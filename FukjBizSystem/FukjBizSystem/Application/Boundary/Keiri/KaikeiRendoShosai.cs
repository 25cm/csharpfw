using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiRendoShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaikeiRendoShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaikeiRendoShosaiForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// 会計No 
        /// </summary>
        private string _kaikeiNo;

        /// <summary>
        /// KaikeiRendoHdrTblDataTable
        /// </summary>
        private KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable _hdrDT;

        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KaikeiRendoShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KaikeiRendoShosaiForm(string kaikeiNo)
        {
            InitializeComponent();

            this._kaikeiNo = kaikeiNo;
        }
        #endregion

        #region イベント

        #region KaikeiRendoShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaikeiRendoShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaikeiRendoShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetControlDomain();

                DoFormLoad();

                if (Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd != "0")
                {
                    // 会計連動ボタン
                    kaikeiRendoButton.Enabled = false;
                }
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

        #region koshinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： koshinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void koshinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された内容で出納管理情報を更新します。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                IKoshinBtnClickALInput alInput      = new KoshinBtnClickALInput();
                alInput.KaikeiRendoHdrTblDataTable  = CreateHdrDataUpdate(_hdrDT);
                alInput.KaikeiRendoDtlTblDT         = CreateDtlDataUpdate();
                IKoshinBtnClickALOutput alOuput     = new KoshinBtnClickApplicationLogic().Execute(alInput);

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新処理が完了しました。");

                kaikeiRendoHdrTblDataSet.Clear();
                kaikeiRendoHdrTblDataSet.Merge(alOuput.KaikeiRendoShosaiDT);

                _hdrDT = alOuput.KaikeiRendoHdrTblDataTable;
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

        #region deleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示している出納管理情報を削除します。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                alInput.KaikeiNo = _kaikeiNo;
                IDeleteBtnClickALOutput alOutput = new DeleteBtnClickApplicationLogic().Execute(alInput);

                //KaikeiRendoListForm frm = new KaikeiRendoListForm();
                //Program.mForm.ShowForm(frm);
                this.DialogResult = DialogResult.OK;
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

        #region kobetsuUkagaishoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kobetsuUkagaishoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kobetsuUkagaishoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (suitoMeisaiListDataGridView.RowCount == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "出納伺書を印刷します。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                //print 008(private)
                IKobetsuUkagaishoBtnClickALInput alInput = new KobetsuUkagaishoBtnClickALInput();
                alInput.KaiKeiNo = kaikeiNoTextBox.Text.Trim();
                alInput.KeikeiRenban = suitoMeisaiListDataGridView.CurrentRow.Cells[renbanCol.Name].Value.ToString();

                new KobetsuUkagaishoBtnClickApplicationLogic().Execute(alInput);

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

        #region ukagaisyoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ukagaisyoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ukagaisyoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "出納伺書を印刷します。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                IUkagaisyoBtnClickALInput alInput = new UkagaisyoBtnClickALInput();
                alInput.KaikeiRendoHdrTblDataTable = CreateHdrDataUkagaisyo(_hdrDT);
                alInput.KaikeiNo = kaikeiNoTextBox.Text.Trim();
                IUkagaisyoBtnClickALOutput alOutput = new UkagaisyoBtnClickApplicationLogic().Execute(alInput);

                _hdrDT = alOutput.KaikeiRendoHdrTblDT;
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

        #region kaikeiRendoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaikeiRendoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaikeiRendoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Common.Common.ExportKaikeiRendoToCSVFile(_kaikeiNo);
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
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "更新処理が行われていない場合、入力した内容は全て破棄されます。\r\n出納管理一覧画面へ遷移しますか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                //KaikeiRendoListForm frm = new KaikeiRendoListForm();
                //Program.mForm.ShowForm(frm);
                this.DialogResult = DialogResult.OK;
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

        #region KaikeiRendoShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KaikeiRendoShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KaikeiRendoShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F2:
                        koshinButton.PerformClick();
                        break;

                    case Keys.F3:
                        deleteButton.PerformClick();
                        break;

                    case Keys.F5:
                        kobetsuUkagaishoButton.PerformClick();
                        break;

                    case Keys.F6:
                        ukagaisyoButton.PerformClick();
                        break;

                    case Keys.F7:
                        kaikeiRendoButton.PerformClick();
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
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.KaikeiNo = _kaikeiNo;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            _hdrDT = alOutput.KaikeiRendoHdrTblDataTable;

            if (alOutput.KaikeiRendoShosaiDT != null && alOutput.KaikeiRendoShosaiDT.Count > 0)
            {
                KaikeiRendoHdrTblDataSet.KaikeiRendoShosaiRow hdrRow = alOutput.KaikeiRendoShosaiDT[0];

                // 会計No
                kaikeiNoTextBox.Text = hdrRow.KaikeiNo;

                // 対象区分
                taisyoKbnTextBox.Text = hdrRow.taisyoKbnTextBox;

                // 対象支所
                taisyoShisyoTextBox.Text = hdrRow.ShishoNm;

                // 対象期間（開始）
                taisyoDtFromTextBox.Text = hdrRow.taisyoDtFromTextBox;

                // 対象期間（終了）
                taisyoDtToTextBox.Text = hdrRow.taisyoDtToTextBox;

                // 作成対象
                if (!string.IsNullOrEmpty(hdrRow.MakeKbn))
                {
                    string yubin = hdrRow.MakeKbn.Substring(0, 1);
                    string bank = hdrRow.MakeKbn.Substring(1, 1);
                    string genkin = hdrRow.MakeKbn.Substring(2, 1);
                    string shiharai = hdrRow.MakeKbn.Substring(3, 1);

                    yubinCheckBox.Checked = (yubin == "1") ? true : false;
                    bankCheckBox.Checked = (bank == "1") ? true : false;
                    genkinCheckBox.Checked = (genkin == "1") ? true : false;
                    shiharaiCheckBox.Checked = (shiharai == "1") ? true : false;
                }

                // 作成範囲
                makeHaniKbnTextBox.Text = hdrRow.makeHaniKbnTextBox;

                // 承認区分
                if (hdrRow.SyoninFlg == "0")
                {
                    misyoninRadioButton.Checked = true;
                }
                else if (hdrRow.SyoninFlg == "1")
                {
                    syoninRadioButton.Checked = true;
                }
                else if (hdrRow.SyoninFlg == "2")
                {
                    kyakkaRadioButton.Checked = true;
                }

                // 出納明細一覧グリッドビュー
                kaikeiRendoHdrTblDataSet.Merge(alOutput.KaikeiRendoShosaiDT);
            }
        }
        #endregion

        #region CreateHdrDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHdrDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdrDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable CreateHdrDataUpdate(KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable hdrDT)
        {
            // 承認フラグ  
            if (misyoninRadioButton.Checked)
            {
                hdrDT[0].SyoninFlg = "0";
            }
            else if (syoninRadioButton.Checked)
            {
                hdrDT[0].SyoninFlg = "1";
            }
            else
            {
                hdrDT[0].SyoninFlg = "2";
            }

            return hdrDT;
        }
        #endregion

        #region CreateDtlDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDtlDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable CreateDtlDataUpdate()
        {
            KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable dtlDT = new KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable();

            if (suitoMeisaiListDataGridView.RowCount == 0)
            {
                return dtlDT;
            }

            foreach (DataGridViewRow row in suitoMeisaiListDataGridView.Rows)
            {
                KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow dtlRow = dtlDT.NewKaikeiRendoDtlTblRow();

                // 会計No 
                dtlRow.KaikeiNo = row.Cells["KaikeiNoCol"].Value.ToString();

                // 連番 
                dtlRow.KeikeiRenban = Convert.ToInt32(row.Cells["renbanCol"].Value);

                // 出力区分
                dtlRow.OutputKbn = row.Cells["outputCol"].Value.ToString();

                dtlRow.InsertDt = today;
                dtlRow.InsertUser = string.Empty;
                dtlRow.InsertTarm = string.Empty;
                dtlRow.UpdateDt = (DateTime)row.Cells["KaikeiRendoDtlTblUpdateDtCol"].Value;
                dtlRow.UpdateUser = string.Empty;
                dtlRow.UpdateTarm = string.Empty;

                dtlDT.AddKaikeiRendoDtlTblRow(dtlRow);
                dtlRow.AcceptChanges();
                dtlRow.SetAdded();
            }

            return dtlDT;
        }
        #endregion

        #region CreateHdrDataUkagaisyo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHdrDataUkagaisyo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdrDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable CreateHdrDataUkagaisyo(KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable hdrDT)
        {
            if (hdrDT[0].IsUkagaiMakeCntNull())
            {
                hdrDT[0].UkagaiMakeCnt = 1;
            }
            else
            {
                hdrDT[0].UkagaiMakeCnt = hdrDT[0].UkagaiMakeCnt + 1;
            }

            return hdrDT;
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
        /// 2014/11/14  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 会計No
            kaikeiNoTextBox.SetControlDomain(ZControlDomain.ZT_STD_CD);

            // 対象区分
            taisyoKbnTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 4);

            // 対象支所
            taisyoShisyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);

            // 対象期間（開始）
            taisyoDtFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);

            // 対象期間（終了）
            taisyoDtToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);

            // 作成範囲
            makeHaniKbnTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 4);

            // 連番
            suitoMeisaiListDataGridView.SetStdControlDomain(renbanCol.Index, ZControlDomain.ZG_STD_NUM, 3);

            // 会計コード
            suitoMeisaiListDataGridView.SetStdControlDomain(kaikeiCdCol.Index, ZControlDomain.ZG_STD_CD, 3);

            // 伝票日付
            suitoMeisaiListDataGridView.SetStdControlDomain(denpyoDtCol.Index, ZControlDomain.ZG_STD_NUM, 8);

            // 借方事業コード
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataJigyoCdCol.Index, ZControlDomain.ZG_STD_CD, 6);

            // 借方科目コード
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataKamokuCdCol.Index, ZControlDomain.ZG_STD_CD, 4);

            // 借方科目名
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataKamokuNｍCol.Index, ZControlDomain.ZG_STD_NAME, 14);

            // 借方補助科目コード
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataHojoCdCol.Index, ZControlDomain.ZG_STD_CD, 5);

            // 借方補助科目名
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataHojoNmCol.Index, ZControlDomain.ZG_STD_NAME, 14);

            // 借方税区分
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataZeiKbnCol.Index, ZControlDomain.ZG_STD_CD, 2);

            // 借方金額
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataKingakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 借方消費税
            suitoMeisaiListDataGridView.SetStdControlDomain(karikataSyohizeiCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 貸方事業コード
            suitoMeisaiListDataGridView.SetStdControlDomain(kashikataJigyoCdCol.Index, ZControlDomain.ZG_STD_CD, 6);

            // 貸方科目コード
            suitoMeisaiListDataGridView.SetStdControlDomain(kashikataKamokuCdCol.Index, ZControlDomain.ZG_STD_CD, 4);

            // 貸方科目略称
            suitoMeisaiListDataGridView.SetStdControlDomain(kashikataKamokuNｍCol.Index, ZControlDomain.ZG_STD_NAME, 14);

            // 貸方補助科目コード
            suitoMeisaiListDataGridView.SetStdControlDomain(kashikataHojoCdCol.Index, ZControlDomain.ZG_STD_CD, 5);

            // 貸方補助科目略称
            suitoMeisaiListDataGridView.SetStdControlDomain(kashikataHojoNmCol.Index, ZControlDomain.ZG_STD_NAME, 14);

            // 貸方税区分
            suitoMeisaiListDataGridView.SetStdControlDomain(kashikataZeiKbnCol.Index, ZControlDomain.ZG_STD_CD, 2);

            // 貸方金額
            suitoMeisaiListDataGridView.SetStdControlDomain(kashikataKingakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 貸方消費税
            suitoMeisaiListDataGridView.SetStdControlDomain(syouhizeiCol.Index, ZControlDomain.ZG_STD_NUM, 10);

            // 摘要
            suitoMeisaiListDataGridView.SetStdControlDomain(tekiyoCol.Index, ZControlDomain.ZG_STD_NAME, 254);
        }
        #endregion

        #endregion
    }
    #endregion
}
