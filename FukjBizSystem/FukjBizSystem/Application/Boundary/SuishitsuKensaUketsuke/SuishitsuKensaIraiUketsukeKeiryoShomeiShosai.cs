using System;
using System.Data;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeKeiryoShomeiShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaIraiUketsukeKeiryoShomeiShosai
    /// <summary>
    /// 検査受付詳細（計量証明）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者    内容
    /// 2014/12/10  豊田      新規作成
    /// 2014/12/10  豊田      DBアクセスを行わないよう変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaIraiUketsukeKeiryoShomeiShosai : FukjBaseForm
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
        /// 初期表示取得データ(水質検査情報)
        /// </summary>
        private SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable _keiryoShomeiIraiInfo { get; set; }

        /// <summary>
        /// 初期表示取得データ(検査セットパターン)
        /// </summary>
        private SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable _kensaSetPattern { get; set; }

        /// <summary>
        /// 初期表示取得データ(計量証明依頼)
        /// </summary>
        private KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable _keiryoShomeiIraiTblDT { get; set; }

        /// <summary>
        /// 編集の有無
        /// </summary>
        private bool _isModified = false;

        #endregion

        #region プロパティ

        /// <summary>
        /// 編集した計量証明依頼(UpdateDtは未編集)
        /// </summary>
        /// <returns></returns>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable ModifiedKeiryoShomeiIraiTblDT
        {
            get { return _keiryoShomeiIraiTblDT; }
        }

        /// 検査セット名
        public string KeiryoShomeiSetNm = string.Empty;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeKeiryoShomeiShosai
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [Obsolete("【豊田】 この呼び出しは削除します。DataTableを引き渡すコンストラクタを使用してください。")]
        public SuishitsuKensaIraiUketsukeKeiryoShomeiShosai()
            : base()
        {
            InitializeComponent();

            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeKeiryoShomeiShosai
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="keiryoShomeiIraiInfo">初期表示データ(水質検査情報)</param>
        /// <param name="kensaSetPattern">初期表示データ(検査セットパターン)</param>
        /// <param name="keiryoShomeiIraiTblDT">初期表示データ(計量証明依頼)</param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaIraiUketsukeKeiryoShomeiShosai(SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable keiryoShomeiIraiInfo,
                                                                SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable kensaSetPattern,
                                                                KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable keiryoShomeiIraiTblDT)
            : base()
        {
            InitializeComponent();

            SetControlDomain();

            _keiryoShomeiIraiInfo = keiryoShomeiIraiInfo;
            _kensaSetPattern = kensaSetPattern;
            _keiryoShomeiIraiTblDT = keiryoShomeiIraiTblDT;
        }
        #endregion

        #region イベントハンドラ

        #region SuishitsuKensaIraiUketsukeKeiryoShomeiShosai_Load(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaDaichoForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/10  豊田      新規作成
        /// 2014/12/10  豊田      DBアクセスを行わないよう変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeKeiryoShomeiShosai_Load(object sender, EventArgs e)
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
        /// 2014/12/10  豊田      新規作成
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
        /// 2014/12/10  豊田      新規作成
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
        /// 2014/12/10  豊田      新規作成
        /// 2014/12/10  豊田      DBアクセスを行わないよう変更
        /// 2015/01/11  小松　　　検査セット名も返す
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

                // 計量証明依頼
                _keiryoShomeiIraiTblDT = CreateUpdateKeiryoShomeiIrai();

                // 検査セット名
                KeiryoShomeiSetNm = string.Empty;
                DataRow[] targetRows = _kensaSetPattern.Select(string.Format("DaichoKensaKomokuEdaban='{0}'", kensaSetComboBox.SelectedValue.ToString()));
                if (targetRows.Length > 0)
                {
                    SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternRow targetRow = (SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternRow)targetRows[0];
                    KeiryoShomeiSetNm = targetRow.DaichoKensaSetNm;
                }

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
        /// 2014/12/10  豊田      新規作成
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
        /// 2014/12/10  豊田      新規作成
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
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isModified = true;
        }
        #endregion

        #region SuishitsuKensaIraiUketsukeKeiryoShomeiShosai_KeyDown(object sender, KeyEventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BushoMstShosaiForm_KeyDown
        /// <summary>
        /// キーダウン（ショートカット）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeKeiryoShomeiShosai_KeyDown(object sender, KeyEventArgs e)
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

        #region kensaSetComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaSetComboBox_SelectionChangeCommitted
        /// <summary>
        /// コンボボックスの選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaSetComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 試験項目リストの差し替え
            SetShikenKomokuList();

            _isModified = true;
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
        /// 2014/12/09  小松      新規作成
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
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 採水員コード
            saisuiinCdTextBox.SetStdControlDomain(ZControlDomain.ZT_SAISUIIN_CD);

            // 採水日付
            saisuiDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 8, HorizontalAlignment.Left);

            // 採水時分
            saisuiTimeTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, HorizontalAlignment.Left);

            // 水温
            suionTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 7);

            // 気温
            kionTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 7);

            // 検査料金
            kensaRyokinTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM);
            // 消費税
            shohizeiTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM);
            // 税込額
            zeikomiKensaRyokinTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM);
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
        /// 2014/12/10  豊田      新規作成
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
        /// 2014/12/10  豊田      新規作成
        /// 2014/12/28  小松      浄化槽台帳が未指定の場合に詳細表示で例外発生の件対応
        /// 2015/01/08  小松　　　受付日が空白の場合例外発生の対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlValue()
        {
            // 依頼書番号 
            iraishoNoTextBox.Text = _keiryoShomeiIraiInfo[0].KeiryoShomeiIraiRenban;

            // 受付日
            //uketsukeDtTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiIraiUketsukeDtNull()
            //    ? string.Empty : DateTime.ParseExact(_keiryoShomeiIraiInfo[0].KeiryoShomeiIraiUketsukeDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");
            uketsukeDtTextBox.Text = (_keiryoShomeiIraiInfo[0].IsKeiryoShomeiIraiUketsukeDtNull() || string.IsNullOrEmpty(_keiryoShomeiIraiInfo[0].KeiryoShomeiIraiUketsukeDt))
                ? string.Empty : DateTime.ParseExact(_keiryoShomeiIraiInfo[0].KeiryoShomeiIraiUketsukeDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");

            if (!_keiryoShomeiIraiInfo[0].IsKeiryoShomeiUketsukeKbnNull() && _keiryoShomeiIraiInfo[0].KeiryoShomeiUketsukeKbn == "2")
            {
                // 受付区分：収集
                uketsukeKbnShushuRadioButton.Checked = true;
                // 受付区分：持込
                uketsukeKbnMotikomiRadioButton.Checked = false;
            }
            else if (!_keiryoShomeiIraiInfo[0].IsKeiryoShomeiUketsukeKbnNull() && _keiryoShomeiIraiInfo[0].KeiryoShomeiUketsukeKbn == "1")
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

            if (!_keiryoShomeiIraiInfo[0].IsKeiryoShomeiGenkinShunyuFlgNull() && _keiryoShomeiIraiInfo[0].KeiryoShomeiGenkinShunyuFlg == "2")
            {
                // 現金収入：無し
                genkinShunyuNashiRadioButton.Checked = true;
                // 現金収入：有り
                genkinShunyuAriRadioButton.Checked = false;
            }
            else if (!_keiryoShomeiIraiInfo[0].IsKeiryoShomeiGenkinShunyuFlgNull() && _keiryoShomeiIraiInfo[0].KeiryoShomeiGenkinShunyuFlg == "1")
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
            saisuiinCdTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiSaisuiinCdNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].KeiryoShomeiSaisuiinCd;

            // 採水員名
            saisuiinNmTextBox.Text = _keiryoShomeiIraiInfo[0].IsSaisuiinNmNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].SaisuiinNm;

            // 採水日
            saisuiDtTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiSaisuiDtNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].KeiryoShomeiSaisuiDt.ToString();

            // 採水時刻
            saisuiTimeTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiSaisuiTimeNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].KeiryoShomeiSaisuiTime.ToString();

            // 水温
            suionTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiSuionNull()
                ? "0" : _keiryoShomeiIraiInfo[0].KeiryoShomeiSuion.ToString();

            // 気温
            kionTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiKionNull()
                ? "0" : _keiryoShomeiIraiInfo[0].KeiryoShomeiKion.ToString();

            // 検査項目枝番
            string kensakomokuEdaban = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiKensakomokuEdabanNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].KeiryoShomeiKensakomokuEdaban.ToString();

            #region 検査セット

            // 検査セット
            FukjBizSystem.Application.Utility.Utility.SetComboBoxList(kensaSetComboBox, _kensaSetPattern, "DaichoKensaSetNm", "DaichoKensaKomokuEdaban", false);

            // 検査セットコンボボックス
            // 一旦、未選択
            kensaSetComboBox.SelectedIndex = -1;
            if (_kensaSetPattern.Count > 0)
            {
                if (string.IsNullOrEmpty(kensakomokuEdaban))
                {
                    // 未指定の場合は、先頭を選択
                    kensaSetComboBox.SelectedIndex = 0;
                }
                else
                {
                    // 検査項目枝番指定
                    kensaSetComboBox.SelectedValue = kensakomokuEdaban;
                }
            }

            // 試験項目リストの差し替え
            SetShikenKomokuList();

            #endregion

            // 指定済みの場合、登録時の料金を表示
            if (!string.IsNullOrEmpty(kensakomokuEdaban))
            {
                // 検査料金
                kensaRyokinTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiKensaRyokinNull()
                    ? "0" : _keiryoShomeiIraiInfo[0].KeiryoShomeiKensaRyokin.ToString("#,0");

                // 消費税
                shohizeiTextBox.Text = _keiryoShomeiIraiInfo[0].IsKeiryoShomeiShohizeiNull()
                    ? "0" : _keiryoShomeiIraiInfo[0].KeiryoShomeiShohizei.ToString("#,0");

                // 税込額
                zeikomiKensaRyokinTextBox.Text = (
                    (_keiryoShomeiIraiInfo[0].IsKeiryoShomeiKensaRyokinNull() ? 0 : _keiryoShomeiIraiInfo[0].KeiryoShomeiKensaRyokin) +
                    (_keiryoShomeiIraiInfo[0].IsKeiryoShomeiShohizeiNull() ? 0 : _keiryoShomeiIraiInfo[0].KeiryoShomeiShohizei)
                    ).ToString("#,0");
            }

            // 浄化槽台帳保健所コード
            jyokasoDaichoHokenjoCdTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoHokenjoCdNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].JokasoHokenjoCd;

            // 浄化槽台帳年度
            jyokasoDaichoNendoTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoTorokuNendoNull()
                ? string.Empty : Common.Common.ConvertToHoshouNendoWareki(_keiryoShomeiIraiInfo[0].JokasoTorokuNendo);

            // 浄化槽台帳連番
            jyokasoDaichoRenbanTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoRenbanNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].JokasoRenban;

            // 設置者氏名
            setchshaShimeiTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoSetchishaNmNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].JokasoSetchishaNm;

            // 電話番号
            setchshaTelNoTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoSetchishaTelNoNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].JokasoSetchishaTelNo;

            // カナ名
            kanaNmTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoSetchishaKanaNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].JokasoSetchishaKana;

            // 設置者住所
            setchshaAdrTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoSetchishaAdrNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].JokasoSetchishaAdr;

            // 設置場所
            setchshaBashoTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoSetchiBashoAdrNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].JokasoSetchiBashoAdr;

            // 採水業者
            saisuiGyoshaTextBox.Text = _keiryoShomeiIraiInfo[0].IsSaisuiGyoshaNmNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].SaisuiGyoshaNm;

            // 建築用途１    表示
            kenchikuYoto1TextBox.Text = _keiryoShomeiIraiInfo[0].IskentikuYotoNm1Null()
                ? string.Empty : _keiryoShomeiIraiInfo[0].kentikuYotoNm1;

            // 建築用途２    表示
            kenchikuYoto2TextBox.Text = _keiryoShomeiIraiInfo[0].IskentikuYotoNm2Null()
                ? string.Empty : _keiryoShomeiIraiInfo[0].kentikuYotoNm2;

            // 建築用途３    表示
            kenchikuYoto3TextBox.Text = _keiryoShomeiIraiInfo[0].IskentikuYotoNm3Null()
                ? string.Empty : _keiryoShomeiIraiInfo[0].kentikuYotoNm3;

            // 建築用途４    表示
            kenchikuYoto4TextBox.Text = _keiryoShomeiIraiInfo[0].IskentikuYotoNm4Null()
                ? string.Empty : _keiryoShomeiIraiInfo[0].kentikuYotoNm4;

            // 建築用途５    表示
            kenchikuYoto5TextBox.Text = _keiryoShomeiIraiInfo[0].IskentikuYotoNm5Null()
                ? string.Empty : _keiryoShomeiIraiInfo[0].kentikuYotoNm5;

            // メーカー
            makerTextBox.Text = _keiryoShomeiIraiInfo[0].IsMakerGyoshaNmNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].MakerGyoshaNm;

            // 型式名
            katashikiNmTextBox.Text = _keiryoShomeiIraiInfo[0].IsKatashikiNmNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].KatashikiNm;

            if (!_keiryoShomeiIraiInfo[0].IsJokasoShoriHosikiKbnNull() && _keiryoShomeiIraiInfo[0].JokasoShoriHosikiKbn == "1")
            {
                // 処理方式：合併
                shorihoshikiGappeiKbnRadioButton.Checked = true;
                // 処理方式：単独
                shorihoshikiTandokuKbnRadioButton.Checked = false;
            }
            else if (!_keiryoShomeiIraiInfo[0].IsJokasoShoriHosikiKbnNull() && _keiryoShomeiIraiInfo[0].JokasoShoriHosikiKbn == "2")
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
            shorihoshikiNmTextBox.Text = _keiryoShomeiIraiInfo[0].IsShoriHoshikiNmNull()
                ? string.Empty : _keiryoShomeiIraiInfo[0].ShoriHoshikiNm;

            // 人槽 
            ninsoTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoShoriTaishoJininNull()
                ? "0" : _keiryoShomeiIraiInfo[0].JokasoShoriTaishoJinin.ToString();

            // 処理目標水質
            syoriMokuhyoBODTextBox.Text = _keiryoShomeiIraiInfo[0].IsJokasoSyoriMokuhyoBODNull()
                ? "0" : _keiryoShomeiIraiInfo[0].JokasoSyoriMokuhyoBOD.ToString();

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
        /// 2014/12/10  豊田      新規作成
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
            // 検査項目リスト    表示
            kensaKomokuListBox.Enabled = false;
            // 検査料金    表示
            kensaRyokinTextBox.CustomReadOnly = true;
            // 消費税    表示
            shohizeiTextBox.CustomReadOnly = true;
            // 税込額    表示
            zeikomiKensaRyokinTextBox.CustomReadOnly = true;
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
            // 採水業者    表示
            saisuiGyoshaTextBox.CustomReadOnly = true;
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
            // 処理目標水質    表示
            syoriMokuhyoBODTextBox.CustomReadOnly = true;

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
                    // 採水日付    入力
                    saisuiDtTextBox.CustomReadOnly = true;
                    // 採水時分    入力
                    saisuiTimeTextBox.CustomReadOnly = true;
                    // 水温    入力
                    suionTextBox.CustomReadOnly = true;
                    // 気温    入力
                    kionTextBox.CustomReadOnly = true;

                    // 検査セット    選択
                    kensaSetComboBox.Enabled = false;

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
                    // 採水日付    入力
                    saisuiDtTextBox.CustomReadOnly = false;
                    // 採水時分    入力
                    saisuiTimeTextBox.CustomReadOnly = false;
                    // 水温    入力
                    suionTextBox.CustomReadOnly = false;
                    // 気温    入力
                    kionTextBox.CustomReadOnly = false;

                    // 検査セット    選択
                    kensaSetComboBox.Enabled = true;

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
                    // 採水日付    入力
                    saisuiDtTextBox.CustomReadOnly = true;
                    // 採水時分    入力
                    saisuiTimeTextBox.CustomReadOnly = true;
                    // 水温    入力
                    suionTextBox.CustomReadOnly = true;
                    // 気温    入力
                    kionTextBox.CustomReadOnly = true;

                    // 検査セット    選択
                    kensaSetComboBox.Enabled = false;

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

        #region SetShikenKomokuList()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetShikenKomokuList()
        /// <summary>
        /// 試験項目リストの表示切替
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetShikenKomokuList()
        {
            // ArgumentExceptionになるのでコメントアウト
            // (以降の処理で Datasourceに再バインドするのでOK)
            //kensaKomokuListBox.Items.Clear();

            if (kensaSetComboBox.SelectedIndex != -1)
            {
                // 選択された検査項目セットに紐づく試験項目を取得
                IGetSuishitsuShikenKoumokuListALInput alInpiut = new GetSuishitsuShikenKoumokuListALInput();
                alInpiut.KensaIraiJokasoHokenjoCd = _keiryoShomeiIraiTblDT[0].KeiryoShomeiJokasoDaichoHokenjoCd;
                alInpiut.KensaIraiJokasoTorokuNendo = _keiryoShomeiIraiTblDT[0].KeiryoShomeiJokasoDaichoNendo;
                alInpiut.KensaIraiJokasoRenban = _keiryoShomeiIraiTblDT[0].KeiryoShomeiJokasoDaichoRenban;
                alInpiut.DaichoKensaKomokuEdaban = kensaSetComboBox.SelectedValue.ToString();

                IGetSuishitsuShikenKoumokuListALOutput alOutput = new GetSuishitsuShikenKoumokuListApplicationLogic().Execute(alInpiut);

                // 取得した試験項目をリストに追加
                Utility.Utility.SetListBoxSource(kensaKomokuListBox, alOutput.SuishitsuShikenKoumokuList, "SeishikiNm", "SuishitsuShikenKoumokuCd");

                // 検査料金
                decimal kensaRyokin = 0;
                // 消費税
                decimal shohizei = 0;
                // 20150201 sou Start
                //FukjBizSystem.Application.Utility.KeiryoShomeiUtility.KeiryoshomeiKensaRyokinShukei(
                //    uketsukeDtTextBox.Text, alInpiut.KensaIraiJokasoHokenjoCd, alInpiut.KensaIraiJokasoTorokuNendo, alInpiut.KensaIraiJokasoRenban, alInpiut.DaichoKensaKomokuEdaban,
                //    out kensaRyokin, out shohizei);
                //
                DataRow[] targetRows = _kensaSetPattern.Select(string.Format("DaichoKensaKomokuEdaban='{0}'", kensaSetComboBox.SelectedValue.ToString()));
                if (targetRows.Length > 0)
                {
                    SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternRow targetRow = (SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternRow)targetRows[0];
                    // 検査料金
                    kensaRyokin = targetRow.DaichoKensaKomokuKensaAmt;
                    // 消費税（小数以下切捨）
                    shohizei = Math.Floor(targetRow.DaichoKensaKomokuKensaAmt
                             * Common.Common.GetSyohizei(Boundary.Common.Common.GetCurrentTimestamp().ToString("yyyyMMdd")));
                }
                else
                {
                    // 検査料金
                    kensaRyokin = 0;
                    // 消費税
                    shohizei = 0;
                }
                // 20150201 sou End

                // 検査料金
                kensaRyokinTextBox.Text = kensaRyokin.ToString("#,0");
                // 消費税
                shohizeiTextBox.Text = shohizei.ToString("#,0");
                // 税込額
                zeikomiKensaRyokinTextBox.Text = (kensaRyokin + shohizei).ToString("#,0");
            }
            else
            {
                // 未選択時はなにも表示しない
                kensaKomokuListBox.DataSource = null;

                // 検査料金
                kensaRyokinTextBox.Text = "0";
                // 消費税
                shohizeiTextBox.Text = "0";
                // 税込額
                zeikomiKensaRyokinTextBox.Text = "0";
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
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckInputValue()
        {
            // 入力チェック無し

            return true;
        }
        #endregion

        #region CreateUpdateKeiryoShomeiIrai()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateUpdateKeiryoShomeiIrai()
        /// <summary>
        /// 更新データの作成
        /// </summary>
        /// <param name="mode"></param>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/10  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable CreateUpdateKeiryoShomeiIrai()
        {
            KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable datatable = _keiryoShomeiIraiTblDT;

            // 受付区分
            if (uketsukeKbnShushuRadioButton.Checked)
            {
                datatable[0].KeiryoShomeiUketsukeKbn = "2";
            }
            else if (uketsukeKbnMotikomiRadioButton.Checked)
            {
                datatable[0].KeiryoShomeiUketsukeKbn = "1";
            }

            // 採水日
            datatable[0].KeiryoShomeiSaisuiDt = saisuiDtTextBox.Text;

            // 採水時刻
            datatable[0].KeiryoShomeiSaisuiTime = saisuiTimeTextBox.Text;

            // 水温
            datatable[0].KeiryoShomeiSuion = string.IsNullOrEmpty(suionTextBox.Text) ? 0 : double.Parse(suionTextBox.Text);

            // 気温
            datatable[0].KeiryoShomeiKion = string.IsNullOrEmpty(kionTextBox.Text) ? 0 : double.Parse(kionTextBox.Text);

            // 試験項目枝番
            datatable[0].KeiryoShomeiKensakomokuEdaban = kensaSetComboBox.SelectedValue.ToString();

            // 検査セットコード(コンボボックスのソースから検索なので必ず取得できる)
            datatable[0].KeiryoShomeiSetCd = _kensaSetPattern.Select(string.Format("DaichoKensaKomokuEdaban='{0}'", kensaSetComboBox.SelectedValue.ToString()))[0]["DaichoKensaKomokuSetCd"].ToString();

            // 検査料金
            datatable[0].KeiryoShomeiKensaRyokin = string.IsNullOrEmpty(kensaRyokinTextBox.Text) ? 0 : decimal.Parse(kensaRyokinTextBox.Text);

            // 消費税
            datatable[0].KeiryoShomeiShohizei = string.IsNullOrEmpty(shohizeiTextBox.Text) ? 0 : decimal.Parse(shohizeiTextBox.Text);

            // 採水員コード
            if (string.IsNullOrEmpty(saisuiinCdTextBox.Text))
            {
                datatable[0].KeiryoShomeiSaisuiinCd = string.Empty;
            }
            else
            {
                datatable[0].KeiryoShomeiSaisuiinCd = saisuiinCdTextBox.Text;
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


        #endregion
    }
    #endregion
}
