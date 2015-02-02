using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.SuuchiNyuuryoku;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
	#region クラス定義
	////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： SuuchiNyuuryokuTabPage
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <history>
	/// 日付　　　　担当者　　　内容
	/// 2014/11/27　戸口　　    新規作成
	/// </history>
	////////////////////////////////////////////////////////////////////////////
	public partial class SuuchiNyuuryokuTabPage : BaseKensaTabPage
    {
		#region フィールド（private）

		/// <summary>
		/// 表示データ設定中フラグ
		/// </summary>
		private bool isInSetData = false;

		/// <summary>
		/// 検査依頼テーブル（数値項目の登録更新用）
		/// </summary>
		private KensaIraiTblDataSet.KensaIraiForSuuchiUpdateDataTable mySuuchi = new KensaIraiTblDataSet.KensaIraiForSuuchiUpdateDataTable();

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SuuchiNyuuryokuTabPage()
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

				// 数値情報の取得
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

				IUpdateKensaSuuchiALInput alInput = new UpdateKensaSuuchiALInput();

				// 検査依頼テーブル（数値項目の登録更新用）を作成
				alInput.KensaIraiForSuuchiUpdate = CreateSuuchi();

				// 更新実行
				new UpdateKensaSuuchiApplicationLogic().Execute(alInput);

				TabMessageBox.Show2(TabMessageBox.Type.Info, "数値入力", "数値情報を更新しました。");

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

		#endregion

		#region メソッド(private)

		#region DoSearch
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： DoSearch
		/// <summary>
		/// 表示データの検索を行う
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/11/27  戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private void DoSearch()
		{
			// 所得済データを初期化
			mySuuchi.Clear();

			IGetKensaSuuchiALInput alInput = new GetKensaSuuchiALInput();
			alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
			alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
			alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
			alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;
			IGetKensaSuuchiALOutput alOutput = new GetKensaSuuchiApplicationLogic().Execute(alInput);

			// 取得データを画面に保持
			mySuuchi.Merge(alOutput.KensaIraiForSuuchiUpdate);
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
		/// 2014/11/27  戸口　　    新規作成
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

				if (mySuuchi != null)
				{
					// ブロワ１
                    if (mySuuchi[0].IsKensaIraiBurowa1Null())
                    {
                        burowaNm1Label.Text = string.Empty;
                        burowaKitei1TextBox.Text = string.Empty;
                        burowaSecchi1TextBox.Text = string.Empty;

                        burowaKitei1TextBox.Enabled = false;
                        burowaSecchi1TextBox.Enabled = false;
                    }
                    else
                    {
                        burowaNm1Label.Text = mySuuchi[0].IsKensaIraiBurowa1Null() ? String.Empty : mySuuchi[0].KensaIraiBurowa1;
                        burowaKitei1TextBox.Text = mySuuchi[0].IsKensaIraiBurowaKiteFuryo1Null() ? String.Empty : mySuuchi[0].KensaIraiBurowaKiteFuryo1;
                        burowaSecchi1TextBox.Text = mySuuchi[0].IsKensaIraiBurowaSetchiFuryo1Null() ? String.Empty : mySuuchi[0].KensaIraiBurowaSetchiFuryo1;

                        burowaKitei1TextBox.Enabled = true;
                        burowaSecchi1TextBox.Enabled = true;
                    }

                    // ブロワ２
                    if (mySuuchi[0].IsKensaIraiBurowa2Null())
                    {
                        burowaNm2Label.Text = string.Empty;
                        burowaKitei2TextBox.Text = string.Empty;
                        burowaSecchi2TextBox.Text = string.Empty;

                        burowaKitei2TextBox.Enabled = false;
                        burowaSecchi2TextBox.Enabled = false;
                    }
                    else
                    {
                        burowaNm2Label.Text = mySuuchi[0].IsKensaIraiBurowa2Null() ? String.Empty : mySuuchi[0].KensaIraiBurowa2;
                        burowaKitei2TextBox.Text = mySuuchi[0].IsKensaIraiBurowaKiteFuryo2Null() ? String.Empty : mySuuchi[0].KensaIraiBurowaKiteFuryo2;
                        burowaSecchi2TextBox.Text = mySuuchi[0].IsKensaIraiBurowaSetchiFuryo2Null() ? String.Empty : mySuuchi[0].KensaIraiBurowaSetchiFuryo2;

                        burowaKitei2TextBox.Enabled = true;
                        burowaSecchi2TextBox.Enabled = true;
                    }

                    // ブロワ３
                    if (mySuuchi[0].IsKensaIraiBurowa3Null())
                    {
                        burowaNm3Label.Text = string.Empty;
                        burowaKitei3TextBox.Text = string.Empty;
                        burowaSecchi3TextBox.Text = string.Empty;

                        burowaKitei3TextBox.Enabled = false;
                        burowaSecchi3TextBox.Enabled = false;
                    }
                    else
                    {
                        burowaNm3Label.Text = mySuuchi[0].IsKensaIraiBurowa3Null() ? String.Empty : mySuuchi[0].KensaIraiBurowa3;
                        burowaKitei3TextBox.Text = mySuuchi[0].IsKensaIraiBurowaKiteFuryo3Null() ? String.Empty : mySuuchi[0].KensaIraiBurowaKiteFuryo3;
                        burowaSecchi3TextBox.Text = mySuuchi[0].IsKensaIraiBurowaSetchiFuryo3Null() ? String.Empty : mySuuchi[0].KensaIraiBurowaSetchiFuryo3;

                        burowaKitei3TextBox.Enabled = true;
                        burowaSecchi3TextBox.Enabled = true;
                    }

					// 管渠の滞留： 流入
					string wkRyunyuStr = mySuuchi[0].IsKensaIraiRyunyuTairyuNull() ? String.Empty : mySuuchi[0].KensaIraiRyunyuTairyu;
					int wkRyunyuInt;
					if (Int32.TryParse(wkRyunyuStr, out wkRyunyuInt))
					{
						ryunyuuTextBox.Text = wkRyunyuStr;
					}
					else
					{
						ryunyuuTextBox.Text = String.Empty;
					}

					// 管渠の滞留： 放流
					string wkHouryuStr = mySuuchi[0].IsKensaIraiHoryuTairyuNull() ? String.Empty : mySuuchi[0].KensaIraiHoryuTairyu;
					int wkHouryuInt;
					if (Int32.TryParse(wkHouryuStr, out wkHouryuInt))
					{
						houryuuTextBox.Text = wkHouryuStr;
					}
					else
					{
						houryuuTextBox.Text = String.Empty;
					}

					// 嵩上げ： 高さ
					string wkKasaageStr = mySuuchi[0].IsKensaIraiKasaageNull() ? String.Empty : mySuuchi[0].KensaIraiKasaage;
					int wkKasaageInt = 0;
					if (Int32.TryParse(wkKasaageStr, out wkKasaageInt))
					{
						kasaageTextBox.Text = wkKasaageStr;
					}
					else
					{
						kasaageTextBox.Text = String.Empty;
					}
				}
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

		#region CreateSuuchi
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： CreateSuuchi
		/// <summary>
		/// 画面データを返却用データに設定する
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/11/25  戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private KensaIraiTblDataSet.KensaIraiForSuuchiUpdateDataTable CreateSuuchi()
		{
			KensaIraiTblDataSet.KensaIraiForSuuchiUpdateDataTable datatable = new KensaIraiTblDataSet.KensaIraiForSuuchiUpdateDataTable();
			KensaIraiTblDataSet.KensaIraiForSuuchiUpdateRow newRow = datatable.NewKensaIraiForSuuchiUpdateRow();

			// 更新用DBキーとNot Null制約の項目
			newRow.KensaIraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
			newRow.KensaIraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
			newRow.KensaIraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
			newRow.KensaIraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

			newRow.UpdateDt = DateTime.Now;
			newRow.UpdateTarm = Dns.GetHostName();
			newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

			// 入力しないが、更新している項目
            if (string.IsNullOrEmpty(this.burowaNm1Label.Text))
            {
                newRow.KensaIraiBurowa1 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowa1 = this.burowaNm1Label.Text;
            }

            if (string.IsNullOrEmpty(this.burowaNm2Label.Text))
            {
                newRow.KensaIraiBurowa2 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowa2 = this.burowaNm2Label.Text;
            }

            if (string.IsNullOrEmpty(this.burowaNm3Label.Text))
            {
                newRow.KensaIraiBurowa3 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowa3 = this.burowaNm3Label.Text;
            }

            if (string.IsNullOrEmpty(this.burowaKitei1TextBox.Text))
            {
                newRow.KensaIraiBurowaKiteFuryo1 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowaKiteFuryo1 = this.burowaKitei1TextBox.Text;
            }

            if (string.IsNullOrEmpty(this.burowaKitei2TextBox.Text))
            {
                newRow.KensaIraiBurowaKiteFuryo2 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowaKiteFuryo2 = this.burowaKitei2TextBox.Text;
            }

            if (string.IsNullOrEmpty(this.burowaKitei3TextBox.Text))
            {
                newRow.KensaIraiBurowaKiteFuryo3 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowaKiteFuryo3 = this.burowaKitei3TextBox.Text;
            }
            
			// 入力項目
            if (string.IsNullOrEmpty(this.burowaSecchi1TextBox.Text))
            {
                newRow.KensaIraiBurowaSetchiFuryo1 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowaSetchiFuryo1 = this.burowaSecchi1TextBox.Text;
            }

            if (string.IsNullOrEmpty(this.burowaSecchi2TextBox.Text))
            {
                newRow.KensaIraiBurowaSetchiFuryo2 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowaSetchiFuryo2 = this.burowaSecchi2TextBox.Text;
            }

            if (string.IsNullOrEmpty(this.burowaSecchi3TextBox.Text))
            {
                newRow.KensaIraiBurowaSetchiFuryo3 = string.Empty;
            }
            else
            {
                newRow.KensaIraiBurowaSetchiFuryo3 = this.burowaSecchi3TextBox.Text;
            }

            if (string.IsNullOrEmpty(this.ryunyuuTextBox.Text))
            {
                newRow.KensaIraiRyunyuTairyu = string.Empty;
            }
            else
            {
                newRow.KensaIraiRyunyuTairyu = this.ryunyuuTextBox.Text;
            }

            if (string.IsNullOrEmpty(this.houryuuTextBox.Text))
            {
                newRow.KensaIraiHoryuTairyu = string.Empty;
            }
            else
            {
                newRow.KensaIraiHoryuTairyu = this.houryuuTextBox.Text;
            }

            if (string.IsNullOrEmpty(this.kasaageTextBox.Text))
            {
                newRow.KensaIraiKasaage = string.Empty;
            }
            else
            {
                newRow.KensaIraiKasaage = this.kasaageTextBox.Text;
            }
			
			// 更新用のデータを追加
			datatable.AddKensaIraiForSuuchiUpdateRow(newRow);

			datatable[0].AcceptChanges();
			datatable[0].SetModified();

			return datatable;
		}
		#endregion

		#endregion メソッド(private)
	}
	#endregion
}
