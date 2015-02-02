using System;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// 日付選択ダイアログ
    /// </summary>
    public partial class SelectDateDialog : FukjTabBaseDialog
    {
        #region フィールド（private）

        /// <summary>
        /// 選択した日付
        /// </summary>
        private DateTime? selectDate = null;

        #endregion

        #region プロパティ

        /// <summary>
        /// 選択した日付
        /// </summary>
        /// <returns></returns>
        public DateTime? SelectedDate
        {
            get { return selectDate; }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// </summary>
        public SelectDateDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region Form_Load(object sender, EventArgs e)
        /// <summary>
        /// [Form_Load]イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                yearNumericUpDown.Value = DateTime.Today.Year;

                monthNumericUpDown.Value = DateTime.Today.Month;

                dayNumericUpDown.Value = DateTime.Today.Day;

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region closeButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region ketteiButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 決定ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ketteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    selectDate = new DateTime((int)yearNumericUpDown.Value, (int)monthNumericUpDown.Value, (int)dayNumericUpDown.Value);
                }
                catch
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "不正な日付です。");
                    return;
                }

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
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
