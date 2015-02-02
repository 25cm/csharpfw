using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.ApplicationLogic.WorkList.CenterKeikoku;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.BusinessLogic.WorkList.CenterKeikoku;

namespace FukjBizSystem.Application.Boundary.WorkList
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CenterKeikokuForm
    /// <summary>
    /// センター警告画面
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class CenterKeikokuForm : FukjBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CenterKeikokuForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CenterKeikokuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region CenterKeikokuForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CenterKeikokuForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// 2015/01/27  宗          取得する支所マスタを全件から事務局以外に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CenterKeikokuForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

                // 支所
                //Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstDT, "ShishoNm", "ShishoCd", false);
                //shishoComboBox.SelectedValue = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
                Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDT, "ShishoNm", "ShishoCd", true);
                if (ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd == "0")
                {
                    shishoComboBox.SelectedIndex = 0;
                }
                else
                {
                    shishoComboBox.SelectedValue = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
                }

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

        #region CenterKeikokuForm_KeyDown(object sender, KeyEventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CenterKeikokuForm_KeyDown
        /// <summary>
        /// キーダウン（ショートカット）
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CenterKeikokuForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F5:
                        refleshButton.PerformClick();
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

        #region refleshButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： refleshButton_Click
        /// <summary>
        /// 再読み込みボタン押下
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void refleshButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 再検索
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
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // 画面を終了（前画面に戻る）
                this.DialogResult = DialogResult.Cancel;
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

        #region shishoComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shishoComboBox_SelectionChangeCommitted
        /// <summary>
        /// 支所選択変更
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者    内容
        /// 2014/12/23  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shishoComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 再検索
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
        
        #endregion

        #region メソッド(private)

        #region DoSearch()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/23  豊田      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                // 描画を停止
                centerKeikokuDataGridView.SuspendLayout();

                centerKeikokuDataSet.CenterKeikokuList.Clear();
                centerKeikokuDataSet.Miwariate11JoList.Clear();
                centerKeikokuDataSet.Miwariate7JoList.Clear();

                IGetCenterKeikokuALInput alInput = new GetCenterKeikokuALInput();

                alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();

                IGetCenterKeikokuALOutput alOutput = new GetCenterKeikokuApplicationLogic().Execute(alInput);

                centerKeikokuDataSet.CenterKeikokuList.Merge(alOutput.CenterKeikokuListDataTable);
                centerKeikokuDataSet.Miwariate11JoList.Merge(alOutput.Miwariate11JoListDataTable);
                centerKeikokuDataSet.Miwariate7JoList.Merge(alOutput.Miwariate7JoListDataTable);


                // 警告！
                CenterKeikokuDataSet.CenterKeikokuListRow myKeikoku = centerKeikokuDataSet.CenterKeikokuList.FindByTantoshaCd(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd);

                if (myKeikoku == null)
                {
                    mikanKeikokuTextBox.Text = "0";
                    mijisshiKeikokuTextBox.Text = "0";
                    horyuKeikokuTextBox.Text = "0";
                }
                else
                {
                    mikanKeikokuTextBox.Text = myKeikoku.Mikanryo.ToString();
                    mijisshiKeikokuTextBox.Text = myKeikoku.Mijisshi.ToString();
                    horyuKeikokuTextBox.Text = myKeikoku.Horyu7Jo.ToString();
                }
                
                // センター警告！
                int mikan = 0;
                int mijisshi = 0;
                int horyu = 0;
                foreach (CenterKeikokuDataSet.CenterKeikokuListRow row in centerKeikokuDataSet.CenterKeikokuList)
                {
                    mikan += row.Mikanryo;
                    mijisshi += row.Mijisshi;
                    horyu += row.Horyu7Jo;
                }

                mikanCenterTextBox.Text = mikan.ToString();
                mijisshiCenterTextBox.Text = mijisshi.ToString();
                horyuCenterTextBox.Text = horyu.ToString();

                // 担当者未設定！

                // 当年度
                CenterKeikokuDataSet.Miwariate11JoListRow tounen = centerKeikokuDataSet.Miwariate11JoList.FindByKensaIraiNendo(Common.Common.ConvertToHoshouNendoWareki(Common.Common.GetCurrentTimestamp().ToString("yyyy")));
                misettei11JoTonenTextBox.Text = tounen == null ? "0" : tounen.KeikokuCount.ToString();
                
                // 翌年度
                CenterKeikokuDataSet.Miwariate11JoListRow yokunen = centerKeikokuDataSet.Miwariate11JoList.FindByKensaIraiNendo(Common.Common.ConvertToHoshouNendoWareki(Common.Common.GetCurrentTimestamp().AddYears(1).ToString("yyyy")));
                misettei11JoYokunenTextBox.Text = yokunen == null ? "0" : yokunen.KeikokuCount.ToString();
                
                // 7条検査
                misettei7JoTextBox.Text = centerKeikokuDataSet.Miwariate7JoList.Count == 0 ? "0" : centerKeikokuDataSet.Miwariate7JoList[0].KeikokuCount.ToString();

            }
            finally
            {
                // 描画再開
                centerKeikokuDataGridView.ResumeLayout();
            }
        }
        #endregion
        
        #endregion
    }
    #endregion
}
