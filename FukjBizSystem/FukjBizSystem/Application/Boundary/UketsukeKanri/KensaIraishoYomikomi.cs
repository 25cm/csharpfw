using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.KensaIraishoYomikomi;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraishoYomikomiForm
    /// <summary>
    /// 検査依頼書読込画面（スタックリーダー）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaIraishoYomikomiForm : FukjBaseForm
    {
        #region 定数(private)

        /// <summary>
        /// 検査区分の定数区分
        /// </summary>
        private const string KENSA_CONST_KBN = "041";

        /// <summary>
        /// バーコード番号の入力桁数
        /// </summary>
        private const int BARCODE_MAX_LENGTH = 10;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;

        /// <summary>
        /// Current system date
        /// </summary>
        private DateTime _now;

        /// <summary>
        /// 採番スタートNo
        /// </summary>
        private decimal? MyCounter;
        
        /// <summary>
        /// 読込処理中フラグ
        /// </summary>
        private bool OnRead = false;

        #endregion
                
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaIraishoYomikomiForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaIraishoYomikomiForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaIraishoYomikomiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoYomikomiForm_Load
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaIraishoYomikomiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 表示データ取得
                DoFormLoad();

                // 開始番号の初期化
                SetFirstMyCounter(null);

                #region コントロール活性化制御

                shisyoComboBox.Enabled = true;

                kensaKbnComboBox.Enabled = true;

                startButton.Enabled = false;

                KensaIraishoYomikomiDataGridView.Enabled = false;

                stopButton.Enabled = false;

                hakiButton.Enabled = false;

                torokuButton.Enabled = false;

                #endregion
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

        #region KensaIraishoYomikomiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoYomikomiForm_KeyDown
        /// <summary>
        /// ファンクションキー制御（ショートカット）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaIraishoYomikomiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        ketteiButton.PerformClick();
                        break;
                    case Keys.F2:
                        startButton.PerformClick();
                        break;
                    case Keys.F3:
                        stopButton.PerformClick();
                        break;
                    case Keys.F4:
                        hakiButton.PerformClick();
                        break;
                    case Keys.F5:
                        torokuButton.PerformClick();
                        break;
                    case Keys.F11:
                        uketsukeListButton.PerformClick();
                        break;
                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
        /// <summary>
        /// 検索条件表示切替ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void viewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;
                if (this._searchShowFlg)//検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else////検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.srhListPanel,
                    this._defaultListPanelTop,
                    this._defaultListPanelHeight);
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

        #region uketsukeListButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeListButton_Click
        /// <summary>
        /// 受付一覧ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeListButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // 検査依頼受付一覧画面
                KensaIraishoUketsukeListForm frm = new KensaIraishoUketsukeListForm();

                // 受付一覧画面に遷移
                Program.mForm.MoveNext(frm, ListFormEnd);
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
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 切断
                UsbBarcodeUtility.Close();

                // 画面を終了する
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

        #region ketteiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ketteiButton_Click
        /// <summary>
        /// 決定ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ketteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shisyoComboBox.Enabled)
                {
                    // Current system date
                    _now = Common.Common.GetCurrentTimestamp();
                    // TODO 外観検査、11条水質の採番を行う場合は、支所コードを使用しないようにする(常に0:事務局扱いで採番する)
                    // 検査区分と支所コードから採番区分への変換
                    string saibanKbn = string.Format("{0}{1}", kensaKbnComboBox.SelectedValue.ToString(), shisyoComboBox.SelectedValue.ToString());

                    // TODO: toyoda 年度変換
                    string nendo = _now.Year.ToString();
                    
                    // 採番開始番号取得
                    IGetNowSaibanRenbanALOutput saibanOutput = 
                        new GetNowSaibanRenbanApplicationLogic().Execute(new GetNowSaibanRenbanALInput(nendo, saibanKbn));

                    // 採番開始番号の設定
                    SetFirstMyCounter(saibanOutput.NowRenban + 1);

                    #region コントロール活性化制御

                    shisyoComboBox.Enabled = false;

                    kensaKbnComboBox.Enabled = false;

                    startButton.Enabled = true;

                    #endregion
                }
                else
                {
                    // 採番開始番号クリア
                    SetFirstMyCounter(null);

                    #region コントロール活性化制御

                    shisyoComboBox.Enabled = true;

                    kensaKbnComboBox.Enabled = true;

                    startButton.Enabled = false;

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

        #region startButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： startButton_Click
        /// <summary>
        /// 開始ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void startButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!UsbBarcodeUtility.Open())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "機器の接続に失敗しました。機器との接続を確認してください。");
                    return;
                }
                
                if (!UsbBarcodeUtility.Write("C0"))
                {
                    // 切断
                    UsbBarcodeUtility.Close();

                    MessageForm.Show2(MessageForm.DispModeType.Error, "機器の接続に失敗しました。機器との接続を確認してください。");
                    return;
                }

                // 読込処理中フラグオン
                OnRead = true;
                                
                // スレッドの作成
                Thread t = new Thread(new ThreadStart(WorkThread));

                // スレッドを開始する
                t.Start();

                #region コントロール活性化制御

                shisyoComboBox.Enabled = false;

                kensaKbnComboBox.Enabled = false;

                ketteiButton.Enabled = false;

                startButton.Enabled = false;

                KensaIraishoYomikomiDataGridView.Enabled = false;

                stopButton.Enabled = true;

                hakiButton.Enabled = false;

                torokuButton.Enabled = false;

                uketsukeListButton.Enabled = false;

                closeButton.Enabled = false;

                // メニューボタンからの遷移を制御
                Program.mForm.SetMenuEnabled(false);

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

        #region stopButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： stopButton_Click
        /// <summary>
        /// 停止ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void stopButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                OnRead = false;

                #region コントロール活性化制御

                shisyoComboBox.Enabled = false;

                kensaKbnComboBox.Enabled = false;

                ketteiButton.Enabled = false;

                startButton.Enabled = true;

                KensaIraishoYomikomiDataGridView.Enabled = true;

                stopButton.Enabled = false;

                hakiButton.Enabled = true;

                torokuButton.Enabled = true;
                
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

        #region hakiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hakiButton_Click
        /// <summary>
        /// 破棄ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hakiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                // 確認メッセージ
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "読み込んだバーコード情報をクリアしますがよろしいですか？\r\n受付番号は登録されません。") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                // 表示内容をクリア
                kensaIraishoDataSet.ReadList.Clear();

                srhListCountLabel.Text = string.Format("{0}件", 0);

                // 採番開始番号クリア
                SetFirstMyCounter(null);

                #region コントロール活性化制御

                shisyoComboBox.Enabled = true;

                kensaKbnComboBox.Enabled = true;

                ketteiButton.Enabled = true;

                startButton.Enabled = false;

                KensaIraishoYomikomiDataGridView.Enabled = false;

                stopButton.Enabled = false;

                hakiButton.Enabled = false;

                torokuButton.Enabled = false;

                // スレッド処理中にCloseさせない
                uketsukeListButton.Enabled = true;
                closeButton.Enabled = true;

                // メニューボタンからの遷移を制御
                Program.mForm.SetMenuEnabled(true);

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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                // 確認メッセージ
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "バーコード情報と受付番号を登録してよろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                // 入力値チェック
                if (!DataCheck())
                {
                    return;
                }
                
                // SuishitsuIraiUketsukeWrk作成
                ITorokuBtnClickALInput torokuInput = new TorokuBtnClickALInput();

                torokuInput.SuishitsuIraiUketsukeWrkDT = CreateSuishitsuIraiUketsukeWrk();

                // TODO: toyoda 年度変換
                torokuInput.SaibanNendo = _now.Year.ToString();

                // 検査区分
                torokuInput.KensaKbn = kensaKbnComboBox.SelectedValue.ToString();

                // 支所コード
                torokuInput.ShishoCd = shisyoComboBox.SelectedValue.ToString();

                // SuishitsuIraiUketsukeWrk更新
                new TorokuBtnClickApplicationLogic().Execute(torokuInput);

                // 表示内容をクリア
                kensaIraishoDataSet.ReadList.Clear();

                srhListCountLabel.Text = string.Format("{0}件", 0);

                // 採番開始番号クリア
                SetFirstMyCounter(null);

                #region コントロール活性化制御

                shisyoComboBox.Enabled = true;

                kensaKbnComboBox.Enabled = true;

                ketteiButton.Enabled = true;

                startButton.Enabled = false;

                KensaIraishoYomikomiDataGridView.Enabled = false;

                stopButton.Enabled = false;

                hakiButton.Enabled = false;

                torokuButton.Enabled = false;

                // スレッド処理中にCloseさせない
                uketsukeListButton.Enabled = true;
                closeButton.Enabled = true;

                // メニューボタンからの遷移を制御
                Program.mForm.SetMenuEnabled(true);

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

        #endregion

        #region メソッド(private)

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            if (kensaIraishoDataSet.ReadList.Count == 0)
            {
                errMsg.AppendLine("必須項目：検査依頼書が一件も読み込まれていません。");
            }
            else
            {
                foreach (KensaIraishoDataSet.ReadListRow row in kensaIraishoDataSet.ReadList)
                {
                    // バーコードが紐づいていない
                    if (row.IsBarcodeNull() || string.IsNullOrEmpty(row.Barcode.Trim()))
                    {
                        errMsg.AppendLine(string.Format("必須項目：バーコード番号が入力されていません。（{0}行目）", row.Rowindex));

                        continue;
                    }

                    // 桁数オーバー
                    if (row.Barcode.Trim().Length > BARCODE_MAX_LENGTH)
                    {
                        errMsg.AppendLine(string.Format("バーコード番号は{0}桁以下で入力して下さい。（{1}行目）", BARCODE_MAX_LENGTH, row.Rowindex));

                        continue;
                    }
                }
            }

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion
        
        #region CreateSuishitsuIraiUketsukeWrk
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSuishitsuIraiUketsukeWrk
        /// <summary>
        /// 登録データの作成
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuIraiUketsukeWrkDataSet.SuishitsuIraiUketsukeWrkDataTable CreateSuishitsuIraiUketsukeWrk()
        {
            SuishitsuIraiUketsukeWrkDataSet.SuishitsuIraiUketsukeWrkDataTable datatable = new SuishitsuIraiUketsukeWrkDataSet.SuishitsuIraiUketsukeWrkDataTable();

            DateTime procDate = Common.Common.GetCurrentTimestamp();

            foreach (KensaIraishoDataSet.ReadListRow row in kensaIraishoDataSet.ReadList)
            {
                SuishitsuIraiUketsukeWrkDataSet.SuishitsuIraiUketsukeWrkRow newRow = datatable.NewSuishitsuIraiUketsukeWrkRow();

                newRow.IraiUketsukeKensaKbn = kensaKbnComboBox.SelectedValue.ToString();

                newRow.IraiUketsukeShishoCd = shisyoComboBox.SelectedValue.ToString();

                // TODO: toyoda 年度変換
                newRow.IraiUketsukeNendo = _now.Year.ToString();

                newRow.IraiUketsukeNo = row.Renban;

                newRow.IraiUketsukeBarCd = row.Barcode.Trim();

                newRow.SetIraiUketsukeCsvOutputDtNull();

                newRow.InsertDt = procDate;

                newRow.InsertUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                newRow.InsertTarm = Dns.GetHostName();

                newRow.UpdateDt = procDate;

                newRow.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                newRow.UpdateTarm = Dns.GetHostName();
                
                // 行を挿入
                datatable.AddSuishitsuIraiUketsukeWrkRow(newRow);

                // 行の状態を設定
                newRow.AcceptChanges();

                // 行の状態を設定（新規）
                newRow.SetAdded();
            }

            return datatable;
        }
        #endregion

        #region SetFirstMyCounter
        /// <summary>
        /// 開始番号の表示を更新する
        /// </summary>
        /// <param name="counter"></param>
        private void SetFirstMyCounter(decimal? counter)
        {
            MyCounter = counter;

            startCountLabel.Text = MyCounter.HasValue ? string.Format("{0:000000}", MyCounter) : "######";

            if (counter == null)
            {
                ketteiButton.Text = "F1:決定";
            }
            else
            {
                ketteiButton.Text = "F1:解除";
            }
        }
        #endregion

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 画面表示用データ取得
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // Current system date
            _now = Common.Common.GetCurrentTimestamp();

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.srhListPanel.Top;
            this._defaultListPanelHeight = this.srhListPanel.Height;

            // 検査区分
            Utility.Utility.SetComboBoxList(kensaKbnComboBox, Common.Common.GetConstTable(KENSA_CONST_KBN), "ConstNm", "ConstValue", false);

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

            // 支所
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", false);
            shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
        }
        #endregion

        #region WorkThread
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： WorkThread
        /// <summary>
        /// スタックリーダー通信処理ワーカスレッド
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void WorkThread()
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 排紙口振分け用コマンド
            string acceptCommand;
            
            // 読み取りエラー発生
            bool HasReadError = false;

            // 手動停止要求
            bool ReadStop = false;

            // 処理中カウンタ
            decimal ThisCounter;

            try
            {
                // プリンタモードモード設定（連番）
                string printCommand = string.Format("{0}{1}", "P2", string.Format("{0:000000}", MyCounter));

                // A1:プリンタモードコマンド送信
                bool ret = UsbBarcodeUtility.Write(printCommand);
                if (!ret)
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("{0},{1}{2}", "A1:Send", "エラー", "(想定外エラー)"));
                    SendMessageError("機器の接続に失敗しました。機器との接続を確認してください。");
                    return;
                }

                // A2:スタートコマンド送信
                ret = UsbBarcodeUtility.Write("C1");
                if (!ret)
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("{0},{1}{2}", "A2:Send", "エラー", "(想定外エラー)"));
                    SendMessageError("機器の接続に失敗しました。機器との接続を確認してください。");
                    return;
                }

                // A3:ステータスコマンド受信
                byte[] readBuff1;
                ret = UsbBarcodeUtility.Read(out readBuff1);
                if (ret)
                {
                    // 準備完了以外は終了させる
                    if (UsbBarcodeUtility.GetStatus(readBuff1) != UsbBarcodeUtility.CommandStatus.StartOK)
                    {
                        if (UsbBarcodeUtility.GetStatus(readBuff1) == UsbBarcodeUtility.CommandStatus.StartNG)
                        {
                            TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("{0},{1}{2}", "A3:Read", Encoding.ASCII.GetString(readBuff1), "(動作準備ＮＧ)"));
                            SendMessageError("機器のエラーを検出しました。用紙が正しくセットされている事、用紙詰まりがない事を確認してください。");
                            return;
                        }
                        else
                        {
                            TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("{0},{1}{2}", "A3:Read", Encoding.ASCII.GetString(readBuff1), "(想定外エラー)"));
                            SendMessageError("機器のエラーを検出しました。用紙が正しくセットされている事、用紙詰まりがない事を確認してください。");
                            return;
                        }
                    }
                }
                else
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("{0},{1}{2}", "A3:Read", "エラー", "(想定外エラー)"));
                    SendMessageError("機器の接続に失敗しました。機器との接続を確認してください。");
                    return;
                }
                
                while (true)
                {
                    // カウンタを更新
                    ThisCounter = MyCounter.Value;

                    try
                    {
                        //Bx Read:（読込データ、ステータスコマンド）受信
                        byte[] readBuff2;
                        ret = UsbBarcodeUtility.Read(out readBuff2);
                        if (ret)
                        {
                            // 読込データに応じて排紙口を切り替え(手動停止がかけられている場合は、応答コマンドに読込停止を設定)
                            if (UsbBarcodeUtility.GetStatus(readBuff2) == UsbBarcodeUtility.CommandStatus.DataReceive)
                            {
                                TraceLog.InfoWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Read,{1}", ThisCounter, Encoding.ASCII.GetString(readBuff2)));
                                SendReadResult(Encoding.ASCII.GetString(readBuff2), string.Format("{0}", string.Format("{0:000000}", ThisCounter)), null);

                                if (!OnRead)
                                {
                                    // 印字して停止
                                    acceptCommand = "AC";
                                    ReadStop = true;
                                }
                                else
                                {
                                    // 印字して継続
                                    acceptCommand = "AA";
                                }
                            }
                            else if (UsbBarcodeUtility.GetStatus(readBuff2) == UsbBarcodeUtility.CommandStatus.ReadError)
                            {
                                TraceLog.InfoWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Read,0x{1}{2}", ThisCounter, BytesConvert.ToHexString(readBuff2), "(読込エラー)"));
                                SendReadResult(null, string.Format("{0}", string.Format("{0:000000}", ThisCounter)), "バーコードが読み取れませんでした。手入力してください。");

                                if (!OnRead)
                                {
                                    // 印字せず停止
                                    acceptCommand = "A3";
                                    ReadStop = true;
                                }
                                else
                                {
                                    // 印字せず停止
                                    acceptCommand = "A3";
                                    HasReadError = true;
                                }

                            }
                            else if (UsbBarcodeUtility.GetStatus(readBuff2) == UsbBarcodeUtility.CommandStatus.NormalEnd)
                            {
                                TraceLog.InfoWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Read,{1}{2}", ThisCounter, Encoding.ASCII.GetString(readBuff2), "(正常終了)"));
                                SendMessageInfo("読込が完了しました。");
                                break;
                            }
                            else
                            {
                                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Read,{1}{2}", ThisCounter, Encoding.ASCII.GetString(readBuff2), "(機器エラー)"));
                                SendMessageError("機器のエラーを検出しました。用紙が正しくセットされている事、用紙詰まりがない事を確認してください。");
                                break;
                            }
                        }
                        else
                        {
                            TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Read,{1}{2}", ThisCounter, "エラー", "(想定外エラー)"));
                            SendMessageError("機器の接続に失敗しました。機器との接続を確認してください。");
                            break;
                        }

                        // Bx Send:応答コマンド送信
                        ret = UsbBarcodeUtility.Write(acceptCommand);
                        if (!ret)
                        {
                            TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Send,{1}{2}", ThisCounter, "エラー", "(想定外エラー)"));
                            SendMessageError("機器の接続に失敗しました。機器との接続を確認してください。");
                            break;
                        }

                        // 読込エラー時（一旦停止してカウントをインクリメントし再実行）、手動停止要求時
                        if (HasReadError || ReadStop)
                        {
                            //Bx Read:ステータスコマンド受信
                            byte[] readBuff3;
                            ret = UsbBarcodeUtility.Read(out readBuff3);
                            if (ret)
                            {
                                if (UsbBarcodeUtility.GetStatus(readBuff3) != UsbBarcodeUtility.CommandStatus.NormalEnd)
                                {
                                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Read,{1}{2}", ThisCounter, Encoding.ASCII.GetString(readBuff3), "(機器エラー)"));
                                    SendMessageError("機器のエラーを検出しました。用紙が正しくセットされている事、用紙詰まりがない事を確認してください。");
                                    break;
                                }
                            }
                            else
                            {
                                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("B{0}:Read,{1}{2}", ThisCounter, "エラー", "(想定外エラー)"));
                                SendMessageError("機器の接続に失敗しました。機器との接続を確認してください。");
                                break;
                            }

                            // 読込エラー時は自動的に再処理を実行
                            if (HasReadError)
                            {
                                // 再処理スレッド開始
                                Thread t = new Thread(new ThreadStart(WorkThread));
                                t.Start();
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        // 想定外エラー
                        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("想定外のエラーを検出しました。({0})", e.Message));
                        SendMessageError(string.Format("想定外のエラーを検出しました。({0})", e.Message));
                    }
                }
            }
            finally
            {
                // 再処理が無い場合は切断
                if (!HasReadError)
                {
                    // 切断
                    UsbBarcodeUtility.Close();
                }

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region SendMessage(ワーカースレッドからの画面描画)

        #region SendMessage(bool showDialog, string barcode, string printed, string message, bool isError)
        /// <summary>
        /// SendMessage(bool showDialog, string barcode, string printed, string message, bool isError)
        /// </summary>
        /// <param name="showDialog"></param>
        /// <param name="barcode"></param>
        /// <param name="printed"></param>
        /// <param name="message"></param>
        /// <param name="isError"></param>
        public void SendMessage(bool showDialog, string barcode, string printed, string message, bool isError)
        {
            if (showDialog)
            {
                if (isError)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, message);
                }
                else
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, message);
                }
            }
            else
            {
                this.SuspendLayout();

                // 結果行の作成
                KensaIraishoDataSet.ReadListRow newRow = kensaIraishoDataSet.ReadList.NewReadListRow();

                // No.
                newRow.Rowindex = kensaIraishoDataSet.ReadList.Count + 1;
                // 支所
                newRow.Shisho = shisyoComboBox.Text;
                // 年度
                newRow.Nendo = _now.Year.ToString(); // TODO: toyoda 年度変換
                // 印字
                newRow.Renban = printed;
                // バーコード
                newRow.Barcode = barcode;
                // 備考
                newRow.Remark = message;
                // 行の追加
                kensaIraishoDataSet.ReadList.AddReadListRow(newRow);

                this.Refresh();

                srhListCountLabel.Text = string.Format("{0}件", kensaIraishoDataSet.ReadList.Count);

                MyCounter++;

                this.ResumeLayout();
            }
        }
        #endregion

        #region SendMessageDelegate(bool showDialog, string barcode, string printed, string message)
        /// <summary>
        /// SendMessageDelegate(bool showDialog, string barcode, string printed, string message, bool isError)
        /// </summary>
        /// <param name="showDialog"></param>
        /// <param name="barcode"></param>
        /// <param name="printed"></param>
        /// <param name="message"></param>
        /// <param name="isError"></param>
        private delegate void SendMessageDelegate(bool showDialog, string barcode, string printed, string message, bool isError);
        #endregion

        #region SendMessageError(string message)
        /// <summary>
        /// SendMessageError(string message)
        /// </summary>
        /// <param name="message"></param>
        private void SendMessageError(string message)
        {
            Invoke(new SendMessageDelegate(SendMessage), new object[] { true, null, null, message, true });

            return;
        }
        #endregion

        #region SendMessageInfo(string message)
        /// <summary>
        /// SendMessageInfo(string message)
        /// </summary>
        /// <param name="message"></param>
        private void SendMessageInfo(string message)
        {
            Invoke(new SendMessageDelegate(SendMessage), new object[] { true, null, null, message, false });

            return;
        }
        #endregion

        #region SendReadResult(string barcode, string printed, string message)
        /// <summary>
        /// SendReadResult(string barcode, string printed, string message)
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="printed"></param>
        /// <param name="message"></param>
        private void SendReadResult(string barcode, string printed, string message)
        {
            Invoke(new SendMessageDelegate(SendMessage), new object[] { false, barcode, printed, message, false });

            return;
        }
        #endregion

        #endregion
                        
        #endregion

        #region BaseFormのテスト的に・・・

        #region KensaIraishoYomikomiForm_FormClosing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoYomikomiForm_FormClosing
        /// <summary>
        /// フォームが閉じられるとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaIraishoYomikomiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ワーカ処理中にクローズされるとエラーになる・・・
            if (OnRead)
            {
                OnRead = false;
            }
        }
        #endregion

        #region ListFormEnd(Form childForm)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ListFormEnd
        /// <summary>
        /// 受付一覧画面終了時
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ListFormEnd(Form childForm)
        {
            // 再処理のための初期化を行う。（特に必要ないかも・・・）
        }
        #endregion

        #endregion
    }
    #endregion
}
