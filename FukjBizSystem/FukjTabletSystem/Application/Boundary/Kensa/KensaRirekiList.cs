using System;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.ApplicationLogic.Kensa;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.KensaRirekiList;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Properties;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaRirekiListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaRirekiListForm : FukjTabBaseForm
    {
		#region プロパティ

		#region 検査依頼のキー

		private string iraiHoteiKbn;
		public string IraiHoteiKbn { get { return iraiHoteiKbn; } }

		private string iraiHokenjoCd;
		public string IraiHokenjoCd { get { return iraiHokenjoCd; } }

		private string iraiNendo;
		public string IraiNendo { get { return iraiNendo; } }

		private string iraiRenban;
		public string IraiRenban { get { return iraiRenban; } }
        
		#endregion

		#endregion

		#region コンストラクタ
		////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaRirekiListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
		public KensaRirekiListForm(string iraiHoteiKbn, string iraiHokenjoCd, string iraiNendo, string iraiRenban)
            : base()
        {
            InitializeComponent();

			// パラメータの保存
			this.iraiHoteiKbn = iraiHoteiKbn;
			this.iraiHokenjoCd = iraiHokenjoCd;
			this.iraiNendo = iraiNendo;
			this.iraiRenban = iraiRenban;

			// 一覧表示を太字にする
            kensaRirekiListDataGridView.Font = new System.Drawing.Font(kensaRirekiListDataGridView.Font.FontFamily, kensaRirekiListDataGridView.Font.Size, System.Drawing.FontStyle.Bold);
        }
        #endregion
        
        #region イベントハンドラ

        #region KensaRirekiListForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaRirekiListForm_Load(object sender, EventArgs e)
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

        #region backButton_Click
        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
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
        
        #region kensaRirekiListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 一覧のボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaRirekiListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダー処理対象外
            if (e.RowIndex < 0)
            {
                return;
            }
            
            DataGridView dgv = (DataGridView)sender;

            // 処理対象外列
            if (dgv.Columns[e.ColumnIndex].Name != "Files"
                && dgv.Columns[e.ColumnIndex].Name != "Picture")
            {
                return;
            }            

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                    
                // 対象項目判定
                if (dgv.Columns[e.ColumnIndex].Name == "Files")
                {
                    // 検査依頼関連ファイル取得
					IGetKensaIraiFileListALInput alInput = new GetKensaIraiFileListALInput();

                    // 検査依頼のキー
                    alInput.IraiHoteiKbn = dgv.Rows[e.RowIndex].Cells[kensaIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString();
                    alInput.IraiHokenjoCd = dgv.Rows[e.RowIndex].Cells[kensaIraiHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                    alInput.IraiNendo = dgv.Rows[e.RowIndex].Cells[kensaIraiNendoDataGridViewTextBoxColumn.Index].Value.ToString();
                    alInput.IraiRenban = dgv.Rows[e.RowIndex].Cells[kensaIraiRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

					IGetKensaIraiFileListALOutput alOutput = new GetKensaIraiFileListApplicationLogic().Execute(alInput);

                    if (alOutput.KensaIraiFileList.Count == 0)
                    {
                        TabMessageBox.Show2(TabMessageBox.Type.Info, "表示データがありません。");
                        return;
                    }

                    FileListDataSet.FileListDataTable fileList = new FileListDataSet.FileListDataTable();
                    fileList.Merge(alOutput.KensaIraiFileList);

                    FileListDialog frm = new FileListDialog(Settings.Default.FileDirectory, fileList);
                    frm.ShowDialog();
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Picture")
                {
                    // 現場写真ファイル取得
                    IGetGenbaShashinFileListALInput alInput = new GetGenbaShashinFileListALInput();

                    // 検査依頼のキー
                    alInput.IraiHoteiKbn = dgv.Rows[e.RowIndex].Cells[kensaIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString();
                    alInput.IraiHokenjoCd = dgv.Rows[e.RowIndex].Cells[kensaIraiHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                    alInput.IraiNendo = dgv.Rows[e.RowIndex].Cells[kensaIraiNendoDataGridViewTextBoxColumn.Index].Value.ToString();
                    alInput.IraiRenban = dgv.Rows[e.RowIndex].Cells[kensaIraiRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

                    IGetGenbaShashinFileListALOutput alOutput = new GetGenbaShashinFileListApplicationLogic().Execute(alInput);

                    if (alOutput.GenbaShashinFileList.Count == 0)
                    {
                        TabMessageBox.Show2(TabMessageBox.Type.Info, "表示データがありません。");
                        return;
                    }

                    FileListDataSet.FileListDataTable fileList = new FileListDataSet.FileListDataTable();
                    fileList.Merge(alOutput.GenbaShashinFileList);

                    FileListDialog frm = new FileListDialog(Settings.Default.FileDirectory, fileList);
                    frm.ShowDialog();
                }
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

        #region メソッド(private)

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                // 描画を停止
                kensaRirekiListDataGridView.SuspendLayout();

                kensaDataSet.KensaRirekiList.Clear();

                IGetKensaRirekiListALInput alInput = new GetKensaRirekiListALInput();

				alInput.IraiHoteiKbn = this.iraiHoteiKbn;
				alInput.IraiHokenjoCd = this.iraiHokenjoCd;
				alInput.IraiNendo = this.iraiNendo;
				alInput.IraiRenban = this.iraiRenban; 
				
				IGetKensaRirekiListALOutput alOutput = new GetKensaRirekiListApplicationLogic().Execute(alInput);

				if (alOutput.KensaRirekiList.Count == 0)
				{
					TabMessageBox.Show2(TabMessageBox.Type.Info, "履歴データがありません。");
					return;
				}

				// クエリ側で年、月、日の桁合わせができないため、画面側で今回分より古いデータの最大を使用するよう制御する。
				string curY = String.Empty;
				string curM = String.Empty;
				string curD = String.Empty;
				string curYmd = String.Empty;
				string lstY = String.Empty;
				string lstM = String.Empty;
				string lstD = String.Empty;
				string lstYmd = String.Empty;

				if (alOutput.KensaYoteiList.Count > 0)
				{
					curY = alOutput.KensaYoteiList[0].IsKensaIraiKensaYoteiNenNull() ? "0000" : alOutput.KensaYoteiList[0].KensaIraiKensaYoteiNen.PadLeft(4, '0');
					curM = alOutput.KensaYoteiList[0].IsKensaIraiKensaYoteiTsukiNull() ? "00" : alOutput.KensaYoteiList[0].KensaIraiKensaYoteiTsuki.PadLeft(2, '0');
					curD = alOutput.KensaYoteiList[0].IsKensaIraiKensaYoteiBiNull() ? "00" : alOutput.KensaYoteiList[0].KensaIraiKensaYoteiBi.PadLeft(2, '0');
					curYmd = curY + curM + curD;
				}
				else
				{
					curYmd = "00000000";
				}

				// いったん全部マージする
				kensaDataSet.KensaRirekiList.Merge(alOutput.KensaRirekiList);

				int wkRowCnt = 0;
				foreach (KensaDataSet.KensaRirekiListRow wkRireki in kensaDataSet.KensaRirekiList)
				{
					lstY = wkRireki.IsKensaIraiKensaYoteiNenNull() ? "0000" : wkRireki.KensaIraiKensaYoteiNen.PadLeft(4, '0');
					lstM = wkRireki.IsKensaIraiKensaYoteiTsukiNull() ? "00" : wkRireki.KensaIraiKensaYoteiTsuki.PadLeft(2, '0');
					lstD = wkRireki.IsKensaIraiKensaYoteiBiNull() ? "00" : wkRireki.KensaIraiKensaYoteiBi.PadLeft(2, '0');
					lstYmd = lstY + lstM + lstD;

					// 今回の検査予定年月日と同じか新しい場合
					if (String.Compare(curYmd, lstYmd) <= 0)
					{
						// 今回以降のデータを表示用から削除
						kensaDataSet.KensaRirekiList[wkRowCnt].Delete();
					}

					wkRowCnt++;

				}

				// 非バインディング列の編集
				foreach (DataGridViewRow row in kensaRirekiListDataGridView.Rows)
				{
					// 検査日
					row.Cells[KensaYoteiYmd.Index].Value = 
						FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(
							(row.Cells[kensaIraiKensaYoteiNenDataGridViewTextBoxColumn.Index].Value.ToString() +
							row.Cells[kensaIraiKensaYoteiTsukiDataGridViewTextBoxColumn.Index].Value.ToString() +
							row.Cells[kensaIraiKensaYoteiBiDataGridViewTextBoxColumn.Index].Value.ToString()),
							"yy/MM/dd"
						);

					// 検査員
					row.Cells[Kensain.Index].Value = string.Format("{0}:{1}",
														row.Cells[kensaIraiKensaTantoshaCdDataGridViewTextBoxColumn.Index].Value.ToString(),
														row.Cells[shokuinNmDataGridViewTextBoxColumn.Index].Value.ToString());

				}
            }
            finally
            {
                // 描画再開
                kensaRirekiListDataGridView.ResumeLayout();
            }
        }
        #endregion
                        
        #endregion

    }
    #endregion
}
