using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.GenkinNyukin;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.Keiri;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using DateUtility = FukjBizSystem.Application.Utility.DateUtility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{

    #region クラス定義

    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenkinNyukinForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GenkinNyukinForm : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Nyukin, // 入金済モード
            Seikyu, // 請求済モード
            Update, // 編集モード
        }

        #endregion

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        private readonly string _keiryoShomeiIraiNendo;

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        private readonly string _keiryoShomeiIraiRenban;

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        private readonly string _keiryoShomeiIraiSishoCd;

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        private readonly string _kensaIraiHokenjoCd;

        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        private readonly string _kensaIraiHoteiKbn;

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        private readonly string _kensaIraiNendo;

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        private readonly string _kensaIraiRenban;

        /// <summary>
        /// KensaKbn
        /// </summary>
        private readonly string _kensaKbn;

        /// <summary>
        /// DateTime Sys
        /// </summary>
        private readonly DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// Update Tarm
        /// </summary>
        private readonly string updateTarm = Dns.GetHostName();

        /// <summary>
        /// Update User
        /// </summary>
        private readonly string updateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// DispMode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// GenkinNyukinTblDataTable
        /// </summary>
        private NyukinTblDataSet.GenkinNyukinTblDataTable _genkinNyukinTblDataTable =
            new NyukinTblDataSet.GenkinNyukinTblDataTable();

        /// <summary>
        /// _isError - for check is error or not
        /// </summary>
        private bool _isError;

        /// <summary>
        /// 計量証明依頼テーブル
        /// </summary>
        private KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable _keiryoShomeiIraiTblDataTable =
            new KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable();

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        private KensaIraiTblDataSet.KensaIraiTblDataTable _kensaIraiTblDataTable =
            new KensaIraiTblDataSet.KensaIraiTblDataTable();

        /// <summary>
        /// 入金テーブル 
        /// </summary>
        private NyukinTblDataSet.NyukinTblDataTable _nyukinTblDataTable = new NyukinTblDataSet.NyukinTblDataTable();

        ///// <summary>
        ///// 更新日- for checking optimistic lock
        ///// </summary>
        //private DateTime _updateDate;

        #endregion

        #region コンストラクタ

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GenkinNyukinForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GenkinNyukinForm()
        {
            InitializeComponent();
        }

        #endregion

        #region コンストラクタ

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GenkinNyukinForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kensaKbn">検査区分</param>
        /// <param name="kensaIraiHoteiKbn">検査依頼法定区分</param>
        /// <param name="kensaIraiHokenjoCd">検査依頼保健所コード</param>
        /// <param name="kensaIraiNendo">検査依頼年度</param>
        /// <param name="kensaIraiRenban">検査依頼連番</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GenkinNyukinForm(string kensaKbn, string kensaIraiHoteiKbn,
                                string kensaIraiHokenjoCd, string kensaIraiNendo,
                                string kensaIraiRenban)
        {
            _kensaKbn = kensaKbn;
            _kensaIraiHoteiKbn = kensaIraiHoteiKbn;
            _kensaIraiHokenjoCd = kensaIraiHokenjoCd;
            _kensaIraiNendo = kensaIraiNendo;
            _kensaIraiRenban = kensaIraiRenban;
            InitializeComponent();
        }

        #endregion

        #region コンストラクタ

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GenkinNyukinForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kensaKbn">検査区分</param>
        /// <param name="keiryoShomeiIraiNendo">計量証明依頼年度</param>
        /// <param name="keiryoShomeiIraiSishoCd">計量証明支所コード</param>
        /// <param name="keiryoShomeiIraiRenban">計量証明依頼連番</param>        
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GenkinNyukinForm(string kensaKbn, string keiryoShomeiIraiNendo,
                                string keiryoShomeiIraiSishoCd,
                                string keiryoShomeiIraiRenban)
        {
            _kensaKbn = kensaKbn;
            _keiryoShomeiIraiNendo = keiryoShomeiIraiNendo;
            _keiryoShomeiIraiSishoCd = keiryoShomeiIraiSishoCd;
            _keiryoShomeiIraiRenban = keiryoShomeiIraiRenban;

            InitializeComponent();
        }

        #endregion

        #region イベント

        #region GenkinNyukinForm_Load

        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GenkinNyukinForm_Load
        /// <summary>
        /// Load data to form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GenkinNyukinForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodBase.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SetControlDomain();
                // Parameters check 1
                if (!CheckParameters())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "パラメータが渡されていません。画面を終了します。");
                    return;
                }

                IFormLoadALInput alInput = new FormLoadALInput();
                SetInputValue(alInput);
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
                _genkinNyukinTblDataTable = alOutput.GenkinNyukinTblDataTable;
                _kensaIraiTblDataTable = alOutput.KensaIraiTblDataTable;
                _keiryoShomeiIraiTblDataTable = alOutput.KeiryoShomeiIraiTblDataTable;

                // Parameters check 2
                if (!CheckDataTableValue())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "データが存在しません。画面を終了します。");
                    _isError = true;
                    return;
                }
                // Display data to form
                SetDataToForm();
                // Setting screen mode
                SetControlModeView();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 画面を終了（前画面に戻る）
                DialogResult = DialogResult.Abort;
                Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodBase.GetCurrentMethod());
            }
        }

        #endregion

        #region ryosyusyoButton_Click

        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyusyoButton_Click
        /// <summary>
        /// 領収書ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// 2014/12/22  habu　    surpress Duplicate Saiban
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyusyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodBase.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int nendo = DateUtility.GetNendo(Common.Common.GetCurrentTimestamp());

                // ここでは採番は行わない
                // 20141222 habu Mod 
                //string nyukinNo = Saiban.GetSaibanRenban(nendo.ToString(), "07");

                // 登録済み入金テーブルを取得し、存在すれば、その内容で領収書画面を呼び出す
                ICheckExistsALInput input = new CheckExistsALInput();
                // パラメータ設定
                if (_kensaKbn.Equals("1"))
                {
                    input.KensaKbn = _kensaKbn;
                    input.KensaHoteiKbn = _kensaIraiHoteiKbn;
                    input.KensaHokenjoCd = _kensaIraiHokenjoCd;
                    input.KensaNendo = _kensaIraiNendo;
                    input.KensaRenban = _kensaIraiRenban;
                }
                else
                {
                    input.KensaKbn = _kensaKbn;
                    input.KeiryoNendo = _keiryoShomeiIraiNendo;
                    input.KeiryoShishoCd = _keiryoShomeiIraiSishoCd;
                    input.KeiryoRenban = _keiryoShomeiIraiRenban;
                }

                ICheckExistsALOutput output = new CheckExistsApplicationLogic().Execute(input);
                NyukinTblDataSet.NyukinTblDataTable nyukinTbl = output.NyukinTbl;

                if (nyukinTbl.Count == 0)
                {
                    // 入金済みでなければ、確認メッセージを表示する
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "入金登録されていませんが、領収書画面へ遷移しますか？") != DialogResult.Yes)
                    {
                        return;
                    }

                    // 引数なしで領収書画面へ遷移する
                    RyoshushoPrintForm frm = new RyoshushoPrintForm();
                    Program.mForm.MoveNext(frm);
                }
                else
                {

                    var ryoshushoPrint = new RyoshushoPrintForm.RyoshushoPrintData();
                    // 発行No (4)
                    ryoshushoPrint.HakkoNo = nyukinTbl[0].NyukinNo;

                    // 業者コード (6)
                    ryoshushoPrint.GyoshaCd = nyukinTbl[0].NyukinGyosyaCd;

                    #region to be removed
                    // 発行No (4)
                    //ryoshushoPrint.HakkoNo = nyukinNo;
                    // 業者コード (6)
                    //ryoshushoPrint.GyoshaCd = gyoshaCdTextBox.Text;
                    // 2014/12/13 AnhNV DEL Start
                    //// 消費税区分 (13/14/15)
                    //ryoshushoPrint.ShouhizeiKbn = "2";
                    ////領収書種別 (17/18/19)
                    //ryoshushoPrint.ShushushoShubetsu = "1";
                    // 2014/12/13 AnhNV DEL End
                    #endregion

                    // 2014/12/13 AnhNV ADD Start
                    // 消費税区分 (13/14/15)
                    ryoshushoPrint.RyoshuShoKbn = RyoshushoPrintForm.RyoshuShoKbn.GenkinNyukin; // 17 ON
                    // 2014/12/13 AnhNV ADD End

                    var ryushushoPrintDT = new YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable();
                    YoshiHanbaiDtlTblDataSet.RyushushoPrintRow ryushushoPrintRow;

                    // 検査区分 = 1
                    if (_kensaKbn.Equals("1"))
                    {
                        // 2014/12/13 AnhNV ADD Start
                        // 消費税区分 (13/14/15)
                        ryoshushoPrint.ShouhizeiKbn = RyoshushoPrintForm.ShouhizeiKbn.Nashi;
                        // 2014/12/13 AnhNV ADD End

                        ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();
                        // 品番 (21)
                        ryushushoPrintRow.Hinban = String.Empty;
                        // 品名 (22)
                        ryushushoPrintRow.HinNm = "検査手数料";
                        // 数量 (23)
                        ryushushoPrintRow.SuiRyo = 1;
                        // 消費税有無 (25) - Watting question
                        ryushushoPrintRow.ShouhizeiUmu = "0";
                        // 単価 (26)
                        ryushushoPrintRow.Tanka = nyukinTbl[0].JitsuNyukinGaku;
                        // 金額 (27)
                        ryushushoPrintRow.Kingaku = nyukinTbl[0].JitsuNyukinGaku;
                        //// 単価 (26)
                        //ryushushoPrintRow.Tanka = !String.IsNullOrEmpty(nyukinTextBox.Text)
                        //                              ? Decimal.Parse(nyukinTextBox.Text)
                        //                              : 0;
                        //// 金額 (27)
                        //ryushushoPrintRow.Kingaku = !String.IsNullOrEmpty(nyukinTextBox.Text)
                        //                                ? Decimal.Parse(nyukinTextBox.Text)
                        //                                : 0;

                        ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                        ryushushoPrintRow.AcceptChanges();
                        ryushushoPrintRow.SetAdded();
                    }
                    // 検査区分 = 2
                    else
                    {
                        // 2014/12/13 AnhNV ADD Start
                        // 消費税区分 (13/14/15)
                        ryoshushoPrint.ShouhizeiKbn = RyoshushoPrintForm.ShouhizeiKbn.Uchizei;
                        // 2014/12/13 AnhNV ADD End

                        ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();
                        // 品番 (21)
                        ryushushoPrintRow.Hinban = String.Empty;
                        // 品名 (22)
                        ryushushoPrintRow.HinNm = "計量証明";
                        // 数量 (23)
                        ryushushoPrintRow.SuiRyo = 1;
                        // 消費税有無 (25) - Watting question
                        ryushushoPrintRow.ShouhizeiUmu = "1";
                        // 単価 (26)
                        ryushushoPrintRow.Tanka = nyukinTbl[0].JitsuNyukinGaku;
                        // 金額 (27)
                        ryushushoPrintRow.Kingaku = nyukinTbl[0].JitsuNyukinGaku;
                        //// 単価 (26)
                        //ryushushoPrintRow.Tanka = !String.IsNullOrEmpty(nyukinTextBox.Text)
                        //                              ? Decimal.Parse(nyukinTextBox.Text)
                        //                              : 0;
                        //// 金額 (27)
                        //ryushushoPrintRow.Kingaku = !String.IsNullOrEmpty(nyukinTextBox.Text)
                        //                                ? Decimal.Parse(nyukinTextBox.Text)
                        //                                : 0;

                        ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                        ryushushoPrintRow.AcceptChanges();
                        ryushushoPrintRow.SetAdded();
                    }

                    #region to be removed
                    // 2014/12/13 AnhNV DEL Start
                    //int rowCount = ryushushoPrintDT.Count;

                    ////add new row blank
                    //for (int i = 0; i < 5 - rowCount; i++)
                    //{
                    //    ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();
                    //    ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                    //}
                    // 2014/12/13 AnhNV DEL End
                    #endregion

                    ryoshushoPrint.RyushushoPrintDataTable = ryushushoPrintDT;

                    var frm = new RyoshushoPrintForm(ryoshushoPrint);
                    Program.mForm.MoveNext(frm);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodBase.GetCurrentMethod());
            }
        }

        #endregion

        #region kakuteiButton_Click

        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodBase.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // 2014/12/18 ThanhVX DEL START : Move NyukinCheck, SeikyuCheck to AL
                //int nyukin = NyukinCheck();
                //int seiyku = SeikyuCheck();

                //if (nyukin == 1)
                //{
                //    MessageForm.Show2(MessageForm.DispModeType.Error, "すでに入金済です。");
                //    return;
                //}
                //else if (seiyku == 1)
                //{
                //    MessageForm.Show2(MessageForm.DispModeType.Error, "すでにすでに請求処理されているため、登録できません。");
                //    return;
                //}
                // 2014/12/18 ThanhVX DEL END
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されている検査料の現金入金処理を行います。よろしいですか？") !=
                    DialogResult.Yes) return;
                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                alInput.KensaKbn = _kensaKbn;
                // Set Value to insert Table
                SetInsertValue(ref _nyukinTblDataTable);
                // Set Value to update Table
                if (_kensaKbn.Equals("1"))
                {
                    SetUpdateKensaIraiTblValue(ref _kensaIraiTblDataTable);
                    alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                    alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                    alInput.KensaIraiNendo = _kensaIraiNendo;
                    alInput.KensaIraiRenban = _kensaIraiRenban;
                }
                else
                {
                    SetUpdateKeiryoShomeiIraiTblValue(ref _keiryoShomeiIraiTblDataTable);
                    alInput.KeiryoShomeiIraiNendo = _keiryoShomeiIraiNendo;
                    alInput.KeiryoShomeiIraiRenban = _keiryoShomeiIraiRenban;
                    alInput.KeiryoShomeiIraiSishoCd = _keiryoShomeiIraiSishoCd;
                }

                //alInput.UpdateDt = _updateDate;
                alInput.NyukinTblDataTable = _nyukinTblDataTable;
                alInput.KensaIraiTblDataTable = _kensaIraiTblDataTable;
                alInput.KeiryoShomeiIraiTblDataTable = _keiryoShomeiIraiTblDataTable;
                String errMsg = new KakuteiBtnClickApplicationLogic().Execute(alInput).ErrorMsg;
                if (!String.IsNullOrEmpty(errMsg))
                    MessageForm.Show2(MessageForm.DispModeType.Error, errMsg);
                else
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "現金入金処理が完了しました。");
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), cex.ToString());
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
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodBase.GetCurrentMethod());
            }
        }

        #endregion

        #region closeButton_Click

        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodBase.GetCurrentMethod());

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Program.mForm.MovePrev();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodBase.GetCurrentMethod());
            }
        }

        #endregion

        #region GenkinNyukinForm_Shown

        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GenkinNyukinForm_Shown
        /// <summary>
        /// Move to previous form if have any error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GenkinNyukinForm_Shown(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodBase.GetCurrentMethod());

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_isError)
                {
                    Program.mForm.MovePrev();
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodBase.GetCurrentMethod());
            }
        }

        #endregion

        #region GenkinNyukinForm_KeyDown

        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GenkinNyukinForm_KeyDown
        /// <summary>
        /// Handler key input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GenkinNyukinForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodBase.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (e.KeyData)
                {
                    case Keys.F1:
                        kakuteiButton.Focus();
                        kakuteiButton.PerformClick();
                        break;
                    case Keys.F6:
                        ryosyusyoButton.Focus();
                        ryosyusyoButton.PerformClick();
                        break;
                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodBase.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodBase.GetCurrentMethod());
                Cursor.Current = preCursor;
            }
        }

        #endregion

        #endregion

        #region メソッド(private)

        #region SetInputValue

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetInputValue
        /// <summary>
        /// Set input value
        /// </summary>
        /// <param name="input">FormLoadALInput</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetInputValue(IFormLoadALInput input)
        {
            if (_kensaKbn.Equals("1"))
            {
                input.KensaKbn = _kensaKbn;
                input.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                input.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                input.KensaIraiNendo = _kensaIraiNendo;
                input.KensaIraiRenban = _kensaIraiRenban;
            }
            else
            {
                input.KensaKbn = _kensaKbn;
                input.KeiryoShomeiIraiNendo = _keiryoShomeiIraiNendo;
                input.KeiryoShomeiIraiSishoCd = _keiryoShomeiIraiSishoCd;
                input.KeiryoShomeiIraiRenban = _keiryoShomeiIraiRenban;
            }
        }

        #endregion

        #region SetDataToForm

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetDataToForm
        /// <summary>
        /// Set data to form
        /// </summary>        
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDataToForm()
        {
            if (_genkinNyukinTblDataTable.Count > 0)
            {
                if (_kensaKbn.Equals("1"))
                {
                    // 検査種別 (1)
                    kensaSyubetsuTextBox.Text = !_genkinNyukinTblDataTable[0].IsNull("ConstNm")
                                                    ? _genkinNyukinTblDataTable[0].ConstNm
                                                    : String.Empty;
                    // 業者コード (2)
                    //2014/12/17 ThanhVX MOD START
                    if (Int32.Parse(_kensaIraiHoteiKbn) <= 2)
                        gyoshaCdTextBox.Text = !_genkinNyukinTblDataTable[0].IsNull("KensaIraiIkkatsuSeikyusakiCd")
                                                   ? _genkinNyukinTblDataTable[0].KensaIraiIkkatsuSeikyusakiCd
                                                   : String.Empty;
                    if (Int32.Parse(_kensaIraiHoteiKbn) == 3)
                        gyoshaCdTextBox.Text = !_genkinNyukinTblDataTable[0].IsNull("KensaIraiSeikyuGyoshaCd")
                                                   ? _genkinNyukinTblDataTable[0].KensaIraiSeikyuGyoshaCd
                                                   : String.Empty;
                    //2014/12/17 ThanhVX MOD END
                    // 業者名称 (3)
                    //2014/12/17 ThanhVX MOD START
                    Common.Common.SetGyoshaNmByCd(gyoshaCdTextBox.Text, gyoshaCdTextBox, gyoshaNmTextBox);
                    //2014/12/17 ThanhVX MOD END
                    // 設置者名 (4)
                    settishaNmTextBox.Text = !_genkinNyukinTblDataTable[0].IsKensaIraiSetchishaNmNull()
                                                 ? _genkinNyukinTblDataTable[0].KensaIraiSetchishaNm
                                                 : String.Empty;
                    // 設置場所 (5)
                    settiBashoTextBox.Text = !_genkinNyukinTblDataTable[0].IsNull("KensaIraiSetchibashoAdr")
                                                 ? _genkinNyukinTblDataTable[0].KensaIraiSetchibashoAdr
                                                 : String.Empty;
                    // 受付支所 (6)
                    shishoNmTextBox.Text = !_genkinNyukinTblDataTable[0].IsNull("ShishoNm")
                                               ? _genkinNyukinTblDataTable[0].ShishoNm
                                               : String.Empty;
                    // 検査料金 (7)
                    kensaRyokinTextBox.Text = !_genkinNyukinTblDataTable[0].IsKensaIraiKensaAmtNull()
                                                  ? _genkinNyukinTblDataTable[0].KensaIraiKensaAmt.ToString("N0")
                                                  : String.Empty;
                    // 消費税 (8)
                    shohizeiTextBox.Text = "0";
                    // 入金金額 (9)
                    nyukinTextBox.Text = !_genkinNyukinTblDataTable[0].IsKensaIraiKensaAmtNull()
                                             ? _genkinNyukinTblDataTable[0].KensaIraiKensaAmt.ToString("N0")
                                             : String.Empty;
                    // 入金日 (10)
                    nyukinDtDateTimePicker.Value = today;
                    //// 更新日
                    //_updateDate = _kensaIraiTblDataTable[0].UpdateDt;
                }
                else
                {
                    // 検査種別 (1)
                    kensaSyubetsuTextBox.Text = "計量証明";
                    // 業者コード (2)
                    gyoshaCdTextBox.Text = !_genkinNyukinTblDataTable[0].IsKeiryoShomeiSeikyuGyoshaCdNull()
                                               ? _genkinNyukinTblDataTable[0].KeiryoShomeiSeikyuGyoshaCd
                                               : String.Empty;
                    // 業者名称 (3)
                    gyoshaNmTextBox.Text = !_genkinNyukinTblDataTable[0].IsNull("GyoshaNm")
                                               ? _genkinNyukinTblDataTable[0].GyoshaNm
                                               : String.Empty;
                    // 設置者名 (4)
                    settishaNmTextBox.Text = !_genkinNyukinTblDataTable[0].IsJokasoSetchishaNmNull()
                                                 ? _genkinNyukinTblDataTable[0].JokasoSetchishaNm
                                                 : String.Empty;
                    // 設置場所 (5)
                    settiBashoTextBox.Text = !_genkinNyukinTblDataTable[0].IsJokasoSetchishaAdrNull()
                                                 ? _genkinNyukinTblDataTable[0].JokasoSetchishaAdr
                                                 : String.Empty;
                    // 受付支所 (6)
                    shishoNmTextBox.Text = !_genkinNyukinTblDataTable[0].IsNull("ShishoNm")
                                               ? _genkinNyukinTblDataTable[0].ShishoNm
                                               : String.Empty;
                    // 検査料金 (7)
                    // 2014/12/17 ThanhVX MOD Start
                    decimal kensaRyokin = !_genkinNyukinTblDataTable[0].IsNull("KeiryoShomeiKensaRyokin")
                                              ? Decimal.Parse(_genkinNyukinTblDataTable[0].KeiryoShomeiKensaRyokin)
                                              : 0;
                    decimal shomeishoizei = !_genkinNyukinTblDataTable[0].IsNull("KeiryoShomeiShohizei")
                                                ? Decimal.Parse(_genkinNyukinTblDataTable[0].KeiryoShomeiShohizei)
                                                : 0;
                    kensaRyokinTextBox.Text = kensaRyokin.ToString("N0");
                    // 消費税 (8)
                    shohizeiTextBox.Text = shomeishoizei.ToString("N0");
                    // 入金金額 (9)
                    nyukinTextBox.Text = (kensaRyokin + shomeishoizei).ToString("N0");
                    // 2014/12/17 ThanhVX MOD End
                    // 入金日 (10)
                    nyukinDtDateTimePicker.Value = today;
                    //// 更新日
                    //_updateDate = _keiryoShomeiIraiTblDataTable[0].UpdateDt;
                }
            }
        }

        #endregion

        #region SeikyuCheck

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SeikyuCheck
        /// <summary>
        /// Validate Seikyu
        /// </summary>        
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private int SeikyuCheck()
        {
            int seikyu = 0;
            if (_kensaKbn.Equals("1"))
            {
                if (_genkinNyukinTblDataTable.Count > 0)
                {
                    if (!_genkinNyukinTblDataTable[0].IsNull("KensaIraiSeikyuKbn"))
                    {
                        seikyu = Int32.Parse(_genkinNyukinTblDataTable[0].KensaIraiSeikyuKbn);
                    }
                }
            }
            else
            {
                if (_genkinNyukinTblDataTable.Count > 0)
                {
                    if (!_genkinNyukinTblDataTable[0].IsNull("KeiryoShomeiSeikyuKbn"))
                    {
                        seikyu = Int32.Parse(_genkinNyukinTblDataTable[0].KeiryoShomeiSeikyuKbn);
                    }
                }
            }
            return seikyu;
        }

        #endregion

        #region NyukinCheck

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： NyukinCheck
        /// <summary>
        /// Validate Nyukin
        /// </summary>        
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　ThanhVX    新規作成
        /// 2014/12/21　小松        入金済みの判定時は、区分を正しく指定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private int NyukinCheck()
        {
            int nyukin;
            if (_kensaKbn.Equals("1"))
            {
                //nyukin = KeiriUtility.ChkNyukinSumi(_kensaIraiHoteiKbn,
                //                                    _kensaIraiHokenjoCd, _kensaIraiNendo,
                //                                    _kensaIraiRenban);
                nyukin = KeiriUtility.ChkNyukinSumi(
                    FukjBizSystem.Application.Utility.KeiriUtility.NyukinKbnConstant.KensaTesuryo,
                    _kensaIraiHoteiKbn, _kensaIraiHokenjoCd, _kensaIraiNendo, _kensaIraiRenban);
            }
            else
            {
                //nyukin = KeiriUtility.ChkNyukinSumi(_keiryoShomeiIraiNendo,
                //                                    _keiryoShomeiIraiSishoCd,
                //                                    _keiryoShomeiIraiRenban);
                nyukin = KeiriUtility.ChkNyukinSumi(
                    FukjBizSystem.Application.Utility.KeiriUtility.NyukinKbnConstant.KeiryoShomei,
                    _keiryoShomeiIraiNendo, _keiryoShomeiIraiSishoCd, _keiryoShomeiIraiRenban);
            }
            return nyukin;
        }

        #endregion

        #region SetControlModeView

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetControlModeView
        /// <summary>
        /// Set item property
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            int nyukin = NyukinCheck();
            // Set Display Mode
            if (nyukin == 1)
            {
                _dispMode = DispMode.Nyukin;
            }
            else
            {
                int seikyu = SeikyuCheck();

                _dispMode = seikyu == 1 ? DispMode.Seikyu : DispMode.Update;
            }

            switch (_dispMode)
            {
                case DispMode.Nyukin:
                    // 入金日
                    nyukinDtDateTimePicker.Enabled = false;
                    // 登録ボタン
                    kakuteiButton.Enabled = false;
                    // ステータスラベル
                    stLbl.Visible = true;
                    stLbl.Text = "入金済";
                    break;
                case DispMode.Seikyu:
                    // 入金日
                    nyukinDtDateTimePicker.Enabled = false;
                    // 登録ボタン
                    kakuteiButton.Enabled = false;
                    // ステータスラベル
                    stLbl.Visible = true;
                    stLbl.Text = "請求済";
                    break;
                case DispMode.Update:
                    // 入金日
                    nyukinDtDateTimePicker.Enabled = true;
                    // 登録ボタン
                    kakuteiButton.Enabled = true;
                    // ステータスラベル
                    stLbl.Visible = false;
                    break;
            }
        }

        #endregion

        #region CheckParameters

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： CheckParameters
        /// <summary>
        /// Check parameters is null/empty
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckParameters()
        {
            if (String.IsNullOrEmpty(_kensaKbn))
            {
                return false;
            }
            if (_kensaKbn.Equals("1"))
            {
                if (String.IsNullOrEmpty(_kensaIraiHoteiKbn) ||
                    String.IsNullOrEmpty(_kensaIraiHokenjoCd) ||
                    String.IsNullOrEmpty(_kensaIraiNendo) ||
                    String.IsNullOrEmpty(_kensaIraiRenban))
                {
                    return false;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(_keiryoShomeiIraiNendo) ||
                    String.IsNullOrEmpty(_keiryoShomeiIraiSishoCd) ||
                    String.IsNullOrEmpty(_keiryoShomeiIraiRenban))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region CheckDataTableValue

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： CheckDataTableValue
        /// <summary>
        /// Check data table is empty or not
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckDataTableValue()
        {
            if (_genkinNyukinTblDataTable.Count <= 0)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region SetInsertValue

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetInsertValue
        /// <summary>
        /// Set value to table for insert DB
        /// </summary>
        /// <param name="input">Reference NyukinTblDataTable</param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetInsertValue(ref NyukinTblDataSet.NyukinTblDataTable input)
        {
            NyukinTblDataSet.NyukinTblRow row = input.NewNyukinTblRow();
            int nendo = DateUtility.GetNendo(today);
            string nyukinNo = Saiban.GetSaibanRenban(nendo.ToString(), Constants.SaibanKbnConstant.SAIBAN_KBN_07);
            // 入金No
            row.NyukinNo = nendo.ToString() + nyukinNo;
            // 入金日
            row.NyukinDt = nyukinDtDateTimePicker.Value.ToString("yyyyMMdd");
            //入金取扱日
            row.NyukinToriatukaiDt = nyukinDtDateTimePicker.Value.ToString("yyyyMMdd");
            // 入金方法
            row.NyukinHoho = "003";
            // 請求額
            row.SeikyuGaku = !String.IsNullOrEmpty(nyukinTextBox.Text) ? Decimal.Parse(nyukinTextBox.Text) : 0;
            // 入金入力額
            row.NyukinGaku = !String.IsNullOrEmpty(nyukinTextBox.Text) ? Decimal.Parse(nyukinTextBox.Text) : 0;
            // 手数料
            row.TesuryoGaku = 0;
            // 手数料内外区分
            row.TesuryoNaigaiKbn = "0";
            // 実入金額
            row.JitsuNyukinGaku = !String.IsNullOrEmpty(nyukinTextBox.Text) ? Decimal.Parse(nyukinTextBox.Text) : 0;
            // 手数料内外区分
            row.NyukinmotoKbn = String.IsNullOrEmpty(gyoshaCdTextBox.Text) ? "2" : "1";
            // 入金者名称
            row.NyukinsyaNm = String.IsNullOrEmpty(gyoshaNmTextBox.Text) ? settishaNmTextBox.Text : gyoshaNmTextBox.Text;
            // 割振り済フラグ
            row.WarifuriFlg = "1";
            // 割振り済金額
            row.WarifuriGaku = !String.IsNullOrEmpty(nyukinTextBox.Text) ? Decimal.Parse(nyukinTextBox.Text) : 0;
            // 返金額合計
            row.HenkinGaku = 0;
            // 完済フラグ
            row.KansaiFlag = "0";
            // 次回繰り越し金
            row.JikaiKurikoshiKin = 0;
            // 繰り越し金
            row.KurikoshiKin = 0;
            // 業者コード
            row.NyukinGyosyaCd = gyoshaCdTextBox.Text;
            // 検査区分＝１
            if (_kensaKbn.Equals("1"))
            {
                // 支所コード
                row.NyukinShisyoCd = !_genkinNyukinTblDataTable[0].IsNull("KensaIraiUketsukeShishoKbn")
                                         ? _genkinNyukinTblDataTable[0].KensaIraiUketsukeShishoKbn
                                         : String.Empty;
                // 入金種別
                row.NyukinSyubetsu = "6";
                // 検査依頼法定区分
                row.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                // 検査依頼保健所コード
                row.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                // 検査依頼年度
                row.KensaIraiNendo = _kensaIraiNendo;
                // 検査依頼連番
                row.KensaIraiRenban = _kensaIraiRenban;
                // 浄化槽保健所コード
                row.JokasoHokenjoCd = !_genkinNyukinTblDataTable[0].IsNull("KensaIraiJokasoHokenjoCd")
                                          ? _genkinNyukinTblDataTable[0].KensaIraiJokasoHokenjoCd
                                          : String.Empty;
                // 浄化槽台帳登録年度
                row.JokasoTorokuNendo = !_genkinNyukinTblDataTable[0].IsNull("KensaIraiJokasoTorokuNendo")
                                            ? _genkinNyukinTblDataTable[0].KensaIraiJokasoTorokuNendo
                                            : String.Empty;
                // 浄化槽台帳連番
                row.JokasoRenban = !_genkinNyukinTblDataTable[0].IsNull("KensaIraiJokasoRenban")
                                       ? _genkinNyukinTblDataTable[0].KensaIraiJokasoRenban
                                       : String.Empty;
                // 連携No
                row.NyukinRenkeiNo = string.Empty;
                // 計量証明検査依頼年度
                row.KeiryoShomeiIraiNendo = string.Empty;
                // 計量証明支所コード
                row.KeiryoShomeiIraiSishoCd = string.Empty;
                // 計量証明依頼連番
                row.KeiryoShomeiIraiRenban = string.Empty;
                // 入金口座
                row.NyukinKoza = string.Empty;
            }
            // 検査区分＝2
            else
            {
                // 支所コード
                row.NyukinShisyoCd = !_genkinNyukinTblDataTable[0].IsKeiryoShomeiIraiSishoCdNull()
                                         ? _genkinNyukinTblDataTable[0].KeiryoShomeiIraiSishoCd
                                         : String.Empty;
                // 入金種別
                row.NyukinSyubetsu = "5";
                // 計量証明検査依頼年度
                row.KeiryoShomeiIraiNendo = _keiryoShomeiIraiNendo;
                // 計量証明支所コード
                row.KeiryoShomeiIraiSishoCd = _keiryoShomeiIraiSishoCd;
                // 計量証明依頼連番
                row.KeiryoShomeiIraiRenban = _keiryoShomeiIraiRenban;
                // 浄化槽保健所コード
                row.JokasoHokenjoCd = !_genkinNyukinTblDataTable[0].IsKeiryoShomeiJokasoDaichoHokenjoCdNull()
                                          ? _genkinNyukinTblDataTable[0].KeiryoShomeiJokasoDaichoHokenjoCd
                                          : String.Empty;
                // 浄化槽台帳登録年度
                row.JokasoTorokuNendo = !_genkinNyukinTblDataTable[0].IsKeiryoShomeiJokasoDaichoNendoNull()
                                            ? _genkinNyukinTblDataTable[0].KeiryoShomeiJokasoDaichoNendo
                                            : String.Empty;
                // 浄化槽台帳連番
                row.JokasoRenban = !_genkinNyukinTblDataTable[0].IsKeiryoShomeiJokasoDaichoRenbanNull()
                                       ? _genkinNyukinTblDataTable[0].KeiryoShomeiJokasoDaichoRenban
                                       : String.Empty;

                // 連携No
                row.NyukinRenkeiNo = string.Empty;
                // 検査依頼法定区分
                row.KensaIraiHoteiKbn = string.Empty;
                // 検査依頼保健所コード
                row.KensaIraiHokenjoCd = string.Empty;
                // 検査依頼年度
                row.KensaIraiNendo = string.Empty;
                // 検査依頼連番
                row.KensaIraiRenban = string.Empty;
                // 入金口座
                row.NyukinKoza = string.Empty;
            }

            // 登録日
            row.InsertDt = today;
            // 登録者
            row.InsertUser = updateUser;
            // 登録端末
            row.InsertTarm = updateTarm;
            // 更新日
            row.UpdateDt = today;
            // 更新者
            row.UpdateUser = updateUser;
            // 更新端末
            row.UpdateTarm = updateTarm;
            input.AddNyukinTblRow(row);
            row.AcceptChanges();
            row.SetAdded();
        }

        #endregion

        #region SetUpdateKensaIraiTblValue

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetUpdateKensaIraiTblValue
        /// <summary>
        /// Set value to table for update DB
        /// </summary>
        /// <param name="input">Reference KensaIraiTblDataTable</param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetUpdateKensaIraiTblValue(ref KensaIraiTblDataSet.KensaIraiTblDataTable input)
        {
            // 入金済金額
            input[0].KensaIraiNyukinzumiAmt = !String.IsNullOrEmpty(nyukinTextBox.Text)
                                                  ? Decimal.Parse(nyukinTextBox.Text)
                                                  : 0;
            // 最終入金年 
            input[0].KensaIraiSaishuNyukinNen = nyukinDtDateTimePicker.Value.ToString("yyyy");
            // 最終入金月 
            input[0].KensaIraiSaishuNyukinTsuki = nyukinDtDateTimePicker.Value.ToString("MM");
            // 最終入金日 
            input[0].KensaIraiSaishuNyukinBi = nyukinDtDateTimePicker.Value.ToString("dd");
            // 入金完了区分 
            input[0].KensaIraiNyukinKanryoKbn = "1";
            // 入金方法 
            input[0].KensaIraiNyukinHohoKbn = "002";
            // 現金収入区分 
            input[0].KensaIraiGenkinShunyuKbn = "1";
            // 更新者
            input[0].UpdateUser = updateUser;
            // 更新端末
            input[0].UpdateTarm = updateTarm;
        }

        #endregion

        #region SetUpdateKeiryoShomeiIraiTblValue

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetUpdateKeiryoShomeiIraiTblValue
        /// <summary>
        /// Set value to table for update DB
        /// </summary>
        /// <param name="input">Reference KeiryoShomeiIraiTblDataTable</param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　ThanhVX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetUpdateKeiryoShomeiIraiTblValue(ref KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable input)
        {
            // 計量証明現金収入フラグ 
            input[0].KeiryoShomeiGenkinShunyuFlg = "1";
            // 更新者
            input[0].UpdateUser = updateUser;
            // 更新端末
            input[0].UpdateTarm = updateTarm;
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 検査種別
            kensaSyubetsuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            //業者コード
            gyoshaCdTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            //業者名称
            gyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            //設置者名
            settishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            //設置場所
            settiBashoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            //受付支所
            shishoNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            //消費税
            shohizeiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            //入金金額
            nyukinTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            //検査料金
            kensaRyokinTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
        }

        #endregion
    }
    #endregion
}