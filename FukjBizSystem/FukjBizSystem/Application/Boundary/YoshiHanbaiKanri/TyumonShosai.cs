using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class TyumonShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Add,        // 登録モード
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
        }

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// Display mode
        /// </summary>
        public DispMode _dispMode = DispMode.Add;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Form is loaded?
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 注文番号
        /// </summary>
        private string _yoshiHanbaiChumonNo;

        /// <summary>
        /// 会員価格フラグ
        /// </summary>
        private string _kaiinFlg;

        /// <summary>
        /// 保証登録用紙コード
        /// </summary>
        private string _hosyoTorokuYoushiCd;

        ///// <summary>
        ///// 用紙販売ヘッダテーブル
        ///// </summary>
        //private YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable _hdrTable;

        ///// <summary>
        ///// 業者マスタ
        ///// </summary>
        //private GyoshaMstDataSet.GyoshaMstDataTable _gyoshaMst;

        ///// <summary>
        ///// 用紙在庫テーブル
        ///// </summary>
        //private YoshiZaikoTblDataSet.YoshiZaikoTblDataTable _yoshiZaikoTblDataTable;

        ///// <summary>
        ///// 保証登録テーブル
        ///// </summary>
        //private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable _hoshoTorokuTblDataTable;

        ///// <summary>
        ///// TyumonShosaiDataTable
        ///// </summary>
        //private YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable _dgvSource;

        /// <summary>
        /// currentDt
        /// </summary>
        private DateTime _currentDt = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// YoshiHeaderDataTable
        /// </summary>
        private TyumonShosaiDataSet.YoshiHeaderDataTable _headerTable;

        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        private TyumonShosaiDataSet.YoshiDetailDataTable _detailTable;

        /// <summary>
        /// 変数．保証登録販売フラグ
        /// </summary>
        private bool _hoshoTorokuHanbaiFlg;

        /// <summary>
        /// 消費税率
        /// </summary>
        private decimal _shouhizeiritsu;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TyumonShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TyumonShosaiForm()
        {
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TyumonShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TyumonShosaiForm(string yoshiHanbaiChumonNo)
        {
            this._yoshiHanbaiChumonNo = yoshiHanbaiChumonNo;

            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region イベント

        #region TyumonShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TyumonShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TyumonShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Add mode title
                titleLabel.Text = "注文登録";

                // Detail mode
                if (!string.IsNullOrEmpty(this._yoshiHanbaiChumonNo))
                {
                    this._dispMode = DispMode.Detail;
                    titleLabel.Text = "注文詳細";
                }

                // Load and display default value
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

        #region TyumonShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TyumonShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TyumonShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        entryButton.Focus();
                        entryButton.PerformClick();
                        break;
                    case Keys.F2:
                        changeButton.Focus();
                        changeButton.PerformClick();
                        break;
                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
                        break;
                    case Keys.F4:
                        reInputButton.Focus();
                        reInputButton.PerformClick();
                        break;
                    case Keys.F5:
                        decisionButton.Focus();
                        decisionButton.PerformClick();
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
        /// 2014/07/21　AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyosyaCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Avoid user fire this event without input
                if (string.IsNullOrEmpty(gyosyaCdTextBox.Text))
                {
                    // 業者名称(3)
                    gyosyaNmTextBox.Text = string.Empty;
                    // 担当者(4)
                    //tantoTextBox.Text = string.Empty;
                    // 会員判定ラベル(8)
                    kaiinLabel.Text = string.Empty;

                    return;
                }

                // Forces to 4 digits
                string gyoshaCd = gyosyaCdTextBox.Text.PadLeft(4, '0');

                IGyoshaCdTextBoxLeaveALInput alInput = new GyoshaCdTextBoxLeaveALInput();
                alInput.GyoshaCd = gyoshaCd;
                IGyoshaCdTextBoxLeaveALOutput alOutput = new GyoshaCdTextBoxLeaveApplicationLogic().Execute(alInput);

                // No record was found
                if (alOutput.GyoshaMstDataTable.Count == 0)
                {
                    // Error message
                    MessageForm.Show2(MessageForm.DispModeType.Error, "業者データが存在しません。");

                    // 業者コード(3)
                    gyosyaCdTextBox.Text = string.Empty;
                    // 業者名称(4)
                    gyosyaNmTextBox.Text = string.Empty;
                    // 担当者(5)
                    //tantoTextBox.Text = string.Empty;
                    // 会員判定ラベル(8)
                    kaiinLabel.Text = string.Empty;

                    return;
                }
                else
                {
                    // 業者コード(3)
                    gyosyaCdTextBox.Text = gyoshaCd;
                    // 業者名称(4)
                    gyosyaNmTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaNm;
                    // 担当者(5)
                    //tantoTextBox.Text = alOutput.GyoshaMstDataTable[0].SofusakiTantoshaNm;
                    // 会員判定ラベル(8)
                    SetKaiinLabel(alOutput.GyoshaMstDataTable[0].GyoshaCd);

                    // 2015.01.27 AnhNV ADD Start
                    KinkakuSaikeisanSyori();
                    // 2015.01.27 AnhNV ADD End
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
        /// 2014/07/21　AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
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

                // 業者コード(2)
                gyosyaCdTextBox.Text = frm._selectedRow.GyoshaCd;
                // 業者名称(3)
                gyosyaNmTextBox.Text = frm._selectedRow.GyoshaNm;
                // 担当者(4)
                //tantoTextBox.Text = frm._selectedRow.SofusakiTantoshaNm;

                IGyoshaCdTextBoxLeaveALInput alInput = new GyoshaCdTextBoxLeaveALInput();
                alInput.GyoshaCd = gyosyaCdTextBox.Text;
                IGyoshaCdTextBoxLeaveALOutput alOutput = new GyoshaCdTextBoxLeaveApplicationLogic().Execute(alInput);

                // 会員判定ラベル(8)
                SetKaiinLabel(alOutput.GyoshaMstDataTable[0].GyoshaCd);

                // 2015.01.27 AnhNV ADD Start
                KinkakuSaikeisanSyori();
                // 2015.01.27 AnhNV ADD End
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

        #region entryButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： entryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2015.01.28 AnhNV ADD Start
                // 金額再計算処理
                KinkakuSaikeisanSyori();

                // 20150129 sou Start
                // 単項目チェック + 入力内容チェック
                if (!InputCheck()) return;
                // 20150129 sou End

                // 最新在庫数取得
                IEntryBtnClickALInput alInput = new EntryBtnClickALInput();
                alInput.YoshiZaikoShishoCd = Convert.ToString(shishoNmComboBox.SelectedValue);
                IEntryBtnClickALOutput alOutput = new EntryBtnClickApplicationLogic().Execute(alInput);

                // Set YoshiZaikoSuryo to dgv cells
                if (alOutput.ZaikoSuiDataTable.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
                    {
                        if (Convert.ToString(dgvr.Cells[YoshiCdCol.Name].Value) == alOutput.ZaikoSuiDataTable[0].YoshiCd)
                        {
                            // 在庫数(隠し)(21)
                            dgvr.Cells[zaikoCntHideCol.Name].Value = alOutput.ZaikoSuiDataTable[0].YoshiZaikoSuryo;

                            // 事前在庫数チェック
                            if (!ZaikosuCheck(dgvr))
                            {
                                return;
                            }

                            break;
                        }
                    }
                }
                // 2015.01.28 AnhNV ADD End

                // 2015.01.28 AnhNV DEL Start
                //// 単項目チェック + 入力内容チェック
                //if (!DataCheck()) return;

                //// Calculate data in datagridview
                //DgvCellValueChanged();
                // 2015.01.28 AnhNV DEL End

                // Switches to confirm mode
                this._dispMode = DispMode.Confirm;

                // Set screen title
                SetScreenTitle();

                // Set input/read only property
                ItemControl();
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

        #region changeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： changeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　  新規作成
        /// 2014/10/03　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._dispMode == DispMode.Detail)
                {
                    // Switches to confirm mode
                    this._dispMode = DispMode.Edit;
                }
                else if (this._dispMode == DispMode.Edit)
                {
                    // 2015.01.28 AnhNV ADD Start
                    // 金額再計算処理
                    KinkakuSaikeisanSyori();

                    // 単項目チェック + 入力内容チェック
                    if (!InputCheck()) return;

                    // 処理済チェック
                    if (!SyorisumiCheck()) { return; }

                    // 請求済チェック
                    if (!SeikyuSumiCheck()) { return; }

                    foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
                    {
                        // 事前在庫数チェック
                        if (!ZaikosuCheck(dgvr))
                        {
                            return;
                        }
                    }
                    // 2015.01.28 AnhNV ADD End

                    // Switches to confirm mode
                    this._dispMode = DispMode.Confirm;
                }

                // Calculate data in datagridview
                //DgvCellValueChanged();

                // Set screen title
                SetScreenTitle();

                // Set input/read only property
                ItemControl();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2015.01.28 AnhNV ADD Start
                // 削除チェック
                if (!DeleteCheck()) { return; }
                // 処理済チェック
                if (!SyorisumiCheck()) { return; }
                // 請求済チェック
                if (!SeikyuSumiCheck()) { return; }
                // 2015.01.28 AnhNV ADD End

                //// 2015/01/15 AnhNV ADD Start
                //// 処理済チェック(更新・削除時)
                //if (!ProcessCheck()) { return; }

                //// 保証登録済チェック
                //if (!HoshoTorokuCompleteCheck()) { return; }
                //// 2015/01/15 AnhNV ADD End

                // 2015.01.28 AnhNV DEL Start
                //// 請求済チェック
                //if (Utility.KeiriUtility.ChkSeikyuSumi(Utility.KeiriUtility.SeikyuKbnConstant.YoshiHanbai, _yoshiHanbaiChumonNo) == 1)
                //{
                //    MessageForm.Show2(MessageForm.DispModeType.Error, "既に請求済のため、更新/削除できません。");
                //    return;
                //}
                // 2015.01.28 AnhNV DEL End

                //if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") == DialogResult.Yes)
                //{
                    IDeleteBtnClickALInput delInput = new DeleteBtnClickALInput();
                    delInput.YoshiHanbaiChumonNo = chumonNoTextBox.Text;
                    delInput.YoshiZaikoShishoCd = Convert.ToString(shishoNmComboBox.SelectedValue);
                    delInput.YoshiHeaderDataTable = _headerTable;
                    delInput.YoshiDetailDataTable = (TyumonShosaiDataSet.YoshiDetailDataTable)yoshiListDataGridView.DataSource;
                    IDeleteBtnClickALOutput delOutput = new DeleteBtnClickApplicationLogic().Execute(delInput);

                    // 2015.01.28 AnhNV DEL Start
                    //// SaisuiinCd does not exist
                    //if (!string.IsNullOrEmpty(delOutput.ErrMsg))
                    //{
                    //    MessageForm.Show2(MessageForm.DispModeType.Error, delOutput.ErrMsg);
                    //    return;
                    //}
                    // 2015.01.28 AnhNV DEL End

                    // Close this form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                //}
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
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

        #region reInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： reInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._dispMode = string.IsNullOrEmpty(this._yoshiHanbaiChumonNo) ? DispMode.Add : DispMode.Edit;

                // Screen title
                SetScreenTitle();

                // Item control display
                ItemControl();
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

        #region decisionButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： decisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Update mode?
                if (!string.IsNullOrEmpty(this._yoshiHanbaiChumonNo))
                {
                    // 請求済チェック
                    if (!SeikyuSumiCheck()) { return; }

                    foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
                    {
                        // 最新在庫数チェック
                        //if (!ZaikosuCheck(dgvr)) { return; }
                    }
                }

                //// 2015/01/15 AnhNV ADD Start
                //// 処理済チェック(更新・削除時)
                //if (!ProcessCheck()) { return; }
                //// 2015/01/15 AnhNV ADD End

                IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();
                alInput.UpdateData = MakeUpdateData();
                IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                // Update error
                if (!string.IsNullOrEmpty(alOutput.ErrMsg))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
                    return;
                }

                // Close this form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
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
        /// 2014/07/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Detail mode
                if (this._dispMode == DispMode.Detail)
                {
                    goto SHOWFORM;
                }

                // Add mode
                if (string.IsNullOrEmpty(_yoshiHanbaiChumonNo))
                {
                    if (!EditControl() || MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        goto SHOWFORM;
                    }

                    return;
                }

                // Other modes
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        goto SHOWFORM;
                    }

                    return;
                }

                SHOWFORM:
                // Close this form
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

        #region yoshiListDataGridView_EditingControlShowing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiListDataGridView_EditingControlShowing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Input number only
                if (yoshiListDataGridView.Columns[yoshiListDataGridView.CurrentCell.ColumnIndex].Name == HanbaiCntCol.Name)
                {
                    e.Control.KeyPress += new KeyPressEventHandler(yoshiListDataGridView_ControlKeyPress);
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

        #region yoshiListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Form is loading...
                if (!_isLoad) return;

                // Handle for 販売数(19) only
                if (yoshiListDataGridView.Columns[e.ColumnIndex].Name != HanbaiCntCol.Name) return;

                // No Gyosha is selected
                if (string.IsNullOrEmpty(gyosyaCdTextBox.Text)) return;
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

        #region yoshiListDataGridView_CellLeave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiListDataGridView_CellLeave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/24　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiListDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // This event will be fired in case of focus to 販売数(19)
                if (yoshiListDataGridView.Columns[e.ColumnIndex].Name == HanbaiCntCol.Name)
                {
                    // Ensure value of current cell is changed!
                    yoshiListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    // 2015.01.27 AnhNV ADD Start
                    this._hoshoTorokuHanbaiFlg = yoshiListDataGridView.CurrentRow.Cells[hoshoTorokuFlgHideCol.Name].Value.ToString() == "1";
                    // Clear 保証登録番号From(31), 保証登録番号To(32)
                    hosyoTorokuNoFromTextBox.Text = string.Empty;
                    hosyoTorokuNoToTextBox.Text = string.Empty;
                    // 金額再計算処理
                    KinkakuSaikeisanSyori(yoshiListDataGridView.CurrentRow);
                    // 2015.01.27 AnhNV ADD End

                    // 2015.01.27 AnhNV DEL Start
                    //// 税率
                    //decimal zeiritsu = Common.Common.GetSyohizei(hanbaiDtDateTimePicker.Value.ToString("yyyyMMdd"));

                    //UpdateKingaku(e.RowIndex, zeiritsu);
                    // 2015.01.27 AnhNV DEL End

                    #region to be removed
                    //if (!string.IsNullOrEmpty(Convert.ToString(yoshiListDataGridView.CurrentRow.Cells[HanbaiCntCol.Index].Value)))
                    //{
                    //    // 税率
                    //    decimal zeiritsu = Common.Common.GetSyohizei(hanbaiDtDateTimePicker.Value.ToString("yyyyMMdd"));

                    //    // 会員単価(14)
                    //    decimal kaiinTanka;
                    //    Decimal.TryParse(Convert.ToString(yoshiListDataGridView.CurrentRow.Cells[KaiinTankaCol.Index].Value), out kaiinTanka);

                    //    // 非会員単価(16)
                    //    decimal hiKaiinTanka;
                    //    Decimal.TryParse(Convert.ToString(yoshiListDataGridView.CurrentRow.Cells[HiKaiinTankaCol.Index].Value), out hiKaiinTanka);

                    //    // 販売数(19)
                    //    decimal hanbaiCnt;
                    //    Decimal.TryParse(Convert.ToString(yoshiListDataGridView.CurrentRow.Cells[HanbaiCntCol.Index].Value), out hanbaiCnt);

                    //    // 販売価格(20)
                    //    decimal hanbaiKakaku = _kaiinFlg == "1" ? (kaiinTanka * hanbaiCnt) : (hiKaiinTanka * hanbaiCnt);
                    //    yoshiListDataGridView.CurrentRow.Cells[HanbaiKakakuCol.Index].Value = hanbaiKakaku.ToString("N0");
                        
                    //    // 20150106 端数処理を追加
                    //    // 消費税(21)
                    //    decimal syohizei = Math.Floor(hanbaiKakaku * zeiritsu);
                    //    //decimal syohizei = hanbaiKakaku * zeiritsu;
                    //    yoshiListDataGridView.CurrentRow.Cells[SyohizeiCol.Index].Value = syohizei.ToString("N0");

                    //    // 販売金額(22)
                    //    yoshiListDataGridView.CurrentRow.Cells[HanbaiKingakuCol.Index].Value = (hanbaiKakaku + syohizei).ToString("N0");
                    //}
                    //else
                    //{
                    //    // 販売価格(20)
                    //    yoshiListDataGridView.CurrentRow.Cells[HanbaiKakakuCol.Index].Value = string.Empty;
                    //    // 消費税(21)
                    //    yoshiListDataGridView.CurrentRow.Cells[SyohizeiCol.Index].Value = string.Empty;
                    //    // 販売金額(22)
                    //    yoshiListDataGridView.CurrentRow.Cells[HanbaiKingakuCol.Index].Value = string.Empty;
                    //}
                    #endregion

                    // 2015.01.27 AnhNV DEL Start
                    // 20150106 合計金額を再計算する
                    //UpdateKingakuGokei();
                    // 2015.01.27 AnhNV DEL End

                    #region to be removed
                    //// Total of 販売金額(22)
                    //hanbaiKingakuTotal += hanbaiKakaku + syohizei;

                    //// 合計金額(10)
                    //totalKingakuTextBox.Text = (hanbaiKingakuTotal + Convert.ToDecimal(!string.IsNullOrEmpty(soryoTextBox.Text) ? soryoTextBox.Text : "0")).ToString("N0");
                    #endregion
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

        #region soryoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/06　habu　　    処理見直し
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        private void soryoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2015.01.27 AnhNV MOD Start
                // 合計金額を更新
                //UpdateKingakuGokei();
                KinkakuSaikeisanSyori();
                // 2015.01.27 AnhNV MOD End
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

        #region genkinNyukinCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： genkinNyukinCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void genkinNyukinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!genkinNyukinCheckBox.Checked)
                {
                    // Enable 送料(30)
                    soryoTextBox.ReadOnly = false;
                }
                else
                {
                    // Clear and disable 送料(30)
                    soryoTextBox.Text = string.Empty;
                    soryoTextBox.ReadOnly = true;
                    // 金額再計算処理
                    KinkakuSaikeisanSyori();
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

        #region hanbaiDtDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hanbaiDtDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hanbaiDtDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_isLoad) { return; }

                decimal newShouhizeiritsu = Common.Common.GetSyohizei(hanbaiDtDateTimePicker.Value.ToString("yyyyMMdd"));
                if (_shouhizeiritsu != newShouhizeiritsu)
                {
                    KinkakuSaikeisanSyori();
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

        #region hosyoTorokuNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hosyoTorokuNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hosyoTorokuNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Stop handle for non-input
                if (string.IsNullOrEmpty(hosyoTorokuNoFromTextBox.Text)) { return; }
                // Stop handle for non-inputable
                if (hosyoTorokuNoFromTextBox.ReadOnly) { return; }

                // 保証登録番号チェック
                string hoshoTorokuNoFrom, hoshoTorokuNoTo;
                if (HoshoTorokuBangoCheck(out hoshoTorokuNoFrom, out hoshoTorokuNoTo))
                {
                    hosyoTorokuNoFromTextBox.Text = hoshoTorokuNoFrom;
                    hosyoTorokuNoToTextBox.Text = hoshoTorokuNoTo;
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
        /// 2014/07/21  AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/11/07　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.09
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            yoshiListDataGridView.DataSource = null;
            yoshiListDataGridView.Rows.Clear();

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.YoshiHanbaiChumonNo = this._yoshiHanbaiChumonNo;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            _detailTable = alOutput.YoshiDetailDataTable;

            // 変数．保証登録用紙コード
            this._hosyoTorokuYoushiCd = alOutput.HoshoTorokuYoshiCd;
            //  変数．保証登録販売フラグ
            this._hoshoTorokuHanbaiFlg = alOutput.HoshoTorokuHanbaiFlg;

            // 支所(2)
            Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", false);
            shishoNmComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 担当者(6)
            Utility.Utility.SetComboBoxList(tantoComboBox, alOutput.ShokuinMstDataTable, "ShokuinNm", "ShokuinCd", false);
            tantoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

            // Update mode
            if (!string.IsNullOrEmpty(this._yoshiHanbaiChumonNo))
            {
                _headerTable = alOutput.YoshiHeaderDataTable;

                // Default selected for 支所(2) & 担当者(6)
                shishoNmComboBox.SelectedValue = _headerTable[0].YoshiHanbaiShishoCd;
                tantoComboBox.SelectedValue = _headerTable[0].YoshiHanbaiShokuinCd;

                // 業者コード(3)
                gyosyaCdTextBox.Text = _headerTable[0].GyoshaCd;
                // 会員判定処理
                SetKaiinLabel(_headerTable[0].GyoshaCd);
                // 業者名称(4)
                gyosyaNmTextBox.Text = _headerTable[0].GyoshaNm;
                // 販売日(7)
                hanbaiDtDateTimePicker.Value = !string.IsNullOrEmpty(_headerTable[0].YoshiHanbaiDt) ? Convert.ToDateTime(_headerTable[0].YoshiHanbaiDt)
                    : _currentDt;
                // 現金入金(8)
                if (!_headerTable[0].IsYoshiHanbaiSeikyuKingakuNull())
                {
                    // 現金入金(8)
                    if (_headerTable[0].YoshiHanbaiSeikyuKingaku > 0)
                    {
                        genkinNyukinCheckBox.Checked = true;
                    }
                    else if (_headerTable[0].YoshiHanbaiSeikyuKingaku == 0 &&
                        Utility.KeiriUtility.ChkSeikyuSumi(Utility.KeiriUtility.SeikyuKbnConstant.YoshiHanbai, _yoshiHanbaiChumonNo) == 1)
                    {
                        genkinNyukinCheckBox.Checked = false;
                    }
                }

                // 保証登録番号From(31)
                hosyoTorokuNoFromTextBox.Text = alOutput.HoshoTorokuNoFrom;
                // 保証登録番号To(32)
                hosyoTorokuNoToTextBox.Text = alOutput.HoshoTorokuNoTo;

                // Screen mode
                _dispMode = DispMode.Detail;
            }
            else // Add mode
            {
                _dispMode = DispMode.Add;
            }

            // Get 消費税率
            this._shouhizeiritsu = Common.Common.GetSyohizei(hanbaiDtDateTimePicker.Value.ToString("yyyyMMdd"));

            // 用紙一覧グリッドビュー
            yoshiListDataGridView.DataSource = _detailTable;

            // Screen title
            SetScreenTitle();
            // Display/Input control
            ItemControl();
            // Format Dgv
            yoshiListDataGridView.Font = new Font("Meiryo", 17.75F, GraphicsUnit.Pixel);
            yoshiListDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            // Loaded OK
            this._isLoad = true;

            #region
            // 2015.01.26 AnhNV DEL Start
            //// 用紙在庫テーブル
            //this._yoshiZaikoTblDataTable = alOutput.YoshiZaikoTblDataTable;

            //// 保証登録テーブル
            //this._hoshoTorokuTblDataTable = alOutput.HoshoTorokuTblDataTable;

            //// Get 保証登録用紙コード
            //this._hosyoTorokuYoushiCd = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_001, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

            //// 支所(1)
            //Utility.Utility.SetComboBoxList(shishoNmComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);

            //// 販売日(5)
            //hanbaiDtDateTimePicker.Value = _currentDt;

            //// Display default value in Detail mode
            //if (this._dispMode == DispMode.Detail)
            //{
            //    // 業者マスタ
            //    this._gyoshaMst = alOutput.GyoshaMstDataTable;

            //    // YoshiHanbaiHdrTblDataTable
            //    this._hdrTable = alOutput.YoshiHanbaiHdrTblDataTable;

            //    // Default value
            //    DisplayDefault();

            //    // 会員判定ラベル(8)
            //    SetKaiinLabel(_gyoshaMst[0].GyoshaCd);
            //}
            //else
            //{
            //    // 現金入金(30)
            //    genkinNyukinCheckBox.Checked = true;
            //}

            //// 用紙一覧グリッドビュー(9)
            //_dgvSource = alOutput.TyumonShosaiDataTable;
            //yoshiListDataGridView.DataSource = _dgvSource;

            //if (this._dispMode == DispMode.Detail)
            //{
            //    // Default value for (20), (21), (22)
            //    DgvCellValueChanged(false);
            //}

            //// Title of screen
            //SetScreenTitle();

            //// Display/Input control
            //ItemControl();

            //// Focus to 支所(1)
            //shishoNmComboBox.Focus();
            //// Font Dgv
            //yoshiListDataGridView.Font = new Font("Meiryo", 17.75F, GraphicsUnit.Pixel);

            //// Loaded OK
            //this._isLoad = true;
            // 2015.01.26 AnhNV DEL End
            #endregion
        }
        #endregion

        #region DisplayDefault
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDefault
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/06　habu　　    処理見直し
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void DisplayDefault()
        //{
        //    // 支所(1)
        //    shishoNmComboBox.SelectedValue = _hdrTable[0].YoshiHanbaiShishoCd;

        //    // 業者コード(2)
        //    gyosyaCdTextBox.Text = _gyoshaMst.Count > 0 ? _gyoshaMst[0].GyoshaCd : string.Empty;

        //    // 業者名称(3)
        //    gyosyaNmTextBox.Text = _gyoshaMst.Count > 0 ? _gyoshaMst[0].GyoshaNm : string.Empty;

        //    // 担当者(4)
        //    tantoTextBox.Text = _hdrTable[0].YoshiHanbaisakiTantosha;

        //    // 販売日(5)
        //    hanbaiDtDateTimePicker.Value = DateTime.ParseExact(_hdrTable[0].YoshiHanbaiDt, "yyyyMMdd", CultureInfo.InvariantCulture);

        //    // 注文番号(7)
        //    chumonNoTextBox.Text = _hdrTable[0].YoshiHanbaiChumonNo;

        //    // 合計金額(8)
        //    totalKingakuTextBox.Text = _hdrTable[0].YoshiHanbaiGokeiKingaku.ToString("N0");

        //    // 現金入金(30)
        //    if (!_hdrTable[0].IsYoshiHanbaiGenkinNyukingakuNull()) // 2014/12/15 AnhNV hot fixed
        //    {
        //        if (_hdrTable[0].YoshiHanbaiGenkinNyukingaku > 0)
        //        {
        //            genkinNyukinCheckBox.Checked = true;
        //            // 20150106 Handle in ItemControl
        //            //genkinNyukinCheckBox.Enabled = false;
        //        }
        //        else if (_hdrTable[0].YoshiHanbaiGenkinNyukingaku == 0
        //            && Utility.KeiriUtility.ChkSeikyuSumi(Utility.KeiriUtility.SeikyuKbnConstant.YoshiHanbai, _yoshiHanbaiChumonNo) == 1)
        //        {
        //            genkinNyukinCheckBox.Checked = false;
        //            // 20150106 Handle in ItemControl
        //            //genkinNyukinCheckBox.Enabled = false;
        //        }
        //    }

        //    // 20150106 habu 送料を追加
        //    // 送料(31)
        //    soryoTextBox.Text = _hdrTable[0].YoshiHanbaiSoryo.ToString("G0");
        //}
        #endregion

        #region SetScreenTitle
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetScreenTitle
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (_dispMode)
            {
                case DispMode.Detail:
                    titleLabel.Text = "注文詳細";
                    break;
                case DispMode.Add:
                    titleLabel.Text = "注文登録";
                    break;
                case DispMode.Confirm:
                    titleLabel.Text = "注文入力確認";
                    break;
                case DispMode.Edit:
                    titleLabel.Text = "注文変更";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ItemControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ItemControl
        /// <summary>
        /// Control the input/display property of all items
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/06　habu　　    不具合対応
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemControl()
        {
            bool disabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? false : true;
            bool keyContDisabled = (_dispMode == DispMode.Add) ? false : true;
            // 2015.01.27 AnhNV DEL Start
            //bool kingakuDisabled = (_dispMode == DispMode.Add || _dispMode == DispMode.Edit) ? false : true;

            //// 20150106 habu 入金関連項目の活性判定箇所をその他の項目と同じ個所に移動
            //if (!kingakuDisabled)
            //{
            //    if (_hdrTable != null && _hdrTable[0].YoshiHanbaiGenkinNyukingaku > 0)
            //    {
            //        kingakuDisabled = true;
            //    }
            //    else if (_hdrTable != null && _hdrTable[0].YoshiHanbaiGenkinNyukingaku == 0
            //        && Utility.KeiriUtility.ChkSeikyuSumi(Utility.KeiriUtility.SeikyuKbnConstant.YoshiHanbai, _yoshiHanbaiChumonNo) == 1)
            //    {
            //        kingakuDisabled = true;
            //    }
            //}
            // 2015.01.27 AnhNV DEL End

            // 支所(1)
            shishoNmComboBox.Enabled = !keyContDisabled;
            // 業者(2)
            gyosyaCdTextBox.ReadOnly = keyContDisabled;
            // 業者検索ボタン(6)
            gyosyaSrhButton.Enabled = !keyContDisabled;
            // 担当者(4)
            tantoComboBox.Enabled = !disabled;
            // 販売日(5)
            hanbaiDtDateTimePicker.Enabled = !disabled;
            // セット部数(18)
            yoshiListDataGridView.Columns[SetBusuCol.Index].ReadOnly = disabled;
            // 販売数(19)
            yoshiListDataGridView.Columns[HanbaiCntCol.Index].ReadOnly = disabled;
            // TODO 更新時の編集使用は別途調整が必要
            
            if (_dispMode == DispMode.Add)
            {
                // 現金入金チェックボックス(8)
                genkinNyukinCheckBox.Enabled = true;
            }
            else if (_dispMode == DispMode.Edit)
            {
                // 現金入金チェックボックス(8)
                genkinNyukinCheckBox.Enabled = !(_headerTable[0].YoshiHanbaiSeikyuKingaku > 0);
                // 送料(30)
                soryoTextBox.ReadOnly = !(_headerTable[0].YoshiHanbaiSeikyuKingaku > 0);
            }
            else if (_dispMode == DispMode.Confirm)
            {
                // 現金入金チェックボックス(8)
                genkinNyukinCheckBox.Enabled = false;
                // 送料(30)
                soryoTextBox.ReadOnly = true;
            }
            // 送料(31)
            //soryoTextBox.ReadOnly = kingakuDisabled;
            // TODO 更新時の編集使用は別途調整が必要
            // 保証登録番号From(31)
            hosyoTorokuNoFromTextBox.ReadOnly = disabled;
            // 保証登録番号To(32)
            hosyoTorokuNoToTextBox.ReadOnly = _dispMode != DispMode.Add;

            #region command buttons

            // 登録ボタン(19)
            entryButton.Visible = (this._dispMode == DispMode.Add) ? true : false;

            // 変更ボタン(20)
            changeButton.Visible = (this._dispMode == DispMode.Detail || this._dispMode == DispMode.Edit) ? true : false;

            // 削除ボタン(21)
            deleteButton.Visible = (this._dispMode == DispMode.Detail) ? true : false;

            // 再入力ボタン(22)
            reInputButton.Visible =

            // 確定ボタン(23)
            decisionButton.Visible = (this._dispMode == DispMode.Confirm) ? true : false;

            #endregion
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  AnhNV　　    新規作成
        /// 2014/10/06　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private bool DataCheck()
        //{
        //    // Error messages
        //    StringBuilder errMsg = new StringBuilder();

        //    // 支所(1)
        //    if (shishoNmComboBox.SelectedIndex <= 0)
        //    {
        //        errMsg.Append("必須項目：支所が選択されていません。\r\n");
        //    }

        //    // 業者(2)
        //    if (string.IsNullOrEmpty(gyosyaCdTextBox.Text.Trim()))
        //    {
        //        errMsg.Append("必須項目：業者が入力されていません。\r\n");
        //    }
        //    else if (!Utility.Utility.IsDecimal(gyosyaCdTextBox.Text))
        //    {
        //        errMsg.Append("業者は半角数字で入力して下さい。\r\n\r\n");
        //    }
        //    else if (gyosyaCdTextBox.Text.Length != 4)
        //    {
        //        errMsg.Append("業者は4桁で入力して下さい。\r\n");
        //    }

        //    // 担当者(4)
        //    //if (string.IsNullOrEmpty(tantoTextBox.Text.Trim()))
        //    //{
        //    //    errMsg.Append("必須項目：担当者が入力されていません。\r\n");
        //    //}
        //    //else if (tantoTextBox.Text.Length > 20)
        //    //{
        //    //    errMsg.Append("担当者は20文字以下で入力して下さい。\r\n");
        //    //}

        //    // 入力内容チェック
        //    if (string.IsNullOrEmpty(errMsg.ToString()))
        //    {
        //        #region 用紙一覧グリッドビュー check

        //        int rowCnt = 0;
        //        //string err17_1 = string.Empty;
        //        //string err17_2 = string.Empty;
        //        //string err17_3 = string.Empty;
        //        //string err18_1 = string.Empty;
        //        //string err18_2 = string.Empty;
        //        //string err18_3 = string.Empty;
        //        //string err18_4 = string.Empty;
        //        //string err18_5 = string.Empty;
        //        //string err19 = string.Empty;        //受入20141222 del
        //        bool saleCntInpFlg = false;            //受入20141222 add
        //        string zaikosuErr = string.Empty;
        //        // バラ販売数(17)
        //        //int hanbaiCnt = 0;
        //        //// セット販売数(18)
        //        //int setHanbaiCnt = 0;
        //        //// セット部数(16)
        //        //int setBusu = 0;
        //        //// 在庫数量
        //        //int yoshiZaikoSuryo = 0;

        //        // 用紙一覧グリッドビュー(9)
        //        foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
        //        {
        //            //// 販売数(19) is empty
        //            //if (string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value)))
        //            //{
        //            //    err19 += rowCnt + 1 + ", ";
        //            //}
        //            // 販売数(19) is not empty
        //            if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value)))
        //            {
        //                saleCntInpFlg = true;
        //            }

        //            // Check for 保証登録用紙コード
        //            if (dgvr.Cells[YoshiCdCol.Index].Value.ToString() == _hosyoTorokuYoushiCd)
        //            {
        //                // 保証登録未入力チェック
        //                if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value))
        //                    && string.IsNullOrEmpty(hosyoTorokuNoFromTextBox.Text))
        //                {
        //                    errMsg.AppendLine("販売する開始保証登録番号を入力してください。");
        //                }

        //                // 保証登録不要チェック
        //                if (string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value))
        //                    && !string.IsNullOrEmpty(hosyoTorokuNoFromTextBox.Text))
        //                {
        //                    errMsg.AppendLine("保証登録用紙の販売はないので、保証登録番号は入力しないでください。");
        //                }

        //                // 保証登録存在チェック
        //                if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value))
        //                    && !string.IsNullOrEmpty(hosyoTorokuNoFromTextBox.Text)
        //                    && hosyoTorokuNoFromTextBox.Text.Length == 11
        //                    && Utility.Utility.IsDecimal(hosyoTorokuNoFromTextBox.Text))
        //                {
        //                    string kikan = hosyoTorokuNoFromTextBox.Text.Substring(0, 4);
        //                    string nendo = Utility.DateUtility.ConvertFromWareki(hosyoTorokuNoFromTextBox.Text.Substring(4, 2), "yyyy");
        //                    string renban = hosyoTorokuNoFromTextBox.Text.Substring(6);
        //                    DataRow[] hoshoRow = _hoshoTorokuTblDataTable.Select(string.Format("HoshoTorokuKensakikan = '{0}' and HoshoTorokuNendo = '{1}' and HoshoTorokuRenban = '{2}' and HoshoTorokuDeleteFlg = '0'",
        //                        kikan, nendo, renban));

        //                    if (hoshoRow.Length == 0)
        //                    {
        //                        errMsg.AppendLine("入力した保証登録番号は存在しません。");
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(_yoshiHanbaiChumonNo)) // check for update mode
        //                {
        //                    // 2015/01/15 AnhNV DEL Start
        //                    //// 処理済チェック
        //                    //if (_hdrTable[0].IsYoshiHanbaiGenkinNyukingakuNull() || _hdrTable[0].YoshiHanbaiGenkinNyukingaku != 0
        //                    //    || _hdrTable[0].IsYoshiHanbaiSeikyuKingakuNull() || _hdrTable[0].YoshiHanbaiSeikyuKingaku != 0
        //                    //    || _hdrTable[0].IsYoshiHanbaiKansaiFlgNull() || _hdrTable[0].YoshiHanbaiKansaiFlg != "0"
        //                    //    || _hdrTable[0].IsYoshiHanbaiSeikyushoHakkoFlgNull() || _hdrTable[0].YoshiHanbaiSeikyushoHakkoFlg != "0"
        //                    //    || _hdrTable[0].IsYoshiHanbaiNohinshoHakkoFlgNull() || _hdrTable[0].YoshiHanbaiNohinshoHakkoFlg != "0"
        //                    //    || _hdrTable[0].IsYoshiHanbaiHassoFlgNull() || _hdrTable[0].YoshiHanbaiHassoFlg != "0")
        //                    //{
        //                    //    errMsg.AppendLine("既に処理済のため、更新/削除できません。");
        //                    //}
        //                    // 2015/01/15 AnhNV DEL End

        //                    if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value)))
        //                    {
        //                        // 保証登録済チェック
        //                        DataRow[] hoshoRow2 = _hoshoTorokuTblDataTable.Select(
        //                            string.Format("HoshoTorokuShishoKbn = '{0}' and HoshoTorokuUriageDt = '{1}' and HoshoTorokuHanbaisakiCd = '{2}' and isnull(HoshoTorokuTorokuKakuninDt, '') <> ''",
        //                            _hdrTable[0].YoshiHanbaiShishoCd, _hdrTable[0].YoshiHanbaiDt, _hdrTable[0].YoshiHanbaisakiGyoshaCd));

        //                        if (hoshoRow2.Length > 0)
        //                        {
        //                            errMsg.AppendLine("既に処理済のため、更新/削除できません。");
        //                        }
        //                    }

        //                    // 請求済チェック
        //                    // 2015/01/15 AnhNV ADD Start
        //                    if (Utility.KeiriUtility.ChkSeikyuSumi(Utility.KeiriUtility.SeikyuKbnConstant.YoshiHanbai, _yoshiHanbaiChumonNo) == 1)
        //                    {
        //                        errMsg.AppendLine("既に請求済のため、更新/削除できません。");
        //                    }
        //                    // 2015/01/15 AnhNV ADD End
        //                }
        //            }

        //            //// バラ販売数(17)
        //            //if (dgvr.Cells[HanbaiCnt.Index].Value == null
        //            //    || string.IsNullOrEmpty(dgvr.Cells[HanbaiCnt.Index].Value.ToString()))
        //            //{

        //            //}
        //            //else if (!Utility.Utility.IsDecimal(dgvr.Cells[HanbaiCnt.Index].Value.ToString()))
        //            //{
        //            //    err17_2 += rowCnt + 1 + ", ";
        //            //}
        //            //else
        //            //{
        //            //    isInputHanbaiCnt = true;
        //            //}

        //            //// セット販売数(18)
        //            //if (dgvr.Cells[SetHanbaiCnt.Index].Value == null
        //            //    || string.IsNullOrEmpty(dgvr.Cells[SetHanbaiCnt.Index].Value.ToString()))
        //            //{

        //            //}
        //            //else if (!Utility.Utility.IsDecimal(dgvr.Cells[SetHanbaiCnt.Index].Value.ToString()))
        //            //{
        //            //    err18_2 += rowCnt + 1 + ", ";
        //            //}
        //            //else
        //            //{
        //            //    isInputHanbaiCnt = true;
        //            //}

        //            // セット部数(16) is blank and セット販売数(18) is not blank
        //            //if (dgvr.Cells[SetHanbaiCnt.Index].Value != null && !string.IsNullOrEmpty(dgvr.Cells[SetHanbaiCnt.Index].Value.ToString())
        //            //    && (dgvr.Cells[SetBusuCol.Index].Value == null || string.IsNullOrEmpty(dgvr.Cells[SetBusuCol.Index].Value.ToString())))
        //            //{
        //            //    err18_4 += rowCnt + 1 + ", ";
        //            //}

        //            #region Zaikosu check

        //            if (shishoNmComboBox.SelectedIndex > 0)
        //            {
        //                // Does not check empty cells
        //                if (dgvr.Cells[HanbaiCntCol.Index].Value != null && !string.IsNullOrEmpty(dgvr.Cells[HanbaiCntCol.Index].Value.ToString().Trim()))
        //                {
        //                    // 支所コード
        //                    string shishoCd = shishoNmComboBox.SelectedValue.ToString();
        //                    // 販売用紙コード
        //                    string yoshiCd = dgvr.Cells[YoshiCdCol.Index].Value.ToString();
        //                    YoshiZaikoTblDataSet.YoshiZaikoTblRow[] zaikoRow =
        //                        (YoshiZaikoTblDataSet.YoshiZaikoTblRow[])_yoshiZaikoTblDataTable.Select(string.Format("YoshiZaikoShishoCd = '{0}' and YoshiZaikoYoshiCd = '{1}'", shishoCd, yoshiCd));

        //                    // No data in YoshiZaikoTbl?
        //                    if (zaikoRow.Length > 0)
        //                    {
        //                        //受入20141222 mod sta 新規登録時は"Set"を空で固定取得してるので、使えない。代わりにセット部数を使う。
        //                        //// セット有の場合: Set
        //                        //if (dgvr.Cells[SetCol.Index].Value.ToString() == "1")
        //                        // セット有の場合: SetBusu
        //                        if (!dgvr.Cells[SetBusuCol.Index].Value.ToString().Trim().Equals(String.Empty))
        //                        {
        //                            // セット部数(18) * 販売数(19) > 用紙在庫テーブルの在庫数量
        //                            if (Convert.ToDecimal(dgvr.Cells[SetBusuCol.Index].Value) * Convert.ToDecimal(dgvr.Cells[HanbaiCntCol.Index].Value)
        //                                > zaikoRow[0].YoshiZaikoSuryo)
        //                            {
        //                                zaikosuErr += rowCnt + 1 + ", ";    //受入20141222 行番号は１始まりにする
        //                            }
        //                        }
        //                        else // セット無の場合: Not set
        //                        {
        //                            // 販売数(19) > 用紙在庫テーブルの在庫数量
        //                            if (Convert.ToDecimal(dgvr.Cells[HanbaiCntCol.Index].Value) > zaikoRow[0].YoshiZaikoSuryo)
        //                            {
        //                                zaikosuErr += rowCnt + 1 + ", ";    //受入20141222 行番号は１始まりにする
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            #endregion

        //            // Next row
        //            rowCnt++;
        //        }

        //        //受入20141222 mod sta
        //        //if (!string.IsNullOrEmpty(err19))
        //        //{
        //        //    errMsg.AppendLine(string.Format("行{0}: 販売数を入力して下さい。", err19.Remove(err19.Length - 2)));
        //        //}
        //        if (!saleCntInpFlg)
        //        {
        //            errMsg.AppendLine(string.Format("販売数を入力して下さい。"));
        //        }
        //        //受入20141222 mod end

        //        if (!string.IsNullOrEmpty(zaikosuErr))
        //        {
        //            errMsg.AppendLine(string.Format("行{0}: 販売数が在庫数を超えています。", zaikosuErr.Remove(zaikosuErr.Length - 2)));
        //        }

        //        //if (!isInputHanbaiCnt)
        //        //{
        //        //    errMsg.Append("販売数、セット販売数を入力して下さい。\r\n");
        //        //}

        //        //if (err17_2 != string.Empty)
        //        //{
        //        //    errMsg.Append(string.Format("行{0}: 販売数は半角数字で入力して下さい。\r\n", err17_2.Remove(err17_2.Length - 2)));
        //        //}

        //        //if (err18_2 != string.Empty)
        //        //{
        //        //    errMsg.Append(string.Format("行{0}: セット販売数は半角数字で入力して下さい。\r\n", err18_2.Remove(err18_2.Length - 2)));
        //        //}

        //        //if (err18_3 != string.Empty)
        //        //{
        //        //    errMsg.Append(string.Format("行{0}: セット販売数は4文字以下で入力して下さい。\r\n", err18_3.Remove(err18_3.Length - 2)));
        //        //}

        //        //if (err18_4 != string.Empty)
        //        //{
        //        //    errMsg.Append(string.Format("行{0}: セット販売対象外の用紙にセット販売数が入力されています。\r\n", err18_4.Remove(err18_4.Length - 2)));
        //        //}

        //        //if (err18_5 != string.Empty)
        //        //{
        //        //    errMsg.Append(string.Format("行{0}: 販売数が在庫数を超えています。", err18_5.Remove(err18_5.Length - 2)));
        //        //}

        //        #endregion
        //    }

        //    // 保証登録番号(32)
        //    if (string.IsNullOrEmpty(hosyoTorokuNoFromTextBox.Text))
        //    {

        //    }
        //    else if (hosyoTorokuNoFromTextBox.Text.Length != 11)
        //    {
        //        errMsg.AppendLine("保証登録番号は11桁で入力して下さい。");
        //    }
        //    else if (!Utility.Utility.IsDecimal(hosyoTorokuNoFromTextBox.Text))
        //    {
        //        errMsg.AppendLine("保証登録番号は半角数字で入力して下さい。");
        //    }

        //    // Throw error messages
        //    if (!string.IsNullOrEmpty(errMsg.ToString()))
        //    {
        //        MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
        //        return false;
        //    }

        //    return true;
        //}
        #endregion

        #region EditCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditCheck
        /// <summary>
        /// Trigger when any item is modified
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            if (_dispMode == DispMode.Add)
            {
                // 支所(1)
                if (Convert.ToString(shishoNmComboBox.SelectedValue) != _headerTable[0].YoshiHanbaiShishoCd) return false;

                // 業者コード(2)
                //string gyoshaCd = _gyoshaMst.Count > 0 ? _gyoshaMst[0].GyoshaCd : string.Empty;
                if (gyosyaCdTextBox.Text != _headerTable[0].GyoshaCd) return false;
            }

            // 担当者(4)
            if (Convert.ToString(tantoComboBox.SelectedValue) != _headerTable[0].YoshiHanbaiShokuinCd) return false;

            // 販売日(5)
            DateTime hanbaiDt;
            DateTime.TryParse(_headerTable[0].YoshiHanbaiDt, out hanbaiDt);
            if (hanbaiDtDateTimePicker.Value.Date != hanbaiDt.Date) return false;

            // 用紙一覧グリッドビュー(9)
            foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
            {
                // 販売数(17)
                //if (!dgvr.Cells[HanbaiCnt.Index].Value.Equals(_dgvSource[dgvr.Index].YoshiHanbaiSuryo)) return false;

                // セット販売数(18)
                //if (!dgvr.Cells[SetHanbaiCnt.Index].Value.Equals(_dgvSource[dgvr.Index].YoshiHanbaiSetSuryo)) return false;
            }

            return true;
        }
        #endregion

        #region EditControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditControl
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// TRUE: Control is edited
        /// FALSE: Control is not edited
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditControl()
        {
            // Any item is edited
            if (shishoNmComboBox.SelectedIndex > 0
                || !string.IsNullOrEmpty(gyosyaCdTextBox.Text.Trim())
                //|| !string.IsNullOrEmpty(tantoTextBox.Text.Trim())
                || hanbaiDtDateTimePicker.Value.ToString("yyyyMMdd") != _currentDt.ToString("yyyyMMdd"))
            {
                return true;
            }

            // 用紙一覧グリッドビュー
            foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value)))
                    // 20141017 habu HotFix
                    // || (dgvr.Cells[SetHanbaiCnt.Index].Value != null && dgvr.Cells[SetHanbaiCnt.Index].Value.ToString() != string.Empty)
                {
                    return true;
                }
            }

            // No items is edited
            return false;
        }
        #endregion

        #region MakeUpdateData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeUpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2014/10/03  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/28　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private UpdateData MakeUpdateData()
        {
            // Current system date
            DateTime now = Common.Common.GetCurrentTimestamp();

            // Instantiate a new UpdateData
            UpdateData update = new UpdateData();

            // Get nendo by System date
            int nendo = Utility.DateUtility.GetNendo(now);

            // 表示モード
            update.DispMode = string.IsNullOrEmpty(this._yoshiHanbaiChumonNo) ? DispMode.Add : DispMode.Edit;
            // Current datetime
            update.Now = now;
            // 注文番号　//受入20141222 注文番号の前部に年度を付ける。
            update.YoshiHanbaiChumonNo = string.IsNullOrEmpty(this._yoshiHanbaiChumonNo) ? nendo.ToString() + Utility.Saiban.GetSaibanRenban(nendo.ToString(), "02") : _yoshiHanbaiChumonNo;
            // 合計金額
            update.YoshiHanbaiGokeiKingaku = !string.IsNullOrEmpty(totalKingakuTextBox.Text) ? Convert.ToDecimal(totalKingakuTextBox.Text) : 0;
            // 用紙販売ヘッダテーブル update
            //update.YoshiHanbaiHdrTblDataTable = !string.IsNullOrEmpty(this._yoshiHanbaiChumonNo) ? CreateYoshiHanbaiHdrUpdate(this._hdrTable) 
            //    : new YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable();
            // 販売先業者コード
            update.YoshiHanbaisakiGyoshaCd = gyosyaCdTextBox.Text;
            // 販売先担当者
            update.YoshiHanbaisakiTantosha = Convert.ToString(tantoComboBox.SelectedValue);
            // 支所コード
            update.YoshiHanbaiShishoCd = Convert.ToString(shishoNmComboBox.SelectedValue);
            // 販売日
            update.YoshiHanbaiDt = hanbaiDtDateTimePicker.Value;
            // 会員区分
            //update.KaiinKbn = _gyoshaMst.Select(string.Format("GyoshaCd = '{0}'", gyosyaCdTextBox.Text))[0]["KaiinKbn"].ToString();
            // 用紙一覧グリッドビュー
            //update.YoshiListDgv = yoshiListDataGridView;
            // 送料(31)
            update.YoshiHanbaiSoryo = Convert.ToDecimal(!string.IsNullOrEmpty(soryoTextBox.Text) ? soryoTextBox.Text : "0");
            // 保証登録番号(32)
            update.HoshoTorokuNo = hosyoTorokuNoFromTextBox.Text;
            // 保証登録用紙コード
            update.HosyoTorokuYoushiCd = _hosyoTorokuYoushiCd;
            // 会員価格フラグ
            update.KaiinFlg = _kaiinFlg;
            // 担当者
            //update.Tanto = tantoTextBox.Text;
            // 現金入金(30)
            update.GenkinNyukinCheck = genkinNyukinCheckBox.Checked;
            // 年度
            update.Nendo = nendo;
            // 業者名称
            update.GyoshaNm = gyosyaNmTextBox.Text;
            //// 用紙販売ヘッダテーブル
            //update.YoshiHanbaiHdrTblDataTable = _hdrTable;
            //// 用紙在庫テーブル
            //update.YoshiZaikoTblDataTable = _yoshiZaikoTblDataTable;
            //// 保証登録テーブル
            //update.HoshoTorokuTblDataTable = _hoshoTorokuTblDataTable;
            // 2015.01.28 AnhNV ADD Start
            update.HoshoTorokuHanbaiFlg = _hoshoTorokuHanbaiFlg;
            //update.HoshoTorokuAkibanDataTable = _
            update.YoshiDetailDataTable = (TyumonShosaiDataSet.YoshiDetailDataTable)yoshiListDataGridView.DataSource;
            update.YoshiHeaderDataTable = _headerTable;
            // 2015.01.28 AnhNV ADD End

            return update;
        }
        #endregion

        #region CreateYoshiHanbaiHdrUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiHanbaiHdrUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable CreateYoshiHanbaiHdrUpdate(YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable table)
        {
            // 販売先担当者
            //table[0].YoshiHanbaisakiTantosha = tantoTextBox.Text;

            // 販売合計金額
            table[0].YoshiHanbaiGokeiKingaku = Convert.ToDecimal(totalKingakuTextBox.Text);

            // 販売日
            table[0].YoshiHanbaiDt = hanbaiDtDateTimePicker.Value.ToString("yyyyMMdd");

            return table;
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
        /// 2014/07/28　AnhNV　　    新規作成
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

        #region yoshiListDataGridView_ControlKeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： yoshiListDataGridView_ControlKeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　AnhNV　　    新規作成
        /// 2014/10/03　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiListDataGridView_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            // Input number only
            if (yoshiListDataGridView.Columns[yoshiListDataGridView.CurrentCell.ColumnIndex].Name == HanbaiCntCol.Name)
            {
                e.Handled = !IsOKForDecimalTextBox(e.KeyChar, sender as TextBox) ? true : false;
            }
        }
        #endregion

        #region SetKaiinLabel
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKaiinLabel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKaiinLabel(string gyoshaCd)
        {
            int kaiinHantei = Utility.KaiinUtility.KaiinHantei(gyoshaCd);
            _kaiinFlg = Utility.KaiinUtility.KaiinKakakuTekiyoHantei(gyoshaCd).ToString();

            // 会員
            if (kaiinHantei == 1)
            {
                kaiinLabel.Text = "会員";
            }
            else
            {
                // 非会員（会員価格）
                if (_kaiinFlg == "1")
                {
                    kaiinLabel.Text = "非会員（会員価格）";
                }
                else // 非会員
                {
                    kaiinLabel.Text = "非会員";
                }
            }
        }
        #endregion

        #region DgvCellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DgvCellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/06　habu　　   処理見直し
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DgvCellValueChanged(bool isSetKingaku = true)
        {
            // 税率
            decimal zeiritsu = Common.Common.GetSyohizei(hanbaiDtDateTimePicker.Value.ToString("yyyyMMdd"));

            foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
            {
                #region to be removed
                //// Skip HousyoTorokuYoushiCd row
                //if (dgvr.Cells[YoshiCdCol.Name].Value.ToString() == _hosyoTorokuYoushiCd
                //    && isSetKingaku)
                //{
                //    continue;
                //}
                #endregion

                #region to be removed
                //if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value)))
                //{
                //    // 会員単価(14)
                //    decimal kaiinTanka;
                //    Decimal.TryParse(Convert.ToString(dgvr.Cells[KaiinTankaCol.Index].Value), out kaiinTanka);

                //    // 非会員単価(16)
                //    decimal hiKaiinTanka;
                //    Decimal.TryParse(Convert.ToString(dgvr.Cells[HiKaiinTankaCol.Index].Value), out hiKaiinTanka);

                //    // 販売数(19)
                //    decimal hanbaiCnt;
                //    Decimal.TryParse(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value), out hanbaiCnt);

                //    // 販売価格(20)
                //    decimal hanbaiKakaku = _kaiinFlg == "1" ? (kaiinTanka * hanbaiCnt) : (hiKaiinTanka * hanbaiCnt);
                //    dgvr.Cells[HanbaiKakakuCol.Index].Value = hanbaiKakaku.ToString("N0");

                //    // 消費税(21)
                //    decimal syohizei = 0;
                //    if (dgvr.Cells[YoshiCdCol.Name].Value.ToString() == _hosyoTorokuYoushiCd)
                //    {
                //        // 20150106 habu 端数処理追加
                //        syohizei = Math.Floor(hanbaiKakaku * zeiritsu);
                //        //decimal syohizei = hanbaiKakaku * zeiritsu;
                //        dgvr.Cells[SyohizeiCol.Index].Value = syohizei.ToString("N0");
                //    }

                //    // 販売金額(22)
                //    dgvr.Cells[HanbaiKingakuCol.Index].Value = (hanbaiKakaku + syohizei).ToString("N0");

                //    // Total of 販売金額(22)
                //    hanbaiKingakuTotal += hanbaiKakaku + syohizei;
                //}
                //else
                //{
                //    // 販売価格(20)
                //    dgvr.Cells[HanbaiKakakuCol.Index].Value = string.Empty;
                //    // 消費税(21)
                //    dgvr.Cells[SyohizeiCol.Index].Value = string.Empty;
                //    // 販売金額(22)
                //    dgvr.Cells[HanbaiKingakuCol.Index].Value = string.Empty;
                //}
                #endregion

                // 1明細分の金額を更新
                UpdateKingaku(dgvr.Index, zeiritsu);
            }

            if (isSetKingaku)
            {
                // 合計金額(10)
                UpdateKingakuGokei();
            }

            #region to be removed
            //if (isSetKingaku)
            //{
            //    // 合計金額(10)
            //    totalKingakuTextBox.Text = (hanbaiKingakuTotal + Convert.ToDecimal(!string.IsNullOrEmpty(soryoTextBox.Text) ? soryoTextBox.Text : "0")).ToString("N0");
            //}
            #endregion

        }
        #endregion

        #region UpdateKingaku
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <param name="zeiritsu"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/06　habu　　   処理見直し
        /// </history>
        private void UpdateKingaku(int rowIdx, decimal zeiritsu)
        {
            DataGridViewRow dgvr = yoshiListDataGridView.Rows[rowIdx];

            // TODO 業者未選択の場合は処理を抜ける(会員判定ができないため)

            if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value)))
            {
                // 会員単価(14)
                decimal kaiinTanka;
                Decimal.TryParse(Convert.ToString(dgvr.Cells[KaiinTankaCol.Index].Value), out kaiinTanka);

                // 非会員単価(16)
                decimal hiKaiinTanka;
                Decimal.TryParse(Convert.ToString(dgvr.Cells[HiKaiinTankaCol.Index].Value), out hiKaiinTanka);

                // 販売数(19)
                decimal hanbaiCnt;
                Decimal.TryParse(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value), out hanbaiCnt);

                // 販売価格(20)
                decimal hanbaiKakaku = _kaiinFlg == "1" ? (kaiinTanka * hanbaiCnt) : (hiKaiinTanka * hanbaiCnt);
                dgvr.Cells[HanbaiKakakuCol.Index].Value = hanbaiKakaku.ToString("N0");

                // 消費税(21)
                decimal syohizei = 0;
                if (dgvr.Cells[YoshiCdCol.Name].Value.ToString() != _hosyoTorokuYoushiCd)
                {
                    syohizei = Math.Floor(hanbaiKakaku * zeiritsu);
                    dgvr.Cells[SyohizeiCol.Index].Value = syohizei.ToString("N0");
                }

                // 販売金額(22)
                dgvr.Cells[HanbaiKingakuCol.Index].Value = (hanbaiKakaku + syohizei).ToString("N0");
            }
            else
            {
                // 販売価格(20)
                dgvr.Cells[HanbaiKakakuCol.Index].Value = string.Empty;
                // 消費税(21)
                dgvr.Cells[SyohizeiCol.Index].Value = string.Empty;
                // 販売金額(22)
                dgvr.Cells[HanbaiKingakuCol.Index].Value = string.Empty;
            }
        }
        #endregion

        #region UpdateKingakuGokei
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/06　habu　　   処理見直し
        /// </history>
        private void UpdateKingakuGokei()
        {
            decimal hanbaiKingakuTotal = 0;

            foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiKingakuCol.Index].Value)))
                {
                    decimal hanbaiKingaku = 0;

                    if (decimal.TryParse(Convert.ToString(dgvr.Cells[HanbaiKingakuCol.Index].Value), out hanbaiKingaku))
                    {
                        hanbaiKingakuTotal += hanbaiKingaku;
                    }
                }
            }

            // 合計金額(10)
            totalKingakuTextBox.Text = (hanbaiKingakuTotal + Convert.ToDecimal(!string.IsNullOrEmpty(soryoTextBox.Text) ? soryoTextBox.Text : "0")).ToString("N0");
        }
        #endregion

        #region ProcessCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ProcessCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/01/15　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.09
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private bool ProcessCheck()
        //{
        //    if (!string.IsNullOrEmpty(_yoshiHanbaiChumonNo))
        //    {
        //        // 処理済チェック
        //        if (_hdrTable[0].IsYoshiHanbaiGenkinNyukingakuNull() || _hdrTable[0].YoshiHanbaiGenkinNyukingaku != 0
        //            || _hdrTable[0].IsYoshiHanbaiSeikyuKingakuNull() || _hdrTable[0].YoshiHanbaiSeikyuKingaku != 0
        //            || _hdrTable[0].IsYoshiHanbaiKansaiFlgNull() || _hdrTable[0].YoshiHanbaiKansaiFlg != "0"
        //            || _hdrTable[0].IsYoshiHanbaiSeikyushoHakkoFlgNull() || _hdrTable[0].YoshiHanbaiSeikyushoHakkoFlg != "0"
        //            || _hdrTable[0].IsYoshiHanbaiNohinshoHakkoFlgNull() || _hdrTable[0].YoshiHanbaiNohinshoHakkoFlg != "0"
        //            || _hdrTable[0].IsYoshiHanbaiHassoFlgNull() || _hdrTable[0].YoshiHanbaiHassoFlg != "0")
        //        {
        //            MessageForm.Show2(MessageForm.DispModeType.Error,"既に処理済のため、更新/削除できません。");
        //            return false;
        //        }
        //    }

        //    return true;
        //}
        #endregion

        #region HoshoTorokuCompleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： HoshoTorokuCompleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/01/15　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.09
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private bool HoshoTorokuCompleteCheck()
        //{
        //    foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
        //    {
        //        if (Convert.ToString(dgvr.Cells[YoshiCdCol.Index].Value) == _hosyoTorokuYoushiCd
        //            && !string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[HanbaiCntCol.Index].Value)))
        //        {
        //            DataRow[] hoshoRow = _hoshoTorokuTblDataTable.Select(
        //                        string.Format("HoshoTorokuShishoKbn = '{0}' and HoshoTorokuUriageDt = '{1}' and HoshoTorokuHanbaisakiCd = '{2}' and isnull(HoshoTorokuTorokuKakuninDt, '') <> ''",
        //                        _hdrTable[0].YoshiHanbaiShishoCd, _hdrTable[0].YoshiHanbaiDt, _hdrTable[0].YoshiHanbaisakiGyoshaCd));

        //            if (hoshoRow.Length > 0)
        //            {
        //                MessageForm.Show2(MessageForm.DispModeType.Error, "既に処理済のため、更新/削除できません。");
        //                return false;
        //            }

        //            return true;
        //        }
        //    }

        //    return true;
        //}
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // Textboxes
            gyosyaCdTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            gyosyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            chumonNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            totalKingakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            soryoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 10);
            hosyoTorokuNoFromTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 11);
            hosyoTorokuNoToTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 11);

            // Datagridview
            yoshiListDataGridView.SetStdControlDomain(YoshiCdCol.Index, ZControlDomain.ZG_STD_CD, 2);
            yoshiListDataGridView.SetStdControlDomain(YoshiNameCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            yoshiListDataGridView.SetStdControlDomain(KaiinTankaCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            yoshiListDataGridView.SetStdControlDomain(HiKaiinTankaCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            yoshiListDataGridView.SetStdControlDomain(SetBusuCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            yoshiListDataGridView.SetStdControlDomain(HanbaiCntCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            //yoshiListDataGridView.SetStdControlDomain(hanbaiCntHideCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            //yoshiListDataGridView.SetStdControlDomain(zaikoCntHideCol.Index, ZControlDomain.ZG_STD_NUM, 6);
            yoshiListDataGridView.SetStdControlDomain(HanbaiKakakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            yoshiListDataGridView.SetStdControlDomain(SyohizeiCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            yoshiListDataGridView.SetStdControlDomain(HanbaiKingakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
        }
        #endregion

        #region KinkakuSaikeisanSyori

        #region KinkakuSaikeisanSyori
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KinkakuSaikeisanSyori
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvr"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KinkakuSaikeisanSyori(DataGridViewRow dgvr = null)
        {
            if (null == dgvr)
            {
                foreach (DataGridViewRow row in yoshiListDataGridView.Rows)
                {
                    DoKinkakuSaikeisanSyori(row);
                }
            }
            else
            {
                DoKinkakuSaikeisanSyori(dgvr);
            }

            MakeTotalKingaku();
        }
        #endregion

        #region DoKinkakuSaikeisanSyori
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoKinkakuSaikeisanSyori
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoKinkakuSaikeisanSyori(DataGridViewRow dgvr)
        {
            // 販売数(18)
            decimal hanbaiCnt;
            Decimal.TryParse(Convert.ToString(dgvr.Cells[HanbaiCntCol.Name].Value), out hanbaiCnt);
            // 会員単価(15)
            decimal kaiinTanka;
            Decimal.TryParse(Convert.ToString(dgvr.Cells[KaiinTankaCol.Name].Value), out kaiinTanka);
            // 非会員単価(16)
            decimal hiKaiinTanka;
            Decimal.TryParse(Convert.ToString(dgvr.Cells[HiKaiinTankaCol.Name].Value), out hiKaiinTanka);

            // 販売数 > 0?
            if (hanbaiCnt > 0)
            {
                // 販売価格(22)
                decimal hanbaiKakaku = _kaiinFlg == "1" ? kaiinTanka * hanbaiCnt : hiKaiinTanka * hanbaiCnt;
                dgvr.Cells[HanbaiKakakuCol.Name].Value = hanbaiKakaku;

                // 消費税(23)
                decimal syohizei = 0;
                // 保証登録フラグ(隠し) = 0?
                if (dgvr.Cells[hoshoTorokuFlgHideCol.Name].Value.ToString() == "0")
                {
                    // 消費税(23)
                    syohizei = hanbaiKakaku * _shouhizeiritsu;
                    dgvr.Cells[SyohizeiCol.Name].Value = syohizei;
                }
                else // 1
                {
                    dgvr.Cells[SyohizeiCol.Name].Value = DBNull.Value;
                }

                // 販売金額(24) = (22) + (23)
                dgvr.Cells[HanbaiKingakuCol.Name].Value = hanbaiKakaku + syohizei;
            }
            else if (hanbaiCnt == 0)
            {
                // 販売価格(22)
                dgvr.Cells[HanbaiKakakuCol.Name].Value = DBNull.Value;
                // 消費税(23)
                dgvr.Cells[SyohizeiCol.Name].Value = DBNull.Value;
                // 販売金額(24)
                dgvr.Cells[HanbaiKingakuCol.Name].Value = DBNull.Value;
            }
        }
        #endregion

        #region MakeTotalKingaku
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeTotalKingaku
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeTotalKingaku()
        {
            // 送料(30)
            decimal soryo;
            Decimal.TryParse(soryoTextBox.Text, out soryo);
            // 合計金額(11)
            totalKingakuTextBox.Text = (soryo + yoshiListDataGridView.Rows.Cast<DataGridViewRow>()
                                                                          .AsEnumerable()
                                                                          .Sum(r => Convert.ToDecimal(string.IsNullOrEmpty(Convert.ToString(r.Cells[HanbaiKingakuCol.Name].Value)) ? "0" : Convert.ToString(r.Cells[HanbaiKingakuCol.Name].Value)))).ToString("N0");
        }
        #endregion

        #endregion

        #region HoshoTorokuBangoCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： HoshoTorokuBangoCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool HoshoTorokuBangoCheck(out string hoshoTorokuNoFrom, out string hoshoTorokuNoTo)
        {
            hoshoTorokuNoFrom = string.Empty;
            hoshoTorokuNoTo = string.Empty;

            // 保証登録未入力チェック
            if (_hoshoTorokuHanbaiFlg && string.IsNullOrEmpty(hosyoTorokuNoFromTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "販売する開始保証登録番号を入力してください。");
                ClearHoshoTorokuTextBox();
                return false;
            }

            // 保証登録番号桁数
            if (/*_hoshoTorokuHanbaiFlg &&*/ hosyoTorokuNoFromTextBox.Text.Length != 11)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "保証登録番号は11桁で入力して下さい。");
                ClearHoshoTorokuTextBox();
                return false;
            }

            // 保証登録不要チェック
            if (_hoshoTorokuHanbaiFlg && !string.IsNullOrEmpty(hosyoTorokuNoFromTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "保証登録用紙の販売はないので、保証登録番号は入力しないでください。");
                ClearHoshoTorokuTextBox();
                return false;
            }

            #region 保証登録番号存在チェック
            IHosyoTorokuNoFromTextBoxLeaveALInput alInput = new HosyoTorokuNoFromTextBoxLeaveALInput();
            alInput.SearchCond = new HoshoTorokuAkibanSearchCond();
            if (_dispMode == DispMode.Add)
            {
                alInput.SearchCond.AkibanMode = AkibanMode.Add;
            }
            else if (_dispMode == DispMode.Edit)
            {
                alInput.SearchCond.AkibanMode = AkibanMode.Edit;
                alInput.SearchCond.HoshoTorokuChumonNo = chumonNoTextBox.Text;
            }
            alInput.SearchCond.HoshoTorokuKensakikan = hosyoTorokuNoFromTextBox.Text.Substring(0, 4);
            alInput.SearchCond.HoshoTorokuNendo = Utility.DateUtility.ConvertFromWareki(hosyoTorokuNoFromTextBox.Text.Substring(4, 2), "yyyy");
            alInput.SearchCond.HoshoTorokuRenban = hosyoTorokuNoFromTextBox.Text.Substring(6, 5);
            IHosyoTorokuNoFromTextBoxLeaveALOutput alOutput = new HosyoTorokuNoFromTextBoxLeaveApplicationLogic().Execute(alInput);

            if (_hoshoTorokuHanbaiFlg && alOutput.HoshoTorokuKaishiNoCheckDataTable.Rows.Count == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "入力された保証登録番号は存在しません。");
                ClearHoshoTorokuTextBox();
                return false;
            }
            #endregion

            #region 保証登録番号空き番チェック
            int hanbaiCnt = 0;
            foreach (DataGridViewRow dgvr in yoshiListDataGridView.Rows)
            {
                if (dgvr.Cells[hoshoTorokuFlgHideCol.Name].Value.ToString() == "1")
                {
                    Int32.TryParse(Convert.ToString(dgvr.Cells[HanbaiCntCol.Name].Value), out hanbaiCnt);
                    break;
                }
            }

            if (_hoshoTorokuHanbaiFlg && alOutput.HoshoTorokuAkibanDataTable.Rows.Count < hanbaiCnt)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "入力された保証登録番号は存在しません。");
                ClearHoshoTorokuTextBox();
                return false;
            }
            #endregion

            // Get 保証登録番号
            if (alOutput.HoshoTorokuAkibanDataTable.Rows.Count > 0)
            {
                hoshoTorokuNoFrom = alOutput.HoshoTorokuAkibanDataTable[0].HoshoTorokuNo;
                hoshoTorokuNoTo = alOutput.HoshoTorokuAkibanDataTable[alOutput.HoshoTorokuAkibanDataTable.Rows.Count - 1].HoshoTorokuNo;
            }

            return true;
        }
        #endregion

        #region ClearHoshoTorokuTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearHoshoTorokuTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearHoshoTorokuTextBox()
        {
            hosyoTorokuNoFromTextBox.Text = string.Empty;
            hosyoTorokuNoToTextBox.Text = string.Empty;
        }
        #endregion

        #region Data check

        #region InputCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InputCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool InputCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            if (_dispMode == DispMode.Add)
            {
                // 支所(2)
                if (string.IsNullOrEmpty(Convert.ToString(shishoNmComboBox.SelectedValue)))
                {
                    errMsg.AppendLine("必須項目：支所が選択されていません。");
                }

                // 業者(3)
                if (string.IsNullOrEmpty(gyosyaCdTextBox.Text))
                {
                    errMsg.AppendLine("必須項目：業者が入力されていません。");
                }
            }

            // 担当者(6)
            if (string.IsNullOrEmpty(Convert.ToString(tantoComboBox.SelectedValue)))
            {
                errMsg.AppendLine("必須項目：担当者が選択されていません。");
            }

            // 販売日(7)
            if (string.IsNullOrEmpty(hanbaiDtDateTimePicker.Value.ToString()))
            {
                errMsg.AppendLine("必須項目：販売日が入力されていません。");
            }

            // 用紙一覧(12)
            int hanbaiInputRecords = yoshiListDataGridView.Rows.Cast<DataGridViewRow>()
                                                               .AsEnumerable()
                                                               .Where(r => !string.IsNullOrEmpty(Convert.ToString(r.Cells[HanbaiCntCol.Name].Value)))
                                                               .Count();
            if (hanbaiInputRecords == 0)
            {
                errMsg.AppendLine("販売数を入力して下さい。");
            }

            // Error?
            if (errMsg.Length > 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region DeleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DeleteCheck()
        {
            return MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") == DialogResult.Yes;
        }
        #endregion

        #region SyorisumiCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SyorisumiCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool SyorisumiCheck()
        {
            if (_headerTable[0].YoshiHanbaiGenkinNyukingaku != 0
                || _headerTable[0].YoshiHanbaiSeikyuKingaku != 0
                || _headerTable[0].YoshiHanbaiKansaiFlg != "0"
                || _headerTable[0].YoshiHanbaiSeikyushoHakkoFlg != "0"
                || _headerTable[0].YoshiHanbaiNohinshoHakkoFlg != "0"
                || _headerTable[0].YoshiHanbaiHassoFlg != "0")
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "既に処理済のため、変更/削除できません。");
                return false;
            }

            return true;
        }
        #endregion

        #region SyorisumiCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SyorisumiCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool SeikyuSumiCheck()
        {
            if (Utility.KeiriUtility.ChkSeikyuSumi(Utility.KeiriUtility.SeikyuKbnConstant.YoshiHanbai, _yoshiHanbaiChumonNo) == 1)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "既に請求済のため、更新/削除できません。");
                return false;
            }

            return true;
        }
        #endregion

        #region ZaikosuCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ZaikosuCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvr"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool ZaikosuCheck(DataGridViewRow dgvr)
        {
            bool isErr = false;
            // セット部数(17)
            int setBusu;
            Int32.TryParse(Convert.ToString(dgvr.Cells[SetBusuCol.Name].Value), out setBusu);
            // 販売数(18)
            int hanbaiCnt;
            Int32.TryParse(Convert.ToString(dgvr.Cells[HanbaiCntCol.Name].Value), out hanbaiCnt);
            // 在庫数(隠し)(21)
            int zaikoCnt;
            Int32.TryParse(Convert.ToString(dgvr.Cells[zaikoCntHideCol.Name].Value), out zaikoCnt);

            // (17) != empty?
            if (!string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[SetBusuCol.Name].Value)))
            {
                if (hanbaiCnt * setBusu > zaikoCnt)
                {
                    isErr = true;
                }
            }
            else
            {
                if (hanbaiCnt > zaikoCnt)
                {
                    isErr = true;
                }
            }

            if (isErr)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("{0}の販売数が在庫数を超えています。", dgvr.Cells[YoshiNameCol.Name].Value));
                return false;
            }

            return true;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion
}
