using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common.GenbaShashinList;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Properties;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenbaShashinListForm
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
    public partial class GenbaShashinListForm : FukjBaseForm
    {
        #region フィールド（private)

        #region 検査依頼のキー

        private string _iraiHoteiKbn;

        private string _iraiHokenjoCd;

        private string _iraiNendo;

        private string _iraiRenban;
        
        #endregion

        /// <summary>
        /// 検査開始日時
        /// </summary>
        private DateTime? _startDate;

        /// <summary>
        /// 検査終了日時
        /// </summary>
        private DateTime? _endDate;

        #endregion
        
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GenbaShashinListForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="iraiHoteiKbn"></param>
        /// <param name="iraiHokenjoCd"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiRenban"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GenbaShashinListForm(string iraiHoteiKbn, string iraiHokenjoCd, string iraiNendo, string iraiRenban)
        {
            InitializeComponent();

            _iraiHoteiKbn = iraiHoteiKbn;
            _iraiHokenjoCd = iraiHokenjoCd;
            _iraiNendo = iraiNendo;
            _iraiRenban = iraiRenban;
        }
        #endregion

        #region イベント

        #region GenbaShashinListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GenbaShashinListForm_Load
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
        private void GenbaShashinListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                DoSearch();
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

        #region GenbaShashinListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GenbaShashinListForm_KeyDown
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
        private void GenbaShashinListForm_KeyDown(object sender, KeyEventArgs e)
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

                    case Keys.F3:
                        deleteButton.PerformClick();
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

                // フォルダ選択ダイアログ
                string ImportDir;
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "画像フォルダを選択してください。";
                    fbd.RootFolder = Environment.SpecialFolder.Desktop;

                    if (fbd.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }

                    ImportDir = fbd.SelectedPath;
                }

                // 画像取り込み画面起動
                using(ImageImportForm iif = new ImageImportForm(ImportDir, _startDate, _endDate))
                {
                    iif.ShowDialog(this);

                    if (iif.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        int renban = 0;

                        // 表示中の最大所見連番を取得
                        foreach (GenbaShashinListDataSet.GenbaShashinTblRow row in genbaShashinListDataSet.GenbaShashinTbl)
                        {
                            string tempRenban;
                            if (row.RowState == DataRowState.Deleted)
                            {
                                tempRenban = row["GenbaShashinCd", DataRowVersion.Original].ToString();
                            }
                            else
                            {
                                tempRenban = row.GenbaShashinCd;
                            }

                            renban = int.Parse(tempRenban) > renban ? int.Parse(tempRenban) : renban;
                        }
                        
                        // レコードの追加
                        foreach (string filePath in iif.SelectedFiles)
                        {
                            // 連番をカウントアップ
                            renban++;

                            GenbaShashinListDataSet.GenbaShashinTblRow newRow = genbaShashinListDataSet.GenbaShashinTbl.NewGenbaShashinTblRow();

                            newRow.GenbaShashinKensaHoteiKbn = _iraiHoteiKbn;
                            newRow.GenbaShashinKensaHokenjoCd = _iraiHokenjoCd;
                            newRow.GenbaShashinKensaNendo = _iraiNendo;
                            newRow.GenbaShashinKensaRenban = _iraiRenban;
                            newRow.GenbaShashinCd = string.Format("{0:000}", renban);

                            newRow.GenbaShashinFilePath = string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}",
                                _iraiHoteiKbn,
                                _iraiHokenjoCd, 
                                _iraiNendo, 
                                _iraiRenban, 
                                Settings.Default.GenbaShashinFileFolder, 
                                filePath.Substring(filePath.LastIndexOf('\\') + 1));
                                                        
                            newRow.InsertDt = DateTime.Now;
                            newRow.InsertTarm = Dns.GetHostName();
                            newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                            newRow.UpdateDt = DateTime.Now;
                            newRow.UpdateTarm = Dns.GetHostName();
                            newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                            genbaShashinListDataSet.GenbaShashinTbl.AddGenbaShashinTblRow(newRow);
                        }

                        IReflectGenbaShashinTblALInput alInput = new ReflectGenbaShashinTblALInput();

                        alInput.GenbaShashinTbl = CreateUpdateGenbaShashinTbl();
                        alInput.IraiHoteiKbn = _iraiHoteiKbn;
                        alInput.IraiHokenjoCd = _iraiHokenjoCd;
                        alInput.IraiNendo = _iraiNendo;
                        alInput.IraiRenban = _iraiRenban;

                        // 更新実行
                        new ReflectGenbaShashinTblApplicationLogic().Execute(alInput);

                        // ファイルのコピー
                        foreach (string filePath in iif.SelectedFiles)
                        {
                            FileUtility.CopyToServerFromLocalFile(string.Format("{0}\\{1}\\{2}\\{3}\\{4}\\{5}",
                                Settings.Default.ServerFileDirectory,
                                _iraiHoteiKbn,
                                _iraiHokenjoCd,
                                _iraiNendo,
                                _iraiRenban,
                                Settings.Default.GenbaShashinFileFolder), filePath, true);
                        }

                        // 自画面の更新
                        DoSearch();
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
        
        #region deleteButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 削除ボタン押下
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
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ファイルパスを退避
                string filePath = GenbaShashinListDataGridView.SelectedRows[0].Cells[genbaShashinFilePathDataGridViewTextBoxColumn.Index].Value.ToString();

                // 選択行をDelete
                genbaShashinListDataSet.GenbaShashinTbl.FindByGenbaShashinKensaHoteiKbnGenbaShashinKensaHokenjoCdGenbaShashinKensaNendoGenbaShashinKensaRenbanGenbaShashinCd
                    (GenbaShashinListDataGridView.SelectedRows[0].Cells[genbaShashinKensaHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString(),
                    GenbaShashinListDataGridView.SelectedRows[0].Cells[genbaShashinKensaHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString(),
                    GenbaShashinListDataGridView.SelectedRows[0].Cells[genbaShashinKensaNendoDataGridViewTextBoxColumn.Index].Value.ToString(),
                    GenbaShashinListDataGridView.SelectedRows[0].Cells[genbaShashinKensaRenbanDataGridViewTextBoxColumn.Index].Value.ToString(),
                    GenbaShashinListDataGridView.SelectedRows[0].Cells[genbaShashinCdDataGridViewTextBoxColumn.Index].Value.ToString()).Delete();

                IReflectGenbaShashinTblALInput alInput = new ReflectGenbaShashinTblALInput();

                alInput.GenbaShashinTbl = CreateUpdateGenbaShashinTbl();
                alInput.IraiHoteiKbn = _iraiHoteiKbn;
                alInput.IraiHokenjoCd = _iraiHokenjoCd;
                alInput.IraiNendo = _iraiNendo;
                alInput.IraiRenban = _iraiRenban;
                
                // 更新実行
                new ReflectGenbaShashinTblApplicationLogic().Execute(alInput);

                // ファイルの削除
                FileUtility.DeleteServerFile(Settings.Default.ServerFileDirectory, filePath);
                
                // 自画面の更新
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

        #region GenbaShashinListDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： GenbaShashinListDataGridView_CellDoubleClick
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
        private void GenbaShashinListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

                // ファイルをローカルの一時ディレクトリにコピーする
                string filePath = FileUtility.CopyToTempFromServer(Settings.Default.ServerFileDirectory,
                                                        Settings.Default.LocalTempDirectory, 
                                                        GenbaShashinListDataGridView.Rows[e.RowIndex].Cells[genbaShashinFilePathDataGridViewTextBoxColumn.Index].Value.ToString(),
                                                        true);
                // ファイルを開く
                Process proc = new Process();
                proc.StartInfo.FileName = filePath;
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

        #region メソッド(private)

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                // 描画を停止
                GenbaShashinListDataGridView.SuspendLayout();

                genbaShashinListDataSet.GenbaShashinTbl.Clear();

                IGetGenbaShashinTblALInput alInput = new GetGenbaShashinTblALInput();

                alInput.IraiHoteiKbn = _iraiHoteiKbn;
                alInput.IraiHokenjoCd = _iraiHokenjoCd;
                alInput.IraiNendo = _iraiNendo;
                alInput.IraiRenban = _iraiRenban;

                IGetGenbaShashinTblALOutput alOutput = new GetGenbaShashinTblApplicationLogic().Execute(alInput);

                genbaShashinListDataSet.GenbaShashinTbl.Merge(alOutput.GenbaShashinTbl);
                _startDate = alOutput.StartDate;
                _endDate = alOutput.EndDate;

                // 非バインディング列の編集
                foreach (DataGridViewRow row in GenbaShashinListDataGridView.Rows)
                {
                    // Ｎｏ
                    row.Cells[FileSeq.Index].Value = row.Cells[genbaShashinCdDataGridViewTextBoxColumn.Index].Value.ToString();

                    // ファイル名（ファイルパスよりファイル名部分を抽出）
                    string filePath = row.Cells[genbaShashinFilePathDataGridViewTextBoxColumn.Index].Value.ToString();
                    row.Cells[FileName.Index].Value = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                }

                if (alOutput.GenbaShashinTbl.Count == 0)
                {
                    deleteButton.Enabled = false;
                }
                else
                {
                    deleteButton.Enabled = true;
                }
            }
            finally
            {
                // 描画再開
                GenbaShashinListDataGridView.ResumeLayout();
            }
        }
        #endregion

        #region CreateUpdateGenbaShashinTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateUpdateGenbaShashinTbl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GenbaShashinTblDataSet.GenbaShashinTblDataTable CreateUpdateGenbaShashinTbl()
        {
            GenbaShashinTblDataSet.GenbaShashinTblDataTable datatable = new GenbaShashinTblDataSet.GenbaShashinTblDataTable();

            int fileseq = 1;

            foreach (GenbaShashinListDataSet.GenbaShashinTblRow row in genbaShashinListDataSet.GenbaShashinTbl)
            {
                // Delete→Insertを行うため、Delete行は処理しない
                if (row.RowState != System.Data.DataRowState.Deleted)
                {
                    GenbaShashinTblDataSet.GenbaShashinTblRow newRow = datatable.NewGenbaShashinTblRow();
                    
                    foreach (DataColumn col in datatable.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName];
                    }

                    // 連番のみ付け直す
                    newRow.GenbaShashinCd = string.Format("{000:0}", fileseq++);

                    datatable.AddGenbaShashinTblRow(newRow);
                }
            }

            return datatable;
        }
        #endregion

        #endregion

    }
    #endregion
}
