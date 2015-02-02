using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using System.Data;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyokenKekkaSelectForm
    /// <summary>
    /// 所見手入力ダイアログ
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/03  AnhNV        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SyokenManualInputForm : FukjBaseForm
    {
        #region クラス定義
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： ShokenManualResult
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public class ShokenManualResult
        {
            /// <summary>
            /// 所見入力
            /// </summary>
            public string ShokenWd { get; set; }

            /// <summary>
            /// 挿入位置
            /// </summary>
            public string InsertPosition { get; set; }
            
            /// <summary>
            /// チェック項目No
            /// </summary>
            public string CheckItemNo { get; set; }
            
            /// <summary>
            /// 指摘箇所
            /// </summary>
            public string ShitekiKasyoNo { get; set; }

            /// <summary>
            /// 判断
            /// </summary>
            public string Handan { get; set; }
        }
        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 処理方式区分
        /// </summary>
        private string _shorihoshikiKbn;

        /// <summary>
        /// 処理対象人員
        /// </summary>
        private string _kensaIraiShoritaishoJinin;

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// ShokenManualResult
        /// </summary>
        public ShokenManualResult _shokenManualResult = new ShokenManualResult();

        #endregion

        //#region コンストラクタ
        //////////////////////////////////////////////////////////////////////////////
        ////  コンストラクタ名 ： SyokenManualInputForm
        ///// <summary>
        ///// コンストラクタ
        ///// </summary>
        ///// <remarks>
        ///// 
        ///// </remarks>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/03  AnhNV        新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //public SyokenManualInputForm()
        //{
        //    InitializeComponent();
        //    gappeiPanel.Location = bakkiGataPanel.Location;
        //    syokiboGappeiPanel.Location = bakkiGataPanel.Location;
        //}
        //#endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SyokenManualInputForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="shorihoshikiKbn"></param>
        /// <param name="kensaIraiShoritaishoJinin"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03  AnhNV        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SyokenManualInputForm(string shorihoshikiKbn, string kensaIraiShoritaishoJinin)
        {
            InitializeComponent();
            gappeiPanel.Location = bakkiGataPanel.Location;
            syokiboGappeiPanel.Location = bakkiGataPanel.Location;
            
            this._shorihoshikiKbn = shorihoshikiKbn;
            this._kensaIraiShoritaishoJinin = kensaIraiShoritaishoJinin;
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
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SyokenManualInputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default value
                DoFormLoad();
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

        #region SyokenManualInputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SyokenManualInputForm_KeyDown
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
        private void SyokenManualInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        torokuButton.Focus();
                        torokuButton.PerformClick();
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

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
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
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 所見入力(1)
                syokenWdTextBox.Text = string.Empty;
                // 挿入位置(2)
                insertPositionTextBox.Text = string.Empty;
                // チェック項目No(3)
                checkItemNoTextBox.Text = string.Empty;
                // 指摘箇所(4)
                shitekiKasyoNoComboBox.SelectedIndex = 0;
                // 判断(5)
                handanComboBox.SelectedIndex = 0;
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
        /// 2014/11/03　AnhNV　　    新規作成
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
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
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単項目チェック
                if (!UnitCheck()) return;

                // 所見手書き
                _shokenManualResult.ShokenWd = syokenWdTextBox.Text.Trim();
                // 挿入位置
                _shokenManualResult.InsertPosition = insertPositionTextBox.Text.Trim();
                // チェック項目
                _shokenManualResult.CheckItemNo = checkItemNoTextBox.Text.Trim();
                // 指摘箇所
                _shokenManualResult.ShitekiKasyoNo = null == shitekiKasyoNoComboBox.SelectedValue ? string.Empty : shitekiKasyoNoComboBox.SelectedValue.ToString();
                // 判定
                _shokenManualResult.Handan = null == handanComboBox.SelectedValue ? string.Empty : handanComboBox.SelectedValue.ToString();

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
        /// 2014/11/03  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // 指摘箇所コンボボックス設定
            DataTable table14 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_014);
            Utility.Utility.SetComboBoxList(shitekiKasyoNoComboBox, table14, "ConstNm", "ConstValue", true);
            // 判断コンボボックス設定
            DataTable table25 = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_025);
            Utility.Utility.SetComboBoxList(handanComboBox, table25, "ConstNm", "ConstValue", true);

            // Control the display of image panels
            switch (_shorihoshikiKbn)
            {
                case "1": // 単独パネル
                    bakkiGataPanel.Visible = true;
                    gappeiPanel.Visible = false;
                    syokiboGappeiPanel.Visible = false;
                    break;
                case "2": // 合併パネル
                    bakkiGataPanel.Visible = false;
                    gappeiPanel.Visible = true;
                    syokiboGappeiPanel.Visible = false;
                    break;
                case "3": // 小規模合併パネル
                    bakkiGataPanel.Visible = false;
                    gappeiPanel.Visible = false;
                    syokiboGappeiPanel.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region UnitCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UnitCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03  AnhNV　　    新規作成
        /// 2014/12/28  小松　　　　メッセージを解りやすく修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            // 挿入位置(2)
            int position = Convert.ToInt32(string.IsNullOrEmpty(insertPositionTextBox.Text) ? "0" : insertPositionTextBox.Text);
            if (position > 30 || position < 1)
            {
                errMsg.AppendLine("挿入位置は 1から30の数値で入力して下さい。[挿入位置]");
            }

            // チェック項目No(3)
            if (string.IsNullOrEmpty(checkItemNoTextBox.Text))
            {
                // 判断(5) = [-]
                if (handanComboBox.Text == "－")
                {
                    errMsg.AppendLine("チェック項目番号が未入力で、判断の選択が「－」です。[チェック項目No]");
                }
            }
            else
            {
                int itemNo = Convert.ToInt32(checkItemNoTextBox.Text);

                if (itemNo >= 99 && handanComboBox.SelectedIndex == 0)
                {
                    errMsg.AppendLine("チェック項目Noが入力され、判断が未選択です。[判断]");
                }
                else if (itemNo < 1 || itemNo > 75)
                {
                    errMsg.AppendLine("チェック項目Noは 1から75の数値で入力して下さい。[チェック項目No]");
                }
            }

            // 指摘箇所(4)
            int jinin;
            Int32.TryParse(_kensaIraiShoritaishoJinin, out jinin);
            if (jinin >= 50 && !string.IsNullOrEmpty(Convert.ToString(shitekiKasyoNoComboBox.SelectedValue)))
            {
                errMsg.AppendLine("処理対象人員が 50人槽以上の場合、指摘箇所は空白を選択して下さい。[指摘箇所]");
            }

            // An error occurred?
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #endregion
    }
    #endregion
}
