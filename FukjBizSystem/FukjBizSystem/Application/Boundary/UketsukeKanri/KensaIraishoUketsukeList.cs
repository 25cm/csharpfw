using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.KensaIraishoUketsukeList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.UketsukeKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraishoUketsukeListForm
    /// <summary>
    /// 検査依頼書読込画面（スタックリーダー）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaIraishoUketsukeListForm : FukjBaseForm
    {
        #region 定数(private)

        /// <summary>
        /// 検査区分（水質検査）
        /// </summary>
        private const string KENSA_KBN_SUISHITSU = "8";

        /// <summary>
        /// 検査区分（計量証明）
        /// </summary>
        private const string KENSA_KBN_KEIRYOU = "9";
        
        /// <summary>
        /// 検査区分の定数区分
        /// </summary>
        private const string KENSA_CONST_KBN = "041";
                
        /// <summary>
        /// HHTデータファイル保存先
        /// </summary>
        private const string OUTPUTPATH_CONST_KBN = "042";

        /// <summary>
        /// HHTデータファイル名
        /// </summary>
        private const string FILENAME_CONST_KBN = "043";

        /// <summary>
        /// CSV区切り文字
        /// </summary>
        private const string HHTLOG_SEPARATOR = "\t";
        
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
        /// ファイル名リスト
        /// </summary>
        private Dictionary<string, string> outputFilenameList = new Dictionary<string, string>();

        /// <summary>
        /// 出力ディレクトリリスト
        /// </summary>
        private Dictionary<string, string> outputDirectoryList = new Dictionary<string, string>();
        
        #endregion
                
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaIraishoUketsukeListForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaIraishoUketsukeListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensaIraishoUketsukeListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoUketsukeListForm_Load
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaIraishoUketsukeListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // 表示データ取得
                DoFormLoad();

                // 初期化
                SetDefaultDisplayControl();
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

        #region KensaIraishoUketsukeListForm_Shown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoUketsukeListForm_Shown
        /// <summary>
        /// フォーム表示後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaIraishoUketsukeListForm_Shown(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 初期検索
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

        #region KensaIraishoUketsukeListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaIraishoUketsukeListForm_KeyDown
        /// <summary>
        /// ファンクションキー制御（ショートカット）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaIraishoUketsukeListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        clearButton.PerformClick();
                        break;
                    case Keys.F2:
                        searchButton.PerformClick();
                        break;
                    case Keys.F3:
                        outputButton.PerformClick();
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
        /// 2014/10/06　豊田　　    新規作成
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
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 検索条件を初期化
                SetDefaultDisplayControl();
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

        #region searchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： searchButton_Click
        /// <summary>
        /// 検索ボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void searchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsValidInput()) return;

                // 検索を実行
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

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// CSV出力ボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                // 確認メッセージ
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示内容をCSVファイルに出力してよろしいですか？") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                                
                foreach (string kensaKbn in outputFilenameList.Keys)
                {
                    // データ作成
                    KensaIraishoDataSet.HHTLOGDataTable outputData = CreateHHTLOG(kensaKbn);

                    // データ無しは出力しない
                    if (outputData.Count == 0)
                    {
                        continue;
                    }

                    foreach (string dir in outputDirectoryList.Keys)
                    {
                        // 保存ファイル名（フルパス）
                        string fullPath = Path.Combine(dir, outputFilenameList[kensaKbn]);

                        // ファイルが存在する場合、上書き確認を行う
                        if (File.Exists(fullPath))
                        {
                            if (MessageForm.Show2(MessageForm.DispModeType.Question, string.Format("{0}にファイルが存在します。\r\n({1})\r\n上書きされますがよろしいですか？", outputDirectoryList[dir], fullPath)) != System.Windows.Forms.DialogResult.Yes)
                            {
                                continue;
                            }
                        }

                        // データ出力
                        ExportCSV(outputData, fullPath);
                    }
                }
                
                // 更新データ作成（出力日）
                IOutputBtnClickALInput alInput = new OutputBtnClickALInput();

                alInput.UpdateCsvOutputDtDataTable = CreateUpdateCsvOutputDt();

                // SuishitsuIraiUketsukeWrk更新
                new OutputBtnClickApplicationLogic().Execute(alInput);
                
                // 画面表示を更新
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

        #region uketsukeDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 受付日チェックボックス変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (uketsukeDtAddFlgCheckBox.Checked)
                {
                    uketsukeDtFromDateTimePicker.Enabled = true;
                    uketsukeDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    uketsukeDtFromDateTimePicker.Enabled = false;
                    uketsukeDtToDateTimePicker.Enabled = false;
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

        #region includeOutputFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： includeOutputFlgCheckBox_CheckedChanged
        /// <summary>
        /// 出力済みを含めるチェックボックス変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void includeOutputFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (includeOutputFlgCheckBox.Checked)
                {
                    outputDtAddFlgCheckBox.Enabled = true;
                    outputDtFromDateTimePicker.Enabled = outputDtAddFlgCheckBox.Checked;
                    outputDtToDateTimePicker.Enabled = outputDtAddFlgCheckBox.Checked;
                }
                else
                {
                    outputDtAddFlgCheckBox.Enabled = false;
                    outputDtFromDateTimePicker.Enabled = false;
                    outputDtToDateTimePicker.Enabled = false;
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

        #region outputDtAddFlgCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputDtAddFlgCheckBox_CheckedChanged
        /// <summary>
        /// 出力日チェックボックス変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputDtAddFlgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (outputDtAddFlgCheckBox.Checked)
                {
                    outputDtFromDateTimePicker.Enabled = true;
                    outputDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    outputDtFromDateTimePicker.Enabled = false;
                    outputDtToDateTimePicker.Enabled = false;
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
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
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
                
        #endregion

        #region メソッド(private)

        #region SetDefaultDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultDisplayControl
        /// <summary>
        /// 検索条件の初期化
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultDisplayControl()
        {
            kensaKbnComboBox.SelectedIndex = 0;

            shisyoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            uketsukeNoFromTextBox.Text = string.Empty;

            uketsukeNoToTextBox.Text = string.Empty;

            uketsukeDtAddFlgCheckBox.Checked = true;

            uketsukeDtFromDateTimePicker.Value = _now.Date;

            uketsukeDtToDateTimePicker.Value = _now.Date;

            includeOutputFlgCheckBox.Checked = false;

            outputDtAddFlgCheckBox.Checked = false;

            outputDtFromDateTimePicker.Value = _now.Date;

            outputDtFromDateTimePicker.Enabled = false;

            outputDtToDateTimePicker.Value = _now.Date;
            
            outputDtToDateTimePicker.Enabled = false;
        }
        #endregion
        
        #region IsValidInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsValidInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsValidInput()
        {
            string errMsg = string.Empty;
            
            // 受付番号
            if (!string.IsNullOrEmpty(uketsukeNoFromTextBox.Text) && !string.IsNullOrEmpty(uketsukeNoToTextBox.Text))
            {
                decimal uketsukeNoFrom = decimal.Parse(uketsukeNoFromTextBox.Text);
                decimal uketsukeNoTo = decimal.Parse(uketsukeNoToTextBox.Text);

                if (uketsukeNoFrom > uketsukeNoTo)
                {
                    errMsg += "範囲指定が正しくありません。受付番号の大小関係を確認してください。";
                }
            }

            // 受付日
            if (uketsukeDtAddFlgCheckBox.Checked)
            {
                int uketsukeDtFrom = Convert.ToInt32(uketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd"));
                int uketsukeDtTo = Convert.ToInt32(uketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd"));

                if (uketsukeDtFrom > uketsukeDtTo)
                {
                    errMsg += "範囲指定が正しくありません。受付日の大小関係を確認してください。";
                }
            }

            // 出力日
            if (includeOutputFlgCheckBox.Checked && outputDtAddFlgCheckBox.Checked)
            {
                int outputDtFrom = Convert.ToInt32(outputDtFromDateTimePicker.Value.ToString("yyyyMMdd"));
                int outputDtTo = Convert.ToInt32(outputDtToDateTimePicker.Value.ToString("yyyyMMdd"));

                if (outputDtFrom > outputDtTo)
                {
                    errMsg += "範囲指定が正しくありません。出力日の大小関係を確認してください。";
                }
            }

            if (!string.IsNullOrEmpty(errMsg))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg);
                return false;
            }

            return true;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // 検索結果一覧をクリア
            suishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeList.Clear();

            ISearchBtnClickALInput alInput = new SearchBtnClickALInput();

            #region 検索条件パラメータ設定

            if (kensaKbnComboBox.SelectedIndex > 0)
            {
                alInput.kensaKbn = kensaKbnComboBox.SelectedValue.ToString();
            }
            else
            {
                alInput.kensaKbn = string.Empty;
            }
            
            alInput.shishoCd = shisyoComboBox.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(uketsukeNoFromTextBox.Text))
            {
                alInput.uketsukeNoFrom = string.Format("{0:000000}", decimal.Parse(uketsukeNoFromTextBox.Text));
            }
            else
            {
                alInput.uketsukeNoFrom = string.Empty;
            }

            if (!string.IsNullOrEmpty(uketsukeNoToTextBox.Text))
            {
                alInput.uketsukeNoTo = string.Format("{0:000000}", decimal.Parse(uketsukeNoToTextBox.Text));
            }
            else
            {
                alInput.uketsukeNoTo = string.Empty;
            }

            if (uketsukeDtAddFlgCheckBox.Checked)
            {
                alInput.uketsukeDateFrom = uketsukeDtFromDateTimePicker.Value;
                alInput.uketsukeDateTo = uketsukeDtToDateTimePicker.Value;
            }
            else
            {
                alInput.uketsukeDateFrom = null;
                alInput.uketsukeDateTo = null;
            }

            alInput.includeOutput = includeOutputFlgCheckBox.Checked;

            if (includeOutputFlgCheckBox.Checked && outputDtAddFlgCheckBox.Checked)
            {
                alInput.outputDateFrom = outputDtFromDateTimePicker.Value;
                alInput.outputDateTo = outputDtToDateTimePicker.Value;
            }
            else
            {
                alInput.outputDateFrom = null;
                alInput.outputDateTo = null;
            }

            #endregion

            ISearchBtnClickALOutput alOutput = new SearchBtnClickApplicationLogic().Execute(alInput);

            srhListCountLabel.Text = alOutput.KensaIraiUketsukeList.Count + "件";

            if (alOutput.KensaIraiUketsukeList.Count == 0)
            {
                // データなしの場合は出力させない
                outputButton.Enabled = false;

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                suishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeList.Merge(alOutput.KensaIraiUketsukeList);

                outputButton.Enabled = true;
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
        /// 2014/10/06　豊田　　    新規作成
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
            DataTable kensaKbnData = Common.Common.GetConstTable(KENSA_CONST_KBN);
            Utility.Utility.SetComboBoxList(kensaKbnComboBox, kensaKbnData, "ConstNm", "ConstValue", true);

            // 出力ファイル名
            foreach (DataRow row in kensaKbnData.Rows)
            {
                string kensaKbn = row["ConstValue"].ToString();

                if (outputFilenameList.ContainsKey(kensaKbn))
                {
                    continue;
                }

                switch (kensaKbn)
                {
                    case KENSA_KBN_SUISHITSU:
                        // 水質検査
                        outputFilenameList.Add(kensaKbn, Common.Common.GetConstValue(FILENAME_CONST_KBN, "002"));
                        break;

                    case KENSA_KBN_KEIRYOU:
                        // 計量証明
                        outputFilenameList.Add(kensaKbn, Common.Common.GetConstValue(FILENAME_CONST_KBN, "001"));
                        break;
                }
            }

            // 出力ディレクトリ
            DataTable outputDirData = Common.Common.GetConstTable(OUTPUTPATH_CONST_KBN);
            
            foreach (DataRow row in outputDirData.Rows)
            {
                // ディレクトリの作成
                DirectoryInfo csvOutput = new DirectoryInfo(row["ConstValue"].ToString());
                csvOutput.Create();

                outputDirectoryList.Add(row["ConstValue"].ToString(), row["ConstNm"].ToString());
            }

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

            // 支所
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", false);
        }
        #endregion

        #region CreateHHTLOG
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHHTLOG
        /// <summary>
        /// HHT転送データの作成(検査区分ごとに作成する)
        /// 区切り文字、出力のフォーマットもここで設定する
        /// </summary>
        /// <param name="kensaKbn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraishoDataSet.HHTLOGDataTable CreateHHTLOG(string kensaKbn)
        {
            KensaIraishoDataSet.HHTLOGDataTable datatable = new KensaIraishoDataSet.HHTLOGDataTable();
            
            foreach (SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListRow row in suishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeList)
            {
                if (row.IraiUketsukeKensaKbn != kensaKbn)
                {
                    continue;
                }

                KensaIraishoDataSet.HHTLOGRow newRow = datatable.NewHHTLOGRow();

                // 入力日(西暦8桁)
                newRow.HTDATE = row.InsertDt.ToString("yyyyMMdd");
                // 区切り文字
                newRow.FILLER1 = HHTLOG_SEPARATOR;
                // 入力時刻(時)
                newRow.HTHH = row.InsertDt.ToString("HH");
                // 入力時刻(分)
                newRow.HTMM = row.InsertDt.ToString("mm");
                // 区切り文字
                newRow.FILLER2 = HHTLOG_SEPARATOR;
                // 入力時刻(秒)
                newRow.HTSS = row.InsertDt.ToString("ss");
                // 区切り文字
                newRow.FILLER3 = HHTLOG_SEPARATOR;
                // 担当者
                newRow.HTTID = string.Empty.PadLeft(datatable.HTTIDColumn.MaxLength, '0');
                // 区切り文字
                newRow.FILLER4 = HHTLOG_SEPARATOR;
                // ITFコード 設置者ＣＤ
                newRow.HTITF = row.IraiUketsukeBarCd;
                // 区切り文字
                newRow.FILLER5 = HHTLOG_SEPARATOR;
                // 依頼No.
                newRow.HTIRNO = row.IraiUketsukeNo;
                
                // 行を挿入
                datatable.AddHHTLOGRow(newRow);
            }

            return datatable;
        }
        #endregion

        #region CreateUpdateCsvOutputDt
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateUpdateCsvOutputDt
        /// <summary>
        /// 更新データの作成（CSV出力日時の更新）
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuIraiUketsukeWrkDataSet.UpdateCsvOutputDtDataTable CreateUpdateCsvOutputDt()
        {
            SuishitsuIraiUketsukeWrkDataSet.UpdateCsvOutputDtDataTable datatable = new SuishitsuIraiUketsukeWrkDataSet.UpdateCsvOutputDtDataTable();

            // 現在日時の取得
            DateTime procDate = Common.Common.GetCurrentTimestamp();

            foreach (SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListRow row in suishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeList)
            {
                SuishitsuIraiUketsukeWrkDataSet.UpdateCsvOutputDtRow newRow = datatable.NewUpdateCsvOutputDtRow();

                // 検査区分
                newRow.IraiUketsukeKensaKbn = row.IraiUketsukeKensaKbn;
                // 支所コード
                newRow.IraiUketsukeShishoCd = row.IraiUketsukeShishoCd;
                // 年度
                newRow.IraiUketsukeNendo = row.IraiUketsukeNendo;
                // 受付番号
                newRow.IraiUketsukeNo = row.IraiUketsukeNo;
                // CSV出力日時
                newRow.IraiUketsukeCsvOutputDt = procDate;
                // 更新日
                newRow.UpdateDt = procDate;
                // 更新ユーザ
                newRow.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                // 更新端末
                newRow.UpdateTarm = Dns.GetHostName();

                // 行を挿入
                datatable.AddUpdateCsvOutputDtRow(newRow);
                // 行の状態を設定
                newRow.AcceptChanges();
                // 行の状態を設定（更新）
                newRow.SetModified();
            }

            return datatable;
        }
        #endregion
        
        #region ExportCSVFromDataGridView
        ///////////////////////////////////////////////////////////////
        /// メソッド：ExportCSVFromDataGridView
        /// <summary>
        /// ExportCSVFromDataTable
        /// </summary>
        /// <param name="hhtlog"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void ExportCSV(KensaIraishoDataSet.HHTLOGDataTable hhtlog, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KensaIraishoDataSet.HHTLOGRow row in hhtlog)
            {
                for (int colIndex = 0; colIndex < hhtlog.Columns.Count; colIndex++)
                {
                    // 区切り文字はレコードにセットしているので、ここでは文字列結合のみ行う
                    sb.Append(row[colIndex].ToString());
                }

                sb.AppendLine();
            }

            // 上書き
            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.Write(sb.ToString());
            }
        }
        #endregion
                
        #endregion
    }
    #endregion
}
