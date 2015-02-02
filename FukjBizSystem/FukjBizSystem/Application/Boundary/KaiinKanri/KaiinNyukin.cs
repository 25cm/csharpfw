using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinNyukin;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.Keiri;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KaiinKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaiinNyukinForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaiinNyukinForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// gyoshaRow
        /// </summary>
        private GyoshaBukaiMstDataSet.KaiinListRow _gyoshaRow;

        /// <summary>
        /// nenKaihiTblDT
        /// </summary>
        private NenKaihiTblDataSet.NenKaihiTblDataTable _nenKaihiTblDT = new NenKaihiTblDataSet.NenKaihiTblDataTable();

        /// <summary>
        /// isRegisSuccess
        /// </summary>
        private bool _isRegisSuccess = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KaikeiRendoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KaiinNyukinForm()
        {
            InitializeComponent();
            //set control domain
            SetControlDomain();
            nennkaihiGakuTextBox.Leave += new EventHandler(Common.Common.NumberTextBox_Leave);
            nyukaihiGakuTextBox.Leave += new EventHandler(Common.Common.NumberTextBox_Leave);
        }

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KaikeiRendoListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KaiinNyukinForm(GyoshaBukaiMstDataSet.KaiinListRow gyoshaRow)
        {
            InitializeComponent();
            //set control domain
            SetControlDomain();
            _gyoshaRow = gyoshaRow;
            nennkaihiGakuTextBox.Leave += new EventHandler(Common.Common.NumberTextBox_Leave);
            nyukaihiGakuTextBox.Leave += new EventHandler(Common.Common.NumberTextBox_Leave);
        }
        #endregion

        #region イベント

        #region KaiinNyukinForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaiinNyukinForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaiinNyukinForm_Load(object sender, EventArgs e)
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

        #region kakuteiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidData()) return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された内容で会費入金情報を登録します。よろしいですか？") != DialogResult.Yes) return;

                NenKaihiTblDataSet.NenKaihiTblDataTable nenKaihiTblUpdateDT = new NenKaihiTblDataSet.NenKaihiTblDataTable();
                NenKaihiTblDataSet.NenKaihiTblDataTable nenKaihiTblDT = new NenKaihiTblDataSet.NenKaihiTblDataTable();

                NyukinTblDataSet.NyukinTblDataTable nyukinTblUpdateDT = new NyukinTblDataSet.NyukinTblDataTable();
                NyukinTblDataSet.NyukinTblDataTable nyukinTblDT = new NyukinTblDataSet.NyukinTblDataTable();

                //年会費入金区分=ONの場合
                if (nenkaihiCheckBox.Checked)
                {
                    nenKaihiTblDT = CreateNenKaihiTblDataTable();
                    nenKaihiTblDT[0].NenkaihiKbn = "1";
                    nenKaihiTblDT[0].KaihiGaku = Convert.ToDecimal(nennkaihiGakuTextBox.Text);
                    nenKaihiTblDT[0].NyukinGaku = genkinRadioButton.Checked ? Convert.ToDecimal(nennkaihiGakuTextBox.Text) : 0;
                    nenKaihiTblUpdateDT.Merge(nenKaihiTblDT);

                    nyukinTblDT = CreateNyukinTblDataTable(nenKaihiTblDT);
                    nyukinTblDT[0].NyukinSyubetsu = "4";
                    nyukinTblDT[0].SeikyuGaku = Convert.ToDecimal(nennkaihiGakuTextBox.Text);
                    nyukinTblDT[0].NyukinGaku = Convert.ToDecimal(nennkaihiGakuTextBox.Text);
                    nyukinTblDT[0].JitsuNyukinGaku = Convert.ToDecimal(nennkaihiGakuTextBox.Text);
                    nyukinTblDT[0].WarifuriGaku = Convert.ToDecimal(nennkaihiGakuTextBox.Text);
                    nyukinTblUpdateDT.Merge(nyukinTblDT);
                }

                //入会費入金区分=ONの場合
                if (nyukaihiCheckBox.Checked)
                {
                    nenKaihiTblDT = CreateNenKaihiTblDataTable();
                    nenKaihiTblDT[0].NenkaihiKbn = "2";
                    nenKaihiTblDT[0].KaihiGaku = Convert.ToDecimal(nyukaihiGakuTextBox.Text);
                    nenKaihiTblDT[0].NyukinGaku = genkinRadioButton.Checked ? Convert.ToDecimal(nyukaihiGakuTextBox.Text) : 0;
                    nenKaihiTblUpdateDT.Merge(nenKaihiTblDT);

                    nyukinTblDT = CreateNyukinTblDataTable(nenKaihiTblDT);
                    nyukinTblDT[0].NyukinSyubetsu = "4";
                    nyukinTblDT[0].SeikyuGaku = Convert.ToDecimal(nyukaihiGakuTextBox.Text);
                    nyukinTblDT[0].NyukinGaku = Convert.ToDecimal(nyukaihiGakuTextBox.Text);
                    nyukinTblDT[0].JitsuNyukinGaku = Convert.ToDecimal(nyukaihiGakuTextBox.Text);
                    nyukinTblDT[0].WarifuriGaku = Convert.ToDecimal(nyukaihiGakuTextBox.Text);
                    nyukinTblUpdateDT.Merge(nyukinTblDT);
                }

                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                alInput.IsCheckDuplicate = false;
                alInput.NenKaihiTblUpdateDataTable = nenKaihiTblUpdateDT;
                alInput.NyukinTblUpdateDataTable = nyukinTblUpdateDT;
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "登録処理が完了しました。");

                // 領収書出力時用に、採番済みデータを保持する
                _nenKaihiTblDT = nenKaihiTblUpdateDT;

                _isRegisSuccess = true;

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

        #region ryosyusyoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ryosyusyoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ryosyusyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20141222 habu Mod 画面上の指定年度で、年会費が登録済みの場合のみ、初期データを領主書画面に引き渡す(採番は行わない)
                // 登録済みの年会費データをチェックする
                ICheckExistsALInput input = new CheckExistsALInput();
                input.GyoshaCd = gyoshaCdTextBox.Text;
                input.Nendo = nendoTextBox.Text;
                ICheckExistsALOutput output = new CheckExistsApplicationLogic().Execute(input);

                NenKaihiTblDataSet.NenKaihiTblDataTable _nenKaihiData = output.NenKaihiTblNenkaihi;
                NenKaihiTblDataSet.NenKaihiTblDataTable _nyukaikinData = output.NenKaihiTblNyukaikin;

                if ((_nenKaihiData.Count == 0 && _nyukaikinData.Count == 0) 
                    && MessageForm.Show2(MessageForm.DispModeType.Question, "入力情報の登録処理を行われていませんが、領収書画面を表示しますか？") != DialogResult.Yes)
                {
                    return;
                }
                //if (!_isRegisSuccess && MessageForm.Show2(MessageForm.DispModeType.Question, "入力情報の登録処理を行われていませんが、領収書画面を表示しますか？") != DialogResult.Yes) return;

                #region to be removed
                // 2014/12/13 AnhNV DEL Start
                //string kaihiNo = nendoTextBox.Text + Utility.Saiban.GetSaibanRenban(nendoTextBox.Text, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_11);
                //string nyukaikinNo = nendoTextBox.Text + Utility.Saiban.GetSaibanRenban(nendoTextBox.Text, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_11);

                //RyoshushoPrintData ryoshushoPrint = new RyoshushoPrintData();
                ////ryoshushoPrint.HakkoNo = nyukaikinNo;
                //ryoshushoPrint.HakkoNo = (_nenKaihiTblDT != null && _nenKaihiTblDT.Count > 0) ? _nenKaihiTblDT[_nenKaihiTblDT.Count - 1].KaihiNo : kaihiNo;
                //ryoshushoPrint.GyoshaCd = gyoshaCdTextBox.Text;
                //ryoshushoPrint.ShushushoShubetsu = genkinRadioButton.Checked ? "1" : "2";
                // 2014/12/13 AnhNV DEL End
                #endregion

                YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable ryushushoPrintDT = new YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable();
                YoshiHanbaiDtlTblDataSet.RyushushoPrintRow ryushushoPrintRow;
                //string kaihiNo = string.Empty;

                // 20141222 habu Mod 画面上の指定年度で、年会費が登録済みの場合のみ、初期データを領主書画面に引き渡す(採番は行わない)
                // 年会費、及び入会金未登録の場合は、引数なしで領収書画面を起動
                if (_nenKaihiData.Count == 0 && _nyukaikinData.Count == 0)
                {
                    RyoshushoPrintForm frm = new RyoshushoPrintForm();
                    Program.mForm.MoveNext(frm);
                }
                // 年会費登録済みの場合は、該当の年会費情報で領収書画面を起動する
                else
                {
                    string kaihiNo = string.Empty;
                    string seikyuKbn = string.Empty;

                    // 年会費、入会金いずれかのみ登録の場合を考慮する
                    if (_nenKaihiData.Count > 0)
                    {
                        ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();

                        //(21)KaihiNo
                        ryushushoPrintRow.Hinban = _nenKaihiData[0].KaihiNo;

                        //(22)
                        ryushushoPrintRow.HinNm = "年会費";

                        //(23)
                        ryushushoPrintRow.SuiRyo = 1;

                        //(26)
                        ryushushoPrintRow.Tanka = _nenKaihiData[0].KaihiGaku;

                        //(27)
                        ryushushoPrintRow.Kingaku = _nenKaihiData[0].KaihiGaku;

                        ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                        ryushushoPrintRow.AcceptChanges();
                        ryushushoPrintRow.SetAdded();

                        kaihiNo = _nenKaihiData[0].KaihiNo;
                        seikyuKbn = _nenKaihiData[0].SeikyuKbn;
                    }

                    if (_nyukaikinData.Count > 0)
                    {
                        ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();

                        //(21)KaihiNo
                        ryushushoPrintRow.Hinban = _nyukaikinData[0].KaihiNo;

                        //(22)
                        ryushushoPrintRow.HinNm = "入会金";

                        //(23)
                        ryushushoPrintRow.SuiRyo = 1;

                        //(26)
                        ryushushoPrintRow.Tanka = _nyukaikinData[0].KaihiGaku;

                        //(27)
                        ryushushoPrintRow.Kingaku = _nyukaikinData[0].KaihiGaku;

                        ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                        ryushushoPrintRow.AcceptChanges();
                        ryushushoPrintRow.SetAdded();

                        kaihiNo = _nyukaikinData[0].KaihiNo;
                        seikyuKbn = _nyukaikinData[0].SeikyuKbn;
                    }

                    RyoshushoPrintForm.RyoshushoPrintData rpData = new RyoshushoPrintForm.RyoshushoPrintData();
                    rpData.HakkoNo = kaihiNo;
                    rpData.GyoshaCd = gyoshaCdTextBox.Text;
                    rpData.ShouhizeiKbn = RyoshushoPrintForm.ShouhizeiKbn.Nashi;
                    rpData.RyoshuShoKbn = seikyuKbn == "2" ? RyoshushoPrintForm.RyoshuShoKbn.GenkinNyukin : RyoshushoPrintForm.RyoshuShoKbn.SeikyuUriage;
                    rpData.RyushushoPrintDataTable = ryushushoPrintDT;

                    RyoshushoPrintForm frm = new RyoshushoPrintForm(rpData);
                    Program.mForm.MoveNext(frm);

                    #region to be removed
                    //// 年会費 is checked
                    //if (nenkaihiCheckBox.Checked)
                    //{
                    //    // Update 1 record
                    //    if (_nenKaihiTblDT.Count > 0)
                    //    {
                    //        // First update record
                    //        kaihiNo = _nenKaihiTblDT[0].KaihiNo;
                    //    }
                    //    else // Not update
                    //    {
                    //        kaihiNo = nendoTextBox.Text + Utility.Saiban.GetSaibanRenban(nendoTextBox.Text, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_11);
                    //    }

                    //    ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();
                    //    //(21)KaihiNo
                    //    ryushushoPrintRow.Hinban = kaihiNo;

                    //    //(22)
                    //    ryushushoPrintRow.HinNm = "年会費";

                    //    //(23)
                    //    ryushushoPrintRow.SuiRyo = 1;

                    //    //(26)
                    //    ryushushoPrintRow.Tanka = Convert.ToDecimal(nennkaihiGakuTextBox.Text);

                    //    //(27)
                    //    ryushushoPrintRow.Kingaku = Convert.ToDecimal(nennkaihiGakuTextBox.Text);

                    //    ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                    //    ryushushoPrintRow.AcceptChanges();
                    //    ryushushoPrintRow.SetAdded();
                    //}

                    //// 入会金 is checked
                    //if (nyukaihiCheckBox.Checked)
                    //{
                    //    // Update
                    //    if (_nenKaihiTblDT.Count > 0)
                    //    {
                    //        // Last update record
                    //        kaihiNo = _nenKaihiTblDT[_nenKaihiTblDT.Count - 1].KaihiNo;
                    //    }
                    //    else // Not update
                    //    {
                    //        // TODO
                    //        kaihiNo = nendoTextBox.Text + Utility.Saiban.GetSaibanRenban(nendoTextBox.Text, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_11);
                    //    }

                    //    ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();
                    //    //(21)KaihiNo
                    //    ryushushoPrintRow.Hinban = kaihiNo;

                    //    //(22)
                    //    ryushushoPrintRow.HinNm = "入会金";

                    //    //(23)
                    //    ryushushoPrintRow.SuiRyo = 1;

                    //    //(26)
                    //    ryushushoPrintRow.Tanka = Convert.ToDecimal(nyukaihiGakuTextBox.Text);

                    //    //(27)
                    //    ryushushoPrintRow.Kingaku = Convert.ToDecimal(nyukaihiGakuTextBox.Text);

                    //    ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                    //    ryushushoPrintRow.AcceptChanges();
                    //    ryushushoPrintRow.SetAdded();
                    //}

                    //// 2014/12/13 AnhNV DEL Start
                    ////int rowCount = ryushushoPrintDT.Count;

                    //////add new row blank
                    ////for (int i = 0; i < 5 - rowCount; i++)
                    ////{
                    ////    ryushushoPrintRow = ryushushoPrintDT.NewRyushushoPrintRow();
                    ////    ryushushoPrintDT.AddRyushushoPrintRow(ryushushoPrintRow);
                    ////}

                    ////ryoshushoPrint.RyushushoPrintDT = ryushushoPrintDT;
                    //// 2014/12/13 AnhNV DEL End

                    //// 2014/12/13 AnhNV ADD Start
                    //// Move to 006-022
                    //RyoshushoPrintForm.RyoshushoPrintData rpData = new RyoshushoPrintForm.RyoshushoPrintData();
                    //rpData.HakkoNo = kaihiNo;
                    //rpData.GyoshaCd = gyoshaCdTextBox.Text;
                    //rpData.ShouhizeiKbn = RyoshushoPrintForm.ShouhizeiKbn.Nashi;
                    //rpData.RyoshuShoKbn = genkinRadioButton.Checked ? RyoshushoPrintForm.RyoshuShoKbn.GenkinNyukin : RyoshushoPrintForm.RyoshuShoKbn.SeikyuUriage;
                    //rpData.RyushushoPrintDataTable = ryushushoPrintDT;
                    //RyoshushoPrintForm frm = new RyoshushoPrintForm(rpData);
                    //Program.mForm.MoveNext(frm);
                    //_nenKaihiTblDT = new NenKaihiTblDataSet.NenKaihiTblDataTable();
                    //// 2014/12/13 AnhNV ADD End
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
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_isRegisSuccess && MessageForm.Show2(MessageForm.DispModeType.Question, "登録処理が行われていない場合、入力した内容は全て破棄されます。\n入金入力を終了しますか？") != DialogResult.Yes) return;

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

        #region KaiinNyukinForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaiinNyukinForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaiinNyukinForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        kakuteiButton.PerformClick();

                        break;
                    case Keys.F6:
                        ryosyusyoButton.PerformClick();
                        break;

                    case Keys.F12:
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
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            ConstMstDataSet.ConstMstDataTable constDT = (ConstMstDataSet.ConstMstDataTable)Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_002);
            
            gyoshaCdTextBox.ReadOnly = true;
            gyoshaCdTextBox.Text = _gyoshaRow.GyoshaCd;
            gyoshaNmTextBox.ReadOnly = true;
            gyoshaNmTextBox.Text = _gyoshaRow.GyoshaNm;

            seizoDtTextBox.ReadOnly = true;
            seizoDtTextBox.Text = _gyoshaRow.BukaiNyukaiDt1;
            kojiDtTextBox.ReadOnly = true;
            kojiDtTextBox.Text = _gyoshaRow.BukaiNyukaiDt2;
            hosyuDtTextBox.ReadOnly = true;
            hosyuDtTextBox.Text = _gyoshaRow.BukaiNyukaiDt3;
            seisoDtTextBox.ReadOnly = true;
            seisoDtTextBox.Text = _gyoshaRow.BukaiNyukaiDt4;

            //nendoTextBox.Text = _currentDateTime.Year.ToString();
            nendoTextBox.Text = Utility.DateUtility.GetNendo(_currentDateTime).ToString();
            nenkaihiCheckBox.Checked = true;
            nennkaihiGakuTextBox.Text = string.Format("{0:N0}", Decimal.Parse(Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_008, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002)));

            nyukaihiCheckBox.Checked = false;
            nyukaihiGakuTextBox.Text = string.Format("{0:N0}", Decimal.Parse(Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_008, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_003)));
            genkinRadioButton.Checked = true;
            //set source to nyukinHohoComboBox
            Utility.Utility.SetComboBoxList(nyukinHohoComboBox, constDT, "ConstValue", "ConstRenban", true);
            uriageDtTextBox.Value = _currentDateTime;

        }
        #endregion

        #region IsValidData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            //登録年度
            if (string.IsNullOrEmpty(nendoTextBox.Text))
            {
                errMsg.AppendLine("登録年度が入力されていません。");
            }

            //入金方法
            if (nyukinHohoComboBox.SelectedIndex <= 0)
            {
                errMsg.AppendLine("入金方法が選択されていません。");
            }

            //入金区分
            if (!nenkaihiCheckBox.Checked && !nyukaihiCheckBox.Checked)
            {
                errMsg.AppendLine("入金区分を選択してください");
            }

            //年会費入金
            if (nenkaihiCheckBox.Checked && string.IsNullOrEmpty(nennkaihiGakuTextBox.Text))
            {
                errMsg.AppendLine("年会費入金額を入力してください。");
            }

            //入会費入金
            if (nyukaihiCheckBox.Checked && string.IsNullOrEmpty(nyukaihiGakuTextBox.Text))
            {
                errMsg.AppendLine("入会費入金額を入力してください。");
            }

            //重複チェック
            IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
            alInput.IsCheckDuplicate = true;
            IKakuteiBtnClickALOutput alOutput = new KakuteiBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.NenKaihiTblInfoDataTable.Select(string.Format("Nendo = '{0}' AND KaihiGyosyaCd = '{1}'", nendoTextBox.Text, gyoshaCdTextBox.Text)).Length > 0)
            {
                errMsg.AppendLine("同一年度ですでに入金処理されています。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region CreateNenKaihiTblDataTable
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNenKaihiTblDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NenKaihiTblDataSet.NenKaihiTblDataTable CreateNenKaihiTblDataTable()
        {
            NenKaihiTblDataSet.NenKaihiTblDataTable nenKaihiTblDT = new NenKaihiTblDataSet.NenKaihiTblDataTable();
            NenKaihiTblDataSet.NenKaihiTblRow newRow = nenKaihiTblDT.NewNenKaihiTblRow();

            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string loginTarm = Dns.GetHostName();

            //会費No
            newRow.KaihiNo = nendoTextBox.Text + Utility.Saiban.GetSaibanRenban(nendoTextBox.Text, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_11);

            //年度
            newRow.Nendo = nendoTextBox.Text;

            //支所コード
            newRow.KaihiShisyoCd = "0";

            //年会費区分
            //newRow.NenkaihiKbn = "1";

            //業者コード
            newRow.KaihiGyosyaCd = gyoshaCdTextBox.Text;

            //請求区分
            newRow.SeikyuKbn = genkinRadioButton.Checked ? "2" : "1";

            //計上日
            newRow.KeijoDt = uriageDtTextBox.Value.ToString("yyyyMMdd");

            //会費
            newRow.KaihiGaku = Convert.ToDecimal(nennkaihiGakuTextBox.Text);

            //入金方法
            newRow.NyukinHoho = nyukinHohoComboBox.SelectedValue.ToString();

            //登録日
            newRow.InsertDt = currentDateTime;

            //登録者
            newRow.InsertUser = loginUser;

            //登録端末
            newRow.InsertTarm = loginTarm;

            //更新日
            newRow.UpdateDt = currentDateTime;

            //更新者
            newRow.UpdateUser = loginUser;

            //更新端末
            newRow.UpdateTarm = loginTarm;

            nenKaihiTblDT.AddNenKaihiTblRow(newRow);
            newRow.AcceptChanges();
            newRow.SetAdded();
            
            return nenKaihiTblDT;
        }
        #endregion

        #region CreateNyukinTblDataTable
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/01　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NyukinTblDataSet.NyukinTblDataTable CreateNyukinTblDataTable(NenKaihiTblDataSet.NenKaihiTblDataTable nenKaihiTblDT)
        {
            NyukinTblDataSet.NyukinTblDataTable nyukinTblDT = new NyukinTblDataSet.NyukinTblDataTable();
            NyukinTblDataSet.NyukinTblRow newRow = nyukinTblDT.NewNyukinTblRow();

            DateTime currentDateTime = Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string loginTarm = Dns.GetHostName();

            //入金No
            newRow.NyukinNo = currentDateTime.ToString("yyyy") + Utility.Saiban.GetSaibanRenban(currentDateTime.ToString("yyyy"), Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_07);

            //支所コード
            newRow.NyukinShisyoCd = "0";

            //入金日
            newRow.NyukinDt = uriageDtTextBox.Value.ToString("yyyyMMdd");

            //入金取扱日
            newRow.NyukinToriatukaiDt = uriageDtTextBox.Value.ToString("yyyyMMdd");

            //入金種別
            //newRow.NyukinSyubetsu = "4";

            //連携No
            newRow.NyukinRenkeiNo = nenKaihiTblDT[0].KaihiNo;

            //計量証明検査依頼年度
            newRow.KeiryoShomeiIraiNendo = string.Empty;

            //計量証明支所コード
            newRow.KeiryoShomeiIraiSishoCd = string.Empty;

            //計量証明依頼連番
            newRow.KeiryoShomeiIraiRenban = string.Empty;

            //検査依頼法定区分
            newRow.KensaIraiHoteiKbn = string.Empty;

            //検査依頼保健所コード
            newRow.KensaIraiHokenjoCd = string.Empty;

            //検査依頼年度
            newRow.KensaIraiNendo = string.Empty;

            //検査依頼連番
            newRow.KensaIraiRenban = string.Empty;

            //入金方法
            newRow.NyukinHoho = nyukinHohoComboBox.SelectedValue.ToString();

            //入金口座
            newRow.NyukinKoza = string.Empty;
            //手数料
            newRow.TesuryoGaku = 0;

            //手数料内外区分
            newRow.TesuryoNaigaiKbn = "0";

            //入金元区分
            newRow.NyukinmotoKbn = "1";

            //業者コード
            newRow.NyukinGyosyaCd = gyoshaCdTextBox.Text;

            //浄化槽保健所コード
            newRow.JokasoHokenjoCd = string.Empty;

            //浄化槽台帳登録年度
            newRow.JokasoTorokuNendo = string.Empty;

            //浄化槽台帳連番
            newRow.JokasoRenban = string.Empty;

            //入金者名称
            newRow.NyukinsyaNm = gyoshaNmTextBox.Text;

            //割振り済フラグ
            newRow.WarifuriFlg = "1";

            //返金額合計
            newRow.HenkinGaku = 0;

            //完済フラグ
            newRow.KansaiFlag = "0";

            //次回繰り越し金
            newRow.JikaiKurikoshiKin = 0;

            //繰り越し金
            newRow.KurikoshiKin = 0;

            //登録日
            newRow.InsertDt = currentDateTime;

            //登録者
            newRow.InsertUser = loginUser;

            //登録端末
            newRow.InsertTarm = loginTarm;

            //更新日
            newRow.UpdateDt = currentDateTime;

            //更新者
            newRow.UpdateUser = loginUser;

            //更新端末
            newRow.UpdateTarm = loginTarm;

            nyukinTblDT.AddNyukinTblRow(newRow);
            newRow.AcceptChanges();
            newRow.SetAdded();

            return nyukinTblDT;
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            gyoshaCdTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            gyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            seizoDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            kojiDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            hosyuDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            seisoDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            nendoTextBox.SetControlDomain(ZControlDomain.ZT_NENDO);
            nennkaihiGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            nyukaihiGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
        }
        #endregion

        #endregion
    }

    #endregion
}
