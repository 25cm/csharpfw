using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using Zynas.Control.Common;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BatchInputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class BatchInputForm : FukjBaseForm
    {
        #region プロパティ(public)

        /// <summary>
        /// 受付区分－持込フラグ
        /// </summary>
        public bool MochikomiFlg = true;

        /// <summary>
        /// 受付区分－収集フラグ
        /// </summary>
        public bool ShushuFlg = false;

        /// <summary>
        /// 採水員コード
        /// </summary>
        public string SaisuiinCd = string.Empty;

        /// <summary>
        /// 採水員名称
        /// </summary>
        public string SaisuiinNm = string.Empty;

        /// <summary>
        /// 残留塩素
        /// </summary>
        public string ZanryuEnso = string.Empty;

        #endregion

        #region プロパティ(private)

        // 水質検査区分
        private string _suishitsuKensaKbn = string.Empty;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： BatchInputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public BatchInputForm(string suishitsuKensaKbn)
        {
            InitializeComponent();

            // 水質検査区分
            _suishitsuKensaKbn = suishitsuKensaKbn;
        }
        #endregion

        #region イベント

        #region BatchInputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BatchInputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BatchInputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 持込フラグを初期設定
                motikomiRadioButton.Checked = true;

                if (_suishitsuKensaKbn == "1")
                {
                    // 計量証明時は残留塩素は非表示
                    label7.Visible = false;
                    label8.Visible = false;
                    zanryuEnsoTextBox.Visible = false;
                }

                // 各コントロールのドメイン設定
                setControlDomain();
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

        #region haneiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： haneiButton_Click
        /// <summary>
        /// 反映ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void haneiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 受付区分－持込フラグ
                MochikomiFlg = motikomiRadioButton.Checked;
                // 受付区分－収集フラグ
                ShushuFlg = shushuRadioButton.Checked;
                // 採水員コード
                SaisuiinCd = saisuiinCdTextBox.Text;
                // 採水員名称
                SaisuiinNm = saisuiinNmTextBox.Text;
                // 残留塩素
                ZanryuEnso = string.Empty;
                if (_suishitsuKensaKbn == "2")
                {
                    // 水質時は残留塩素セット
                    decimal enso = 0;
                    if (Decimal.TryParse(zanryuEnsoTextBox.Text, out enso))
                    {
                        // 正常値のみセット
                        ZanryuEnso = zanryuEnsoTextBox.Text;
                    }
                }

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

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region saisuiinSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinSearchButton_Click
        /// <summary>
        /// 採水員検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
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

        #region saisuiinSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinSearchButton_Click
        /// <summary>
        /// 採水員テキストボックスのロストフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150128 sou Start 採水員コードの0埋め
                saisuiinCdTextBox.Text = saisuiinCdTextBox.Text.PadLeft(5, '0');
                // 20150128 sou End

                if (string.IsNullOrEmpty(saisuiinCdTextBox.Text))
                {
                    // 未選択なら名称は空文字
                    saisuiinNmTextBox.Text = string.Empty;
                }
                else
                {
                    // 採水員コードから検索した名称
                    SaisuiinMstDataSet.SaisuiinMstDataTable saisuiinMstDT = Common.Common.GetSaisuiinMstByKey(saisuiinCdTextBox.Text);
                    if (saisuiinMstDT.Rows.Count > 0)
                    {
                        // 該当ありなら採水員名称セット
                        SaisuiinMstDataSet.SaisuiinMstRow saisuiinMstRow = saisuiinMstDT[0];
                        saisuiinNmTextBox.Text = saisuiinMstRow.SaisuiinNm;
                    }
                    else
                    {
                        // 該当なしなら名称は空文字
                        saisuiinNmTextBox.Text = string.Empty;
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

        #region BatchInputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BatchInputForm_KeyDown
        /// <summary>
        /// フォームキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BatchInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        haneiButton.Focus();
                        haneiButton.PerformClick();
                        break;
                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #endregion

        #region メソッド

        #region setControlDomain
        // 各コントロールのドメイン設定
        private void setControlDomain()
        {
            // 採水員コード
            saisuiinCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);
            // 残留塩素
            zanryuEnsoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 2, InputValidateUtility.SignFlg.Positive);
        }
        #endregion

        #endregion
    }
    #endregion
}
