using System;
using System.Data;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.MemoTabPage;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoTabPage
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MemoTabPage : BaseKensaTabPage
    {
        #region フィールド（private）

		/// <summary>
		/// 表示データ設定中フラグ
		/// </summary>
		private bool isInSetData = false;

		/// <summary>
		/// メモ大分類マスタ（内部キャッシュ用：全件取得）
        /// </summary>
		private MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable myMemoDaibunruiMst = new MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable();

		/// <summary>
		/// メモマスタ（内部キャッシュ用：全件取得）
		/// </summary>
		private MemoMstDataSet.MemoMstDataTable myMemoMst = new MemoMstDataSet.MemoMstDataTable();

		/// <summary>
		/// 浄化槽定型メモテーブル（内部キャッシュ用：検査依頼のキーで取得）
		/// </summary>
		private JokasoMemoTblDataSet.JokasoMemoListDataTable myJokasoMemoTbl = new JokasoMemoTblDataSet.JokasoMemoListDataTable();

		/// <summary>
		/// 浄化槽台帳マスタ（メモ用：検査依頼のキーで取得）
		/// </summary>
		private JokasoDaichoMstDataSet.JokasoDaichoMstMemoDataTable myJokasoDaichoMst = new JokasoDaichoMstDataSet.JokasoDaichoMstMemoDataTable();

		/// <summary>
		/// 検査依頼関連ファイルテーブル（見出し用：検査依頼のキーで取得）
		/// </summary>
		private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable myKensaIraiKanrenFileTbl = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

		#endregion
        
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MemoTabPage()
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

                // メモ情報の取得
                DoSearch();

                // 取得データの表示
                SetControlData();

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 親画面の終了
                ((KensaMenuForm)this.TopLevelControl).DoClose();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

		#region memoDaibunruiListBox_SelectedValueChanged(object sender, EventArgs e)
		/// <summary>
		/// メモ大分類選択変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void memoDaibunruiListBox_SelectedValueChanged(object sender, EventArgs e)
		{
			TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
			Cursor preCursor = Cursor.Current;

			try
			{
				Cursor.Current = Cursors.WaitCursor;

				// メモ大分類の紐づく表示を全てクリア
				memoListDataSet.MemoMst.Clear();
				memoTextBox.Text = String.Empty;

				// 未選択の場合
				if (memoDaibunruiListBox.SelectedIndex == -1)
				{
					return;
				}

				// 対象の項目を抽出
				DataRow[] rows = myMemoMst.Select(string.Format("MemoDaibunruiCd='{0}'", memoDaibunruiListBox.SelectedValue.ToString()));

				// 検査項目をリストに設定
				foreach (DataRow row in rows)
				{
					memoListDataSet.MemoMst.ImportRow(row);
				}

				// メモ一覧を未選択にする
				memoMstListBox.SelectedIndex = -1;
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

		#region memoMstListBox_SelectedValueChanged(object sender, EventArgs e)
		/// <summary>
		/// メモ選択変更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void memoMstListBox_SelectedValueChanged(object sender, EventArgs e)
		{
			TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
			Cursor preCursor = Cursor.Current;

			try
			{
				Cursor.Current = Cursors.WaitCursor;

				memoTextBox.Text = String.Empty;

				// 未選択の場合
				if (memoMstListBox.SelectedIndex == -1)
				{
					return;
				}

				// 選択されたメモ
				memoTextBox.Text = memoMstListBox.Text;

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

		#region tsuikaButton_Click(object sender, EventArgs e)
		/// <summary>
		/// 追加ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsuikaButton_Click(object sender, EventArgs e)
		{
			// 未選択チェック
			if (memoMstListBox.SelectedIndex == -1)
			{
				TabMessageBox.Show2(TabMessageBox.Type.Warn, "メモ", "メモが選択されていません。");
				return;
			}

			// 追加済みチェック
			// 対象の項目を抽出
			DataRow[] rows = memoListDataSet.JokasoMemoList.Select(string.Format("JokasoMemoDaibunruiCd='{0}' AND JokasoMemoCd='{1}'", memoDaibunruiListBox.SelectedValue.ToString(), memoMstListBox.SelectedValue.ToString()));
			if (rows.Length > 0)
			{
				TabMessageBox.Show2(TabMessageBox.Type.Warn, "メモ", "既に追加されているメモです。");
				return;
			}

			// 追加用の行を作成
			MemoListDataSet.JokasoMemoListRow newRow = memoListDataSet.JokasoMemoList.NewJokasoMemoListRow();
			newRow.JokasoMemoJokasoHokenjoCd = myJokasoDaichoMst[0].JokasoHokenjoCd;
			newRow.JokasoMemoJokasoTorokuNendo = myJokasoDaichoMst[0].JokasoTorokuNendo;
			newRow.JokasoMemoJokasoRenban = myJokasoDaichoMst[0].JokasoRenban;
			newRow.JokasoMemoDaibunruiCd = memoDaibunruiListBox.SelectedValue.ToString();
			newRow.JokasoMemoCd = memoMstListBox.SelectedValue.ToString();
			newRow.Memo = memoMstListBox.Text;

			memoListDataSet.JokasoMemoList.AddJokasoMemoListRow(newRow);
			
			// 行の追加
			newRow.AcceptChanges();
			newRow.SetAdded();

			// 編集あり
			this.IsEdited = true;
		}
		#endregion

		#region memoListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		/// <summary>
		/// 一覧のセルクリック（削除処理）
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void memoListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// ヘッダー処理対象外
			if (e.RowIndex < 0)
			{
				return;
			}

			// 処理対象外列
			if (e.ColumnIndex != Delete.Index)
			{
				return;
			}

			TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
			Cursor preCursor = Cursor.Current;

			try
			{
				Cursor.Current = Cursors.WaitCursor;

				// 対象項目判定

				if (e.ColumnIndex == Delete.Index)
				{
					DataGridView dgv = (DataGridView)sender;

					// 対象のレコード（メモ）を取得
					DataRow[] memoRow = memoListDataSet.JokasoMemoList.Select(
						string.Format("JokasoMemoJokasoHokenjoCd = '{0}' AND JokasoMemoJokasoTorokuNendo = '{1}' AND JokasoMemoJokasoRenban = '{2}' AND JokasoMemoDaibunruiCd = '{3}' AND JokasoMemoCd = '{4}'",
						dgv.Rows[e.RowIndex].Cells[jokasoMemoJokasoHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString(),
						dgv.Rows[e.RowIndex].Cells[jokasoMemoJokasoTorokuNendoDataGridViewTextBoxColumn.Index].Value.ToString(),
						dgv.Rows[e.RowIndex].Cells[jokasoMemoJokasoRenbanDataGridViewTextBoxColumn.Index].Value.ToString(),
						dgv.Rows[e.RowIndex].Cells[jokasoMemoDaibunruiCdDataGridViewTextBoxColumn.Index].Value.ToString(),
						dgv.Rows[e.RowIndex].Cells[jokasoMemoCdDataGridViewTextBoxColumn.Index].Value.ToString()));

					// メモを削除
					if (memoRow.Length > 0)
					{
						memoRow[0].Delete();
					}
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

		#region kakuteiButton_Click(object sender, EventArgs e)
		/// <summary>
		/// 確定ボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kakuteiButton_Click(object sender, EventArgs e)
		{
			TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
			Cursor preCursor = Cursor.Current;

			try
			{
				Cursor.Current = Cursors.WaitCursor;

				IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();

				// 浄化槽定型メモテーブルを作成
				alInput.JokasoMemoTbl = CreateJokasoMemoTbl();

				// 浄化槽台帳マスタを作成
				alInput.JokasoDaichoMstMemo = CreateJokasoDaichoMemo();

				// 更新実行
				new KakuteiBtnClickApplicationLogic().Execute(alInput);

				TabMessageBox.Show2(TabMessageBox.Type.Info, "メモ", "メモ情報を更新しました。");

				// 再表示データの取得
				DoSearch();

				// 再表示の実行
				SetControlData();

				// 編集無し(初期化)
				this.IsEdited = false;
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

		#region TextBox_TextChanged(object sender, EventArgs e)
		/// <summary>
		/// 編集済みの判定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			if (!isInSetData)
			{
				this.IsEdited = true;
			}
		}
		#endregion

		#endregion イベントハンドラ

		#region メソッド(private)

		#region DoSearch
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： DoSearch
		/// <summary>
		/// 表示データの検索を行う
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/11/21  戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private void DoSearch() 
        {
			// 所得済データを初期化
			myMemoDaibunruiMst.Clear();
			myMemoMst.Clear();
			myJokasoMemoTbl.Clear();

			IGetMemoInfoALInput alInput = new GetMemoInfoALInput();
			alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
			alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
			alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
			alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;
			IGetMemoInfoALOutput alOutput = new GetMemoInfoApplicationLogic().Execute(alInput);

			// 取得データを画面に保持
			myMemoDaibunruiMst.Merge(alOutput.MemoDaibunruiMst);
			myMemoMst.Merge(alOutput.MemoMst);
			myJokasoMemoTbl.Merge(alOutput.JokasoMemoList);
			myJokasoDaichoMst.Merge(alOutput.JokasoDaichoMstMemo);
			myKensaIraiKanrenFileTbl.Merge(alOutput.KensaIraiKanrenFileTbl);
		}

		#endregion

		#region SetControlData
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： SetControlData
		/// <summary>
		/// 取得データを画面コントロールにマッピングする
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/11/21  戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private void SetControlData()
        {
			try 
            {
				// マッピング中オン
				isInSetData = true;

				// 描画を停止
				this.SuspendLayout();

				// リストボックス
				memoListDataSet.MemoDaibunruiMst.Clear();
				memoListDataSet.MemoMst.Clear();
				
				if (myMemoDaibunruiMst.Count > 0)
				{
					// メモ大分類マスタをリストに出力
					memoListDataSet.MemoDaibunruiMst.Merge(myMemoDaibunruiMst);
					// 未選択とする
					memoDaibunruiListBox.SelectedIndex = -1;
				}

				// データグリッドにバインド済みのデータを初期化
				memoListDataSet.JokasoMemoList.Clear();
				memoListDataSet.KensaIraiKanrenFileTbl.Clear();

				// データグリッドの表示
				memoListDataSet.JokasoMemoList.Merge(myJokasoMemoTbl);
				memoListDataSet.KensaIraiKanrenFileTbl.Merge(myKensaIraiKanrenFileTbl);

				// 選択されたメモ
				memoTextBox.Clear();

				// 手書きメモ
				if (myJokasoDaichoMst.Count > 0)
				{
					tegakiMemoTextBox.Text = 
						myJokasoDaichoMst[0].IsJokasoTegakiMemoNull() ? String.Empty : myJokasoDaichoMst[0].JokasoTegakiMemo;
				}

				// 検査日
				string kensaYoteiNen = 
					((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.IsKensaIraiKensaYoteiNenNull() ?
						String.Empty : ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiKensaYoteiNen;
				string kensaYoteiTsuki = 
					((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.IsKensaIraiKensaYoteiTsukiNull() ?
						String.Empty : ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiKensaYoteiTsuki;
				string kensaYoteiBi = 
					((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.IsKensaIraiKensaYoteiBiNull() ?
						String.Empty : ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiKensaYoteiBi;

				kensaNenTextBox.Text = 
					FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(
						(kensaYoteiNen + kensaYoteiTsuki + kensaYoteiBi),
						"yy年MM月dd日"
					);
			}
			finally
			{
				// 描画再開
				this.ResumeLayout();

				// マッピング中オフ
				isInSetData = false;
			}
		}
		#endregion

		#region CreateJokasoMemoTbl
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： CreateJokasoMemoTbl
		/// <summary>
		/// 画面データを返却用用データに設定する
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/11/25  戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private JokasoMemoTblDataSet.JokasoMemoTblDataTable CreateJokasoMemoTbl()
		{
			JokasoMemoTblDataSet.JokasoMemoTblDataTable datatable = new JokasoMemoTblDataSet.JokasoMemoTblDataTable();

			foreach (MemoListDataSet.JokasoMemoListRow row in memoListDataSet.JokasoMemoList)
			{
				// 画面内で更新は行われないため、追加、削除のみを対象とする

				// 追加行
				if (row.RowState == DataRowState.Added)
				{
					JokasoMemoTblDataSet.JokasoMemoTblRow newRow = datatable.NewJokasoMemoTblRow();

					foreach (DataColumn col in datatable.Columns)
					{
						newRow[col.ColumnName] = row[col.ColumnName];
					}

					newRow.InsertDt = DateTime.Now;
					newRow.InsertTarm = Dns.GetHostName();
					newRow.InsertUser = FukjBizSystem.Application.Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
					newRow.UpdateDt = DateTime.Now;
					newRow.UpdateTarm = Dns.GetHostName();
					newRow.UpdateUser = FukjBizSystem.Application.Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

					datatable.AddJokasoMemoTblRow(newRow);

					newRow.AcceptChanges();
					newRow.SetAdded();
				}
				// 削除行
				else if (row.RowState == DataRowState.Deleted)
				{
					JokasoMemoTblDataSet.JokasoMemoTblRow newRow = datatable.NewJokasoMemoTblRow();

					foreach (DataColumn col in datatable.Columns)
					{
						newRow[col.ColumnName] = row[col.ColumnName, DataRowVersion.Original];
					}

					datatable.AddJokasoMemoTblRow(newRow);

					newRow.AcceptChanges();
					newRow.Delete();
				}
			}

			return datatable;
		}
		#endregion

		#region CreateJokasoDaichoMemo
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： CreateJokasoMemoTbl
		/// <summary>
		/// 画面データを返却用用データに設定する
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/11/25  戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private JokasoDaichoMstDataSet.JokasoDaichoMstMemoDataTable CreateJokasoDaichoMemo()
		{
			JokasoDaichoMstDataSet.JokasoDaichoMstMemoDataTable datatable = new JokasoDaichoMstDataSet.JokasoDaichoMstMemoDataTable();
			JokasoDaichoMstDataSet.JokasoDaichoMstMemoRow newRow = datatable.NewJokasoDaichoMstMemoRow();

			newRow.JokasoHokenjoCd = myJokasoDaichoMst[0].JokasoHokenjoCd;
			newRow.JokasoTorokuNendo = myJokasoDaichoMst[0].JokasoTorokuNendo;
			newRow.JokasoRenban = myJokasoDaichoMst[0].JokasoRenban;

            // 手書きメモ１（編集項目）
            if (string.IsNullOrEmpty(this.tegakiMemoTextBox.Text))
            {
                newRow.JokasoTegakiMemo = string.Empty;
            }
            else
            {
                newRow.JokasoTegakiMemo = this.tegakiMemoTextBox.Text;
            }

            // 手書きメモ２は元々の値を戻す
            if (myJokasoDaichoMst[0].IsJokasoTegakiMemo2Null() || string.IsNullOrEmpty(myJokasoDaichoMst[0].JokasoTegakiMemo2))
            {
                newRow.JokasoTegakiMemo2 = string.Empty;
            }
            else
            {
                newRow.JokasoTegakiMemo2 = myJokasoDaichoMst[0].JokasoTegakiMemo2;
            }

            newRow.UpdateDt = DateTime.Now;
            newRow.UpdateTarm = Dns.GetHostName();
            newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

			datatable.AddJokasoDaichoMstMemoRow(newRow);
			datatable[0].AcceptChanges();
			datatable[0].SetModified();

			return datatable;
		}
		#endregion

		#endregion メソッド(private)
    }
    #endregion
}
