using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensainBetsuKensaYotei;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensainBetsuKensaYoteiPrintForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　habu        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensainBetsuKensaYoteiPrintForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensainBetsuKensaYoteiPrintForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26　habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensainBetsuKensaYoteiPrintForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KensainBetsuKensaYoteiPrintForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensainBetsuKensaYoteiPrintForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26　habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensainBetsuKensaYoteiPrintForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ロググインユーザ情報
                ShokuinMstDataSet.ShokuinMstRow shokuin = ShokuinInfo.GetShokuinInfo().Shokuin;

                // 検査員一覧取得
                {
                    DataTable table = MstUtility.ShokuinMst.GetShokuinMstByShishoCdOrderKensain(shokuin.ShokuinShozokuShishoCd);
                    Utility.Utility.SetComboBoxList(kensainComboBox, table, "ShokuinNm", "ShokuinCd", true);
                }

                // ログインユーザを初期値として設定
                kensainComboBox.SelectedValue = shokuin.ShokuinCd;

                kensaYoteiDtInputDataTimePicker.Value = _currentDateTime;
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
        /// 2014/12/26　habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(TypeUtility.GetString(kensainComboBox.SelectedValue)))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Warning, "担当検査員を選択してください。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査員別検査予定一覧を印刷します。よろしいですか？") != DialogResult.Yes) return;

                // 出力処理起動
                IPrintBtnClickALInput input = new PrintBtnClickALInput();
                input.KensaYoteiDate = kensaYoteiDtInputDataTimePicker.Value;
                input.KensainCd = (string)kensainComboBox.SelectedValue;

                IPrintBtnClickALOutput output = new PrintBtnClickApplicationLogic().Execute(input);

                if (!string.IsNullOrEmpty(output.ErrMessage))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Warning, output.ErrMessage);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

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
        /// 2014/12/26　habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
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

        #region KensainBetsuKensaYoteiPrintForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensainBetsuKensaYoteiPrintForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26　habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensainBetsuKensaYoteiPrintForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        printButton.PerformClick();
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

    }
    #endregion
}
