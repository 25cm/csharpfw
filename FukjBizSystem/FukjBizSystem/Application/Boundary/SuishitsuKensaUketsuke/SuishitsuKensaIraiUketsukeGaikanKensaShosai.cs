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
    //  クラス名 ： SuishitsuKensaIraiUketsukeGaikanKensaShosai
    /// <summary>
    /// 検査受付詳細（外観検査）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者    内容
    /// 2014/12/08  豊田      新規作成
    /// 2014/12/10  豊田      DBアクセスを行わないよう変更
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaIraiUketsukeGaikanKensaShosai : FukjBaseForm
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
        /// 初期表示取得データ(水質検査情報)
        /// </summary>
        private SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable _suishitsuIraiInfo
            = new SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable();

        /// <summary>
        /// 編集の有無
        /// </summary>
        private bool _isModified = false;

        #endregion

        #region プロパティ

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
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeGaikanKensaShosai
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [Obsolete("【豊田】 この呼び出しは削除します。DataTableを引き渡すコンストラクタを使用してください。")]
        public SuishitsuKensaIraiUketsukeGaikanKensaShosai()
            : base()
        {
            InitializeComponent();

            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeGaikanKensaShosai
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
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [Obsolete("【豊田】 この呼び出しは削除します。DataTableを引き渡すコンストラクタを使用してください。")]
        public SuishitsuKensaIraiUketsukeGaikanKensaShosai(string kensaIraiHoteiKbn, string kensaIraiHokenjoCd, string kensaIraiNendo, string kensaIraiRenban,
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
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeGaikanKensaShosai
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="kensaDaichoDtl">初期表示データ(検査台帳明細)</param>
        /// <param name="_suishitsuIraiInfo">初期表示データ(水質検査情報)</param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaIraiUketsukeGaikanKensaShosai(KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtl,
                                                            SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable suishitsuIraiInfo)
            : base()
        {
            InitializeComponent();

            SetControlDomain();

            _kensaDaichoDtl = kensaDaichoDtl;
            _suishitsuIraiInfo = suishitsuIraiInfo;
        }
        #endregion

        #region イベントハンドラ

        #region SuishitsuKensaIraiUketsukeGaikanKensaShosai_Load(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaDaichoForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/08  豊田      新規作成
        /// 2014/12/10  豊田      DBアクセスを行わないよう変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeGaikanKensaShosai_Load(object sender, EventArgs e)
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
        /// 2014/12/08  豊田      新規作成
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
        /// 2014/12/08  豊田      新規作成
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
        /// 2014/12/08  豊田      新規作成
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
        /// 2014/12/08  豊田      新規作成
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
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            _isModified = true;
        }
        #endregion

        #region SuishitsuKensaIraiUketsukeGaikanKensaShosai_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BushoMstShosaiForm_KeyDown
        /// <summary>
        /// キーダウン（ショートカット）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeGaikanKensaShosai_KeyDown(object sender, KeyEventArgs e)
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
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 依頼書番号
            kensaIraiSuishitsuIraiNoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 6);

            // 透視度
            kensaKekkaToshidoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 7);
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
        /// 2014/12/08  豊田      新規作成
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
        /// 2014/12/08  豊田      新規作成
        /// 2014/12/09  小松      日付文字列変換修正
        /// 2015/01/08  小松　　　受付日が空白の場合例外発生の対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlValue()
        {
            // 検査依頼保健所コード    表示
            kensaIraiHokenjoCdTextBox.Text = _suishitsuIraiInfo[0].KensaIraiHokenjoCd;

            // 検査依頼年度    表示
            kensaIraiNendoTextBox.Text = Common.Common.ConvertToHoshouNendoWareki(_suishitsuIraiInfo[0].KensaIraiNendo);

            // 検査依頼連番    表示
            kensaIraiRenbanTextBox.Text = _suishitsuIraiInfo[0].KensaIraiRenban;

            // 依頼書番号    表示
            kensaIraiSuishitsuIraiNoTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSuishitsuIraiNoNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSuishitsuIraiNo;

            // 受付日    表示
            // MOD START 20141209 日付文字列変換修正 komatsu
            //kensaIraiSuishitsuUketsukeDtTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSuishitsuUketsukeDtNull()
            //    ? string.Empty : DateTime.Parse(_suishitsuIraiInfo[0].KensaIraiSuishitsuUketsukeDt).ToString("yyyy年MM月dd日");
            //kensaIraiSuishitsuUketsukeDtTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSuishitsuUketsukeDtNull()
            //    ? string.Empty : DateTime.ParseExact(_suishitsuIraiInfo[0].KensaIraiSuishitsuUketsukeDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");
            // MOD  END  20141209 日付文字列変換修正 komatsu
            kensaIraiSuishitsuUketsukeDtTextBox.Text = (_suishitsuIraiInfo[0].IsKensaIraiSuishitsuUketsukeDtNull() || string.IsNullOrEmpty(_suishitsuIraiInfo[0].KensaIraiSuishitsuUketsukeDt))
                ? string.Empty : DateTime.ParseExact(_suishitsuIraiInfo[0].KensaIraiSuishitsuUketsukeDt, "yyyyMMdd", null).ToString("yyyy年MM月dd日");

            // 透視度    入力
            kensaKekkaToshidoTextBox.Text = _kensaDaichoDtl[0].IsKeiryoShomeiKekkaValueNull()
                ? "0" : _kensaDaichoDtl[0].KeiryoShomeiKekkaValue.ToString("#0.00");

            // 浄化槽台帳保健所コード    表示
            jokasoHokenjoCdTextBox.Text = _suishitsuIraiInfo[0].KensaIraiJokasoHokenjoCd;

            // 浄化槽台帳年度    表示
            jokasoTorokuNendoTextBox.Text = Common.Common.ConvertToHoshouNendoWareki(_suishitsuIraiInfo[0].KensaIraiJokasoTorokuNendo);

            // 浄化槽台帳連番    表示
            jokasoRenbanTextBox.Text = _suishitsuIraiInfo[0].KensaIraiJokasoRenban;

            // 設置者氏名    表示
            jokasoSetchishaNmTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaNm;

            // 電話番号    表示
            jokasoSetchishaTelNoTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaTelNoNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaTelNo;

            // カナ名    表示
            jokasoSetchishaKanaTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaKanaNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaKana;

            // 設置者住所    表示
            jokasoSetchishaAdrTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchishaAdrNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchishaAdr;

            // 設置場所    表示
            jokasoSetchiBashoAdrTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiSetchibashoAdrNull()
                ? string.Empty : _suishitsuIraiInfo[0].KensaIraiSetchibashoAdr;

            // メーカー    表示
            jokasoMekaGyoshaCdTextBox.Text = _suishitsuIraiInfo[0].IsMakerGyoshaNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].MakerGyoshaNm;

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

            // 型式名    表示
            katashikiNmTextBox.Text = _suishitsuIraiInfo[0].IsKatashikiNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].KatashikiNm;

            if (!_suishitsuIraiInfo[0].IsKensaIraiShorihoshikiKbnNull() && _suishitsuIraiInfo[0].KensaIraiShorihoshikiKbn == "1")
            {
                // 処理方式：合併    表示
                jokasoShoriHosikiGappeiKbnRadioButton.Checked = true;
                // 処理方式：単独    表示
                jokasoShoriHosikiTandokuKbnRadioButton.Checked = false;
            }
            else if (!_suishitsuIraiInfo[0].IsKensaIraiShorihoshikiKbnNull() && _suishitsuIraiInfo[0].KensaIraiShorihoshikiKbn == "2")
            {
                // 処理方式：合併    表示
                jokasoShoriHosikiGappeiKbnRadioButton.Checked = false;
                // 処理方式：単独    表示
                jokasoShoriHosikiTandokuKbnRadioButton.Checked = true;
            }
            else // デフォルト
            {
                // 処理方式：合併    表示
                jokasoShoriHosikiGappeiKbnRadioButton.Checked = true;
                // 処理方式：単独    表示
                jokasoShoriHosikiTandokuKbnRadioButton.Checked = false;
            }

            // 処理方式名    表示
            shoriHoshikiNmTextBox.Text = _suishitsuIraiInfo[0].IsShoriHoshikiNmNull()
                ? string.Empty : _suishitsuIraiInfo[0].ShoriHoshikiNm;

            // 人槽    表示
            jokasoShoriTaishoJininTextBox.Text = _suishitsuIraiInfo[0].IsKensaIraiShoritaishoJininNull()
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
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControl()
        {
            // 検査依頼保健所コード    表示
            kensaIraiHokenjoCdTextBox.CustomReadOnly = true;
            // 検査依頼年度    表示
            kensaIraiNendoTextBox.CustomReadOnly = true;
            // 検査依頼連番    表示
            kensaIraiRenbanTextBox.CustomReadOnly = true;
            // 依頼書番号    表示
            kensaIraiSuishitsuIraiNoTextBox.CustomReadOnly = true;
            // 受付日    表示
            kensaIraiSuishitsuUketsukeDtTextBox.CustomReadOnly = true;
            // 浄化槽台帳保健所コード    表示
            jokasoHokenjoCdTextBox.CustomReadOnly = true;
            // 浄化槽台帳年度    表示
            jokasoTorokuNendoTextBox.CustomReadOnly = true;
            // 浄化槽台帳連番    表示
            jokasoRenbanTextBox.CustomReadOnly = true;
            // 設置者氏名    表示
            jokasoSetchishaNmTextBox.CustomReadOnly = true;
            // 電話番号    表示
            jokasoSetchishaTelNoTextBox.CustomReadOnly = true;
            // カナ名    表示
            jokasoSetchishaKanaTextBox.CustomReadOnly = true;
            // 設置者住所    表示
            jokasoSetchishaAdrTextBox.CustomReadOnly = true;
            // 設置場所    表示
            jokasoSetchiBashoAdrTextBox.CustomReadOnly = true;
            // メーカー    表示
            jokasoMekaGyoshaCdTextBox.CustomReadOnly = true;
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
            // 型式名    表示
            katashikiNmTextBox.CustomReadOnly = true;
            // 処理方式：合併    表示
            jokasoShoriHosikiGappeiKbnRadioButton.Enabled = false;
            // 処理方式：単独    表示
            jokasoShoriHosikiTandokuKbnRadioButton.Enabled = false;
            // 処理方式名    表示
            shoriHoshikiNmTextBox.CustomReadOnly = true;
            // 人槽    表示
            jokasoShoriTaishoJininTextBox.CustomReadOnly = true;

            switch (_dispMode)
            {
                case DispMode.Detail:

                    // 透視度
                    kensaKekkaToshidoTextBox.CustomReadOnly = true;

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

                    // 透視度
                    kensaKekkaToshidoTextBox.CustomReadOnly = false;

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

                    // 透視度
                    kensaKekkaToshidoTextBox.CustomReadOnly = true;

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
        /// 2014/12/08  豊田      新規作成
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
        /// 2014/12/08  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable CreateUpdateKensaDaichoDtl()
        {
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable datatable = _kensaDaichoDtl;

            if (string.IsNullOrEmpty(kensaKekkaToshidoTextBox.Text))
            {
                datatable[0].KeiryoShomeiKekkaValue = 0;
            }
            else
            {
                datatable[0].KeiryoShomeiKekkaValue = decimal.Parse(kensaKekkaToshidoTextBox.Text);
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
