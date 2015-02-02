using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaIraiUketsukeSuisitsuKensaShosai
    /// <summary>
    /// 検査受付詳細（１１条水質）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者    内容
    /// 2014/12/09  豊田      新規作成
    /// 2014/12/10  豊田      DBアクセスを行わないよう変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaIraiUketsukeSuisitsuKensaShosai : FukjBaseForm
    {
        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        private enum DispMode
        {
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
        }
        #endregion

        #region フィールド(private)

        /// <summary>
        /// DispMode
        /// </summary>
        private DispMode _dispMode;

        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        private string _kensaIraiHoteiKbn;

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        private string _kensaIraiHokenjoCd;

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        private string _kensaIraiNendo;

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        private string _kensaIraiRenban;

        /// <summary>
        /// KensaKbn
        /// </summary>
        private string _kensaKbn;

        /// <summary>
        /// _iraiNendo
        /// </summary>
        private string _iraiNendo;

        /// <summary>
        /// _shishoCd
        /// </summary>
        private string _shishoCd;

        /// <summary>
        /// _iraiNo
        /// </summary>
        private string _iraiNo;

        /// <summary>
        /// 初期表示取得データ(検査台帳明細)
        /// </summary>
        private KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable _kensaDaichoDtl
            = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();

        /// <summary>
        /// 初期表示取得データ(検査依頼)
        /// </summary>
        private KensaIraiTblDataSet.KensaIraiTblDataTable _kensaIraiTbl
            = new KensaIraiTblDataSet.KensaIraiTblDataTable();

        /// <summary>
        /// 初期表示取得データ(水質検査情報)
        /// </summary>
        private SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable _suishitsuIraiInfo
            = new SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable();

        /// <summary>
        /// 初期表示取得データ(検査日)
        /// </summary>
        private SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable _maxKensaDt
            = new SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable();

        /// <summary>
        /// 編集の有無
        /// </summary>
        private bool _isModified = false;

        #endregion

        #region プロパティ

        /// <summary>
        /// 編集した検査依頼(UpdateDtは未編集)
        /// </summary>
        /// <returns></returns>
        public KensaIraiTblDataSet.KensaIraiTblDataTable ModifiedKensaIraiTbl
        {
            get { return _kensaIraiTbl; }
        }

        /// <summary>
        /// 編集した検査台帳明細(UpdateDtは未編集)
        /// </summary>
        /// <returns></returns>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable ModifiedKensaDaichoDtl
        {
            get { return _kensaDaichoDtl; }
        }

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeSuisitsuKensaShosai
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [Obsolete("【豊田】 この呼び出しは削除します。DataTableを引き渡すコンストラクタを使用してください。")]
        public SuishitsuKensaIraiUketsukeSuisitsuKensaShosai()
            : base()
        {
            InitializeComponent();

            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeSuisitsuKensaShosai
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kensaIraiHoteiKbn">検査依頼法定区分</param>
        /// <param name="kensaIraiHokenjoCd">検査依頼保健所コード</param>
        /// <param name="kensaIraiNendo">検査依頼年度</param>
        /// <param name="kensaIraiRenban">検査依頼連番</param>
        /// <param name="kensaKbn">検査台帳検査区分</param>
        /// <param name="iraiNendo">検査台帳依頼年度</param>
        /// <param name="shishoCd">検査台帳支所コード</param>
        /// <param name="iraiNo">検査台帳依頼書番号</param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [Obsolete("【豊田】 この呼び出しは削除します。DataTableを引き渡すコンストラクタを使用してください。")]
        public SuishitsuKensaIraiUketsukeSuisitsuKensaShosai(string kensaIraiHoteiKbn, string kensaIraiHokenjoCd, string kensaIraiNendo, string kensaIraiRenban,
                                                            string kensaKbn, string iraiNendo, string shishoCd, string iraiNo)
            : base()
        {
            InitializeComponent();

            SetControlDomain();

            _kensaIraiHoteiKbn = kensaIraiHoteiKbn;
            _kensaIraiHokenjoCd = kensaIraiHokenjoCd;
            _kensaIraiNendo = kensaIraiNendo;
            _kensaIraiRenban = kensaIraiRenban;
            _kensaKbn = kensaKbn;
            _iraiNendo = iraiNendo;
            _shishoCd = shishoCd;
            _iraiNo = iraiNo;
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeSuisitsuKensaShosai
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kensaDaichoDtl">初期表示データ(検査台帳明細)</param>
        /// <param name="kensaIraiTbl">初期表示データ(検査依頼)</param>
        /// <param name="suishitsuIraiInfo">初期表示データ(水質検査情報)</param>
        /// <param name="maxKensaDt">初期表示データ(検査日)</param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaIraiUketsukeSuisitsuKensaShosai(KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtl,
                                                                KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTbl,
                                                                SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable suishitsuIraiInfo,
                                                                SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable maxKensaDt)
            : base()
        {
            InitializeComponent();

            SetControlDomain();

            _kensaDaichoDtl = kensaDaichoDtl;
            _kensaIraiTbl = kensaIraiTbl;
            _suishitsuIraiInfo = suishitsuIraiInfo;
            _maxKensaDt = maxKensaDt;
        }
        #endregion

        #region イベントハンドラ

        #region SuishitsuKensaIraiUketsukeSuisitsuKensaShosai_Load(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaDaichoForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// 2014/12/10  豊田      DBアクセスを行わないよう変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeSuisitsuKensaShosai_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // データ取得
                DoSearch();

                // 取得データを画面項目に設定
                SetControlValue();

                // 詳細モード
                _dispMode = DispMode.Detail;

                // モードに応じて画面表示を切替
                SetDisplayControl();

                // 編集有無を初期化
                _isModified = false;

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 画面を終了（前画面に戻る）
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

        #region saisuiinSearchButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinSearchButton_Click
        /// <summary>
        /// 採水員検索ボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 採水員検索画面を表示して選択
                SaisuiinMstSearchForm dlg = new SaisuiinMstSearchForm();
                dlg.ShowDialog();

                // キャンセルされた
                if (dlg.DialogResult != DialogResult.OK)
                {
                    return;
                }

                // 選択されなかった
                if (dlg._selectedRow == null)
                {
                    return;
                }

                // 採水員コード
                saisuiinCdTextBox.Text = dlg._selectedRow.SaisuiinCd;
                // 採水員名称
                saisuiinNmTextBox.Text = dlg._selectedRow.SaisuiinNm;

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

        #region changeButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： changeButton_Click
        /// <summary>
        /// 変更ボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_dispMode == DispMode.Edit)
                {
                    // 確認モード
                    _dispMode = DispMode.Confirm;
                }
                else
                {
                    // 編集モード
                    _dispMode = DispMode.Edit;
                }

                // モードに応じて画面表示を切替
                SetDisplayControl();

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

        #region reInputButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： reInputButton_Click
        /// <summary>
        /// 再入力ボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 編集モード
                _dispMode = DispMode.Edit;

                // モードに応じて画面表示を切替
                SetDisplayControl();

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

        #region decisionButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： decisionButton_Click
        /// <summary>
        /// 確定ボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// 2014/12/10  豊田      DBアクセスを行わないよう変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 入力値チェック
                if (!CheckInputValue())
                {
                    return;
                }

                // 検査台帳明細
                _kensaDaichoDtl = CreateUpdateKensaDaichoDtl();

                // 検査依頼
                _kensaIraiTbl = CreateUpdateKensaIraiTbl();

                // 画面を終了（前画面に戻る）
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

        #region closeButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_isModified)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // 画面を終了（前画面に戻る）
                this.DialogResult = DialogResult.Cancel;
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

        #region TextBox_TextChanged(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TextBox_TextChanged
        /// <summary>
        /// テキスト編集 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            _isModified = true;
        }
        #endregion

        #region RadioButton_CheckedChanged(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： RadioButton_CheckedChanged
        /// <summary>
        /// ラジオボタン切り替え 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isModified = true;
        }
        #endregion

        #region CheckBox_CheckedChanged(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CheckBox_CheckedChanged
        /// <summary>
        /// チェックボックス切り替え 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _isModified = true;
        }
        #endregion

        #region SuishitsuKensaIraiUketsukeSuisitsuKensaShosai_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BushoMstShosaiForm_KeyDown
        /// <summary>
        /// キーダウン（ショートカット）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeSuisitsuKensaShosai_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F2:
                        changeButton.PerformClick();
                        break;
                    case Keys.F4:
                        reInputButton.PerformClick();
                        break;
                    case Keys.F5:
                        decisionButton.PerformClick();
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

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 採水員コード
            saisuiinCdTextBox.SetStdControlDomain(ZControlDomain.ZT_SAISUIIN_CD);

            // 残留塩素
            zanryuEnsoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 7);

            // 検査料金
            kensaRyokinTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 5);

            // 入金額
            nyukinGakTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 5);
        }
        #endregion

        #region DoSearch()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// 2014/12/10  豊田      DBアクセスを行わないよう変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // データアクセス無し
        }
        #endregion

        #region SetControlValue()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlValue()
        /// <summary>
        /// コントロールに取得データを設定
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// 2015/01/08  小松　　　受付日が空白の場合例外発生の対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlValue()
        {
            // 依頼書番号 
            iraishoNoTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSuishitsuIraiNoNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSuishitsuIraiNo;

            // 検査受付日付
            //uketsukeDtTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSuishitsuUketsukeDtNull()
            //    ? string.Empty : DateTime.ParseExact(_suishitsuIraiInfo[0].KensaIraiSuishitsuUketsukeDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");
            uketsukeDtTextBox.Text = (_suishitsuIraiInfo[0].IsKensaIraiSuishitsuUketsukeDtNull() || string.IsNullOrEmpty(_suishitsuIraiInfo[0].KensaIraiSuishitsuUketsukeDt))
                ? string.Empty : DateTime.ParseExact(_suishitsuIraiInfo[0].KensaIraiSuishitsuUketsukeDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");

            if (!_suishitsuIraiInfo[0].IsKensaIraiUketsukeKbnNull() && _suishitsuIraiInfo[0].KensaIraiUketsukeKbn == "2")
            {
                // 受付区分：収集
                uketsukeKbnShushuRadioButton.Checked = true;
                // 受付区分：持込
                uketsukeKbnMotikomiRadioButton.Checked = false;
            }
            else if (!_suishitsuIraiInfo[0].IsKensaIraiUketsukeKbnNull() && _suishitsuIraiInfo[0].KensaIraiUketsukeKbn == "1")
            {
                // 受付区分：収集
                uketsukeKbnShushuRadioButton.Checked = false;
                // 受付区分：持込
                uketsukeKbnMotikomiRadioButton.Checked = true;
            }
            else // デフォルト
            {
                // 受付区分：収集
                uketsukeKbnShushuRadioButton.Checked = true;
                // 受付区分：持込
                uketsukeKbnMotikomiRadioButton.Checked = false;
            }

            if (!_suishitsuIraiInfo[0].IsKensaIraiGenkinShunyuKbnNull() && _suishitsuIraiInfo[0].KensaIraiGenkinShunyuKbn == "2")
            {
                // 現金収入：無し
                genkinShunyuNashiRadioButton.Checked = true;
                // 現金収入：有り
                genkinShunyuAriRadioButton.Checked = false;
            }
            else if (!_suishitsuIraiInfo[0].IsKensaIraiGenkinShunyuKbnNull() && _suishitsuIraiInfo[0].KensaIraiGenkinShunyuKbn == "1")
            {
                // 現金収入：無し
                genkinShunyuNashiRadioButton.Checked = false;
                // 現金収入：有り
                genkinShunyuAriRadioButton.Checked = true;
            }
            else // デフォルト
            {
                // 現金収入：無し
                genkinShunyuNashiRadioButton.Checked = true;
                // 現金収入：有り
                genkinShunyuAriRadioButton.Checked = false;
            }

            // 採水員コード
            saisuiinCdTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSaisuiinCdNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSaisuiinCd;

            // 採水員名
            saisuiinNmTextBox.Text = _suishitsuIraiInfo[0].IsSaisuiinNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].SaisuiinNm;

            // 残留塩素
            zanryuEnsoTextBox.Text = _kensaDaichoDtl[0].IsKeiryoShomeiKekkaValueNull()
                ? "0" : _kensaDaichoDtl[0].KeiryoShomeiKekkaValue.ToString("#0.00");

            // 保健所非通知フラグ
            hokenjoTsutiCheckBox.Checked = !_suishitsuIraiInfo[0].IsKensaIraiHakkoKbn4Null() && _suishitsuIraiInfo[0].KensaIraiHakkoKbn4 == "1"
                ? true : false;

            // 市町村非通知フラグ
            shichosonTsutiCheckBox.Checked = !_suishitsuIraiInfo[0].IsKensaIraiHakkoKbn5Null() && _suishitsuIraiInfo[0].KensaIraiHakkoKbn5 == "1"
                ? true : false;

            // 水質検査
            SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtRow suishitsuDt = _maxKensaDt.FindByKensaIraiHoteiKbn("3");
            suishitsuKensaTextBox.Text = (suishitsuDt == null || suishitsuDt.IsMaxKensaDtNull() || string.IsNullOrEmpty(suishitsuDt.MaxKensaDt))
                ? string.Empty : DateTime.ParseExact(suishitsuDt.MaxKensaDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");

            // 外観検査
            SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtRow gaikanDt = _maxKensaDt.FindByKensaIraiHoteiKbn("2");
            gaikanKensaTextBox.Text = (gaikanDt == null || gaikanDt.IsMaxKensaDtNull() || string.IsNullOrEmpty(gaikanDt.MaxKensaDt))
                ? string.Empty : DateTime.ParseExact(gaikanDt.MaxKensaDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");

            // 7条検査
            SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtRow jo7Dt = _maxKensaDt.FindByKensaIraiHoteiKbn("1");
            jo7KensaTextBox.Text = (jo7Dt == null || jo7Dt.IsMaxKensaDtNull() || string.IsNullOrEmpty(jo7Dt.MaxKensaDt))
                ? string.Empty : DateTime.ParseExact(jo7Dt.MaxKensaDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");

            // 検査料金
            kensaRyokinTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiKensaAmtNull()
                ? "0" : _suishitsuIraiInfo[0].KensaIraiKensaAmt.ToString("#,0");

            // 入金額
            nyukinGakTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiNyukinzumiAmtNull()
                ? "0" : _suishitsuIraiInfo[0].KensaIraiNyukinzumiAmt.ToString("#,0");

            // 浄化槽台帳保健所コード
            jyokasoDaichoHokenjoCdTextBox.Text = _suishitsuIraiInfo[0].KensaIraiJokasoHokenjoCd;

            // 浄化槽台帳年度
            jyokasoDaichoNendoTextBox.Text = Common.Common.ConvertToHoshouNendoWareki(_suishitsuIraiInfo[0].KensaIraiJokasoTorokuNendo);

            // 浄化槽台帳連番
            jyokasoDaichoRenbanTextBox.Text = _suishitsuIraiInfo[0].KensaIraiJokasoRenban;

            // 設置者氏名
            setchshaShimeiTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaNm;

            // 電話番号
            setchshaTelNoTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaTelNoNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaTelNo;

            // カナ名
            kanaNmTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaKanaNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaKana;

            // 設置者住所
            setchshaAdrTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaAdrNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaAdr;

            // 設置場所
            setchshaBashoTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchibashoAdrNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchibashoAdr;

            // 保守業者
            hoshuGyoshaTextBox.Text = _suishitsuIraiInfo[0].IsHoshutenkenGyoshaNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].HoshutenkenGyoshaNm;

            // 清掃業者
            seisoGyoshaTextBox.Text = _suishitsuIraiInfo[0].IsSeisoGyoshaNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].SeisoGyoshaNm;

            // 建築用途１    表示
            kenchikuYoto1TextBox.Text = _suishitsuIraiInfo[0].IsKenchikuyotoNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].KenchikuyotoNm;

            // 建築用途２    表示
            kenchikuYoto2TextBox.Text = _suishitsuIraiInfo[0].IskentikuYotoNm2Null()
                ? string.Empty : _suishitsuIraiInfo[0].kentikuYotoNm2;

            // 建築用途３    表示
            kenchikuYoto3TextBox.Text = _suishitsuIraiInfo[0].IskentikuYotoNm3Null()
                ? string.Empty : _suishitsuIraiInfo[0].kentikuYotoNm3;

            // 建築用途４    表示
            kenchikuYoto4TextBox.Text = _suishitsuIraiInfo[0].IskentikuYotoNm4Null()
                ? string.Empty : _suishitsuIraiInfo[0].kentikuYotoNm4;

            // 建築用途５    表示
            kenchikuYoto5TextBox.Text = _suishitsuIraiInfo[0].IskentikuYotoNm5Null()
                ? string.Empty : _suishitsuIraiInfo[0].kentikuYotoNm5;

            // メーカー
            makerTextBox.Text = _suishitsuIraiInfo[0].IsMakerGyoshaNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].MakerGyoshaNm;

            // 型式名
            katashikiNmTextBox.Text = _suishitsuIraiInfo[0].IsKatashikiNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].KatashikiNm;

            if (!_suishitsuIraiInfo[0].IsKensaIraiShorihoshikiKbnNull() && _suishitsuIraiInfo[0].KensaIraiShorihoshikiKbn == "1")
            {
                // 処理方式：合併
                shorihoshikiGappeiKbnRadioButton.Checked = true;
                // 処理方式：単独
                shorihoshikiTandokuKbnRadioButton.Checked = false;
            }
            else if (!_suishitsuIraiInfo[0].IsKensaIraiShorihoshikiKbnNull() && _suishitsuIraiInfo[0].KensaIraiShorihoshikiKbn == "2")
            {
                // 処理方式：合併
                shorihoshikiGappeiKbnRadioButton.Checked = false;
                // 処理方式：単独    表示
                shorihoshikiTandokuKbnRadioButton.Checked = true;
            }
            else // デフォルト
            {
                // 処理方式：合併
                shorihoshikiGappeiKbnRadioButton.Checked = true;
                // 処理方式：単独
                shorihoshikiTandokuKbnRadioButton.Checked = false;
            }

            // 処理方式名 
            shorihoshikiNmTextBox.Text = _suishitsuIraiInfo[0].IsShoriHoshikiNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].ShoriHoshikiNm;

            // 人槽 
            ninsoTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiShoritaishoJininNull()
                ? "0" : _suishitsuIraiInfo[0].KensaIraiShoritaishoJinin.ToString();

        }
        #endregion

        #region SetDisplayControl()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlValue()
        /// <summary>
        /// コントロールの活性化制御
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            // 依頼書番号    表示
            iraishoNoTextBox.CustomReadOnly = true;
            // 受付日    表示
            uketsukeDtTextBox.CustomReadOnly = true;
            // 現金収入：無し    表示
            genkinShunyuNashiRadioButton.Enabled = false;
            // 現金収入：有り    表示
            genkinShunyuAriRadioButton.Enabled = false;
            // 採水員名    表示
            saisuiinNmTextBox.CustomReadOnly = true;
            // 水質検査    表示
            suishitsuKensaTextBox.CustomReadOnly = true;
            // 外観検査    表示
            gaikanKensaTextBox.CustomReadOnly = true;
            // 7条検査    表示
            jo7KensaTextBox.CustomReadOnly = true;
            // 浄化槽台帳保健所コード    表示
            jyokasoDaichoHokenjoCdTextBox.CustomReadOnly = true;
            // 浄化槽台帳年度    表示
            jyokasoDaichoNendoTextBox.CustomReadOnly = true;
            // 浄化槽台帳連番    表示
            jyokasoDaichoRenbanTextBox.CustomReadOnly = true;
            // 設置者氏名    表示
            setchshaShimeiTextBox.CustomReadOnly = true;
            // 電話番号    表示
            setchshaTelNoTextBox.CustomReadOnly = true;
            // カナ名    表示
            kanaNmTextBox.CustomReadOnly = true;
            // 設置者住所    表示
            setchshaAdrTextBox.CustomReadOnly = true;
            // 設置場所    表示
            setchshaBashoTextBox.CustomReadOnly = true;
            // 保守業者    表示
            hoshuGyoshaTextBox.CustomReadOnly = true;
            // 清掃業者    表示
            seisoGyoshaTextBox.CustomReadOnly = true;
            // 建築用途１    表示
            kenchikuYoto1TextBox.CustomReadOnly = true;
            // 建築用途２    表示
            kenchikuYoto2TextBox.CustomReadOnly = true;
            // 建築用途３    表示
            kenchikuYoto3TextBox.CustomReadOnly = true;
            // 建築用途４    表示
            kenchikuYoto4TextBox.CustomReadOnly = true;
            // 建築用途５    表示
            kenchikuYoto5TextBox.CustomReadOnly = true;
            // メーカー    表示
            makerTextBox.CustomReadOnly = true;
            // 型式名    表示
            katashikiNmTextBox.CustomReadOnly = true;
            // 処理方式区分：合併    表示
            shorihoshikiGappeiKbnRadioButton.Enabled = false;
            // 処理方式区分：単独    表示
            shorihoshikiTandokuKbnRadioButton.Enabled = false;
            // 処理方式名    表示
            shorihoshikiNmTextBox.CustomReadOnly = true;
            // 人槽    表示
            ninsoTextBox.CustomReadOnly = true;
            // 検査料金    入力
            kensaRyokinTextBox.CustomReadOnly = true;
            // 入金額    入力
            nyukinGakTextBox.CustomReadOnly = true;

            switch (_dispMode)
            {
                case DispMode.Detail:

                    // 採水員コード    入力
                    saisuiinCdTextBox.CustomReadOnly = true;
                    // 採水員検索ボタン
                    saisuiinSearchButton.Enabled = false;
                    // 受付区分：収集    選択
                    uketsukeKbnShushuRadioButton.Enabled = false;
                    // 受付区分：持込    選択
                    uketsukeKbnMotikomiRadioButton.Enabled = false;
                    // 保健所非通知フラグ    入力
                    hokenjoTsutiCheckBox.Enabled = false;
                    // 市町村非通知フラグ    入力
                    shichosonTsutiCheckBox.Enabled = false;
                    // 残留塩素    入力
                    zanryuEnsoTextBox.CustomReadOnly = true;

                    // 変更ボタン
                    changeButton.Visible = true;
                    // 再入力ボタン
                    reInputButton.Visible = false;
                    // 確定ボタン
                    decisionButton.Visible = false;
                    // 閉じるボタン
                    closeButton.Visible = true;

                    break;

                case DispMode.Edit:

                    // 採水員コード    入力
                    saisuiinCdTextBox.CustomReadOnly = false;
                    // 採水員検索ボタン
                    saisuiinSearchButton.Enabled = true;
                    // 受付区分：収集    選択
                    uketsukeKbnShushuRadioButton.Enabled = true;
                    // 受付区分：持込    選択
                    uketsukeKbnMotikomiRadioButton.Enabled = true;
                    // 保健所非通知フラグ    入力
                    hokenjoTsutiCheckBox.Enabled = true;
                    // 市町村非通知フラグ    入力
                    shichosonTsutiCheckBox.Enabled = true;
                    // 残留塩素    入力
                    zanryuEnsoTextBox.CustomReadOnly = false;

                    // 変更ボタン
                    changeButton.Visible = true;
                    // 再入力ボタン
                    reInputButton.Visible = false;
                    // 確定ボタン
                    decisionButton.Visible = false;
                    // 閉じるボタン
                    closeButton.Visible = true;

                    break;

                case DispMode.Confirm:

                    // 採水員コード    入力
                    saisuiinCdTextBox.CustomReadOnly = true;
                    // 採水員検索ボタン
                    saisuiinSearchButton.Enabled = false;
                    // 受付区分：収集    選択
                    uketsukeKbnShushuRadioButton.Enabled = false;
                    // 受付区分：持込    選択
                    uketsukeKbnMotikomiRadioButton.Enabled = false;
                    // 保健所非通知フラグ    入力
                    hokenjoTsutiCheckBox.Enabled = false;
                    // 市町村非通知フラグ    入力
                    shichosonTsutiCheckBox.Enabled = false;
                    // 残留塩素    入力
                    zanryuEnsoTextBox.CustomReadOnly = true;

                    // 変更ボタン
                    changeButton.Visible = false;
                    // 再入力ボタン
                    reInputButton.Visible = true;
                    // 確定ボタン
                    decisionButton.Visible = true;
                    // 閉じるボタン
                    closeButton.Visible = true;

                    break;
            }
        }

        #endregion

        #region CheckInputValue()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckInputValue()
        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <param name="mode"></param>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckInputValue()
        {
            // 入力チェック無し

            return true;
        }
        #endregion

        #region CreateUpdateKensaDaichoDtl()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateUpdateKensaDaichoDtl()
        /// <summary>
        /// 更新データの作成
        /// </summary>
        /// <param name="mode"></param>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable CreateUpdateKensaDaichoDtl()
        {
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable datatable = _kensaDaichoDtl;

            if (string.IsNullOrEmpty(zanryuEnsoTextBox.Text))
            {
                datatable[0].KeiryoShomeiKekkaValue = 0;
            }
            else
            {
                datatable[0].KeiryoShomeiKekkaValue = decimal.Parse(zanryuEnsoTextBox.Text);
            }

            // 更新時刻は楽観ロックチェックで使用するため、ApplicationLogicで設定する

            //更新者
            datatable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            //更新端末
            datatable[0].UpdateTarm = Dns.GetHostName();

            datatable[0].AcceptChanges();
            datatable[0].SetModified();

            return datatable;
        }
        #endregion

        #region CreateUpdateKensaIraiTbl()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateUpdateKensaIraiTbl()
        /// <summary>
        /// 更新データの作成
        /// </summary>
        /// <param name="mode"></param>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/09  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateUpdateKensaIraiTbl()
        {
            KensaIraiTblDataSet.KensaIraiTblDataTable datatable = _kensaIraiTbl;

            // 受付区分
            if (uketsukeKbnShushuRadioButton.Checked)
            {
                datatable[0].KensaIraiUketsukeKbn = "2";
            }
            else if (uketsukeKbnMotikomiRadioButton.Checked)
            {
                datatable[0].KensaIraiUketsukeKbn = "1";
            }

            // 保健所非通知フラグ
            if (hokenjoTsutiCheckBox.Checked)
            {
                datatable[0].KensaIraiHakkoKbn4 = "1";
            }
            else
            {
                datatable[0].KensaIraiHakkoKbn4 = "0";
            }

            // 市町村非通知フラグ
            if (shichosonTsutiCheckBox.Checked)
            {
                datatable[0].KensaIraiHakkoKbn5 = "1";
            }
            else
            {
                datatable[0].KensaIraiHakkoKbn5 = "0";
            }

            // 採水員コード
            if (string.IsNullOrEmpty(saisuiinCdTextBox.Text))
            {
                datatable[0].KensaIraiSaisuiinCd = string.Empty;
            }
            else
            {
                datatable[0].KensaIraiSaisuiinCd = saisuiinCdTextBox.Text;
            }

            // ステータス区分（水質検査受付済み）
            datatable[0].KensaIraiStatusKbn = "50";
            // 外観日報区分（未登録）
            datatable[0].KensaIraiGaikanNippoKbn = "0";
            // 水質日報区分（未登録）
            datatable[0].KensaIraiSuishitsuNippoKbn = "0";
            // 請求区分（未登録）
            datatable[0].KensaIraiSeikyuKbn = "0";

            // 更新時刻は楽観ロックチェックで使用するため、ApplicationLogicで設定する

            //更新者
            datatable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            //更新端末
            datatable[0].UpdateTarm = Dns.GetHostName();

            datatable[0].AcceptChanges();
            datatable[0].SetModified();

            return datatable;
        }
        #endregion

        #endregion
    }
    #endregion
}
