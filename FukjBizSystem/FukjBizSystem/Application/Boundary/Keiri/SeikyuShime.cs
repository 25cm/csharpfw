using System;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuShime;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyuShimeForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// 2014/12/10  kiyokuni　エラー処理見直し
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SeikyuShimeForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// Today DateTime
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// ErrFlg = 0
        /// </summary>
        private bool shimeSuccess = false;

        #region 処理メッセージ

        /// <summary>
        /// 処理開始
        /// </summary>
        private const string MSG_INFO_START_PROCESSING = "処理を開始します。";

        /// <summary>
        /// 処理完了
        /// </summary>
        private const string MSG_INFO_COMPLETE_PROCESSING = "正常に処理が完了しました。";

        /// <summary>
        /// データ集計エラー
        /// </summary>
        private const string MSG_ERR_STEP_1 = "各データ集計処理に失敗しました。\r\nシステム管理者に連絡してください。\r\nエラーフラグ：";

        /// <summary>
        /// 年会費エラー
        /// </summary>
        private const string MSG_ERR_STEP_2 = "年会費集計処理に失敗しました。\r\nシステム管理者に連絡してください。\r\nエラーフラグ：";

        /// <summary>
        /// 更新エラー
        /// </summary>
        private const string MSG_ERR_STEP_3 = "ワーク更新処理に失敗しました。\r\nシステム管理者に連絡してください。\r\nエラーフラグ：";

        /// <summary>
        /// 消費税エラー
        /// </summary>
        private const string MSG_ERR_STEP_4 = "消費税計算に失敗しました。\r\nシステム管理者に連絡してください。\r\nエラーフラグ：";

        /// <summary>
        /// 採番エラー
        /// </summary>
        private const string MSG_ERR_STEP_5 = "採番処理に失敗しました。\r\nシステム管理者に連絡してください。\r\nエラーフラグ：";

        /// <summary>
        /// 作成エラー
        /// </summary>
        private const string MSG_ERR_STEP_6 = "各データ作成処理に失敗しました。\r\nシステム管理者に連絡してください。\r\nエラーフラグ：";

        /// <summary>
        /// その他エラー
        /// </summary>
        private const string MSG_ERR_STEP_7 = "請求締め処理に失敗しました。\r\nシステム管理者に連絡してください。\r\nエラーフラグ：";

        ///// <summary>
        ///// 送料請求対象追加処理エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_8 = "エラーＮｏ：８\r\n送料請求対象追加処理に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 6月度 年会費集計処理エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_9 = "エラーＮｏ：９\r\n6月度 年会費集計処理に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 年会費請求対象追加処理エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_10 = "エラーＮｏ：１０\r\n年会費請求対象追加処理に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 業者/個人フラグ更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_11 = "エラーＮｏ：１１\r\n業者/個人フラグ更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 業者単位 繰越し金追加エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_12 = "エラーＮｏ：１２\r\n業者単位 繰越し金追加に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 個人単位 繰越し金追加エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_13 = "エラーＮｏ：１３\r\n個人単位 繰越し金追加に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 未作成フラグ更新（業者）エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_14 = "エラーＮｏ：１４\r\n未作成フラグ更新（業者）に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 未作成フラグ更新（個人）エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_15 = "エラーＮｏ：１５\r\n未作成フラグ更新（個人）に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 消費税率取得エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_16 = "エラーＮｏ：１６\r\n消費税率取得に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 消費税算出エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_17 = "エラーＮｏ：１７\r\n消費税算出に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 業者数カウントエラー
        ///// </summary>
        //private const string MSG_ERR_STEP_18 = "エラーＮｏ：１８\r\n業者数カウントに失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 採番取得/更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_19 = "エラーＮｏ：１９\r\n採番取得/更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 業者分採番元番号更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_20 = "エラーＮｏ：２０\r\n業者分採番元番号更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 業者分請求作成カウント更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_21 = "エラーＮｏ：２１\r\n業者分請求作成カウント更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 個人数カウントエラー
        ///// </summary>
        //private const string MSG_ERR_STEP_22 = "エラーＮｏ：２２\r\n個人数カウントに失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 採番取得/更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_23 = "エラーＮｏ：２３\r\n採番取得/更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 個人分採番元番号更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_24 = "エラーＮｏ：２４\r\n個人分採番元番号更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 個人分請求作成カウント更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_25 = "エラーＮｏ：２５\r\n個人分請求作成カウント更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 請求No生成エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_26 = "エラーＮｏ：２６\r\n請求No生成に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 請求連番更新エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_27 = "エラーＮｏ：２７\r\n請求連番更新に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 締め済業者削除（請求明細）エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_28 = "エラーＮｏ：２８\r\n締め済業者削除（請求明細）に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 締め済業者削除（請求ヘッダ）エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_29 = "エラーＮｏ：２９\r\n締め済業者削除（請求ヘッダ）に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 締め済業者削除（請求鑑）エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_30 = "エラーＮｏ：３０\r\n締め済業者削除（請求鑑）に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 請求明細テーブル作成エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_31 = "エラーＮｏ：３１\r\n請求明細テーブル作成に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 請求書鑑テーブル作成エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_32 = "エラーＮｏ：３２\r\n請求書鑑テーブル作成に失敗しました。\r\nシステム管理者に連絡してください。";

        ///// <summary>
        ///// 請求ヘッダテーブル作成エラー
        ///// </summary>
        //private const string MSG_ERR_STEP_33 = "エラーＮｏ：３３\r\n請求ヘッダテーブル作成に失敗しました。\r\nシステム管理者に連絡してください。";
        
        #endregion

        #endregion

        #region public

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string gyoshaCdFrom = string.Empty;

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string gyoshaCdTo = string.Empty;

        /// <summary>
        /// 締め年月
        /// </summary>
        public string shimeNenGetsu = string.Empty;

        /// <summary>
        /// 締め区分
        /// </summary>
        public bool shimeKbn = false;

        /// <summary>
        /// 締め済業者/削除・再作成
        /// </summary>
        public bool shimeSumi = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SeikyuShimeForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SeikyuShimeForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region SeikyuShimeForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SeikyuShimeForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeikyuShimeForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 締め年月
                shimeDtTextBox.Text = today.AddMonths(-1).Year + string.Empty + (today.AddMonths(-1).Month < 10 ? "0" + today.AddMonths(-1).Month : today.AddMonths(-1).Month.ToString());

                // 請求日
                seikyuDtDateTimePicker.Value = today;

                // 業者コード（開始）
                gyoshaCdFromTextBox.Clear();

                // 業者コード（終了）
                gyoshaCdToTextBox.Clear();

                // 締め区分/事務局
                jimukyokuRadioButton.Checked = true;

                // 締め済業者/削除・再作成
                shimeSumiCheckBox.Checked = false;

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

        #region shimesyoriButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shimesyoriButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  DatNT　  新規作成
        /// 2014/10/29  DatNT    v1.06
        /// 2014/12/10  kiyokuni v1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shimesyoriButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 処理メッセージ
                msgTextBox.Clear();
                System.Windows.Forms.Application.DoEvents();

                // 単項目チェック & 関連チェック
                if (!CheckCondition()) { return; }

                // 実行確認チェック
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された条件で請求締め処理を実施します。よろしいですか？") != DialogResult.Yes)
                {
                    return;
                }

                IShimesyoriBtnClickALInput alInput = new ShimesyoriBtnClickALInput();

                MakeALInput(alInput);
                //処理中のボタンロック
                shimesyoriButton.Enabled = false;
                closeButton.Enabled = false;

                //処理開始
                msgTextBox.SelectionColor = Color.Blue;
                msgTextBox.AppendText(MSG_INFO_START_PROCESSING + Environment.NewLine);
                System.Windows.Forms.Application.DoEvents();
                IShimesyoriBtnClickALOutput alOuput = new ShimesyoriBtnClickApplicationLogic().Execute(alInput);

                // Display Message
                DispMsg(alOuput.ErrorFlg);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                //処理中のボタンロック解除
                shimesyoriButton.Enabled = true;
                closeButton.Enabled = true;
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
        /// 2014/09/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (shimeSuccess)
                {
                    this.DialogResult = DialogResult.OK;

                    shimeNenGetsu = shimeDtTextBox.Text;
                    gyoshaCdFrom = gyoshaCdFromTextBox.Text;
                    gyoshaCdTo = gyoshaCdToTextBox.Text;
                    shimeKbn = jimukyokuRadioButton.Checked;
                    shimeSumi = shimeSumiCheckBox.Checked;
                }

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

        #region SeikyuShimeForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SeikyuShimeForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeikyuShimeForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        shimesyoriButton.Focus();
                        shimesyoriButton.PerformClick();
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

        #region gyoshaCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29  DatNT　   v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text))
                {
                    gyoshaCdFromTextBox.Text = gyoshaCdFromTextBox.Text.PadLeft(4, '0');
                    gyoshaCdToTextBox.Text = gyoshaCdFromTextBox.Text;
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

        #region gyoshaCdFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29  DatNT　   v1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
                {
                    gyoshaCdToTextBox.Text = gyoshaCdToTextBox.Text.PadLeft(4, '0');
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

        #region CheckCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  DatNT　　 新規作成
        /// 2014/10/29  DatNT     v1.03
        /// 2014/12/10  kiyokuni  チェック処理を修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMsg = new StringBuilder();

            // 締め年月
            if (string.IsNullOrEmpty(shimeDtTextBox.Text))
            {
                errMsg.AppendLine("締め年月を入力して下さい。");
            }
            if (!string.IsNullOrEmpty(shimeDtTextBox.Text) && shimeDtTextBox.Text.Length != 6)
            {
                errMsg.AppendLine("締め年月は6桁で入力して下さい。");
            }

            // 業者コード（開始＆終了）
            bool flg = true;
            //del kiyokuni 2014.12.03
            //if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && gyoshaCdFromTextBox.Text.Length != 4)
            //{
            //    errMsg.AppendLine("業者コード（開始）は2桁で入力して下さい。");
            //    flg = false;
            //}

            //if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text) && gyoshaCdToTextBox.Text.Length != 4)
            //{
            //    errMsg.AppendLine("業者コード（終了）は2桁で入力して下さい。");
            //    flg = true;
            //}
            
            if (flg && !string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyoshaCdToTextBox.Text)
                && Convert.ToInt32(gyoshaCdFromTextBox.Text) > Convert.ToInt32(gyoshaCdToTextBox.Text))
            {
                errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
            }
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            // 日報未完了チェック
            IShimesyoriBtnClickALInput alInput = new ShimesyoriBtnClickALInput();
            alInput.ReportCheck     = true;
            alInput.ShimeKbn        = jimukyokuRadioButton.Checked ? "0" : "1";
            alInput.ShimeDt         = shimeDtTextBox.Text;
            alInput.GyoshaCdFrom    = gyoshaCdFromTextBox.Text;
            alInput.GyoshaCdTo      = gyoshaCdToTextBox.Text;
            IShimesyoriBtnClickALOutput alOutput = new ShimesyoriBtnClickApplicationLogic().Execute(alInput);

            if (alOutput.DailyReportInCompleteCount > 0 || alOutput.KeiryouShomeiIncompleteCount > 0)
            {
                errMsg.AppendLine("日報未完了データが存在するため、締め処理が実行できません。");
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            //if(!string.IsNullOrEmpty(errMsg.ToString()))
            //{
            //    MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
            //    return false;
            //}

            return true;
        }
        #endregion

        #region MakeALInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeALInput
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alInput"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeALInput(IShimesyoriBtnClickALInput alInput)
        {
            // Report Check
            alInput.ReportCheck = false;

            // 締め年月
            alInput.ShimeDt = shimeDtTextBox.Text;

            // 業者コード（開始＆終了）
            //if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
            //{
            //    alInput.GyoshaCdFrom = gyoshaCdFromTextBox.Text;
            //    alInput.GyoshaCdTo = "9999";
            //}
            //else if (string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
            //{
            //    alInput.GyoshaCdFrom = "0000";
            //    alInput.GyoshaCdTo = "9999";
            //}
            //else if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
            //{
                alInput.GyoshaCdFrom = gyoshaCdFromTextBox.Text;
                alInput.GyoshaCdTo = gyoshaCdToTextBox.Text;
            //}

            // 締め済業者/削除・再作成
            alInput.ShimeSumi = shimeSumiCheckBox.Checked ? "1" : "0";

            // 請求日
            alInput.SeikyuDt = seikyuDtDateTimePicker.Value.ToString("yyyyMMdd");
            
            // 締め区分
            alInput.ShimeKbn = (jimukyokuRadioButton.Checked) ? "1" : "2";

            // ログイン者名
            alInput.LoginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 端末名
            alInput.PcUpdate = Dns.GetHostName();

            // 年度
            alInput.Nendo = Utility.DateUtility.GetNendo(today).ToString();
        }
        #endregion

        #region DispMsg
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispMsg
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errFlg"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  DatNT　　 新規作成
        /// 2014/12/10  kiyokuni　メッセージ変更、開始のタイミングが違うので修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DispMsg(string errFlg)
        {
            //msgTextBox.SelectionColor = Color.Blue;
            //msgTextBox.AppendText(MSG_INFO_START_PROCESSING + Environment.NewLine);

            if (errFlg == "0")
            {
                msgTextBox.SelectionColor = Color.Blue;
                msgTextBox.AppendText(MSG_INFO_COMPLETE_PROCESSING + Environment.NewLine);

                shimeSuccess = true;
            }
            else
            {
                shimeSuccess = false;

                string[] err = new string[1];
                //string[] err = new string[errFlg.Length];

                //if (errFlg.Contains(","))
                //{
                //    err = errFlg.Split(',');
                //}
                //else
                //{
                    err[0] = errFlg;
                //}

                foreach (string errStr in err)
                {
                    msgTextBox.SelectionColor = Color.Red;

                    if(Convert.ToInt32(errStr)>=1 && Convert.ToInt32(errStr)<=8 || errStr=="12" || errStr=="13"){
                        msgTextBox.AppendText(MSG_ERR_STEP_1 + errStr + Environment.NewLine);
                    }else if(errStr=="9" || errStr=="10"){
                        msgTextBox.AppendText(MSG_ERR_STEP_2 + errStr + Environment.NewLine);
                    }else if(errStr=="11" || errStr=="14" || errStr=="15"){
                        msgTextBox.AppendText(MSG_ERR_STEP_3 + errStr + Environment.NewLine);
                    }else if(errStr=="16" || errStr=="17"){
                        msgTextBox.AppendText(MSG_ERR_STEP_4 + errStr + Environment.NewLine);
                    }else if (Convert.ToInt32(errStr) >= 18 && Convert.ToInt32(errStr) <= 42){
                        msgTextBox.AppendText(MSG_ERR_STEP_5 + errStr + Environment.NewLine);
                    }else if (Convert.ToInt32(errStr) >= 43 && Convert.ToInt32(errStr) <= 54){
                        msgTextBox.AppendText(MSG_ERR_STEP_6 + errStr + Environment.NewLine);
                    }else{
                        msgTextBox.AppendText(MSG_ERR_STEP_7 + errStr + Environment.NewLine);
                    }


                    //switch (errStr)
                    //{
                    //    case "1": msgTextBox.AppendText(MSG_ERR_STEP_1 + Environment.NewLine); break;
                    //    case "2": msgTextBox.AppendText(MSG_ERR_STEP_2 + Environment.NewLine); break;
                    //    case "3": msgTextBox.AppendText(MSG_ERR_STEP_3 + Environment.NewLine); break;
                    //    case "4": msgTextBox.AppendText(MSG_ERR_STEP_4 + Environment.NewLine); break;
                    //    case "5": msgTextBox.AppendText(MSG_ERR_STEP_5 + Environment.NewLine); break;
                    //    case "6": msgTextBox.AppendText(MSG_ERR_STEP_6 + Environment.NewLine); break;
                    //    case "7": msgTextBox.AppendText(MSG_ERR_STEP_7 + Environment.NewLine); break;
                    //    case "8": msgTextBox.AppendText(MSG_ERR_STEP_8 + Environment.NewLine); break;
                    //    case "9": msgTextBox.AppendText(MSG_ERR_STEP_9 + Environment.NewLine); break;
                    //    case "10": msgTextBox.AppendText(MSG_ERR_STEP_10 + Environment.NewLine); break;
                    //    case "11": msgTextBox.AppendText(MSG_ERR_STEP_11 + Environment.NewLine); break;
                    //    case "12": msgTextBox.AppendText(MSG_ERR_STEP_12 + Environment.NewLine); break;
                    //    case "13": msgTextBox.AppendText(MSG_ERR_STEP_13 + Environment.NewLine); break;
                    //    case "14": msgTextBox.AppendText(MSG_ERR_STEP_14 + Environment.NewLine); break;
                    //    case "15": msgTextBox.AppendText(MSG_ERR_STEP_15 + Environment.NewLine); break;
                    //    case "16": msgTextBox.AppendText(MSG_ERR_STEP_16 + Environment.NewLine); break;
                    //    case "17": msgTextBox.AppendText(MSG_ERR_STEP_17 + Environment.NewLine); break;
                    //    case "18": msgTextBox.AppendText(MSG_ERR_STEP_18 + Environment.NewLine); break;
                    //    case "19": msgTextBox.AppendText(MSG_ERR_STEP_19 + Environment.NewLine); break;
                    //    case "20": msgTextBox.AppendText(MSG_ERR_STEP_20 + Environment.NewLine); break;
                    //    case "21": msgTextBox.AppendText(MSG_ERR_STEP_21 + Environment.NewLine); break;
                    //    case "22": msgTextBox.AppendText(MSG_ERR_STEP_22 + Environment.NewLine); break;
                    //    case "23": msgTextBox.AppendText(MSG_ERR_STEP_23 + Environment.NewLine); break;
                    //    case "24": msgTextBox.AppendText(MSG_ERR_STEP_24 + Environment.NewLine); break;
                    //    case "25": msgTextBox.AppendText(MSG_ERR_STEP_25 + Environment.NewLine); break;
                    //    case "26": msgTextBox.AppendText(MSG_ERR_STEP_26 + Environment.NewLine); break;
                    //    case "27": msgTextBox.AppendText(MSG_ERR_STEP_27 + Environment.NewLine); break;
                    //    case "28": msgTextBox.AppendText(MSG_ERR_STEP_28 + Environment.NewLine); break;
                    //    case "29": msgTextBox.AppendText(MSG_ERR_STEP_29 + Environment.NewLine); break;
                    //    case "30": msgTextBox.AppendText(MSG_ERR_STEP_30 + Environment.NewLine); break;
                    //    case "31": msgTextBox.AppendText(MSG_ERR_STEP_31 + Environment.NewLine); break;
                    //    case "32": msgTextBox.AppendText(MSG_ERR_STEP_32 + Environment.NewLine); break;
                    //    case "33": msgTextBox.AppendText(MSG_ERR_STEP_33 + Environment.NewLine); break;
                    //    default: break;
                    //}
                }
            }
        }
        #endregion


        #endregion
    }
    #endregion
}
