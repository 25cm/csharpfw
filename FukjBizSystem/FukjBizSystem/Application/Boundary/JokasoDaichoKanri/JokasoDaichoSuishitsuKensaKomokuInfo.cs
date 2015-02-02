using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
//using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuMstList;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using System.Drawing;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Control.Common;
using FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo;
using FukjBizSystem.Application.DataSet;
using System.Data;
using FukjBizSystem.Application.Utility;

namespace FukjBizSystem.Application.Boundary.JokasoDaichoKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoDaichoSuishitsuKensaKomokuInfoForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// 2014/12/23  小松        選択で変更不可の行の色をグレイからライトグレイに変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JokasoDaichoSuishitsuKensaKomokuInfoForm : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Add,        // 新規登録
            Edit,       // 編集
            Init,       // 初期表示
        }
        #endregion

        #endregion

        #region プロパティ(public)

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// モード別画面制御
        /// </summary>
        private DispMode _displayMode = DispMode.Init;

        #region 画面起動引数
        /// <summary>
        /// 保健所コード
        /// </summary>
        private string _hokenjoCd = string.Empty;

        /// <summary>
        /// 年度
        /// </summary>
        private string _torokuNendo = string.Empty;

        /// <summary>
        /// 連番
        /// </summary>
        private string _renban = string.Empty;

        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable _suishitsuKensaKomokuInfoSearchDataTable = new SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable();

        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        private SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable _suishitsuKensaSetMstDataTable = new SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable();

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        private DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable _daichoSuishitsuKensaKomokuMstDataTable = new DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable();

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ For Rakkan Check
        /// </summary>
        private DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable _daichoSuishitsuKensaKomokuMstDataTableRakkan = new DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable();

        /// <summary>
        /// Need to call CalRyokin()
        /// </summary>
        private bool _isCalRyokin = false;

        // 20150201 sou Start
        /// <summary>
        /// 会員区分
        /// </summary>
        private string _kaiinKbn = string.Empty;

        /// <summary>
        /// 会員価格適用区分
        /// </summary>
        private string _tekiyoKbn = string.Empty;
        // 20150201 sou End

        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JokasoDaichoSuishitsuKensaKomokuInfoForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JokasoDaichoSuishitsuKensaKomokuInfoForm()
        {
            InitializeComponent();
            //this.kensaKomokuListDataGridView.Rows.Add("false", "001", "ｐＨ（測定時液温）", "ｐＨ", "600", "ＪＩＳ　Ｋ　０１０２　１２．１", "（ガラス電極法）", "セット");
            //this.kensaKomokuListDataGridView.Rows.Add("false", "002", "懸濁物質", "ＳＳ", "2,400", "昭和４６年環境庁告示第５９号付表９", "（ろ過重量法）", "セット");
            //this.kensaKomokuListDataGridView.Rows.Add("false", "003", "ＢＯＤ", "Ｃ－ＢＯＤ", "4,000", "ＪＩＳ　Ｋ　０１０２　２１．備考１及び", "３２．３（隔膜電極法）", "単独");
            //this.kensaKomokuListDataGridView.Rows.Add("false", "022", "ＢＯＤ", "ＢＯＤ", "4,000", "ＪＩＳ　Ｋ　０１０２　２１．及び３２．３", "（隔膜電極法）", "単独");
            //kensaKomokuListDataGridView.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;
            //kensaKomokuListDataGridView.Rows[1].DefaultCellStyle.BackColor = Color.LightGray;
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JokasoDaichoSuishitsuKensaKomokuInfoForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// 2014/12/17　HieuNH　　　Default mode is Init
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JokasoDaichoSuishitsuKensaKomokuInfoForm(string hokenjoCd, string torokuNendo, string renban)
            : base()
        {
            this._hokenjoCd = hokenjoCd;
            this._torokuNendo = torokuNendo;
            this._renban = renban;
            //// ADD HieuNH 2014/12/17 BEGIN
            this._displayMode = DispMode.Init;
            //// ADD HieuNH 2014/12/17 END

            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： YachoTorikomiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JokasoDaichoSuishitsuKensaKomokuInfoForm(string hokenjoCd, string torokuNendo, string renban, DispMode initDispMode)
            : base()
        {
            this._hokenjoCd = hokenjoCd;
            this._torokuNendo = torokuNendo;
            this._renban = renban;
            this._displayMode = initDispMode;

            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region イベント

        #region JokasoDaichoSuishitsuKensaKomokuInfoForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JokasoDaichoSuishitsuKensaKomokuInfoForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoDaichoSuishitsuKensaKomokuInfoForm_Load(object sender, EventArgs e)
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

        #region kihonKensaSetComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kihonKensaSetComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kihonKensaSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string setNm, komokuNm;

                //// MODIFY HieuNH 2014/12/19 BEGIN
                //Utility.KeiryoShomeiUtility.GetSuishitsuSetKomokuNm(kihonKensaSetComboBox.SelectedValue.ToString(), out setNm, out komokuNm);
                Utility.KeiryoShomeiUtility.GetSuishitsuSetKomokuNm(kihonKensaSetComboBox.SelectedValue == null? string.Empty : kihonKensaSetComboBox.SelectedValue.ToString(), out setNm, out komokuNm);
                //// MODIFY HieuNH 2014/12/19 END

                setNaiyoTextBox.Text = komokuNm;

                ChangeTorokuKbn();

                CalRyokin();
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

        #region JokasoDaichoSuishitsuKensaKomokuInfoForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： JokasoDaichoSuishitsuKensaKomokuInfoForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void JokasoDaichoSuishitsuKensaKomokuInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F5:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F6:
                        shinkiButton.Focus();
                        shinkiButton.PerformClick();
                        break;
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F1:
                        torokuButton.Focus();
                        torokuButton.PerformClick();
                        break;
                    case Keys.F2:
                        updateButton.Focus();
                        updateButton.PerformClick();
                        break;
                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
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
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region pushButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： pushButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/1　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void pushButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoPush();
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "水質検査項目内容の情報を全てクリアします。よろしいですか？") == System.Windows.Forms.DialogResult.Yes)
                {
                    InitScreen();
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/19　HieuNH　　　kihonKensaSetComboBox does not require (v1.02)
        /// 2014/12/22　HieuNH　　　Fix bug
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150201 sou Start
                if (string.IsNullOrEmpty(kensaRyokinTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検査料金合計が未入力です。");
                    return;
                }
                // 20150201 sou End

                if (!UpdateCheck())
                    return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "登録処理を実行します。よろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                    return;

                //// DELETE HieuNH 2014/12/22 BEGIN
                //if (!InsertCheck())
                //    return;
                //// DELETE HieuNH 2014/12/22 END

                ITorokuBtnClickALInput alInput = new TorokuBtnClickALInput();
                //// MODIFY HieuNH 2014/12/19 BEGIN
                //alInput.DaichoKensaKomokuSetCd = kihonKensaSetComboBox.SelectedValue.ToString();
                alInput.DaichoKensaKomokuSetCd = kihonKensaSetComboBox.SelectedValue == null? string.Empty: kihonKensaSetComboBox.SelectedValue.ToString();
                //// MODIFY HieuNH 2014/12/19 END
                alInput.DaichoKensaSetNm = setNmTextBox.Text;
                alInput.DaichoSuishitsuKensaKomokuMstDataTable = _daichoSuishitsuKensaKomokuMstDataTable;
                alInput.HokenjoCd = _hokenjoCd;
                alInput.SuishitsuCd = suishitsuSyuruiComboBox.SelectedValue.ToString();
                alInput.Renban = _renban;
                alInput.SuishitsuKensaKomokuInfoSearchDataTable = _suishitsuKensaKomokuInfoSearchDataTable;
                alInput.TorokuNendo = _torokuNendo;
                // 20150201 sou Start
                alInput.Ryokin = (string.IsNullOrEmpty(kensaRyokinTextBox.Text) ? 0 : decimal.Parse(kensaRyokinTextBox.Text));
                // 20150201 sou End

                //// MODIFY HieuNH 2014/12/22 BEGIN
                //new TorokuBtnClickApplicationLogic().Execute(alInput);
                ITorokuBtnClickALOutput alOutput= new TorokuBtnClickApplicationLogic().Execute(alInput);
                //// MODIFY HieuNH 2014/12/22 END

                //// ADD HieuNH 2014/12/22 BEGIN
                if (alOutput.ErrorCode == 1)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "この浄化槽ではこれ以上、検査項目セットを新規登録できません。");
                    return;
                }
                //// ADD HieuNH 2014/12/22 END
                
                DoFormLoad();

                InitScreen();
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/19　HieuNH　　　kihonKensaSetComboBox does not require (v1.02)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void updateButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150201 sou Start
                if (string.IsNullOrEmpty(kensaRyokinTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検査料金合計が未入力です。");
                    return;
                }
                // 20150201 sou End

                if (!UpdateCheck())
                    return;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "変更対象の登録枝番ですでに依頼書を出力されていた場合、\n受付時に内容が変更される場合があります。\nよろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                    return;

                IUpdateBtnClickALInput alInput = new UpdateBtnClickALInput();
                //// MODIFY HieuNH 2014/12/19 BEGIN
                //alInput.DaichoKensaKomokuSetCd = kihonKensaSetComboBox.SelectedValue.ToString();
                alInput.DaichoKensaKomokuSetCd = kihonKensaSetComboBox.SelectedValue == null ? string.Empty : kihonKensaSetComboBox.SelectedValue.ToString();
                //// MODIFY HieuNH 2014/12/19 END
                alInput.DaichoKensaSetNm = setNmTextBox.Text;
                alInput.DaichoSuishitsuKensaKomokuMstDataTableRakkan = _daichoSuishitsuKensaKomokuMstDataTableRakkan;
                alInput.HokenjoCd = _hokenjoCd;
                alInput.Renban = _renban;
                alInput.SuishitsuCd = suishitsuSyuruiComboBox.SelectedValue.ToString();
                alInput.SuishitsuKensaKomokuInfoSearchDataTable = _suishitsuKensaKomokuInfoSearchDataTable;
                alInput.TorokuNendo = _torokuNendo;
                // 20150201 sou Start
                alInput.Ryokin = (string.IsNullOrEmpty(kensaRyokinTextBox.Text) ? 0 : decimal.Parse(kensaRyokinTextBox.Text));
                // 20150201 sou End
                new UpdateBtnClickApplicationLogic().Execute(alInput);

                DoFormLoad();

                InitScreen();
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "削除対象の登録枝番ですでに依頼書を出力されていた場合、\n受付時に新たに浄化槽台帳検査項目を作成する必要があります。\nよろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                    return;

                IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                alInput.HokenjoCd = _hokenjoCd;
                alInput.Renban = _renban;
                alInput.DaichoKensaKomokuEdaban = torokuEdabanComboBox.SelectedValue.ToString();
                alInput.TorokuNendo = _torokuNendo;
                new DeleteBtnClickApplicationLogic().Execute(alInput);

                DoFormLoad();

                InitScreen();
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

        #region kensaKomokuListDataGridView_CurrentCellDirtyStateChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaKomokuListDataGridView_CurrentCellDirtyStateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaKomokuListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kensaKomokuListDataGridView.IsCurrentCellDirty && kensaKomokuListDataGridView.CurrentCell is DataGridViewCheckBoxCell && kensaKomokuListDataGridView.CurrentCell.ColumnIndex == addCol.Index)
                {
                    _isCalRyokin = true;
                    kensaKomokuListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    kensaKomokuListDataGridView.EndEdit();
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

        #region kensaKomokuListDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaKomokuListDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/22　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaKomokuListDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow row in kensaKomokuListDataGridView.Rows)
                {
                    if (row.Cells[colorFlg.Index].Value != null && row.Cells[colorFlg.Index].Value.ToString().Equals("1"))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.ReadOnly = true;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.ReadOnly = false;
                    }
                }
                kensaKomokuListDataGridView.Refresh();
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

        #region kensaKomokuListDataGridView_CellEndEdit
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaKomokuListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaKomokuListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.ColumnIndex == addCol.Index && _isCalRyokin)
                {
                    _isCalRyokin = false;
                    CalRyokin();
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

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// 2014/12/17　HieuNH　　　Remove alignment for kensaRyokinTextBox
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            jokasoCd1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2, HorizontalAlignment.Left);
            jokasoCd2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2, HorizontalAlignment.Left);
            jokasoCd3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5, HorizontalAlignment.Left);
            settisyaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60, HorizontalAlignment.Left);
            setNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80, HorizontalAlignment.Left);
            //// MODIFY HieuNH 2014/12/17 BEGIN
            //kensaRyokinTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10, HorizontalAlignment.Left);
            kensaRyokinTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            //// MODIFY HieuNH 2014/12/17 END

            kensaKomokuListDataGridView.SetStdControlDomain(kensaCdCol.Index, ZControlDomain.ZG_STD_CD, 3, DataGridViewContentAlignment.MiddleLeft);
            kensaKomokuListDataGridView.SetStdControlDomain(kensaNmCol.Index, ZControlDomain.ZG_STD_NAME, 30, DataGridViewContentAlignment.MiddleLeft);
            kensaKomokuListDataGridView.SetStdControlDomain(kensaRyakushoCol.Index, ZControlDomain.ZG_STD_NAME, 10, DataGridViewContentAlignment.MiddleLeft);
            kensaKomokuListDataGridView.SetStdControlDomain(kensaRyokinCol.Index, ZControlDomain.ZG_STD_NUM, 10, DataGridViewContentAlignment.MiddleRight);
            kensaKomokuListDataGridView.SetStdControlDomain(keiryoHohoJodanCol.Index, ZControlDomain.ZG_STD_NUM, 44, DataGridViewContentAlignment.MiddleLeft);
            kensaKomokuListDataGridView.SetStdControlDomain(keiryoHohoGedanCol.Index, ZControlDomain.ZG_STD_NUM, 44, DataGridViewContentAlignment.MiddleLeft);
            kensaKomokuListDataGridView.SetStdControlDomain(torokuKbnCol.Index, ZControlDomain.ZG_STD_NAME, 6, DataGridViewContentAlignment.MiddleCenter);
        }
        #endregion

        #region SetControlData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlData()
        {
            jokasoCd1TextBox.Text = string.IsNullOrEmpty(_hokenjoCd) ? string.Empty : _hokenjoCd;
            jokasoCd2TextBox.Text = string.IsNullOrEmpty(_torokuNendo) ? string.Empty : Utility.DateUtility.ConvertToWareki(_torokuNendo, "yy"); 
            jokasoCd3TextBox.Text = string.IsNullOrEmpty(_renban) ? string.Empty : _renban;

            if (torokuEdabanComboBox.Items.Count > 0)
                torokuEdabanComboBox.SelectedIndex = 0;
            else
                torokuEdabanComboBox.SelectedIndex = -1;

            setNmTextBox.Text = string.Empty;
            if (kihonKensaSetComboBox.Items.Count > 0)
                kihonKensaSetComboBox.SelectedIndex = 0;
            else
                kihonKensaSetComboBox.SelectedIndex = -1;
            setNaiyoTextBox.Text = string.Empty;
            if (suishitsuSyuruiComboBox.Items.Count > 0)
                suishitsuSyuruiComboBox.SelectedIndex = 0;
            else
                suishitsuSyuruiComboBox.SelectedIndex = -1;
            kensaRyokinTextBox.Text = string.Empty;
        }
        #endregion

        #region SetDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl(DispMode dispMode)
        {
            bool enabled = false;

            // 浄化槽番号
            jokasoCd1TextBox.ReadOnly = true;
            jokasoCd2TextBox.ReadOnly = true;
            jokasoCd3TextBox.ReadOnly = true;
            // 設置者名
            settisyaTextBox.ReadOnly = true;
            
            if (dispMode == DispMode.Init)
                enabled = true;

            // 登録枝番コンボボックス
            torokuEdabanComboBox.Enabled = enabled;
            // 検索ボタン
            kensakuButton.Enabled = enabled;
            // 新規ボタン
            shinkiButton.Enabled = enabled;

            enabled = !enabled;

            // クリアボタン
            clearButton.Enabled = enabled;
            // 浄化槽セット名称
            setNmTextBox.ReadOnly = !enabled;
            // 基本水質検査セットコンボボックス
            kihonKensaSetComboBox.Enabled = enabled;
            // 水質の種類コンボボックス
            suishitsuSyuruiComboBox.Enabled = enabled;

            // 検査料金合計
            setNaiyoTextBox.ReadOnly = true;
            // 検査セット内容ラベル
            // 20150201 sou Start
            //kensaRyokinTextBox.ReadOnly = true;
            kensaRyokinTextBox.ReadOnly = false;
            // 20150201 sou End

            //// 水質検査項目一覧
            if (dispMode == DispMode.Init)
            {
                kensaKomokuListDataGridView.ReadOnly = true;

                addCol.ReadOnly = true;
                kensaCdCol.ReadOnly = true;
                kensaNmCol.ReadOnly = true;
                kensaRyakushoCol.ReadOnly = true;
                kensaRyokinCol.ReadOnly = true;
                keiryoHohoGedanCol.ReadOnly = true;
                keiryoHohoJodanCol.ReadOnly = true;
                torokuKbnCol.ReadOnly = true;
                torokuKbnHideCol.ReadOnly = true;
            }
            else
            {
                kensaKomokuListDataGridView.ReadOnly = false;

                addCol.ReadOnly = false;
                kensaCdCol.ReadOnly = true;
                kensaNmCol.ReadOnly = true;
                kensaRyakushoCol.ReadOnly = true;
                kensaRyokinCol.ReadOnly = true;
                keiryoHohoGedanCol.ReadOnly = true;
                keiryoHohoJodanCol.ReadOnly = true;
                torokuKbnCol.ReadOnly = true;
                torokuKbnHideCol.ReadOnly = true;
            }

            // 登録ボタン
            if (dispMode == DispMode.Add)
                torokuButton.Visible = true;
            else
                torokuButton.Visible = false;

            // 変更ボタン
            // 削除ボタン
            if (dispMode == DispMode.Edit)
            {
                updateButton.Visible = true;
                deleteButton.Visible = true;
            }
            else
            {
                updateButton.Visible = false;
                deleteButton.Visible = false;
            }

            // 閉じるボタン
            closeButton.Visible = true;
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
        /// 2014/12/10　HieuNH　　　新規作成
        /// 2014/12/22　HieuNH　　　Fix bug
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            SetDisplayControl(_displayMode);

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.HokenjoCd = _hokenjoCd;
            alInput.TorokuNendo = _torokuNendo;
            alInput.Renban = _renban;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //// ADD HieuNH 2014/12/17 BEGIN
            // 設置者名 (4)
            if (alOutput.JokasoDaichoMstDT != null && alOutput.JokasoDaichoMstDT.Count > 0 && !alOutput.JokasoDaichoMstDT[0].IsJokasoSetchishaNmNull())
            {
                settisyaTextBox.Text = alOutput.JokasoDaichoMstDT[0].JokasoSetchishaNm;
                // 20150201 sou Start
                gyoshaCdTextBox.Text = alOutput.JokasoDaichoMstDT[0].JokasoSeikyuGyoshaCd;
                gyoshaNmTextBox.Text = alOutput.GyoshaMstDT[0].GyoshaNm;
                _kaiinKbn = KaiinUtility.KaiinHantei(gyoshaCdTextBox.Text).ToString();
                kaiinKbnNmTextBox.Text = (_kaiinKbn == "1" ? "会員" : "非会員");
                _tekiyoKbn = KaiinUtility.KaiinKakakuTekiyoHantei(gyoshaCdTextBox.Text).ToString();
                // 20150201 sou End
            }
            //// ADD HieuNH 2014/12/17 END
            //// ADD HieuNH 2014/12/22 BEGIN
            else
            {
                jokasoCd1TextBox.Text = string.IsNullOrEmpty(_hokenjoCd) ? string.Empty : _hokenjoCd;
                jokasoCd2TextBox.Text = string.IsNullOrEmpty(_torokuNendo) ? string.Empty : Utility.DateUtility.ConvertToWareki(_torokuNendo, "yy");
                jokasoCd3TextBox.Text = string.IsNullOrEmpty(_renban) ? string.Empty : _renban;
                kensakuButton.Enabled = false;
                shinkiButton.Enabled = false;
                return;
            }
            //// ADD HieuNH 2014/12/22 END

            //// ADD HieuNH 2014/12/22 BEGIN
            _daichoSuishitsuKensaKomokuMstDataTable = alOutput.DaichoSuishitsuKensaKomokuMstDataTable;
            //// ADD HieuNH 2014/12/22 END

            // 登録枝番(5)
            if (alOutput.DaichoSuishitsuKensaKomokuMstDataTable != null && alOutput.DaichoSuishitsuKensaKomokuMstDataTable.Count > 0)
            {
                DataColumn dispCol1 = alOutput.DaichoSuishitsuKensaKomokuMstDataTable.Columns.Add("DaichoKensaSetNmDisp", typeof(String));
                dispCol1.AllowDBNull = true;
                dispCol1.Unique = false;
                dispCol1.Expression = string.Format("{0}+':'+{1}", "DaichoKensaKomokuEdaban", "DaichoKensaSetNm");
                Utility.Utility.SetComboBoxList(torokuEdabanComboBox, alOutput.DaichoSuishitsuKensaKomokuMstDataTable, "DaichoKensaSetNmDisp", "DaichoKensaKomokuEdaban", true);

                //// DELETE HieuNH 2014/12/22 BEGIN
                //_daichoSuishitsuKensaKomokuMstDataTable = alOutput.DaichoSuishitsuKensaKomokuMstDataTable;
                //// DELETE HieuNH 2014/12/22 END

            //// ADD HieuNH 2014/12/22 BEGIN
            }
            else
            {
                torokuEdabanComboBox.DataSource = null;
            }
            //// ADD HieuNH 2014/12/22 BEGIN

                // 基本水質検査セット (10)
                if (alOutput.SuishitsuKensaSetMstDataTable != null && alOutput.SuishitsuKensaSetMstDataTable.Count > 0)
                {
                    DataColumn dispCol2 = alOutput.SuishitsuKensaSetMstDataTable.Columns.Add("SetNmDisp", typeof(String));
                    dispCol2.AllowDBNull = true;
                    dispCol2.Unique = false;
                    dispCol2.Expression = string.Format("{0}+':'+{1}", "SetCd", "SetNm");

                    Utility.Utility.SetComboBoxList(kihonKensaSetComboBox, alOutput.SuishitsuKensaSetMstDataTable, "SetNmDisp", "SetCd", true);
                }
                _suishitsuKensaSetMstDataTable = alOutput.SuishitsuKensaSetMstDataTable;

                // 基本水質検査セット (27)
                if (alOutput.SuishitsuMstDataTable != null && alOutput.SuishitsuMstDataTable.Count > 0)
                {
                    DataColumn dispCol3 = alOutput.SuishitsuMstDataTable.Columns.Add("SuishitsuNmDisp", typeof(String));
                    dispCol3.AllowDBNull = true;
                    dispCol3.Unique = false;
                    dispCol3.Expression = string.Format("{0}+':'+{1}", "SuishitsuCd", "SuishitsuNm");

                    Utility.Utility.SetComboBoxList(suishitsuSyuruiComboBox, alOutput.SuishitsuMstDataTable, "SuishitsuNmDisp", "SuishitsuCd", true);
                }

                //// DELETE HieuNH 2014/12/17 BEGIN
                //// 設置者名 (4)
                //if (alOutput.JokasoDaichoMstDT != null && alOutput.JokasoDaichoMstDT.Count > 0 && !alOutput.JokasoDaichoMstDT[0].IsJokasoSetchishaNmNull())
                //    settisyaTextBox.Text = alOutput.JokasoDaichoMstDT[0].JokasoSetchishaNm;
                //// DELETE HieuNH 2014/12/17 END

                //// DELETE HieuNH 2014/12/22 BEGIN
                //SetControlData();
                //// DELETE HieuNH 2014/12/22 END

                _suishitsuKensaKomokuInfoSearchDataTable.Clear();
                kensaKomokuListDataGridView.AutoGenerateColumns = false;
                kensaKomokuListDataGridView.DataSource = _suishitsuKensaKomokuInfoSearchDataTable;

                //// DELETE HieuNH 2014/12/17 BEGIN
                //kensakuButton.Enabled = true;
                //shinkiButton.Enabled = true;
                //// DELETE HieuNH 2014/12/17 END

                //// DELETE HieuNH 2014/12/22 BEGIN
                ////// ADD HieuNH 2014/12/17 BEGIN
                //this.ActiveControl = kensakuButton;
                //kensakuButton.Focus();
                ////// ADD HieUNh 2014/12/17 END
                //// DELETE HieuNH 2014/12/22 END

            //// DELETE HieuNH 2014/12/22 BEGIN
            //}
            //else
            //{
            //    _daichoSuishitsuKensaKomokuMstDataTable = alOutput.DaichoSuishitsuKensaKomokuMstDataTable;

            //    _suishitsuKensaSetMstDataTable = alOutput.SuishitsuKensaSetMstDataTable;

            //    //// DELETE HieuNH 2014/12/22 BEGIN
            //    //SetControlData();
            //    //// DELETE HieuNH 2014/12/22 END

            //    _suishitsuKensaKomokuInfoSearchDataTable.Clear();
            //    kensaKomokuListDataGridView.AutoGenerateColumns = false;
            //    kensaKomokuListDataGridView.DataSource = _suishitsuKensaKomokuInfoSearchDataTable;

            //    //// DELETE HieuNH 2014/12/22 BEGIN
            //    //kensakuButton.Enabled = false;
            //    //shinkiButton.Enabled = false;
            //    //// DELETE HieuNH 2014/12/22 END
            //}
            //// DELETE HieuNH 2014/12/22 END

            //// ADD HieuNH 2014/12/22 BEGIN
            InitScreen();
            //// ADD HieuNH 2014/12/22 END
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/19　HieuNH　　　Check null for data
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            if (KensakuCheck())
            {
                _suishitsuKensaKomokuInfoSearchDataTable.Clear();

                IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
                alInput.HokenjoCd = _hokenjoCd;
                alInput.TorokuNendo = _torokuNendo;
                alInput.Renban = _renban;
                alInput.DaichoKensaKomokuEdaban = torokuEdabanComboBox.SelectedValue.ToString();
                IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

                _suishitsuKensaKomokuInfoSearchDataTable = alOutput.SuishitsuKensaKomokuInfoSearchDataTable;
                kensaKomokuListDataGridView.AutoGenerateColumns = false;
                kensaKomokuListDataGridView.DataSource = _suishitsuKensaKomokuInfoSearchDataTable;

                _daichoSuishitsuKensaKomokuMstDataTableRakkan = alOutput.DaichoSuishitsuKensaKomokuMstDataTable;

                if (alOutput.DaichoSuishitsuKensaKomokuMstDataTable != null && alOutput.DaichoSuishitsuKensaKomokuMstDataTable.Count > 0)
                {
                    //// MODIFY HieuNH 2014/12/19 BEGIN
                    //kihonKensaSetComboBox.SelectedValue = alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuSetCd;
                    //suishitsuSyuruiComboBox.SelectedValue = alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuSuishitsuCd;
                    //setNmTextBox.Text = alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaSetNm;

                    kihonKensaSetComboBox.SelectedValue = alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].IsDaichoKensaKomokuSetCdNull() ? string.Empty : alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuSetCd;
                    suishitsuSyuruiComboBox.SelectedValue = alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].IsDaichoKensaKomokuSuishitsuCdNull() ? string.Empty : alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuSuishitsuCd;
                    setNmTextBox.Text = alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].IsDaichoKensaSetNmNull() ? string.Empty : alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaSetNm;
                    //// MODIFY HieuNH 2014/12/19 END
                }
                _displayMode = DispMode.Edit;
                SetDisplayControl(_displayMode);

                string setNm, komokuNm;

                //// MODIFY HieuNH 2014/12/19 BEGIN
                //Utility.KeiryoShomeiUtility.GetSuishitsuSetKomokuNm(kihonKensaSetComboBox.SelectedValue.ToString(), out setNm, out komokuNm);
                Utility.KeiryoShomeiUtility.GetSuishitsuSetKomokuNm(kihonKensaSetComboBox.SelectedValue == null? string.Empty: kihonKensaSetComboBox.SelectedValue.ToString(), out setNm, out komokuNm);
                //// MODIFY HieuNH 2014/12/19 END

                setNaiyoTextBox.Text = komokuNm;

                ChangeTorokuKbn();

                // 20150201 sou Start
                //CalRyokin();
                kensaRyokinTextBox.Text = alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].IsDaichoKensaKomokuKensaAmtNull() ? string.Empty : alOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuKensaAmt.ToString("N0");
                // 20150201 sou End
            }
        }
        #endregion

        #region DoPush
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoPush
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/17　HieuNH　　　Change PushBtn -> ShinkiBtn
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoPush()
        {
            if (InsertCheck())
            {
                //// MODIFY HieuNH 2014/12/17 BEGIN
                //IPushBtnClickALOutput alOutput = new PushBtnClickApplicationLogic().Execute(new PushBtnClickALInput());
                IShinkiBtnClickALOutput alOutput = new ShinkiBtnClickApplicationLogic().Execute(new ShinkiBtnClickALInput());
                //// MODIFY HieuNH 2014/12/17 END
                _suishitsuKensaKomokuInfoSearchDataTable = alOutput.SuishitsuKensaKomokuInfoSearchDataTable;

                kensaKomokuListDataGridView.AutoGenerateColumns = false;
                kensaKomokuListDataGridView.DataSource = _suishitsuKensaKomokuInfoSearchDataTable;

                _displayMode = DispMode.Add;
                SetDisplayControl(_displayMode);
            }
        }
        #endregion

        #region InitScreen
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitScreen
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/22　HieuNH　　　Fix bug
        /// 2014/12/23  小松        枝番がMAX(9)の場合は、新規ボタンは非活性
        /// 　　　　　　　　　　　　新規の場合は、新規ボタンにフォーカス設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InitScreen()
        {
            if(_suishitsuKensaKomokuInfoSearchDataTable != null)
                _suishitsuKensaKomokuInfoSearchDataTable.Clear();
            _displayMode = DispMode.Init;

            SetControlData();
            SetDisplayControl(_displayMode);

            //// MODIFY HieuNH 2014/12/22 BEGIN
            //this.ActiveControl = kensakuButton;
            //kensakuButton.Focus();

            if (_daichoSuishitsuKensaKomokuMstDataTable != null && _daichoSuishitsuKensaKomokuMstDataTable.Count > 0)
            {
                kensakuButton.Enabled = true;
                this.ActiveControl = kensakuButton;
                kensakuButton.Focus();

                // 枝番がMAX(9)の場合は、新規ボタンは非活性
                object maxDaichoKensaKomokuEdaban = _daichoSuishitsuKensaKomokuMstDataTable.Compute("MAX(DaichoKensaKomokuEdaban)", null);
                if (maxDaichoKensaKomokuEdaban != System.DBNull.Value && maxDaichoKensaKomokuEdaban != null)
                {
                    if (maxDaichoKensaKomokuEdaban.ToString() == "9")
                    {
                        // 非活性
                        shinkiButton.Enabled = false;
                    }
                }
            }
            else
            {
                kensakuButton.Enabled = false;
                // 新規の場合は、新規ボタンにセットフォーカス
                this.ActiveControl = shinkiButton;
                shinkiButton.Focus();
            }
            //// MODIFY HieuNH 2014/12/22 END
        }
        #endregion

        #region KensakuCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KensakuCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool KensakuCheck()
        {
            if (torokuEdabanComboBox.SelectedIndex == -1 || torokuEdabanComboBox.SelectedIndex == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "登録枝番を選択して下さい。");
                return false;
            }
            return true;
        }
        #endregion

        #region InsertCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool InsertCheck()
        {
            if (_daichoSuishitsuKensaKomokuMstDataTable.Count == 10)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "この浄化槽ではこれ以上、検査項目セットを新規登録できません。");
                return false;
            }
            return true;
        }
        #endregion

        #region ChangeTorokuKbn
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeTorokuKbn
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/19　HieuNH　　　Check kihonKensaSetComboBox.SelectedValue null
        /// 2014/12/22　HieuNH　　　Fix bug
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeTorokuKbn()
        {
            foreach (DataGridViewRow row in kensaKomokuListDataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.Cells[torokuKbnHideCol.Index].Value = "2";
                row.Cells[torokuKbnCol.Index].Value = "単独";
                addCol.ReadOnly = false;
            }

            kensaKomokuListDataGridView.EndEdit();

            IChangeTorokuKbnALInput alInput = new ChangeTorokuKbnALInput();
            alInput.SuishitsuKensaKomokuInfoSearchDataTable = _suishitsuKensaKomokuInfoSearchDataTable;
            //// MODIFY HieuNH 2014/12/19 BEGIN
            //alInput.SetKomokuSetCd = kihonKensaSetComboBox.SelectedValue.ToString();
            alInput.SetKomokuSetCd = kihonKensaSetComboBox.SelectedValue == null ? string.Empty : kihonKensaSetComboBox.SelectedValue.ToString();
            //// MODIFY HieuNH 2014/12/19 END
            IChangeTorokuKbnALOutput alOutput = new ChangeTorokuKbnApplicationLogic().Execute(alInput);

            _suishitsuKensaKomokuInfoSearchDataTable = alOutput.SuishitsuKensaKomokuInfoSearchDataTable;
            kensaKomokuListDataGridView.AutoGenerateColumns = false;
            kensaKomokuListDataGridView.DataSource = _suishitsuKensaKomokuInfoSearchDataTable;

            foreach (DataGridViewRow row in kensaKomokuListDataGridView.Rows)
            {
                if (row.Cells[colorFlg.Index].Value != null && row.Cells[colorFlg.Index].Value.ToString().Equals("1"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.ReadOnly = true;
                }
                //// ADD HieuNH 2014/12/22 BEGIN
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.ReadOnly = false;
                }
                //// ADD HieuNH 2014/12/22 END

            }

            kensaKomokuListDataGridView.Refresh();
        }
        #endregion

        #region CalRyokin
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CalRyokin
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/19　HieuNH　　　Check kihonKensaSetComboBox.SelectedValue null
        /// 2015/02/01  宗          会員、非会員別の項目を取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CalRyokin()
        {
            // 20150201 sou Start
            //decimal hikaiinRyokin = 0;
            decimal setRyokin = 0;
            // 20150201 sou End
            // Get HikaiinRyokin
            if (_suishitsuKensaSetMstDataTable != null && _suishitsuKensaSetMstDataTable.Count > 0)
            {
                //// MODIFY HieuNH 2014/12/19 BEGIN
                //SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstRow[] rows = (SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstRow[])_suishitsuKensaSetMstDataTable.Select("SetCd = '" + kihonKensaSetComboBox.SelectedValue.ToString() + "'");
                string setCd = kihonKensaSetComboBox.SelectedValue == null ? string.Empty : kihonKensaSetComboBox.SelectedValue.ToString();
                SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstRow[] rows = (SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstRow[])_suishitsuKensaSetMstDataTable.Select("SetCd = '" + setCd + "'");
                //// MODIFY HieuNH 2014/12/19 END
                if (rows.Length > 0)
                {
                    SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstRow selectedRow = rows[0];
                    // 20150201 sou Start
                    //hikaiinRyokin = selectedRow.SetHikaiinRyoukin;
                    if (_tekiyoKbn == "1")
                    {
                        setRyokin = selectedRow.SetRyoukin;
                    }
                    else
                    {
                        setRyokin = selectedRow.SetHikaiinRyoukin;
                    }
                    // 20150201 sou End
                }
            }

            decimal total = 0;

            foreach (DataGridViewRow row in kensaKomokuListDataGridView.Rows)
            {
                if (row.Cells[addCol.Index].Value.ToString().Equals("1") && row.Cells[torokuKbnHideCol.Index].Value.Equals("2"))
                {
                    total = total + decimal.Parse(row.Cells[kensaRyokinCol.Index].Value.ToString());
                }
            }

            // 20150201 sou Start
            //kensaRyokinTextBox.Text = (total + hikaiinRyokin).ToString("N0");
            kensaRyokinTextBox.Text = (total + setRyokin).ToString("N0");
            // 20150201 sou End
        }
        #endregion

        #region UpdateCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/19　HieuNH　　　Remove check kihonKensaSetComboBox (v1.02)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UpdateCheck()
        {
            bool isValid = false;
            StringBuilder errMsg = new StringBuilder();

            if (string.IsNullOrEmpty(setNmTextBox.Text))
                errMsg.AppendLine("浄化槽セット名称を入力して下さい。");
            //// DELETE HieuNH 2014/12/19 BEGIN
            //if (kihonKensaSetComboBox.SelectedIndex == -1 || kihonKensaSetComboBox.SelectedIndex == 0)
            //    errMsg.AppendLine("基本水質検査セットを選択して下さい。");
            //// DELETE HieuNH 2014/12/19 END
            if (suishitsuSyuruiComboBox.SelectedIndex == -1 || suishitsuSyuruiComboBox.SelectedIndex == 0)
                errMsg.AppendLine("水質の種類を選択して下さい。");

            foreach (DataGridViewRow row in kensaKomokuListDataGridView.Rows)
            {
                if (row.Cells[addCol.Index].Value.ToString().Equals("1") )
                {
                    isValid = true;
                    break;
                }
            }
            if(!isValid)
                errMsg.AppendLine("水質検査項目が1件も選択されていません。");

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
