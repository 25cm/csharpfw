using System;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyuShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  DatNT　  新規作成
    /// 2014/11/05  DatNT   v1.02
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SeikyuShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Edit,           // 編集
            Display,        // 編集不可
        }
        #endregion

        #endregion

        #region プロパティ(private)
        
        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// 親請求No
        /// </summary>
        private string _oyaseikyuNo = string.Empty;
        
        /// <summary>
        /// DisplayMode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// SeikyusyoKagamiHdrTblDataTable
        /// </summary>
        private SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable _kagamiDT;

        /// <summary>
        /// SeikyuShosaiFormLoadHdrRow
        /// </summary>
        private SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrRow _seikyuShosaiFormLoadHdrRow;

        /// <summary>
        /// SeikyuHdrTblDataTable By OyaSeikyuNo
        /// </summary>
        private SeikyuHdrTblDataSet.SeikyuHdrTblDataTable _hdrDT;

        /// <summary>
        /// Updated data (更新ボタン)
        /// </summary>
        private bool wasUpdated = false;

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// Count Kbn 9
        /// </summary>
        private int countKbn9 = 0;

        /// <summary>
        /// Add New Meisai
        /// </summary>
        private bool addNewMeisai = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SeikyuShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SeikyuShosaiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SeikyuShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="seikyuNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// 2014/11/05  DatNT     v1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //public SeikyuShosaiForm(string seikyuNo)
        public SeikyuShosaiForm(string oyaseikyuNo)
        {
            InitializeComponent();

            //_seikyuNo = seikyuNo;
            _oyaseikyuNo = oyaseikyuNo;
        }
        #endregion

        #region イベント

        #region SeikyuShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SeikyuShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeikyuShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

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

        #region meisaiAddButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： meisaiAddButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// 2014/11/06  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void meisaiAddButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SeikyuAddMeisaiForm frm = new SeikyuAddMeisaiForm(seikyuDtDateTimePicker.Value.ToString("yyyyMMdd"), seikyusakiNmTextBox.Text.Trim());
                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    // 2014/11/06 DatNT v1.03 MOD Start
                    //SeikyuDtlTblDataSet.SeikyuShosaiFormLoadRow dispRow = frm.returnDT[0];
                    
                    //seikyuListDataGridView.Rows.Add(string.Empty,
                    //                                dispRow.SeikyuShisyoCd,
                    //                                dispRow.ShishoNm,
                    //                                dispRow.SeikyuKomokuNm,
                    //                                dispRow.SeikyuSyohinNm,
                    //                                dispRow.SeikyuCnt,
                    //                                string.Empty,
                    //                                dispRow.SeikyuGaku,
                    //                                dispRow.SyohizeiGaku,
                    //                                dispRow.SeikyuKingakuKei,
                    //                                dispRow.NyukinTotal,
                    //                                dispRow.SeikyuKansaiFlg,
                    //                                dispRow.SeikyuKomokuKbn,
                    //                                dispRow.KazeiFlag);

                    SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlRow dispRow = frm.returnDT[0];

                    seikyuListDataGridView.Rows.Add(dispRow.SeikyusakiNm,       // seikyusakiCol
                                                    string.Empty,               // renbanCol
                                                    dispRow.shishoNmCol,        // 支所名
                                                    dispRow.SeikyuKomokuNm,     // seikyuKamokuCol
                                                    dispRow.SeikyuSyohinNm,     // syohinCol
                                                    dispRow.SeikyuCnt,          // suryoCol
                                                    string.Empty,               // tankaCol
                                                    dispRow.SeikyuGaku,         // kingakuCol
                                                    dispRow.SyohizeiGaku,       // syohizeiCol
                                                    dispRow.SeikyuKingakuKei,   // totalCol
                                                    dispRow.NyukinTotal,        // nyukinCol
                                                    dispRow.SeikyuKansaiFlg,    // kansaiCol
                                                    dispRow.SeikyuKomokuKbn,    // seikyuKomokuKbnCol
                                                    dispRow.KazeiFlag,          // kazeiFlgCol
                                                    loginUser,                  // torokuNmCol
                                                    today,                      // torokuDtCol
                                                    pcUpdate,                   // torokuTanmatsuCol
                                                    string.Empty,               // seikyuNoCol
                                                    Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd, // shishoCdCol
                                                    "0");                       // changedFlgCol

                    addNewMeisai = true;

                    // 2014/11/06 DatNT v1.03 MOD End
                }

                SetBGColor(false);

                seikyuTotalTextBox.Text = CalcSeikyuTotal().ToString("N0");
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

        #region meisaiDelButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： meisaiDelButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void meisaiDelButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (seikyuListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (seikyuListDataGridView.CurrentRow.Cells["seikyuKomokuKbnCol"].Value != null 
                    && seikyuListDataGridView.CurrentRow.Cells["seikyuKomokuKbnCol"].Value.ToString() != "9")
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データは追加明細ではありません。");
                    return;
                }

                seikyuListDataGridView.Rows.Remove(seikyuListDataGridView.CurrentRow);

                seikyuTotalTextBox.Text = CalcSeikyuTotal().ToString("N0");
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

        #region updateButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： updateButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void updateButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 2015.01.07 toyoda Delete Start
                //wasUpdated = false;
                // 2015.01.07 toyoda Delete End

                // HDR
                SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable seikyuShosaiHdr;

                // DTL
                SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable seikyuShosaiDtl;

                // 単項目チェック
                if (!UnitCheck()) { return; }

                #region 更新チェック

                // 更新不可チェック
                IUpdateBtnClickALInput updateCheckInput = new UpdateBtnClickALInput();
                updateCheckInput.OyaSeikyuNo = _oyaseikyuNo;                
                updateCheckInput.UpdateCheck = true;
                IUpdateBtnClickALOutput updateCheckOutput = new UpdateBtnClickApplicationLogic().Execute(updateCheckInput);

                seikyuShosaiHdr = updateCheckOutput.SeikyuShosaiFormLoadHdrDT;
                seikyuShosaiDtl = updateCheckOutput.SeikyuShosaiFormLoadDtlDT;

                if (!updateCheckOutput.UpdateCheckOutput)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "入金処理が行われているため、更新できません。");
                    return;
                }

                // 請求額＜0
                if (Convert.ToDecimal(seikyuTotalTextBox.Text) < 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "請求合計金額がマイナスになっています。");
                    return;
                }

                #endregion

                #region 更新確認チェック

                if (!seikyuShosaiHdr[0].IsSeikyusyoHakkoFlgNull() && seikyuShosaiHdr[0].SeikyusyoHakkoFlg == "1")
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "請求書がすでに発行済ですが、表示されている請求を更新しますか？")
                        != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (!seikyuShosaiHdr[0].IsSeikyusyoHakkoFlgNull() && seikyuShosaiHdr[0].SeikyusyoHakkoFlg == "0")
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されている請求を更新します。よろしいですか？")
                        != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                #endregion

                DoUpdate(UpdateType());

                // 2015.01.07 toyoda Delete Start
                //wasUpdated = true;
                // 2015.01.07 toyoda Delete End
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

        #region DeleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DeleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // HDR
                SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable seikyuShosaiHdr;

                // DTL
                SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable seikyuShosaiDtl;

                // 削除チェック
                IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                alInput.DeleteCheck = true;
                alInput.OyaSeikyuNo = _oyaseikyuNo;
                IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                seikyuShosaiHdr = alOutput.SeikyuShosaiFormLoadHdrDT;
                seikyuShosaiDtl = alOutput.SeikyuShosaiFormLoadDtlDT;

                if (!alOutput.DeleteCheckOutput)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "入金処理が行われているため、削除できません。");
                    return;
                }

                if (!seikyuShosaiHdr[0].IsSeikyusyoHakkoFlgNull() && seikyuShosaiHdr[0].SeikyusyoHakkoFlg == "1")
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "請求書がすでに発行済ですが、表示されている請求を削除しますか？")
                        != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }
                else
                {
                    if (!seikyuShosaiHdr[0].IsSeikyusyoHakkoFlgNull() && seikyuShosaiHdr[0].SeikyusyoHakkoFlg == "0")
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されている請求を削除します。よろしいですか？")
                            != System.Windows.Forms.DialogResult.Yes)
                        {
                            return;
                        }
                    }
                }

                // Delete 
                IDeleteBtnClickALInput deleteInput = new DeleteBtnClickALInput();
                deleteInput.DeleteFlg = true;
                deleteInput.OyaSeikyuNo = _oyaseikyuNo;
                IDeleteBtnClickALOutput deleteOuput = new DeleteBtnClickApplicationLogic().Execute(deleteInput);

                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();
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

        #region seikyushoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： seikyushoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void seikyushoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int changedDgv = UpdateType();

                if (_dispMode == DispMode.Edit
                    && (seikyusakiNmTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakiNm.Trim()
                    || zipNoTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakisakiZipCd.Trim()
                    || adrTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakiAdr.Trim()
                    || telNoTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SekyusakiTel.Trim()
                    || seikyuDtDateTimePicker.Value.ToString("yyyyMMdd") != _seikyuShosaiFormLoadHdrRow.SeikyuDt
                    || changedDgv == 1)
                    && !wasUpdated)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "請求書出力前に更新処理を実施してください。");
                    return;
                }

                // プリンター取得エラー
                // 2014.12.16 toyoda Mod Start プリンタ設定をDB保持に変更
                //string printer = Common.Common.GetPrinterName(Utility.Constants.PrinterConstant.PRINT_TYPE_SEIKYU);
                string printer = Common.Common.GetPrinterName(Utility.Constants.PrintKbn.PRINT_KBN_SEIKYUSHO);
                // 2014.12.16 toyoda Mod End

                if (!Common.Common.PrinterExist(printer))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "請求書発行先プリンタが設定されていません。");
                    return;
                }

                // 請求書印刷
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "請求書を印刷します。\r\nよろしいですか？")
                    != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                ISeikyushoBtnClickALInput alInput = new SeikyushoBtnClickALInput();
                alInput.KagamiHdrDT = _kagamiDT;
                alInput.PrinterName = printer;
                ISeikyushoBtnClickALOutput alOutput = new SeikyushoBtnClickApplicationLogic().Execute(alInput);
                
                // 2015.01.07 toyoda Add Start
                // 表示データを再取得
                DoFormLoad();
                // 2015.01.07 toyoda Add End
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

        #region meisaishoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： meisaishoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void meisaishoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int changedDgv = UpdateType();

                if (_dispMode == DispMode.Edit
                    && (seikyusakiNmTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakiNm.Trim()
                    || zipNoTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakisakiZipCd.Trim()
                    || adrTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakiAdr.Trim()
                    || telNoTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SekyusakiTel.Trim()
                    || seikyuDtDateTimePicker.Value.ToString("yyyyMMdd") != _seikyuShosaiFormLoadHdrRow.SeikyuDt
                    || changedDgv == 1)
                    && !wasUpdated)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "請求書出力前に更新処理を実施してください。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "明細書を印刷します。\r\nよろしいですか？")
                    != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                ISeisaishoBtnClickALInput alInput = new SeisaishoBtnClickALInput();
                alInput.KagamiHdrDT = _kagamiDT;
                new SeisaishoBtnClickApplicationLogic().Execute(alInput);

                // 2015.01.07 toyoda Add Start
                // 表示データを再取得
                DoFormLoad();
                // 2015.01.07 toyoda Add End
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

        #region CloseButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CloseButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int changedDgv = UpdateType();

                if (_dispMode == DispMode.Edit)
                {
                    if (
                        ((_seikyuShosaiFormLoadHdrRow != null)
                            && (seikyusakiNmTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakiNm.Trim()
                                || zipNoTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakisakiZipCd.Trim()
                                || adrTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SeikyusakiAdr.Trim()
                                || telNoTextBox.Text.Trim() != _seikyuShosaiFormLoadHdrRow.SekyusakiTel.Trim()
                                || seikyuDtDateTimePicker.Value.ToString("yyyyMMdd") != _seikyuShosaiFormLoadHdrRow.SeikyuDt))
                        || ((_seikyuShosaiFormLoadHdrRow == null)
                            && (seikyusakiNmTextBox.Text.Trim() != string.Empty
                                || zipNoTextBox.Text.Trim() != string.Empty
                                || adrTextBox.Text.Trim() != string.Empty
                                || telNoTextBox.Text.Trim() != string.Empty
                                || seikyuDtDateTimePicker.Value.ToString("yyyyMMdd") != today.ToString("yyyyMMdd")))
                        || changedDgv == 1
                        )
                    {
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "更新処理が行われていない場合、入力した内容は全て破棄されます。\r\n請求入力を終了しますか？")
                            != System.Windows.Forms.DialogResult.Yes)
                        {
                            return;
                        }
                    }
                }

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

        #region SeikyuShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SeikyuShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeikyuShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F2:
                        updateButton.Focus();
                        updateButton.PerformClick();
                        break;

                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
                        break;

                    case Keys.F6:
                        seikyushoButton.Focus();
                        seikyushoButton.PerformClick();
                        break;

                    case Keys.F7:
                        meisaishoButton.Focus();
                        meisaishoButton.PerformClick();
                        break;

                    case Keys.F8:
                        meisaiAddButton.Focus();
                        meisaiAddButton.PerformClick();
                        break;

                    case Keys.F9:
                        meisaiDelButton.Focus();
                        meisaiDelButton.PerformClick();
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
        /// 2014/09/30  DatNT　  新規作成
        /// 2014/11/05  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Clear DGV
            seikyuListDataGridView.Rows.Clear();

            addNewMeisai = false;

            // 請求No
            //seikyuNoTextBox.Text = _seikyuNo;
            seikyuNoTextBox.Text = _oyaseikyuNo;

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.OyaSeikyuNo = _oyaseikyuNo;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            _kagamiDT = alOutput.SeikyusyoKagamiHdrTblDataTable;

            _hdrDT = alOutput.SeikyuHdrTblDT;

            if (alOutput.SeikyuShosaiFormLoadHdrDT != null && alOutput.SeikyuShosaiFormLoadHdrDT.Count > 0)
            {
                _seikyuShosaiFormLoadHdrRow = alOutput.SeikyuShosaiFormLoadHdrDT[0];

                SetValues(_seikyuShosaiFormLoadHdrRow);

                if (alOutput.SeikyuShosaiFormLoadDtlDT != null && alOutput.SeikyuShosaiFormLoadDtlDT.Count > 0)
                {
                    // Display DGV
                    foreach (SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlRow row in alOutput.SeikyuShosaiFormLoadDtlDT)
                    {
                        DataGridViewRow dgvRow = seikyuListDataGridView.Rows[seikyuListDataGridView.Rows.Add()];

                        // 請求先
                        dgvRow.Cells[seikyusakiCol.Name].Value = row.SeikyusakiNm;

                        // 連番
                        dgvRow.Cells[renbanCol.Name].Value = row.SeikyuRenban;
                        
                        // 支所名
                        dgvRow.Cells[shishoNmCol.Name].Value = row.shishoNmCol;

                        dgvRow.Cells[shishoCdCol.Name].Value = row.SeikyuShisyoCd;

                        // 請求書科目名
                        dgvRow.Cells[seikyuKamokuCol.Name].Value = row.SeikyuKomokuNm;

                        // 商品名
                        dgvRow.Cells[syohinCol.Name].Value = row.SeikyuSyohinNm;

                        // 数量
                        dgvRow.Cells[suryoCol.Name].Value = row.SeikyuCnt;

                        // 単価
                        dgvRow.Cells[tankaCol.Name].Value = row.SeikyuTanka;

                        // 金額
                        dgvRow.Cells[kingakuCol.Name].Value = row.SeikyuGaku;

                        // 消費税
                        dgvRow.Cells[syohizeiCol.Name].Value = row.SyohizeiGaku;

                        // 合計金額
                        dgvRow.Cells[totalCol.Name].Value = row.SeikyuKingakuKei;

                        // 入金額
                        dgvRow.Cells[nyukinCol.Name].Value = row.NyukinTotal;

                        // 完済
                        dgvRow.Cells[kansaiCol.Name].Value = row.kansaiCol;

                        // 請求項目区分（隠し）
                        dgvRow.Cells[seikyuKomokuKbnCol.Name].Value = row.SeikyuKomokuKbn;

                        // 課税フラグ（隠し）
                        dgvRow.Cells[kazeiFlagCol.Name].Value = row.KazeiFlag;

                        // 登録者（隠し）
                        dgvRow.Cells[torokuNmCol.Name].Value = row.InsertUser;

                        // 登録日時（隠し）
                        dgvRow.Cells[torokuDtCol.Name].Value = row.InsertDt;

                        // 登録端末（隠し）
                        dgvRow.Cells[torokuTanmatsuCol.Name].Value = row.InsertTarm;

                        // 請求No
                        dgvRow.Cells[seikyuNoCol.Name].Value = row.SeikyuNo;

                        dgvRow.Cells[SeikyuRenbanCol.Name].Value = row.SeikyuRenban;

                        if (row.SeikyuKomokuKbn == "9")
                        {
                            dgvRow.Cells[changedFlgCol.Name].Value = "0";
                        }
                        else
                        {
                            dgvRow.Cells[changedFlgCol.Name].Value = "1";
                        }
                    }

                    SetBGColor(true);
                }
            }
        }
        #endregion

        #region SetValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetValues
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// 2014/11/05  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetValues(//SeikyuDtlTblDataSet.SeikyuShosaiFormLoadRow row)
                                SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrRow row)
        {
            // 請求年月
            seikyuYMTextBox.Text = row.seikyuYMTextBox;

            // 請求先区分
            if (!row.IsSeikyusakiKbnNull())
            {
                if (row.SeikyusakiKbn == "1")
                {
                    gyoshaRadioButton.Checked = true;

                    // 業者コード
                    gyoshaCdTextBox.Text = row.IkkatsuSeikyuSakiCd;

                    // 業者名
                    gyoshaNmTextBox.Text = row.gyoshaNmTextBox;
                }
                else if (row.SeikyusakiKbn == "2")
                {
                    kojinRadioButton.Checked = true;
                }
            }

            // 設置者名
            settishaNmTextBox.Text = row.settishaNmTextBox;

            // 請求先
            seikyusakiNmTextBox.Text = row.SeikyusakiNm;

            // 郵便番号
            zipNoTextBox.Text = row.SeikyusakisakiZipCd;

            // 住所
            adrTextBox.Text = row.SeikyusakiAdr;

            // 電話番号
            telNoTextBox.Text = row.SekyusakiTel;

            // 請求日
            if (string.IsNullOrEmpty(row.SeikyuDt))
            {
                seikyuDtDateTimePicker.Value = today;
            }
            else
            {
                seikyuDtDateTimePicker.Value = new DateTime(Convert.ToInt32(row.SeikyuDt.Substring(0, 4)), Convert.ToInt32(row.SeikyuDt.Substring(4, 2)), Convert.ToInt32(row.SeikyuDt.Substring(6, 2)));
            }

            // 請求金額合計
            //seikyuTotalTextBox.Text = row.SeikyuTotal.ToString("N0");
            seikyuTotalTextBox.Text = row.IsSeikyuKingakuNull() ? "0" : row.SeikyuKingaku.ToString("N0");

            seikyuPrintLbl.Visible = (!row.IsSeikyusyoHakkoFlgNull() && row.SeikyusyoHakkoFlg == "1") ? true : false;

            //if (row.NyukinTotalHdr > 0)
            if(!row.IsNyukinTotalNull() && row.NyukinTotal > 0)
            {
                _dispMode = DispMode.Display;
            }
            else
            {
                _dispMode = DispMode.Edit;
            }

            SetControlModeView();
        }
        #endregion

        #region SetControlModeView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlModeView
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlModeView()
        {
            if (_dispMode == DispMode.Edit)
            {
                // 表示
                gyoshaRadioButton.Enabled = false;

                // 郵便番号
                zipNoTextBox.Enabled = true;

                // 請求日
                seikyuDtDateTimePicker.Enabled = true;

                // 明細追加ボタン
                meisaiAddButton.Enabled = true;

                // 明細削除ボタン
                meisaiDelButton.Enabled = true;

                // 請求金額合計
                seikyuTotalTextBox.Enabled = true;

                // 更新ボタン
                updateButton.Enabled = true;

                // 削除ボタン
                deleteButton.Enabled = true;
            }
            else
            {
                // 表示
                gyoshaRadioButton.Enabled = false;

                // 請求先
                seikyusakiNmTextBox.Enabled = false;
                
                // 郵便番号
                zipNoTextBox.Enabled = false;

                // 住所
                adrTextBox.Enabled = false;

                // 電話番号
                telNoTextBox.Enabled = false;

                // 請求日
                seikyuDtDateTimePicker.Enabled = false;

                // 明細追加ボタン
                meisaiAddButton.Enabled = false;

                // 明細削除ボタン
                meisaiDelButton.Enabled = false;

                // 請求金額合計
                seikyuTotalTextBox.Enabled = false;

                // 更新ボタン
                updateButton.Enabled = false;

                // 削除ボタン
                deleteButton.Enabled = false;
            }
        }
        #endregion

        #region SetBGColor
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetBGColor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loadedForm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetBGColor(bool isLoad)
        {
            int count = 0;

            foreach (DataGridViewRow row in seikyuListDataGridView.Rows)
            {
                if (row.Cells[seikyuKomokuKbnCol.Name].Value.ToString() == "9")
                {
                    row.DefaultCellStyle.BackColor = Color.Aqua;

                    count++;
                }
            }

            if (isLoad)
            {
                countKbn9 = count;
            }
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
        /// 2014/10/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // 請求先
            if(string.IsNullOrEmpty(seikyusakiNmTextBox.Text.Trim()))
            {
                errMess.AppendLine("請求先が入力されていません。");
            }

            if (string.IsNullOrEmpty(adrTextBox.Text.Trim()))
            {
                errMess.AppendLine("住所が入力されていません。");
            }

            if(!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region CalcSeikyuTotal
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CalcSeikyuTotal
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private decimal CalcSeikyuTotal()
        {
            decimal seikyuTotal = 0;

            foreach (DataGridViewRow row in seikyuListDataGridView.Rows)
            {
                if (row.Cells["totalCol"].Value != null && !string.IsNullOrEmpty(row.Cells["totalCol"].Value.ToString()))
                {
                    seikyuTotal += Convert.ToDecimal(row.Cells["totalCol"].Value);
                }
            }

            return seikyuTotal;
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateType"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate(int updateType)
        {
            // SeikyusyoKagamiHdrTbl DT
            SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable kagamiHdrDT = CreateKagamiDT(_kagamiDT, string.Empty);

            // SeikyuHdrTbl DT
            SeikyuHdrTblDataSet.SeikyuHdrTblDataTable seikyuHdrDT = CreateSeikyuHdrUpdateDT(_hdrDT);

            // SeikyuHdrTbl Insert DT
            SeikyuHdrTblDataSet.SeikyuHdrTblDataTable seikyuHdrInsertDT = new SeikyuHdrTblDataSet.SeikyuHdrTblDataTable();

            // SeikyuDtlTbl DT
            SeikyuDtlTblDataSet.SeikyuDtlTblDataTable dtlDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();
            
            if (updateType == 0)
            {
                kagamiHdrDT = CreateKagamiDT(_kagamiDT, string.Empty);
            }
            else
            {
                kagamiHdrDT = CreateKagamiDT(_kagamiDT, seikyuTotalTextBox.Text);

                dtlDT = CreateSeikyuDtlInsertDT();

                seikyuHdrInsertDT = CreateSeikyuHdrInsertDT(_kagamiDT);
            }            

            IUpdateBtnClickALInput alInput  = new UpdateBtnClickALInput();
            alInput.KagamiHdrDT             = kagamiHdrDT;
            alInput.SeikyuHdrTblDT          = seikyuHdrDT;
            alInput.SeikyuDtlTblDT          = dtlDT;
            alInput.SeikyuHdrTblInsertDT    = seikyuHdrInsertDT;
            alInput.UpdateType              = updateType;
            alInput.IsGyosha                = gyoshaRadioButton.Checked ? true : false;
            IUpdateBtnClickALOutput alOutput = new UpdateBtnClickApplicationLogic().Execute(alInput);

            MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新処理が完了しました。");

            DoFormLoad();
        }
        #endregion

        #region CreateKagamiDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKagamiDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kagamiDT"></param>
        /// <param name="seikyuTotal"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable CreateKagamiDT(
            SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable kagamiDT,
            string seikyuTotal)
        {
            // 請求先
            kagamiDT[0].SeikyusakiNm = seikyusakiNmTextBox.Text.Trim();

            // 郵便番号
            kagamiDT[0].SeikyusakisakiZipCd = zipNoTextBox.Text.Trim();

            // 住所
            kagamiDT[0].SeikyusakiAdr = adrTextBox.Text.Trim();

            // 電話番号
            kagamiDT[0].SekyusakiTel = telNoTextBox.Text.Trim();

            // 請求日
            kagamiDT[0].SeikyuDt = seikyuDtDateTimePicker.Value.ToString("yyyyMMdd");

            kagamiDT[0].UpdateTarm = pcUpdate;
            kagamiDT[0].UpdateUser = loginUser;

            if (!string.IsNullOrEmpty(seikyuTotal))
            {
                kagamiDT[0].SeikyuKingaku = Convert.ToDecimal(seikyuTotal);
            }

            return kagamiDT;
        }
        #endregion

        #region CreateSeikyuHdrInsertDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSeikyuHdrInsertDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kagamiHdrDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuHdrTblDataSet.SeikyuHdrTblDataTable CreateSeikyuHdrInsertDT(
            SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable kagamiHdrDT)
        {
            SeikyuHdrTblDataSet.SeikyuHdrTblDataTable hdrInsertDT = new SeikyuHdrTblDataSet.SeikyuHdrTblDataTable();

            SeikyuHdrTblDataSet.SeikyuHdrTblRow hdrInsertRow = hdrInsertDT.NewSeikyuHdrTblRow();

            string nendo = Utility.DateUtility.GetNendo(today).ToString();

            // 請求No
            hdrInsertRow.SeikyuNo = nendo + Utility.Saiban.GetSaibanRenban(today, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_06);

            // 請求年月
            hdrInsertRow.SeikyuYM = string.Concat(seikyuYMTextBox.Text.Substring(0, 4), seikyuYMTextBox.Text.Substring(5, 2));

            // 親請求No
            hdrInsertRow.OyaSeikyuNo = _oyaseikyuNo;

            // 締め区分
            if (!kagamiHdrDT[0].IsShimeKbnNull())
            {
                hdrInsertRow.ShimeKbn = kagamiHdrDT[0].ShimeKbn;
            }

            // 作成区分
            hdrInsertRow.SeikyuMakeKbn = kagamiHdrDT[0].SeikyuMakeKbn;

            // 請求先区分
            hdrInsertRow.SeikyusakiKbn = gyoshaRadioButton.Checked ? "1" : "2";

            // 業者コード
            hdrInsertRow.SeikyuGyosyaCd = !kagamiHdrDT[0].IsIkkatsuSeikyuSakiCdNull() ? kagamiHdrDT[0].IkkatsuSeikyuSakiCd : null;

            // 浄化槽保健所コード
            hdrInsertRow.JokasoHokenjoCd = !kagamiHdrDT[0].IsJokasoHokenjoCdNull() ? kagamiHdrDT[0].JokasoHokenjoCd : null;

            // 浄化槽台帳登録年度
            hdrInsertRow.JokasoTorokuNendo = !kagamiHdrDT[0].IsJokasoTorokuNendoNull() ? kagamiHdrDT[0].JokasoTorokuNendo : null;

            // 浄化槽台帳連番
            hdrInsertRow.JokasoRenban = !kagamiHdrDT[0].IsJokasoRenbanNull() ? kagamiHdrDT[0].JokasoRenban : null;

            // 請求先名称
            hdrInsertRow.SeikyusakiNm = seikyusakiNmTextBox.Text.Trim();

            // 請求日
            hdrInsertRow.SeikyuDt = seikyuDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 請求締め日
            hdrInsertRow.SeikyuShimeDt = string.Empty;

            // 再請求回数
            hdrInsertRow.SaiseikyuCnt = 0;

            // 再請求日
            hdrInsertRow.SaiseikyuDt = string.Empty;

            // 再請求締め日
            hdrInsertRow.SaiseikyuShimeDt = string.Empty;

            //// 請求金額
            //hdrInsertRow.SeikyuKingaku = !kagamiHdrDT[0].IsSeikyuKingakuNull() ? kagamiHdrDT[0].SeikyuKingaku : 0;

            //// 繰り越し等合計
            //hdrInsertRow.KurikoshiKingaku = !kagamiHdrDT[0].IsKurikoshiKingakuNull() ? kagamiHdrDT[0].KurikoshiKingaku : 0;

            //// 請求合計金額
            //hdrInsertRow.SeikyuTotal = !kagamiHdrDT[0].IsSeikyuTotalNull() ? kagamiHdrDT[0].SeikyuTotal : 0;

            // 入金合計金額
            hdrInsertRow.NyukinTotal = 0;

            // 請求確定フラグ
            hdrInsertRow.SeikyuKakuteiFlg = "0";

            hdrInsertRow.InsertDt = today;
            hdrInsertRow.InsertUser = loginUser;
            hdrInsertRow.InsertTarm = pcUpdate;
            hdrInsertRow.UpdateDt = today;
            hdrInsertRow.UpdateUser = loginUser;
            hdrInsertRow.UpdateTarm = pcUpdate;

            hdrInsertDT.AddSeikyuHdrTblRow(hdrInsertRow);
            hdrInsertRow.AcceptChanges();
            hdrInsertRow.SetAdded();
            
            return hdrInsertDT;
        }
        #endregion

        #region CreateSeikyuDtlInsertDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSeikyuDtlInsertDT
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuDtlTblDataSet.SeikyuDtlTblDataTable CreateSeikyuDtlInsertDT()
        {
            SeikyuDtlTblDataSet.SeikyuDtlTblDataTable dtlInsertDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();

            string seikyuNo = string.Empty;

            int renban = 0;

            foreach (DataGridViewRow row in seikyuListDataGridView.Rows)
            {
                if (row.Cells[seikyuKomokuKbnCol.Name].Value != null && row.Cells[seikyuKomokuKbnCol.Name].Value.ToString() == "9")
                {
                    SeikyuDtlTblDataSet.SeikyuDtlTblRow dtlInsertRow = dtlInsertDT.NewSeikyuDtlTblRow();

                    // 請求No 
                    dtlInsertRow.SeikyuNo = row.Cells[seikyuNoCol.Name].Value.ToString();

                    // 連番
                    dtlInsertRow.SeikyuRenban = renban--;
                    
                    // 支所コード
                    dtlInsertRow.SeikyuShisyoCd = row.Cells[shishoCdCol.Name].Value.ToString();

                    // 請求項目区分
                    dtlInsertRow.SeikyuKomokuKbn = "9";

                    // 請求書科目名
                    dtlInsertRow.SeikyuKomokuNm = row.Cells[seikyuKamokuCol.Name].Value.ToString();

                    // 商品名
                    dtlInsertRow.SeikyuSyohinNm = row.Cells[syohinCol.Name].Value.ToString();

                    // 商品売上日
                    dtlInsertRow.SyohinUriageDt = seikyuDtDateTimePicker.Value.ToString("yyyyMMdd");

                    // 数量
                    dtlInsertRow.SeikyuCnt = Convert.ToInt32(row.Cells[suryoCol.Name].Value);

                    // 単価
                    dtlInsertRow.SeikyuTanka = !string.IsNullOrEmpty(row.Cells[tankaCol.Name].Value.ToString()) ? Convert.ToDecimal(row.Cells[tankaCol.Name].Value) : 0;

                    // 金額
                    dtlInsertRow.SeikyuGaku = Convert.ToDecimal(row.Cells[kingakuCol.Name].Value);

                    // 消費税
                    dtlInsertRow.SyohizeiGaku = Convert.ToDecimal(row.Cells[syohizeiCol.Name].Value);

                    // 合計金額
                    dtlInsertRow.SeikyuKingakuKei = Convert.ToDecimal(row.Cells[totalCol.Name].Value);

                    // 入金額
                    dtlInsertRow.NyukinTotal = Convert.ToDecimal(row.Cells[nyukinCol.Name].Value);

                    // 課税フラグ
                    dtlInsertRow.KazeiFlag = row.Cells[kazeiFlagCol.Name].Value.ToString();

                    // 完済フラグ
                    if (dtlInsertRow.SeikyuKingakuKei >= 0)
                    {
                        dtlInsertRow.SeikyuKansaiFlg = "0";
                    }
                    else
                    {
                        dtlInsertRow.SeikyuKansaiFlg = "2";
                    }

                    dtlInsertRow.InsertDt = today;
                    dtlInsertRow.InsertTarm = pcUpdate;
                    dtlInsertRow.InsertUser = loginUser;
                    dtlInsertRow.UpdateDt = today;
                    dtlInsertRow.UpdateTarm = pcUpdate;
                    dtlInsertRow.UpdateUser = loginUser;

                    dtlInsertDT.AddSeikyuDtlTblRow(dtlInsertRow);
                    dtlInsertRow.AcceptChanges();
                    dtlInsertRow.SetAdded();
                }
            }

            return dtlInsertDT;
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 請求No
            seikyuNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 8);

            // 請求年月
            seikyuYMTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 7);

            // 業者コード
            gyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD);

            // 業者名
            gyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            // 設置者名
            settishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);

            // 請求先
            seikyusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);

            // 郵便番号
            zipNoTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);

            // 住所
            adrTextBox.SetStdControlDomain(ZControlDomain.ZT_ADR);

            // 電話番号
            telNoTextBox.SetStdControlDomain(ZControlDomain.ZT_TEL_NO);

            // 請求金額合計
            seikyuTotalTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);

            // 請求先
            seikyuListDataGridView.SetStdControlDomain(seikyusakiCol.Index, ZControlDomain.ZG_STD_NAME, 60);

            // 連番
            seikyuListDataGridView.SetStdControlDomain(renbanCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 支所名
            seikyuListDataGridView.SetStdControlDomain(shishoNmCol.Index, ZControlDomain.ZG_STD_NAME, 10);

            // 請求書科目名
            seikyuListDataGridView.SetStdControlDomain(seikyuKamokuCol.Index, ZControlDomain.ZG_STD_NAME, 40);

            // 商品名
            seikyuListDataGridView.SetStdControlDomain(syohinCol.Index, ZControlDomain.ZG_STD_NAME, 60);

            // 数量
            seikyuListDataGridView.SetStdControlDomain(suryoCol.Index, ZControlDomain.ZG_STD_NUM, 4);

            // 単価
            seikyuListDataGridView.SetStdControlDomain(tankaCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 金額
            seikyuListDataGridView.SetStdControlDomain(kingakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 消費税
            seikyuListDataGridView.SetStdControlDomain(syohizeiCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 合計金額
            seikyuListDataGridView.SetStdControlDomain(totalCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 入金額
            seikyuListDataGridView.SetStdControlDomain(nyukinCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 完済
            seikyuListDataGridView.SetStdControlDomain(kansaiCol.Index, ZControlDomain.ZG_STD_NAME, 4, DataGridViewContentAlignment.MiddleCenter);
        }
        #endregion

        #region UpdateType
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateType
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private int UpdateType()
        {
            int countFlg = 0;

            foreach (DataGridViewRow row in seikyuListDataGridView.Rows)
            {
                if (row.Cells[changedFlgCol.Name].Value.ToString() == "0")
                {
                    countFlg++;
                }
            }

            if (countFlg == countKbn9 && !addNewMeisai)
            {
                return 0;
            }

            return 1;
        }
        #endregion

        #region CreateSeikyuHdrUpdateDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSeikyuHdrUpdateDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdrDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuHdrTblDataSet.SeikyuHdrTblDataTable CreateSeikyuHdrUpdateDT(SeikyuHdrTblDataSet.SeikyuHdrTblDataTable hdrDT)
        {
            foreach (SeikyuHdrTblDataSet.SeikyuHdrTblRow row in hdrDT)
            {
                // 請求先名称
                row.SeikyusakiNm = seikyusakiNmTextBox.Text.Trim();

                // 請求日
                row.SeikyuDt = seikyuDtDateTimePicker.Value.ToString("yyyyMMdd");

                row.UpdateTarm = pcUpdate;

                row.UpdateUser = loginUser;
            }

            return hdrDT;
        }
        #endregion

        #endregion

    }
    #endregion
}
