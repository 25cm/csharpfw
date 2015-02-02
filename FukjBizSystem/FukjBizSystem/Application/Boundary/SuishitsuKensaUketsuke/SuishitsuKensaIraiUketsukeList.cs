using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeKeiryoShomeiShosai;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Microsoft.VisualBasic.FileIO;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaIraiUketsukeList
    /// <summary>
    /// 水質受付管理_検査受付一覧
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01  小松        新規作成
    /// 2014/12/26  小松        外観検査対象のチェック追加
    ///                         また、重複ありや台帳無しの時の制御を追加
    /// 2014/12/29  小松        外観検査で外観対象外の時は確認メッセージ非表示
    /// 　　　　　　　　　　　　水質検査で処理対象人員が51以上の場合の確認メッセージ表示
    /// 2015/01/09  小松        水質検査時に外観検査対象が含まれる場合のチェックを再修正
    /// 　　　　　　　　　　　　また、収集・持込のラジオボタン制御修正
    /// 2015/01/09  小松        外観検査時に受付可能状態を判定（ステータス区分、検査状況）
    /// 2015/01/11  小松        計量証明時に検査セット、料金等が表示されない。また、検査セット名を表示
    /// 2015/01/14  小松        外観検査時に検査依頼、検査結果、浄化槽台帳が存在しない場合は受付しない
    /// 2015/01/31  宗          手入力機能追加
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaIraiUketsukeList : FukjBaseForm
    {
        #region 定数定義

        // HHTデータファイルの区切り文字
        private const string DEF_HHT_FILE_SEPARATOR = "\t";

        // HHTデータ用DataTable
        private SuishitsuKensaIraiDataSet.HhtImportDataTable _hhtDT = new SuishitsuKensaIraiDataSet.HhtImportDataTable();

        // 画面モード
        class GamenMode
        {
            // 初期
            public const string Init = "0";
            // 未編集（検索実行直後）
            public const string NoEdit = "1";
            // 登録（依頼取込直後）
            public const string Insert = "2";
            // 更新（検索実行後にセル値を変更）
            public const string Update = "3";
        }

        // 水質検査区分（画面上部の条件）
        class SuishitsuKensaKbn
        {
            // 計量証明
            public const string KeiryoShomei = "1";
            // 水質検査
            public const string SuishitsuKensa = "2";
            // 外観検査
            public const string GaikanKensa = "3";
        }

        // 取込区分
        class HhtImportKbn
        {
            // 取込区分（正常）
            public const string Success = "0";
            // 取込区分（重複）
            public const string KeyDuplicateErr = "1";
            // 取込区分（設置者コードに該当する浄化槽台帳なし）
            public const string NotFoundJokasoDaicho = "2";
            // 取込区分（仮番）
            public const string KaribanErr = "3";
            // 取込区分（重複行有）
            public const string ListDuplicateErr = "4";
            // 取込区分（廃止）
            public const string HaishiWar = "5";
            // 取込区分（ステータス区分エラー）
            public const string StatusErr = "6";
            // 取込区分（検査依頼なし）
            public const string NotFoundKensaIrai = "7";
        }

        // 外観検査対象名称区分
        class GaikanKensaTaishoNmKbn
        {
            // 対象
            public const string Taisho = "対象";
            // 非対称
            public const string Hitaisho = "非対象";
        }

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// フォームロード
        /// </summary>
        private bool _formLoad = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SuishitsuKensaIraiUketsukeList
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaIraiUketsukeList()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SuishitsuKensaIraiUketsukeList_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaIraiUketsukeList_Load
        /// <summary>
        /// フォーム画面ロードイベント
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeList_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 画面モード
                gamenMode.Text = GamenMode.Init;
                // 水質検査区分
                suishitsuKensaKbn.Text = SuishitsuKensaKbn.SuishitsuKensa;

                // ヘッダのVisualスタイルを無効化
                kensaUketsukeListDataGridView.EnableHeadersVisualStyles = false;
                // ヘッダの背景色を設定
                kensaUketsukeListDataGridView.Columns[motikomiFlgCol.Index].HeaderCell.Style.BackColor = Color.Yellow;
                kensaUketsukeListDataGridView.Columns[shushuFlgCol.Index].HeaderCell.Style.BackColor = Color.Yellow;

                // 画面ロード時の必要情報取得
                doLoadForm();

                // 画面情報設定
                clearForm();

                // 各コントロールのドメイン設定
                setControlDomain();

                // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                setControlProperty();

                // 一覧のカラムの制御
                setListColmunVisible();

                // フォームロード済
                _formLoad = true;
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

        #region ViewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 表示切替ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (jokenPanel.Height == 30)
                {
                    jokenPanel.Height = 124;
                    listPanel.Top = 124;
                    listPanel.Height = 427;
                    ViewChangeButton.Text = "▲";
                }
                else
                {
                    jokenPanel.Height = 30;
                    listPanel.Top = 30;
                    listPanel.Height = 520;
                    ViewChangeButton.Text = "▼";
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

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 検索ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松 　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 関連チェック
                if (!IsValidData())
                {
                    return;
                }

                // 選択中の水質検査区分から各内部変数を設定
                setSuishitsuKensaKbn();

                DoSearch();
                if (kensaUketsukeListDataGridView.Rows.Count == 0)
                {
                    // 初期モード
                    gamenMode.Text = GamenMode.Init;
                }
                else
                {
                    // 未編集モード
                    gamenMode.Text = GamenMode.NoEdit;
                    // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                    setControlProperty();
                    // 一覧のカラムの制御
                    setListColmunVisible();
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

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// クリアボタン押下イベント
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 画面モード
                gamenMode.Text = GamenMode.Init;

                // 画面情報設定
                clearForm();
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

        #region torikomiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torikomiButton_Click
        /// <summary>
        /// 依頼取込ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/29  小松        新規作成
        /// 2014/12/25  小松　　　　HHTファイルの取込先をサーバの共有からローカルのフォルダに変更
        /// 2015/01/30  宗          関連チェックを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torikomiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 関連チェック
                if (!IsValidData())
                {
                    return;
                }

                // 選択中の水質検査区分から各内部変数を設定
                setSuishitsuKensaKbn();

                // 取込確認
                if (MessageForm.Show2(MessageForm.DispModeType.Question,
                    string.Format("{0}用の HHTデータファイルを取り込みます。よろしいですか？", suishitsuKensaKbnLabel.Text))
                    != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                #region HHTデータファイル取得
                // 取込ローカルファイル名
                string localFilePath = string.Empty;
                // ローカルの HHTデータファイル名（フルパス）を取得
                if (!getHhtDataFile(suishitsuKensaKbn.Text, out localFilePath))
                {
                    // エラー
                    return;
                }
                #endregion

                #region HHTデータ用DataTable作成
                SuishitsuKensaIraiDataSet.HhtImportDataTable hhtDT = new SuishitsuKensaIraiDataSet.HhtImportDataTable();
                #endregion

                #region HHTデータファイルの読み込み
                // HHTデータファイルを読み込んで、HHTデータ用DataTableに取得
                if (!importHhtData(suishitsuKensaKbn.Text, localFilePath, hhtDT))
                {
                    // エラー
                    return;
                }
                #endregion

                // 20150131 sou Start
                _hhtDT = hhtDT;
                // 20150131 sou End

                #region 取得したデータを一覧に表示
                // 取得したデータを一覧に表示
                if (!setDataGridViewFromImportHhtData(suishitsuKensaKbn.Text, hhtDT))
                {
                    // エラー
                    return;
                }
                #endregion

                if (kensaUketsukeListDataGridView.Rows.Count == 0)
                {
                    // 初期モード
                    gamenMode.Text = GamenMode.Init;
                    // 件数表示
                    uketsukeListCountLabel.Text = "0件";
                }
                else
                {
                    // 登録モード
                    gamenMode.Text = GamenMode.Insert;
                    // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                    setControlProperty();
                    // 一覧のカラムの制御
                    setListColmunVisible();
                    // 左上のセルに
                    kensaUketsukeListDataGridView.CurrentCell = kensaUketsukeListDataGridView[0, 0];
                    //kensaUketsukeListDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    //kensaUketsukeListDataGridView.FirstDisplayedScrollingColumnIndex = 0;
                    // 件数表示
                    //uketsukeListCountLabel.Text = string.Empty;
                    uketsukeListCountLabel.Text = kensaUketsukeListDataGridView.Rows.Count.ToString() + "件";
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

        #region shosaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shosaiButton_Click
        /// <summary>
        /// 詳細ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 選択行数取得
                if (kensaUketsukeListDataGridView.CurrentRow.Index < 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                // 取込でエラーになっている場合は処理を抜ける
                if (readOnlyHantei(kensaUketsukeListDataGridView.CurrentRow.Cells[ImportKbnCol.Index].Value.ToString()))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "取込でエラーになっている場合は詳細画面を開けません。");
                    return;
                }

                // 詳細
                nextForm();
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

        #region batchInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： batchInputButton_Click
        /// <summary>
        /// 一括入力ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void batchInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 表示行数取得
                if (kensaUketsukeListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                    return;
                }

                // 一括入力
                BatchInputForm dlg = new BatchInputForm(suishitsuKensaKbn.Text);
                dlg.ShowDialog();

                // キャンセルされた
                if (dlg.DialogResult != DialogResult.OK)
                {
                    return;
                }

                // 取込結果一覧DataTable
                SuishitsuKensaIraiDataSet.UketsukeImportListDataTable listDT = (SuishitsuKensaIraiDataSet.UketsukeImportListDataTable)kensaUketsukeListDataGridView.DataSource;
                foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow listRow in listDT)
                {
                    if (!listRow.KoshinFlg)
                    {
                        continue;
                    }

                    // 更新対象のみセット
                    bool mochikomiFlg = true;
                    bool shushuFlg = false;
                    if (dlg.MochikomiFlg)
                    {
                        // 持込
                        mochikomiFlg = true;
                        shushuFlg = false;
                    }
                    else
                    {
                        // 収集
                        mochikomiFlg = false;
                        shushuFlg = true;
                    }
                    listRow.MotikomiFlg = mochikomiFlg;
                    listRow.ShushuFlg = shushuFlg;

                    if (!string.IsNullOrEmpty(dlg.SaisuiinCd) && !string.IsNullOrEmpty(dlg.SaisuiinNm))
                    {
                        // 採水員
                        listRow.SaisuiinCd = dlg.SaisuiinCd;
                        listRow.SaisuiinNm = dlg.SaisuiinNm;
                    }

                    if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.SuishitsuKensa)
                    {
                        if (!string.IsNullOrEmpty(dlg.ZanryuEnso))
                        {
                            // 水質時は残留塩素セット
                            decimal enso = 0;
                            if (Decimal.TryParse(dlg.ZanryuEnso, out enso))
                            {
                                // 残留塩素濃度
                                listRow.ZanryuEnso = enso;
                            }
                        }
                    }
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

        #region genkinNyuryokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： genkinNyuryokuButton_Click
        /// <summary>
        /// 現金入力ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void genkinNyuryokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 選択行数取得
                if (kensaUketsukeListDataGridView.CurrentRow.Index < 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }
                // カレント行
                int rowIndex = kensaUketsukeListDataGridView.CurrentRow.Index;

                if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.KeiryoShomei)
                {
                    // 計量証明

                    // 計量証明依頼年度
                    string keiryoShomeiNendo = kensaUketsukeListDataGridView[keiryoShomeiIraiNendoCol.Index, rowIndex].Value.ToString();
                    // 計量証明依頼支所
                    string keiryoShomeiSisho = kensaUketsukeListDataGridView[keiryoShomeiIraiSishoCdCol.Index, rowIndex].Value.ToString();
                    // 計量証明依頼連番
                    string keiryoShomeiRenban = kensaUketsukeListDataGridView[keiryoShomeiIraiRenbanCol.Index, rowIndex].Value.ToString();
                    // 現金入力
                    GenkinNyukinForm frm = new GenkinNyukinForm("2", keiryoShomeiNendo, keiryoShomeiSisho, keiryoShomeiRenban);

                    // 2015.01.12 toyoda Modify Start 現金入金後に画面の再描画を行う
                    //Program.mForm.MoveNext(frm);
                    Program.mForm.MoveNext(frm, GenkinNyukinFormEnd);
                    // 2015.01.12 toyoda Modify End
                }
                else
                {
                    // 法定検査

                    // 検査依頼法定区分
                    string kensaIraiHoteiKbn = kensaUketsukeListDataGridView[kensaIraiHoteiKbnCol.Index, rowIndex].Value.ToString();
                    // 検査依頼法定保健所コード
                    string kensaIraiHokenjoCd = kensaUketsukeListDataGridView[kensaIraiHokenjoCdCol.Index, rowIndex].Value.ToString();
                    // 検査依頼法定年度
                    string kensaIraiNendo = kensaUketsukeListDataGridView[kensaIraiNendoCol.Index, rowIndex].Value.ToString();
                    // 検査依頼法定連番
                    string kensaIraiRenban = kensaUketsukeListDataGridView[kensaIraiRenbanCol.Index, rowIndex].Value.ToString();
                    // 現金入力
                    GenkinNyukinForm frm = new GenkinNyukinForm("1", kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban);

                    // 2015.01.12 toyoda Modify Start 現金入金後に画面の再描画を行う
                    //Program.mForm.MoveNext(frm);
                    Program.mForm.MoveNext(frm, GenkinNyukinFormEnd);
                    // 2015.01.12 toyoda Modify End
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

        #region kakuteiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 確定ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  小松        新規作成
        /// 2015/01/05  小松　　　　マスタに登録されていない水質検査セットコードが使用されている場合は受付時点で弾く（計量証明検査のみ）
        /// 2015/01/21  小松　　　　外観検査時の11条水質＋スクリーニングは、処理方式別水質検査実施マスタのチェックは行わない。（固定で検査項目分を登録するため）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 更新チェック
                bool Entry = false;
                bool SuishitsuKensaGaikanAriFlg = false;
                //bool GaikanKensaGaikanNashiFlg = false;
                SuishitsuKensaIraiDataSet.UketsukeImportListDataTable listDT = (SuishitsuKensaIraiDataSet.UketsukeImportListDataTable)kensaUketsukeListDataGridView.DataSource;
                foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow listRow in listDT)
                {
                    if (!listRow.KoshinFlg)
                    {
                        continue;
                    }

                    // 浄化槽台帳が指定されているかチェック
                    if (string.IsNullOrEmpty(listRow.JokasoDaichoHokenjoCd) || string.IsNullOrEmpty(listRow.JokasoDaichoNendo) || string.IsNullOrEmpty(listRow.JokasoDaichoRenban))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("浄化槽台帳が指定されていない依頼があります。検体番号:[{0}]", listRow.KentaiNo));
                        return;
                    }

                    Entry = true;

                    // 外観検査チェック
                    if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.SuishitsuKensa)
                    {
                        if (listRow.GaikanKensaTaisho == GaikanKensaTaishoNmKbn.Taisho)
                        {
                            // 検査区分が「水質検査」で、外観検査対象が含まれている場合
                            SuishitsuKensaGaikanAriFlg = true;
                            //break;
                        }
                    }
                    //else if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.GaikanKensa)
                    //{
                    //    if (listRow.GaikanKensaTaisho == GaikanKensaTaishoNmKbn.Hitaisho)
                    //    {
                    //        // 検査区分が「外観検査」 かつ 当年度が外観検査対象の地区では無い地区が含まれている場合
                    //        // 「外観検査の対象ではない地区が含まれています」
                    //        GaikanKensaGaikanNashiFlg = true;
                    //        break;
                    //    }
                    //}

                    // 水質検査セットマスタが正しく設定されていない場合（料金が算出出来ない）
                    if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.KeiryoShomei)
                    {
                        // 検査料金
                        decimal kensaRyokin = 0;
                        // 消費税
                        decimal shohizei = 0;
                        bool result = FukjBizSystem.Application.Utility.KeiryoShomeiUtility.KeiryoshomeiKensaRyokinShukei(
                            uketsukeDataTimePicker.Value.ToString("yyyyMMdd"), listRow.JokasoDaichoHokenjoCd, listRow.JokasoDaichoNendo, listRow.JokasoDaichoRenban, listRow.Edaban, out kensaRyokin, out shohizei);
                        if (!result)
                        {
                            // 対象の水質検査セットマスタが存在しない。（料金が算出できない）
                            MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("水質検査セットマスタが正しく指定されていない依頼があります。\n検体番号:[{0}]　協会番号[{1}]", listRow.KentaiNo, listRow.KyokaiNo));
                            return;
                        }
                    }

                    // 計量証明で、計量証明に関連付いている浄化槽台帳水質検査項目マスタが正しく設定されているか確認
                    if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.KeiryoShomei)
                    {
                        bool result = KakuteiBtnClickApplicationLogic.CheckKeiryoShomeiMaster(listRow.JokasoDaichoHokenjoCd, listRow.JokasoDaichoNendo, listRow.JokasoDaichoRenban, listRow.Edaban);
                        if (!result)
                        {
                            // 対象の浄化槽台帳水質検査項目マスタが存在しない。（検査台帳明細が登録できない）
                            MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("浄化槽台帳水質検査項目マスタが正しく設定されていない依頼があります。\n検体番号:[{0}]　協会番号[{1}]", listRow.KentaiNo, listRow.KyokaiNo));
                            return;
                        }
                    }

                    // 外観検査で、検査依頼に関連付いている処理方式別水質検査実施マスタが正しく設定されているか確認（７条と11条外観のみ。11条水質のスクリーニングは対象外）
                    //if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.GaikanKensa)
                    if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.GaikanKensa && !Utility.Utility.IsSaiSaisuiTarget(listRow.KensaIraiHoteiKbn, listRow.ScreeningKbn))
                    {
                        bool result = KakuteiBtnClickApplicationLogic.CheckSuishitsuMaster(listRow.KensaIraiHoteiKbn, listRow.KensaIraiHokenjoCd, listRow.KensaIraiNendo, listRow.KensaIraiRenban);
                        if (!result)
                        {
                            // 対象の水質検査セットマスタが存在しない。（料金が算出できない）
                            MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("処理方式別水質検査実施マスタが正しく設定されていない依頼があります。\n検体番号:[{0}]　検査依頼番号[{1}]", listRow.KentaiNo, listRow.KensaIraiNo));
                            return;
                        }
                    }
                }
                if (!Entry)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "登録対象の情報が存在しません。");
                    return;
                }

                // 日報の確認状況を確認
                // データ検索⑬
                if (GetSuishitsuNippoCheckCnt() > 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "既に確認済みの水質日報があります。");
                    return;
                }

                // 検査区分が「水質検査」で、外観検査対象が含まれている場合
                if (SuishitsuKensaGaikanAriFlg)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "外観検査対象が含まれていますがよろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }
                //// 検査区分が「外観検査」 かつ 当年度が外観検査対象の地区では無い地区が含まれている場合
                //if (GaikanKensaGaikanNashiFlg)
                //{
                //    if (MessageForm.Show2(MessageForm.DispModeType.Question, "外観検査の対象ではない地区が含まれていますがよろしいですか？") == DialogResult.No)
                //    {
                //        return;
                //    }
                //}

                string message = string.Empty;
                // 登録モードの場合（依頼取込後）
                if (gamenMode.Text == GamenMode.Insert)
                {
                    message = "取り込んだ内容を登録します。よろしいですか？";
                }
                // 更新モードの場合（検索実行後）
                else if (gamenMode.Text == GamenMode.Update)
                {
                    message = "編集した検査情報を更新します。よろしいですか？";
                }
                if (MessageForm.Show2(MessageForm.DispModeType.Question, message) == DialogResult.No)
                {
                    return;
                }

                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                // 水質検査区分(1:計量証明/2:水質/3:外観)
                alInput.SuishitsuKensaKbn = suishitsuKensaKbn.Text;
                // 画面モード(2:登録(INSERT)/3:更新(UPDATE))
                alInput.GamenMode = gamenMode.Text;
                // 依頼年度
                alInput.IraiNendo = iraiNendoTextBox.Text.Trim();
                // 支所コード
                alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();
                // 受付日
                alInput.KensaIraiUketsukeDt = uketsukeDataTimePicker.Value.ToString("yyyyMMdd");
                // 取込結果一覧DataTable
                alInput.UketsukeImportListDT = listDT;
                // 登録
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                // 登録モードの場合（依頼取込後）
                if (gamenMode.Text == GamenMode.Insert)
                {
                    message = "取り込みが完了しました。";
                }
                // 更新モードの場合（検索実行後）
                else if (gamenMode.Text == GamenMode.Update)
                {
                    message = "更新が完了しました。";
                }
                MessageForm.Show2(MessageForm.DispModeType.Infomation, message);

                // 初期モード
                gamenMode.Text = GamenMode.Init;
                // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                setControlProperty();
                // 一覧のカラムの制御
                setListColmunVisible();
                // 画面情報設定
                clearForm();
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

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// 一覧出力ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 表示行数取得
                if (kensaUketsukeListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "出力データはありません。");
                    return;
                }

                // 一覧の内容を Excelファイルへ出力
                // 共通関数内で保存先ダイアログが表示される
                string outputFilename = "水質検査受付一覧";
                if (Common.Common.FlushGridviewDataToExcel(kensaUketsukeListDataGridView, outputFilename))
                {
                    // 出力完了
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力が完了しました。");
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

        #region torikeshiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torikeshiButton_Click
        /// <summary>
        /// 取消ボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torikeshiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string message = string.Empty;
                // 登録モードの場合（依頼取込後）
                if (gamenMode.Text == GamenMode.Insert)
                {
                    message = "取り込んだ内容が破棄されます。よろしいですか？";
                }
                // 更新モードの場合（検索実行後）
                else if (gamenMode.Text == GamenMode.Update)
                {
                    message = "編集した内容が破棄されます。よろしいですか？";
                }
                if (!string.IsNullOrEmpty(message))
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, message) == DialogResult.No)
                    {
                        return;
                    }
                }

                // 初期モード
                gamenMode.Text = GamenMode.Init;
                // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                setControlProperty();
                // 一覧のカラムの制御
                setListColmunVisible();
                // 画面情報設定
                clearForm();
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

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松 　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string message = string.Empty;
                // 登録モードの場合（依頼取込後）
                if (gamenMode.Text == GamenMode.Insert)
                {
                    message = "取り込んだ内容が破棄されます。よろしいですか？";
                }
                // 更新モードの場合（検索実行後）
                else if (gamenMode.Text == GamenMode.Update)
                {
                    message = "編集した内容が破棄されます。よろしいですか？";
                }
                if (!string.IsNullOrEmpty(message))
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, message) == DialogResult.No)
                    {
                        return;
                    }
                }

                // メニューに戻る
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

        //#region SetReadonlyGridView
        //private void SetReadonlyGridView()
        //{
        //    for (int i = 0; i < kensaUketsukeListDataGridView.RowCount - 1; i++)
        //    {
        //        foreach (DataGridViewColumn col in kensaUketsukeListDataGridView.Columns)
        //        {
        //            DataGridViewCell cell = kensaUketsukeListDataGridView.Rows[i].Cells[col.Name];
        //            if (col.Name == ShishoCol.Name || col.Name == YoshiCol.Name)
        //            {
        //                cell.ReadOnly = true;
        //            }

        //            if (col.Name == SuryoOldCol.Name)
        //            {
        //                cell.Value = kensaUketsukeListDataGridView.Rows[i].Cells[SuryoCdCol.Name].Value;
        //            }
        //        }
        //    }
        //}
        //#endregion

        #region kensaUketsukeListDataGridView_CellDoubleClick
        // リスト行をダブルクリック
        private void kensaUketsukeListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            try
            {
                // 詳細ボタン押下処理
                shosaiButton.PerformClick();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kensaUketsukeListDataGridView_CellValueChanged
        // セル値変更
        private void kensaUketsukeListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // フォームロード未
                if (!_formLoad)
                {
                    return;
                }

                // 未編集モードの場合
                if (gamenMode.Text == GamenMode.NoEdit)
                {
                    // 更新モード
                    gamenMode.Text = GamenMode.Update;
                    // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                    setControlProperty();
                    // 一覧のカラムの制御
                    setListColmunVisible();
                }
                // 更新フラグ列以外が変更
                if (e.ColumnIndex != KoshinFlgCol.Index)
                {
                    if (kensaUketsukeListDataGridView[KoshinFlgCol.Index, e.RowIndex].ReadOnly == false)
                    {
                        // 更新フラグOK
                        kensaUketsukeListDataGridView[KoshinFlgCol.Index, e.RowIndex].Value = true;
                    }
                }

                Debug.WriteLine(string.Format("CellValueChanged() 列：[{0}] 行[{1}]", e.ColumnIndex, e.RowIndex));
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
            }
        }
        #endregion

        #region kensaUketsukeListDataGridView_CurrentCellDirtyStateChanged
        private void kensaUketsukeListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (kensaUketsukeListDataGridView.IsCurrentCellDirty)
            {
                // コミットする
                kensaUketsukeListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion

        #region kensaUketsukeListDataGridView_CellContentClick
        // リスト内のボタンクリック
        private void kensaUketsukeListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150128 sou Start ヘッダ選択時は処理を抜ける
                if (e.RowIndex < 0) { return; }
                // 20150128 sou End

                DataGridView dgv = (DataGridView)sender;
                // 採水員列ボタンがクリックされた
                if (e.ColumnIndex == saisuiinSearchCol.Index)
                {
                    // 取込でエラーになっている場合は処理を抜ける
                    if (readOnlyHantei(kensaUketsukeListDataGridView.CurrentRow.Cells[ImportKbnCol.Index].Value.ToString()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "取込でエラーになっている場合は採水員を変更できません。");
                        return;
                    }

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
                    kensaUketsukeListDataGridView.CurrentRow.Cells[saisuiinCdCol.Name].Value = dlg._selectedRow.SaisuiinCd;
                    // 採水員名称
                    kensaUketsukeListDataGridView.CurrentRow.Cells[saisuiinNmCol.Name].Value = dlg._selectedRow.SaisuiinNm;
                }
                // 浄化槽列ボタンがクリックされた
                else if (e.ColumnIndex == jokasoDaichoSearchCol.Index)
                {
                    // 取込でエラーになっている場合は処理を抜ける
                    if (readOnlyHantei(kensaUketsukeListDataGridView.CurrentRow.Cells[ImportKbnCol.Index].Value.ToString()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "取込でエラーになっている場合は浄化槽を変更できません。");
                        return;
                    }

                    // 浄化槽台帳検索画面を表示して選択
                    JokasoDaichoSearchForm dlg = new JokasoDaichoSearchForm();
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

                    // 浄化槽台帳保健所CD
                    kensaUketsukeListDataGridView.CurrentRow.Cells[jokasoDaichoHokenjoCdCol.Name].Value = dlg._selectedRow.JokasoHokenjoCd;
                    // 浄化槽台帳年月
                    kensaUketsukeListDataGridView.CurrentRow.Cells[jokasoDaichoNendoCol.Name].Value = dlg._selectedRow.JokasoTorokuNendo;
                    // 浄化槽台帳連番
                    kensaUketsukeListDataGridView.CurrentRow.Cells[jokasoDaichoRenbanCol.Name].Value = dlg._selectedRow.JokasoRenban;
                    // 協会番号
                    kensaUketsukeListDataGridView.CurrentRow.Cells[kyokaiNoCol.Name].Value =
                        dlg._selectedRow.JokasoHokenjoCd
                        + "-"
                        // 年度和暦変換(平成起算)
                        + Common.Common.ConvertToHoshouNendoWareki(dlg._selectedRow.JokasoTorokuNendo)
                        + "-"
                        + dlg._selectedRow.JokasoRenban;

                    if (!dlg._selectedRow.IsJokasoJotaiKbnNull() && dlg._selectedRow.JokasoJotaiKbn == "2")
                    {
                        // 廃止の場合はワーニング
                        // 取込区分（廃止）
                        kensaUketsukeListDataGridView.CurrentRow.Cells[ImportKbnCol.Index].Value = HhtImportKbn.HaishiWar;
                        // 取込メッセージ（廃止）
                        kensaUketsukeListDataGridView.CurrentRow.Cells[ImportMessageCol.Index].Value =
                            string.Format("浄化槽台帳マスタの浄化槽状態が廃止(2)の浄化槽です。浄化槽台帳番号:[{0}]",
                                kensaUketsukeListDataGridView.CurrentRow.Cells[kyokaiNoCol.Name].Value);
                    }
                    else
                    {
                        // 取込区分（正常）
                        kensaUketsukeListDataGridView.CurrentRow.Cells[ImportKbnCol.Index].Value = HhtImportKbn.Success;
                        // 取込メッセージ（正常）
                        kensaUketsukeListDataGridView.CurrentRow.Cells[ImportMessageCol.Index].Value = string.Empty;
                    }
                    // 設置者名
                    kensaUketsukeListDataGridView.CurrentRow.Cells[settishaNmCol.Name].Value = dlg._selectedRow.JokasoSetchishaNm;

                    // 一覧の表示設定
                    settingChengeKensaUketsukeList();
                }
                else if (e.ColumnIndex == motikomiFlgCol.Index
                    && (bool)kensaUketsukeListDataGridView[e.ColumnIndex, e.RowIndex].Value)
                {
                    //｛持込｝にチェックが付けられた場合｛収集｝のチェックを外す
                    kensaUketsukeListDataGridView[shushuFlgCol.Index, e.RowIndex].Value = false;
                    kensaUketsukeListDataGridView[shushuFlgCol.Index, e.RowIndex].ReadOnly = false;
                    //｛収集｝はチェックが押せないように（チェックONが両方消えてしまうので）
                    kensaUketsukeListDataGridView[motikomiFlgCol.Index, e.RowIndex].ReadOnly = true;
                }
                else if (e.ColumnIndex == shushuFlgCol.Index
                    && (bool)kensaUketsukeListDataGridView[e.ColumnIndex, e.RowIndex].Value)
                {
                    //｛収集｝にチェックが付けられた場合｛持込｝のチェックを外す
                    kensaUketsukeListDataGridView[motikomiFlgCol.Index, e.RowIndex].Value = false;
                    kensaUketsukeListDataGridView[motikomiFlgCol.Index, e.RowIndex].ReadOnly = false;
                    //｛持込｝はチェックが押せないように（チェックONが両方消えてしまうので）
                    kensaUketsukeListDataGridView[shushuFlgCol.Index, e.RowIndex].ReadOnly = true;
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

        #region SuishitsuKensaIraiUketsukeList_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaIraiUketsukeList_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  小松    　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaIraiUketsukeList_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    // F7:クリアボタンのClickイベントと同様
                    // F8:検索ボタンのClickイベントと同様
                    // F1:依頼取込ボタンのClickイベントと同様
                    // F2:詳細ボタンのClickイベントと同様
                    // F3:一括入力ボタンのClickイベントと同様
                    // F4:現金入力ボタンのClickイベントと同様
                    // F5:確定ボタンのClickイベントと同様
                    // F6:一覧出力ボタンのClickイベントと同様
                    // F9:取消力ボタンのClickイベントと同様
                    // F12:閉じるボタンのClickイベントと同様

                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F1:
                        torikomiButton.Focus();
                        torikomiButton.PerformClick();
                        break;

                    case Keys.F2:
                        shosaiButton.Focus();
                        shosaiButton.PerformClick();
                        break;

                    case Keys.F3:
                        ikkatsuNyuryokuButton.Focus();
                        ikkatsuNyuryokuButton.PerformClick();
                        break;

                    case Keys.F4:
                        genkinNyuryokuButton.Focus();
                        genkinNyuryokuButton.PerformClick();
                        break;

                    case Keys.F5:
                        kakuteiButton.Focus();
                        kakuteiButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;

                    case Keys.F9:
                        torikeshiButton.Focus();
                        torikeshiButton.PerformClick();
                        break;

                    case Keys.F12:
                        tojiruButton.Focus();
                        tojiruButton.PerformClick();
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

        #region kensaKbnRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaKbnRadioButton_CheckedChanged
        /// <summary>
        /// 水質検査区分のラジオボタン選択
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09  小松    　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaKbnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // 一覧のカラムの制御
            setListColmunVisible();
        }
        #endregion

        #region iraiNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(iraiNoFromTextBox.Text))
                {
                    return;
                }
                iraiNoFromTextBox.Text = iraiNoFromTextBox.Text.PadLeft(iraiNoFromTextBox.MaxLength, '0');
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

        #region iraiNoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(iraiNoToTextBox.Text))
                {
                    return;
                }
                iraiNoToTextBox.Text = iraiNoToTextBox.Text.PadLeft(iraiNoToTextBox.MaxLength, '0');
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

        #region メソッド

        #region DoSearch
        private void DoSearch()
        {
            // 既存データクリア
            kensaUketsukeListDataGridView.DataSource = null;
            kensaUketsukeListDataGridView.Rows.Clear();

            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            // 水質検査区分(1:計量証明/2:水質/3:外観)
            alInput.SuishitsuKensaKbn = suishitsuKensaKbn.Text;
            // 依頼年度
            alInput.IraiNendo = iraiNendoTextBox.Text.Trim();
            // 支所コード
            alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();
            // 受付日
            alInput.KensaIraiUketsukeDt = uketsukeDataTimePicker.Value.ToString("yyyyMMdd");
            // 検体番号（開始）(6桁ゼロパディング)
            if (string.IsNullOrEmpty(iraiNoFromTextBox.Text.Trim()))
            {
                alInput.KentaiFromNo = string.Empty;
            }
            else
            {
                iraiNoFromTextBox.Text = iraiNoFromTextBox.Text.Trim().PadLeft(6, '0');
                alInput.KentaiFromNo = iraiNoFromTextBox.Text;
            }
            // 検体番号（終了）(6桁ゼロパディング)
            if (string.IsNullOrEmpty(iraiNoToTextBox.Text.Trim()))
            {
                alInput.KentaiToNo = string.Empty;
            }
            else
            {
                iraiNoToTextBox.Text = iraiNoToTextBox.Text.Trim().PadLeft(6, '0');
                alInput.KentaiToNo = iraiNoToTextBox.Text;
            }
            // 残留塩素の試験項目コード
            alInput.ZanryuEnsoCd = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);
            // 透視度の試験項目コード
            alInput.ToshidoCd = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
            // 検索実行
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // 列が自動的に作成されないようにする
            kensaUketsukeListDataGridView.AutoGenerateColumns = false;

            // DataTableクリア
            SuishitsuKensaIraiDataSet.UketsukeImportListDataTable impDT = new SuishitsuKensaIraiDataSet.UketsukeImportListDataTable();
            impDT.Clear();

            if (alInput.SuishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei)
            {
                if (alOutput.KensaDaicho9joInfoDT.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                    return;
                }

                foreach (SuishitsuKensaUketsukeDataSet.KensaDaicho9joInfoRow infoRow in alOutput.KensaDaicho9joInfoDT)
                {
                    SuishitsuKensaIraiDataSet.UketsukeImportListRow impRow = impDT.NewUketsukeImportListRow();

                    // 更新フラグ
                    impRow.KoshinFlg = false;
                    // 登録済フラグ
                    impRow.TorokusumiFlg = "1";
                    // スクリーニング区分
                    impRow.ScreeningKbn = "0";
                    // 検査依頼法定区分
                    impRow.KensaIraiHoteiKbn = string.Empty;
                    // 検査依頼保健所CD
                    impRow.KensaIraiHokenjoCd = string.Empty;
                    // 検査依頼年度
                    impRow.KensaIraiNendo = string.Empty;
                    // 検査依頼連番
                    impRow.KensaIraiRenban = string.Empty;
                    // 検査依頼番号
                    impRow.KensaIraiNo = string.Empty;
                    // 再採水区分
                    impRow.SaisaisuiKbn = "0";
                    // 再採水
                    impRow.SaisaisuiMark = "";
                    // 計量証明検査依頼年度
                    impRow.KeiryoShomeiIraiNendo = infoRow.KeiryoShomeiIraiNendo;
                    // 計量証明支所CD
                    impRow.KeiryoShomeiIraiSishoCd = infoRow.KeiryoShomeiIraiSishoCd;
                    // 計量証明依頼連番
                    impRow.KeiryoShomeiIraiRenban = infoRow.KeiryoShomeiIraiRenban;
                    // 計量証明依頼番号
                    impRow.KeiryoShomeiIraiNo = infoRow.KeiryoShomeiIraiNo;
                    // 検体番号
                    impRow.KentaiNo = infoRow.SuishitsuKensaIraiNo;
                    // 持込
                    impRow.MotikomiFlg = false;
                    // 収集
                    impRow.ShushuFlg = false;
                    if (infoRow.KeiryoShomeiUketsukeKbn == "1")
                    {
                        // 1=持込
                        impRow.MotikomiFlg = true;
                        impRow.ShushuFlg = false;
                    }
                    else if (infoRow.KeiryoShomeiUketsukeKbn == "2")
                    {
                        // 2=収集        
                        impRow.MotikomiFlg = false;
                        impRow.ShushuFlg = true;
                    }
                    // 現金
                    impRow.GenkinFlg = false;
                    if (infoRow.KeiryoShomeiGenkinShunyuFlg == "1")
                    {
                        // 1=現金
                        impRow.GenkinFlg = true;
                    }
                    // 採水員CD
                    impRow.SaisuiinCd = infoRow.KeiryoShomeiSaisuiinCd;
                    // 採水員名称
                    impRow.SaisuiinNm = infoRow.SaisuiinNm;
                    // 浄化槽台帳保健所CD
                    impRow.JokasoDaichoHokenjoCd = infoRow.JokasoHokenjoCd;
                    // 浄化槽台帳年度
                    impRow.JokasoDaichoNendo = infoRow.JokasoTorokuNendo;
                    // 浄化槽台帳連番
                    impRow.JokasoDaichoRenban = infoRow.JokasoRenban;
                    // 協会番号
                    impRow.KyokaiNo = infoRow.KyokaiNo;
                    // 残塩
                    impRow.ZanryuEnso = 0;
                    // 設置者名
                    impRow.SettishaNm = infoRow.JokasoSetchishaNm;
                    // 枝番
                    impRow.Edaban = infoRow.KeiryoShomeiKensakomokuEdaban;
                    // 検査員CD
                    impRow.KensainCd = string.Empty;
                    // 検査員名称
                    impRow.KensainNm = string.Empty;
                    // 更新日時(楽観ロックチェック用)
                    impRow.KeiryoShomeiIraiUpdateDt = infoRow.KeiryoShomeiIraiUpdateDt;

                    // 採水日付
                    impRow.SaisuiDt = infoRow.KeiryoShomeiSaisuiDt;
                    // 採水時分
                    impRow.SaisuiTime = infoRow.KeiryoShomeiSaisuiTime;
                    // 計量証明水温
                    impRow.KeiryoShomeiSuion = (decimal)infoRow.KeiryoShomeiSuion;
                    // 計量証明気温
                    impRow.KeiryoShomeiKion = (decimal)infoRow.KeiryoShomeiKion;
                    // 計量証明セットコード
                    impRow.KeiryoShomeiSetCd = infoRow.KeiryoShomeiSetCd;
                    // 計量証明検査料金
                    impRow.KeiryoShomeiKensaRyokin = infoRow.KeiryoShomeiKensaRyokin;
                    // 計量証明消費税額
                    impRow.KeiryoShomeiShohizei = infoRow.KeiryoShomeiShohizei;
                    // 検査項目枝番
                    impRow.KeiryoShomeiKensakomokuEdaban = infoRow.KeiryoShomeiKensakomokuEdaban;
                    // 外観検査対象
                    impRow.GaikanKensaTaisho = string.Empty;
                    // 外観検査地区割
                    impRow.GaikanKensaChikuwari = string.Empty;
                    // 検査セット名
                    impRow.KeiryoShomeiSetNm = infoRow.DaichoKensaSetNm;

                    // 行追加
                    impDT.AddUketsukeImportListRow(impRow);
                }
            }
            else if (alInput.SuishitsuKensaKbn == SuishitsuKensaKbn.SuishitsuKensa)
            {
                if (alOutput.KensaDaichoSuishitsuInfoDT.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                    return;
                }

                foreach (SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoRow infoRow in alOutput.KensaDaichoSuishitsuInfoDT)
                {
                    SuishitsuKensaIraiDataSet.UketsukeImportListRow impRow = impDT.NewUketsukeImportListRow();

                    // 更新フラグ
                    impRow.KoshinFlg = false;
                    // 登録済フラグ
                    impRow.TorokusumiFlg = "1";
                    // スクリーニング区分
                    impRow.ScreeningKbn = "0";
                    // 検査依頼法定区分
                    impRow.KensaIraiHoteiKbn = infoRow.KensaKekkaIraiHoteiKbn;
                    // 検査依頼保健所CD
                    impRow.KensaIraiHokenjoCd = infoRow.KensaKekkaIraiHokenjoCd;
                    // 検査依頼年度
                    impRow.KensaIraiNendo = infoRow.KensaKekkaIraiNendo;
                    // 検査依頼連番
                    impRow.KensaIraiRenban = infoRow.KensaKekkaIraiRenban;
                    // 検査依頼番号
                    impRow.KensaIraiNo = infoRow.KensaIraiNo;
                    // 再採水区分
                    impRow.SaisaisuiKbn = infoRow.SaisaisuiKbn;
                    // スクリーニング区分が0の場合
                    if (impRow.ScreeningKbn == "0")
                    {
                        // 再採水区分：初回
                        impRow.SaisaisuiKbn = "0";
                        impRow.SaisaisuiMark = "";
                    }
                    else
                    {
                        // 再採水区分：再採水
                        impRow.SaisaisuiKbn = "1";
                        impRow.SaisaisuiMark = "○";
                    }
                    // 計量証明検査依頼年度
                    impRow.KeiryoShomeiIraiNendo = string.Empty;
                    // 計量証明支所CD
                    impRow.KeiryoShomeiIraiSishoCd = string.Empty;
                    // 計量証明依頼連番
                    impRow.KeiryoShomeiIraiRenban = string.Empty;
                    // 計量証明依頼番号
                    impRow.KeiryoShomeiIraiNo = string.Empty;
                    // 検体番号
                    impRow.KentaiNo = infoRow.SuishitsuKensaIraiNo;
                    // 持込
                    impRow.MotikomiFlg = false;
                    // 収集
                    impRow.ShushuFlg = false;
                    if (infoRow.KensaIraiUketsukeKbn == "1")
                    {
                        // 1=持込
                        impRow.MotikomiFlg = true;
                        impRow.ShushuFlg = false;
                    }
                    else if (infoRow.KensaIraiUketsukeKbn == "2")
                    {
                        // 2=収集        
                        impRow.MotikomiFlg = false;
                        impRow.ShushuFlg = true;
                    }
                    // 現金
                    impRow.GenkinFlg = false;
                    if (infoRow.KensaIraiGenkinShunyuKbn == "1")
                    {
                        // 1=現金
                        impRow.GenkinFlg = true;
                    }
                    // 採水員CD
                    impRow.SaisuiinCd = infoRow.KensaIraiSaisuiinCd;
                    // 採水員名称
                    impRow.SaisuiinNm = infoRow.SaisuiinNm;
                    // 浄化槽台帳保健所CD
                    impRow.JokasoDaichoHokenjoCd = infoRow.JokasoHokenjoCd;
                    // 浄化槽台帳年度
                    impRow.JokasoDaichoNendo = infoRow.JokasoTorokuNendo;
                    // 浄化槽台帳連番
                    impRow.JokasoDaichoRenban = infoRow.JokasoRenban;
                    // 協会番号
                    impRow.KyokaiNo = infoRow.KyokaiNo;
                    // 残塩
                    impRow.ZanryuEnso = infoRow.KeiryoShomeiKekkaValue;
                    // 設置者名
                    impRow.SettishaNm = infoRow.JokasoSetchishaNm;
                    // 枝番
                    impRow.Edaban = string.Empty;
                    // 検査員CD
                    impRow.KensainCd = string.Empty;
                    // 検査員名称
                    impRow.KensainNm = string.Empty;
                    // 更新日時(楽観ロックチェック用)
                    impRow.KensaIraiUpdateDt = infoRow.KensaIraiUpdateDt;
                    impRow.KensaDaichoDtlUpdateDt = infoRow.KensaDaichoDtlUpdateDt;

                    // 検査料金
                    impRow.KensaIraiKensaAmt = infoRow.KensaIraiKensaAmt;
                    // 入金額
                    impRow.KensaIraiNyukinzumiAmt = infoRow.KensaIraiNyukinzumiAmt;
                    // 保健所非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    impRow.KensaIraiHakkoKbn4 = infoRow.KensaIraiHakkoKbn4;
                    // 市町村非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    impRow.KensaIraiHakkoKbn5 = infoRow.KensaIraiHakkoKbn5;
                    // 外観検査対象
                    impRow.GaikanKensaTaisho = string.Empty;
                    // 外観検査地区割
                    impRow.GaikanKensaChikuwari = string.Empty;
                    // 検査セット名
                    impRow.KeiryoShomeiSetNm = string.Empty;

                    // 行追加
                    impDT.AddUketsukeImportListRow(impRow);
                }
            }
            else if (alInput.SuishitsuKensaKbn == SuishitsuKensaKbn.GaikanKensa)
            {
                if (alOutput.KensaDaichoGaikanInfoDT.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                    return;
                }

                foreach (SuishitsuKensaUketsukeDataSet.KensaDaichoGaikanInfoRow infoRow in alOutput.KensaDaichoGaikanInfoDT)
                {
                    SuishitsuKensaIraiDataSet.UketsukeImportListRow impRow = impDT.NewUketsukeImportListRow();

                    // 更新フラグ
                    impRow.KoshinFlg = false;
                    // 登録済フラグ
                    impRow.TorokusumiFlg = "1";
                    // スクリーニング区分
                    //impRow.ScreeningKbn = "0";
                    impRow.ScreeningKbn = infoRow.KensaIraiScreeningKbn;
                    // 検査依頼法定区分
                    impRow.KensaIraiHoteiKbn = infoRow.KensaKekkaIraiHoteiKbn;
                    // 検査依頼保健所CD
                    impRow.KensaIraiHokenjoCd = infoRow.KensaKekkaIraiHokenjoCd;
                    // 検査依頼年度
                    impRow.KensaIraiNendo = infoRow.KensaKekkaIraiNendo;
                    // 検査依頼連番
                    impRow.KensaIraiRenban = infoRow.KensaKekkaIraiRenban;
                    // 検査依頼番号
                    impRow.KensaIraiNo = infoRow.KensaIraiNo;
                    // 再採水区分
                    impRow.SaisaisuiKbn = infoRow.SaisaisuiKbn;
                    // スクリーニング区分が0の場合
                    if (impRow.ScreeningKbn == "0")
                    {
                        // 再採水区分：初回
                        impRow.SaisaisuiKbn = "0";
                        impRow.SaisaisuiMark = "";
                    }
                    else
                    {
                        // 再採水区分：再採水
                        impRow.SaisaisuiKbn = "1";
                        impRow.SaisaisuiMark = "○";
                    }
                    // 計量証明検査依頼年度
                    impRow.KeiryoShomeiIraiNendo = string.Empty;
                    // 計量証明支所CD
                    impRow.KeiryoShomeiIraiSishoCd = string.Empty;
                    // 計量証明依頼連番
                    impRow.KeiryoShomeiIraiRenban = string.Empty;
                    // 計量証明依頼番号
                    impRow.KeiryoShomeiIraiNo = string.Empty;
                    // 検体番号
                    impRow.KentaiNo = infoRow.SuishitsuKensaIraiNo;
                    // 持込
                    impRow.MotikomiFlg = false;
                    // 収集
                    impRow.ShushuFlg = false;
                    if (infoRow.KensaIraiUketsukeKbn == "1")
                    {
                        // 1=持込
                        impRow.MotikomiFlg = true;
                        impRow.ShushuFlg = false;
                    }
                    else if (infoRow.KensaIraiUketsukeKbn == "2")
                    {
                        // 2=収集        
                        impRow.MotikomiFlg = false;
                        impRow.ShushuFlg = true;
                    }
                    // 現金
                    impRow.GenkinFlg = false;
                    if (infoRow.KensaIraiGenkinShunyuKbn == "1")
                    {
                        // 1=現金
                        impRow.GenkinFlg = true;
                    }
                    // 採水員CD
                    impRow.SaisuiinCd = string.Empty;
                    // 採水員名称
                    impRow.SaisuiinNm = string.Empty;
                    // 浄化槽台帳保健所CD
                    impRow.JokasoDaichoHokenjoCd = infoRow.JokasoHokenjoCd;
                    // 浄化槽台帳年度
                    impRow.JokasoDaichoNendo = infoRow.JokasoTorokuNendo;
                    // 浄化槽台帳連番
                    impRow.JokasoDaichoRenban = infoRow.JokasoRenban;
                    // 協会番号
                    impRow.KyokaiNo = infoRow.KyokaiNo;
                    // 透視度
                    impRow.Toshido = infoRow.KeiryoShomeiKekkaValue;
                    // 設置者名
                    impRow.SettishaNm = infoRow.JokasoSetchishaNm;
                    // 枝番
                    impRow.Edaban = string.Empty;
                    // 検査員CD
                    impRow.KensainCd = infoRow.KensaIraiKensaTantoshaCd;
                    // 検査員名称
                    impRow.KensainNm = infoRow.ShokuinNm;
                    // 更新日時(楽観ロックチェック用)
                    impRow.KensaDaichoDtlUpdateDt = infoRow.KensaDaichoDtlUpdateDt;
                    // 外観検査対象
                    impRow.GaikanKensaTaisho = string.Empty;
                    // 外観検査地区割
                    impRow.GaikanKensaChikuwari = string.Empty;
                    // 検査セット名
                    impRow.KeiryoShomeiSetNm = string.Empty;

                    // 行追加
                    impDT.AddUketsukeImportListRow(impRow);
                }
            }

            // 一覧に設定
            kensaUketsukeListDataGridView.DataSource = impDT;
            // 一覧の表示設定
            settingChengeKensaUketsukeList();

            // 件数表示
            uketsukeListCountLabel.Text = kensaUketsukeListDataGridView.Rows.Count.ToString() + "件";
            // 左上のセルに
            kensaUketsukeListDataGridView.CurrentCell = kensaUketsukeListDataGridView[0, 0];
            //kensaUketsukeListDataGridView.FirstDisplayedScrollingRowIndex = 0;
            //kensaUketsukeListDataGridView.FirstDisplayedScrollingColumnIndex = 0;
        }
        #endregion

        #region doLoadForm
        // 画面ロード時の必要情報取得
        private void doLoadForm()
        {
            // 20150129 sou Start 共通関数使用
            #region to be removed
            //IFormLoadALInput alInput = new FormLoadALInput();
            ////20150128 HuyTX Mod 課題対応 No279 支所コンボから事務局除外対応
            ////ShishoMstDataSet.ShishoMstDataTable shishoMst = new FormLoadApplicationLogic().Execute(alInput).ShishoMstDT;
            //ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable shishoMst = new FormLoadApplicationLogic().Execute(alInput).ShishoMstExceptJimukyokuDataTable;
            ////End
            //if (shishoMst.Count > 0)
            //{
            //    shishoComboBox.DataSource = shishoMst;
            //}
            #endregion
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput()); 
            Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
            // 20150129 sou End

        }
        #endregion

        #region clearForm
        // 画面情報設定
        private void clearForm()
        {
            // 支所（ログインユーザの所属支所を初期選択）
            shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 依頼年度（現在日から年度取得した年度を初期設定）
            int nendo = Utility.DateUtility.GetNendo(Boundary.Common.Common.GetCurrentTimestamp());
            iraiNendoTextBox.Text = nendo.ToString();
            // 受付日（現在日を初期設定）
            uketsukeDataTimePicker.Value = Boundary.Common.Common.GetCurrentTimestamp();

            // 検体番号（開始）
            iraiNoFromTextBox.Text = string.Empty;
            // 検体番号（開始）
            iraiNoToTextBox.Text = string.Empty;
            // 一覧クリア
            kensaUketsukeListDataGridView.DataSource = null;
            kensaUketsukeListDataGridView.Rows.Clear();
            //kensaUketsukeListDataGridView.FirstDisplayedScrollingColumnIndex = 0;
            // 件数表示
            uketsukeListCountLabel.Text = kensaUketsukeListDataGridView.Rows.Count.ToString() + "件";
        }
        #endregion

        #region setControlDomain
        // 各コントロールのドメイン設定
        private void setControlDomain()
        {
            // 年度
            //iraiNendoTextBox.SetControlDomain(ZControlDomain.ZT_NENDO);
            iraiNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, HorizontalAlignment.Right);
            // 検体番号(開始)
            iraiNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);
            // 検体番号(終了)
            iraiNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);
            // リスト部
            // 残留塩素
            kensaUketsukeListDataGridView.SetStdControlDomain(zanryuEnsoCol.Index, ZControlDomain.ZG_STD_NUM, 9, 3, InputValidateUtility.SignFlg.Positive);
            // 透視度
            kensaUketsukeListDataGridView.SetStdControlDomain(ToshidoCol.Index, ZControlDomain.ZG_STD_NUM, 9, 3, InputValidateUtility.SignFlg.Positive);
            // 検体番号
            kensaUketsukeListDataGridView.SetStdControlDomain(kentaiNoCol.Index, ZControlDomain.ZG_STD_CD, 6, DataGridViewContentAlignment.MiddleRight);
            // 金額系
            kensaUketsukeListDataGridView.SetStdControlDomain(KensaAmtCol.Index, ZControlDomain.ZG_STD_NUM);
            kensaUketsukeListDataGridView.SetStdControlDomain(NyukinzumiAmtCol.Index, ZControlDomain.ZG_STD_NUM);
            kensaUketsukeListDataGridView.SetStdControlDomain(KeiryoShomeiKensaRyokinCol.Index, ZControlDomain.ZG_STD_NUM);
            kensaUketsukeListDataGridView.SetStdControlDomain(KeiryoShomeiShohizeiCol.Index, ZControlDomain.ZG_STD_NUM);
            // 再採水
            kensaUketsukeListDataGridView.SetStdControlDomain(saisaisuiMarkCol.Index, ZControlDomain.ZG_STD_NAME, DataGridViewContentAlignment.MiddleCenter);
            // 水温
            kensaUketsukeListDataGridView.SetStdControlDomain(KeiryoShomeiSuionCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            // 気温
            kensaUketsukeListDataGridView.SetStdControlDomain(KeiryoShomeiKionCol.Index, ZControlDomain.ZG_STD_NUM, 4);

        }
        #endregion

        #region setControlProperty
        // 画面モードごとのボタンやコントロールの制御（活性・非活性）
        private void setControlProperty()
        {
            // 初期モード時
            if (gamenMode.Text == GamenMode.Init)
            {
                // 条件パネル
                kensaKbnGroupBox.Enabled = true;
                iraiNendoTextBox.Enabled = true;
                shishoComboBox.Enabled = true;
                uketsukeDataTimePicker.Enabled = true;
                iraiNoFromTextBox.Enabled = true;
                iraiNoToTextBox.Enabled = true;
                // 検索ボタン
                kensakuButton.Enabled = true;
                // クリアボタン
                clearButton.Enabled = true;
                // 取込ボタン
                torikomiButton.Enabled = true;
                // 取消ボタン
                torikeshiButton.Enabled = false;
                // 詳細ボタン
                shosaiButton.Enabled = false;
                // 一括入力ボタン
                ikkatsuNyuryokuButton.Enabled = false;
                // 現金入力ボタン
                genkinNyuryokuButton.Enabled = false;
                // 確定入力ボタン
                kakuteiButton.Enabled = false;
                // 一覧出力ボタン
                outputButton.Enabled = false;
                // 手入力ボタン
                editInputButton.Enabled = true;
                // 閉じるボタン
                tojiruButton.Enabled = true;
            }
            // 未編集モード時
            if (gamenMode.Text == GamenMode.NoEdit)
            {
                // 条件パネル
                kensaKbnGroupBox.Enabled = false;
                iraiNendoTextBox.Enabled = false;
                shishoComboBox.Enabled = false;
                uketsukeDataTimePicker.Enabled = false;
                iraiNoFromTextBox.Enabled = false;
                iraiNoToTextBox.Enabled = false;
                // 検索ボタン
                kensakuButton.Enabled = false;
                clearButton.Enabled = false;
                // 取込ボタン
                torikomiButton.Enabled = false;
                // 取消ボタン
                torikeshiButton.Enabled = true;
                // 詳細ボタン
                shosaiButton.Enabled = true;
                // 一括入力ボタン
                if (gaikanKensaRadioButton.Checked == true)
                {
                    // 外観検査時は、非活性
                    ikkatsuNyuryokuButton.Enabled = false;
                }
                else
                {
                    ikkatsuNyuryokuButton.Enabled = true;
                }
                // 現金入力ボタン
                genkinNyuryokuButton.Enabled = true;
                // 確定入力ボタン
                kakuteiButton.Enabled = false;
                // 一覧出力ボタン
                outputButton.Enabled = true;
                // 手入力ボタン
                editInputButton.Enabled = false;
                // 閉じるボタン
                tojiruButton.Enabled = true;
            }
            // 登録モード時
            if (gamenMode.Text == GamenMode.Insert)
            {
                // 条件パネル
                kensaKbnGroupBox.Enabled = false;
                iraiNendoTextBox.Enabled = false;
                shishoComboBox.Enabled = false;
                uketsukeDataTimePicker.Enabled = false;
                iraiNoFromTextBox.Enabled = false;
                iraiNoToTextBox.Enabled = false;
                // 検索ボタン
                kensakuButton.Enabled = false;
                clearButton.Enabled = false;
                // 取込ボタン
                torikomiButton.Enabled = false;
                // 取消ボタン
                torikeshiButton.Enabled = true;
                // 詳細ボタン
                shosaiButton.Enabled = true;
                // 一括入力ボタン
                if (gaikanKensaRadioButton.Checked == true)
                {
                    // 外観取込時は、非活性
                    ikkatsuNyuryokuButton.Enabled = false;
                }
                else
                {
                    ikkatsuNyuryokuButton.Enabled = true;
                }
                // 現金入力ボタン
                //genkinNyuryokuButton.Enabled = true;
                // 取込後は、依頼テーブルなどが無いので現金入金不可
                genkinNyuryokuButton.Enabled = false;
                // 確定入力ボタン
                kakuteiButton.Enabled = true;
                // 一覧出力ボタン
                outputButton.Enabled = true;
                // 手入力ボタン
                editInputButton.Enabled = true;
                // 閉じるボタン
                tojiruButton.Enabled = true;
            }
            // 更新モード時
            if (gamenMode.Text == GamenMode.Update)
            {
                // 条件パネル
                kensaKbnGroupBox.Enabled = false;
                iraiNendoTextBox.Enabled = false;
                shishoComboBox.Enabled = false;
                uketsukeDataTimePicker.Enabled = false;
                iraiNoFromTextBox.Enabled = false;
                iraiNoToTextBox.Enabled = false;
                // 検索ボタン
                kensakuButton.Enabled = false;
                clearButton.Enabled = false;
                // 取込ボタン
                torikomiButton.Enabled = false;
                // 取消ボタン
                torikeshiButton.Enabled = true;
                // 詳細ボタン
                shosaiButton.Enabled = true;
                // 一括入力ボタン
                if (gaikanKensaRadioButton.Checked == true)
                {
                    // 外観検査時は、非活性
                    ikkatsuNyuryokuButton.Enabled = false;
                }
                else
                {
                    ikkatsuNyuryokuButton.Enabled = true;
                }
                // 現金入力ボタン
                // 2015.01.12 toyoda Modify Start 現金入金後に画面の再描画を行う（編集中は入金不可）
                //genkinNyuryokuButton.Enabled = true;
                genkinNyuryokuButton.Enabled = false;
                // 2015.01.12 toyoda Modify End

                // 確定入力ボタン
                kakuteiButton.Enabled = true;
                // 一覧出力ボタン
                outputButton.Enabled = true;
                // 手入力ボタン
                editInputButton.Enabled = false;
                // 閉じるボタン
                tojiruButton.Enabled = true;
            }
        }
        #endregion

        #region nextForm
        // 詳細画面表示
        private void nextForm()
        {
            if (kensaUketsukeListDataGridView.CurrentRow.Index < 0)
            {
                return;
            }
            // カレント行
            int rowIndex = kensaUketsukeListDataGridView.CurrentRow.Index;
            // 浄化槽台帳保健所コード
            string jokasoDaichoHokenjoCd = kensaUketsukeListDataGridView[jokasoDaichoHokenjoCdCol.Index, rowIndex].Value.ToString();
            // 浄化槽台帳登録年度
            string jokasoDaichoNendo = kensaUketsukeListDataGridView[jokasoDaichoNendoCol.Index, rowIndex].Value.ToString();
            // 浄化槽台帳連番
            string jokasoDaichoRenban = kensaUketsukeListDataGridView[jokasoDaichoRenbanCol.Index, rowIndex].Value.ToString();
            // 計量証明依頼年度
            string keiryoShomeiNendo = kensaUketsukeListDataGridView[keiryoShomeiIraiNendoCol.Index, rowIndex].Value.ToString();
            // 計量証明依頼支所
            string keiryoShomeiSisho = kensaUketsukeListDataGridView[keiryoShomeiIraiSishoCdCol.Index, rowIndex].Value.ToString();
            // 計量証明依頼連番
            string keiryoShomeiRenban = kensaUketsukeListDataGridView[keiryoShomeiIraiRenbanCol.Index, rowIndex].Value.ToString();
            // 検査依頼法定区分
            string kensaIraiHoteiKbn = kensaUketsukeListDataGridView[kensaIraiHoteiKbnCol.Index, rowIndex].Value.ToString();
            // 検査依頼法定保健所コード
            string kensaIraiHokenjoCd = kensaUketsukeListDataGridView[kensaIraiHokenjoCdCol.Index, rowIndex].Value.ToString();
            // 検査依頼法定年度
            string kensaIraiNendo = kensaUketsukeListDataGridView[kensaIraiNendoCol.Index, rowIndex].Value.ToString();
            // 検査依頼法定連番
            string kensaIraiRenban = kensaUketsukeListDataGridView[kensaIraiRenbanCol.Index, rowIndex].Value.ToString();
            // 検体番号
            string kentaiNo = kensaUketsukeListDataGridView[kentaiNoCol.Index, rowIndex].Value.ToString();
            // 依頼年度
            string iraiNendo = iraiNendoTextBox.Text.Trim();
            // 支所コード
            string shishoCd = shishoComboBox.SelectedValue.ToString();
            // 検査受付日付
            string suishitsuUketsukeDt = uketsukeDataTimePicker.Value.ToString("yyyyMMdd");
            //　一覧データ
            SuishitsuKensaIraiDataSet.UketsukeImportListDataTable listDT = (SuishitsuKensaIraiDataSet.UketsukeImportListDataTable)kensaUketsukeListDataGridView.DataSource;

            if (string.IsNullOrEmpty(kensaUketsukeListDataGridView[kyokaiNoCol.Index, rowIndex].Value.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("浄化槽台帳が指定されていません。検体番号:[{0}]", kentaiNo));
                return;
            }

            // 画面遷移
            if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.KeiryoShomei)
            {
                SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable KeiryoShomeiIraiInfo;
                SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable KensaSetPattern;
                KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDT;

                // 登録モードの場合（依頼取込後）
                if (gamenMode.Text == GamenMode.Insert)
                {
                    // 表示用データ取得
                    IGetInsertDataForKeiryoShomeiShosaiALInput alInput = new GetInsertDataForKeiryoShomeiShosaiALInput();
                    // 依頼年度 
                    alInput.IraiNendo = iraiNendo;
                    // 支所コード 
                    alInput.ShishoCd = shishoCd;
                    // 検査受付日付
                    alInput.SuishitsuUketsukeDt = suishitsuUketsukeDt;
                    // 取込結果一覧データ
                    alInput.ListRow = listDT[rowIndex];
                    // 検索実行
                    IGetInsertDataForKeiryoShomeiShosaiALOutput alOutput = new GetInsertDataForKeiryoShomeiShosaiApplicationLogic().Execute(alInput);

                    KeiryoShomeiIraiInfo = alOutput.KeiryoShomeiIraiInfo;
                    KensaSetPattern = alOutput.KensaSetPattern;
                    KeiryoShomeiIraiTblDT = alOutput.KeiryoShomeiIraiTblDT;
                }
                // 更新モードの場合（検索実行後）
                else
                {
                    // 表示用データ取得
                    IGetDataForKeiryoShomeiShosaiALInput alInput = new GetDataForKeiryoShomeiShosaiALInput();
                    // 計量証明依頼年度
                    alInput.KeiryoShomeiIraiNendo = keiryoShomeiNendo;
                    // 計量証明支所
                    alInput.KeiryoShomeiIraiSishoCd = keiryoShomeiSisho;
                    // 計量証明連番
                    alInput.KeiryoShomeiIraiRenban = keiryoShomeiRenban;
                    // 取込結果一覧データ
                    alInput.ListRow = listDT[rowIndex];
                    // 検索実行
                    IGetDataForKeiryoShomeiShosaiALOutput alOutput = new GetDataForKeiryoShomeiShosaiApplicationLogic().Execute(alInput);

                    KeiryoShomeiIraiInfo = alOutput.KeiryoShomeiIraiInfo;
                    KensaSetPattern = alOutput.KensaSetPattern;
                    KeiryoShomeiIraiTblDT = alOutput.KeiryoShomeiIraiTblDT;
                }

                // 計量証明用の詳細画面
                SuishitsuKensaIraiUketsukeKeiryoShomeiShosai frm = new SuishitsuKensaIraiUketsukeKeiryoShomeiShosai(KeiryoShomeiIraiInfo, KensaSetPattern, KeiryoShomeiIraiTblDT);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    // 更新フラグOK
                    kensaUketsukeListDataGridView[KoshinFlgCol.Index, rowIndex].Value = true;

                    // 受付区分(1=持込、2=収集)(デフォルト:1)
                    if (frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiUketsukeKbn == "1")
                    {
                        // 1=持込
                        kensaUketsukeListDataGridView[motikomiFlgCol.Index, rowIndex].Value = true;
                        kensaUketsukeListDataGridView[shushuFlgCol.Index, rowIndex].Value = false;
                    }
                    else if (frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiUketsukeKbn == "2")
                    {
                        // 2=収集        
                        kensaUketsukeListDataGridView[motikomiFlgCol.Index, rowIndex].Value = false;
                        kensaUketsukeListDataGridView[shushuFlgCol.Index, rowIndex].Value = true;
                    }
                    // 採水員コード
                    kensaUketsukeListDataGridView[saisuiinCdCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiSaisuiinCd;
                    // 採水員名(採水員コードから検索した名称)
                    SaisuiinMstDataSet.SaisuiinMstDataTable saisuiinMstDT = Common.Common.GetSaisuiinMstByKey(frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiSaisuiinCd);
                    if (saisuiinMstDT.Rows.Count > 0)
                    {
                        // 該当ありなら採水員名称セット
                        SaisuiinMstDataSet.SaisuiinMstRow saisuiinMstRow = saisuiinMstDT[0];
                        kensaUketsukeListDataGridView[saisuiinNmCol.Index, rowIndex].Value = saisuiinMstRow.SaisuiinNm;
                    }
                    else
                    {
                        // 該当なしなら名称は空文字
                        kensaUketsukeListDataGridView[saisuiinNmCol.Index, rowIndex].Value = string.Empty;
                    }
                    // 採水日付
                    kensaUketsukeListDataGridView[SaisuiDtCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiSaisuiDt;
                    // 採水時分
                    kensaUketsukeListDataGridView[SaisuiTimeCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiSaisuiTime;
                    // 計量証明水温
                    kensaUketsukeListDataGridView[KeiryoShomeiSuionCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiSuion;
                    // 計量証明気温
                    kensaUketsukeListDataGridView[KeiryoShomeiKionCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiKion;
                    // 計量証明セットコード
                    kensaUketsukeListDataGridView[KeiryoShomeiSetCdCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiSetCd;
                    // 計量証明検査料金
                    kensaUketsukeListDataGridView[KeiryoShomeiKensaRyokinCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiKensaRyokin;
                    // 計量証明消費税額
                    kensaUketsukeListDataGridView[KeiryoShomeiShohizeiCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiShohizei;
                    // 検査項目枝番
                    kensaUketsukeListDataGridView[KeiryoShomeiKensakomokuEdabanCol.Index, rowIndex].Value = frm.ModifiedKeiryoShomeiIraiTblDT[0].KeiryoShomeiKensakomokuEdaban;
                    // 検査セット名
                    kensaUketsukeListDataGridView[KeiryoShomeiSetNmCol.Index, rowIndex].Value = frm.KeiryoShomeiSetNm;
                }
            }
            else if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.SuishitsuKensa)
            {
                SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable SuishitsuIraiInfo;
                KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT;
                KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable;
                SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable MaxKensaDt;

                // 登録モードの場合（依頼取込後）
                if (gamenMode.Text == GamenMode.Insert)
                {
                    // 表示用データ取得
                    IGetInsertDataForSuisitsuKensaShosaiALInput alInput = new GetInsertDataForSuisitsuKensaShosaiALInput();
                    // 依頼年度 
                    alInput.IraiNendo = iraiNendo;
                    // 支所コード 
                    alInput.ShishoCd = shishoCd;
                    // 検査受付日付
                    alInput.SuishitsuUketsukeDt = suishitsuUketsukeDt;
                    // 取込結果一覧データ
                    alInput.ListRow = listDT[rowIndex];

                    // 検索実行
                    IGetInsertDataForSuisitsuKensaShosaiALOutput alOutput = new GetInsertDataForSuisitsuKensaShosaiApplicationLogic().Execute(alInput);

                    SuishitsuIraiInfo = alOutput.SuishitsuIraiInfo;
                    KensaDaichoDtlTblDT = alOutput.KensaDaichoDtlTblDT;
                    KensaIraiTblDataTable = alOutput.KensaIraiTblDataTable;
                    MaxKensaDt = alOutput.MaxKensaDt;
                }
                // 更新モードの場合（検索実行後）
                else
                {
                    // 表示用データ取得
                    IGetDataForSuisitsuKensaShosaiALInput alInput = new GetDataForSuisitsuKensaShosaiALInput();
                    alInput.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
                    alInput.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
                    alInput.KensaIraiNendo = kensaIraiNendo;
                    alInput.KensaIraiRenban = kensaIraiRenban;
                    alInput.KensaKbn = suishitsuKensaKbn.Text;
                    alInput.IraiNendo = iraiNendo;
                    alInput.Sisho = shishoCd;
                    alInput.IraiNo = kentaiNo;
                    // 取込結果一覧データ
                    alInput.ListRow = listDT[rowIndex];

                    // 検索実行
                    IGetDataForSuisitsuKensaShosaiALOutput alOutput = new GetDataForSuisitsuKensaShosaiApplicationLogic().Execute(alInput);

                    SuishitsuIraiInfo = alOutput.SuishitsuIraiInfo;
                    KensaDaichoDtlTblDT = alOutput.KensaDaichoDtlTblDT;
                    KensaIraiTblDataTable = alOutput.KensaIraiTblDataTable;
                    MaxKensaDt = alOutput.MaxKensaDt;
                }

                // 水質検査用の詳細画面
                SuishitsuKensaIraiUketsukeSuisitsuKensaShosai frm =
                    new SuishitsuKensaIraiUketsukeSuisitsuKensaShosai(KensaDaichoDtlTblDT, KensaIraiTblDataTable, SuishitsuIraiInfo, MaxKensaDt);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    // 更新フラグOK
                    kensaUketsukeListDataGridView[KoshinFlgCol.Index, rowIndex].Value = true;

                    // 受付区分(1=持込、2=収集)(デフォルト:1)
                    if (frm.ModifiedKensaIraiTbl[0].KensaIraiUketsukeKbn == "1")
                    {
                        // 1=持込
                        kensaUketsukeListDataGridView[motikomiFlgCol.Index, rowIndex].Value = true;
                        kensaUketsukeListDataGridView[shushuFlgCol.Index, rowIndex].Value = false;
                    }
                    else if (frm.ModifiedKensaIraiTbl[0].KensaIraiUketsukeKbn == "2")
                    {
                        // 2=収集        
                        kensaUketsukeListDataGridView[motikomiFlgCol.Index, rowIndex].Value = false;
                        kensaUketsukeListDataGridView[shushuFlgCol.Index, rowIndex].Value = true;
                    }
                    // 採水員コード
                    kensaUketsukeListDataGridView[saisuiinCdCol.Index, rowIndex].Value = frm.ModifiedKensaIraiTbl[0].KensaIraiSaisuiinCd;
                    // 採水員名(採水員コードから検索した名称)
                    SaisuiinMstDataSet.SaisuiinMstDataTable saisuiinMstDT = Common.Common.GetSaisuiinMstByKey(frm.ModifiedKensaIraiTbl[0].KensaIraiSaisuiinCd);
                    if (saisuiinMstDT.Rows.Count > 0)
                    {
                        // 該当ありなら採水員名称セット
                        SaisuiinMstDataSet.SaisuiinMstRow saisuiinMstRow = saisuiinMstDT[0];
                        kensaUketsukeListDataGridView[saisuiinNmCol.Index, rowIndex].Value = saisuiinMstRow.SaisuiinNm;
                    }
                    else
                    {
                        // 該当なしなら名称は空文字
                        kensaUketsukeListDataGridView[saisuiinNmCol.Index, rowIndex].Value = string.Empty;
                    }
                    // 保健所非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    kensaUketsukeListDataGridView[HakkoKbn4Col.Index, rowIndex].Value = frm.ModifiedKensaIraiTbl[0].KensaIraiHakkoKbn4;
                    // 市町村非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    kensaUketsukeListDataGridView[HakkoKbn5Col.Index, rowIndex].Value = frm.ModifiedKensaIraiTbl[0].KensaIraiHakkoKbn5;

                    // 残留塩素
                    kensaUketsukeListDataGridView[zanryuEnsoCol.Index, rowIndex].Value = frm.ModifiedKensaDaichoDtl[0].KeiryoShomeiKekkaValue;
                }
            }
            else if (suishitsuKensaKbn.Text == SuishitsuKensaKbn.GaikanKensa)
            {
                SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable SuishitsuIraiInfo;
                KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT;

                // 登録モードの場合（依頼取込後）
                if (gamenMode.Text == GamenMode.Insert)
                {
                    // 表示用データ取得
                    IGetInsertDataForGaikanKensaShosaiALInput alInput = new GetInsertDataForGaikanKensaShosaiALInput();
                    // 依頼年度 
                    alInput.IraiNendo = iraiNendo;
                    // 支所コード 
                    alInput.ShishoCd = shishoCd;
                    // 検査受付日付
                    alInput.SuishitsuUketsukeDt = suishitsuUketsukeDt;
                    // 取込結果一覧データ
                    alInput.ListRow = listDT[rowIndex];

                    // 検索実行
                    IGetInsertDataForGaikanKensaShosaiALOutput alOutput = new GetInsertDataForGaikanKensaShosaiApplicationLogic().Execute(alInput);

                    SuishitsuIraiInfo = alOutput.SuishitsuIraiInfo;
                    KensaDaichoDtlTblDT = alOutput.KensaDaichoDtlTblDT;
                }
                // 更新モードの場合（検索実行後）
                else
                {
                    // 表示用データ取得
                    IGetDataForGaikanKensaShosaiALInput alInput = new GetDataForGaikanKensaShosaiALInput();
                    alInput.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
                    alInput.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
                    alInput.KensaIraiNendo = kensaIraiNendo;
                    alInput.KensaIraiRenban = kensaIraiRenban;
                    alInput.KensaKbn = suishitsuKensaKbn.Text;
                    alInput.IraiNendo = iraiNendo;
                    alInput.Sisho = shishoCd;
                    alInput.IraiNo = kentaiNo;
                    // 取込結果一覧データ
                    alInput.ListRow = listDT[rowIndex];

                    // 検索実行
                    IGetDataForGaikanKensaShosaiALOutput alOutput = new GetDataForGaikanKensaShosaiApplicationLogic().Execute(alInput);

                    SuishitsuIraiInfo = alOutput.SuishitsuIraiInfo;
                    KensaDaichoDtlTblDT = alOutput.KensaDaichoDtlTblDT;
                }

                // 外観検査用の詳細画面
                SuishitsuKensaIraiUketsukeGaikanKensaShosai frm =
                    new SuishitsuKensaIraiUketsukeGaikanKensaShosai(KensaDaichoDtlTblDT, SuishitsuIraiInfo);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    // 更新フラグOK
                    kensaUketsukeListDataGridView[KoshinFlgCol.Index, rowIndex].Value = true;

                    // 透視度
                    kensaUketsukeListDataGridView[ToshidoCol.Index, rowIndex].Value = frm.ModifiedKensaDaichoDtl[0].KeiryoShomeiKekkaValue;
                }
            }
        }
        #endregion

        #region  getHhtDataFile
        // 取込用HHTデータファイルを取得
        private bool getHhtDataFile(string suishitsuKensaKbn, out string localFilePath)
        {
            // HHTデータファイル名
            string constRenban = string.Empty;
            if (suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei)
            {
                // 計量証明
                constRenban = Constants.ConstRenbanConstanst.CONST_RENBAN_001;
            }
            else if (suishitsuKensaKbn == SuishitsuKensaKbn.SuishitsuKensa)
            {
                // 水質用
                constRenban = Constants.ConstRenbanConstanst.CONST_RENBAN_002;
            }
            else
            {
                // 外観用
                constRenban = Constants.ConstRenbanConstanst.CONST_RENBAN_003;
            }
            string fileName = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_HHT_FNAME, constRenban);

            // 取込用ローカルフォルダ名
            string localFolder = SharedFolderUtility.GetConstLocalFolder(Constants.ConstKbnConstanst.CONST_KBN_HHT_SV_DIR, Constants.ConstRenbanConstanst.CONST_RENBAN_001);
            localFilePath = Path.Combine(localFolder, fileName);

            // 取込用HHTファイル名の存在確認
            if (!File.Exists(localFilePath))
            {
                // HHTデータファイルが存在しない
                // 「指定された{0}は存在しません。」
                MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("指定された HHTデータファイルが存在しません。{0}", localFilePath));
                // エラー
                return false;
            }

            return true;
        }
        #endregion

        //#region  getHhtDataFile
        //// 取込用HHTデータファイルを取得
        //private bool getHhtDataFile(string suishitsuKensaKbn, out string localFilePath)
        //{
        //    // サーバフォルダ名
        //    string serverFolder = SharedFolderUtility.GetConstFolder(Constants.ConstKbnConstanst.CONST_KBN_HHT_SV_DIR, Constants.ConstRenbanConstanst.CONST_RENBAN_001, 0, 1, "");

        //    // HHTデータファイル名
        //    string constRenban = string.Empty;
        //    if (suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei)
        //    {
        //        // 計量証明
        //        constRenban = Constants.ConstRenbanConstanst.CONST_RENBAN_001;
        //    }
        //    else if (suishitsuKensaKbn == SuishitsuKensaKbn.SuishitsuKensa)
        //    {
        //        // 水質用
        //        constRenban = Constants.ConstRenbanConstanst.CONST_RENBAN_002;
        //    }
        //    else
        //    {
        //        // 外観用
        //        constRenban = Constants.ConstRenbanConstanst.CONST_RENBAN_003;
        //    }
        //    string fileName = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_HHT_FNAME, constRenban);

        //    // 取込用ローカルフォルダ名
        //    string localFolder = SharedFolderUtility.GetConstLocalFolder(Constants.ConstKbnConstanst.CONST_KBN_HHT_CL_DIR, Constants.ConstRenbanConstanst.CONST_RENBAN_001);

        //    // サーバファイル名
        //    string shareFilePath = Path.Combine(serverFolder, fileName);
        //    // 取込ローカルファイル名
        //    localFilePath = Path.Combine(localFolder, fileName);

        //    // 取込ローカルフォルダの存在確認
        //    if (!Directory.Exists(localFolder))
        //    {
        //        // ローカルフォルダが存在しない場合はフォルダ作成
        //        Directory.CreateDirectory(localFolder);
        //    }

        //    // 取込ローカルファイル名の存在確認
        //    if (File.Exists(localFilePath))
        //    {
        //        // ローカルファイルが存在する場合は削除
        //        File.Delete(localFilePath);
        //    }

        //    // サーバファイル名の存在確認
        //    if (File.Exists(shareFilePath))
        //    {
        //        try
        //        {
        //            // 共有フォルダに接続
        //            if (!SharedFolderUtility.Connect())
        //            {
        //                // サーバに接続できません
        //                // 「サーバに接続できません。{0}」
        //                MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバに接続できません。{0}", serverFolder));
        //                return false;
        //            }

        //            // 共有フォルダからダウンロード
        //            if (!SharedFolderUtility.DownloadFile(localFilePath, shareFilePath))
        //            {
        //                // サーバから HHTデータファイルのダウンロードに失敗しました。
        //                // 「サーバから HHTデータファイルのダウンロードに失敗しました。{0}」
        //                MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバから HHTデータファイルのダウンロードに失敗しました。{0} {1}", shareFilePath, localFilePath));
        //                return false;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // エラー処理
        //            // 共有フォルダへのアクセスに失敗しました。
        //            MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("共有フォルダへのアクセスに失敗しました。{0}", shareFilePath));
        //            throw ex;
        //        }
        //        finally
        //        {
        //            // 共有フォルダから切断
        //            SharedFolderUtility.Disconnect();
        //        }
        //    }
        //    else
        //    {
        //        // サーバに HHTデータファイルが存在しない
        //        // 「指定された{0}は存在しません。」
        //        MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("指定された HHTデータファイルが存在しません。{0}", shareFilePath));
        //        // エラー
        //        return false;
        //    }

        //    return true;
        //}
        //#endregion

        #region importHhtData
        // HHTデータファイルを読み込んでデータを取込
        private bool importHhtData(string suishitsuKensaKbn, string localFilePath, SuishitsuKensaIraiDataSet.HhtImportDataTable hhtDT)
        {
            // HHTデータファイルを読み込み（TSVファイル）
            TextFieldParser parser = new TextFieldParser(localFilePath, Encoding.GetEncoding("shift_jis"));
            // フィールドが可変長
            parser.TextFieldType = FieldType.Delimited;
            // 区切り文字を設定
            parser.SetDelimiters(DEF_HHT_FILE_SEPARATOR);
            // クォーテーションがあり
            parser.HasFieldsEnclosedInQuotes = true;

            // 先頭行から取込(最終行まで)
            string[] tsvRow;
            while (!parser.EndOfData)
            {
                // 1行取得
                tsvRow = parser.ReadFields();
                Debug.WriteLine(string.Format("---"));
                for (int i = 0; i < tsvRow.Length; i++)
                {
                    Debug.WriteLine(string.Format("tsvRow[{0}]=[{1}]", i, tsvRow[i]));
                }
                SuishitsuKensaIraiDataSet.HhtImportRow newRow = hhtDT.NewHhtImportRow();
                // バーコード番号
                newRow.BarcodeNo = string.Empty;
                // 検体番号
                newRow.KentaiNo = string.Empty;
                // 支所コード
                newRow.ShishoCd = string.Empty;
                // 浄化槽台帳保健所コード
                newRow.JokasoHokenjoCd = string.Empty;
                // 浄化槽台帳年度
                newRow.JokasoTorokuNendo = string.Empty;
                // 浄化槽台帳連番
                newRow.JokasoRenban = string.Empty;
                // 検査依頼法定区分
                newRow.KensaIraiHoteiKbn = string.Empty;
                // 検査依頼保健所CD
                newRow.KensaIraiHokenjoCd = string.Empty;
                // 検査依頼依頼年度
                newRow.KensaIraiNendo = string.Empty;
                // 検査依頼連番
                newRow.KensaIraiRenban = string.Empty;
                // 枝番
                newRow.Edaban = string.Empty;
                // 取込状況フラグ
                newRow.TorikomiJyokyoFlg = "0";

                if ((suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei) || (suishitsuKensaKbn == SuishitsuKensaKbn.SuishitsuKensa))
                {
                    // 計量証明 OR 水質検査

                    // バーコード番号
                    newRow.BarcodeNo = tsvRow[4];
                    // 検体番号
                    newRow.KentaiNo = tsvRow[5].Trim().PadLeft(6, '0');

                    if (newRow.BarcodeNo.Length == 10)
                    {
                        // 旧フォーマット

                        // 設置者区分(バーコードの 2桁目から 1文字)
                        newRow.JokasoSetchishaKbn = newRow.BarcodeNo.Substring(1, 1);
                        // 設置者コード(バーコードの 3桁目から 7文字)
                        newRow.JokasoSetchishaCd = newRow.BarcodeNo.Substring(2, 7);
                        // 枝番(バーコードの 10桁目から 1文字)
                        newRow.Edaban = newRow.BarcodeNo.Substring(9, 1);

                        // 設置者区分と設置者コードから浄化槽台帳マスタ情報を取得
                        // データ検索④
                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable jokasoDaichoMstDT =
                            Common.Common.GetJokasoDaichoMstByJokasoSetchisha(newRow.JokasoSetchishaKbn, newRow.JokasoSetchishaCd);
                        if (jokasoDaichoMstDT.Rows.Count > 0)
                        {
                            JokasoDaichoMstDataSet.JokasoDaichoMstRow row = (JokasoDaichoMstDataSet.JokasoDaichoMstRow)jokasoDaichoMstDT.Rows[0];
                            // 浄化槽台帳保健所コード
                            newRow.JokasoHokenjoCd = row.JokasoHokenjoCd;
                            // 浄化槽台帳年度
                            newRow.JokasoTorokuNendo = row.JokasoTorokuNendo;
                            // 浄化槽台帳連番
                            newRow.JokasoRenban = row.JokasoRenban;
                        }
                        else
                        {
                            // 取込状況フラグ
                            // 該当の浄化槽台帳なし
                            newRow.TorikomiJyokyoFlg = "1";
                        }
                    }
                    else if (newRow.BarcodeNo.Length == 14)
                    {
                        // 新フォーマット

                        // 支所コード(バーコードの 2桁目から 1文字)
                        newRow.ShishoCd = newRow.BarcodeNo.Substring(1, 1);
                        // 検査依頼法定区分(バーコードの 3桁目から 2文字)
                        newRow.JokasoHokenjoCd = newRow.BarcodeNo.Substring(2, 2);
                        // 検査依頼保健所CD(バーコードの 5桁目から 4文字)
                        newRow.JokasoTorokuNendo = newRow.BarcodeNo.Substring(4, 4);
                        // 検査依頼依頼年度(バーコードの 9桁目から 5文字)
                        newRow.JokasoRenban = newRow.BarcodeNo.Substring(8, 5);
                        // 枝番(バーコードの 14桁目から 1文字)
                        newRow.Edaban = newRow.BarcodeNo.Substring(13, 1);
                    }
                }
                else
                {
                    // 外観用

                    // バーコード番号
                    newRow.BarcodeNo = tsvRow[4];
                    // 検体番号
                    newRow.KentaiNo = tsvRow[5].Trim().PadLeft(6, '0');

                    // バーコード番号が13桁のみセット
                    if (newRow.BarcodeNo.Length == 13)
                    {
                        // 検査依頼法定区分(バーコードの 1桁目から 1文字)
                        newRow.KensaIraiHoteiKbn = newRow.BarcodeNo.Substring(0, 1);
                        // 検査依頼保健所CD(バーコードの 2桁目から 2文字)
                        newRow.KensaIraiHokenjoCd = newRow.BarcodeNo.Substring(1, 2);
                        // 検査依頼依頼年度(バーコードの 4桁目から 4文字)
                        newRow.KensaIraiNendo = newRow.BarcodeNo.Substring(3, 4);
                        // 検査依頼連番(バーコードの 8桁目から 6文字)
                        newRow.KensaIraiRenban = newRow.BarcodeNo.Substring(7, 6);
                    }
                }

                DataRow[] checkRows = hhtDT.Select(string.Format("KentaiNo = '{0}'", newRow.KentaiNo));
                if (checkRows.Length > 0)
                {
                    // 取込状況フラグ
                    // 重複行有
                    newRow.TorikomiJyokyoFlg = "2";
                }

                // 行追加
                hhtDT.AddHhtImportRow(newRow);
            }
            parser.Close();

            return true;
        }
        #endregion

        #region setDataGridViewFromImportHhtData
        // 取得したデータを一覧に表示
        private bool setDataGridViewFromImportHhtData(string suishitsuKensaKbn, SuishitsuKensaIraiDataSet.HhtImportDataTable hhtDT)
        {
            // 列が自動的に作成されないようにする
            kensaUketsukeListDataGridView.AutoGenerateColumns = false;

            // 外観検査地区取得
            string gaikanCheckChiku = Boundary.Common.Common.GaikanKensaChikuHantei(iraiNendoTextBox.Text.Trim());

            // DataTableクリア
            SuishitsuKensaIraiDataSet.UketsukeImportListDataTable impDT = new SuishitsuKensaIraiDataSet.UketsukeImportListDataTable();
            impDT.Clear();

            foreach (SuishitsuKensaIraiDataSet.HhtImportRow hhtRow in hhtDT)
            {
                SuishitsuKensaIraiDataSet.UketsukeImportListRow impRow = impDT.NewUketsukeImportListRow();

                if ((suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei) || (suishitsuKensaKbn == SuishitsuKensaKbn.SuishitsuKensa))
                {
                    // 計量証明 OR 水質検査

                    if (suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei)
                    {
                        // 計量証明

                        // 依頼年度、支所コード、検体番号で同一の検査台帳が登録済か確認
                        KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable kensaDaichoDT =
                            Common.Common.GetKensaDaicho9joHdrTblByKey(iraiNendoTextBox.Text.Trim(), shishoComboBox.SelectedValue.ToString(), hhtRow.KentaiNo);
                        if (kensaDaichoDT.Rows.Count == 0)
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = true;
                            // 登録済フラグ（未登録）
                            impRow.TorokusumiFlg = "0";
                            // 取込区分（正常）
                            impRow.ImportKbn = HhtImportKbn.Success;
                            // 取込メッセージ（正常）
                            impRow.ImportMessage = string.Empty;
                        }
                        else
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = false;
                            // 登録済フラグ（登録済）
                            impRow.TorokusumiFlg = "1";
                            // 取込区分（重複）
                            impRow.ImportKbn = HhtImportKbn.KeyDuplicateErr;
                            // 取込メッセージ（重複）
                            impRow.ImportMessage = string.Format("既に登録済の検体番号の情報が存在します。検体番号:[{0}]", hhtRow.KentaiNo);
                        }

                        if (impRow.ImportKbn == HhtImportKbn.Success)
                        {
                            // 旧フォーマット取込時の設置者コードに該当する浄化槽台帳なしの場合
                            if (hhtRow.TorikomiJyokyoFlg == "1")
                            {
                                // 更新フラグ
                                impRow.KoshinFlg = false;
                                // 取込区分（設置者コードに該当する浄化槽台帳なし）
                                impRow.ImportKbn = HhtImportKbn.NotFoundJokasoDaicho;
                                // 取込メッセージ（設置者コードに該当する浄化槽台帳なし）
                                impRow.ImportMessage = string.Format("該当する浄化槽台帳マスタが存在しません。設置者区分:[{0}], 設置者コード:[{1}]", hhtRow.JokasoSetchishaKbn, hhtRow.JokasoSetchishaCd);
                            }
                            // 旧フォーマット取込時の重複行ありの場合
                            else if (hhtRow.TorikomiJyokyoFlg == "2")
                            {
                                // 更新フラグ
                                impRow.KoshinFlg = false;
                                // 取込区分（重複行有）
                                impRow.ImportKbn = HhtImportKbn.ListDuplicateErr;
                                // 取込メッセージ（重複行有）
                                impRow.ImportMessage = string.Format("同一の検体番号が取込ファイル内に既に存在します。検体番号:[{0}]", hhtRow.KentaiNo);
                            }
                        }
                    }
                    else
                    {
                        // 水質検査

                        // 検査区分(2)、依頼年度、支所コード、検体番号で同一の検査台帳が登録済か確認
                        KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable kensaDaichoDT =
                            Common.Common.GetKensaDaicho11joHdrTblByKey("2", iraiNendoTextBox.Text.Trim(), shishoComboBox.SelectedValue.ToString(), hhtRow.KentaiNo);
                        if (kensaDaichoDT.Rows.Count == 0)
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = true;
                            // 登録済フラグ（未登録）
                            impRow.TorokusumiFlg = "0";
                            // 取込区分（正常）
                            impRow.ImportKbn = HhtImportKbn.Success;
                        }
                        else
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = false;
                            // 登録済フラグ（登録済）
                            impRow.TorokusumiFlg = "1";
                            // 取込区分（重複）
                            impRow.ImportKbn = HhtImportKbn.KeyDuplicateErr;
                            // 取込メッセージ（重複）
                            impRow.ImportMessage = string.Format("既に登録済の検体番号の情報が存在します。検体番号:[{0}]", hhtRow.KentaiNo);
                        }

                        if (impRow.ImportKbn == HhtImportKbn.Success)
                        {
                            // 重複行ありの場合
                            if (hhtRow.TorikomiJyokyoFlg == "2")
                            {
                                // 更新フラグ
                                impRow.KoshinFlg = false;
                                // 取込区分（重複行有）
                                impRow.ImportKbn = HhtImportKbn.ListDuplicateErr;
                                // 取込メッセージ（重複行有）
                                impRow.ImportMessage = string.Format("同一の検体番号が取込ファイル内に既に存在します。検体番号:[{0}]", hhtRow.KentaiNo);
                            }
                        }
                    }
                    // スクリーニング区分
                    impRow.ScreeningKbn = "0";
                    // 検査依頼法定区分
                    impRow.KensaIraiHoteiKbn = hhtRow.KensaIraiHoteiKbn;
                    // 検査依頼保健所CD
                    impRow.KensaIraiHokenjoCd = hhtRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    impRow.KensaIraiNendo = hhtRow.KensaIraiNendo;
                    // 検査依頼連番
                    impRow.KensaIraiRenban = hhtRow.KensaIraiRenban;
                    // 検査依頼番号
                    impRow.KensaIraiNo = Common.Common.CreateKensaIraiNoString(hhtRow.KensaIraiHokenjoCd, hhtRow.KensaIraiNendo, hhtRow.KensaIraiRenban);
                    // 再採水区分
                    impRow.SaisaisuiKbn = "0";
                    // 再採水
                    impRow.SaisaisuiMark = "";
                    // 計量証明検査依頼年度
                    impRow.KeiryoShomeiIraiNendo = string.Empty;
                    // 計量証明支所CD
                    impRow.KeiryoShomeiIraiSishoCd = string.Empty;
                    // 計量証明依頼連番
                    impRow.KeiryoShomeiIraiRenban = string.Empty;
                    // 計量証明依頼番号
                    impRow.KeiryoShomeiIraiNo = string.Empty;
                    // 検体番号
                    impRow.KentaiNo = hhtRow.KentaiNo;
                    // 持込（デフォルト：持込）
                    impRow.MotikomiFlg = true;
                    // 収集
                    impRow.ShushuFlg = false;
                    // 現金（デフォルト：請求）
                    impRow.GenkinFlg = false;
                    // 採水員CD
                    impRow.SaisuiinCd = string.Empty;
                    // 採水員名称
                    impRow.SaisuiinNm = string.Empty;
                    // 浄化槽台帳保健所CD
                    impRow.JokasoDaichoHokenjoCd = string.Empty;
                    // 浄化槽台帳年度
                    impRow.JokasoDaichoNendo = string.Empty;
                    // 浄化槽台帳連番
                    impRow.JokasoDaichoRenban = string.Empty;
                    // 協会番号
                    impRow.KyokaiNo = string.Empty;

                    // バーコードが仮番かどうかのチェック
                    // (バーコードが10桁以上で、仮番が 7,8,9以外の場合)
                    if (!string.IsNullOrEmpty(hhtRow.BarcodeNo) && hhtRow.BarcodeNo.Length >= 10)
                    {
                        if (hhtRow.BarcodeNo.Substring(0, 1) == "7" || hhtRow.BarcodeNo.Substring(0, 1) == "8" || hhtRow.BarcodeNo.Substring(0, 1) == "9")
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = false;
                            // 取込区分（仮番）
                            impRow.ImportKbn = HhtImportKbn.KaribanErr;
                            // 取込メッセージ（仮番）
                            impRow.ImportMessage = string.Format("浄化槽台帳が仮番です。浄化槽台帳を選択してください。バーコード番号:[{0}]", hhtRow.BarcodeNo);
                        }
                        else
                        {
                            // 浄化槽台帳保健所CD
                            impRow.JokasoDaichoHokenjoCd = hhtRow.JokasoHokenjoCd;
                            // 浄化槽台帳年度
                            impRow.JokasoDaichoNendo = hhtRow.JokasoTorokuNendo;
                            // 浄化槽台帳連番
                            impRow.JokasoDaichoRenban = hhtRow.JokasoRenban;
                            // 協会番号
                            impRow.KyokaiNo = Common.Common.CreateKyokaiNoString(hhtRow.JokasoHokenjoCd, hhtRow.JokasoTorokuNendo, hhtRow.JokasoRenban);
                        }
                    }
                    // 設置者名
                    impRow.SettishaNm = string.Empty;
                    // 枝番
                    impRow.Edaban = hhtRow.Edaban;
                    // 検査員CD
                    impRow.KensainCd = string.Empty;
                    // 検査員名称
                    impRow.KensainNm = string.Empty;

                    // 採水日付
                    impRow.SaisuiDt = string.Empty;
                    // 採水時分
                    impRow.SaisuiTime = string.Empty;
                    // 計量証明水温
                    impRow.KeiryoShomeiSuion = 0;
                    // 計量証明気温
                    impRow.KeiryoShomeiKion = 0;
                    // 計量証明セットコード
                    impRow.KeiryoShomeiSetCd = string.Empty;
                    // 計量証明検査料金
                    impRow.KeiryoShomeiKensaRyokin = 0;
                    // 計量証明消費税額
                    impRow.KeiryoShomeiShohizei = 0;
                    // 検査項目枝番
                    impRow.KeiryoShomeiKensakomokuEdaban = string.Empty;

                    if (suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei)
                    {
                        // 計量証明

                        // 検査料金
                        impRow.KensaIraiKensaAmt = 0;
                    }
                    else
                    {
                        // 水質検査

                        // 検査料金
                        impRow.KensaIraiKensaAmt = GetKensaIraiKensaAmt(hhtRow.JokasoHokenjoCd, hhtRow.JokasoTorokuNendo, hhtRow.JokasoRenban);
                    }
                    // 入金額
                    impRow.KensaIraiNyukinzumiAmt = 0;
                    // 保健所非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    impRow.KensaIraiHakkoKbn4 = "0";
                    // 市町村非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    impRow.KensaIraiHakkoKbn5 = "0";
                    // 残留塩素
                    impRow.ZanryuEnso = 0;

                    // 透視度
                    impRow.Toshido = 0;

                    // 外観検査対象
                    impRow.GaikanKensaTaisho = string.Empty;
                    // 外観検査地区割
                    impRow.GaikanKensaChikuwari = string.Empty;

                    if (suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei)
                    {
                        // 計量証明

                        // 検査項目枝番
                        impRow.KeiryoShomeiKensakomokuEdaban = hhtRow.Edaban;

                        if (!string.IsNullOrEmpty(impRow.KeiryoShomeiKensakomokuEdaban))
                        {
                            // 表示用データ取得
                            IGetInsertDataForKeiryoShomeiShosaiALInput shosaiAlIn = new GetInsertDataForKeiryoShomeiShosaiALInput();
                            // 依頼年度 
                            shosaiAlIn.IraiNendo = iraiNendoTextBox.Text.Trim();
                            // 支所コード 
                            shosaiAlIn.ShishoCd = shishoComboBox.SelectedValue.ToString();
                            // 検査受付日付
                            shosaiAlIn.SuishitsuUketsukeDt = uketsukeDataTimePicker.Value.ToString("yyyyMMdd");
                            // 取込結果一覧データ
                            shosaiAlIn.ListRow = impRow;
                            // 検索実行
                            IGetInsertDataForKeiryoShomeiShosaiALOutput shosaiAlOut = new GetInsertDataForKeiryoShomeiShosaiApplicationLogic().Execute(shosaiAlIn);
                            // 結果取得
                            SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable _keiryoShomeiIraiInfo = shosaiAlOut.KeiryoShomeiIraiInfo;
                            SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable _kensaSetPattern = shosaiAlOut.KensaSetPattern;
                            KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable _keiryoShomeiIraiTblDT = shosaiAlOut.KeiryoShomeiIraiTblDT;

                            if (_kensaSetPattern.Rows.Count > 0)
                            {
                                // 選択された検査項目セットに紐づく試験項目を取得
                                IGetSuishitsuShikenKoumokuListALInput kamokuAlIn = new GetSuishitsuShikenKoumokuListALInput();
                                kamokuAlIn.KensaIraiJokasoHokenjoCd = impRow.JokasoDaichoHokenjoCd;
                                kamokuAlIn.KensaIraiJokasoTorokuNendo = impRow.JokasoDaichoNendo;
                                kamokuAlIn.KensaIraiJokasoRenban = impRow.JokasoDaichoRenban;
                                kamokuAlIn.DaichoKensaKomokuEdaban = impRow.KeiryoShomeiKensakomokuEdaban;
                                IGetSuishitsuShikenKoumokuListALOutput kamokuAlOut = new GetSuishitsuShikenKoumokuListApplicationLogic().Execute(kamokuAlIn);

                                // 検査セットコード
                                DataRow[] targetRows = _kensaSetPattern.Select(string.Format("DaichoKensaKomokuEdaban='{0}'", impRow.KeiryoShomeiKensakomokuEdaban));
                                if (targetRows.Length > 0)
                                {
                                    SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternRow targetRow = (SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternRow)targetRows[0];
                                    // 検査セットコード
                                    impRow.KeiryoShomeiSetCd = targetRow.DaichoKensaKomokuSetCd;
                                    // 検査セット名称
                                    impRow.KeiryoShomeiSetNm = targetRow.DaichoKensaSetNm;

                                    // 20150201 sou Start
                                    //// 検査料金
                                    //decimal kensaRyokin = 0;
                                    //// 消費税
                                    //decimal shohizei = 0;
                                    //FukjBizSystem.Application.Utility.KeiryoShomeiUtility.KeiryoshomeiKensaRyokinShukei(
                                    //    shosaiAlIn.SuishitsuUketsukeDt, kamokuAlIn.KensaIraiJokasoHokenjoCd, kamokuAlIn.KensaIraiJokasoTorokuNendo, kamokuAlIn.KensaIraiJokasoRenban, kamokuAlIn.DaichoKensaKomokuEdaban,
                                    //    out kensaRyokin, out shohizei);
                                    //
                                    //// 計量証明検査料金（税抜金額）
                                    //impRow.KeiryoShomeiKensaRyokin = kensaRyokin;
                                    //// 計量証明消費税額（小数以下切捨）
                                    //impRow.KeiryoShomeiShohizei = shohizei;

                                    // 計量証明検査料金（税抜金額）
                                    impRow.KeiryoShomeiKensaRyokin = targetRow.DaichoKensaKomokuKensaAmt;
                                    // 計量証明消費税額（小数以下切捨）
                                    impRow.KeiryoShomeiShohizei = Math.Floor(targetRow.DaichoKensaKomokuKensaAmt 
                                                                * Common.Common.GetSyohizei(Boundary.Common.Common.GetCurrentTimestamp().ToString("yyyyMMdd")));
                                    // 20150201 sou End
                                }
                            }
                        }
                    }
                }
                else
                {
                    // 外観

                    //// 検査区分(3)、依頼年度、支所コード、検体番号で同一の検査台帳が登録済か確認
                    //KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable kensaDaichoDT =
                    //    Common.Common.GetKensaDaicho11joHdrTblByKey("3", iraiNendoTextBox.Text.Trim(), shishoComboBox.SelectedValue.ToString(), hhtRow.KentaiNo);
                    // 検査区分(3)、検査依頼法定区分、検査依頼保健所CD、検査依頼依頼年度、検査依頼連番で同一の検査台帳が登録済か確認
                    KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable kensaDaichoDT =
                        Common.Common.GetKensaDaicho11joHdrTblByKensaKbnKensaIraiNo("3", hhtRow.KensaIraiHoteiKbn, hhtRow.KensaIraiHokenjoCd, hhtRow.KensaIraiNendo, hhtRow.KensaIraiRenban);
                    if (kensaDaichoDT.Rows.Count == 0)
                    {
                        // 更新フラグ
                        impRow.KoshinFlg = true;
                        // 登録済フラグ（未登録）
                        impRow.TorokusumiFlg = "0";
                        // 取込区分（正常）
                        impRow.ImportKbn = HhtImportKbn.Success;
                        // 取込メッセージ（正常）
                        impRow.ImportMessage = string.Empty;
                    }
                    else
                    {
                        // 更新フラグ
                        impRow.KoshinFlg = false;
                        // 登録済フラグ（登録済）
                        impRow.TorokusumiFlg = "1";
                        // 取込区分（重複）
                        impRow.ImportKbn = HhtImportKbn.KeyDuplicateErr;
                        // 取込メッセージ（重複）
                        impRow.ImportMessage = string.Format("既に登録済の検査依頼の情報が存在します。検体番号:[{0}]", hhtRow.KentaiNo);
                    }

                    if (impRow.ImportKbn == HhtImportKbn.Success)
                    {
                        // 重複行ありの場合
                        if (hhtRow.TorikomiJyokyoFlg == "2")
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = false;
                            // 取込区分（重複行有）
                            impRow.ImportKbn = HhtImportKbn.ListDuplicateErr;
                            // 取込メッセージ（重複行有）
                            impRow.ImportMessage = string.Format("同一の検体番号が取込ファイル内に既に存在します。検体番号:[{0}]", hhtRow.KentaiNo);
                        }
                    }
                    // スクリーニング区分
                    impRow.ScreeningKbn = "0";
                    // 検査依頼法定区分
                    impRow.KensaIraiHoteiKbn = hhtRow.KensaIraiHoteiKbn;
                    // 検査依頼保健所CD
                    impRow.KensaIraiHokenjoCd = hhtRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    impRow.KensaIraiNendo = hhtRow.KensaIraiNendo;
                    // 検査依頼連番
                    impRow.KensaIraiRenban = hhtRow.KensaIraiRenban;
                    // 検査依頼番号
                    impRow.KensaIraiNo = Common.Common.CreateKensaIraiNoString(hhtRow.KensaIraiHokenjoCd, hhtRow.KensaIraiNendo, hhtRow.KensaIraiRenban);
                    // 再採水区分
                    impRow.SaisaisuiKbn = "0";
                    // 再採水
                    impRow.SaisaisuiMark = "";
                    // 計量証明検査依頼年度
                    impRow.KeiryoShomeiIraiNendo = string.Empty;
                    // 計量証明支所CD
                    impRow.KeiryoShomeiIraiSishoCd = string.Empty;
                    // 計量証明依頼連番
                    impRow.KeiryoShomeiIraiRenban = string.Empty;
                    // 計量証明依頼番号
                    impRow.KeiryoShomeiIraiNo = string.Empty;
                    // 検体番号
                    impRow.KentaiNo = hhtRow.KentaiNo;
                    // 持込
                    impRow.MotikomiFlg = false;
                    // 収集
                    impRow.ShushuFlg = false;
                    // 現金
                    impRow.GenkinFlg = false;
                    // 採水員CD
                    impRow.SaisuiinCd = string.Empty;
                    // 採水員名称
                    impRow.SaisuiinNm = string.Empty;
                    // 浄化槽台帳保健所CD
                    impRow.JokasoDaichoHokenjoCd = hhtRow.JokasoHokenjoCd;
                    // 浄化槽台帳年度
                    impRow.JokasoDaichoNendo = hhtRow.JokasoTorokuNendo;
                    // 浄化槽台帳連番
                    impRow.JokasoDaichoRenban = hhtRow.JokasoRenban;
                    // 協会番号
                    impRow.KyokaiNo = Common.Common.CreateKyokaiNoString(impRow.JokasoDaichoHokenjoCd, impRow.JokasoDaichoNendo, impRow.JokasoDaichoRenban);
                    // 残塩
                    impRow.ZanryuEnso = 0;
                    // 設置者名
                    impRow.SettishaNm = string.Empty;
                    // 枝番
                    impRow.Edaban = hhtRow.Edaban;
                    // 検査員CD
                    impRow.KensainCd = string.Empty;
                    // 検査員名称
                    impRow.KensainNm = string.Empty;

                    // 採水日付
                    impRow.SaisuiDt = string.Empty;
                    // 採水時分
                    impRow.SaisuiTime = string.Empty;
                    // 計量証明水温
                    impRow.KeiryoShomeiSuion = 0;
                    // 計量証明気温
                    impRow.KeiryoShomeiKion = 0;
                    // 計量証明セットコード
                    impRow.KeiryoShomeiSetCd = string.Empty;
                    // 計量証明検査料金
                    impRow.KeiryoShomeiKensaRyokin = 0;
                    // 計量証明消費税額
                    impRow.KeiryoShomeiShohizei = 0;
                    // 検査項目枝番
                    impRow.KeiryoShomeiKensakomokuEdaban = string.Empty;

                    // 検査料金
                    impRow.KensaIraiKensaAmt = 0;
                    // 入金額
                    impRow.KensaIraiNyukinzumiAmt = 0;
                    // 保健所非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    impRow.KensaIraiHakkoKbn4 = "0";
                    // 市町村非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                    impRow.KensaIraiHakkoKbn5 = "0";
                    // 残留塩素
                    impRow.ZanryuEnso = 0;

                    // 透視度
                    impRow.Toshido = 0;

                    // 外観検査対象
                    impRow.GaikanKensaTaisho = string.Empty;
                    // 外観検査地区割
                    impRow.GaikanKensaChikuwari = string.Empty;

                    // 検査依頼番号から検査依頼テーブル情報を取得
                    KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT =
                        Common.Common.GetKensaIraiTblByKey(hhtRow.KensaIraiHoteiKbn, hhtRow.KensaIraiHokenjoCd, hhtRow.KensaIraiNendo, hhtRow.KensaIraiRenban);
                    if (kensaIraiDT.Rows.Count > 0)
                    {
                        KensaIraiTblDataSet.KensaIraiTblRow row = (KensaIraiTblDataSet.KensaIraiTblRow)kensaIraiDT.Rows[0];
                        // スクリーニング区分
                        //impRow.ScreeningKbn = row.IsKensaIraiScreeningKbnNull() ? "0" : row.KensaIraiScreeningKbn;
                        if (row.IsKensaIraiScreeningKbnNull() || string.IsNullOrEmpty(row.KensaIraiScreeningKbn))
                        {
                            impRow.ScreeningKbn = "0";
                        }
                        else
                        {
                            impRow.ScreeningKbn = row.KensaIraiScreeningKbn.Trim();
                        }
                        // スクリーニング区分が0の場合
                        if (impRow.ScreeningKbn == "0")
                        {
                            // 再採水区分：初回
                            impRow.SaisaisuiKbn = "0";
                            // 再採水
                            impRow.SaisaisuiMark = "";
                        }
                        else
                        {
                            // 再採水区分：再採水
                            impRow.SaisaisuiKbn = "1";
                            // 再採水
                            impRow.SaisaisuiMark = "○";
                        }
                        // 浄化槽台帳保健所CD
                        impRow.JokasoDaichoHokenjoCd = row.KensaIraiJokasoHokenjoCd;
                        // 浄化槽台帳年度
                        impRow.JokasoDaichoNendo = row.KensaIraiJokasoTorokuNendo;
                        // 浄化槽台帳連番
                        impRow.JokasoDaichoRenban = row.KensaIraiJokasoRenban;
                        // 協会番号
                        impRow.KyokaiNo = Common.Common.CreateKyokaiNoString(impRow.JokasoDaichoHokenjoCd, impRow.JokasoDaichoNendo, impRow.JokasoDaichoRenban);
                        // 検査員コード
                        impRow.KensainCd = row.IsKensaIraiKensaTantoshaCdNull() ? string.Empty : row.KensaIraiKensaTantoshaCd;
                        if (!string.IsNullOrEmpty(impRow.KensainCd))
                        {
                            // 職員マスタより職員名取得
                            ShokuinMstDataSet.ShokuinMstDataTable shokuinDT = MstUtility.ShokuinMst.GetShokuinMstByShokuinCd(impRow.KensainCd);
                            if (shokuinDT.Rows.Count > 0)
                            {
                                // 検査員名称に職員名をセット
                                impRow.KensainNm = shokuinDT[0].ShokuinNm;
                            }
                        }

                        // 検査依頼番号から検査結果テーブル情報を取得
                        KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT =
                            Common.Common.GetKensaKekkaTblByKey(hhtRow.KensaIraiHoteiKbn, hhtRow.KensaIraiHokenjoCd, hhtRow.KensaIraiNendo, hhtRow.KensaIraiRenban);
                        if (kensaKekkaDT.Rows.Count > 0)
                        {
                            KensaKekkaTblDataSet.KensaKekkaTblRow kekkaRow = (KensaKekkaTblDataSet.KensaKekkaTblRow)kensaKekkaDT.Rows[0];

                            if (impRow.ImportKbn == HhtImportKbn.Success)
                            {
                                int statusKbnNum = 0;
                                int.TryParse(row.KensaIraiStatusKbn, out statusKbnNum);
                                // ステータス区分、検査状況を判定して受付可能かのチェック
                                if (kekkaRow.KensaKekkaKensaJoukyouKbn == "003" && row.KensaIraiStatusKbn == "40")
                                {
                                    // 検査状況=003完了、ステータス=40は受付可能
                                    // 受付可能
                                }
                                else if ((kekkaRow.KensaKekkaKensaJoukyouKbn == "002" || kekkaRow.KensaKekkaKensaJoukyouKbn == "004") && statusKbnNum <= 40)
                                {
                                    // 検査状況=002未完了・004中断、ステータス<=40は受付可能
                                    // 受付可能
                                }
                                else
                                {
                                    // 以外は受付不可

                                    // 更新フラグ
                                    impRow.KoshinFlg = false;
                                    // 取込区分（ステータス区分エラー）
                                    impRow.ImportKbn = HhtImportKbn.StatusErr;
                                    // 取込メッセージ（ステータス区分エラー）
                                    impRow.ImportMessage = string.Format("対象の検査依頼の検査状況、ステータスが取込対象外です。検査状況:[{0}]  ステータス区分:[{1}]", kekkaRow.KensaKekkaKensaJoukyouKbn, row.KensaIraiStatusKbn);
                                }
                            }
                        }
                        else
                        {
                            // 検査結果なし（取込不可）

                            // 更新フラグ
                            impRow.KoshinFlg = false;
                            // 取込区分（検査依頼なし）
                            impRow.ImportKbn = HhtImportKbn.NotFoundKensaIrai;
                            // 取込メッセージ（ステータス区分エラー）
                            impRow.ImportMessage = string.Format("検査結果テーブルに対象のレコードが存在しません。\n検査依頼番号：[{0}]", impRow.KensaIraiNo);
                        }
                    }
                    else
                    {
                        // 検査依頼なし（取込不可）

                        // 更新フラグ
                        impRow.KoshinFlg = false;
                        // 取込区分（（検査依頼なし）
                        impRow.ImportKbn = HhtImportKbn.NotFoundKensaIrai;
                        // 取込メッセージ（ステータス区分エラー）
                        impRow.ImportMessage = string.Format("検査依頼テーブルに対象のレコードが存在しません。\n検査依頼番号：[{0}]", impRow.KensaIraiNo);
                    }
                }

                // 浄化槽台帳マスタを取得して、浄化槽状態区分のチェック
                JokasoDaichoMstDataSet.JokasoDaichoMstDataTable jokasoDaichoMstDT =
                    Common.Common.GetJokasoDaichoMstByKey(impRow.JokasoDaichoHokenjoCd, impRow.JokasoDaichoNendo, impRow.JokasoDaichoRenban);
                if (jokasoDaichoMstDT.Rows.Count > 0)
                {
                    JokasoDaichoMstDataSet.JokasoDaichoMstRow jokasoDaichoMstRow = jokasoDaichoMstDT[0];
                    if (!jokasoDaichoMstRow.IsJokasoJotaiKbnNull() && jokasoDaichoMstRow.JokasoJotaiKbn == "2")
                    {
                        // 廃止の場合はワーニング
                        // 取込区分（廃止）
                        impRow.ImportKbn = HhtImportKbn.HaishiWar;
                        // 取込メッセージ（廃止）
                        impRow.ImportMessage = string.Format("浄化槽台帳マスタの浄化槽状態が廃止(2)の浄化槽です。浄化槽台帳番号:[{0}]", impRow.KyokaiNo);
                    }

                    if (suishitsuKensaKbn == SuishitsuKensaKbn.SuishitsuKensa)
                    {
                        if (jokasoDaichoMstRow.JokasoShoriTaishoJinin >= 51)
                        {
                            // 検査区分が「水質検査」 かつ 処理対象人員が51以上の場合
                            // 「外観検査の対象が含まれています」
                            // 更新フラグ
//                            impRow.KoshinFlg = false;
                            // 外観検査対象
                            impRow.GaikanKensaTaisho = GaikanKensaTaishoNmKbn.Taisho;
                            // 外観検査地区割
                            impRow.GaikanKensaChikuwari = "51人槽以上";
                        }
                        else if (gaikanCheckChiku == jokasoDaichoMstRow.JokasoGaikanTikuwariKbn)
                        {
                            // 検査区分が「水質検査」 かつ 当年度が外観検査対象の地区が含まれている場合
                            // 「外観検査の対象が含まれています」
                            // 更新フラグ
//                            impRow.KoshinFlg = false;
                            // 外観検査対象
                            impRow.GaikanKensaTaisho = GaikanKensaTaishoNmKbn.Taisho;
                            // 外観検査地区割（地区割記号＋"：外観検査年"）
                            impRow.GaikanKensaChikuwari = jokasoDaichoMstRow.JokasoGaikanTikuwariKbn + "：外観検査年";
                        }
                        else if (gaikanCheckChiku != jokasoDaichoMstRow.JokasoGaikanTikuwariKbn)
                        {
                            // 検査区分が「水質検査」 かつ 当年度が外観検査対象の地区では無い地区が含まれている場合（通常）
                            // 更新フラグ
//                            impRow.KoshinFlg = false;
                            // 外観検査非対象
                            impRow.GaikanKensaTaisho = GaikanKensaTaishoNmKbn.Hitaisho;
                            // 外観検査地区割（地区割記号＋"：水質検査年"）
                            impRow.GaikanKensaChikuwari = jokasoDaichoMstRow.JokasoGaikanTikuwariKbn + "：水質検査年";
                        }
                    }
                    //else if (suishitsuKensaKbn == SuishitsuKensaKbn.GaikanKensa)
                    //{
                    //    if (gaikanCheckChiku != jokasoDaichoMstRow.JokasoGaikanTikuwariKbn)
                    //    {
                    //        // 検査区分が「外観検査」 かつ 当年度が外観検査対象の地区では無い地区が含まれている場合
                    //        // 「外観検査の対象ではない地区が含まれています」
                    //        // 更新フラグ
                    //        impRow.KoshinFlg = false;
                    //        // 取込メッセージ（外観検査非対象）
                    //        impRow.GaikanKensaTaisho = GaikanKensaTaishoNmKbn.Hitaisho;
                    //    }
                    //}

                    // 取込時は設置者名を表示
                    impRow.SettishaNm = jokasoDaichoMstRow.JokasoSetchishaNm;

                }
                else
                {
                    if (!readOnlyHantei(impRow.ImportKbn))
                    {
                        if (suishitsuKensaKbn == SuishitsuKensaKbn.GaikanKensa)
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = false;
                            // 取込区分（設置者コードに該当する浄化槽台帳なし）
                            impRow.ImportKbn = HhtImportKbn.NotFoundKensaIrai;
                            // 取込メッセージ（設置者コードに該当する浄化槽台帳なし）
                            impRow.ImportMessage = string.Format("該当する浄化槽台帳マスタが存在しません。浄化槽台帳番号:[{0}]", impRow.KyokaiNo);
                        }
                        else
                        {
                            // 更新フラグ
                            impRow.KoshinFlg = false;
                            // 取込区分（設置者コードに該当する浄化槽台帳なし）
                            impRow.ImportKbn = HhtImportKbn.NotFoundJokasoDaicho;
                            // 取込メッセージ（設置者コードに該当する浄化槽台帳なし）
                            impRow.ImportMessage = string.Format("該当する浄化槽台帳マスタが存在しません。浄化槽台帳番号:[{0}]", impRow.KyokaiNo);
                        }
                    }
                }

                // 行追加
                impDT.AddUketsukeImportListRow(impRow);
            }

            // 一覧に設定
            kensaUketsukeListDataGridView.DataSource = impDT;
            // 一覧の表示設定
            settingChengeKensaUketsukeList();

            if (impDT.Count <= 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            return true;
        }
        #endregion

        #region setSuishitsuKensaKbn
        // 選択中の水質検査区分から各内部変数を設定
        private void setSuishitsuKensaKbn()
        {
            // 計量証明
            if (keiryoShomeiRadioButton.Checked == true)
            {
                suishitsuKensaKbn.Text = SuishitsuKensaKbn.KeiryoShomei;
                suishitsuKensaKbnLabel.Text = "計量証明";
            }
            // 水質検査
            if (suishitsuKensaRadioButton.Checked == true)
            {
                suishitsuKensaKbn.Text = SuishitsuKensaKbn.SuishitsuKensa;
                suishitsuKensaKbnLabel.Text = "水質検査";
            }
            // 外観検査
            if (gaikanKensaRadioButton.Checked == true)
            {
                suishitsuKensaKbn.Text = SuishitsuKensaKbn.GaikanKensa;
                suishitsuKensaKbnLabel.Text = "外観検査";
            }
        }
        #endregion

        #region IsValidData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidData
        /// <summary>
        /// 関連チェック
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松        新規作成
        /// 2015/01/29  宗          支所の入力確認を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidData()
        {
            StringBuilder errMsg = new StringBuilder();

            // 年度
            if (string.IsNullOrEmpty(iraiNendoTextBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：年度が入力されていません。");
            }

            // 支所
            if (string.IsNullOrEmpty(shishoComboBox.Text.Trim()))
            {
                errMsg.AppendLine("必須項目：支所が入力されていません。");
            }

            // 依頼番号（開始＆終了）
            if (!string.IsNullOrEmpty(iraiNoFromTextBox.Text.Trim()) && !string.IsNullOrEmpty(iraiNoToTextBox.Text.Trim())
                && Convert.ToInt32(iraiNoFromTextBox.Text.Trim()) > Convert.ToInt32(iraiNoToTextBox.Text.Trim()))
            {
                errMsg.AppendLine("範囲指定が正しくありません。検体番号の大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region GetSuishitsuNippoCheckCnt
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSuishitsuNippoCheckCnt
        /// <summary>
        /// 日報の確認状況取得
        /// データ検索⑬
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private int GetSuishitsuNippoCheckCnt()
        {
            IGetSuishitsuNippoCheckInfoALInput alInput = new GetSuishitsuNippoCheckInfoALInput();
            // 支所コード
            alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();
            // 水質検査受付日(yyyyMMdd)
            alInput.SuishistsuUketsukeDt = uketsukeDataTimePicker.Value.ToString("yyyyMMdd");
            // 検索実行
            IGetSuishitsuNippoCheckInfoALOutput alOutput = new GetSuishitsuNippoCheckInfoApplicationLogic().Execute(alInput);
            return alOutput.CheckCnt;
        }
        #endregion

        #region setListColmunVisible
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： setListColmunVisible
        /// <summary>
        /// 一覧のカラムの制御
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　小松        新規作成
        /// 2015/01/11  小松　　　　外観検査の時の受付一覧から浄化槽検索ボタンを削除
        /// 2015/01/21  小松　　　　外観検査時は、受付一覧の現金列は非表示
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setListColmunVisible()
        {
            //kensaUketsukeListDataGridView.FirstDisplayedScrollingColumnIndex = 0;
            if (gamenMode.Text == "2")
            {
                // 登録
                kensaUketsukeListDataGridView.Columns[ImportMessageCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[jokasoDaichoSearchCol.Index].Visible = true;
            }
            else
            {
                // 未編集、更新
                kensaUketsukeListDataGridView.Columns[ImportMessageCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[jokasoDaichoSearchCol.Index].Visible = false;
            }

            // 計量証明
            if (keiryoShomeiRadioButton.Checked == true)
            {
                kensaUketsukeListDataGridView.Columns[KoshinFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[torokusumiFlgCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[screeningKbnCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[kensaIraiNoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisaisuiKbnCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisaisuiMarkCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[keiryoShomeiIraiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[kentaiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[motikomiFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[shushuFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[genkinFlgCol.Index].Visible = true;
                // 20150128 sou Start 要望No214,215,216の対応
                //kensaUketsukeListDataGridView.Columns[saisuiinCdCol.Index].Visible = true;
                //kensaUketsukeListDataGridView.Columns[saisuiinNmCol.Index].Visible = true;
                //kensaUketsukeListDataGridView.Columns[saisuiinSearchCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[saisuiinCdCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisuiinNmCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisuiinSearchCol.Index].Visible = false;
                // 20150128 sou End
                kensaUketsukeListDataGridView.Columns[KensainCdCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KensainNmCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[kyokaiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[zanryuEnsoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[settishaNmCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[SaisuiDtCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[SaisuiTimeCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSuionCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKionCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSetCdCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSetNmCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKensaRyokinCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiShohizeiCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKensakomokuEdabanCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KensaAmtCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[NyukinzumiAmtCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[HakkoKbn4Col.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[HakkoKbn5Col.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[ToshidoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[GaikanKensaTaishoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[GaikanKensaChikuwariCol.Index].Visible = false;
            }
            // 水質検査
            else if (suishitsuKensaRadioButton.Checked == true)
            {
                kensaUketsukeListDataGridView.Columns[KoshinFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[torokusumiFlgCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[screeningKbnCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[kensaIraiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[saisaisuiKbnCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisaisuiMarkCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[keiryoShomeiIraiNoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[kentaiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[motikomiFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[shushuFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[genkinFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[saisuiinCdCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[saisuiinNmCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[saisuiinSearchCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KensainCdCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KensainNmCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[kyokaiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[zanryuEnsoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[settishaNmCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[SaisuiDtCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[SaisuiTimeCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSuionCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKionCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSetCdCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSetNmCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKensaRyokinCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiShohizeiCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKensakomokuEdabanCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KensaAmtCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[NyukinzumiAmtCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[HakkoKbn4Col.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[HakkoKbn5Col.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[ToshidoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[GaikanKensaTaishoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[GaikanKensaChikuwariCol.Index].Visible = true;
            }
            // 外観検査
            else if (gaikanKensaRadioButton.Checked == true)
            {
                kensaUketsukeListDataGridView.Columns[KoshinFlgCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[torokusumiFlgCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[screeningKbnCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[kensaIraiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[saisaisuiKbnCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisaisuiMarkCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[keiryoShomeiIraiNoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[kentaiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[motikomiFlgCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[shushuFlgCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[genkinFlgCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisuiinCdCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisuiinNmCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[saisuiinSearchCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KensainCdCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[KensainNmCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[kyokaiNoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[zanryuEnsoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[settishaNmCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[SaisuiDtCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[SaisuiTimeCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSuionCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKionCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSetCdCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiSetNmCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKensaRyokinCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiShohizeiCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KeiryoShomeiKensakomokuEdabanCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[KensaAmtCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[NyukinzumiAmtCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[HakkoKbn4Col.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[HakkoKbn5Col.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[ToshidoCol.Index].Visible = true;
                kensaUketsukeListDataGridView.Columns[GaikanKensaTaishoCol.Index].Visible = false;
                kensaUketsukeListDataGridView.Columns[GaikanKensaChikuwariCol.Index].Visible = false;
                // 常に非表示
                kensaUketsukeListDataGridView.Columns[jokasoDaichoSearchCol.Index].Visible = false;
            }
            kensaUketsukeListDataGridView.Columns[ImportKbnCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[jokasoDaichoHokenjoCdCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[jokasoDaichoNendoCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[jokasoDaichoRenbanCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[kensaIraiHoteiKbnCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[kensaIraiHokenjoCdCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[kensaIraiNendoCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[kensaIraiRenbanCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[keiryoShomeiIraiNendoCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[keiryoShomeiIraiSishoCdCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[keiryoShomeiIraiRenbanCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[edabanCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[KeiryoShomeiIraiUpdateDtCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[KensaIraiUpdateDtCol.Index].Visible = false;
            kensaUketsukeListDataGridView.Columns[KensaDaichoDtlUpdateDtCol.Index].Visible = false;
        }
        #endregion

        #region GetKensaIraiKensaAmt
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaIraiKensaAmt
        /// <summary>
        /// 検査依頼の検査料金取得
        /// データ検索⑦
        /// </summary>
        /// <param name="jokasoHokenjoCd">浄化槽台帳保健所CD</param>
        /// <param name="jokasoTorokuNendo">浄化槽台帳登録年度</param>
        /// <param name="jokasoRenban">浄化槽台帳連番</param>
        /// <returns>検査料金</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private decimal GetKensaIraiKensaAmt(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban)
        {
            IGetKensaIraiKensaAmtInfoALInput alInput = new GetKensaIraiKensaAmtInfoALInput();
            // 浄化槽台帳保健所コード
            alInput.JokasoHokenjoCd = jokasoHokenjoCd;
            // 浄化槽台帳登録年度
            alInput.JokasoTorokuNendo = jokasoTorokuNendo;
            // 浄化槽台帳連番
            alInput.JokasoRenban = jokasoRenban;
            // 検索実行
            IGetKensaIraiKensaAmtInfoALOutput alOutput = new GetKensaIraiKensaAmtInfoApplicationLogic().Execute(alInput);
            // 検査料金
            return alOutput.KensaIraiKensaAmt;
        }
        #endregion

        #region settingChengeKensaUketsukeList
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： settingChengeKensaUketsukeList
        /// <summary>
        /// 一覧表示後の表示設定
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26  小松　　    新規作成
        /// 2015/01/10  宗  　　    行単位の表示設定追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void settingChengeKensaUketsukeList()
        {
            foreach (DataGridViewRow row in kensaUketsukeListDataGridView.Rows)
            {
                if ((bool)row.Cells[motikomiFlgCol.Index].Value)
                {
                    row.Cells[motikomiFlgCol.Index].ReadOnly = true;
                }
                if ((bool)row.Cells[shushuFlgCol.Index].Value)
                {
                    row.Cells[shushuFlgCol.Index].ReadOnly = true;
                }

                if (row.Cells[ImportKbnCol.Index].Value.ToString() == HhtImportKbn.KeyDuplicateErr)
                {
                    // 表示のみ
                    row.Cells[KoshinFlgCol.Index].ReadOnly = true;
                    // 背景赤
                    row.DefaultCellStyle.BackColor = Color.Red;
                    // 表示のみ(行単位)
                    row.ReadOnly = readOnlyHantei(row.Cells[ImportKbnCol.Index].Value.ToString());
                }
                else if (row.Cells[ImportKbnCol.Index].Value.ToString() == HhtImportKbn.ListDuplicateErr)
                {
                    // 背景ピンク
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                    // 表示のみ
                    row.Cells[KoshinFlgCol.Index].ReadOnly = true;
                    // 表示のみ(行単位)
                    row.ReadOnly = readOnlyHantei(row.Cells[ImportKbnCol.Index].Value.ToString());
                }
                else if (row.Cells[ImportKbnCol.Index].Value.ToString() == HhtImportKbn.StatusErr)
                {
                    // 背景ピンク
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                    // 表示のみ
                    row.Cells[KoshinFlgCol.Index].ReadOnly = true;
                    // 表示のみ(行単位)
                    row.ReadOnly = readOnlyHantei(row.Cells[ImportKbnCol.Index].Value.ToString());
                }
                else if (row.Cells[ImportKbnCol.Index].Value.ToString() == HhtImportKbn.NotFoundKensaIrai)
                {
                    // 背景ピンク
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                    // 表示のみ
                    row.Cells[KoshinFlgCol.Index].ReadOnly = true;
                    // 表示のみ(行単位)
                    row.ReadOnly = readOnlyHantei(row.Cells[ImportKbnCol.Index].Value.ToString());
                }
                else if (row.Cells[ImportKbnCol.Index].Value.ToString() == HhtImportKbn.NotFoundJokasoDaicho)
                {
                    // 背景黄色
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    // 表示のみ(行単位)
                    row.ReadOnly = readOnlyHantei(row.Cells[ImportKbnCol.Index].Value.ToString());
                }
                else
                {
                    // 正常；通常
                    row.DefaultCellStyle.BackColor = Color.White;
                    // 表示のみ(行単位)
                    row.ReadOnly = readOnlyHantei(row.Cells[ImportKbnCol.Index].Value.ToString());
                }
            }
        }
        #endregion

        #region readOnlyHantei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： readOnlyHantei
        /// <summary>
        /// 行単位の表示設定切替判定
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/10  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool readOnlyHantei(string hhtImportKbn)
        {
            bool readOnly = true;

            if ((hhtImportKbn == HhtImportKbn.KeyDuplicateErr)
                || (hhtImportKbn == HhtImportKbn.ListDuplicateErr)
                || (hhtImportKbn == HhtImportKbn.NotFoundKensaIrai)
                || (hhtImportKbn == HhtImportKbn.StatusErr))
            {
                // 表示のみ
                readOnly = true;
            }
            else
            {
                // 入力可
                readOnly = false;
            }

            return readOnly;
        }
        #endregion

        #region GenkinNyukinFormEnd(Form childForm)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GenkinNyukinFormEnd
        /// <summary>
        /// 現金入金終了時
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/12  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GenkinNyukinFormEnd(Form childForm)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 再検索を行う
                DoSearch();

                if (kensaUketsukeListDataGridView.Rows.Count == 0)
                {
                    // 初期モード
                    gamenMode.Text = GamenMode.Init;
                }
                else
                {
                    // 未編集モード
                    gamenMode.Text = GamenMode.NoEdit;
                }

                // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                setControlProperty();
                // 一覧のカラムの制御
                setListColmunVisible();
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

        #region editInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： editInputButton_Click
        /// <summary>
        /// 検査依頼手入力
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗　  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void editInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 登録モードの場合はチェック済みなので再チェックはしない
                if (gamenMode.Text != GamenMode.Insert)
                {
                    // 関連チェック
                    if (!IsValidData())
                    {
                        return;
                    }
                }

                // 選択中の水質検査区分から各内部変数を設定
                setSuishitsuKensaKbn();

                #region HHTデータファイル取得
                // 取込ローカルファイル名
                string localFilePath = string.Empty;
                // ローカルの HHTデータファイル名（フルパス）を取得
                if (!getHhtDataFile(suishitsuKensaKbn.Text, out localFilePath))
                {
                    // エラー
                    return;
                }
                #endregion

                #region HHTデータ用DataTableを別画面(ダイアログ)で編集
                // 手入力
                HhtInputForm dlg = new HhtInputForm(suishitsuKensaKbn.Text, _hhtDT);
                dlg.ShowDialog();

                // キャンセルされた
                if (dlg.DialogResult != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    // 手入力結果を退避
                    _hhtDT = dlg.hhtDT;
                }
                #endregion

                #region 取得したデータを一覧に表示
                // 取得したデータを一覧に表示
                if (!setDataGridViewFromImportHhtData(suishitsuKensaKbn.Text, _hhtDT))
                {
                    // エラー
                    return;
                }
                #endregion

                if (kensaUketsukeListDataGridView.Rows.Count == 0)
                {
                    // 初期モード
                    gamenMode.Text = GamenMode.Init;
                    // 件数表示
                    uketsukeListCountLabel.Text = "0件";
                }
                else
                {
                    // 登録モード
                    gamenMode.Text = GamenMode.Insert;
                    // 画面モードごとのボタンやコントロールの制御（活性・非活性）
                    setControlProperty();
                    // 一覧のカラムの制御
                    setListColmunVisible();
                    // 左上のセルに
                    kensaUketsukeListDataGridView.CurrentCell = kensaUketsukeListDataGridView[0, 0];
                    // 件数表示
                    uketsukeListCountLabel.Text = kensaUketsukeListDataGridView.Rows.Count.ToString() + "件";
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
    }
}
