using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ImageImportForm
    /// <summary>
    /// 現場写真一覧ダイアログ
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ImageImportForm : FukjBaseForm
    {
        #region フィールド（private)

        #region パラメータ

        /// <summary>
        /// 画像ファイルディレクトリ
        /// </summary>
        private string _fileDirectory;

        /// <summary>
        /// 検査開始日時
        /// </summary>
        private DateTime? _startDate;

        /// <summary>
        /// 検査終了日時
        /// </summary>
        private DateTime? _endDate;
        
        /// <summary>
        /// 選択されたファイル
        /// </summary>
        private List<string> _selectedFiles = new List<string>();
                
        #endregion

        #endregion

        #region プロパティ

        /// <summary>
        /// 選択されたファイル
        /// </summary>
        public List<string> SelectedFiles
        {
            get { return _selectedFiles; }
        }

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ImageImportForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="fileDirectory"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ImageImportForm(string fileDirectory, DateTime? startDate, DateTime? endDate)
        {
            InitializeComponent();

            _fileDirectory = fileDirectory;

            _startDate = startDate;

            _endDate = endDate;
        }
        #endregion

        #region イベント

        #region ImageImportForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ImageImportForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ImageImportForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                FileInfo[] fileInfos = new DirectoryInfo(_fileDirectory).GetFiles();

                for (int i = 0; i < fileInfos.Length; i++)
                {
                    bool selected = (_startDate.HasValue && _endDate.HasValue && fileInfos[i].CreationTime >= _startDate && fileInfos[i].CreationTime <= _endDate) ? true : false;
                    ImageImportListDataGridView.Rows.Add(selected, fileInfos[i].Name, fileInfos[i].CreationTime.ToString("yyyy/MM/dd HH:mm:ss"), fileInfos[i].FullName);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

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

        #region ImageImportForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ImageImportForm_KeyDown
        /// <summary>
        /// ファンクションキー制御
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ImageImportForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        entryButton.PerformClick();
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

        #region entryButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： entryButton_Click
        /// <summary>
        /// 追加ボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _selectedFiles.Clear();

                foreach (DataGridViewRow row in ImageImportListDataGridView.Rows)
                {
                    if ((bool)row.Cells[Checked.Index].Value)
                    {
                        _selectedFiles.Add(row.Cells[FilePath.Index].Value.ToString());
                    }
                }

                if (_selectedFiles.Count == 0)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
        
        #region ImageImportListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ImageImportListDataGridView_CellDoubleClick
        /// <summary>
        /// 一覧のセルダブルクリック
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ImageImportListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダーのクリックは処理しない
            if (e.RowIndex < 0)
            {
                return;
            }

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ファイルを開く
                Process proc = new Process();
                proc.StartInfo.FileName = ImageImportListDataGridView.Rows[e.RowIndex].Cells[FilePath.Index].Value.ToString();
                proc.Start();
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
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
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
