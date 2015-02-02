using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaKekkaInputShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.KensaKekka;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Control;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputShosaiForm
    /// <summary>
    /// 検査結果入力（詳細）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/23  AnhNV        新規作成
    /// 2015/01/24  小松　　　　所見自動挿入追加
    /// 2015/01/26　小松　　　　単位装置選択処理追加
    /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
    /// 2015/01/29  小松　　    要望対応:#8559(検査結果値の評価、表示等の制御)
    /// 2015/01/29  habu　　    要望対応:#8500(行政報告の自動判定)
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKekkaInputShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Update,
            Display,
        }

        #endregion

        #region 定義(private)

        /// <summary>
        /// 1:○
        /// </summary>
        private const string MARU = "○";
        /// <summary>
        /// 2:△
        /// </summary>
        private const string SANKAKU = "△";
        /// <summary>
        /// 3:×
        /// </summary>
        private const string BATSU = "×";
        /// <summary>
        /// 4:－
        /// </summary>
        private const string HIKU = "－";
        /// <summary>
        /// 測定不能
        /// </summary>
        private const string SOKUTEI = "測定不能";

        // 所見結果コントロール表示域用
        #region 所見結果コントロール表示域用
        // 所見結果コントロール表示用の幅
        private const int SHOKEN_KEKKA_WIDTH = 1127;
        // 所見結果コントロール表示用の高さ
        private const int SHOKEN_KEKKA_HEIGHT = 20;
        // 所見結果コントロール表示用のX座標
        private const int SHOKEN_KEKKA_LOCATION_X = 12;
        // 所見結果コントロール表示用のY座標オフセット
        private const int SHOKEN_KEKKA_LOCATION_Y_MARGIN = 4;
        // パネルの幅
        private const int SHOKEN_KEKKA_PANEL_WIDTH = SHOKEN_KEKKA_WIDTH + 12 + 1;
        // パネルの高さ（初期）
        private const int SHOKEN_KEKKA_PANEL_HEIGHT_INIT = 610;
        // 所見結果の最大行数
        private const int SHOKEN_KEKKA_MAX_COUNT = 30;
        #endregion

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// Display mode
        /// </summary>
        public DispMode _dispMode;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// Form load completed?
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        private string _kensaIraiHoteiKbn;
        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        private string _kensaIraiHokenjoCd;
        /// <summary>
        /// 検査依頼年度 
        /// </summary>
        private string _kensaIraiNendo;
        /// <summary>
        /// 検査依頼連番
        /// </summary>
        private string _kensaIraiRenban;
        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        private string _mochikomiDt;

        /// <summary>
        /// Value of 判定(34)(ロード時の自動判定結果)
        /// </summary>
        private string _hanteiKekka;

        /// <summary>
        /// (ロード時の行政報告判定)
        /// </summary>
        private string _gyoseiHokokuHantei;

        #region Display tables
        /// <summary>
        /// CheckList75DataTable
        /// </summary>
        private GaikanKensaKekkaTblDataSet.CheckList75DataTable _cl75Table;

        ///// <summary>
        ///// KensaKekkaFooterDataTable
        ///// </summary>
        //private GaikanKensaKekkaTblDataSet.KensaKekkaFooterDataTable _footerTable;

        /// <summary>
        /// Display table
        /// </summary>
        private GaikanKensaKekkaTblDataSet.KensaKekkaInputShosaiDataTable _dispTable;

        /// <summary>
        /// Kensa textbox/Label dict.
        /// </summary>
        private Dictionary<ZTextBox, Label> _kensaTextBoxDict = new Dictionary<ZTextBox, Label>();

        /// <summary>
        /// Kensa combobox/Label dict.
        /// </summary>
        private Dictionary<ComboBox, Label> _kensaCbDict = new Dictionary<ComboBox, Label>();

        /// <summary>
        /// TextBox/水質検査区分 dict.
        /// </summary>
        private Dictionary<ZTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn> _txtKbnDict
            = new Dictionary<ZTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn>();

        /// <summary>
        /// ComboBox/水質検査区分 dict.
        /// </summary>
        private Dictionary<ComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn> _cbKbnDict
            = new Dictionary<ComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn>();

        /// <summary>
        /// 所見結果
        /// </summary>
        private List<SyokenKekkaControl> _syokenKekkaControl;

        /// <summary>
        /// チェック項目
        /// </summary>
        private List<CheckItemControl> _checkItemControl;

        /// <summary>
        /// KakoKensaJohoDataTable
        /// </summary>
        private GaikanKensaKekkaTblDataSet.KakoKensaJohoDataTable _kakoKensaJohoTable;
        #endregion

        #region Update tables
        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        private KensaIraiTblDataSet.KensaIraiTblDataTable _kensaIraiTable;

        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        private KensaKekkaTblDataSet.KensaKekkaTblDataTable _kensaKekkaTable;

        /// <summary>
        /// 外観検査結果テーブル
        /// </summary>
        private GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable _gaikanKekkaTable;

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        private SaiSaisuiTblDataSet.SaiSaisuiTblDataTable _saisuiTable;

        /// <summary>
        /// 浄化槽定型メモテーブル
        /// </summary>
        private JokasoMemoTblDataSet.JokasoMemoTblDataTable _jokasoMemoTable;

        /// <summary>
        /// 所見結果テーブル
        /// </summary>
        private GaikanKensaKekkaTblDataSet.ShokenKekkaListDataTable _shokenKekkaList { get; set; }

        /// <summary>
        /// 所見結果補足テーブル
        /// </summary>
        private GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListDataTable _shokenKekkaHosokuList { get; set; }

        #endregion

        // 所見置換文字列
        private string _shokenReplaceStr = string.Empty;

        #endregion

        #region to be removed
        //#region コンストラクタ
        //////////////////////////////////////////////////////////////////////////////
        ////  コンストラクタ名 ： KensaKekkaInputShosaiForm
        ///// <summary>
        ///// コンストラクタ
        ///// </summary>
        ///// <remarks>
        ///// 
        ///// </remarks>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/29  小松        新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //public KensaKekkaInputShosaiForm()
        //{
        //    InitializeComponent();
        //    SetControlDomain();

        //    RegisterEvents();
        //}
        //#endregion
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKekkaInputShosaiForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="kensaIraiHokenjoCd"></param>
        /// <param name="kensaIraiNendo"></param>
        /// <param name="kensaIraiRenban"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKekkaInputShosaiForm
            (
                string kensaIraiHoteiKbn,
                string kensaIraiHokenjoCd,
                string kensaIraiNendo,
                string kensaIraiRenban
            )
        {
            InitializeComponent();
            SetControlDomain();

            // Params
            this._kensaIraiHoteiKbn = kensaIraiHoteiKbn;
            this._kensaIraiHokenjoCd = kensaIraiHokenjoCd;
            this._kensaIraiNendo = kensaIraiNendo;
            this._kensaIraiRenban = kensaIraiRenban;

            RegisterEvents();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKekkaInputShosaiForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="kensaIraiHokenjoCd"></param>
        /// <param name="kensaIraiNendo"></param>
        /// <param name="kensaIraiRenban"></param>
        /// <param name="mochikomiDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKekkaInputShosaiForm
            (
                string kensaIraiHoteiKbn,
                string kensaIraiHokenjoCd,
                string kensaIraiNendo,
                string kensaIraiRenban,
                string mochikomiDt
            )
        {
            InitializeComponent();
            SetControlDomain();

            // Params
            this._kensaIraiHoteiKbn = kensaIraiHoteiKbn;
            this._kensaIraiHokenjoCd = kensaIraiHokenjoCd;
            this._kensaIraiNendo = kensaIraiNendo;
            this._kensaIraiRenban = kensaIraiRenban;
            this._mochikomiDt = mochikomiDt;

            RegisterEvents();
        }
        #endregion

        #region イベント

        #region KensaKekkaInputShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaInputShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23　AnhNV　　    新規作成
        /// 2015/01/26　小松　　　　単位装置選択処理追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaInputShosaiForm_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'kensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTbl' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.kensaIraiKanrenFileTblTableAdapter.Fill(this.kensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTbl);
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 置換対象とする文字列「（大分類）」取得
                _shokenReplaceStr = Common.Common.GetConstNm(Utility.Constants.ConstKbnConstanst.CONST_KBN_077, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                // Load default value
                DoFormLoad();

                // Load OK
                this._isLoad = true;

                // Set focus
                if (_dispMode == DispMode.Update)
                {
                    // Focus to メモ確認(16)
                    memoKakuninCheckBox.Focus();
                }
                else
                {
                    // Focus to ブロワ１(40)
                    burowa1TextBox.Focus();
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

        #region KensaKekkaInputShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaInputShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaInputShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        entryButton.Focus();
                        entryButton.PerformClick();
                        break;
                    case Keys.F6:
                        kekkashoDispButton.Focus();
                        kekkashoDispButton.PerformClick();
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

        #region kensaFinishButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaFinishButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23　AnhNV　　    新規作成
        /// 2015/01/24  小松　　　　所見自動挿入に伴い、完了時に所見結果件数のチェックなどを行うように修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaFinishButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 入力内容チェック
                if (!InputCheck()) return;
                // メモ確認チェック
                if (!MemoConfirmCheck()) return;
                // 検査完了内容チェック
                if (!KensaCompleteCheck()) return;
                // 検査完了警告確認
                if (!KensaCompleteConfirm()) return;
                // 検査完了更新確認
                if (!UpdateConfirmForKensaComplete()) return;

                // Get system date
                DateTime now = Common.Common.GetCurrentTimestamp();
                // ログインユーザー名
                string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                // クライアント端末名
                string host = Dns.GetHostName();

                // Do update (2) in design
                IKensaFinishBtnClickALInput alInput = new KensaFinishBtnClickALInput();
                alInput.SystemDt = now;
                alInput.KensaIraiTblDataTable = CreateKensaIraiTblDataTableUpdate(_kensaIraiTable, user, host);
                alInput.KensaIraiTblDataTable.Merge(CreateKensaIraiTblDataTableForUpdateStatus(_kensaIraiTable));
                alInput.KensaKekkaTblDataTable = CreateKensaKekkaTblDataTableInsert(now, user, host);
                alInput.SaiSaisuiTblDataTable = CreateSaiSaisuiTblDataTableInsert(now, user, host);
                alInput.GaikanKensaKekkaTblDataTable = CreateGaikanKensaKekkaTblDataTableInsert(now, user, host);
                alInput.JokasoMemoTblDataTable = CreateJokasoMemoTblDataTableInsert(now, user, host);
                // Optimistic lock checking tables
                alInput.KensaKekkaRakTblDataTable = _kensaKekkaTable;
                alInput.GaikanKensaKekkaRakTblDataTable = _gaikanKekkaTable;
                alInput.SaiSaisuiRakTblDataTable = _saisuiTable;
                alInput.JokasoMemoRakTblDataTable = _jokasoMemoTable;
                new KensaFinishBtnClickApplicationLogic().Execute(alInput);

                // Close this screen
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

        #region suishitsuKensaSyokenButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaSyokenButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaSyokenButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.ShokenShiteki, "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region kensaComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaComboBox_SelectedIndexChanged
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
        private void kensaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_isLoad) return;

                ComboBox targetComboBox = sender as ComboBox;
                string checkNumber = null != targetComboBox.SelectedValue ? targetComboBox.SelectedValue.ToString() : string.Empty;

                SetBikoText(checkNumber, _kensaCbDict[targetComboBox], _cbKbnDict[targetComboBox]);
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

        #region sokuteiFunoComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sokuteiFunoComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29　AnhNV　　    新規作成
        /// 2015/01/29  小松　　　　BOD、塩化物イオン、ATUBODは検査員は触らないので非活性
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void sokuteiFunoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_isLoad) return;

                if (sokuteiFunoComboBox.SelectedItem.ToString() == SOKUTEI)
                {
                    // pH(49)
                    pHTextBox.Text = string.Empty;
                    // pH評価(50)
                    pHHyokaLabel.Text = HIKU;
                    // 溶存酸素量From(51)
                    yozonSansoRyo1TextBox.Text = string.Empty;
                    // 溶存酸素量To(52)
                    yozonSansoRyo2TextBox.Text = string.Empty;
                    // 溶存酸素量評価(53)
                    yozonSansoRyoHyokaLabel.Text = HIKU;
                    // ２次透視度（度）(54)
                    nijiToshidoTextBox.Text = string.Empty;
                    // ２次透視度（数値範囲）(55)
                    nijiToshidoComboBox.SelectedIndex = 0;
                    nijiToshidoComboBox.Enabled = false;
                    // ２次透視度評価(56)
                    nijiToshidoHyokaLabel.Text = HIKU;
                    // 透視度（度）(57)
                    toshidoTextBox.Text = string.Empty;
                    // 透視度（数値範囲）(58)
                    toshidoComboBox.SelectedIndex = 0;
                    toshidoComboBox.Enabled = false;
                    // 透視度評価(59)
                    toshidoHyokaLabel.Text = HIKU;
                    // 残留塩素(60)
                    zanryuensoTextBox.Text = string.Empty;
                    // 残留塩素評価(61)
                    zanryuensoHyokaLabel.Text = HIKU;
                    // ＢＯＤ(62)
                    BODTextBox.Text = string.Empty;
                    // ＢＯＤ（数値範囲）(63)
                    BODComboBox.SelectedIndex = 0;
                    BODComboBox.Enabled = false;
                    // ＢＯＤ評価(64)
                    BODHyokaLabel.Text = HIKU;
                    // 塩化物イオン(65)
                    enkabutsuIonTextBox.Text = string.Empty;
                    // 塩化物イオン（数値範囲）(66)
                    enkabutsuIonComboBox.SelectedIndex = 0;
                    enkabutsuIonComboBox.Enabled = false;
                    // 塩化物イオン評価(67)
                    enkabutsuIonHyokaLabel.Text = HIKU;
                    // 汚泥沈殿率(68)
                    odeiChindenRitsuTextBox.Text = string.Empty;
                    // 汚泥沈殿率（数値範囲）(69)
                    odeiChindenRitsuComboBox.SelectedIndex = 0;
                    odeiChindenRitsuComboBox.Enabled = false;
                    // 汚泥沈殿率評価(70)
                    odeiChindenRitsuHyokaLabel.Text = HIKU;
                    // MLSS(71)
                    MLSSTextBox.Text = string.Empty;

                    // v1.09 ADD Start
                    // ATUBOD
                    ATUBODTextBox.Text = string.Empty;
                    ATUBODComboBox.SelectedIndex = 0;
                    ATUBODComboBox.Enabled = false;
                    //ATUBODHyokaLabel.Text = HIKU;
                    // v1.09 ADD End

                    // pH(49)
                    pHTextBox.Enabled = false;
                    // 溶存酸素量From(51)
                    yozonSansoRyo1TextBox.Enabled = false;
                    // 溶存酸素量To(52)
                    yozonSansoRyo2TextBox.Enabled = false;
                    // ２次透視度（度）(54)
                    nijiToshidoTextBox.Enabled = false;
                    // 透視度（度）(57)
                    toshidoTextBox.Enabled = false;
                    // 残留塩素(60)
                    zanryuensoTextBox.Enabled = false;
                    // 汚泥沈殿率(68)
                    odeiChindenRitsuTextBox.Enabled = false;
                    // MLSS(71)
                    MLSSTextBox.Enabled = false;
                }
                else
                {
                    // pH(49)
                    // ２次透視度（数値範囲）(55)
                    nijiToshidoComboBox.Enabled = true;
                    // 透視度（数値範囲）(58)
                    toshidoComboBox.Enabled = true;
                    //// ＢＯＤ（数値範囲）(63)
                    //BODComboBox.Enabled = true;
                    //// 塩化物イオン（数値範囲）(66)
                    //enkabutsuIonComboBox.Enabled = true;
                    // 汚泥沈殿率（数値範囲）(69)
                    odeiChindenRitsuComboBox.Enabled = true;

                    //// v1.09 ADD Start
                    //// ATUBOD
                    //ATUBODComboBox.Enabled = true;
                    //// v1.09 ADD End

                    // pH(49)
                    pHTextBox.Enabled = true;
                    // 溶存酸素量From(51)
                    yozonSansoRyo1TextBox.Enabled = true;
                    // 溶存酸素量To(52)
                    yozonSansoRyo2TextBox.Enabled = true;
                    // ２次透視度（度）(54)
                    nijiToshidoTextBox.Enabled = true;
                    // 透視度（度）(57)
                    toshidoTextBox.Enabled = true;
                    // 残留塩素(60)
                    zanryuensoTextBox.Enabled = true;
                    // 汚泥沈殿率(68)
                    odeiChindenRitsuTextBox.Enabled = true;
                    // MLSS(71)
                    MLSSTextBox.Enabled = true;

                    // pH評価(50)
                    pHHyokaLabel.Text = string.Empty;
                    // 溶存酸素量評価(53)
                    yozonSansoRyoHyokaLabel.Text = string.Empty;
                    // ２次透視度評価(56)
                    nijiToshidoHyokaLabel.Text = string.Empty;
                    // 透視度評価(59)
                    toshidoHyokaLabel.Text = string.Empty;
                    // 残留塩素評価(61)
                    zanryuensoHyokaLabel.Text = string.Empty;
                    // ＢＯＤ評価(64)
                    BODHyokaLabel.Text = string.Empty;
                    // 塩化物イオン評価(67)
                    enkabutsuIonHyokaLabel.Text = string.Empty;
                    // 汚泥沈殿率評価(70)
                    odeiChindenRitsuHyokaLabel.Text = string.Empty;
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

        #region saiSokuteiFunoComboBox_SelectedIndexChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saiSokuteiFunoComboBox_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　AnhNV　　    新規作成
        /// 2015/01/29  小松　　　　BOD、塩化物イオン、ATUBODは検査員は触らないので非活性
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saiSokuteiFunoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_isLoad) return;

                if (saiSokuteiFunoComboBox.SelectedItem.ToString() == SOKUTEI)
                {
                    // pH(49)
                    saiPHTextBox.Text = string.Empty;
                    // pH評価(50)
                    saiPHHyokaLabel.Text = HIKU;
                    // 溶存酸素量From(51)
                    saiYozonSansoRyo1TextBox.Text = string.Empty;
                    // 溶存酸素量To(52)
                    saiYozonSansoRyo2TextBox.Text = string.Empty;
                    // 溶存酸素量評価(53)
                    saiYozonSansoRyoHyokaLabel.Text = HIKU;
                    // ２次透視度（度）(54)
                    saiNijiToshidoTextBox.Text = string.Empty;
                    // ２次透視度（数値範囲）(55)
                    saiNijiToshidoComboBox.SelectedIndex = 0;
                    saiNijiToshidoComboBox.Enabled = false;
                    // ２次透視度評価(56)
                    saiNijiToshidoHyokaLabel.Text = HIKU;
                    // 透視度（度）(57)
                    saiToshidoTextBox.Text = string.Empty;
                    // 透視度（数値範囲）(58)
                    saiToshidoComboBox.SelectedIndex = 0;
                    saiToshidoComboBox.Enabled = false;
                    // 透視度評価(59)
                    saiToshidoHyokaLabel.Text = HIKU;
                    // 残留塩素(60)
                    saiZanryuensoTextBox.Text = string.Empty;
                    // 残留塩素評価(61)
                    saiZanryuensoHyokaLabel.Text = HIKU;
                    // ＢＯＤ(62)
                    saiBODTextBox.Text = string.Empty;
                    // ＢＯＤ（数値範囲）(63)
                    saiBODComboBox.SelectedIndex = 0;
                    saiBODComboBox.Enabled = false;
                    // ＢＯＤ評価(64)
                    saiBODHyokaLabel.Text = HIKU;
                    // 塩化物イオン(65)
                    saiEnkabutsuIonTextBox.Text = string.Empty;
                    // 塩化物イオン（数値範囲）(66)
                    saiEnkabutsuIonComboBox.SelectedIndex = 0;
                    saiEnkabutsuIonComboBox.Enabled = false;
                    // 塩化物イオン評価(67)
                    saiEnkabutsuIonHyokaLabel.Text = HIKU;
                    // 汚泥沈殿率(68)
                    saiOdeiChindenRitsuTextBox.Text = string.Empty;
                    // 汚泥沈殿率（数値範囲）(69)
                    saiOdeiChindenRitsuComboBox.SelectedIndex = 0;
                    saiOdeiChindenRitsuComboBox.Enabled = false;
                    // 汚泥沈殿率評価(70)
                    saiOdeiChindenRitsuHyokaLabel.Text = HIKU;
                    // MLSS(71)
                    saiMLSSTextBox.Text = string.Empty;

                    // v1.09 ADD Start
                    // ATUBOD
                    saiATUBODTextBox.Text = string.Empty;
                    saiATUBODComboBox.SelectedIndex = 0;
                    saiATUBODComboBox.Enabled = false;
                    //saiATUBODHyokaLabel.Text = HIKU;
                    // v1.09 ADD End

                    // pH(49)
                    saiPHTextBox.Enabled = false;
                    // 溶存酸素量From(51)
                    saiYozonSansoRyo1TextBox.Enabled = false;
                    // 溶存酸素量To(52)
                    saiYozonSansoRyo2TextBox.Enabled = false;
                    // ２次透視度（度）(54)
                    saiNijiToshidoTextBox.Enabled = false;
                    // 透視度（度）(57)
                    saiToshidoTextBox.Enabled = false;
                    // 残留塩素(60)
                    saiZanryuensoTextBox.Enabled = false;
                    // 汚泥沈殿率(68)
                    saiOdeiChindenRitsuTextBox.Enabled = false;
                    // MLSS(71)
                    saiMLSSTextBox.Enabled = false;
                }
                else
                {
                    // ２次透視度（数値範囲）(55)
                    saiNijiToshidoComboBox.Enabled = true;
                    // 透視度（数値範囲）(58)
                    saiToshidoComboBox.Enabled = true;
                    //// ＢＯＤ（数値範囲）(63)
                    //saiBODComboBox.Enabled = true;
                    //// 塩化物イオン（数値範囲）(66)
                    //saiEnkabutsuIonComboBox.Enabled = true;
                    // 汚泥沈殿率（数値範囲）(69)
                    saiOdeiChindenRitsuComboBox.Enabled = true;

                    //// v1.09 ADD Start
                    //// ATUBOD
                    //saiATUBODComboBox.Enabled = true;
                    //// v1.09 ADD End

                    // pH(49)
                    saiPHTextBox.Enabled = true;
                    // 溶存酸素量From(51)
                    saiYozonSansoRyo1TextBox.Enabled = true;
                    // 溶存酸素量To(52)
                    saiYozonSansoRyo2TextBox.Enabled = true;
                    // ２次透視度（度）(54)
                    saiNijiToshidoTextBox.Enabled = true;
                    // 透視度（度）(57)
                    saiToshidoTextBox.Enabled = true;
                    // 残留塩素(60)
                    saiZanryuensoTextBox.Enabled = true;
                    // 汚泥沈殿率(68)
                    saiOdeiChindenRitsuTextBox.Enabled = true;
                    // MLSS(71)
                    saiMLSSTextBox.Enabled = true;

                    // pH評価(50)
                    saiPHHyokaLabel.Text = string.Empty;
                    // 溶存酸素量評価(53)
                    saiYozonSansoRyoHyokaLabel.Text = string.Empty;
                    // ２次透視度評価(56)
                    saiNijiToshidoHyokaLabel.Text = string.Empty;
                    // 透視度評価(59)
                    saiToshidoHyokaLabel.Text = string.Empty;
                    // 残留塩素評価(61)
                    saiZanryuensoHyokaLabel.Text = string.Empty;
                    // ＢＯＤ評価(64)
                    saiBODHyokaLabel.Text = string.Empty;
                    // 塩化物イオン評価(67)
                    saiEnkabutsuIonHyokaLabel.Text = string.Empty;
                    // 汚泥沈殿率評価(70)
                    saiOdeiChindenRitsuHyokaLabel.Text = string.Empty;
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
        /// 2014/10/30　AnhNV　　    新規作成
        /// 2015/01/24  小松　　　　所見自動挿入追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 入力内容チェック
                if (!InputCheck()) return;

                // 水質タブ要素範囲チェック
                if (!CheckForTab27()) return;

                // 検査結果更新確認
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されている内容で検査結果情報を更新します。よろしいですか？") == DialogResult.Yes)
                {
                    // Get システム日付
                    DateTime now = Common.Common.GetCurrentTimestamp();
                    // ログインユーザー名
                    string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    // クライアント端末名
                    string host = Dns.GetHostName();

                    // Do update (1) in design
                    IEntryBtnClickALInput alInput = new EntryBtnClickALInput();
                    alInput.SystemDt = now;
                    alInput.KensaIraiTblDataTable = CreateKensaIraiTblDataTableUpdate(_kensaIraiTable, user, host);
                    //alInput.KensaIraiTblDataTable.Merge(CreateKensaIraiTblDataTableForUpdateStatus(_kensaIraiTable));
                    alInput.KensaKekkaTblDataTable = CreateKensaKekkaTblDataTableInsert(now, user, host);
                    alInput.SaiSaisuiTblDataTable = CreateSaiSaisuiTblDataTableInsert(now, user, host);
                    alInput.GaikanKensaKekkaTblDataTable = CreateGaikanKensaKekkaTblDataTableInsert(now, user, host);
                    alInput.JokasoMemoTblDataTable = CreateJokasoMemoTblDataTableInsert(now, user, host);

                    // 所見結果、所見結果補足テーブルの両方のデータを作成
                    // 所見結果
                    ShokenKekkaTblDataSet.ShokenKekkaTblDataTable shokenDT = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();
                    // 所見結果補足
                    ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable hosokuDT = new ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable();
                    CreateShokenKekkaDataTableInsert(ref shokenDT, ref hosokuDT, now, user, host);
                    alInput.ShokenKekkaDT = shokenDT;
                    alInput.ShokenKekkaHosokuDT = hosokuDT;

                    // Optimistic lock checking tables
                    alInput.KensaKekkaRakTblDataTable = _kensaKekkaTable;
                    alInput.GaikanKensaKekkaRakTblDataTable = _gaikanKekkaTable;
                    alInput.SaiSaisuiRakTblDataTable = _saisuiTable;
                    alInput.JokasoMemoRakTblDataTable = _jokasoMemoTable;
                    // new EntryBtnClickApplicationLogic().Execute(alInput);
                    // 所見自動挿入チェックの状態をセット
                    alInput.ShokenAutoAddFlag = ShokenAutoAddCheckBox.Checked;
                    // 登録
                    IEntryBtnClickALOutput alOutput = new EntryBtnClickApplicationLogic().Execute(alInput);
                    if (ShokenAutoAddCheckBox.Checked)
                    {
                        if (alOutput.ShokenAutoAddErrFlag != "0")
                        {
                            // 所見自動挿入エラー
                            MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("所見自動挿入でエラーが発生しました。データに不整合が発生している可能性があります。\nエラーコード[{0}]", alOutput.ShokenAutoAddErrFlag));
                        }
                    }

                    // Move to previous screen
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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

        #region checkItemControl_CustomItemClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： checkItemControl_CustomItemClick
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
        private void checkItemControl_CustomItemClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                CheckItemControl ciControl = sender as CheckItemControl;
                // 所見区分
                string shokenKbn = ciControl.ItemNo.ToString();
                if (shokenKbn == "0")
                {
                    return;
                }
                else
                {
                    shokenKbn = shokenKbn.PadLeft(3, '0');
                }

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, shokenKbn, "1");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 判定結果(39-c)
                    ciControl.HanteiKekka = shokenRow.Handan;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region syoruiKensaSyokenButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syoruiKensaSyokenButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syoruiKensaSyokenButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.ShokenShiteki, "3");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region memoInputDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： memoInputDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void memoInputDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Avoid user click to header row
                if (e.RowIndex == -1) return;

                string jokasoMemoCd = memoInputDataGridView.CurrentRow.Cells[daibunruiCdColumn.Name].Value.ToString();

                // Open 000-010
                MemoMstSearchForm frm = new MemoMstSearchForm(jokasoMemoCd);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK && null != frm._selectedRow)
                {
                    // 大分類(115)
                    memoInputDataGridView.CurrentRow.Cells[daibunruiCdColumn.Name].Value = frm._selectedRow.MemoDaibunruiCd;
                    // メモコード(116)
                    memoInputDataGridView.CurrentRow.Cells[memoCdColumn.Name].Value = frm._selectedRow.MemoCd;
                    // メモ内容(117)
                    memoInputDataGridView.CurrentRow.Cells[memoWdColumn.Name].Value = frm._selectedRow.Memo;
                }

                // Add a new row at the bottom of dgv for next input
                //if (e.RowIndex == memoInputDataGridView.Rows.Count - 1)
                //{
                //    GaikanKensaKekkaTblDataSet.MemoInputDataTable newSource = (GaikanKensaKekkaTblDataSet.MemoInputDataTable)memoInputDataGridView.DataSource;
                //    GaikanKensaKekkaTblDataSet.MemoInputRow newRow = newSource.NewMemoInputRow();
                //    newSource.AddMemoInputRow(newRow);

                //    memoInputDataGridView.DataSource = null;
                //    memoInputDataGridView.Rows.Clear();
                //    memoInputDataGridView.DataSource = newSource;
                //}
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

        #region kensaFukaJohoAddButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaFukaJohoAddButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaFukaJohoAddButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                KensaFukaJohoAddForm frm = new KensaFukaJohoAddForm(string.Empty,
                    _dispTable[0].KensaKekkaIraiHoteiKbn,
                    _dispTable[0].KensaIraiHokenjoCd,
                    _dispTable[0].KensaIraiNendo,
                    _dispTable[0].KensaIraiRenban,
                    KensaFukaJohoAddForm.DispMode.Insert);

                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    IKensaFukaJohoAddBtnClickALInput alInput = new KensaFukaJohoAddBtnClickALInput();
                    alInput.KensaIraiHoteiKbn = _dispTable[0].KensaKekkaIraiHoteiKbn;
                    alInput.KensaIraiHokenjoCd = _dispTable[0].KensaIraiHokenjoCd;
                    alInput.KensaIraiNendo = _dispTable[0].KensaIraiNendo;
                    alInput.KensaIraiRenban = _dispTable[0].KensaIraiRenban;
                    IKensaFukaJohoAddBtnClickALOutput alOutput = new KensaFukaJohoAddBtnClickApplicationLogic().Execute(alInput);

                    // Binding new source to kensaFukaListDataGridView
                    kensaFukaListDataGridView.DataSource = null;
                    kensaFukaListDataGridView.Rows.Clear();
                    kensaFukaListDataGridView.DataSource = alOutput.KensaIraiKanrenFileTblDT;

                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "検査付加情報を追加しました。");
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

        #region kensaFukaJohoModButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaFukaJohoModButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaFukaJohoModButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (kensaFukaListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "表示データがありません。");
                    return;
                }

                string midashi = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiKanrenFileMidashiCol.Name].Value);
                string kensaIraiFileShubetsuCd = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiFileShubetsuCdCol.Name].Value);
                string kensaIraiKanrenFilePath = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiKanrenFilePathCol.Name].Value);

                KensaFukaJohoAddForm frm = new KensaFukaJohoAddForm(midashi,
                    _dispTable[0].KensaKekkaIraiHoteiKbn,
                    _dispTable[0].KensaIraiHokenjoCd,
                    _dispTable[0].KensaIraiNendo,
                    _dispTable[0].KensaIraiRenban,
                    KensaFukaJohoAddForm.DispMode.Update,
                    kensaIraiFileShubetsuCd,
                    kensaIraiKanrenFilePath);

                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    IKensaFukaJohoModBtnClickALInput alInput = new KensaFukaJohoModBtnClickALInput();
                    alInput.KensaIraiHoteiKbn = _dispTable[0].KensaKekkaIraiHoteiKbn;
                    alInput.KensaIraiHokenjoCd = _dispTable[0].KensaIraiHokenjoCd;
                    alInput.KensaIraiNendo = _dispTable[0].KensaIraiNendo;
                    alInput.KensaIraiRenban = _dispTable[0].KensaIraiRenban;
                    IKensaFukaJohoModBtnClickALOutput alOutput = new KensaFukaJohoModBtnClickApplicationLogic().Execute(alInput);

                    // Binding new source to kensaFukaListDataGridView
                    kensaFukaListDataGridView.DataSource = null;
                    kensaFukaListDataGridView.Rows.Clear();
                    kensaFukaListDataGridView.DataSource = alOutput.KensaIraiKanrenFileTblDT;

                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "検査付加情報を変更しました。");
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

        #region kensaFukaJohoDelButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaFukaJohoDelButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaFukaJohoDelButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row in dgv
                if (kensaFukaListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "表示データがありません。");
                    return;
                }

                //// Confirm before delete
                //if (MessageForm.Show2(MessageForm.DispModeType.Question, "対象の検査付加情報を削除します。よろしいですか？") != DialogResult.Yes)
                //{
                //    return;
                //}

                string midashi = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiKanrenFileMidashiCol.Name].Value);
                string kensaIraiFileShubetsuCd = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiFileShubetsuCdCol.Name].Value);
                string kensaIraiKanrenFilePath = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiKanrenFilePathCol.Name].Value);

                KensaFukaJohoAddForm frm = new KensaFukaJohoAddForm(midashi,
                    _dispTable[0].KensaKekkaIraiHoteiKbn,
                    _dispTable[0].KensaIraiHokenjoCd,
                    _dispTable[0].KensaIraiNendo,
                    _dispTable[0].KensaIraiRenban,
                    KensaFukaJohoAddForm.DispMode.Delete,
                    kensaIraiFileShubetsuCd,
                    kensaIraiKanrenFilePath);

                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    IKensaFukaJohoDelBtnClickALInput alInput = new KensaFukaJohoDelBtnClickALInput();
                    alInput.KensaIraiHoteiKbn = _dispTable[0].KensaKekkaIraiHoteiKbn;
                    alInput.KensaIraiHokenjoCd = _dispTable[0].KensaIraiHokenjoCd;
                    alInput.KensaIraiNendo = _dispTable[0].KensaIraiNendo;
                    alInput.KensaIraiRenban = _dispTable[0].KensaIraiRenban;
                    IKensaFukaJohoDelBtnClickALOutput alOutput = new KensaFukaJohoDelBtnClickApplicationLogic().Execute(alInput);

                    // Binding new source to kensaFukaListDataGridView
                    kensaFukaListDataGridView.DataSource = null;
                    kensaFukaListDataGridView.Rows.Clear();
                    kensaFukaListDataGridView.DataSource = alOutput.KensaIraiKanrenFileTblDT;

                    // Finish deleted file
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象の検査付加情報を削除しました。");
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

        #region kensaFukaListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaFukaListDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaFukaListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Avoid user click to header row
                if (e.RowIndex == -1) return;

                string midashi = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiKanrenFileMidashiCol.Name].Value);
                string kensaIraiFileShubetsuCd = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiFileShubetsuCdCol.Name].Value);
                string kensaIraiKanrenFilePath = Convert.ToString(kensaFukaListDataGridView.CurrentRow.Cells[kensaIraiKanrenFilePathCol.Name].Value);

                // 表示のみ
                KensaFukaJohoAddForm frm = new KensaFukaJohoAddForm(midashi,
                    _dispTable[0].KensaKekkaIraiHoteiKbn,
                    _dispTable[0].KensaIraiHokenjoCd,
                    _dispTable[0].KensaIraiNendo,
                    _dispTable[0].KensaIraiRenban,
                    KensaFukaJohoAddForm.DispMode.View,
                    kensaIraiFileShubetsuCd,
                    kensaIraiKanrenFilePath);
                // 表示後に関連ファイルを実行して表示して終了
                frm.ShowDialog();
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

        #region manualInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： manualInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void manualInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string shorihoshikiKbn = _dispTable[0].KensaIraiShorihoshikiKbn;
                string jinin = _dispTable[0].IsKensaIraiShoritaishoJininNull() ? "0" : _dispTable[0].KensaIraiShoritaishoJinin.ToString();

                SyokenManualInputForm frm = new SyokenManualInputForm(shorihoshikiKbn, jinin);
                frm.ShowDialog();

                if (frm.DialogResult != DialogResult.OK)
                {
                    return;
                }

                // 所見手書き, 挿入位置, チェック項目, 指摘箇所, 判定
                SetSyokenKekkaControlFromSyokenManualDlg(frm._shokenManualResult.ShokenWd, frm._shokenManualResult.InsertPosition, frm._shokenManualResult.CheckItemNo, frm._shokenManualResult.ShitekiKasyoNo, frm._shokenManualResult.Handan);
                //foreach (SyokenKekkaControl skc in _syokenKekkaControl)
                //{
                //    if (Convert.ToString(skc.ItemNo) == frm._shokenManualResult.ShitekiKasyoNo)
                //    {
                //        // 所見区分(238)
                //        skc.SyokenKbn = ""; // TODO
                //        // 所見コード(239)
                //        skc.SyokenCd = ""; // TODO
                //        // 所見内容(241)
                //        skc.SyokenWd = frm._shokenManualResult.ShokenWd;
                //    }
                //}
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

        #region syokenKekkaControl_CustomSearchButtonClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syokenKekkaControl_CustomSearchButtonClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　AnhNV　　    新規作成
        /// 2014/12/26  小松　　　　所見一覧の虫メガネボタンでの所見設定が登録されない件の対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syokenKekkaControl_CustomSearchButtonClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                SyokenKekkaControl syokenControl = sender as SyokenKekkaControl;

                // 所見区分
                string shokenKbn = syokenControl.SyokenKbn == null ? string.Empty : syokenControl.SyokenKbn;
                Debug.WriteLine("syokenKekkaControl_CustomSearchButtonClick() syokenControl.SyokenKbn:" + syokenControl.SyokenKbn);
                // 所見コード
                string shokenCd = syokenControl.SyokenCd == null ? string.Empty : syokenControl.SyokenCd;
                Debug.WriteLine("syokenKekkaControl_CustomSearchButtonClick() syokenControl.SyokenCd:" + syokenControl.SyokenCd);

                // Open 000-009 ShokenMstSearch
                SyokenMstSearchForm frm = new SyokenMstSearchForm(shokenKbn, shokenCd);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    // 所見マスタ選択ダイアログで設定された所見を所見一覧に設定
                    SetSyokenKekkaControlFromSyokenMstSearchDlg(frm._selectedRow, syokenControl.ItemNo);
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

        #region syokenKekkaControl_CustomUpButtonClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syokenKekkaControl_CustomUpButtonClick
        /// <summary>
        /// 所見結果用ユーザコントロールの移動ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syokenKekkaControl_CustomUpButtonClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display)
                {
                    return;
                }

                SyokenKekkaControl syokenControl = sender as SyokenKekkaControl;

                // 移動可能かチェック
                if (syokenControl.ItemNo == 1)
                {
                    // 先頭は移動無効
                    MessageForm.Show2(MessageForm.DispModeType.Warning, "先頭行の移動は出来ません。");
                    return;
                }
                if (syokenControl.ShokenKekkaKbn == SyokenKekkaControl.ShokenKekkaKbnType.ShokenHosoku)
                {
                    // 補足は移動無効
                    MessageForm.Show2(MessageForm.DispModeType.Warning, "所見補足のみの移動は出来ません。");
                    return;
                }

                // 移動元は補足有りか
                int startIndex = syokenControl.ItemNo - 1;
                int endIndex = syokenControl.ItemNo - 1;
                for (int index = startIndex + 1; index < _syokenKekkaControl.Count; index++)
                {
                    if (_syokenKekkaControl[index].ShokenKekkaKbn == SyokenKekkaControl.ShokenKekkaKbnType.ShokenHosoku)
                    {
                        endIndex = index;
                    }
                    else
                    {
                        break;
                    }
                }

                SyokenKekkaControl tempSyokenControl = new SyokenKekkaControl();
                // 移動先を一旦コピー
                SetSyokenKekkaControlFromShokenKekkaCtrl(_syokenKekkaControl[startIndex - 1], tempSyokenControl);
                for (int index = startIndex; index <= endIndex; index++)
                {
                    // 対象行を上に移動
                    SetSyokenKekkaControlFromShokenKekkaCtrl(_syokenKekkaControl[index], _syokenKekkaControl[index - 1]);
                }
                // 移動元下部に移動先をコピー
                SetSyokenKekkaControlFromShokenKekkaCtrl(tempSyokenControl, _syokenKekkaControl[endIndex]);
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

        #region syokenKekkaControl_CustomDelButtonClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： syokenKekkaControl_CustomDelButtonClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void syokenKekkaControl_CustomDelButtonClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display)
                {
                    return;
                }

                SyokenKekkaControl syokenControl = sender as SyokenKekkaControl;

                if (syokenControl.ShokenKekkaKbn == SyokenKekkaControl.ShokenKekkaKbnType.ShokenHosoku)
                {
                    // 補足のみ削除無効
                    MessageForm.Show2(MessageForm.DispModeType.Warning, "所見補足のみの削除は出来ません。");
                    return;
                }

                // 削除元は補足有りか
                int startIndex = syokenControl.ItemNo - 1;
                int endIndex = syokenControl.ItemNo - 1;
                for (int index = startIndex + 1; index < _syokenKekkaControl.Count; index++)
                {
                    if (_syokenKekkaControl[index].ShokenKekkaKbn == SyokenKekkaControl.ShokenKekkaKbnType.ShokenHosoku)
                    {
                        endIndex = index;
                    }
                    else
                    {
                        break;
                    }
                }

                // 補足も含めて削除
                for (int index = startIndex; index <= endIndex; index++)
                {
                    // 所見結果クリア
                    InitSyokenKekkaControl(_syokenKekkaControl[index]);
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
        /// 2014/11/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_dispMode == DispMode.Display)
                {
                    this.Close();
                    return;
                }

                // 編集内容破棄チェック
                if (EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
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

        #region Textboxes leave events

        #region kensaTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaTextBox_Leave
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
        private void kensaTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                ZTextBox targetTextBox = sender as ZTextBox;

                string checkNumber = targetTextBox.Text;
                SetBikoText(checkNumber, _kensaTextBoxDict[targetTextBox], _txtKbnDict[targetTextBox]);
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

        #region nijiToshidoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nijiToshidoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nijiToshidoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                SetBikoTextForToshidosTextBox(nijiToshidoTextBox, nijiToshidoComboBox, nijiToshidoHyokaLabel);
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

        #region toshidoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： toshidoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void toshidoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                SetBikoTextForToshidosTextBox(toshidoTextBox, toshidoComboBox, toshidoHyokaLabel);
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

        #region saiNijiToshidoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saiNijiToshidoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saiNijiToshidoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                SetBikoTextForToshidosTextBox(saiNijiToshidoTextBox, saiNijiToshidoComboBox, saiNijiToshidoHyokaLabel);
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

        #region saiToshidoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saiToshidoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saiToshidoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                SetBikoTextForToshidosTextBox(saiToshidoTextBox, saiToshidoComboBox, saiToshidoHyokaLabel);
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

        #region Label double click events

        #region phLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： phLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void phLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "100", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region yozonSansoRyoHyokaLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yozonSansoRyoHyokaLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yozonSansoRyoHyokaLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "200", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region nijiToshidoHyokaLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nijiToshidoHyokaLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nijiToshidoHyokaLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "300", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region toshidoHyokaLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： toshidoHyokaLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void toshidoHyokaLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "400", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region zanryuensoHyokaLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zanryuensoHyokaLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zanryuensoHyokaLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "500", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region BODHyokaLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BODHyokaLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BODHyokaLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "600", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region enkabutsuIonHyokaLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： enkabutsuIonHyokaLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void enkabutsuIonHyokaLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "700", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region odeiChindenRitsuHyokaLabel_DoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： odeiChindenRitsuHyokaLabel_DoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void odeiChindenRitsuHyokaLabel_DoubleClick(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display) return;

                // Call to 009-005 ShokenKekkaSelect
                SyokenKekkaSelectForm frm = new SyokenKekkaSelectForm(SyokenKekkaSelectForm.Mode.Shoken, "800", "2");
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ShokenMstDataSet.ShokenKekkaSelectRow shokenRow = frm._shokenResult.ShokenRow;

                    // 所見区分(238), 所見コード(239), 所見内容(241)
                    SetSyokenKekkaControlFromShokenSelectDlg(frm._shokenResult.ShokenRow, frm._shokenResult.HosokuDT, frm._shokenResult.SonyuIchiNum);
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

        #region Fax buttons click events

        #region faxSofuMakerButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxSofuMakerButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxSofuMakerButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFaxSofuMakerBtnClickALInput alInput = new FaxSofuMakerBtnClickALInput();
                alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                alInput.KensaIraiNendo = _kensaIraiNendo;
                alInput.KensaIraiRenban = _kensaIraiRenban;
                alInput.PrintMode = KensaKekkaListForm.PrintMode.FaxMk;
                new FaxSofuMakerBtnClickApplicationLogic().Execute(alInput);
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

        #region faxSofuHotenButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxSofuHotenButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxSofuHotenButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFaxSofuHotenBtnClickALInput alInput = new FaxSofuHotenBtnClickALInput();
                alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                alInput.KensaIraiNendo = _kensaIraiNendo;
                alInput.KensaIraiRenban = _kensaIraiRenban;
                alInput.PrintMode = KensaKekkaListForm.PrintMode.FaxHosyu;
                new FaxSofuHotenBtnClickApplicationLogic().Execute(alInput);
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

        #region faxSofuKojiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxSofuKojiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxSofuKojiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFaxSofuKojiBtnClickALInput alInput = new FaxSofuKojiBtnClickALInput();
                alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                alInput.KensaIraiNendo = _kensaIraiNendo;
                alInput.KensaIraiRenban = _kensaIraiRenban;
                alInput.PrintMode = KensaKekkaListForm.PrintMode.FaxKoji;
                new FaxSofuKojiBtnClickApplicationLogic().Execute(alInput);
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

        #region faxSofuHokenshoButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： faxSofuHokenshoButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void faxSofuHokenshoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFaxSofuHokenshoBtnClickALInput alInput = new FaxSofuHokenshoBtnClickALInput();
                alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                alInput.KensaIraiNendo = _kensaIraiNendo;
                alInput.KensaIraiRenban = _kensaIraiRenban;
                new FaxSofuHokenshoBtnClickApplicationLogic().Execute(alInput);
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

        #region kekkashoDispButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kekkashoDispButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　AnhNV　　    新規作成
        /// 2015/01/07　habu　　    共通関数での出力に修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kekkashoDispButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 結果書出力
                int result = Utility.KekkashoUtility.KekkashoOutput(_kensaIraiHoteiKbn, _kensaIraiHokenjoCd, _kensaIraiNendo, _kensaIraiRenban);

                switch (result)
                {
                    case 2:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "対象のデータが見つかりません。");
                        break;
                    case 3:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                        break;
                    case 4:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが存在しません。システム管理者に連絡してください。");
                        break;
                    case 9:
                        MessageForm.Show2(MessageForm.DispModeType.Error, "結果書作成に失敗しました。システム管理者に連絡してください。");
                        break;
                    default:
                        break;
                }

                #region to be removed
                //IKekkashoDispBtnClickALInput alInput = new KekkashoDispBtnClickALInput();
                //alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
                //alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
                //alInput.KensaIraiNendo = _kensaIraiNendo;
                //alInput.KensaIraiRenban = _kensaIraiRenban;
                //new KekkashoDispBtnClickApplicationLogic().Execute(alInput);
                #endregion
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

        #region memoSelButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： memoSelButton_Click
        /// <summary>
        /// メモ選択ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/21　小松　    　メモの選択、削除に対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void memoSelButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No handle in Display mode
                if (_dispMode == DispMode.Display)
                {
                    return;
                }

                if (memoInputDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "表示データがありません。");
                    return;
                }

                string jokasoMemoCd = memoInputDataGridView.CurrentRow.Cells[daibunruiCdColumn.Name].Value.ToString();

                // Open 000-010
                MemoMstSearchForm frm = new MemoMstSearchForm(jokasoMemoCd);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK && null != frm._selectedRow)
                {
                    // 大分類(115)
                    memoInputDataGridView.CurrentRow.Cells[daibunruiCdColumn.Name].Value = frm._selectedRow.MemoDaibunruiCd;
                    // メモコード(116)
                    memoInputDataGridView.CurrentRow.Cells[memoCdColumn.Name].Value = frm._selectedRow.MemoCd;
                    // メモ内容(117)
                    memoInputDataGridView.CurrentRow.Cells[memoWdColumn.Name].Value = frm._selectedRow.Memo;
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

        #region memoDelButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： memoDelButton_Click
        /// <summary>
        /// メモ削除ボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/21　小松　    　メモの選択、削除に対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void memoDelButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                // No handle in Display mode
                if (_dispMode == DispMode.Display)
                {
                    return;
                }

                if (memoInputDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "表示データがありません。");
                    return;
                }

                {
                    // 大分類(115)
                    memoInputDataGridView.CurrentRow.Cells[daibunruiCdColumn.Name].Value = string.Empty;
                    // メモコード(116)
                    memoInputDataGridView.CurrentRow.Cells[memoCdColumn.Name].Value = string.Empty;
                    // メモ内容(117)
                    memoInputDataGridView.CurrentRow.Cells[memoWdColumn.Name].Value = string.Empty;
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
        /// 2014/10/23  AnhNV　　    新規作成
        /// 2014/11/11  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.10
        /// 2015/01/09  小松　　　　再採水対象の場合は、水質タブの１回目(左側)は入力不可
        /// 2015/01/11  小松　　　　７条、11条外観の場合は、再採水の入力はしない
        /// 2015/01/29  小松　　    要望対応:#8559(検査結果値の評価、表示等の制御)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // ComboBoxes
            SetComboBoxSource();

            // A dictionary of textbox/label of tab 水質
            SetDictData();

            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.KensaIraiHoteiKbn = _kensaIraiHoteiKbn;
            alInput.KensaIraiHokenjoCd = _kensaIraiHokenjoCd;
            alInput.KensaIraiNendo = _kensaIraiNendo;
            alInput.KensaIraiRenban = _kensaIraiRenban;
            alInput.KensaKekkaMochikomiDt = _mochikomiDt;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            _dispTable = alOutput.KensaOutputTable.KensaKekkaInputShosaiDataTable;
            _cl75Table = alOutput.KensaOutputTable.CheckList75DataTable;
            //_footerTable = alOutput.KensaOutputTable.KensaKekkaFooterDataTable;
            _kakoKensaJohoTable = alOutput.KensaOutputTable.KakoKensaJohoDataTable;
            // Update tables
            _kensaIraiTable = alOutput.KensaOutputTable.KensaIraiTblDataTable;
            _kensaKekkaTable = alOutput.KensaOutputTable.KensaKekkaTblDataTable;
            _gaikanKekkaTable = alOutput.KensaOutputTable.GaikanKensaKekkaTblDataTable;
            _saisuiTable = alOutput.KensaOutputTable.SaiSaisuiTblDataTable;
            _jokasoMemoTable = alOutput.KensaOutputTable.JokasoMemoTblDataTable;
            // 所見結果テーブル
            _shokenKekkaList = alOutput.KensaOutputTable.ShokenKekkaList;
            // 所見結果補足テーブル
            _shokenKekkaHosokuList = alOutput.KensaOutputTable.ShokenKekkaHosokuList;
            int shokenKekkaCnt;
            {
                int maxKekkaIndex = 0;
                object maxKekkaIndexValue = _shokenKekkaList.Compute("MAX(ShokenHyojiichi)", null);
                if (maxKekkaIndexValue != System.DBNull.Value && maxKekkaIndexValue != null)
                {
                    maxKekkaIndex = (int)maxKekkaIndexValue;
                }
                //foreach (GaikanKensaKekkaTblDataSet.ShokenKekkaListRow maxKekkaRow in _shokenKekkaList.Select("MAX(ShokenHyojiichi)"))
                //{
                //    maxKekkaIndex = maxKekkaRow.ShokenHyojiichi;
                //}
                int maxKekkaHosokuIndex = 0;
                object maxKekkaHosokuIndexValue = _shokenKekkaHosokuList.Compute("MAX(ShokenHyojiichi)", null);
                if (maxKekkaHosokuIndexValue != System.DBNull.Value && maxKekkaHosokuIndexValue != null)
                {
                    maxKekkaHosokuIndex = (int)maxKekkaHosokuIndexValue;
                }
                //foreach (GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListRow maxKekkaHosokuRow in _shokenKekkaHosokuList.Select("ShokenHyojiichi = MAX(ShokenHyojiichi)"))
                //{
                //    maxKekkaHosokuIndex = maxKekkaHosokuRow.ShokenHyojiichi;
                //}

                if (maxKekkaIndex < maxKekkaHosokuIndex)
                {
                    shokenKekkaCnt = maxKekkaHosokuIndex;
                }
                else
                {
                    shokenKekkaCnt = maxKekkaIndex;
                }
                if (shokenKekkaCnt < SHOKEN_KEKKA_MAX_COUNT)
                {
                    shokenKekkaCnt = SHOKEN_KEKKA_MAX_COUNT;
                }

                syokenKekkaPanel.Location = new Point(0, 0);
                syokenKekkaPanel.Size = new Size(SHOKEN_KEKKA_PANEL_WIDTH, SHOKEN_KEKKA_PANEL_HEIGHT_INIT);
                _syokenKekkaControl = new List<SyokenKekkaControl>();
                for (int i = 0; i < shokenKekkaCnt; i++)
                {
                    SyokenKekkaControl syokenKekkaControl = new SyokenKekkaControl();
                    InitSyokenKekkaControl(syokenKekkaControl);
                    syokenKekkaPanel.Controls.Add(syokenKekkaControl);
                    syokenKekkaControl.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
                    syokenKekkaControl.CustomUpButtonClick += new EventHandler(syokenKekkaControl_CustomUpButtonClick);
                    syokenKekkaControl.CustomDeleteButtonClick += new EventHandler(syokenKekkaControl_CustomDelButtonClick);
                    syokenKekkaControl.ItemNo = i + 1;
                    syokenKekkaControl.Location = new Point(SHOKEN_KEKKA_LOCATION_X, SHOKEN_KEKKA_LOCATION_Y_MARGIN + (SHOKEN_KEKKA_HEIGHT * i));
                    // syokenKekkaControl.Size = new Size(1100, 20);
                    syokenKekkaControl.TabIndex = i + 1;
                    _syokenKekkaControl.Add(syokenKekkaControl);
                }
            }


            // ステータス区分
            string kensaIraiStatusKbn = _dispTable[0].KensaIraiStatusKbn;

            // Set display mode
            _dispMode = Convert.ToInt32(kensaIraiStatusKbn == string.Empty ? "0" : kensaIraiStatusKbn) >= 65
                ? DispMode.Display : DispMode.Update;

            // Control the display
            ItemsDisplayControl();
            KensaHanteiActiveControl(kensaIraiStatusKbn);

            // Numbering custom kekka control
            SetDefaultKekkaControl();

            // Default values
            DisplayDefault(alOutput);

            // 検査完了ボタン(25) && 判定(34)
            //kensaFinishButton.Enabled = _dispTable[0].KensaIraiStatusKbn == "60" ? true : false;

            // 判定(34)
            //hanteiComboBox.SelectedValue = _dispTable[0].KensaKekkaHantei;
            // v1.09
            _hanteiKekka = GetDefaultValueForHanteiComboBox();
            hanteiComboBox.SelectedValue = _hanteiKekka;

            // 20150129 habu 行政報告の判定を追加
            _gyoseiHokokuHantei = GetDefaultValueForGyoseiHokokuComboBox();
            gyoseiHokokuLevelComboBox.SelectedValue = _gyoseiHokokuHantei;

            // 再採水対象かチェック
            if (IsSaiSaisuiTarget())
            {
                // 再採水対象の場合は、１回目は入力不可
                suishitsuGroupBox.Enabled = false;
            }
            // 11条水質のフォローかチェック
            if (Is11JoFollowTarget())
            {
                // 11条水質フォローの場合も、１回目は入力不可
                suishitsuGroupBox.Enabled = false;
            }

            // 7条、11条外観かチェック
            if (_dispTable[0].KensaIraiHoteiKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN ||
                _dispTable[0].KensaIraiHoteiKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN)
            {
                // 7条、11条外観の場合は、２回目は入力不可
                saiSuishitsuGroupBox.Enabled = false;
            }
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
        /// 2014/10/24  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// 2015/01/21  小松        検査種別は、11条水質の時はスクリーニング区分名をあわせて表示
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault(IFormLoadALOutput alOutput)
        {
            #region ヘッダー
            // 検査種別(1)
            kensaSyubetsuTextBox.Text = _dispTable[0].KensaSyubetsu;

            if (_kensaIraiTable[0].KensaIraiHoteiKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU)
            {
                // 11条水質の場合、スクリーニング区分名も表示
                string constNm = Common.Common.GetConstNmByKbnValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_024, _kensaIraiTable[0].KensaIraiScreeningKbn);
                if (!string.IsNullOrEmpty(constNm))
                {
                    kensaSyubetsuTextBox.Text = constNm;
                }
            }

            // 検査番号(保健所コード)(2)
            kyokaiNo1TextBox.Text = _dispTable[0].KensaIraiHokenjoCd;
            // 検査番号(年度)(3)
            kyokaiNo2TextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].KensaIraiNendo, "yy");
            // 検査番号(連番)(4)
            kyokaiNo3TextBox.Text = _dispTable[0].KensaIraiRenban;
            // 保健所受理番号保健所コード(5)
            hokensyoJuriNo1TextBox.Text = _dispTable[0].KensaIraiHokenjoJyuriHokenjoCd;
            // 保健所受理番号年度(6)
            hokensyoJuriNo2TextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].KensaIraiHokenjoJyuriNendo, "yy");
            // 保健所受理番号市町村コード(7)
            hokensyoJuriNo3TextBox.Text = _dispTable[0].KensaIraiHokenjoJyuriShichosonCd;
            // 保健所受理番号連番(8)
            hokensyoJuriNo4TextBox.Text = _dispTable[0].KensaIraiHokenjoJyuriRenban;
            // 担当(9)
            tantoTextBox.Text = _dispTable[0].Tanto;
            // 設置者名(10)
            secchisyaNmTextBox.Text = _dispTable[0].KensaIraiSetchishaNm;
            // 人槽１(11)
            ninsoKataTextBox.Text = _dispTable[0].ShoriHoshikiShubetsuNm;
            // 人槽２(12)
            ninsoNumTextBox.Text = _dispTable[0].IsJokasoShoriTaishoJininNull() ? string.Empty : _dispTable[0].JokasoShoriTaishoJinin.ToString();
            // 設置CD(13)
            secchisyaCdTextBox.Text = _dispTable[0].JokasoSetchishaKbn + '-' + _dispTable[0].JokasoSetchishaCd;
            // 検査員コード(14)
            kensaTantoCdTextBox.Text = _dispTable[0].KensaIraiKensaTantoshaCd;
            // 検査員名(15)
            kensaTantoNmTextBox.Text = _dispTable[0].KensaTantoNm;
            // メモ確認(16)
            memoKakuninCheckBox.Checked = _dispTable[0].KensaIraiMemoKakuninFlg == "1" ? true : false;
            // 設置場所(17)
            secchisyaAdrTextBox.Text = _dispTable[0].KensaIraiSetchibashoAdr;
            // 保証登録No1(18)
            hosyoEntryNo1TextBox.Text = _dispTable[0].KensaIraiHoshoTorokuKensakikanCd;
            // 保証登録No2(19)
            hosyoEntryNo2TextBox.Text = Common.Common.ConvertToHoshouNendoWareki(_dispTable[0].KensaIraiHoshoTorokuNendo);
            // 保証登録No3(20)
            hosyoEntryNo3TextBox.Text = _dispTable[0].KensaIraiHoshoTorokuRenban;
            //// 検査日 年(21)
            //kensaDtNenTextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].KensaIraiKensaNen, "yy");
            //// 検査日 月(22)
            //kensaDtTsukiTextBox.Text = _dispTable[0].KensaIraiKensaTsuki;
            //// 検査日 日(23)
            // 検査日 (21)
            kensaDtTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(_dispTable[0].KensaIraiKensaNen) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiKensaTsuki) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiKensaBi))
            {
                DateTime tempKensaDT;
                if (DateTime.TryParseExact(_dispTable[0].KensaIraiKensaNen + _dispTable[0].KensaIraiKensaTsuki + _dispTable[0].KensaIraiKensaBi, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tempKensaDT))
                {
                    kensaDtTextBox.Text = (new DateTime(Convert.ToInt32(_dispTable[0].KensaIraiKensaNen),
                                                        Convert.ToInt32(_dispTable[0].KensaIraiKensaTsuki),
                                                        Convert.ToInt32(_dispTable[0].KensaIraiKensaBi))).ToString("yyyy年MM月dd日");
                }
            }
            //kensaDtHiTextBox.Text = _dispTable[0].KensaIraiKensaBi;
            // 過去の検査情報(24)
            kakoKensaJohoTextBox.Text = _kakoKensaJohoTable[0].RowNum >= 1 ? "●" : string.Empty;
            #endregion

            #region 判定／外観Tab(26)
            //// 判定(34)
            ////hanteiComboBox.SelectedValue = _dispTable[0].KensaKekkaHantei;
            //// v1.09
            //_hanteiKekka = GetDefaultValueForHanteiComboBox();
            //hanteiComboBox.SelectedValue = _hanteiKekka;
            // 行政報告レベル(35)
            gyoseiHokokuLevelComboBox.SelectedValue = _dispTable[0].KensaIraiGyoseiHokokuLevel;
            // 嵩上(36)
            kasaageNumTextBox.Text = _dispTable[0].KensaIraiKasaage;
            // 43.滞留(37)
            tairyu43TextBox.Text = _dispTable[0].KensaIraiRyunyuTairyu;
            // 44.滞留(38)
            tairyu44TextBox.Text = _dispTable[0].KensaIraiHoryuTairyu;
            // ブロワ１(40)
            burowa1TextBox.Text = _dispTable[0].KensaIraiBurowa1;
            // ブロワ規定風量１(41)
            burowaKitei1TextBox.Text = _dispTable[0].KensaIraiBurowaKiteFuryo1;
            // ブロワ設置風量１(42)
            burowaSetchi1TextBox.Text = _dispTable[0].KensaIraiBurowaSetchiFuryo1;
            // ブロワ２(43)
            burowa2TextBox.Text = _dispTable[0].KensaIraiBurowa2;
            // ブロワ規定風量２(44)
            burowaKitei2TextBox.Text = _dispTable[0].KensaIraiBurowaKiteFuryo2;
            // ブロワ設置風量２(45)
            burowaSetchi2TextBox.Text = _dispTable[0].KensaIraiBurowaSetchiFuryo2;
            // ブロワ３(46)
            burowa3TextBox.Text = _dispTable[0].KensaIraiBurowa3;
            // ブロワ規定風量３(47)
            burowaKitei3TextBox.Text = _dispTable[0].KensaIraiBurowaKiteFuryo3;
            // ブロワ設置風量３(48)
            burowaSetchi3TextBox.Text = _dispTable[0].KensaIraiBurowaSetchiFuryo3;
            #endregion

            #region 水質Tab(27)
            // pH(49)
            pHTextBox.Text = _dispTable[0].IsKensaKekkaSuisoIonNodoNull() ? string.Empty : _dispTable[0].KensaKekkaSuisoIonNodo.ToString("N1");
            // pH評価(50)
            pHHyokaLabel.Text = _dispTable[0].PHHyoka;
            // 溶存酸素量From(51)
            yozonSansoRyo1TextBox.Text = _dispTable[0].IsKensaKekkaYozonSansoryo1Null() ? string.Empty : _dispTable[0].KensaKekkaYozonSansoryo1.ToString("N1");
            // 溶存酸素量To(52)
            yozonSansoRyo2TextBox.Text = _dispTable[0].IsKensaKekkaYozonSansoryo2Null() ? string.Empty : _dispTable[0].KensaKekkaYozonSansoryo2.ToString("N1");
            // 溶存酸素量評価(53)
            yozonSansoRyoHyokaLabel.Text = _dispTable[0].YozonSansoRyoHyoka;
            // ２次透視度（度）(54)
            nijiToshidoTextBox.Text = _dispTable[0].IsKensaKekkaToshido2jiSyorisuiNull() ? string.Empty : _dispTable[0].KensaKekkaToshido2jiSyorisui.ToString("N1");
            // ２次透視度（数値範囲）(55)
            nijiToshidoComboBox.SelectedValue = _dispTable[0].KensaKekkaToshido22jiSyorisui;
            // ２次透視度評価(56)
            nijiToshidoHyokaLabel.Text = _dispTable[0].NijiToshidoHyoka;
            // 透視度（度）(57)
            toshidoTextBox.Text = _dispTable[0].IsKensaKekkaToshidoNull() ? string.Empty : _dispTable[0].KensaKekkaToshido.ToString("N1");
            // 透視度（数値範囲）(58)
            toshidoComboBox.SelectedValue = _dispTable[0].KensaKekkaToshido2;
            // 透視度評価(59)
            toshidoHyokaLabel.Text = _dispTable[0].ToshidoHyoka;
            // 残留塩素(60)
            zanryuensoTextBox.Text = _dispTable[0].IsKensaKekkaZanryuEnsoNodoNull() ? string.Empty : _dispTable[0].KensaKekkaZanryuEnsoNodo.ToString("N1");
            // 残留塩素評価(61)
            zanryuensoHyokaLabel.Text = _dispTable[0].ZanryuensoHyokaLabel;
            // ＢＯＤ(62)
            BODTextBox.Text = _dispTable[0].IsKensaKekkaBODNull() ? string.Empty : _dispTable[0].KensaKekkaBOD.ToString("N1");
            // ＢＯＤ（数値範囲）(63)
            BODComboBox.SelectedValue = _dispTable[0].KensaIraiBOD2;
            // ＢＯＤ評価(64)
            BODHyokaLabel.Text = _dispTable[0].BODHyokaLabel;
            // 塩化物イオン(65)
            enkabutsuIonTextBox.Text = _dispTable[0].IsKensaKekkaEnsoIonNodoNull() ? string.Empty : _dispTable[0].KensaKekkaEnsoIonNodo.ToString("N1");
            // 塩化物イオン（数値範囲）(66)
            enkabutsuIonComboBox.SelectedValue = _dispTable[0].KensaIraiEnsoIonNodo2;
            // 塩化物イオン評価(67)
            enkabutsuIonHyokaLabel.Text = _dispTable[0].EnkabutsuIonHyokaLabel;
            // 汚泥沈殿率(68)
            odeiChindenRitsuTextBox.Text = _dispTable[0].IsKensaKekkaOdeiChindenritsuNull() ? string.Empty : _dispTable[0].KensaKekkaOdeiChindenritsu.ToString();
            // 汚泥沈殿率（数値範囲）(69)
            odeiChindenRitsuComboBox.SelectedValue = _dispTable[0].KensaKekkaOdeiChindenritsu2;
            // 汚泥沈殿率評価(70)
            odeiChindenRitsuHyokaLabel.Text = _dispTable[0].OdeiChindenRitsuHyokaLabel;
            // MLSS(71)
            MLSSTextBox.Text = _dispTable[0].IsKensaKekkaMLSSNull() ? string.Empty : _dispTable[0].KensaKekkaMLSS.ToString();
            // 測定不能(72)
            sokuteiFunoComboBox.SelectedIndex = _dispTable[0].KensaKekkaSuishitsuSokuteifuno == "1" ? 1 : 0;
            // 水質依頼No(73)
            suishitsuIraiNoTextBox.Text = _dispTable[0].KensaKekkaSuishitsuIraiNo;

            // 再採水pH(74)
            saiPHTextBox.Text = _dispTable[0].IsSaiSaisuiSuisoIonNodoNull() ? string.Empty : _dispTable[0].SaiSaisuiSuisoIonNodo.ToString("N1");
            // 再採水pH評価(75)
            saiPHHyokaLabel.Text = _dispTable[0].SaiPHHyokaLabel;
            // 再採水溶存酸素量From(76)
            saiYozonSansoRyo1TextBox.Text = _dispTable[0].IsSaiSaisuiYozonSansoryo1Null() ? string.Empty : _dispTable[0].SaiSaisuiYozonSansoryo1.ToString("N1");
            // 再採水溶存酸素量To(77)
            saiYozonSansoRyo2TextBox.Text = _dispTable[0].IsSaiSaisuiYozonSansoryo2Null() ? string.Empty : _dispTable[0].SaiSaisuiYozonSansoryo2.ToString("N1");
            // 再採水溶存酸素量評価(78)
            //saiNijiToshidoTextBox.Text = _dispTable[0].SaiNijiToshido;
            saiYozonSansoRyoHyokaLabel.Text = _dispTable[0].SaiNijiToshido;
            // 再採水２次透視度（度）(79)
            saiNijiToshidoTextBox.Text = _dispTable[0].IsSaiSaisuiToshido2jishorisuiNull() ? string.Empty : _dispTable[0].SaiSaisuiToshido2jishorisui.ToString("N1");
            // 再採水２次透視度（数値範囲）(80)
            saiNijiToshidoComboBox.SelectedValue = _dispTable[0].SaiSaisuiToshido22jishorisui;
            // 再採水２次透視度評価(81)
            saiNijiToshidoHyokaLabel.Text = _dispTable[0].saiNijiToshidoHyokaLabel;
            // 再採水透視度（度）(82)
            saiToshidoTextBox.Text = _dispTable[0].IsSaiSaisuiToshidoNull() ? string.Empty : _dispTable[0].SaiSaisuiToshido.ToString("N1");
            // 再採水透視度（数値範囲）(83)
            saiToshidoComboBox.SelectedValue = _dispTable[0].SaiSaisuiToshido2;
            // 再採水透視度評価(84)
            saiToshidoHyokaLabel.Text = _dispTable[0].SaiToshidoHyokaLabel;
            // 再採水残留塩素(85)
            saiZanryuensoTextBox.Text = _dispTable[0].IsSaiSaisuiZanryuEnsoNodoNull() ? string.Empty : _dispTable[0].SaiSaisuiZanryuEnsoNodo.ToString("N1");
            // 再採水残留塩素評価(86)
            saiZanryuensoHyokaLabel.Text = _dispTable[0].SaiZanryuensoHyokaLabel;
            // 再採水ＢＯＤ(87)
            saiBODTextBox.Text = _dispTable[0].IsSaiSaisuiBODNull() ? string.Empty : _dispTable[0].SaiSaisuiBOD.ToString("N1");
            // 再採水ＢＯＤ（数値範囲）(88)
            saiBODComboBox.SelectedValue = _dispTable[0].SaiSaisuiBOD2;
            // 再採水ＢＯＤ評価(89)
            saiBODHyokaLabel.Text = _dispTable[0].SaiBODHyokaLabel;
            // 再採水塩化物イオン(90)
            saiEnkabutsuIonTextBox.Text = _dispTable[0].IsSaiSaisuiEnkaIonNodoNull() ? string.Empty : _dispTable[0].SaiSaisuiEnkaIonNodo.ToString("N1");
            // 再採水塩化物イオン（数値範囲）(91)
            saiEnkabutsuIonComboBox.SelectedValue = _dispTable[0].SaiSaisuiEnkaIonNodo2;
            // 再採水塩化物イオン評価(92)
            saiEnkabutsuIonHyokaLabel.Text = _dispTable[0].SaiEnkabutsuIonHyokaLabel;
            // 再採水汚泥沈殿率(93)
            saiOdeiChindenRitsuTextBox.Text = _dispTable[0].IsSaiSaisuiOdeichindenritsuNull() ? string.Empty : _dispTable[0].SaiSaisuiOdeichindenritsu;
            // 再採水汚泥沈殿率（数値範囲）(94)
            saiOdeiChindenRitsuComboBox.SelectedValue = _dispTable[0].SaiSaisuiOdeichindenritsu2;
            // 再採水汚泥沈殿率評価(95)
            saiOdeiChindenRitsuHyokaLabel.Text = _dispTable[0].SaiOdeiChindenRitsuHyokaLabel;
            // 再採水MLSS(96)
            saiMLSSTextBox.Text = _dispTable[0].IsSaiSaisuiMLSSNull() ? string.Empty : _dispTable[0].SaiSaisuiMLSS.ToString();
            // 再採水測定不能(97)
            saiSokuteiFunoComboBox.SelectedIndex = _dispTable[0].SaiSaisuiSuishitsuSokuteifuno == "1" ? 1 : 0;
            // 再採水水質依頼No(98)
            saiSuishitsuIraiNoTextBox.Text = _dispTable[0].SaiSaisuiSuishitsuIraiNo;

            // v1.11 Add start
            // ATUBOD (247)
            ATUBODTextBox.Text = _dispTable[0].IsKensaKekkaATUBODNull() ? string.Empty : _dispTable[0].KensaKekkaATUBOD.ToString("N1");
            // ATUBOD（数値範囲）(248)
            ATUBODComboBox.SelectedValue = _dispTable[0].KensaKekkaATUBOD2;
            // 再採水ATUBOD(249)
            saiATUBODTextBox.Text = _dispTable[0].IsSaiSaisuiATUBODNull() ? string.Empty : _dispTable[0].SaiSaisuiATUBOD.ToString("N1");
            // 再採水ATUBOD（数値範囲）(250)
            saiATUBODComboBox.SelectedValue = _dispTable[0].SaiSaisuiATUBOD2;
            // v1.11 Add end
            #endregion

            #region 書類Tab(28)
            // 保守点検-記録有無(100)
            hosyuTenken1ComboBox.SelectedValue = _dispTable[0].KensaKekkaHoshuTenkenKirokuUmu;
            // 保守点検-回数(101)
            hosyuTenken2ComboBox.SelectedValue = _dispTable[0].KensaKekkaHoshuTenkenKaisu;
            // 保守点検-内容(102)
            hosyuTenken3ComboBox.SelectedValue = _dispTable[0].KensaKekkaHoshuTenkenNaiyo;
            // 保守点検-月毎(103)
            //hosyuTenkenTsukiTextBox.Text = _dispTable[0].KensaIraiTenkenKaisuTsukiGoto;
            // 保守点検-週毎(104)
            //hosyuTenkenNumTextBox.Text = _dispTable[0].KensaIraiTenkenKaisuShuGoto;
            // 清掃-記録有無(105)
            seiso1ComboBox.SelectedValue = _dispTable[0].KensaKekkaSeisoKirokuUmu;
            // 清掃-回数(106)
            seiso2ComboBox.SelectedValue = _dispTable[0].KensaKekkaSeisoKaisu;
            // 清掃-内容(107)
            seiso3ComboBox.SelectedValue = _dispTable[0].KensaKekkaSeisoNaiyo;
            // 清掃-回/年(108)
            //seisoCountTextBox.Text = _dispTable[0].KensaIraiSeisoKaisuNenkan;

            DateTime seisoDt;
            if (DateTime.TryParseExact(_dispTable[0].KensaKekkaSeisoDt, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out seisoDt))
            {
                // 清掃年(109)
                //seisoDtNenTextBox.Text = Utility.DateUtility.ConvertToWareki(seisoDt.ToString("yyyy"), "yy");
                seisoDtNenTextBox.Text = seisoDt.ToString("yyyy");
                // 清掃月(110)
                seisoDtTsukiTextBox.Text = seisoDt.ToString("MM");
                // 清掃日(111)
                seisoDtHiTextBox.Text = seisoDt.ToString("dd");
            }
            else
            {
                // Back to 009-004
                //this.Close();
            }

            // 点検担当者名(112)
            tenkenTantosyaNmTextBox.Text = _dispTable[0].KensaIraiKensaTantoshaNm;

            // v1.13 Add start
            // 保守点検－実施(251)
            hosyuTenkenJisshiComboBox.SelectedValue = _dispTable[0].KensaKekkaTenkenKaisuKbn;
            // 保守点検－規定(252)
            hosyuTenkenKiteiComboBox.SelectedValue = _dispTable[0].TenkenKaisuKbn;
            // 清掃－規定(253)
            seisoKiteiComboBox.SelectedValue = _dispTable[0].SeisoKaisuKbn;
            // v1.13 Add end
            #endregion

            #region メモTab(29)
            // メモ(114)
            int numRow = alOutput.KensaOutputTable.MemoInputDataTable.Rows.Count;
            if (numRow < 14)
            {
                int addedRowNum = 14 - numRow;

                // Add row to equal 14
                for (int i = 1; i <= addedRowNum; i++)
                {
                    GaikanKensaKekkaTblDataSet.MemoInputRow newRow = alOutput.KensaOutputTable.MemoInputDataTable.NewMemoInputRow();
                    alOutput.KensaOutputTable.MemoInputDataTable.AddMemoInputRow(newRow);
                }

                memoInputDataGridView.DataSource = null;
                memoInputDataGridView.Rows.Clear();
                memoInputDataGridView.DataSource = alOutput.KensaOutputTable.MemoInputDataTable;

                // Default hidden columns
                foreach (DataGridViewRow dgvr in memoInputDataGridView.Rows)
                {
                    if (dgvr.Index == numRow) break;

                    dgvr.Cells[DefaultJokasoMemoDaibunruiCd.Name].Value = alOutput.KensaOutputTable.MemoInputDataTable[dgvr.Index].JokasoMemoDaibunruiCd;
                    dgvr.Cells[DefaultJokasoMemoCd.Name].Value = alOutput.KensaOutputTable.MemoInputDataTable[dgvr.Index].JokasoMemoCd;
                    dgvr.Cells[DefaultMemo.Name].Value = alOutput.KensaOutputTable.MemoInputDataTable[dgvr.Index].Memo;
                }
            }
            else
            {
                memoInputDataGridView.DataSource = null;
                memoInputDataGridView.Rows.Clear();
                memoInputDataGridView.DataSource = alOutput.KensaOutputTable.MemoInputDataTable;

                // Default hidden columns
                foreach (DataGridViewRow dgvr in memoInputDataGridView.Rows)
                {
                    dgvr.Cells[DefaultJokasoMemoDaibunruiCd.Name].Value = alOutput.KensaOutputTable.MemoInputDataTable[dgvr.Index].JokasoMemoDaibunruiCd;
                    dgvr.Cells[DefaultJokasoMemoCd.Name].Value = alOutput.KensaOutputTable.MemoInputDataTable[dgvr.Index].JokasoMemoCd;
                    dgvr.Cells[DefaultMemo.Name].Value = alOutput.KensaOutputTable.MemoInputDataTable[dgvr.Index].Memo;
                }
            }

            // メモ手書き
            memoInputTextBox.Text = _dispTable[0].KensaKekkaMemoTegaki;

            // 検査付加情報(119)
            kensaFukaListDataGridView.DataSource = null;
            kensaFukaListDataGridView.Rows.Clear();
            kensaFukaListDataGridView.DataSource = alOutput.KensaOutputTable.KensaIraiKanrenFileTblDT;

            //// Default hidden columns
            //foreach (DataGridViewRow dgvr in kensaFukaListDataGridView.Rows)
            //{
            //    dgvr.Cells[DefaultKensaDt.Name].Value = alOutput.KensaOutputTable.KensaIraiKanrenFileTblDT[dgvr.Index].KensaDt;
            //    dgvr.Cells[DefaultMidashi.Name].Value = alOutput.KensaOutputTable.KensaIraiKanrenFileTblDT[dgvr.Index].KensaIraiKanrenFileMidashi;
            //}
            #endregion

            #region 基本情報１Tab(30)
            DateTime jokasoUketsukeBi;
            if (DateTime.TryParseExact(_dispTable[0].JokasoUketsukeBi, "yyyyMMdd", null, DateTimeStyles.None, out jokasoUketsukeBi))
            {
                //// 受付日　年(131)
                //uketsukeDtNenTextBox.Text = jokasoUketsukeBi.ToString("yyyy");
                //// 受付日　月(132)
                //uketsukeDtTsukiTextBox.Text = jokasoUketsukeBi.ToString("MM");
                //// 受付日　日(133)
                //uketsukeDtHiTextBox.Text = jokasoUketsukeBi.ToString("dd");
                // 受付日　年(131)
                uketsukeDtTextBox.Text = jokasoUketsukeBi.ToString("yyyy年MM月dd日");
            }
            // 法根拠(134)
            hoKonkyoTextBox.Text = _dispTable[0].HoKonkyo;
            // 市町村設置型(135)
            shicyosonSecchiTypeTextBox.Text = _dispTable[0].ShicyosonSecchiType;
            // ディスポーザ(136)
            disposerTextBox.Text = _dispTable[0].JokasoDisupozaFlg;
            // カナ(137)
            kanrisyaKanaTextBox.Text = _dispTable[0].KensaIraiSetchishaKana;
            // 管理者名(138)
            kanrisyaNmTextBox.Text = _dispTable[0].KensaIraiSetchishaNm;
            // 管理者-郵便番号(139)
            kanrisyaZipCdTextBox.Text = _dispTable[0].KensaIraiSetchishaZipCd;
            // 管理者-電話番号(140)
            kanrisyaTelNoTextBox.Text = _dispTable[0].KensaIraiSetchishaTelNo;
            // 管理者-住所(141)
            kanrisyaAdrTextBox.Text = _dispTable[0].KensaIraiSetchishaAdr;
            // 名称(142)
            secchiNmTextBox.Text = _dispTable[0].KensaIraiShisetsuNm;
            // 設置場所-郵便番号(143)
            secchiZipCdTextBox.Text = _dispTable[0].KensaIraiSetchibashoZipCd;
            // 設置場所-電話番号(144)
            secchiTelNoTextBox.Text = _dispTable[0].KensaIraiSetchibashoTelNo;
            // 設置場所-住所(145)
            secchiAdrTextBox.Text = _dispTable[0].KensaIraiSetchibashoAdr;
            // 市町村コード(146)
            secchiShicyosonCdTextBox.Text = _dispTable[0].KensaIraiGenChikuCd;
            // 市町村名(147)
            secchiShicyosonNmTextBox.Text = _dispTable[0].ChikuRyakusho;
            // 担当支所コード(148)
            secchiTantoShisyoCdTextBox.Text = _dispTable[0].KensaIraiUketsukeShishoKbn;
            // 担当支所名称(149)
            secchiTantoShisyoNmTextBox.Text = _dispTable[0].ShishoNm;
            #endregion

            #region 基本情報２Tab(31)
            // 送付先(150)
            sofusakiNmTextBox.Text = _dispTable[0].KensaIraiSofusakiNm;
            // 送付先-郵便番号(151)
            sofusakiZipCdTextBox.Text = _dispTable[0].KensaIraiSofusakiZipCd;
            // 送付先-電話番号(152)
            sofusakiTelNoTextBox.Text = _dispTable[0].KensaIraiSofusakiTelNo;
            // 送付先-住所(153)
            sofusakiAdrTextBox.Text = _dispTable[0].KensaIraiSofusakiAdr;
            // 別途送付先コード１(154)
            bettoSofusakiCd1TextBox.Text = _dispTable[0].JokasoBettoSoufuGyoshaCd1;
            // 別途送付先名１(155)
            bettoSofusakiNm1TextBox.Text = _dispTable[0].BettoSofusakiNm1;
            // 別途送付先コード２(156)
            bettoSofusakiCd2TextBox.Text = _dispTable[0].JokasoBettoSoufuGyoshaCd2;
            // 別途送付先名２(157)
            bettoSofusakiNm2TextBox.Text = _dispTable[0].bettoSofusakiNm2;
            // 別途送付先コード３(158)
            bettoSofusakiCd3TextBox.Text = _dispTable[0].JokasoBettoSoufuGyoshaCd3;
            // 別途送付先名３(159)
            bettoSofusakiNm3TextBox.Text = _dispTable[0].bettoSofusakiNm3;
            // 一括請求先コード(160)
            ikkatsuSeikyusakiCdTextBox.Text = _dispTable[0].KensaIraiIkkatsuSeikyusakiCd;
            // 一括請求先名(161)
            ikkatsuSeikyusakiNmTextBox.Text = _dispTable[0].IkkatsuSeikyusakiNm;
            // 請求先(162)
            seikyusakiNmTextBox.Text = _dispTable[0].KensaIraiSeikyusakiNm;
            // 請求先-郵便番号(163)
            seikyusakiZipCdTextBox.Text = _dispTable[0].KensaIraiSeikyusakiZipCd;
            // 請求先-電話番号(164)
            seikyusakiTelNoTextBox.Text = _dispTable[0].KensaIraiSeikyusakiTelNo;
            // 請求先-住所(165)
            seikyusakiAdrTextBox.Text = _dispTable[0].KensaIraiSeikyusakiAdr;
            // 保健所コード(166)
            hokensyoCdTextBox.Text = _dispTable[0].KensaIraiSetchibashoHokenjoCd;
            // 保健所名(167)
            hokensyoNmTextBox.Text = _dispTable[0].HokenjoNm;
            //// 取下年(168)
            //torisageDtNenTextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].KensaIraiTorisageNen, "yy");
            //// 取下月(169)
            //torisageDtTsukiTextBox.Text = _dispTable[0].KensaIraiTorisageTsuki;
            //// 取下日(170)
            //torisageDtHiTextBox.Text = _dispTable[0].KensaIraiTorisageBi;
            // 取下年(168)
            torisageDtTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(_dispTable[0].KensaIraiTorisageNen) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiTorisageTsuki) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiTorisageBi))
            {
                torisageDtTextBox.Text = (new DateTime(Convert.ToInt32(_dispTable[0].KensaIraiTorisageNen),
                                                    Convert.ToInt32(_dispTable[0].KensaIraiTorisageTsuki),
                                                    Convert.ToInt32(_dispTable[0].KensaIraiTorisageBi))).ToString("yyyy年MM月dd日");
            }
            
            // 取下理由(171)
            torisageRiyuTextBox.Text = _dispTable[0].TorisageRiyu;
            #endregion

            #region 基本情報３Tab(32)
            // メーカーコード(172)
            makerCdTextBox.Text = _dispTable[0].JokasoMekaGyoshaCd;
            // メーカー名(173)
            makerNmTextBox.Text = _dispTable[0].MakerNm;
            // 種類(174)
            syuruiTextBox.Text = _dispTable[0].Syurui;
            // BOD処理性能(175)
            BODSpecTextBox.Text = _dispTable[0].KensaIraiBODShoriSeino;
            // 形式コード(176)
            keishikiCdTextBox.Text = _dispTable[0].KensaIraiKatashikiCd;
            // 形式名(177)
            keishikiNmTextBox.Text = _dispTable[0].KatashikiNm;
            // 工事業者コード(178)
            kojiGyosyaCdTextBox.Text = _dispTable[0].KensaIraiKojiGyoshaCd;
            // 工事業者名(179)
            kojiGyosyaNmTextBox.Text = _dispTable[0].KojiGyosyaNm;
            // 告知(180)
            kokuchiKbnTextBox.Text = _dispTable[0].KensaIraiKokujiKbn == "1" ? "その他" : string.Empty;
            // 告知-年度(181)
            //kokuchiKbnNendoTextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].KensaIraiKokujiNendo, "yy");
            kokuchiKbnNendoTextBox.Text = _dispTable[0].KensaIraiKokujiNendo;
            // 告知-第(182)
            kokuchiKbnHansuTextBox.Text = _dispTable[0].KensaIraiKokujiNo;
            // 認定番号(183)
            ninteiNoTextBox.Text = _dispTable[0].KensaIraiNinteiNo;
            // 点検業者コード(184)
            tenkenGyosyaCdTextBox.Text = _dispTable[0].KensaIraiHoshutenkenGyoshaCd;
            // 点検業者名(185)
            tenkenGyosyaNmTextBox.Text = _dispTable[0].TenkenGyosyaNm;
            // 建物用途1上段(186)
            tatemonoYoto1JodanTextBox.Text = _dispTable[0].TatemonoYoto1Jodan;
            // 建物用途1下段(187)
            tatemonoYoto1GedanTextBox.Text = _dispTable[0].TatemonoYoto1Gedan;
            // 建物用途2上段(188)
            tatemonoYoto2JodanTextBox.Text = _dispTable[0].TatemonoYoto2Jodan;
            // 建物用途2下段(189)
            tatemonoYoto2GedanTextBox.Text = _dispTable[0].TatemonoYoto2Gedan;
            // 建物用途3上段(190)
            tatemonoYoto3JodanTextBox.Text = _dispTable[0].TatemonoYoto3Jodan;
            // 建物用途3下段(191)
            tatemonoYoto3GedanTextBox.Text = _dispTable[0].TatemonoYoto3Gedan;
            // 建物用途4上段(192)
            tatemonoYoto4JodanTextBox.Text = _dispTable[0].TatemonoYoto4Jodan;
            // 建物用途4下段(193)
            tatemonoYoto4GedanTextBox.Text = _dispTable[0].TatemonoYoto4Gedan;
            // 建物用途5上段(194)
            tatemonoYoto5JodanTextBox.Text = _dispTable[0].TatemonoYoto5Jodan;
            // 建物用途5下段(195)
            tatemonoYoto5GedanTextBox.Text = _dispTable[0].TatemonoYoto5Gedan;
            // 清掃業者コード(196)
            seisoGyosyaCdTextBox.Text = _dispTable[0].KensaIraiSeisoGyoshaCd;
            // 清掃業者名(197)
            seisoGyosyaNmTextBox.Text = _dispTable[0].SeisoGyosyaNm;
            // 放流先コード(198)
            horyusakiCdTextBox.Text = _dispTable[0].KensaIraiHoryusakiCd;
            // 放流先名(199)
            horyusakiNmTextBox.Text = _dispTable[0].Name;
            // 処理方法１(200)
            syoriModel1TextBox.Text = _dispTable[0].ShoriHoshikiShubetsuNm;
            // 処理方法２(201)
            syoriModel2TextBox.Text = _dispTable[0].ShoriHoshikiNm;
            //// 使用開始日-年(202)
            //shiyoKaishiDtNenTextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].KensaIraiShiyoKaishiNen, "yy");
            //// 使用開始日-月(203)
            //shiyoKaishiDtTsukiTextBox.Text = _dispTable[0].KensaIraiShiyoKaishiTsuki;
            //// 使用開始日-日(204)
            //shiyoKaishiDtHiTextBox.Text = _dispTable[0].KensaIraiShiyoKaishiBi;
            // 使用開始日-年(202)
            shiyoKaishiDtTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(_dispTable[0].KensaIraiShiyoKaishiNen) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiShiyoKaishiTsuki) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiShiyoKaishiBi))
            {
                shiyoKaishiDtTextBox.Text = (new DateTime(Convert.ToInt32(_dispTable[0].KensaIraiShiyoKaishiNen),
                                                    Convert.ToInt32(_dispTable[0].KensaIraiShiyoKaishiTsuki),
                                                    Convert.ToInt32(_dispTable[0].KensaIraiShiyoKaishiBi))).ToString("yyyy年MM月dd日");
            }
            // 届(205)
            todokeTextBox.Text = _dispTable[0].Todoke;
            //// 設置年月日-年(206)
            //secchiDtNenTextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].KensaIraiSetchiNen, "yy");
            //// 設置年月日-月(207)
            //secchiDtTsukiTextBox.Text = _dispTable[0].KensaIraiSetchiTsuki;
            //// 設置年月日-日(208)
            //secchiDtHiTextBox.Text = _dispTable[0].KensaIraiSetchiBi;
            // 設置年月日-年(206)
            secchiDtTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(_dispTable[0].KensaIraiSetchiNen) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiSetchiTsuki) && !string.IsNullOrEmpty(_dispTable[0].KensaIraiSetchiBi))
            {
                secchiDtTextBox.Text = (new DateTime(Convert.ToInt32(_dispTable[0].KensaIraiSetchiNen),
                                                    Convert.ToInt32(_dispTable[0].KensaIraiSetchiTsuki),
                                                    Convert.ToInt32(_dispTable[0].KensaIraiSetchiBi))).ToString("yyyy年MM月dd日");
            }
            // 処理対象人員-人(209)
            syoriTaisyoJininNumTextBox.Text = _dispTable[0].IsKensaIraiShoritaishoJininNull() ? "0" : _dispTable[0].KensaIraiShoritaishoJinin.ToString();
            // 処理対象人員-m3/日(210)
            syoriTaisyoJininM3TextBox.Text = _dispTable[0].IsJokasoHiHeikinOsuiRyoNull() ? string.Empty : _dispTable[0].JokasoHiHeikinOsuiRyo.ToString("N0");
            // 実使用人員-人(211)
            jitsuShiyoJininNumTextBox.Text = _dispTable[0].KensaIraiJitsushiyoJininValue;
            // 実使用人員-m3/日(212)
            jitsuShiyoJininM3TextBox.Text = _dispTable[0].IsJokasoJitsuHiHeikinOsuiRyoNull() ? string.Empty : _dispTable[0].JokasoJitsuHiHeikinOsuiRyo.ToString("N0");
            // ３次(213)
            sanjiTextBox.Text = _dispTable[0].Sanji;
            // 延べ面積(214)
            nobeMensekiM2TextBox.Text = _dispTable[0].IsJokasoTatemonoNobeMensekiNull() ? string.Empty : _dispTable[0].JokasoTatemonoNobeMenseki.ToString();
            // 世帯等(215)
            setainadoTextBox.Text = _dispTable[0].KensaIraiJitsushiyoJinin;
            #endregion

            #region 基本情報４Tab(33)
            // 入金方法(216)
            nyukinTypeTextBox.Text = _dispTable[0].NyukinType;
            // 検査手数料(217)
            kensaTesuryoAmtTextBox.Text = _dispTable[0].IsKensaIraiKensaAmtNull() ? string.Empty : _dispTable[0].KensaIraiKensaAmt.ToString("N0");
            // 入金済(218)
            nyukinZumiAmtTextBox.Text = _dispTable[0].IsKensaIraiNyukinzumiAmtNull() ? string.Empty : _dispTable[0].KensaIraiNyukinzumiAmt.ToString("N0");
            // 請求額(219)
            seikyuAmtTextBox.Text = _dispTable[0].IsKensaIraiSeikyuAmtNull() ? string.Empty : _dispTable[0].KensaIraiSeikyuAmt.ToString("N0");
            // 地図番号年度１(227)
            mapNoNendo1TextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].JokasoChizuNendo, "yy");
            // 地図番号ページ１(228)
            mapNoPage1TextBox.Text = _dispTable[0].JokasoChizuPageNo;
            // 地図番号年度２(229)
            mapNoNendo2TextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].JokasoChizuNendo1, "yy");
            // 地図番号ページ２(230)
            mapNoPage2TextBox.Text = _dispTable[0].JokasoChizuPageNo1;
            // ハガキ送付先(231)
            hagakiSofusakiTextBox.Text = _dispTable[0].HagakiSofusaki;
            // 変更前メーカーコード(232)
            befMakerCdTextBox.Text = _dispTable[0].KensaIraiHenkomaeMakerCd;
            // 変更前メーカー名(233)
            befMakerNmTextBox.Text = _dispTable[0].BefMakerNm;
            // 変更前工事業者コード(234)
            befKojiGyosyaCdTextBox.Text = _dispTable[0].KensaIraiHenkomaeKojiGyoshaCd;
            // 変更前工事業者名(235)
            befKojiGyosyaNmTextBox.Text = _dispTable[0].BefKojiGyosyaNm;
            // DataGridView
            nyukinDataGridView.DataSource = null;
            nyukinDataGridView.Rows.Clear();
            nyukinDataGridView.DataSource = alOutput.KensaOutputTable.MaeukekinNyukinDataTable;
            #endregion

            #region チェック項目(39)

            // 判定結果
            int itemNo = 0;

            foreach (GaikanKensaKekkaTblDataSet.CheckList75Row row in _cl75Table)
            {
                // No check item control for empty GaikanKensaKekkaCheckKomokuCd
                if (string.IsNullOrEmpty(row.GaikankensaKomokuCd)) { continue; }

                // Get 番号
                itemNo = Convert.ToInt32(row.GaikankensaKomokuCd);
                // No check item control for GaikanKensaKekkaCheckKomokuCd which is greater than 75 or zero.
                if (itemNo == 0 || itemNo > 75) { continue; }

                if (_checkItemControl[itemNo - 1].ItemNo == itemNo)
                {
                    // 番号
                    _checkItemControl[itemNo - 1].ItemNo = itemNo;
                    // 項目名
                    _checkItemControl[itemNo - 1].ItemText = row.GaikankensaKomokuNm;
                    // Get 判定結果
                    string hanteiKekka = string.Empty;
                    switch (row.GaikanKensaKekkaCheckKomokuHantei)
                    {
                        case "1":
                            hanteiKekka = MARU;
                            break;
                        case "2":
                            hanteiKekka = SANKAKU;
                            break;
                        case "3":
                            hanteiKekka = BATSU;
                            break;
                        case "4":
                            hanteiKekka = HIKU;
                            break;
                        default:
                            break;
                    }
                    // 判定結果
                    _checkItemControl[itemNo - 1].HanteiKekka = hanteiKekka;
                }
            }

            #endregion

            #region フッター(236)

            //int ctrlIdx = 0;
            //foreach (GaikanKensaKekkaTblDataSet.KensaKekkaFooterRow row in _footerTable)
            //{
            //    // Maximum of 30 SyokenKekkaControl
            //    if (ctrlIdx > 30) break;

            //    if (_syokenKekkaControl[ctrlIdx].ItemNo == Convert.ToInt32(row.KensaIraiShokenRenban))
            //    {
            //        // 番号
            //        //_syokenKekkaControl[ctrlIdx].ItemNo = Convert.ToInt32(row.KensaIraiShokenRenban);
            //        // 所見区分
            //        _syokenKekkaControl[ctrlIdx].SyokenKbn = row.ShokenKbn;
            //        // 所見コード
            //        _syokenKekkaControl[ctrlIdx].SyokenCd = row.ShokenCd;
            //    }

            //    // Next control
            //    ctrlIdx++;
            //}

            foreach (GaikanKensaKekkaTblDataSet.ShokenKekkaListRow _shokenKekkaRow in _shokenKekkaList)
            {
                SetSyokenKekkaControlFromShokenKekkaTbl(_shokenKekkaRow, null, _shokenKekkaRow.ShokenHyojiichi);
            }
            foreach (GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListRow _shokenKekkaHosokuRow in _shokenKekkaHosokuList)
            {
                SetSyokenKekkaControlFromShokenKekkaTbl(null, _shokenKekkaHosokuRow, _shokenKekkaHosokuRow.ShokenHyojiichi);
            }


            #endregion
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
        /// 2014/10/23  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 検査種別
            kensaSyubetsuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            // 検査番号
            kyokaiNo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiNo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kyokaiNo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            // 保健所受理番号
            hokensyoJuriNo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            hokensyoJuriNo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            hokensyoJuriNo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, HorizontalAlignment.Left);
            hokensyoJuriNo4TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, HorizontalAlignment.Left);
            // 設置者名
            secchisyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            // 人槽１
            ninsoKataTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 14);
            // 人槽２
            ninsoNumTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            // 設置CD
            secchisyaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 7);
            // 検査員コード
            kensaTantoCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 3);
            // 検査員名
            kensaTantoNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);
            // 設置場所
            secchisyaAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            // 保証登録
            hosyoEntryNo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 1, HorizontalAlignment.Left);
            hosyoEntryNo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            hosyoEntryNo3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, HorizontalAlignment.Left);
            // 検査日
            kensaDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            //kensaDtNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //kensaDtTsukiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //kensaDtHiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            // 過去の検査情報
            kakoKensaJohoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, Int32.MaxValue, HorizontalAlignment.Center);

            kasaageNumTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
            tairyu43TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            tairyu44TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);

            burowa1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 16);
            burowaKitei1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 12);
            burowaSetchi1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 12);
            burowa2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 16);
            burowaKitei2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 12);
            burowaSetchi2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 12);
            burowa3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 16);
            burowaKitei3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 12);
            burowaSetchi3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 12);

            // pH
            pHTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // 溶存酸素量
            yozonSansoRyo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            yozonSansoRyo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // ２次透視度（度）(54)
            nijiToshidoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // 透視度（度）(57)
            toshidoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // 残留塩素(60)
            zanryuensoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 2, InputValidateUtility.SignFlg.Positive);
            // ＢＯＤ(62)
            BODTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
            enkabutsuIonTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);
            MLSSTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            suishitsuIraiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            // 再採水 pH(74)
            saiPHTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // 再採水溶存酸素量
            saiYozonSansoRyo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            saiYozonSansoRyo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // 再採水２次透視度（度）(79)
            saiNijiToshidoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // 再採水透視度（度）
            saiToshidoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            // 再採水残留塩素(85)
            saiZanryuensoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 2, InputValidateUtility.SignFlg.Positive);
            // 再採水ＢＯＤ
            saiBODTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
            saiEnkabutsuIonTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);
            saiOdeiChindenRitsuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            saiMLSSTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            saiSuishitsuIraiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            // 清掃
            seisoDtNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, HorizontalAlignment.Left);
            seisoDtTsukiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            seisoDtHiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            tenkenTantosyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);
            // メモ DataGridView (114)
            memoInputDataGridView.SetStdControlDomain(daibunruiCdColumn.Index, ZControlDomain.ZT_STD_CD, 2);
            memoInputDataGridView.SetStdControlDomain(memoCdColumn.Index, ZControlDomain.ZT_STD_CD, 3);
            memoInputDataGridView.SetStdControlDomain(memoWdColumn.Index, ZControlDomain.ZT_STD_NAME, 100);
            // 手書きメモ(118)
            memoInputTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            // 検査付加情報 DataGridView (119)
            kensaFukaListDataGridView.SetStdControlDomain(kensaIraiFileShubetsuCdCol.Index, ZControlDomain.ZT_STD_CD, 3);
            kensaFukaListDataGridView.SetStdControlDomain(kensaIraiKanrenFileMidashiCol.Index, ZControlDomain.ZT_STD_NAME, Int32.MaxValue);
            kensaFukaListDataGridView.SetStdControlDomain(insertDtCol.Index, ZControlDomain.ZT_STD_NAME, 10, DataGridViewContentAlignment.MiddleCenter);
            kensaFukaListDataGridView.SetStdControlDomain(kensaIraiKanrenFilePathCol.Index, ZControlDomain.ZT_STD_NAME, Int32.MaxValue);
            // 受付日
            uketsukeDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            //uketsukeDtNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //uketsukeDtTsukiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //uketsukeDtHiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            hoKonkyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            shicyosonSecchiTypeTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);

            kanrisyaKanaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
            kanrisyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            kanrisyaZipCdTextBox.SetStdControlDomain(ZControlDomain.ZT_ZIP_CD);
            kanrisyaTelNoTextBox.SetStdControlDomain(ZControlDomain.ZT_TEL_NO);
            kanrisyaAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 30);
            secchiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            secchiZipCdTextBox.SetStdControlDomain(ZControlDomain.ZT_ZIP_CD);
            secchiTelNoTextBox.SetStdControlDomain(ZControlDomain.ZT_TEL_NO);
            secchiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            secchiShicyosonCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);
            secchiShicyosonNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            secchiTantoShisyoCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 1);
            secchiTantoShisyoNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            sofusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            sofusakiZipCdTextBox.SetStdControlDomain(ZControlDomain.ZT_ZIP_CD);
            sofusakiTelNoTextBox.SetStdControlDomain(ZControlDomain.ZT_TEL_NO);
            sofusakiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            sofusakiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            bettoSofusakiNm1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            bettoSofusakiCd2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            bettoSofusakiCd2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            bettoSofusakiCd3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            bettoSofusakiNm3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            ikkatsuSeikyusakiCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            ikkatsuSeikyusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            seikyusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            seikyusakiZipCdTextBox.SetStdControlDomain(ZControlDomain.ZT_ZIP_CD);
            seikyusakiTelNoTextBox.SetStdControlDomain(ZControlDomain.ZT_TEL_NO);
            seikyusakiAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            hokensyoCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            hokensyoNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 24);

            // 取下
            torisageDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            //torisageDtNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //torisageDtTsukiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //torisageDtHiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            torisageRiyuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);

            makerCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            makerNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            syuruiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            BODSpecTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 7);
            keishikiCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            keishikiNmTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 20);
            kojiGyosyaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            kokuchiKbnTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);

            // 告知-年度(181)
            kokuchiKbnNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            kokuchiKbnHansuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 3);

            ninteiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            tenkenGyosyaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            tenkenGyosyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            // 建物用途
            tatemonoYoto1JodanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto1GedanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto2JodanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto2GedanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto3JodanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto3GedanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto4JodanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto4GedanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto5JodanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            tatemonoYoto5GedanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            seisoGyosyaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            seisoGyosyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            horyusakiCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 3);
            horyusakiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            syoriModel1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 14);
            syoriModel2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);

            // 使用開始日
            shiyoKaishiDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            //shiyoKaishiDtNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //shiyoKaishiDtTsukiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //shiyoKaishiDtHiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            todokeTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);

            // 設置年月日
            secchiDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            //secchiDtNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //secchiDtTsukiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            //secchiDtHiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);

            syoriTaisyoJininNumTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            syoriTaisyoJininM3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            jitsuShiyoJininNumTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            jitsuShiyoJininM3TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            sanjiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            nobeMensekiM2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            setainadoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME);
            nyukinTypeTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            kensaTesuryoAmtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            nyukinZumiAmtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            seikyuAmtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);

            // nyukinDataGridView
            //nyukinDataGridView.SetControlDomain(nyukinAmtColumn.Index, ZControlDomain.ZT_STD_NUM);
            //nyukinDataGridView.SetControlDomain(nyukinDtColumn.Index, ZControlDomain.ZT_STD_NAME);
            //nyukinDataGridView.SetControlDomain(bikoColumn.Index, ZControlDomain.ZT_STD_NAME);
            //nyukinDataGridView.SetControlDomain(henkinDtColumn.Index, ZControlDomain.ZT_STD_NAME);
            //nyukinDataGridView.SetControlDomain(henkinAmtColumn.Index, ZControlDomain.ZT_STD_NUM);

            nyukinDataGridView.SetStdControlDomain(nyukinAmtColumn.Index, ZControlDomain.ZT_STD_NUM, Int32.MaxValue);
            nyukinDataGridView.SetStdControlDomain(nyukinDtColumn.Index, ZControlDomain.ZT_STD_NAME, Int32.MaxValue);
            nyukinDataGridView.SetStdControlDomain(bikoColumn.Index, ZControlDomain.ZT_STD_NAME, Int32.MaxValue);
            nyukinDataGridView.SetStdControlDomain(henkinDtColumn.Index, ZControlDomain.ZT_STD_NAME, Int32.MaxValue);
            nyukinDataGridView.SetStdControlDomain(henkinAmtColumn.Index, ZControlDomain.ZT_STD_NUM, Int32.MaxValue);
            // 地図番号年度１(227)
            mapNoNendo1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            mapNoPage1TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 5);
            // 地図番号年度２(229)
            mapNoNendo2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2, HorizontalAlignment.Left);
            mapNoPage2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 5);

            hagakiSofusakiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            // 変更前
            befMakerCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            befMakerNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            befKojiGyosyaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            befKojiGyosyaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            // v1.11 ADD start
            ATUBODTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
            saiATUBODTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
            // v1.11 ADD end
        }
        #endregion

        #region ItemsDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ItemsDisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.11
        /// 2015/01/29  小松　　　　BOD、塩化物イオン、ATUBODは検査員は触らないので非活性
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemsDisplayControl()
        {
            #region enable property
            // メモ確認(16)
            memoKakuninCheckBox.Enabled =
            memoKakuninCheckBox.TabStop =
                // 判定(34)
            hanteiComboBox.Enabled =
            hanteiComboBox.TabStop =
                // 行政報告レベル(35)
            gyoseiHokokuLevelComboBox.Enabled =
            gyoseiHokokuLevelComboBox.TabStop =
                // pH評価(50)
            pHHyokaLabel.Enabled =
                // 溶存酸素量評価(53)
            yozonSansoRyoHyokaLabel.Enabled =
                // ２次透視度（数値範囲）(55)
            nijiToshidoComboBox.Enabled =
            nijiToshidoComboBox.TabStop =
                // ２次透視度評価(56)
            nijiToshidoHyokaLabel.Enabled =
                // 透視度（数値範囲）(58)
            toshidoComboBox.Enabled =
            toshidoComboBox.TabStop =
                // 透視度評価(59)
            toshidoHyokaLabel.Enabled =
                // ＢＯＤ（数値範囲）(63)
            BODComboBox.Enabled =
            BODComboBox.TabStop =
                // 塩化物イオン（数値範囲）(66)
            enkabutsuIonComboBox.Enabled =
            enkabutsuIonComboBox.TabStop =
                // 汚泥沈殿率（数値範囲）(69)
            odeiChindenRitsuComboBox.Enabled =
            odeiChindenRitsuComboBox.TabStop =
                // 測定不能(72)
            sokuteiFunoComboBox.Enabled =
            sokuteiFunoComboBox.TabStop =
                // 再採水２次透視度（数値範囲）(80)
            saiNijiToshidoComboBox.Enabled =
            saiNijiToshidoComboBox.TabStop =
                // 再採水透視度（数値範囲）(83)
            saiToshidoComboBox.Enabled =
            saiToshidoComboBox.TabStop =
                // 再採水ＢＯＤ（数値範囲）(88)
            saiBODComboBox.Enabled =
            saiBODComboBox.TabStop =
                // 再採水塩化物イオン（数値範囲）(91)
            saiEnkabutsuIonComboBox.Enabled =
            saiEnkabutsuIonComboBox.TabStop =
                // 再採水塩化物イオン評価(92)
                // 再採水汚泥沈殿率（数値範囲）(94)
            saiOdeiChindenRitsuComboBox.Enabled =
            saiOdeiChindenRitsuComboBox.TabStop =
                // 再採水測定不能(97)
            saiSokuteiFunoComboBox.Enabled =
            saiSokuteiFunoComboBox.TabStop =
                // 保守点検-記録有無(100)
            hosyuTenken1ComboBox.Enabled =
            hosyuTenken1ComboBox.TabStop =
                // 保守点検-回数(101)
            hosyuTenken2ComboBox.Enabled =
            hosyuTenken2ComboBox.TabStop =
                // 保守点検-内容(102)
            hosyuTenken3ComboBox.Enabled =
            hosyuTenken3ComboBox.TabStop =
                // 清掃-記録有無(105)
            seiso1ComboBox.Enabled =
            seiso1ComboBox.TabStop =
                // 清掃-回数(106)
            seiso2ComboBox.Enabled =
            seiso2ComboBox.TabStop =
                // 清掃-内容(107)
            seiso3ComboBox.Enabled =
            seiso3ComboBox.TabStop =
                // メモ一覧(114)
                //memoInputDataGridView.Enabled =
            memoInputDataGridView.TabStop =
                // 所見結果
                //syokenKekkaPanel.Enabled =
            syokenKekkaPanel.TabStop =

            //// 保守点検－実施(251)
                //hosyuTenkenJisshiComboBox.Enabled =
                //// 保守点検－規定(252)
                //hosyuTenkenKiteiComboBox.Enabled =
                //// 清掃－規定(253)
                //seisoKiteiComboBox.Enabled =
                // 保守点検－規定(252)
            hosyuTenkenJisshiComboBox.Enabled =

            // v1.11 ADD Start
            ATUBODComboBox.Enabled =
            ATUBODComboBox.TabStop =
            saiATUBODComboBox.TabStop =
            saiATUBODComboBox.Enabled = _dispMode == DispMode.Display ? false : true;
            // v1.11 ADD End

            // 所見結果
            foreach (System.Windows.Forms.Control c in syokenKekkaPanel.Controls)
            {
                c.Enabled = _dispMode == DispMode.Display ? false : true;
            }
            #endregion

            #region read-only property
            // 嵩上(36)
            kasaageNumTextBox.ReadOnly =
                // 43.滞留(37)
            tairyu43TextBox.ReadOnly =
                // 44.滞留(38)
            tairyu44TextBox.ReadOnly =
                // チェック項目 1～75(39)
                // pH(49)
            pHTextBox.ReadOnly =
                // 溶存酸素量From(51)
            yozonSansoRyo1TextBox.ReadOnly =
                // 溶存酸素量To(52)
            yozonSansoRyo2TextBox.ReadOnly =
                // ２次透視度（度）(54)
            nijiToshidoTextBox.ReadOnly =
                // 透視度（度）(57)
            toshidoTextBox.ReadOnly =
                // 残留塩素(60)
            zanryuensoTextBox.ReadOnly =
                // 残留塩素評価(61)
                //zanryuensoHyokaLabel.Enabled
                // ＢＯＤ(62)
            BODTextBox.ReadOnly =
                // ＢＯＤ評価(64)
                //BODHyokaLabel
                // 塩化物イオン(65)
            enkabutsuIonTextBox.ReadOnly =
                // 塩化物イオン評価(67)
                // 汚泥沈殿率(68)
            odeiChindenRitsuTextBox.ReadOnly =
                // 汚泥沈殿率評価(70)
                // MLSS(71)
            MLSSTextBox.ReadOnly =
                // 水質依頼No(73)
                //suishitsuIraiNoTextBox.ReadOnly =
                // 再採水pH(74)
            saiPHTextBox.ReadOnly =
                // 再採水pH評価(75)
                // 再採水溶存酸素量From(76)
            saiYozonSansoRyo1TextBox.ReadOnly =
                // 再採水溶存酸素量To(77)
            saiYozonSansoRyo2TextBox.ReadOnly =
                // 再採水溶存酸素量評価(78)
                // 再採水２次透視度（度）(79)
            saiNijiToshidoTextBox.ReadOnly =
                // 再採水２次透視度評価(81)
                // 再採水透視度（度）(82)
            saiToshidoTextBox.ReadOnly =
                // 再採水透視度評価(84)
                // 再採水残留塩素(85)
            saiZanryuensoTextBox.ReadOnly =
                // 再採水残留塩素評価(86)
                // 再採水ＢＯＤ(87)
            saiBODTextBox.ReadOnly =
                // 再採水ＢＯＤ評価(89)
                // 再採水塩化物イオン(90)
            saiEnkabutsuIonTextBox.ReadOnly =
                // 再採水汚泥沈殿率(93)
            saiOdeiChindenRitsuTextBox.ReadOnly =
                // 再採水汚泥沈殿率評価(95)
                // 再採水MLSS(96)
            saiMLSSTextBox.ReadOnly =
                // 再採水水質依頼No(98)
                //saiSuishitsuIraiNoTextBox.ReadOnly =
                // 保守点検-月毎(103)
                //hosyuTenkenTsukiTextBox.ReadOnly = 
                // 保守点検-週毎(104)
                //hosyuTenkenNumTextBox.ReadOnly =
                // 清掃-回/年(108)
                //seisoCountTextBox.ReadOnly = 
                // 清掃年(109)
            seisoDtNenTextBox.ReadOnly =
                // 清掃月(110)
            seisoDtTsukiTextBox.ReadOnly =
                // 清掃日(111)
            seisoDtHiTextBox.ReadOnly =
                // 点検担当者名(112)
            tenkenTantosyaNmTextBox.ReadOnly =
                // 手書きメモ(118)
            memoInputTextBox.ReadOnly =
                // 検査付加情報(119)
                // メモ一覧(114)
            memoInputDataGridView.ReadOnly =

            // v1.11 ADD start
            ATUBODTextBox.ReadOnly =
            saiATUBODTextBox.ReadOnly =
                // v1.11 ADD End

            // 20141211
                // ブロワ１(40)
            burowa1TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ規定風量１(41)
            burowaKitei1TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ設置風量１(42)
            burowaSetchi1TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ２(43)
            burowa2TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ規定風量２(44)
            burowaKitei2TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ設置風量２(45)
            burowaSetchi2TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ３(46)
            burowa3TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ規定風量３(47)
            burowaKitei3TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            // ブロワ設置風量３(48)
            burowaSetchi3TextBox.ReadOnly = _dispMode == DispMode.Display ? true : false;
            #endregion

            #region tab-stop property
            // 嵩上(36)
            kasaageNumTextBox.TabStop =
                // 43.滞留(37)
            tairyu43TextBox.TabStop =
                // 44.滞留(38)
            tairyu44TextBox.TabStop =
                // チェック項目 1～75(39)
                // pH(49)
            pHTextBox.TabStop =
                // 溶存酸素量From(51)
            yozonSansoRyo1TextBox.TabStop =
                // 溶存酸素量To(52)
            yozonSansoRyo2TextBox.TabStop =
                // ２次透視度（度）(54)
            nijiToshidoTextBox.TabStop =
                // 透視度（度）(57)
            toshidoTextBox.TabStop =
                // 残留塩素(60)
            zanryuensoTextBox.TabStop =
                // 残留塩素評価(61)
                //zanryuensoHyokaLabel.Enabled
                // ＢＯＤ(62)
            BODTextBox.TabStop =
                // ＢＯＤ評価(64)
                //BODHyokaLabel
                // 塩化物イオン(65)
            enkabutsuIonTextBox.TabStop =
                // 塩化物イオン評価(67)
                // 汚泥沈殿率(68)
            odeiChindenRitsuTextBox.TabStop =
                // 汚泥沈殿率評価(70)
                // MLSS(71)
            MLSSTextBox.TabStop =
                // 水質依頼No(73)
                //suishitsuIraiNoTextBox.TabStop =
                // 再採水pH(74)
            saiPHTextBox.TabStop =
                // 再採水pH評価(75)
                // 再採水溶存酸素量From(76)
            saiYozonSansoRyo1TextBox.TabStop =
                // 再採水溶存酸素量To(77)
            saiYozonSansoRyo2TextBox.TabStop =
                // 再採水溶存酸素量評価(78)
                // 再採水２次透視度（度）(79)
            saiNijiToshidoTextBox.TabStop =
                // 再採水２次透視度評価(81)
                // 再採水透視度（度）(82)
            saiToshidoTextBox.TabStop =
                // 再採水透視度評価(84)
                // 再採水残留塩素(85)
            saiZanryuensoTextBox.TabStop =
                // 再採水残留塩素評価(86)
                // 再採水ＢＯＤ(87)
            saiBODTextBox.TabStop =
                // 再採水ＢＯＤ評価(89)
                // 再採水塩化物イオン(90)
            saiEnkabutsuIonTextBox.TabStop =
                // 再採水汚泥沈殿率(93)
            saiOdeiChindenRitsuTextBox.TabStop =
                // 再採水汚泥沈殿率評価(95)
                // 再採水MLSS(96)
            saiMLSSTextBox.TabStop =
                // 再採水水質依頼No(98)
                //saiSuishitsuIraiNoTextBox.TabStop =
                // 保守点検-月毎(103)
                //hosyuTenkenTsukiTextBox.TabStop = 
                // 保守点検-週毎(104)
                //hosyuTenkenNumTextBox.TabStop =
                // 清掃-回/年(108)
                //seisoCountTextBox.TabStop = 
                // 清掃年(109)
            seisoDtNenTextBox.TabStop =
                // 清掃月(110)
            seisoDtTsukiTextBox.TabStop =
                // 清掃日(111)
            seisoDtHiTextBox.TabStop =
                // 点検担当者名(112)
            tenkenTantosyaNmTextBox.TabStop =
                // 手書きメモ(118)
            memoInputTextBox.TabStop =
                // 検査付加情報(119)

            // v1.11 ADD start
            ATUBODTextBox.TabStop =
            saiATUBODTextBox.TabStop = _dispMode == DispMode.Display ? false : true;
            // v1.11 ADD End
            #endregion

            #region visible property
            // 検査完了ボタン(25)
            kensaFinishButton.Visible =
                // 水質検査所見ボタン(99)
            suishitsuKensaSyokenButton.Visible =
                // 書類検査所見ボタン(113)
            syoruiKensaSyokenButton.Visible =
                // 検査付加情報追加ボタン(124)
            kensaFukaJohoAddButton.Visible =
                // 検査付加情報変更ボタン(125)
            kensaFukaJohoModButton.Visible =
                // 検査付加情報削除ボタン(126)
            kensaFukaJohoDelButton.Visible =
                // FAX送付（メーカー）ボタン(127)
            faxSofuMakerButton.Visible =
                // FAX送付（保点業者）ボタン(128)
            faxSofuHotenButton.Visible =
                // FAX送付（工事業者）ボタン(129)
            faxSofuKojiButton.Visible =
                // FAX送付（保健所）ボタン(130)
            faxSofuHokenshoButton.Visible =
                // 手入力ボタン(243)
            manualInputButton.Visible =
                // 登録ボタン(244)
            entryButton.Visible = _dispMode == DispMode.Display ? false : true;
            #endregion

            // 固定で使用不可（読み取り専用）
            BODTextBox.Enabled = false;
            BODComboBox.Enabled = false;
            enkabutsuIonTextBox.Enabled = false;
            enkabutsuIonComboBox.Enabled = false;
            ATUBODTextBox.Enabled = false;
            ATUBODComboBox.Enabled = false;
            saiBODTextBox.Enabled = false;
            saiBODComboBox.Enabled = false;
            saiEnkabutsuIonTextBox.Enabled = false;
            saiEnkabutsuIonComboBox.Enabled = false;
            saiATUBODTextBox.Enabled = false;
            saiATUBODComboBox.Enabled = false;
        }

        #endregion

        #region SetComboBoxSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetComboBoxSource
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetComboBoxSource()
        {
            DataTable table16 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_016);
            DataTable table17 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_017);
            DataTable table27 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_027);
            DataTable table28 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_028);
            DataTable table25 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_025);
            DataTable table26 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_026);
            // v1.13
            DataTable table67 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_067);
            DataTable table68 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_068);

            #region ConstKbn16, ConstKbn17
            // 判定(34)
            Utility.Utility.SetComboBoxList(hanteiComboBox, table16, "ConstNm", "ConstValue", true);
            // 行政報告レベル(35)
            Utility.Utility.SetComboBoxList(gyoseiHokokuLevelComboBox, table17, "ConstNm", "ConstValue", true);
            #endregion

            #region ConstKbn27
            // ２次透視度（数値範囲）(55)
            Utility.Utility.SetComboBoxList(nijiToshidoComboBox, table27, "ConstNm", "ConstValue", true);
            // 透視度（数値範囲）(58)
            Utility.Utility.SetComboBoxList(toshidoComboBox, table27, "ConstNm", "ConstValue", true);
            // ＢＯＤ（数値範囲）(63)
            Utility.Utility.SetComboBoxList(BODComboBox, table27, "ConstNm", "ConstValue", true);
            // 塩化物イオン（数値範囲）(66)
            Utility.Utility.SetComboBoxList(enkabutsuIonComboBox, table27, "ConstNm", "ConstValue", true);
            // 再採水２次透視度（度）(79)
            Utility.Utility.SetComboBoxList(saiNijiToshidoComboBox, table27, "ConstNm", "ConstValue", true);
            // 再採水透視度（数値範囲）(83)
            Utility.Utility.SetComboBoxList(saiToshidoComboBox, table27, "ConstNm", "ConstValue", true);
            // 再採水ＢＯＤ（数値範囲）(88)
            Utility.Utility.SetComboBoxList(saiBODComboBox, table27, "ConstNm", "ConstValue", true);
            // 再採水塩化物イオン（数値範囲）(91)
            Utility.Utility.SetComboBoxList(saiEnkabutsuIonComboBox, table27, "ConstNm", "ConstValue", true);

            // v1.13 ADD Start
            // ATUBOD（数値範囲）(248)
            Utility.Utility.SetComboBoxList(ATUBODComboBox, table27, "ConstNm", "ConstValue", true);
            // 再採水ATUBOD（数値範囲）(250)
            Utility.Utility.SetComboBoxList(saiATUBODComboBox, table27, "ConstNm", "ConstValue", true);
            // v1.13 ADD End
            #endregion

            #region ConstKbn28
            // 汚泥沈殿率（数値範囲）(69)
            Utility.Utility.SetComboBoxList(odeiChindenRitsuComboBox, table28, "ConstNm", "ConstValue", true);
            // 再採水汚泥沈殿率（数値範囲）(94)
            Utility.Utility.SetComboBoxList(saiOdeiChindenRitsuComboBox, table28, "ConstNm", "ConstValue", true);
            #endregion

            #region ConstKbn25
            // 保守点検-記録有無(100)
            Utility.Utility.SetComboBoxList(hosyuTenken1ComboBox, table25, "ConstNm", "ConstValue", true);
            // 保守点検-内容(102)
            Utility.Utility.SetComboBoxList(hosyuTenken3ComboBox, table25, "ConstNm", "ConstValue", true);
            // 清掃-記録有無(105)
            Utility.Utility.SetComboBoxList(seiso1ComboBox, table25, "ConstNm", "ConstValue", true);
            // 清掃-内容(107)
            Utility.Utility.SetComboBoxList(seiso3ComboBox, table25, "ConstNm", "ConstValue", true);
            #endregion

            #region ConstKbn26
            // 保守点検-回数(101)
            Utility.Utility.SetComboBoxList(hosyuTenken2ComboBox, table26, "ConstNm", "ConstValue", true);
            // 清掃-回数(106)
            Utility.Utility.SetComboBoxList(seiso2ComboBox, table26, "ConstNm", "ConstValue", true);
            #endregion

            #region ConstKbn67, ConstKbn68
            // v1.13 ADD Start
            // 保守点検－実施(251)
            Utility.Utility.SetComboBoxList(hosyuTenkenJisshiComboBox, table67, "ConstNm", "ConstValue", false);
            // 保守点検－規定(252)
            Utility.Utility.SetComboBoxList(hosyuTenkenKiteiComboBox, table67, "ConstNm", "ConstValue", false);
            // 清掃－規定(253)
            Utility.Utility.SetComboBoxList(seisoKiteiComboBox, table68, "ConstNm", "ConstValue", false);
            // v1.13 ADD End
            #endregion
        }
        #endregion

        #region SetBikoText
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetBikoText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkNumber"></param>
        /// <param name="targetLabel"></param>
        /// <param name="kbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetBikoText(string checkNumber, Label targetLabel, Utility.SuishitsuUtility.SuishitsuKensaKbn kbn)
        {
            int res = Utility.SuishitsuUtility.SuishitsuHyokaHantei(
                _kensaIraiTable[0].IsKensaIraiShorihoshikiKbnNull() ? string.Empty : _kensaIraiTable[0].KensaIraiShorihoshikiKbn,
                _kensaIraiTable[0].IsKensaIraiBODShoriSeinoNull() ? string.Empty : _kensaIraiTable[0].KensaIraiBODShoriSeino,
                kbn,
                checkNumber);

            // Get 備考
            string bikoText = string.Empty;
            switch (res)
            {
                case 1: // ○
                    bikoText = MARU;
                    break;
                case 2: // △
                    bikoText = SANKAKU;
                    break;
                case 3: // ×
                    bikoText = BATSU;
                    break;
                case 4: // －
                    bikoText = HIKU;
                    break;
                case 0: // エラー
                default:
                    break;
            }

            // Label text
            targetLabel.Text = bikoText;
        }
        #endregion

        #region SetBikoTextForToshidoTextBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetBikoTextForToshidoTextBox
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetTextBox"></param>
        /// <param name="targetComboBox"></param>
        /// <param name="targetLabel"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetBikoTextForToshidosTextBox(ZTextBox targetTextBox, ComboBox targetComboBox, Label targetLabel)
        {
            if (string.IsNullOrEmpty(targetTextBox.Text))
            {
                targetTextBox.Text = string.Empty;
                targetComboBox.SelectedIndex = 0;
            }
            else
            {
                decimal saiNijiToshiso = Convert.ToDecimal(targetTextBox.Text);

                if (saiNijiToshiso == 0m)
                {
                    targetTextBox.Text = 0m.ToString("N1");
                    targetComboBox.SelectedIndex = 0;
                }
                else
                {
                    if (saiNijiToshiso >= 30)
                    {
                        targetTextBox.Text = "30";
                        targetComboBox.SelectedIndex = 1; // 以上
                    }
                    else if (saiNijiToshiso <= 1)
                    {
                        targetTextBox.Text = "1";
                        targetComboBox.SelectedIndex = 2; // 以下
                    }
                    else
                    {
                        targetComboBox.SelectedItem = string.Empty;
                    }
                }
            }

            SetBikoText(targetTextBox.Text, targetLabel, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido);
        }
        #endregion

        #region DataCheck

        #region InputCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InputCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/28  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool InputCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            if (!string.IsNullOrEmpty(seisoDtNenTextBox.Text)
                || !string.IsNullOrEmpty(seisoDtTsukiTextBox.Text)
                || !string.IsNullOrEmpty(seisoDtHiTextBox.Text))
            {
                //string seisoYear = Utility.DateUtility.ConvertFromWareki(seisoDtNenTextBox.Text, "yyyy");
                //string seisoDt = string.Concat(seisoYear, "/", seisoDtTsukiTextBox.Text, "/", seisoDtHiTextBox.Text);
                string seisoDt = string.Concat(seisoDtNenTextBox.Text, "/", seisoDtTsukiTextBox.Text, "/", seisoDtHiTextBox.Text);

                // Is valid a date time?
                DateTime validSeisoDt;
                if (!DateTime.TryParse(seisoDt, out validSeisoDt))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "清掃日は日付の書式で入力して下さい。");
                    return false;
                }
            }

            // 所見結果の行数チェック
            {
                int lastIndex = 0;
                for (int index = _syokenKekkaControl.Count - 1; index >= 0; index--)
                {
                    if (!string.IsNullOrEmpty(_syokenKekkaControl[index].ShokenKekkaKbn))
                    {
                        // 所見 or 所見補足のある最終行
                        lastIndex = index;
                        break;
                    }
                }

                if (lastIndex > SHOKEN_KEKKA_MAX_COUNT - 1)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("所見結果が{0}行を超えて設定されています。{1}行以内に編集してください。", SHOKEN_KEKKA_MAX_COUNT, SHOKEN_KEKKA_MAX_COUNT));
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region MemoConfirmCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MemoConfirmCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/28  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool MemoConfirmCheck()
        {
            // メモ確認(16) is off?
            if (memoKakuninCheckBox.Checked == false)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "メモ確認がチェックされてません。\r\nメモ項目を確認後、チェックして下さい。");
                return false;
            }

            return true;
        }
        #endregion

        #region 検査完了内容チェック (Kensa complete check)

        #region KensaCompleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KensaCompleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/28  AnhNV　　    新規作成
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// 2015/01/29  小松　　    要望対応:#8559(検査結果値の評価、表示等の制御)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool KensaCompleteCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 判定(34)
            if (hanteiComboBox.SelectedIndex <= 0) { errMsg.AppendLine("判定を選択して下さい。"); }

            if (sokuteiFunoComboBox.SelectedItem.ToString() != SOKUTEI)
            {
                if (!IsSaiSaisuiTarget() && !Is11JoFollowTarget())
                {
                    // スクリーニング、ス＋フの場合は、1回目は水質検査課の結果なので、チェックは不要
                    // フォローの場合も、1回目は水質検査課の結果なので、チェックは不要
                    // それ以外の場合のみチェックを行う

                    // pH(49)
                    if (!BmsCheck(pHTextBox, pHHyokaLabel)) { errMsg.AppendLine("pHを入力して下さい。"); }
                    // pH評価(50)
                    if (!checkSuishitsuHantei(pHTextBox, pHHyokaLabel)) { errMsg.AppendLine("pHの評価を行って下さい。"); }

                    // 溶存酸素量From(51) + 溶存酸素量To(52)
                    if (!BmsCheck(yozonSansoRyo1TextBox, yozonSansoRyoHyokaLabel)
                        || !BmsCheck(yozonSansoRyo2TextBox, yozonSansoRyoHyokaLabel)) { errMsg.AppendLine("溶存酸素量を入力して下さい。"); }
                    // 溶存酸素量評価(53)
                    if (!checkSuishitsuHantei(yozonSansoRyo1TextBox, yozonSansoRyoHyokaLabel)) { errMsg.AppendLine("溶存酸素量の評価を行って下さい。"); }
                    if (!checkSuishitsuHantei(yozonSansoRyo2TextBox, yozonSansoRyoHyokaLabel)) { errMsg.AppendLine("溶存酸素量の評価を行って下さい。"); }

                    // ２次透視度（度）(54)
                    if (!BmsCheck(nijiToshidoTextBox, saiNijiToshidoHyokaLabel)) { errMsg.AppendLine("２次透視度を入力して下さい。"); }
                    // ２次透視度（数値範囲）(55)

                    // ２次透視度評価(56)
                    if (!checkSuishitsuHantei(nijiToshidoTextBox, saiNijiToshidoHyokaLabel)) { errMsg.AppendLine("２次透視度の評価を行って下さい。"); }

                    // 透視度（度）(57)
                    if (!BmsCheck(toshidoTextBox, toshidoHyokaLabel)) { errMsg.AppendLine("透視度を入力して下さい。"); }
                    // 透視度（数値範囲）(58)

                    // 透視度評価(59)
                    if (!checkSuishitsuHantei(toshidoTextBox, toshidoHyokaLabel)) { errMsg.AppendLine("透視度の評価を行って下さい。"); }

                    // 残留塩素(60)
                    if (!BmsCheck(zanryuensoTextBox, zanryuensoHyokaLabel)) { errMsg.AppendLine("残留塩素を入力して下さい。"); }
                    // 残留塩素評価(61)
                    if (!checkSuishitsuHantei(zanryuensoTextBox, zanryuensoHyokaLabel)) { errMsg.AppendLine("残留塩素の評価を行って下さい。"); }

                    // ＢＯＤ(62)
                    if (!BmsCheck(BODTextBox, BODHyokaLabel)) { errMsg.AppendLine("ＢＯＤを入力して下さい。"); }
                    // ＢＯＤ（数値範囲）(63)

                    // ＢＯＤ評価(64)
                    if (!checkSuishitsuHantei(BODTextBox, BODHyokaLabel)) { errMsg.AppendLine("ＢＯＤの評価を行って下さい。"); }

                    // 塩化物イオン(65)
                    if (!BmsCheck(enkabutsuIonTextBox, enkabutsuIonHyokaLabel)) { errMsg.AppendLine("塩化物イオンを入力して下さい。"); }
                    // 塩化物イオン（数値範囲）(66)

                    // 塩化物イオン評価(67)
                    if (!checkSuishitsuHantei(enkabutsuIonTextBox, enkabutsuIonHyokaLabel)) { errMsg.AppendLine("塩化物イオンの評価を行って下さい。"); }

                    // 汚泥沈殿率(68)
                    if (!BmsCheck(odeiChindenRitsuTextBox, odeiChindenRitsuHyokaLabel)) { errMsg.AppendLine("汚泥沈殿率を入力して下さい。"); }
                    // 汚泥沈殿率（数値範囲）(69)

                    // 汚泥沈殿率評価(70)
                    if (!checkSuishitsuHantei(odeiChindenRitsuTextBox, odeiChindenRitsuHyokaLabel)) { errMsg.AppendLine("汚泥沈殿率の評価を行って下さい。"); }

                    // MLSS(71)

                    // 測定不能(72)

                    // 水質依頼No(73)
                }

                // 20150107 habu 再採水対象のみチェックを行う
                if (IsSaiSaisuiTarget())
                {
                    // 再採水pH(74)
                    if (!BmsCheck(saiPHTextBox, saiPHHyokaLabel)) { errMsg.AppendLine("pHを入力して下さい。"); }
                    // 再採水pH評価(75)
                    if (!checkSuishitsuHantei(saiPHTextBox, saiPHHyokaLabel)) { errMsg.AppendLine("pHの評価を行って下さい。"); }

                    // 再採水溶存酸素量From(76) + 再採水溶存酸素量To(77)
                    if (!BmsCheck(saiYozonSansoRyo1TextBox, saiYozonSansoRyoHyokaLabel)
                        || !BmsCheck(saiYozonSansoRyo2TextBox, saiYozonSansoRyoHyokaLabel)) { errMsg.AppendLine("溶存酸素量を入力して下さい。"); }
                    // 再採水溶存酸素量評価(78)
                    if (!checkSuishitsuHantei(saiYozonSansoRyo1TextBox, saiYozonSansoRyoHyokaLabel)) { errMsg.AppendLine("溶存酸素量の評価を行って下さい。"); }
                    if (!checkSuishitsuHantei(saiYozonSansoRyo2TextBox, saiYozonSansoRyoHyokaLabel)) { errMsg.AppendLine("溶存酸素量の評価を行って下さい。"); }

                    // 再採水２次透視度（度）(79)
                    if (!BmsCheck(saiNijiToshidoTextBox, saiNijiToshidoHyokaLabel)) { errMsg.AppendLine("２次透視度を入力して下さい。"); }
                    // 再採水２次透視度（数値範囲）(80)

                    // 再採水２次透視度評価(81)
                    if (!checkSuishitsuHantei(saiNijiToshidoTextBox, saiNijiToshidoHyokaLabel)) { errMsg.AppendLine("２次透視度の評価を行って下さい。"); }

                    // 再採水透視度（度）(82)
                    if (!BmsCheck(saiToshidoTextBox, saiToshidoHyokaLabel)) { errMsg.AppendLine("透視度を入力して下さい。"); }
                    // 再採水透視度（数値範囲）(83)

                    // 再採水透視度評価(84)
                    if (!checkSuishitsuHantei(saiToshidoTextBox, saiToshidoHyokaLabel)) { errMsg.AppendLine("透視度の評価を行って下さい。"); }

                    // 再採水残留塩素(85)
                    if (!BmsCheck(saiZanryuensoTextBox, saiZanryuensoHyokaLabel)) { errMsg.AppendLine("残留塩素を入力して下さい。"); }
                    // 再採水残留塩素評価(86)
                    if (!checkSuishitsuHantei(saiZanryuensoTextBox, saiZanryuensoHyokaLabel)) { errMsg.AppendLine("残留塩素の評価を行って下さい。"); }

                    // 再採水ＢＯＤ(87)
                    if (!BmsCheck(saiBODTextBox, saiBODHyokaLabel)) { errMsg.AppendLine("ＢＯＤを入力して下さい。"); }
                    // 再採水ＢＯＤ（数値範囲）(88)

                    // 再採水ＢＯＤ評価(89)
                    if (!checkSuishitsuHantei(saiBODTextBox, saiBODHyokaLabel)) { errMsg.AppendLine("ＢＯＤの評価を行って下さい。"); }

                    // 再採水塩化物イオン(90)
                    if (!BmsCheck(saiEnkabutsuIonTextBox, saiEnkabutsuIonHyokaLabel)) { errMsg.AppendLine("塩化物イオンを入力して下さい。"); }
                    // 再採水塩化物イオン（数値範囲）(91)

                    // 再採水塩化物イオン評価(92)
                    if (!checkSuishitsuHantei(saiEnkabutsuIonTextBox, saiEnkabutsuIonHyokaLabel)) { errMsg.AppendLine("塩化物イオンの評価を行って下さい。"); }

                    // 再採水汚泥沈殿率(93)
                    if (!BmsCheck(saiOdeiChindenRitsuTextBox, saiOdeiChindenRitsuHyokaLabel)) { errMsg.AppendLine("汚泥沈殿率を入力して下さい。"); }
                    // 再採水汚泥沈殿率評価（再採水）(95)
                    if (!checkSuishitsuHantei(saiOdeiChindenRitsuTextBox, saiOdeiChindenRitsuHyokaLabel)) { errMsg.AppendLine("汚泥沈殿率の評価を行って下さい。"); }
                }
            }

            // An error occured?
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region BmsCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： BmsCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetTextBox">結果値</param>
        /// <param name="targetLabel">判定</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool BmsCheck(ZTextBox targetTextBox, Label targetLabel)
        {
            if ((targetLabel.Text == BATSU || targetLabel.Text == MARU || targetLabel.Text == SANKAKU)
                && string.IsNullOrEmpty(targetTextBox.Text.Trim()))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region checkSuishitsuHantei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： checkSuishitsuHantei
        /// <summary>
        /// 判定が行われているかチェック
        /// </summary>
        /// <param name="targetTextBox">結果値</param>
        /// <param name="targetLabel">判定</param>
        /// <returns>true:OK/false:判定無で結果値に有の場合は不整合NG</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool checkSuishitsuHantei(ZTextBox targetTextBox, Label targetLabel)
        {
            if (string.IsNullOrEmpty(targetLabel.Text.Trim())
                && !string.IsNullOrEmpty(targetTextBox.Text.Trim()))
            {
                // 判定無で結果値に有の場合は不整合
                return false;
            }

            return true;
        }
        #endregion

        #endregion

        #region KensaCompleteConfirm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KensaCompleteConfirm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  AnhNV　　    新規作成
        /// 2015/01/07  habu　　    判定チェックを修正(×、○ -> ×、△)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool KensaCompleteConfirm()
        {
            StringBuilder warnMsg = new StringBuilder();
            bool isWarn = false;

            // 測定不能(72) != "測定不能" and 判定(34) == 1
            if (sokuteiFunoComboBox.SelectedItem.ToString() != SOKUTEI && hanteiComboBox.SelectedValue.ToString() == "1")
            {
                // pH評価(50)
                if (pHHyokaLabel.Text == BATSU) { isWarn = true; }
                // 透視度評価(59)
                if (toshidoHyokaLabel.Text == BATSU || toshidoHyokaLabel.Text == SANKAKU) { isWarn = true; }
                // ＢＯＤ評価(64)
                if (BODHyokaLabel.Text == BATSU || BODHyokaLabel.Text == SANKAKU) { isWarn = true; }

                // 20150107 habu 再採水対象のみチェックを行う
                if (IsSaiSaisuiTarget())
                {
                    // 再採水pH評価(75)
                    if (saiPHHyokaLabel.Text == BATSU) { isWarn = true; }
                    // 再採水透視度評価(84)
                    if (saiToshidoHyokaLabel.Text == BATSU || saiToshidoHyokaLabel.Text == SANKAKU) { isWarn = true; }
                    // 再採水ＢＯＤ評価(89)
                    if (saiBODHyokaLabel.Text == BATSU || saiBODHyokaLabel.Text == SANKAKU) { isWarn = true; }
                }
            }

            // Confirmation
            if (isWarn)
            {
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "判定が正しいか確認して下さい。") != DialogResult.Yes)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region UpdateConfirmForKensaComplete
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateConfirmForKensaComplete
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UpdateConfirmForKensaComplete()
        {
            if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査完了に更新します。よろしいですか？") == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region CheckForTab27
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckForTab27
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckForTab27()
        {
            double yozon1, yozon2;
            Double.TryParse(yozonSansoRyo1TextBox.Text, out yozon1);
            Double.TryParse(yozonSansoRyo2TextBox.Text, out yozon2);

            // 溶存酸素量From(51) must be less than 溶存酸素量To(52)!
            if (yozon1 > yozon2)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。溶存酸素量の大小関係を確認して下さい。");
                return false;
            }

            return true;
        }
        #endregion

        #region IsSaiSaisuiTarget
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/07  habu　　    新規作成
        /// </history>
        private bool IsSaiSaisuiTarget()
        {
            string hoteiKbn　= TypeUtility.GetString(_kensaIraiTable[0][_kensaIraiTable.KensaIraiHoteiKbnColumn.ColumnName]);
            string scrKbn = TypeUtility.GetString(_kensaIraiTable[0][_kensaIraiTable.KensaIraiScreeningKbnColumn.ColumnName]);

            // 11条水質の、スクリーニング or スクリーニング+フォローのみ再採水対象とする
            if (hoteiKbn != Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU)
            {
                return false;
            }
            if (scrKbn != Utility.Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING
                && scrKbn != Utility.Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING_FOLLOW)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Is11JoFollowTarget
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29  小松　　    要望対応:#8559(検査結果値の評価、表示等の制御)
        /// </history>
        private bool Is11JoFollowTarget()
        {
            string hoteiKbn = TypeUtility.GetString(_kensaIraiTable[0][_kensaIraiTable.KensaIraiHoteiKbnColumn.ColumnName]);
            string scrKbn = TypeUtility.GetString(_kensaIraiTable[0][_kensaIraiTable.KensaIraiScreeningKbnColumn.ColumnName]);

            // 11条水質のフォローかの判定
            if (hoteiKbn == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU &&
                scrKbn == Utility.Constants.ScreeningKbnConstant.SCREENING_KBN_FOLLOW)
            {
                return true;
            }

            return false;
        }
        #endregion

        #endregion

        #region DB Update

        #region CreateKensaIraiTblDataTableForUpdateStatus
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDataTableForUpdateStatus
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  AnhNV　　    新規作成
        /// 2014/11/11  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDataTableForUpdateStatus(KensaIraiTblDataSet.KensaIraiTblDataTable table)
        {
            // ステータス区分
            table[0].KensaIraiStatusKbn = "65";
            // 判定区分
            table[0].KensaIraiHanteiKbn = Convert.ToString(hanteiComboBox.SelectedValue);
            // 更新者
            table[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            table[0].UpdateTarm = Dns.GetHostName();

            return table;
        }
        #endregion

        #region CreateKensaIraiTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.11
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDataTableUpdate(KensaIraiTblDataSet.KensaIraiTblDataTable table, string user, string host)
        {
            // メモ確認フラグ(16)
            table[0].KensaIraiMemoKakuninFlg = memoKakuninCheckBox.Checked ? "1" : "0";
            // 発行区分９(35)
            table[0].KensaIraiGyoseiHokokuLevel = gyoseiHokokuLevelComboBox.SelectedValue != null ? gyoseiHokokuLevelComboBox.SelectedValue.ToString() : string.Empty;
            // 嵩上げ(36)
            table[0].KensaIraiKasaage = kasaageNumTextBox.Text;
            // 流入滞留(37)
            table[0].KensaIraiRyunyuTairyu = tairyu43TextBox.Text;
            // 放流滞留(38)
            table[0].KensaIraiHoryuTairyu = tairyu44TextBox.Text;
            // 保守点検（内容）(102)
            table[0].KensaIraiHoshuTenkenNiayo = Convert.ToString(hosyuTenken3ComboBox.SelectedValue);
            // 点検回数月毎(103)
            //table[0].KensaIraiTenkenKaisuTsukiGoto = hosyuTenkenTsukiTextBox.Text;
            // 点検回数週毎(104)
            //table[0].KensaIraiTenkenKaisuShuGoto = hosyuTenkenNumTextBox.Text;
            // ブロワ１(40)
            table[0].KensaIraiBurowa1 = burowa1TextBox.Text;
            // ブロワ規定風量１(41)
            table[0].KensaIraiBurowaKiteFuryo1 = burowaKitei1TextBox.Text;
            // ブロワ設置風量１(42)
            table[0].KensaIraiBurowaSetchiFuryo1 = burowaSetchi1TextBox.Text;
            // ブロワ２(43)
            table[0].KensaIraiBurowa2 = burowa2TextBox.Text;
            // ブロワ規定風量２(44)
            table[0].KensaIraiBurowaKiteFuryo2 = burowaKitei2TextBox.Text;
            // ブロワ設置風量２(45)
            table[0].KensaIraiBurowaSetchiFuryo2 = burowaSetchi2TextBox.Text;
            // ブロワ３(46)
            table[0].KensaIraiBurowa3 = burowa3TextBox.Text;
            // ブロワ規定風量３(47)
            table[0].KensaIraiBurowaKiteFuryo3 = burowaKitei3TextBox.Text;
            // ブロワ設置風量３(48)
            table[0].KensaIraiBurowaSetchiFuryo3 = burowaSetchi3TextBox.Text;
            // 書類点検担当者名(112)
            table[0].KensaIraiKensaTantoshaNm = tenkenTantosyaNmTextBox.Text;
            // 更新者
            table[0].UpdateUser = user;
            // 更新端末
            table[0].UpdateTarm = host;

            return table;
        }
        #endregion

        #region CreateKensaKekkaTblDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaKekkaTblDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.11
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaKekkaTblDataSet.KensaKekkaTblDataTable CreateKensaKekkaTblDataTableInsert(DateTime now, string user, string host)
        {
            KensaKekkaTblDataSet.KensaKekkaTblDataTable table = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();
            KensaKekkaTblDataSet.KensaKekkaTblRow newRow = table.NewKensaKekkaTblRow();

            // 検査依頼法定区分 
            newRow.KensaKekkaIraiHoteiKbn = this._kensaIraiHoteiKbn;
            // 検査依頼保健所コード(2)
            newRow.KensaKekkaIraiHokenjoCd = kyokaiNo1TextBox.Text;
            // 検査依頼年度 (3)
            newRow.KensaKekkaIraiNendo = Utility.DateUtility.ConvertFromWareki(kyokaiNo2TextBox.Text, "yyyy");
            // 検査依頼連番 (4)
            newRow.KensaKekkaIraiRenban = kyokaiNo3TextBox.Text;
            // 判定(34)
            newRow.KensaKekkaHantei = hanteiComboBox.SelectedValue == null ? string.Empty : hanteiComboBox.SelectedValue.ToString();
            // 水素イオン濃度(49)
            double pH;
            if (Double.TryParse(pHTextBox.Text, out pH))
            {
                newRow.KensaKekkaSuisoIonNodo = pH;
            }
            // 水素イオン濃度ー判定(50)
            newRow.KensaKekkaSuisoIonNodoHantei = GetKomokuHanteiByHanteiLabel(pHHyokaLabel.Text);
            // 溶存酸素量１(51)
            double yozon1;
            if (Double.TryParse(yozonSansoRyo1TextBox.Text, out yozon1))
            {
                newRow.KensaKekkaYozonSansoryo1 = yozon1;
            }
            // 溶存酸素量２(52)
            double yozon2;
            if (Double.TryParse(yozonSansoRyo2TextBox.Text, out yozon2))
            {
                newRow.KensaKekkaYozonSansoryo2 = yozon2;
            }
            // 溶存酸素量ー判定(53)
            newRow.KensaKekkaYozonSansoryoHantei = GetKomokuHanteiByHanteiLabel(yozonSansoRyoHyokaLabel.Text);
            // 透視度２次処理水(54)
            double niji;
            if (Double.TryParse(nijiToshidoTextBox.Text, out niji))
            {
                newRow.KensaKekkaToshido2jiSyorisui = niji;
            }
            // 透視度２２次処理水(55)
            newRow.KensaKekkaToshido22jiSyorisui = nijiToshidoComboBox.SelectedValue == null ? string.Empty : nijiToshidoComboBox.SelectedValue.ToString();
            // 透視度ー判定２次処理水(56)
            newRow.KensaKekkaToshidoHantei2jiSyorisui = GetKomokuHanteiByHanteiLabel(nijiToshidoHyokaLabel.Text);
            // 透視度(57)
            double toshido;
            if (Double.TryParse(toshidoTextBox.Text, out toshido))
            {
                newRow.KensaKekkaToshido = toshido;
            }
            // 透視度２(58)
            newRow.KensaKekkaToshido2 = toshidoComboBox.SelectedValue == null ? string.Empty : toshidoComboBox.SelectedValue.ToString();
            // 透視度ー判定(59)
            newRow.KensaKekkaToshidoHantei = GetKomokuHanteiByHanteiLabel(toshidoHyokaLabel.Text);
            // 残留塩素濃度(60)
            double zanryu;
            if (Double.TryParse(zanryuensoTextBox.Text, out zanryu))
            {
                newRow.KensaKekkaZanryuEnsoNodo = zanryu;
            }
            // 残留塩素濃度ー判定(61)
            newRow.KensaKekkaZanryuEnsoNodoHantei = GetKomokuHanteiByHanteiLabel(zanryuensoHyokaLabel.Text);
            // 生物化学酸素要求量(62)
            double BOD;
            if (Double.TryParse(BODTextBox.Text, out BOD))
            {
                newRow.KensaKekkaBOD = BOD;
            }
            // 生物化学酸素要求量２(63)
            newRow.KensaIraiBOD2 = BODComboBox.SelectedValue == null ? string.Empty : BODComboBox.SelectedValue.ToString();
            // 生物化学酸素要求量ー判定(64)
            newRow.KensaKekkaBODHantei = GetKomokuHanteiByHanteiLabel(BODHyokaLabel.Text);
            // 塩素イオン濃度(65)
            //newRow.KensaKekkaEnsoIonNodo = enkabutsuIonTextBox.Text;
            decimal ion;
            if (Decimal.TryParse(enkabutsuIonTextBox.Text, out ion))
            {
                // 塩素イオン濃度(65)
                newRow.KensaKekkaEnsoIonNodo = ion;
            }
            // 塩素イオン濃度２(66)
            newRow.KensaIraiEnsoIonNodo2 = enkabutsuIonComboBox.SelectedValue == null ? string.Empty : enkabutsuIonComboBox.SelectedValue.ToString();
            // 塩素イオン濃度ー判定(67)
            newRow.KensaKekkaEnsoIonNodoHantei = GetKomokuHanteiByHanteiLabel(enkabutsuIonHyokaLabel.Text);
            // 汚泥沈殿率(68)
            //newRow.KensaKekkaOdeiChindenritsu = odeiChindenRitsuTextBox.Text;
            decimal odei;
            if (Decimal.TryParse(odeiChindenRitsuTextBox.Text, out odei))
            {
                newRow.KensaKekkaOdeiChindenritsu = odei;
            }
            // 汚泥沈殿率２(69)
            newRow.KensaKekkaOdeiChindenritsu2 = odeiChindenRitsuComboBox.SelectedValue == null ? string.Empty : odeiChindenRitsuComboBox.SelectedValue.ToString();
            // 汚泥沈殿率ー判定(70)
            newRow.KensaKekkaOdeiChindenritsuHantei = GetKomokuHanteiByHanteiLabel(odeiChindenRitsuHyokaLabel.Text);
            // ＭＬＳＳ(71)
            //newRow.KensaKekkaMLSS = MLSSTextBox.Text;
            decimal mlss;
            if (Decimal.TryParse(MLSSTextBox.Text, out mlss))
            {
                newRow.KensaKekkaMLSS = mlss;
            }
            // 水質検査測定不能(72)
            newRow.KensaKekkaSuishitsuSokuteifuno = sokuteiFunoComboBox.SelectedValue == null ? string.Empty : sokuteiFunoComboBox.SelectedValue.ToString();
            // 水質検査依頼番号(73)
            newRow.KensaKekkaSuishitsuIraiNo = suishitsuIraiNoTextBox.Text;
            // 保守点検記録有無(100)
            newRow.KensaKekkaHoshuTenkenKirokuUmu = hosyuTenken1ComboBox.SelectedValue == null ? string.Empty : hosyuTenken1ComboBox.SelectedValue.ToString();
            // 保守点検回数(101)
            newRow.KensaKekkaHoshuTenkenKaisu = hosyuTenken2ComboBox.SelectedValue == null ? string.Empty : hosyuTenken2ComboBox.SelectedValue.ToString();
            // 清掃記録有無(105)
            newRow.KensaKekkaSeisoKirokuUmu = seiso1ComboBox.SelectedValue == null ? string.Empty : seiso1ComboBox.SelectedValue.ToString();
            // 清掃回数(106)
            newRow.KensaKekkaSeisoKaisu = seiso2ComboBox.SelectedValue == null ? string.Empty : seiso2ComboBox.SelectedValue.ToString();
            // 清掃内容(107)
            newRow.KensaKekkaSeisoNaiyo = seiso3ComboBox.SelectedValue == null ? string.Empty : seiso3ComboBox.SelectedValue.ToString();
            // 清掃回数（年）(108)
            //newRow.KensaKekkaSeisoKaisu = seisoCountTextBox.Text;

            DateTime seisoDt;
            //string seisoDtStr = string.Concat(Utility.DateUtility.ConvertFromWareki(seisoDtNenTextBox.Text, "yyyy"), seisoDtTsukiTextBox.Text.PadLeft(2, '0'), seisoDtHiTextBox.Text.PadLeft(2, '0'));
            string seisoDtStr = string.Concat(seisoDtNenTextBox.Text, seisoDtTsukiTextBox.Text.PadLeft(2, '0'), seisoDtHiTextBox.Text.PadLeft(2, '0'));
            if (DateTime.TryParseExact(seisoDtStr, "yyyyMMdd", null, DateTimeStyles.None, out seisoDt))
            {
                // 清掃日付(109), (110), (111)
                newRow.KensaKekkaSeisoDt = seisoDt.ToString("yyyyMMdd");
            }
            else
            {
                // 清掃日付(109), (110), (111)
                newRow.KensaKekkaSeisoDt = string.Empty;
            }
            // メモ手書き(118)
            newRow.KensaKekkaMemoTegaki = memoInputTextBox.Text;
            // v1.13 Add start
            // 保守点検-内容(102)
            newRow.KensaKekkaHoshuTenkenNaiyo = Convert.ToString(hosyuTenken3ComboBox.SelectedValue);
            // 保守点検-実施(251)
            newRow.KensaKekkaTenkenKaisuKbn = Convert.ToString(hosyuTenkenJisshiComboBox.SelectedValue);

            double atuBOD;
            if (Double.TryParse(ATUBODTextBox.Text, out atuBOD))
            {
                // ATUBOD(247)
                newRow.KensaKekkaATUBOD = atuBOD;
            }
            // ATUBOD２(248)
            newRow.KensaKekkaATUBOD2 = Convert.ToString(ATUBODComboBox.SelectedValue);
            // v1.13 Add end

            // 入力担当者
            newRow.KensaKekkaNyuryokuTanto = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

            // 登録日
            newRow.InsertDt = now;
            // 登録者
            newRow.InsertUser = user;
            // 登録端末
            newRow.InsertTarm = host;
            // 更新日
            newRow.UpdateDt = now;
            // 更新者
            newRow.UpdateUser = user;
            // 更新端末
            newRow.UpdateTarm = host;

            // 行を挿入
            table.AddKensaKekkaTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateGaikanKensaKekkaTblDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGaikanKensaKekkaTblDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable CreateGaikanKensaKekkaTblDataTableInsert(DateTime now, string user, string host)
        {
            GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable table = new GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable();
            string nendo = Utility.DateUtility.ConvertFromWareki(kyokaiNo2TextBox.Text, "yyyy");

            // Loop through チェック項目(39)
            string komokuHantei = string.Empty;
            foreach (CheckItemControl c in _checkItemControl)
            {
                komokuHantei = GetKomokuHanteiByHanteiLabel(c.HanteiKekka);

                // Skip handle for non-edit control
                if (string.IsNullOrEmpty(komokuHantei)) continue;

                GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow newRow = table.NewGaikanKensaKekkaTblRow();

                // 検査依頼法定区分 
                newRow.GaikanKensaKekkaIraiHoteiKbn = this._kensaIraiHoteiKbn;
                // 検査依頼保健所コード
                newRow.GaikanKensaKekkaIraiHokenjoCd = kyokaiNo1TextBox.Text;
                // 検査依頼年度 
                newRow.GaikanKensaKekkakuIraiNendo = nendo;
                // 検査依頼連番 
                newRow.GaikanKensaKekkaIraiRenban = kyokaiNo3TextBox.Text;
                // 外観検査結果連番
                newRow.GaikanKensaKekkaRenban = c.ItemNo.ToString();
                // 外観チェック項目コード
                newRow.GaikanKensaKekkaCheckKomokuCd = c.ItemNo.ToString().PadLeft(3, '0');
                // 外観チェック項目判定
                newRow.GaikanKensaKekkaCheckKomokuHantei = komokuHantei;
                // 登録日
                newRow.InsertDt = now;
                // 登録者
                newRow.InsertUser = user;
                // 登録端末
                newRow.InsertTarm = host;
                // 更新日
                newRow.UpdateDt = now;
                // 更新者
                newRow.UpdateUser = user;
                // 更新端末
                newRow.UpdateTarm = host;

                // 行を挿入
                table.AddGaikanKensaKekkaTblRow(newRow);
                // 行の状態を設定
                newRow.AcceptChanges();
                // 行の状態を設定（新規）
                newRow.SetAdded();
            }

            return table;
        }
        #endregion

        #region CreateSaiSaisuiTblDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaiSaisuiTblDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.11
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaiSaisuiTblDataSet.SaiSaisuiTblDataTable CreateSaiSaisuiTblDataTableInsert(DateTime now, string user, string host)
        {
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable table = new SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();
            SaiSaisuiTblDataSet.SaiSaisuiTblRow newRow = table.NewSaiSaisuiTblRow();

            // 検査依頼法定区分 
            newRow.SaiSaisuiIraiHoteiKbn = this._kensaIraiHoteiKbn;
            // 検査依頼保健所コード(2)
            newRow.SaiSaisuiIraiHokenjoCd = kyokaiNo1TextBox.Text;
            // 検査依頼年度 (3)
            newRow.SaiSaisuiIraiNendo = Utility.DateUtility.ConvertFromWareki(kyokaiNo2TextBox.Text, "yyyy");
            // 検査依頼連番 (4)
            newRow.SaiSaisuiIraiRrenban = kyokaiNo3TextBox.Text;
            // 水素イオン濃度(74)
            double saiPH;
            if (Double.TryParse(saiPHTextBox.Text, out saiPH))
            {
                newRow.SaiSaisuiSuisoIonNodo = saiPH;
            }
            // 水素イオン濃度ー判定(75)
            newRow.SaiSaisuiSuisoIonNodoHantei = GetKomokuHanteiByHanteiLabel(saiPHHyokaLabel.Text);
            // 溶存酸素量１(76)
            double saiYozon1;
            if (Double.TryParse(saiYozonSansoRyo1TextBox.Text, out saiYozon1))
            {
                newRow.SaiSaisuiYozonSansoryo1 = saiYozon1;
            }
            // 溶存酸素量２(77)
            double saiYozon2;
            if (Double.TryParse(saiYozonSansoRyo2TextBox.Text, out saiYozon2))
            {
                newRow.SaiSaisuiYozonSansoryo2 = saiYozon2;
            }
            // 溶存酸素量ー判定(78)
            newRow.SaiSaisuiYozonSansoryoHantei = GetKomokuHanteiByHanteiLabel(saiYozonSansoRyoHyokaLabel.Text);
            // 透視度（度）２次処理水(79)
            double saiNiji;
            if (Double.TryParse(saiNijiToshidoTextBox.Text, out saiNiji))
            {
                newRow.SaiSaisuiToshido2jishorisui = saiNiji;
            }
            // 透視度２２次処理水(80)
            newRow.SaiSaisuiToshido22jishorisui = saiNijiToshidoComboBox.SelectedValue == null ? string.Empty : saiNijiToshidoComboBox.SelectedValue.ToString();
            // 透視度ー判定２次処理水(81)
            newRow.SaiSaisuiToshidoHantei2jishorisui = GetKomokuHanteiByHanteiLabel(saiNijiToshidoHyokaLabel.Text);
            // 透視度（度）(82)
            double saiToshido;
            if (Double.TryParse(saiToshidoTextBox.Text, out saiToshido))
            {
                newRow.SaiSaisuiToshido = saiToshido;
            }
            // 透視度２(83)
            newRow.SaiSaisuiToshido2 = saiToshidoComboBox.SelectedValue == null ? string.Empty : saiToshidoComboBox.SelectedValue.ToString();
            // 透視度ー判定(84)
            newRow.SaiSaisuiToshidoHantei = GetKomokuHanteiByHanteiLabel(saiToshidoHyokaLabel.Text);
            // 残留塩素濃度(85)
            double saiZanryu;
            if (Double.TryParse(saiZanryuensoTextBox.Text, out saiZanryu))
            {
                newRow.SaiSaisuiZanryuEnsoNodo = saiZanryu;
            }
            // 残留塩素濃度ー判定(86)
            newRow.SaiSaisuiZanryuEnsoNodoHantei = GetKomokuHanteiByHanteiLabel(saiZanryuensoHyokaLabel.Text);
            // 生物化学酸素要求量(87)
            double saiBOD;
            if (Double.TryParse(saiBODTextBox.Text, out saiBOD))
            {
                newRow.SaiSaisuiBOD = saiBOD;
            }
            // 生物化学酸素要求量２(88)
            newRow.SaiSaisuiBOD2 = saiBODComboBox.SelectedValue == null ? string.Empty : saiBODComboBox.SelectedValue.ToString();
            // 生物化学酸素要求量ー判定(89)
            newRow.SaiSaisuiBODHantei = GetKomokuHanteiByHanteiLabel(saiBODHyokaLabel.Text);
            // 塩化イオン濃度(90)
            decimal saiEnka;
            if (Decimal.TryParse(saiEnkabutsuIonTextBox.Text, out saiEnka))
            {
                newRow.SaiSaisuiEnkaIonNodo = saiEnka;
            }
            // 塩化イオン濃度２(91)
            newRow.SaiSaisuiEnkaIonNodo2 = saiEnkabutsuIonComboBox.SelectedValue == null ? string.Empty : saiEnkabutsuIonComboBox.SelectedValue.ToString();
            // 塩化イオン濃度ー判定(92)
            newRow.SaiSaisuiEnkaIonNodoHantei = GetKomokuHanteiByHanteiLabel(saiEnkabutsuIonHyokaLabel.Text);
            // 汚泥沈殿率（％）(93)
            decimal saiOdei;
            if (Decimal.TryParse(saiOdeiChindenRitsuTextBox.Text, out saiOdei))
            {
                newRow.SaiSaisuiOdeichindenritsu = saiOdei;
            }
            // 汚泥沈殿率２(94)
            newRow.SaiSaisuiOdeichindenritsu2 = saiOdeiChindenRitsuComboBox.SelectedValue == null ? string.Empty : saiOdeiChindenRitsuComboBox.SelectedValue.ToString();
            // 汚泥沈殿率ー判定(95)
            newRow.SaiSaisuiOdeichindenritsuHantei = GetKomokuHanteiByHanteiLabel(saiOdeiChindenRitsuHyokaLabel.Text);
            // ＭＬＳＳ(96)
            decimal saiMLSS;
            if (Decimal.TryParse(saiMLSSTextBox.Text, out saiMLSS))
            {
                newRow.SaiSaisuiMLSS = saiMLSS;
            }
            // 水質検査（測定不能）(97)
            newRow.SaiSaisuiSuishitsuSokuteifuno = saiSokuteiFunoComboBox.SelectedValue == null ? string.Empty : saiSokuteiFunoComboBox.SelectedValue.ToString();
            // 水質検査依頼番号(98)
            newRow.SaiSaisuiSuishitsuIraiNo = saiSuishitsuIraiNoTextBox.Text;

            // v1.11 Add start
            double saiATU;
            if (Double.TryParse(saiATUBODTextBox.Text, out saiATU))
            {
                // ATUBOD
                newRow.SaiSaisuiATUBOD = saiATU;
            }
            // ATUBOD２
            newRow.SaiSaisuiATUBOD2 = Convert.ToString(saiATUBODComboBox.SelectedValue);
            // v1.11 Add end

            // 登録日
            newRow.InsertDt = now;
            // 登録者
            newRow.InsertUser = user;
            // 登録端末
            newRow.InsertTarm = host;
            // 更新日
            newRow.UpdateDt = now;
            // 更新者
            newRow.UpdateUser = user;
            // 更新端末
            newRow.UpdateTarm = host;

            // 行を挿入
            table.AddSaiSaisuiTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateJokasoMemoTblDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJokasoMemoTblDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoMemoTblDataSet.JokasoMemoTblDataTable CreateJokasoMemoTblDataTableInsert(DateTime now, string user, string host)
        {
            JokasoMemoTblDataSet.JokasoMemoTblDataTable table = new JokasoMemoTblDataSet.JokasoMemoTblDataTable();

            try
            {
                // Loop through メモ一覧(114)
                foreach (DataGridViewRow dgvr in memoInputDataGridView.Rows)
                {
                    JokasoMemoTblDataSet.JokasoMemoTblRow newRow = table.NewJokasoMemoTblRow();

                    // 浄化槽台帳保健所コード
                    newRow.JokasoMemoJokasoHokenjoCd = _kensaIraiTable[0].KensaIraiJokasoHokenjoCd;
                    // 浄化槽台帳登録年度
                    newRow.JokasoMemoJokasoTorokuNendo = _kensaIraiTable[0].KensaIraiJokasoTorokuNendo;
                    // 浄化槽台帳連番
                    newRow.JokasoMemoJokasoRenban = _kensaIraiTable[0].KensaIraiJokasoRenban;
                    // メモ大分類
                    newRow.JokasoMemoDaibunruiCd = Convert.ToString(dgvr.Cells[daibunruiCdColumn.Name].Value);
                    // メモコード
                    newRow.JokasoMemoCd = Convert.ToString(dgvr.Cells[memoCdColumn.Name].Value);
                    // 登録日
                    newRow.InsertDt = now;
                    // 登録者
                    newRow.InsertUser = user;
                    // 登録端末
                    newRow.InsertTarm = host;
                    // 更新日
                    newRow.UpdateDt = now;
                    // 更新者
                    newRow.UpdateUser = user;
                    // 更新端末
                    newRow.UpdateTarm = host;

                    if (!table.Rows.Contains(new string[]
                        {
                            _kensaIraiTable[0].KensaIraiJokasoHokenjoCd,
                            _kensaIraiTable[0].KensaIraiJokasoTorokuNendo,
                            _kensaIraiTable[0].KensaIraiJokasoRenban,
                            newRow.JokasoMemoDaibunruiCd,
                            newRow.JokasoMemoCd
                        }))
                    {
                        // 行を挿入
                        table.AddJokasoMemoTblRow(newRow);
                        // 行の状態を設定
                        newRow.AcceptChanges();
                        // 行の状態を設定（新規）
                        newRow.SetAdded();
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }

            return table;
        }
        #endregion

        #region CreateShokenKekkaDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokenKekkaDataTableInsert
        /// <summary>
        /// 所見結果、所見結果補足テーブルの両方のデータを作成
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/17  小松　　    小松
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateShokenKekkaDataTableInsert(ref ShokenKekkaTblDataSet.ShokenKekkaTblDataTable shokenDT, ref ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable hosokuDT, DateTime nowDt, string userNm, string hostNm)
        {
            // フッタ部の所見結果一覧から取得
            int shokenRenban = 0;
            int shokenHosokuRenban = 0;
            for (int index = 0; index < _syokenKekkaControl.Count; index++)
            {
                if (string.IsNullOrEmpty(_syokenKekkaControl[index].ShokenKekkaKbn))
                {
                    // 所見データ無し
                    continue;
                }

                if (_syokenKekkaControl[index].ShokenKekkaKbn == SyokenKekkaControl.ShokenKekkaKbnType.Shoken)
                {
                    // 所見結果
                    ShokenKekkaTblDataSet.ShokenKekkaTblRow newRow = shokenDT.NewShokenKekkaTblRow();

                    // 検査依頼法定区分
                    newRow.KensaIraiShokanIraiHoteiKbn = _kensaIraiTable[0].KensaIraiHoteiKbn;
                    // 検査依頼保健所コード
                    newRow.KensaIraiShokenIraiHokenjoCd = _kensaIraiTable[0].KensaIraiHokenjoCd;
                    // 検査依頼年度
                    newRow.KensaIraiShokenIraiNendo = _kensaIraiTable[0].KensaIraiNendo;
                    // 検査依頼連番
                    newRow.KensaIraiShokenIraiRenban = _kensaIraiTable[0].KensaIraiRenban;
                    // 所見連番
                    shokenRenban++;
                    shokenHosokuRenban = 0;
                    newRow.KensaIraiShokenRenban = shokenRenban.ToString().PadLeft(2, '0');
                    // 所見区分
                    newRow.ShokenKbn = _syokenKekkaControl[index].SyokenKbn;
                    // 所見コード
                    newRow.ShokenCd = _syokenKekkaControl[index].SyokenCd;
                    // 表示位置(1オリジン)
                    newRow.ShokenHyojiichi = _syokenKekkaControl[index].ItemNo;
                    // 所見手書き
                    newRow.ShokenTegaki = _syokenKekkaControl[index].ShokenTegaki;
                    // チェック項目
                    newRow.ShokenCheckKomoku = _syokenKekkaControl[index].ShokenCheckKomoku;
                    // チェック項目判定
                    newRow.ShokenCheckHantei = _syokenKekkaControl[index].ShokenCheckHantei;
                    // 指摘箇所No
                    newRow.ShokenShitekiKashoNo = _syokenKekkaControl[index].ShokenShitekiKashoNo;
                    // 設置者連絡有無
                    newRow.ShokenSetchishaRenrakuFlg = _syokenKekkaControl[index].ShokenSetchishaRenrakuFlg;
                    // 保守点検業者連絡有無
                    newRow.ShokenHoshuGyoshaRenrakuFlg = _syokenKekkaControl[index].ShokenHoshuGyoshaRenrakuFlg;
                    // 清掃業者連絡有無
                    newRow.ShokenSeisoGyoshaRenrakuFlg = _syokenKekkaControl[index].ShokenSeisoGyoshaRenrakuFlg;
                    // 工事業者連絡有無
                    newRow.ShokenKojiGyoshaRenrakuFlg = _syokenKekkaControl[index].ShokenKojiGyoshaRenrakuFlg;
                    // メーカー連絡有無
                    newRow.ShokenMakerRenrakuFlg = _syokenKekkaControl[index].ShokenMakerRenrakuFlg;
                    // 保健所連絡有無
                    newRow.ShokenHokenjoRenrakuFlg = _syokenKekkaControl[index].ShokenHokenjoRenrakuFlg;
                    // 保守契約確認有無
                    newRow.ShokenHoshuKeiyakuKakuninFlg = _syokenKekkaControl[index].ShokenHoshuKeiyakuKakuninFlg;
                    // 点検回数確認有無
                    newRow.ShokenTenkenKaisuuKakuninFlg = _syokenKekkaControl[index].ShokenTenkenKaisuuKakuninFlg;
                    // 清掃回数確認有無
                    newRow.ShokenSeisouKaisuuKakuninFlg = _syokenKekkaControl[index].ShokenSeisouKaisuuKakuninFlg;
                    // 単位装置名
                    newRow.TaniSochiNm = _syokenKekkaControl[index].TaniSochiNm;

                    // 追加・更新情報
                    newRow.InsertDt = nowDt;
                    newRow.InsertUser = userNm;
                    newRow.InsertTarm = hostNm;
                    newRow.UpdateDt = nowDt;
                    newRow.UpdateUser = userNm;
                    newRow.UpdateTarm = hostNm;

                    // 行を挿入
                    shokenDT.AddShokenKekkaTblRow(newRow);
                    // 行の状態を設定
                    newRow.AcceptChanges();
                    // 行の状態を設定（新規）
                    newRow.SetAdded();
                }
                else
                {
                    // 所見結果補足
                    ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow newRow = hosokuDT.NewShokenKekkaHosokuTblRow();

                    // 検査依頼法定区分
                    newRow.KensaIraiShokanIraiHoteiKbn = _kensaIraiTable[0].KensaIraiHoteiKbn;
                    // 検査依頼保健所コード
                    newRow.KensaIraiShokenIraiHokenjoCd = _kensaIraiTable[0].KensaIraiHokenjoCd;
                    // 検査依頼年度
                    newRow.KensaIraiShokenIraiNendo = _kensaIraiTable[0].KensaIraiNendo;
                    // 検査依頼連番
                    newRow.KensaIraiShokenIraiRenban = _kensaIraiTable[0].KensaIraiRenban;
                    // 所見連番
                    newRow.KensaIraiShokenRenban = shokenRenban.ToString().PadLeft(2, '0');
                    // 所見補足文連番
                    shokenHosokuRenban++;
                    newRow.KensaIraiShokenHosokuRenban = shokenHosokuRenban.ToString().PadLeft(2, '0');
                    // 所見区分
                    newRow.ShokenKbn = _syokenKekkaControl[index].SyokenKbn;
                    // 所見コード
                    newRow.ShokenCd = _syokenKekkaControl[index].SyokenCd;
                    // 表示位置(1オリジン)
                    newRow.ShokenHyojiichi = _syokenKekkaControl[index].ItemNo;
                    // 所見手書き
                    newRow.ShokenTegaki = _syokenKekkaControl[index].ShokenTegaki;
                    // チェック項目
                    newRow.ShokenCheckKomoku = _syokenKekkaControl[index].ShokenCheckKomoku;
                    // チェック項目判定
                    newRow.ShokenCheckHantei = _syokenKekkaControl[index].ShokenCheckHantei;
                    // 指摘箇所No
                    newRow.ShokenShitekiKashoNo = _syokenKekkaControl[index].ShokenShitekiKashoNo;
                    // 設置者連絡有無
                    newRow.ShokenSetchishaRenrakuFlg = _syokenKekkaControl[index].ShokenSetchishaRenrakuFlg;
                    // 保守点検業者連絡有無
                    newRow.ShokenHoshuGyoshaRenrakuFlg = _syokenKekkaControl[index].ShokenHoshuGyoshaRenrakuFlg;
                    // 清掃業者連絡有無
                    newRow.ShokenSeisoGyoshaRenrakuFlg = _syokenKekkaControl[index].ShokenSeisoGyoshaRenrakuFlg;
                    // 工事業者連絡有無
                    newRow.ShokenKojiGyoshaRenrakuFlg = _syokenKekkaControl[index].ShokenKojiGyoshaRenrakuFlg;
                    // メーカー連絡有無
                    newRow.ShokenMakerRenrakuFlg = _syokenKekkaControl[index].ShokenMakerRenrakuFlg;
                    // 保健所連絡有無
                    newRow.ShokenHokenjoRenrakuFlg = _syokenKekkaControl[index].ShokenHokenjoRenrakuFlg;
                    // 保守契約確認有無
                    newRow.ShokenHoshuKeiyakuKakuninFlg = _syokenKekkaControl[index].ShokenHoshuKeiyakuKakuninFlg;
                    // 点検回数確認有無
                    newRow.ShokenTenkenKaisuuKakuninFlg = _syokenKekkaControl[index].ShokenTenkenKaisuuKakuninFlg;
                    // 清掃回数確認有無
                    newRow.ShokenSeisouKaisuuKakuninFlg = _syokenKekkaControl[index].ShokenSeisouKaisuuKakuninFlg;

                    // 追加・更新情報
                    newRow.InsertDt = nowDt;
                    newRow.InsertUser = userNm;
                    newRow.InsertTarm = hostNm;
                    newRow.UpdateDt = nowDt;
                    newRow.UpdateUser = userNm;
                    newRow.UpdateTarm = hostNm;

                    // 行を挿入
                    hosokuDT.AddShokenKekkaHosokuTblRow(newRow);
                    // 行の状態を設定
                    newRow.AcceptChanges();
                    // 行の状態を設定（新規）
                    newRow.SetAdded();
                }
            }
        }
        #endregion

        #endregion

        #region SetDictData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDictData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.11
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDictData()
        {
            #region TextBox
            _kensaTextBoxDict = new Dictionary<ZTextBox, Label>
            {
                // Left side
                { pHTextBox, pHHyokaLabel },
                { yozonSansoRyo1TextBox, yozonSansoRyoHyokaLabel },
                { yozonSansoRyo2TextBox, yozonSansoRyoHyokaLabel },
                { nijiToshidoTextBox, nijiToshidoHyokaLabel },
                { toshidoTextBox, toshidoHyokaLabel },
                { zanryuensoTextBox, zanryuensoHyokaLabel },
                { BODTextBox, BODHyokaLabel },
                { enkabutsuIonTextBox, enkabutsuIonHyokaLabel },
                { odeiChindenRitsuTextBox, odeiChindenRitsuHyokaLabel },
                // v1.11
                //{ ATUBODTextBox, ATUBODHyokaLabel },
                // Right side
                { saiPHTextBox, saiPHHyokaLabel },
                { saiYozonSansoRyo1TextBox, saiYozonSansoRyoHyokaLabel },
                { saiYozonSansoRyo2TextBox, saiYozonSansoRyoHyokaLabel },
                { saiNijiToshidoTextBox, saiNijiToshidoHyokaLabel },
                { saiToshidoTextBox, saiToshidoHyokaLabel },
                { saiZanryuensoTextBox, saiZanryuensoHyokaLabel },
                { saiBODTextBox, saiBODHyokaLabel },
                { saiEnkabutsuIonTextBox, saiEnkabutsuIonHyokaLabel },
                { saiOdeiChindenRitsuTextBox, saiOdeiChindenRitsuHyokaLabel },
                // v1.11
                //{ saiATUBODTextBox, saiATUBODHyokaLabel },
            };

            _txtKbnDict = new Dictionary<ZTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn>
            {
                // Left side
                { pHTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.PH },
                { yozonSansoRyo1TextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.YozonSansoRyo },
                { yozonSansoRyo2TextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.YozonSansoRyo },
                { nijiToshidoTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { toshidoTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { zanryuensoTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso },
                { BODTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
                { enkabutsuIonTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon },
                { odeiChindenRitsuTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.OdeiChindenRitsu },
                // v1.11
                { ATUBODTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
                // Right side
                { saiPHTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.PH },
                { saiYozonSansoRyo1TextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.YozonSansoRyo },
                { saiYozonSansoRyo2TextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.YozonSansoRyo },
                { saiNijiToshidoTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { saiToshidoTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { saiZanryuensoTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso },
                { saiBODTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
                { saiEnkabutsuIonTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon },
                { saiOdeiChindenRitsuTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.OdeiChindenRitsu },
                // v1.11
                { saiATUBODTextBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
            };
            #endregion

            #region Combobox
            _kensaCbDict = new Dictionary<ComboBox, Label>
            {
                // Left side
                { nijiToshidoComboBox, nijiToshidoHyokaLabel },
                { toshidoComboBox, toshidoHyokaLabel },
                { BODComboBox, BODHyokaLabel },
                { enkabutsuIonComboBox, enkabutsuIonHyokaLabel },
                { odeiChindenRitsuComboBox, odeiChindenRitsuHyokaLabel },
                // v1.11
                //{ ATUBODComboBox, ATUBODHyokaLabel },
                // Right side
                { saiNijiToshidoComboBox, saiNijiToshidoHyokaLabel },
                { saiToshidoComboBox, saiToshidoHyokaLabel },
                { saiBODComboBox, saiBODHyokaLabel },
                { saiEnkabutsuIonComboBox, saiEnkabutsuIonHyokaLabel },
                { saiOdeiChindenRitsuComboBox, saiOdeiChindenRitsuHyokaLabel },
                // v1.11
                //{ saiATUBODComboBox, saiATUBODHyokaLabel },
            };

            _cbKbnDict = new Dictionary<ComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn>
            {
                // Left side
                { nijiToshidoComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { toshidoComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { BODComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
                { enkabutsuIonComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon },
                { odeiChindenRitsuComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.OdeiChindenRitsu },
                // v1.11
                { ATUBODComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
                // Right side
                { saiNijiToshidoComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { saiToshidoComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.Toshido },
                { saiBODComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
                { saiEnkabutsuIonComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon },
                { saiOdeiChindenRitsuComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.OdeiChindenRitsu },
                // v1.11
                { saiATUBODComboBox, Utility.SuishitsuUtility.SuishitsuKensaKbn.BOD },
            };
            #endregion

            #region 所見結果(236)
            //_syokenKekkaControl = new List<SyokenKekkaControl>();
            //_syokenKekkaControl.Add(syokenKekkaControl1);
            //_syokenKekkaControl.Add(syokenKekkaControl2);
            //_syokenKekkaControl.Add(syokenKekkaControl3);
            //_syokenKekkaControl.Add(syokenKekkaControl4);
            //_syokenKekkaControl.Add(syokenKekkaControl5);
            //_syokenKekkaControl.Add(syokenKekkaControl6);
            //_syokenKekkaControl.Add(syokenKekkaControl7);
            //_syokenKekkaControl.Add(syokenKekkaControl8);
            //_syokenKekkaControl.Add(syokenKekkaControl9);
            //_syokenKekkaControl.Add(syokenKekkaControl10);
            //_syokenKekkaControl.Add(syokenKekkaControl11);
            //_syokenKekkaControl.Add(syokenKekkaControl12);
            //_syokenKekkaControl.Add(syokenKekkaControl13);
            //_syokenKekkaControl.Add(syokenKekkaControl14);
            //_syokenKekkaControl.Add(syokenKekkaControl15);
            //_syokenKekkaControl.Add(syokenKekkaControl16);
            //_syokenKekkaControl.Add(syokenKekkaControl17);
            //_syokenKekkaControl.Add(syokenKekkaControl18);
            //_syokenKekkaControl.Add(syokenKekkaControl19);
            //_syokenKekkaControl.Add(syokenKekkaControl20);
            //_syokenKekkaControl.Add(syokenKekkaControl21);
            //_syokenKekkaControl.Add(syokenKekkaControl22);
            //_syokenKekkaControl.Add(syokenKekkaControl23);
            //_syokenKekkaControl.Add(syokenKekkaControl24);
            //_syokenKekkaControl.Add(syokenKekkaControl25);
            //_syokenKekkaControl.Add(syokenKekkaControl26);
            //_syokenKekkaControl.Add(syokenKekkaControl27);
            //_syokenKekkaControl.Add(syokenKekkaControl28);
            //_syokenKekkaControl.Add(syokenKekkaControl29);
            //_syokenKekkaControl.Add(syokenKekkaControl30);
            #endregion

            #region チェック項目(39)
            _checkItemControl = new List<CheckItemControl>();
            _checkItemControl.Add(checkItemControl1);
            _checkItemControl.Add(checkItemControl2);
            _checkItemControl.Add(checkItemControl3);
            _checkItemControl.Add(checkItemControl4);
            _checkItemControl.Add(checkItemControl5);
            _checkItemControl.Add(checkItemControl6);
            _checkItemControl.Add(checkItemControl7);
            _checkItemControl.Add(checkItemControl8);
            _checkItemControl.Add(checkItemControl9);
            _checkItemControl.Add(checkItemControl10);
            _checkItemControl.Add(checkItemControl11);
            _checkItemControl.Add(checkItemControl12);
            _checkItemControl.Add(checkItemControl13);
            _checkItemControl.Add(checkItemControl14);
            _checkItemControl.Add(checkItemControl15);
            _checkItemControl.Add(checkItemControl16);
            _checkItemControl.Add(checkItemControl17);
            _checkItemControl.Add(checkItemControl18);
            _checkItemControl.Add(checkItemControl19);
            _checkItemControl.Add(checkItemControl20);
            _checkItemControl.Add(checkItemControl21);
            _checkItemControl.Add(checkItemControl22);
            _checkItemControl.Add(checkItemControl23);
            _checkItemControl.Add(checkItemControl24);
            _checkItemControl.Add(checkItemControl25);
            _checkItemControl.Add(checkItemControl26);
            _checkItemControl.Add(checkItemControl27);
            _checkItemControl.Add(checkItemControl28);
            _checkItemControl.Add(checkItemControl29);
            _checkItemControl.Add(checkItemControl30);
            _checkItemControl.Add(checkItemControl31);
            _checkItemControl.Add(checkItemControl32);
            _checkItemControl.Add(checkItemControl33);
            _checkItemControl.Add(checkItemControl34);
            _checkItemControl.Add(checkItemControl35);
            _checkItemControl.Add(checkItemControl36);
            _checkItemControl.Add(checkItemControl37);
            _checkItemControl.Add(checkItemControl38);
            _checkItemControl.Add(checkItemControl39);
            _checkItemControl.Add(checkItemControl40);
            _checkItemControl.Add(checkItemControl41);
            _checkItemControl.Add(checkItemControl42);
            _checkItemControl.Add(checkItemControl43);
            _checkItemControl.Add(checkItemControl44);
            _checkItemControl.Add(checkItemControl45);
            _checkItemControl.Add(checkItemControl46);
            _checkItemControl.Add(checkItemControl47);
            _checkItemControl.Add(checkItemControl48);
            _checkItemControl.Add(checkItemControl49);
            _checkItemControl.Add(checkItemControl50);
            _checkItemControl.Add(checkItemControl51);
            _checkItemControl.Add(checkItemControl52);
            _checkItemControl.Add(checkItemControl53);
            _checkItemControl.Add(checkItemControl54);
            _checkItemControl.Add(checkItemControl55);
            _checkItemControl.Add(checkItemControl56);
            _checkItemControl.Add(checkItemControl57);
            _checkItemControl.Add(checkItemControl58);
            _checkItemControl.Add(checkItemControl59);
            _checkItemControl.Add(checkItemControl60);
            _checkItemControl.Add(checkItemControl61);
            _checkItemControl.Add(checkItemControl62);
            _checkItemControl.Add(checkItemControl63);
            _checkItemControl.Add(checkItemControl64);
            _checkItemControl.Add(checkItemControl65);
            _checkItemControl.Add(checkItemControl66);
            _checkItemControl.Add(checkItemControl67);
            _checkItemControl.Add(checkItemControl68);
            _checkItemControl.Add(checkItemControl69);
            _checkItemControl.Add(checkItemControl70);
            _checkItemControl.Add(checkItemControl71);
            _checkItemControl.Add(checkItemControl72);
            _checkItemControl.Add(checkItemControl73);
            _checkItemControl.Add(checkItemControl74);
            _checkItemControl.Add(checkItemControl75);
            #endregion
        }
        #endregion

        #region SetSyokenKekkaControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSyokenKekkaControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokenKbn"></param>
        /// <param name="shokenCd"></param>
        /// <param name="shokenWd"></param>
        /// <param name="sonyuIchiNum"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSyokenKekkaControl(string shokenKbn, string shokenCd, string shokenWd, int sonyuIchiNum)
        {
            foreach (SyokenKekkaControl skc in _syokenKekkaControl)
            {
                // 番号(237) equals 挿入位置?
                if (skc.ItemNo == sonyuIchiNum)
                {
                    skc.SyokenKbn = shokenKbn;
                    skc.SyokenCd = shokenCd;
                    skc.SyokenWd = shokenWd;

                    // No more loop needed
                    break;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSyokenKekkaControlFromShokenKekkaTbl
        /// <summary>
        /// 所見結果、所見結果補足テーブルの読み込み結果を所見一覧に表示
        /// </summary>
        /// <param name="shokenRow">所見結果読み込み時の所見</param>
        /// <param name="hosokuRow">所見結果読み込み時の所見補足</param>
        /// <param name="sonyuIchiNum">挿入位置(1オリジン)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSyokenKekkaControlFromShokenKekkaTbl(GaikanKensaKekkaTblDataSet.ShokenKekkaListRow shokenRow, GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListRow hosokuRow, int sonyuIchiNum)
        {
            if (shokenRow != null)
            {
                // 所見情報を挿入

                // 所見区分
                _syokenKekkaControl[sonyuIchiNum - 1].SyokenKbn = shokenRow.ShokenKbn;
                // 所見コード
                _syokenKekkaControl[sonyuIchiNum - 1].SyokenCd = shokenRow.ShokenCd;
                // 内容
                _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd = shokenRow.ShokenWd;
                // 所見手書き
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenTegaki = shokenRow.ShokenTegaki;
                if (!string.IsNullOrEmpty(shokenRow.ShokenTegaki))
                {
                    _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd = shokenRow.ShokenTegaki;
                }
                // チェック項目
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckKomoku = shokenRow.ShokenCheckKomoku;
                // チェック項目判定
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckHantei = shokenRow.ShokenCheckHantei;
                // 指摘箇所No
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenShitekiKashoNo = shokenRow.ShokenShitekiKashoNo;
                // 設置者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenSetchishaRenrakuFlg = shokenRow.ShokenSetchishaRenrakuFlg;
                // 保守点検業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuGyoshaRenrakuFlg = shokenRow.ShokenHoshuGyoshaRenrakuFlg;
                // 清掃業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisoGyoshaRenrakuFlg = shokenRow.ShokenSeisoGyoshaRenrakuFlg;
                // 工事業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenKojiGyoshaRenrakuFlg = shokenRow.ShokenKojiGyoshaRenrakuFlg;
                // メーカー連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenMakerRenrakuFlg = shokenRow.ShokenMakerRenrakuFlg;
                // 保健所連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenHokenjoRenrakuFlg = shokenRow.ShokenHokenjoRenrakuFlg;
                // 保守契約確認有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuKeiyakuKakuninFlg = shokenRow.ShokenHoshuKeiyakuKakuninFlg;
                // 点検回数確認有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenTenkenKaisuuKakuninFlg = shokenRow.ShokenTenkenKaisuuKakuninFlg;
                // 清掃回数確認有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisouKaisuuKakuninFlg = shokenRow.ShokenSeisouKaisuuKakuninFlg;
                // 所見区分（1:所見/2:所見補足）
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenKekkaKbn = SyokenKekkaControl.ShokenKekkaKbnType.Shoken;
                // 単位装置名
                _syokenKekkaControl[sonyuIchiNum - 1].TaniSochiNm = shokenRow.TaniSochiNm;

                if (!string.IsNullOrEmpty(_shokenReplaceStr) && _shokenReplaceStr.Length > 0 && !string.IsNullOrEmpty(shokenRow.TaniSochiNm) && shokenRow.TaniSochiNm.Length > 0)
                {
                    // 単位装置名で置換
                    _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd = 
                        _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd.Replace(_shokenReplaceStr, shokenRow.TaniSochiNm);
                }
            }

            if (hosokuRow != null)
            {
                // 所見補足情報を挿入

                // 所見区分
                _syokenKekkaControl[sonyuIchiNum - 1].SyokenKbn = hosokuRow.ShokenKbn;
                // 所見コード
                _syokenKekkaControl[sonyuIchiNum - 1].SyokenCd = hosokuRow.ShokenCd;
                // 内容
                _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd = hosokuRow.ShokenWd;
                // 所見手書き
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenTegaki = hosokuRow.ShokenTegaki;
                // チェック項目
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckKomoku = hosokuRow.ShokenCheckKomoku;
                // チェック項目判定
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckHantei = hosokuRow.ShokenCheckHantei;
                // 指摘箇所No
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenShitekiKashoNo = hosokuRow.ShokenShitekiKashoNo;
                // 設置者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenSetchishaRenrakuFlg = hosokuRow.ShokenSetchishaRenrakuFlg;
                // 保守点検業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuGyoshaRenrakuFlg = hosokuRow.ShokenHoshuGyoshaRenrakuFlg;
                // 清掃業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisoGyoshaRenrakuFlg = hosokuRow.ShokenSeisoGyoshaRenrakuFlg;
                // 工事業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenKojiGyoshaRenrakuFlg = hosokuRow.ShokenKojiGyoshaRenrakuFlg;
                // メーカー連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenMakerRenrakuFlg = hosokuRow.ShokenMakerRenrakuFlg;
                // 保健所連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenHokenjoRenrakuFlg = hosokuRow.ShokenHokenjoRenrakuFlg;
                // 保守契約確認有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuKeiyakuKakuninFlg = hosokuRow.ShokenHoshuKeiyakuKakuninFlg;
                // 点検回数確認有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenTenkenKaisuuKakuninFlg = hosokuRow.ShokenTenkenKaisuuKakuninFlg;
                // 清掃回数確認有無
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisouKaisuuKakuninFlg = hosokuRow.ShokenSeisouKaisuuKakuninFlg;
                // 所見区分（1:所見/2:所見補足）
                _syokenKekkaControl[sonyuIchiNum - 1].ShokenKekkaKbn = SyokenKekkaControl.ShokenKekkaKbnType.ShokenHosoku;
                // 単位装置名
                _syokenKekkaControl[sonyuIchiNum - 1].TaniSochiNm = string.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShokenListAddLine
        /// <summary>
        /// 所見一覧のリスト拡張
        /// </summary>
        /// <param name="addLineCount">拡張行数</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/17  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ShokenListAddLine(int addLineCount)
        {
            // 所見一覧を拡張
            syokenKekkaPanel.Size = new Size(SHOKEN_KEKKA_PANEL_WIDTH, SHOKEN_KEKKA_PANEL_HEIGHT_INIT + (SHOKEN_KEKKA_HEIGHT * addLineCount));
            int startIndex = _syokenKekkaControl.Count;
            for (int i = startIndex; i < startIndex + addLineCount; i++)
            {
                SyokenKekkaControl syokenKekkaControl = new SyokenKekkaControl();
                InitSyokenKekkaControl(syokenKekkaControl);
                syokenKekkaPanel.Controls.Add(syokenKekkaControl);
                syokenKekkaControl.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
                syokenKekkaControl.CustomUpButtonClick += new EventHandler(syokenKekkaControl_CustomUpButtonClick);
                syokenKekkaControl.CustomDeleteButtonClick += new EventHandler(syokenKekkaControl_CustomDelButtonClick);
                syokenKekkaControl.ItemNo = i + 1;
                syokenKekkaControl.Location = new Point(SHOKEN_KEKKA_LOCATION_X, SHOKEN_KEKKA_LOCATION_Y_MARGIN + (SHOKEN_KEKKA_HEIGHT * i));
                syokenKekkaControl.TabIndex = i + 1;
                _syokenKekkaControl.Add(syokenKekkaControl);
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSyokenKekkaControlFromShokenSelectDlg
        /// <summary>
        /// 所見選択ダイアログで選択された所見を所見一覧に設定
        /// </summary>
        /// <param name="shokenRow">所見選択の所見</param>
        /// <param name="hosokuDT">所見選択の所見補足</param>
        /// <param name="sonyuIchiNum">挿入位置(1オリジン)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  小松　　    新規作成
        /// 2015/01/21　小松　　　　所見結果のチェック項目判定に、所見マスタの判断をセット
        /// 2015/01/22　小松　　　　所見結果の指摘箇所Noに、所見マスタの指摘箇所Noをセット
        /// 2015/01/26　小松　　　　単位装置選択処理追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSyokenKekkaControlFromShokenSelectDlg(ShokenMstDataSet.ShokenKekkaSelectRow shokenRow, ShokenMstDataSet.ShokenKekkaSelectDataTable hosokuDT, int sonyuIchiNum)
        {
            string taniSochiNm = string.Empty;
            if (_shokenReplaceStr.Length > 0 && shokenRow.ShokenWd.IndexOf(_shokenReplaceStr) != -1)
            {
                // 置換対象の文字列が含まれる場合
                TaniSochiNmSelectForm sochiFrm = new TaniSochiNmSelectForm(_dispTable[0].JokasoMekaGyoshaCd, _dispTable[0].KensaIraiKatashikiCd, shokenRow.ShokenKbn, shokenRow.ShokenCd);
                sochiFrm.ShowDialog();

                if (sochiFrm.DialogResult == DialogResult.OK)
                {
                    // 単位装置名設定
                    taniSochiNm = sochiFrm.ResultTaniSochiNm;
                    // 単位装置名で置換
                    shokenRow.ShokenWd = shokenRow.ShokenWd.Replace(_shokenReplaceStr, taniSochiNm);
                }
            }

            // 所見一覧に表示可能か
            if (_syokenKekkaControl.Count < (sonyuIchiNum + hosokuDT.Rows.Count))
            {
                // 所見一覧を拡張
                int addLineCount = (sonyuIchiNum + hosokuDT.Rows.Count) - _syokenKekkaControl.Count;
                ShokenListAddLine(addLineCount);
            }

            // 挿入位置に設定済の所見が存在するか確認
            int insertCnt = 1 + hosokuDT.Rows.Count;
            bool existsFlg = false;
            for (int index = sonyuIchiNum - 1; index < sonyuIchiNum - 1 + insertCnt; index++)
            {
                if (!string.IsNullOrEmpty(_syokenKekkaControl[index].ShokenKekkaKbn))
                {
                    // 挿入位置に設定済の所見が存在する
                    existsFlg = true;
                    break;
                }
            }

            // 挿入位置に設定済の所見が存在する場合は、その領域を開けて以降を下に移動
            if (existsFlg)
            {
                for (int index = _syokenKekkaControl.Count - 1; index >= sonyuIchiNum - 1; index--)
                {
                    if (!string.IsNullOrEmpty(_syokenKekkaControl[index].ShokenKekkaKbn))
                    {
                        // 挿入個数分下に移動

                        // 所見一覧に表示可能か
                        if (_syokenKekkaControl.Count < (index + 1 + insertCnt))
                        {
                            // 所見一覧を拡張
                            int addLineCount = (index + 1 + insertCnt) - _syokenKekkaControl.Count;
                            ShokenListAddLine(addLineCount);
                        }
                        // 所見を移動
                        SetSyokenKekkaControlFromShokenKekkaCtrl(_syokenKekkaControl[index], _syokenKekkaControl[index + insertCnt]);
                    }
                }
            }
            else
            {
                // 設定されていない場合は、そのままその位置に上書き。以降もずらさない。

            }

            // 所見情報を挿入
            // 所見区分
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenKbn = shokenRow.ShokenKbn;
            // 所見コード
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenCd = shokenRow.ShokenCd;
            // 内容
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd = shokenRow.ShokenWd;
            // 所見手書き
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenTegaki = string.Empty;
            // チェック項目
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckKomoku = string.Empty;
            // チェック項目判定
            //_syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckHantei = string.Empty;
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckHantei = shokenRow.ShokenHandan;
            // 指摘箇所No
            //_syokenKekkaControl[sonyuIchiNum - 1].ShokenShitekiKashoNo = string.Empty;
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenShitekiKashoNo = shokenRow.ShokenShitekiNo;
            // 設置者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSetchishaRenrakuFlg = "0";
            // 保守点検業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuGyoshaRenrakuFlg = "0";
            // 清掃業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisoGyoshaRenrakuFlg = "0";
            // 工事業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenKojiGyoshaRenrakuFlg = "0";
            // メーカー連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenMakerRenrakuFlg = "0";
            // 保健所連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHokenjoRenrakuFlg = "0";
            // 保守契約確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuKeiyakuKakuninFlg = "0";
            // 点検回数確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenTenkenKaisuuKakuninFlg = "0";
            // 清掃回数確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisouKaisuuKakuninFlg = "0";
            // 所見区分（1:所見/2:所見補足）
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenKekkaKbn = SyokenKekkaControl.ShokenKekkaKbnType.Shoken;
            // 単位装置名
            _syokenKekkaControl[sonyuIchiNum - 1].TaniSochiNm = taniSochiNm;

            // 所見補足情報を挿入
            int offset = 1;
            foreach (ShokenMstDataSet.ShokenKekkaSelectRow hosokuRow in hosokuDT)
            {
                // 所見区分
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].SyokenKbn = hosokuRow.ShokenKbn;
                // 所見コード
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].SyokenCd = hosokuRow.ShokenCd;
                // 内容
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].SyokenWd = hosokuRow.ShokenWd;
                // 所見手書き
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenTegaki = string.Empty;
                // チェック項目
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenCheckKomoku = string.Empty;
                // チェック項目判定
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenCheckHantei = string.Empty;
                // 指摘箇所No
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenShitekiKashoNo = string.Empty;
                // 設置者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenSetchishaRenrakuFlg = "0";
                // 保守点検業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenHoshuGyoshaRenrakuFlg = "0";
                // 清掃業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenSeisoGyoshaRenrakuFlg = "0";
                // 工事業者連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenKojiGyoshaRenrakuFlg = "0";
                // メーカー連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenMakerRenrakuFlg = "0";
                // 保健所連絡有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenHokenjoRenrakuFlg = "0";
                // 保守契約確認有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenHoshuKeiyakuKakuninFlg = "0";
                // 点検回数確認有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenTenkenKaisuuKakuninFlg = "0";
                // 清掃回数確認有無
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenSeisouKaisuuKakuninFlg = "0";
                // 所見区分（1:所見/2:所見補足）
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].ShokenKekkaKbn = SyokenKekkaControl.ShokenKekkaKbnType.ShokenHosoku;
                // 単位装置名
                _syokenKekkaControl[sonyuIchiNum - 1 + offset].TaniSochiNm = string.Empty;

                offset++;
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSyokenKekkaControlFromSyokenManualDlg
        /// <summary>
        /// 所見手入力ダイアログで設定された所見手入力を所見一覧に設定
        /// </summary>
        /// <param name="shokenWd">所見所見手入力の所見</param>
        /// <param name="insertPosition">所見所見手入力の挿入位置</param>
        /// <param name="checkItemNo">所見所見手入力のチェック項目</param>
        /// <param name="shitekiKasyoNo">所見所見手入力の指摘箇所</param>
        /// <param name="handan">所見所見手入力の判定</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSyokenKekkaControlFromSyokenManualDlg(string shokenWd, string insertPosition, string checkItemNo, string shitekiKasyoNo, string handan)
        {
            int sonyuIchiNum = Convert.ToInt32(insertPosition);
            // 所見区分
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenKbn = string.Empty;
            // 所見コード
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenCd = string.Empty;
            // 内容
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd = shokenWd;
            // 所見手書き
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenTegaki = shokenWd;
            // チェック項目
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckKomoku = checkItemNo;
            // チェック項目判定
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckHantei = handan;
            // 指摘箇所No
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenShitekiKashoNo = shitekiKasyoNo;
            // 設置者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSetchishaRenrakuFlg = "0";
            // 保守点検業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuGyoshaRenrakuFlg = "0";
            // 清掃業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisoGyoshaRenrakuFlg = "0";
            // 工事業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenKojiGyoshaRenrakuFlg = "0";
            // メーカー連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenMakerRenrakuFlg = "0";
            // 保健所連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHokenjoRenrakuFlg = "0";
            // 保守契約確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuKeiyakuKakuninFlg = "0";
            // 点検回数確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenTenkenKaisuuKakuninFlg = "0";
            // 清掃回数確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisouKaisuuKakuninFlg = "0";
            // 所見区分（1:所見/2:所見補足）
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenKekkaKbn = SyokenKekkaControl.ShokenKekkaKbnType.Shoken;
            // 単位装置名
            _syokenKekkaControl[sonyuIchiNum - 1].TaniSochiNm = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSyokenKekkaControlFromSyokenMstSearchDlg
        /// <summary>
        /// 所見マスタ選択ダイアログで設定された所見を所見一覧に設定
        /// </summary>
        /// <param name="shokenRow">所見選択の所見</param>
        /// <param name="sonyuIchiNum">挿入位置(1オリジン)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26  小松　　    新規作成
        /// 2015/01/21　小松　　　　所見結果のチェック項目判定に、所見マスタの判断をセット
        /// 2015/01/22　小松　　　　所見結果の指摘箇所Noに、所見マスタの指摘箇所Noをセット
        /// 2015/01/26　小松　　　　単位装置選択処理追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSyokenKekkaControlFromSyokenMstSearchDlg(ShokenMstDataSet.SyokenMstSearchListRow shokenRow, int sonyuIchiNum)
        {
            string taniSochiNm = string.Empty;
            if (_shokenReplaceStr.Length > 0 && shokenRow.ShokenWd.IndexOf(_shokenReplaceStr) != -1)
            {
                // 置換対象の文字列が含まれる場合
                TaniSochiNmSelectForm sochiFrm = new TaniSochiNmSelectForm(_dispTable[0].JokasoMekaGyoshaCd, _dispTable[0].KensaIraiKatashikiCd, shokenRow.ShokenKbn, shokenRow.ShokenCd);
                sochiFrm.ShowDialog();

                if (sochiFrm.DialogResult == DialogResult.OK)
                {
                    // 単位装置名設定
                    taniSochiNm = sochiFrm.ResultTaniSochiNm;
                    // 単位装置名で置換
                    shokenRow.ShokenWd = shokenRow.ShokenWd.Replace(_shokenReplaceStr, taniSochiNm);
                }
            }

            // 所見区分
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenKbn = shokenRow.ShokenKbn;
            // 所見コード
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenCd = shokenRow.ShokenCd;
            // 内容
            _syokenKekkaControl[sonyuIchiNum - 1].SyokenWd = shokenRow.ShokenWd;
            // 所見手書き
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenTegaki = string.Empty;
            // チェック項目
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckKomoku = string.Empty;
            // チェック項目判定
            //_syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckHantei = string.Empty;
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenCheckHantei = shokenRow.ShokenHandan;
            // 指摘箇所No
            //_syokenKekkaControl[sonyuIchiNum - 1].ShokenShitekiKashoNo = string.Empty;
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenShitekiKashoNo = shokenRow.ShokenShitekiNo;
            // 設置者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSetchishaRenrakuFlg = "0";
            // 保守点検業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuGyoshaRenrakuFlg = "0";
            // 清掃業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisoGyoshaRenrakuFlg = "0";
            // 工事業者連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenKojiGyoshaRenrakuFlg = "0";
            // メーカー連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenMakerRenrakuFlg = "0";
            // 保健所連絡有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHokenjoRenrakuFlg = "0";
            // 保守契約確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenHoshuKeiyakuKakuninFlg = "0";
            // 点検回数確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenTenkenKaisuuKakuninFlg = "0";
            // 清掃回数確認有無
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenSeisouKaisuuKakuninFlg = "0";
            // 所見区分（1:所見/2:所見補足）
            _syokenKekkaControl[sonyuIchiNum - 1].ShokenKekkaKbn = SyokenKekkaControl.ShokenKekkaKbnType.Shoken;
            // 単位装置名
            _syokenKekkaControl[sonyuIchiNum - 1].TaniSochiNm = taniSochiNm;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetSyokenKekkaControlFromShokenKekkaCtrl
        /// <summary>
        /// 所見結果コントロールの内容をコピー
        /// </summary>
        /// <param name="srcCtrl">コピー元の所見結果コントロール</param>
        /// <param name="destCtrl">コピー先の所見結果コントロール</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSyokenKekkaControlFromShokenKekkaCtrl(SyokenKekkaControl srcCtrl, SyokenKekkaControl destCtrl)
        {
            // 所見区分
            destCtrl.SyokenKbn = srcCtrl.SyokenKbn;
            // 所見コード
            destCtrl.SyokenCd = srcCtrl.SyokenCd;
            // 内容
            destCtrl.SyokenWd = srcCtrl.SyokenWd;
            // 所見手書き
            destCtrl.ShokenTegaki = srcCtrl.ShokenTegaki;
            // チェック項目
            destCtrl.ShokenCheckKomoku = srcCtrl.ShokenCheckKomoku;
            // チェック項目判定
            destCtrl.ShokenCheckHantei = srcCtrl.ShokenCheckHantei;
            // 指摘箇所No
            destCtrl.ShokenShitekiKashoNo = srcCtrl.ShokenShitekiKashoNo;
            // 設置者連絡有無
            destCtrl.ShokenSetchishaRenrakuFlg = srcCtrl.ShokenSetchishaRenrakuFlg;
            // 保守点検業者連絡有無
            destCtrl.ShokenHoshuGyoshaRenrakuFlg = srcCtrl.ShokenHoshuGyoshaRenrakuFlg;
            // 清掃業者連絡有無
            destCtrl.ShokenSeisoGyoshaRenrakuFlg = srcCtrl.ShokenSeisoGyoshaRenrakuFlg;
            // 工事業者連絡有無
            destCtrl.ShokenKojiGyoshaRenrakuFlg = srcCtrl.ShokenKojiGyoshaRenrakuFlg;
            // メーカー連絡有無
            destCtrl.ShokenMakerRenrakuFlg = srcCtrl.ShokenMakerRenrakuFlg;
            // 保健所連絡有無
            destCtrl.ShokenHokenjoRenrakuFlg = srcCtrl.ShokenHokenjoRenrakuFlg;
            // 保守契約確認有無
            destCtrl.ShokenHoshuKeiyakuKakuninFlg = srcCtrl.ShokenHoshuKeiyakuKakuninFlg;
            // 点検回数確認有無
            destCtrl.ShokenTenkenKaisuuKakuninFlg = srcCtrl.ShokenTenkenKaisuuKakuninFlg;
            // 清掃回数確認有無
            destCtrl.ShokenSeisouKaisuuKakuninFlg = srcCtrl.ShokenSeisouKaisuuKakuninFlg;
            // 所見区分（1:所見/2:所見補足）
            destCtrl.ShokenKekkaKbn = srcCtrl.ShokenKekkaKbn;
            // 単位装置名
            destCtrl.TaniSochiNm = srcCtrl.TaniSochiNm;
        }
        #endregion

        #region InitSyokenKekkaControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitSyokenKekkaControl
        /// <summary>
        /// 所見結果コントロールの内容をクリア
        /// </summary>
        /// <param name="syokenControl">所見結果コントロール</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InitSyokenKekkaControl(SyokenKekkaControl syokenControl)
        {
            // 所見区分
            syokenControl.SyokenKbn = string.Empty;
            // 所見コード
            syokenControl.SyokenCd = string.Empty;
            // 内容
            syokenControl.SyokenWd = string.Empty;
            // 所見手書き
            syokenControl.ShokenTegaki = string.Empty;
            // チェック項目
            syokenControl.ShokenCheckKomoku = string.Empty;
            // チェック項目判定
            syokenControl.ShokenCheckHantei = string.Empty;
            // 指摘箇所No
            syokenControl.ShokenShitekiKashoNo = string.Empty;
            // 設置者連絡有無
            syokenControl.ShokenSetchishaRenrakuFlg = string.Empty;
            // 保守点検業者連絡有無
            syokenControl.ShokenHoshuGyoshaRenrakuFlg = string.Empty;
            // 清掃業者連絡有無
            syokenControl.ShokenSeisoGyoshaRenrakuFlg = string.Empty;
            // 工事業者連絡有無
            syokenControl.ShokenKojiGyoshaRenrakuFlg = string.Empty;
            // メーカー連絡有無
            syokenControl.ShokenMakerRenrakuFlg = string.Empty;
            // 保健所連絡有無
            syokenControl.ShokenHokenjoRenrakuFlg = string.Empty;
            // 保守契約確認有無
            syokenControl.ShokenHoshuKeiyakuKakuninFlg = string.Empty;
            // 点検回数確認有無
            syokenControl.ShokenTenkenKaisuuKakuninFlg = string.Empty;
            // 清掃回数確認有無
            syokenControl.ShokenSeisouKaisuuKakuninFlg = string.Empty;
            // 所見区分（1:所見/2:所見補足）
            syokenControl.ShokenKekkaKbn = string.Empty;
            // 単位装置名
            syokenControl.TaniSochiNm = string.Empty;
        }
        #endregion

        #region EditCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditCheck
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// TRUE: edited
        /// FALSE: not edit
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04  AnhNV　　    新規作成
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.11
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// 2015/01/29  habu　　    行政報告の自動判定対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            #region ヘッダー
            // メモ確認(16)
            if (memoKakuninCheckBox.Checked && _dispTable[0].KensaIraiMemoKakuninFlg != "1"
                || !memoKakuninCheckBox.Checked && _dispTable[0].KensaIraiMemoKakuninFlg == "1") return true;
            #endregion

            #region 判定／外観Tab(26)
            // 判定(34)
            string hantei = hanteiComboBox.SelectedValue == null ? "0" : hanteiComboBox.SelectedValue.ToString();
            //if (hantei != _dispTable[0].KensaKekkaHantei) return true;
            if (hantei != _hanteiKekka) return true;
            // 行政報告レベル(35)
            string gyosei = gyoseiHokokuLevelComboBox.SelectedValue == null ? string.Empty : gyoseiHokokuLevelComboBox.SelectedValue.ToString();
            if (gyosei != _gyoseiHokokuHantei) return true;
            //if (gyosei != _dispTable[0].KensaIraiGyoseiHokokuLevel) return true;
            // 嵩上(36)
            if (kasaageNumTextBox.Text != _dispTable[0].KensaIraiKasaage) return true;
            // 43.滞留(37)
            if (tairyu43TextBox.Text != _dispTable[0].KensaIraiRyunyuTairyu) return true;
            // 44.滞留(38)
            if (tairyu44TextBox.Text != _dispTable[0].KensaIraiHoryuTairyu) return true;
            // ブロワ１(40)
            if (burowa1TextBox.Text != _dispTable[0].KensaIraiBurowa1) return true;
            // ブロワ規定風量１(41)
            if (burowaKitei1TextBox.Text != _dispTable[0].KensaIraiBurowaKiteFuryo1) return true;
            // ブロワ設置風量１(42)
            if (burowaSetchi1TextBox.Text != _dispTable[0].KensaIraiBurowaSetchiFuryo1) return true;
            // ブロワ２(43)
            if (burowa2TextBox.Text != _dispTable[0].KensaIraiBurowa2) return true;
            // ブロワ規定風量２(44)
            if (burowaKitei2TextBox.Text != _dispTable[0].KensaIraiBurowaKiteFuryo2) return true;
            // ブロワ設置風量２(45)
            if (burowaSetchi2TextBox.Text != _dispTable[0].KensaIraiBurowaSetchiFuryo2) return true;
            // ブロワ３(46)
            if (burowa3TextBox.Text != _dispTable[0].KensaIraiBurowa3) return true;
            // ブロワ規定風量３(47)
            if (burowaKitei3TextBox.Text != _dispTable[0].KensaIraiBurowaKiteFuryo3) return true;
            // ブロワ設置風量３(48)
            if (burowaSetchi3TextBox.Text != _dispTable[0].KensaIraiBurowaSetchiFuryo3) return true;
            #endregion

            #region 水質Tab(27)
            // pH(49)
            if (pHTextBox.Text != (_dispTable[0].IsKensaKekkaSuisoIonNodoNull() ? string.Empty : _dispTable[0].KensaKekkaSuisoIonNodo.ToString("N1"))) return true;
            // pH評価(50)
            if (pHHyokaLabel.Text != _dispTable[0].PHHyoka) return true;
            // 溶存酸素量From(51)
            if (yozonSansoRyo1TextBox.Text != (_dispTable[0].IsKensaKekkaYozonSansoryo1Null() ? string.Empty : _dispTable[0].KensaKekkaYozonSansoryo1.ToString("N1"))) return true;
            // 溶存酸素量To(52)
            if (yozonSansoRyo2TextBox.Text != (_dispTable[0].IsKensaKekkaYozonSansoryo2Null() ? string.Empty : _dispTable[0].KensaKekkaYozonSansoryo2.ToString("N1"))) return true;
            // 溶存酸素量評価(53)
            if (yozonSansoRyoHyokaLabel.Text != _dispTable[0].YozonSansoRyoHyoka) return true;
            // ２次透視度（度）(54)
            if (nijiToshidoTextBox.Text != (_dispTable[0].IsKensaKekkaToshido2jiSyorisuiNull() ? string.Empty : _dispTable[0].KensaKekkaToshido2jiSyorisui.ToString("N1"))) return true;
            // ２次透視度（数値範囲）(55)
            string niji = nijiToshidoComboBox.SelectedValue == null ? string.Empty : nijiToshidoComboBox.SelectedValue.ToString();
            if (niji != _dispTable[0].KensaKekkaToshido22jiSyorisui) return true;
            // ２次透視度評価(56)
            if (nijiToshidoHyokaLabel.Text != _dispTable[0].NijiToshidoHyoka) return true;
            // 透視度（度）(57)
            if (toshidoTextBox.Text != (_dispTable[0].IsKensaKekkaToshidoNull() ? string.Empty : _dispTable[0].KensaKekkaToshido.ToString("N1"))) return true;
            // 透視度（数値範囲）(58)
            string toshido = toshidoComboBox.SelectedValue == null ? string.Empty : toshidoComboBox.SelectedValue.ToString();
            if (toshido != _dispTable[0].KensaKekkaToshido2) return true;
            // 透視度評価(59)
            if (toshidoHyokaLabel.Text != _dispTable[0].ToshidoHyoka) return true;
            // 残留塩素(60)
            if (zanryuensoTextBox.Text != (_dispTable[0].IsKensaKekkaZanryuEnsoNodoNull() ? string.Empty : _dispTable[0].KensaKekkaZanryuEnsoNodo.ToString("N1"))) return true;
            // 残留塩素評価(61)
            if (zanryuensoHyokaLabel.Text != _dispTable[0].ZanryuensoHyokaLabel) return true;
            // ＢＯＤ(62)
            if (BODTextBox.Text != (_dispTable[0].IsKensaKekkaBODNull() ? string.Empty : _dispTable[0].KensaKekkaBOD.ToString("N1"))) return true;
            // ＢＯＤ（数値範囲）(63)
            string bod = BODComboBox.SelectedValue == null ? _dispTable[0].KensaIraiBOD2 : BODComboBox.SelectedValue.ToString();
            if (bod != _dispTable[0].KensaIraiBOD2) return true;
            // ＢＯＤ評価(64)
            if (BODHyokaLabel.Text != _dispTable[0].BODHyokaLabel) return true;
            // 塩化物イオン(65)
            if (enkabutsuIonTextBox.Text != (_dispTable[0].IsKensaKekkaEnsoIonNodoNull() ? string.Empty : _dispTable[0].KensaKekkaEnsoIonNodo.ToString("N1"))) return true;
            // 塩化物イオン（数値範囲）(66)
            string enka = enkabutsuIonComboBox.SelectedValue == null ? string.Empty : enkabutsuIonComboBox.SelectedValue.ToString();
            if (enka != _dispTable[0].KensaIraiEnsoIonNodo2) return true;
            // 塩化物イオン評価(67)
            if (enkabutsuIonHyokaLabel.Text != _dispTable[0].EnkabutsuIonHyokaLabel) return true;
            // 汚泥沈殿率(68)
            if (odeiChindenRitsuTextBox.Text != (_dispTable[0].IsKensaKekkaOdeiChindenritsuNull() ? string.Empty : _dispTable[0].KensaKekkaOdeiChindenritsu.ToString())) return true;
            // 汚泥沈殿率（数値範囲）(69)
            string odei = odeiChindenRitsuComboBox.SelectedValue == null ? string.Empty : odeiChindenRitsuComboBox.SelectedValue.ToString();
            if (odei != _dispTable[0].KensaKekkaOdeiChindenritsu2) return true;
            // 汚泥沈殿率評価(70)
            if (odeiChindenRitsuHyokaLabel.Text != _dispTable[0].OdeiChindenRitsuHyokaLabel) return true;
            // MLSS(71)
            if (MLSSTextBox.Text != (_dispTable[0].IsKensaKekkaMLSSNull() ? string.Empty : _dispTable[0].KensaKekkaMLSS.ToString())) return true;
            // 測定不能(72)
            if ((sokuteiFunoComboBox.SelectedIndex == 1 && _dispTable[0].KensaKekkaSuishitsuSokuteifuno != "1")
                || (sokuteiFunoComboBox.SelectedIndex == 0 && _dispTable[0].KensaKekkaSuishitsuSokuteifuno == "1")) return true;
            // 水質依頼No(73)
            if (suishitsuIraiNoTextBox.Text != _dispTable[0].KensaKekkaSuishitsuIraiNo) return true;

            // 再採水pH(74)
            if (saiPHTextBox.Text != (_dispTable[0].IsSaiSaisuiSuisoIonNodoNull() ? string.Empty : _dispTable[0].SaiSaisuiSuisoIonNodo.ToString("N1"))) return true;
            // 再採水pH評価(75)
            if (saiPHHyokaLabel.Text != _dispTable[0].SaiPHHyokaLabel) return true;
            // 再採水溶存酸素量From(76)
            if (saiYozonSansoRyo1TextBox.Text != (_dispTable[0].IsSaiSaisuiYozonSansoryo1Null() ? string.Empty : _dispTable[0].SaiSaisuiYozonSansoryo1.ToString("N1"))) return true;
            // 再採水溶存酸素量To(77)
            if (saiYozonSansoRyo2TextBox.Text != (_dispTable[0].IsSaiSaisuiYozonSansoryo2Null() ? string.Empty : _dispTable[0].SaiSaisuiYozonSansoryo2.ToString("N1"))) return true;
            // 再採水溶存酸素量評価(78)
            //if (saiNijiToshidoTextBox.Text != _dispTable[0].SaiSaisuiYozonSansoryoHantei) return true;
            // 再採水２次透視度（度）(79)
            if (saiNijiToshidoTextBox.Text != (_dispTable[0].IsSaiSaisuiToshido2jishorisuiNull() ? string.Empty : _dispTable[0].SaiSaisuiToshido2jishorisui.ToString("N1"))) return true;
            // 再採水２次透視度（数値範囲）(80)
            string sainiji = saiNijiToshidoComboBox.SelectedValue == null ? string.Empty : saiNijiToshidoComboBox.SelectedValue.ToString();
            if (sainiji != _dispTable[0].SaiSaisuiToshido22jishorisui) return true;
            // 再採水２次透視度評価(81)
            //if (saiNijiToshidoHyokaLabel.Text != _dispTable[0].saiNijiToshidoHyokaLabel) return true;
            // 再採水透視度（度）(82)
            if (saiToshidoTextBox.Text != (_dispTable[0].IsSaiSaisuiToshidoNull() ? string.Empty : _dispTable[0].SaiSaisuiToshido.ToString("N1"))) return true;
            // 再採水透視度（数値範囲）(83)
            string saiToshido = saiToshidoComboBox.SelectedValue == null ? string.Empty : saiToshidoComboBox.SelectedValue.ToString();
            if (saiToshido != _dispTable[0].SaiSaisuiToshido2) return true;
            // 再採水透視度評価(84)
            //if (saiToshidoHyokaLabel.Text != _dispTable[0].SaiSaisuiToshidoHantei) return true;
            // 再採水残留塩素(85)
            if (saiZanryuensoTextBox.Text != (_dispTable[0].IsSaiSaisuiZanryuEnsoNodoNull() ? string.Empty : _dispTable[0].SaiSaisuiZanryuEnsoNodo.ToString("N1"))) return true;
            // 再採水残留塩素評価(86)
            //if (saiZanryuensoHyokaLabel.Text != _dispTable[0].SaiZanryuensoHyokaLabel) return true;
            // 再採水ＢＯＤ(87)
            if (saiBODTextBox.Text != (_dispTable[0].IsSaiSaisuiBODNull() ? string.Empty : _dispTable[0].SaiSaisuiBOD.ToString("N1"))) return true;
            // 再採水ＢＯＤ（数値範囲）(88)
            string saiBOD = saiBODComboBox.SelectedValue == null ? string.Empty : saiBODComboBox.SelectedValue.ToString();
            if (saiBOD != _dispTable[0].SaiSaisuiBOD2) return true;
            // 再採水ＢＯＤ評価(89)
            //if (saiBODHyokaLabel.Text != _dispTable[0].SaiBODHyokaLabel) return true;
            // 再採水塩化物イオン(90)
            if (saiEnkabutsuIonTextBox.Text != (_dispTable[0].IsSaiSaisuiEnkaIonNodoNull() ? string.Empty : _dispTable[0].SaiSaisuiEnkaIonNodo.ToString("N1"))) return true;
            // 再採水塩化物イオン（数値範囲）(91)
            string saiEnka = saiEnkabutsuIonComboBox.SelectedValue == null ? string.Empty : saiEnkabutsuIonComboBox.SelectedValue.ToString();
            if (saiEnka != _dispTable[0].SaiSaisuiEnkaIonNodo2) return true;
            // 再採水塩化物イオン評価(92)
            //if (saiEnkabutsuIonHyokaLabel.Text != _dispTable[0].SaiEnkabutsuIonHyokaLabel) return true;
            // 再採水汚泥沈殿率(93)
            if (saiOdeiChindenRitsuTextBox.Text != (_dispTable[0].IsSaiSaisuiOdeichindenritsuNull() ? string.Empty : _dispTable[0].SaiSaisuiOdeichindenritsu)) return true;
            // 再採水汚泥沈殿率（数値範囲）(94)
            string saiOdei = saiOdeiChindenRitsuComboBox.SelectedValue == null ? string.Empty : saiOdeiChindenRitsuComboBox.SelectedValue.ToString();
            if (saiOdei != _dispTable[0].SaiSaisuiOdeichindenritsu2) return true;
            // 再採水汚泥沈殿率評価(95)
            //if (saiOdeiChindenRitsuHyokaLabel.Text != _dispTable[0].SaiOdeiChindenRitsuHyokaLabel) return true;
            // 再採水MLSS(96)
            if (saiMLSSTextBox.Text != (_dispTable[0].IsSaiSaisuiMLSSNull() ? string.Empty : _dispTable[0].SaiSaisuiMLSS.ToString())) return true;
            // 再採水測定不能(97)
            if ((saiSokuteiFunoComboBox.SelectedIndex == 1 && _dispTable[0].SaiSaisuiSuishitsuSokuteifuno != "1")
                || (saiSokuteiFunoComboBox.SelectedIndex == 0 && _dispTable[0].SaiSaisuiSuishitsuSokuteifuno == "1")) return true;
            // 再採水水質依頼No(98)
            if (saiSuishitsuIraiNoTextBox.Text != _dispTable[0].SaiSaisuiSuishitsuIraiNo) return true;

            // v1.11 Add start
            string atuBOD = _dispTable[0].IsKensaKekkaATUBODNull() ? string.Empty : _dispTable[0].KensaKekkaATUBOD.ToString("N1");
            if (ATUBODTextBox.Text != atuBOD) return true;
            atuBOD = null == ATUBODComboBox.SelectedValue ? string.Empty : ATUBODComboBox.SelectedValue.ToString();
            if (atuBOD != _dispTable[0].KensaKekkaATUBOD2) return true;

            string saiATU = _dispTable[0].IsSaiSaisuiATUBODNull() ? string.Empty : _dispTable[0].SaiSaisuiATUBOD.ToString("N1");
            if (saiATUBODTextBox.Text != saiATU) return true;
            saiATU = null == saiATUBODComboBox.SelectedValue ? string.Empty : saiATUBODComboBox.SelectedValue.ToString();
            if (saiATU != _dispTable[0].SaiSaisuiATUBOD2) return true;
            // v1.11 Add end

            // v1.13 Add start
            string jisshi = null == hosyuTenkenJisshiComboBox.SelectedValue ? string.Empty : hosyuTenkenJisshiComboBox.SelectedValue.ToString();
            if (jisshi != _dispTable[0].KensaKekkaTenkenKaisuKbn) return true;
            string kitei = null == hosyuTenkenKiteiComboBox.SelectedValue ? string.Empty : hosyuTenkenKiteiComboBox.SelectedValue.ToString();
            if (kitei != _dispTable[0].TenkenKaisuKbn) return true;
            string seiso = null == seisoKiteiComboBox.SelectedValue ? string.Empty : seisoKiteiComboBox.SelectedValue.ToString();
            if (seiso != _dispTable[0].SeisoKaisuKbn) return true;
            // v1.13 Add end
            #endregion

            #region 書類Tab(28)
            // 保守点検-記録有無(100)
            string hosyu1 = hosyuTenken1ComboBox.SelectedValue == null ? string.Empty : hosyuTenken1ComboBox.SelectedValue.ToString();
            if (hosyu1 != _dispTable[0].KensaKekkaHoshuTenkenKirokuUmu) return true;
            // 保守点検-回数(101)
            string hosyu2 = hosyuTenken2ComboBox.SelectedValue == null ? string.Empty : hosyuTenken2ComboBox.SelectedValue.ToString();
            if (hosyu2 != _dispTable[0].KensaKekkaHoshuTenkenKaisu) return true;
            // 保守点検-内容(102)
            string hosyu3 = hosyuTenken3ComboBox.SelectedValue == null ? string.Empty : hosyuTenken3ComboBox.SelectedValue.ToString();
            if (hosyu3 != _dispTable[0].KensaIraiHoshuTenkenNiayo) return true;
            // 保守点検-月毎(103)
            //if (hosyuTenkenTsukiTextBox.Text != _dispTable[0].KensaIraiTenkenKaisuTsukiGoto) return true;
            // 保守点検-週毎(104)
            //if (hosyuTenkenNumTextBox.Text != _dispTable[0].KensaIraiTenkenKaisuShuGoto) return true;
            // 清掃-記録有無(105)
            string seiso1 = seiso1ComboBox.SelectedValue == null ? string.Empty : seiso1ComboBox.SelectedValue.ToString();
            if (seiso1 != _dispTable[0].KensaKekkaSeisoKirokuUmu) return true;
            // 清掃-回数(106)
            string seiso2 = seiso2ComboBox.SelectedValue == null ? string.Empty : seiso2ComboBox.SelectedValue.ToString();
            if (seiso2 != _dispTable[0].KensaKekkaSeisoKaisu) return true;
            // 清掃-内容(107)
            string seiso3 = seiso3ComboBox.SelectedValue == null ? string.Empty : seiso3ComboBox.SelectedValue.ToString();
            if (seiso3 != _dispTable[0].KensaKekkaSeisoNaiyo) return true;
            // 清掃-回/年(108)
            //if (seisoCountTextBox.Text != _dispTable[0].KensaIraiSeisoKaisuNenkan) return true;

            DateTime kekkaSeisoDt;
            if (DateTime.TryParseExact(_dispTable[0].KensaKekkaSeisoDt, "yyyyMMdd", null, DateTimeStyles.None, out kekkaSeisoDt))
            {
                // 清掃年(109)
                //string nendo = Utility.DateUtility.ConvertToWareki(kekkaSeisoDt.ToString("yyyyMMdd"), "yy");
                if (seisoDtNenTextBox.Text != kekkaSeisoDt.ToString("yyyy")) return true;
                // 清掃月(110)
                if (seisoDtTsukiTextBox.Text != kekkaSeisoDt.ToString("MM")) return true;
                // 清掃日(111)
                if (seisoDtHiTextBox.Text != kekkaSeisoDt.ToString("dd")) return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(seisoDtNenTextBox.Text)
                    || !string.IsNullOrEmpty(seisoDtTsukiTextBox.Text)
                    || !string.IsNullOrEmpty(seisoDtHiTextBox.Text)) return true;
            }
            // 点検担当者名(112)
            if (tenkenTantosyaNmTextBox.Text != _dispTable[0].KensaIraiKensaTantoshaNm) return true;
            #endregion

            #region メモTab(29)
            // メモ(114)
            string daibunruiCd = string.Empty;
            string memoCd = string.Empty;
            string memoWd = string.Empty;
            foreach (DataGridViewRow dgvr in memoInputDataGridView.Rows)
            {
                daibunruiCd = dgvr.Cells[DefaultJokasoMemoDaibunruiCd.Name].Value == null ? string.Empty : dgvr.Cells[DefaultJokasoMemoDaibunruiCd.Name].Value.ToString();
                if (dgvr.Cells[daibunruiCdColumn.Name].Value.ToString() != daibunruiCd) return true;

                memoCd = dgvr.Cells[DefaultJokasoMemoCd.Name].Value == null ? string.Empty : dgvr.Cells[DefaultJokasoMemoCd.Name].Value.ToString();
                if (dgvr.Cells[memoCdColumn.Name].Value.ToString() != memoCd) return true;

                memoWd = dgvr.Cells[DefaultMemo.Name].Value == null ? string.Empty : dgvr.Cells[DefaultMemo.Name].Value.ToString();
                if (dgvr.Cells[memoWdColumn.Name].Value.ToString() != memoWd) return true;
            }

            //// 検査付加情報(119)
            //string kensaDt = string.Empty;
            //string midashi = string.Empty;
            //foreach (DataGridViewRow dgvr in kensaFukaListDataGridView.Rows)
            //{
            //    kensaDt = dgvr.Cells[DefaultKensaDt.Name].Value == null ? string.Empty : dgvr.Cells[DefaultKensaDt.Name].Value.ToString();
            //    if (dgvr.Cells[insertDtCol.Name].Value.ToString() != kensaDt) return true;

            //    midashi = dgvr.Cells[DefaultMidashi.Name].Value == null ? string.Empty : dgvr.Cells[DefaultMidashi.Name].Value.ToString();
            //    if (dgvr.Cells[kensaIraiKanrenFileMidashiCol.Name].Value.ToString() != midashi) return true;
            //}
            #endregion

            #region チェック項目(39)

            // Control index
            int itemNo = 0;

            foreach (GaikanKensaKekkaTblDataSet.CheckList75Row row in _cl75Table)
            {
                // No check item control for empty GaikankensaKomokuCd
                if (string.IsNullOrEmpty(row.GaikankensaKomokuCd)) { continue; }

                // Get 番号
                itemNo = Convert.ToInt32(row.GaikankensaKomokuCd);
                // No check item control for GaikankensaKomokuCd which is greater than 75 or zero.
                if (itemNo == 0 || itemNo > 75) { continue; }

                // 番号
                //_checkItemControl[itemNo - 1].ItemNo = itemNo;
                // 項目名
                //_checkItemControl[itemNo - 1].ItemText = row.GaikankensaKomokuNm;
                // Get 判定結果
                string hanteiKekka = string.Empty;
                switch (row.GaikanKensaKekkaCheckKomokuHantei)
                {
                    case "1":
                        hanteiKekka = MARU;
                        break;
                    case "2":
                        hanteiKekka = SANKAKU;
                        break;
                    case "3":
                        hanteiKekka = BATSU;
                        break;
                    case "4":
                        hanteiKekka = HIKU;
                        break;
                    default:
                        break;
                }
                // 判定結果
                if (_checkItemControl[itemNo - 1].HanteiKekka != hanteiKekka) { return true; }
            }

            #endregion

            //#region フッター(236)

            //int ctrlIdx = 0;

            //foreach (GaikanKensaKekkaTblDataSet.KensaKekkaFooterRow row in _footerTable)
            //{
            //    // Maximum of 30 SyokenKekkaControl
            //    if (ctrlIdx > 30) break;

            //    // 番号
            //    if (_syokenKekkaControl[ctrlIdx].ItemNo != Convert.ToInt32(row.KensaIraiShokenRenban)) { return true; }
            //    // 所見区分
            //    if (_syokenKekkaControl[ctrlIdx].SyokenKbn != row.ShokenKbn) { return true; }
            //    // 所見コード
            //    if (_syokenKekkaControl[ctrlIdx].SyokenCd != row.ShokenCd) { return true; }

            //    // Next control
            //    ctrlIdx++;
            //}

            //#endregion

            return false;
        }
        #endregion

        #region KensaHanteiVisibleControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KensaHanteiVisibleControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiStatusKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.10
        /// 2015/01/14  小松　　    検査完了ボタンの活性・非活性の判定の修正(Ver 1.09分がぬけてる)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaHanteiActiveControl(string kensaIraiStatusKbn)
        {
            //if (kensaIraiStatusKbn == "40" || kensaIraiStatusKbn == "60")
            //{
            //    // 検査完了ボタン(25)
            //    kensaFinishButton.Enabled = true;
            //    // 判定(34)
            //    hanteiComboBox.Enabled = true;
            //}
            //else
            //{
            //    // 検査完了ボタン(25)
            //    kensaFinishButton.Enabled = false;
            //    // 判定(34)
            //    hanteiComboBox.Enabled = false;
            //}

            bool enableFlg = false;
            if (_dispTable[0].KensaIraiHoteiKbn == FukjBizSystem.Application.Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU &&
                _kensaIraiTable[0].KensaIraiScreeningKbn == FukjBizSystem.Application.Utility.Constants.ScreeningKbnConstant.SCREENING_KBN_FOLLOW &&
                _dispTable[0].KensaIraiStatusKbn == FukjBizSystem.Application.Utility.Constants.KensaIraiStatusConstant.STATUS_KENSA_JISSHI_ZUMI && 
                _kensaIraiTable[0].KensaIraiSuishitsuKeninKbn == "1")
            {
                // 水質のフォロー検査でステータス区分が40:外観検査実施済(タブレット取込時)、検査依頼.水質検印区分が検印済(1)の時

                // 活性
                enableFlg = true;
            }
            else if (_dispTable[0].KensaIraiStatusKbn == FukjBizSystem.Application.Utility.Constants.KensaIraiStatusConstant.STATUS_SUISHITSU_KENIN_ZUMI)
            {
                // 水質のフォロー検査以外でステータス区分が60:水質検印済(水質検査台帳検印後)の時

                // 活性
                enableFlg = true;
            }
            else
            {
                // その他は検査完了ボタンは非活性（完了できない）。
            }

            // 検査完了ボタン(25)
            kensaFinishButton.Enabled = enableFlg;
            // 判定(34)
            hanteiComboBox.Enabled = enableFlg;
        }
        #endregion

        #region RegisterEvents
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RegisterEvents
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.12
        /// 2014/11/28  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.11
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RegisterEvents()
        {
            #region チェック項目
            checkItemControl1.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl2.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl3.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl4.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl5.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl6.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl7.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl8.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl9.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl10.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl11.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl12.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl13.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl14.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl15.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl16.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl17.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl18.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl19.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl20.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl21.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl22.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl23.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl24.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl25.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl26.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl27.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl28.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl29.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl30.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl31.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl32.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl33.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl34.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl35.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl36.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl37.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl38.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl39.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl40.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl41.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl42.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl43.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl44.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl45.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl46.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl47.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl48.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl49.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl50.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl51.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl52.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl53.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl54.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl55.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl56.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl57.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl58.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl59.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl60.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl61.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl62.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl63.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl64.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl65.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl66.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl67.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl68.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl69.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl70.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl71.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl72.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl73.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl74.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            checkItemControl75.CustomItemClick += new System.EventHandler(this.checkItemControl_CustomItemClick);
            #endregion

            #region 水質Tab - Textbox leave
            // Left side
            pHTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            yozonSansoRyo1TextBox.Leave += new EventHandler(kensaTextBox_Leave);
            yozonSansoRyo2TextBox.Leave += new EventHandler(kensaTextBox_Leave);
            nijiToshidoTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            toshidoTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            zanryuensoTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            BODTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            enkabutsuIonTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            odeiChindenRitsuTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            // v1.11
            //ATUBODTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            // Right side
            saiPHTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiYozonSansoRyo1TextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiYozonSansoRyo2TextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiNijiToshidoTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiToshidoTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiZanryuensoTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiBODTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiEnkabutsuIonTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            saiOdeiChindenRitsuTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            // v1.11
            //saiATUBODTextBox.Leave += new EventHandler(kensaTextBox_Leave);
            #endregion

            #region 水質Tab - Combobox selected index changed
            // Left side
            nijiToshidoComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            toshidoComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            BODComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            enkabutsuIonComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            odeiChindenRitsuComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            // v1.11
            //ATUBODComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            // Right side
            saiNijiToshidoComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            saiToshidoComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            saiBODComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            saiEnkabutsuIonComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            saiOdeiChindenRitsuComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            // v1.11
            //saiATUBODComboBox.SelectedIndexChanged += new EventHandler(kensaComboBox_SelectedIndexChanged);
            #endregion

            #region 所見結果 - Search button click
            //syokenKekkaControl1.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl2.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl3.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl4.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl5.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl6.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl7.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl8.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl9.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl10.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl11.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl12.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl13.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl14.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl15.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl16.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl17.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl18.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl19.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl20.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl21.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl22.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl23.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl24.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl25.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl26.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl27.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl28.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl29.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            //syokenKekkaControl30.CustomSearchButtonClick += new EventHandler(syokenKekkaControl_CustomSearchButtonClick);
            #endregion
        }
        #endregion

        #region GetDefaultValueForHanteiComboBox
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDefaultValueForHanteiComboBox
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/19  小松　　    再作成（設計書が解りにくかった）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetDefaultValueForHanteiComboBox()
        {
            // 判定区分 = 0
            if (_dispTable[0].KensaIraiHanteiKbn == "0" || string.IsNullOrEmpty(_dispTable[0].KensaIraiHanteiKbn.Trim()))
            {
                // 外観検査
                int gaikanHantei = 1;
                // ×
                DataRow[] dr = _cl75Table.Select("GaikanKensaKekkaCheckKomokuHantei = '3'");
                if (dr.Length > 0)
                {
                    // 外観検査：不適正(3)
                    gaikanHantei = 3;
                }
                else
                {
                    // △
                    dr = _cl75Table.Select("GaikanKensaKekkaCheckKomokuHantei = '2'");
                    if (dr.Length > 0)
                    {
                        // 外観検査：おおむね適正(2)
                        gaikanHantei = 2;
                    }
                }

                // 水質検査
                int suishitsuHantei = 1;
                if (pHHyokaLabel.Text == BATSU
                    || yozonSansoRyoHyokaLabel.Text == BATSU
                    || nijiToshidoHyokaLabel.Text == BATSU
                    || toshidoHyokaLabel.Text == BATSU
                    || zanryuensoHyokaLabel.Text == BATSU
                    || BODHyokaLabel.Text == BATSU
                    || enkabutsuIonHyokaLabel.Text == BATSU
                    || odeiChindenRitsuHyokaLabel.Text == BATSU)
                {
                    // 水質検査：不適正(3)
                    suishitsuHantei = 3;
                }
                else
                {
                    // △
                    if (pHHyokaLabel.Text == SANKAKU
                        || yozonSansoRyoHyokaLabel.Text == SANKAKU
                        || nijiToshidoHyokaLabel.Text == SANKAKU
                        || toshidoHyokaLabel.Text == SANKAKU
                        || zanryuensoHyokaLabel.Text == SANKAKU
                        || BODHyokaLabel.Text == SANKAKU
                        || enkabutsuIonHyokaLabel.Text == SANKAKU
                        || odeiChindenRitsuHyokaLabel.Text == SANKAKU)
                    {
                        // 水質検査：おおむね適正(2)
                        suishitsuHantei = 2;
                    }
                }

                // 大きい方を判定として返す
                if (suishitsuHantei > gaikanHantei)
                {
                    return suishitsuHantei.ToString();
                }
                else
                {
                    return gaikanHantei.ToString();
                }
            }

            // 判定区分 = 1, 2 or 3
            return _dispTable[0].KensaIraiHanteiKbn;
        }
        #endregion

        #region GetDefaultValueForGyoseiHokokuComboBox
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29  habu　　    行政報告レベルの自動設定を追加
        /// </history>
        private string GetDefaultValueForGyoseiHokokuComboBox()
        {
            int defaultGyoseiHokoku = 0;

            // 既に設定済みの場合は、そちらを使用する
            if(_dispTable[0].KensaIraiGyoseiHokokuLevel != "0" 
                && !string.IsNullOrEmpty(_dispTable[0].KensaIraiGyoseiHokokuLevel.Trim()))
            {
                return _dispTable[0].KensaIraiGyoseiHokokuLevel;
            }

            if (_shokenKekkaList != null)
            {
                foreach (GaikanKensaKekkaTblDataSet.ShokenKekkaListRow shokenRow in _shokenKekkaList)
                {
                    int hokokuLevel = TypeUtility.GetInt(shokenRow[_shokenKekkaList.ShokenHokokuLevelColumn]);

                    if (hokokuLevel > defaultGyoseiHokoku)
                    {
                        defaultGyoseiHokoku = hokokuLevel;
                    }
                }
            }

            if (_shokenKekkaHosokuList != null)
            {
                foreach (GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListRow shokenRow in _shokenKekkaHosokuList)
                {
                    int hokokuLevel = TypeUtility.GetInt(shokenRow[_shokenKekkaHosokuList.ShokenHokokuLevelColumn]);

                    if (hokokuLevel > defaultGyoseiHokoku)
                    {
                        defaultGyoseiHokoku = hokokuLevel;
                    }
                }
            }

            return defaultGyoseiHokoku.ToString();
        }
        #endregion

        #region to be removed
        //#region GetDefaultValueForHanteiComboBox
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： GetDefaultValueForHanteiComboBox
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/12/02  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.09
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private string GetDefaultValueForHanteiComboBox()
        //{
        //    // 判定区分 = 0
        //    if (_dispTable[0].KensaIraiHanteiKbn == "0" || string.IsNullOrEmpty(_dispTable[0].KensaIraiHanteiKbn.Trim()))
        //    {
        //        //// In case of 3
        //        //DataRow[] dr = _cl75Table.Select("GaikanKensaKekkaCheckKomokuHantei = '3'");
        //        //if (dr.Length > 0) { return "3"; }

        //        //// In case of 2
        //        //dr = _cl75Table.Select("GaikanKensaKekkaCheckKomokuHantei = '2'");
        //        //if (dr.Length > 0) { return "2"; }

        //        //// ×
        //        //if (pHHyokaLabel.Text == BATSU
        //        //    || yozonSansoRyoHyokaLabel.Text == BATSU
        //        //    || nijiToshidoHyokaLabel.Text == BATSU
        //        //    || toshidoHyokaLabel.Text == BATSU
        //        //    || zanryuensoHyokaLabel.Text == BATSU
        //        //    || BODHyokaLabel.Text == BATSU
        //        //    || enkabutsuIonHyokaLabel.Text == BATSU
        //        //    || odeiChindenRitsuHyokaLabel.Text == BATSU)
        //        //{
        //        //    return "3";
        //        //}

        //        //// △
        //        //if (pHHyokaLabel.Text == SANKAKU
        //        //    || yozonSansoRyoHyokaLabel.Text == SANKAKU
        //        //    || nijiToshidoHyokaLabel.Text == SANKAKU
        //        //    || toshidoHyokaLabel.Text == SANKAKU
        //        //    || zanryuensoHyokaLabel.Text == SANKAKU
        //        //    || BODHyokaLabel.Text == SANKAKU
        //        //    || enkabutsuIonHyokaLabel.Text == SANKAKU
        //        //    || odeiChindenRitsuHyokaLabel.Text == SANKAKU)
        //        //{
        //        //    return "2";
        //        //}

        //        //// Others
        //        //return "1";

        //        // 2014/12/12 AnhNV Update related to QASheet_20141211_2(ODC→ZYNAS)_回答 Start
        //        // ×
        //        DataRow[] dr = _cl75Table.Select("GaikanKensaKekkaCheckKomokuHantei = '3'");
        //        if (pHHyokaLabel.Text == BATSU
        //            || yozonSansoRyoHyokaLabel.Text == BATSU
        //            || nijiToshidoHyokaLabel.Text == BATSU
        //            || toshidoHyokaLabel.Text == BATSU
        //            || zanryuensoHyokaLabel.Text == BATSU
        //            || BODHyokaLabel.Text == BATSU
        //            || enkabutsuIonHyokaLabel.Text == BATSU
        //            || odeiChindenRitsuHyokaLabel.Text == BATSU
        //            || dr.Length > 0)
        //        {
        //            return "3";
        //        }

        //        // △
        //        dr = _cl75Table.Select("GaikanKensaKekkaCheckKomokuHantei = '2'");
        //        if (pHHyokaLabel.Text == SANKAKU
        //            || yozonSansoRyoHyokaLabel.Text == SANKAKU
        //            || nijiToshidoHyokaLabel.Text == SANKAKU
        //            || toshidoHyokaLabel.Text == SANKAKU
        //            || zanryuensoHyokaLabel.Text == SANKAKU
        //            || BODHyokaLabel.Text == SANKAKU
        //            || enkabutsuIonHyokaLabel.Text == SANKAKU
        //            || odeiChindenRitsuHyokaLabel.Text == SANKAKU
        //            || dr.Length > 0)
        //        {
        //            return "2";
        //        }

        //        // Others - ○
        //        return "1";
        //        // 2014/12/12 AnhNV Update related to QASheet_20141211_2(ODC→ZYNAS)_回答 End
        //    }

        //    // 判定区分 = 1, 2 or 3
        //    return _dispTable[0].KensaIraiHanteiKbn;
        //}
        //#endregion
        #endregion

        #region SetDefaultKekkaControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultKekkaControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.09
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultKekkaControl()
        {
            // Control index
            int itemNo = 1;
            foreach (CheckItemControl cic in _checkItemControl)
            {
                cic.ItemNo = itemNo;
                itemNo++;
            }

            // Default item no (from 1 to 30)
            itemNo = 1;
            foreach (SyokenKekkaControl skc in _syokenKekkaControl)
            {
                skc.ItemNo = itemNo;
                itemNo++;
            }
        }
        #endregion

        #region GetKomokuHanteiByHanteiLabel
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKomokuHanteiByHanteiLabel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hanteiLabel">○/△/×/－ (full-width or half-width)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetKomokuHanteiByHanteiLabel(string hanteiLabel)
        {
            string komokuHantei = string.Empty;

            // Compare without width
            if (String.Compare(hanteiLabel, MARU, CultureInfo.CurrentCulture, CompareOptions.IgnoreWidth) == 0)
            {
                // ○
                komokuHantei = "1";
            }
            else if (string.Compare(hanteiLabel, SANKAKU, CultureInfo.CurrentCulture, CompareOptions.IgnoreWidth) == 0)
            {
                // △
                komokuHantei = "2";
            }
            else if (string.Compare(hanteiLabel, BATSU, CultureInfo.CurrentCulture, CompareOptions.IgnoreWidth) == 0)
            {
                // ×
                komokuHantei = "3";
            }
            else if (string.Compare(hanteiLabel, HIKU, CultureInfo.CurrentCulture, CompareOptions.IgnoreWidth) == 0)
            {
                // －
                komokuHantei = "4";
            }

            return komokuHantei;
        }
        #endregion

        #endregion
    }
    #endregion
}