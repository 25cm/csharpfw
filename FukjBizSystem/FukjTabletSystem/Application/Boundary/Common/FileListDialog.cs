using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// ファイル一覧選択ダイアログ
    /// </summary>
    public partial class FileListDialog : FukjTabBaseDialog
    {
        /// <summary>
        /// ファイルディレクトリルート
        /// </summary>
        private string rootPath;

        /// <summary>
        /// 表示ファイルリスト
        /// </summary>
        private FileListDataSet.FileListDataTable fileList = new FileListDataSet.FileListDataTable();

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// </summary>
        /// <param name="RootPath"></param>
        /// <param name="FileList"></param>
        public FileListDialog(string RootPath, FileListDataSet.FileListDataTable FileList)
        {
            InitializeComponent();

            rootPath = RootPath;

            fileList = FileList;

            // 一覧表示を太字にする
            fileListDataGridView.Font = new System.Drawing.Font(fileListDataGridView.Font.FontFamily, fileListDataGridView.Font.Size, System.Drawing.FontStyle.Bold);
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

                foreach (FileListDataSet.FileListRow row in fileList)
                {
                    // ファイル名の抽出
                    row.FileName = row.FilePath.Substring(row.FilePath.LastIndexOf('\\') + 1);
                    // 一覧に追加
                    fileListDataSet.FileList.ImportRow(row);
                }
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

        #region fileListDataGridView_CellClick
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ファイル一覧のセルクリック
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void fileListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダーのクリックは処理しない
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridView dgv = (DataGridView)sender;

            // 対象項目判定
            if (dgv.Columns[e.ColumnIndex].Name == "Selected")
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
                Cursor preCursor = Cursor.Current;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string filePath = Path.Combine(rootPath, fileListDataSet.FileList[e.RowIndex].FilePath);

                    // ファイルを開く
                    Process proc = new Process();
                    proc.StartInfo.FileName = filePath;
                    proc.Start();
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
        }
        #endregion

        #region fileListDataGridView_CellFormatting
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ファイル一覧のチェックボックス表示変換
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void fileListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // 対象項目判定
            if (dgv.Columns[e.ColumnIndex].Name == "Selected")
            {
                e.Value = "開く";
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

        #endregion
    }
}
