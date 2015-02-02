using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.WorkList;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common.SubMenu
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： WorkListMenuForm
    /// <summary>
    /// サブメニュー画面（作業一覧）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class workListMenuForm : FukjBaseForm
    {
        #region 定数（private）

        /// <summary>
        /// メニュー番号０：センター警告
        /// </summary>
        private const int MENU_INDEX_CENTER_WARN = 1;

        /// <summary>
        /// メニュー番号１：作業一覧
        /// </summary>
        private const int MENU_INDEX_SAGYO_LIST = 2;
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： WorkListMenuForm
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
        public workListMenuForm()
        {
            InitializeComponent();
        }
        #endregion

        #region workListMenuForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： workListMenuForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void workListMenuForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // メニューの設定
                WorkListDataGridView.Rows.Add(MENU_INDEX_CENTER_WARN, "センター警告", "詳細");
                WorkListDataGridView.Rows.Add(MENU_INDEX_SAGYO_LIST, "作業一覧", "詳細");

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
        
        #region WorkListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： WorkListDataGridView_CellContentClick
        /// <summary>
        /// グリッドメニューボタン押下
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
        private void WorkListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //"Shosai"列ならば、ボタンがクリックされた
            if (WorkListDataGridView.Columns[e.ColumnIndex].Name != Shosai.Name)
            {
                return;
            }

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                    switch ((int)(WorkListDataGridView.Rows[e.RowIndex].Cells[MenuIndex.Index].Value))
                    {
                        case MENU_INDEX_CENTER_WARN:

                            // センター警告画面を開く
                            CenterKeikokuForm frm = new CenterKeikokuForm();
                            Program.mForm.MoveNext(frm);

                            break;

                        case MENU_INDEX_SAGYO_LIST:

                            MessageBox.Show("作業一覧がクリックされました");

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
    }
    #endregion
}
