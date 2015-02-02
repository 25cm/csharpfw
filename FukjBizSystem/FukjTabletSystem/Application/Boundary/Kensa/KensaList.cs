using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.ApplicationLogic.Kensa;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.KensaList;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.Boundary.MapWorks;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Properties;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaListForm : FukjTabBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaListForm()
            : base()
        {
            InitializeComponent();

            // 一覧表示を太字にする
            kensaListDataGridView.Font = new System.Drawing.Font(kensaListDataGridView.Font.FontFamily, kensaListDataGridView.Font.Size, System.Drawing.FontStyle.Bold);
        }
        #endregion
        
        #region イベントハンドラ

        #region KensaListForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaListForm_Load(object sender, EventArgs e)
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

        #region mapButton_Click
        /// <summary>
        /// マップボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // カレント指定なし
                using (MapWorksForm frm = new MapWorksForm(CreateMapPoint(), "", true))
                {
                    try
                    {
                        frm.ShowDialog();
                    }
                    catch
                    {
                        // 多重起動になった際のDisposeで失敗することがあるが・・・
                    }

                    // 再検索
                    DoSearch();
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

        #region kensaListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 一覧のボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダー処理対象外
            if (e.RowIndex < 0)
            {
                return;
            }
            
            DataGridView dgv = (DataGridView)sender;

            // 処理対象外列
            if (dgv.Columns[e.ColumnIndex].Name != "Kensa"
                && dgv.Columns[e.ColumnIndex].Name != "Rireki"
                && dgv.Columns[e.ColumnIndex].Name != "Map"
                && dgv.Columns[e.ColumnIndex].Name != "Files"
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
                if (dgv.Columns[e.ColumnIndex].Name == "Kensa")
                {
                    // 検査依頼のキー
                    string iraiRowIndex = dgv.Rows[e.RowIndex].Cells[RowIndex.Index].Value.ToString();
                    string iraiHoteiKbn = dgv.Rows[e.RowIndex].Cells[kensaIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString();
                    string iraiHokenjoCd = dgv.Rows[e.RowIndex].Cells[kensaIraiHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                    string iraiNendo = dgv.Rows[e.RowIndex].Cells[kensaIraiNendoDataGridViewTextBoxColumn.Index].Value.ToString();
                    string iraiRenban = dgv.Rows[e.RowIndex].Cells[kensaIraiRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

                    using (KensaMenuForm form = new KensaMenuForm(iraiHoteiKbn, iraiHokenjoCd, iraiNendo, iraiRenban, iraiRowIndex))
                    {
                        form.ShowDialog(this);

                        // 再検索
                        DoSearch();
                    }
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Rireki")
                {
					// 検査依頼のキー
					string iraiRowIndex = dgv.Rows[e.RowIndex].Cells[RowIndex.Index].Value.ToString();
					string iraiHoteiKbn = dgv.Rows[e.RowIndex].Cells[kensaIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString();
					string iraiHokenjoCd = dgv.Rows[e.RowIndex].Cells[kensaIraiHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
					string iraiNendo = dgv.Rows[e.RowIndex].Cells[kensaIraiNendoDataGridViewTextBoxColumn.Index].Value.ToString();
					string iraiRenban = dgv.Rows[e.RowIndex].Cells[kensaIraiRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

					using (KensaRirekiListForm form = new KensaRirekiListForm(iraiHoteiKbn, iraiHokenjoCd, iraiNendo, iraiRenban))
					{
						form.ShowDialog(this);
					}
				}
                else if (dgv.Columns[e.ColumnIndex].Name == "Map")
                {
                    string iraiRowIndex = dgv.Rows[e.RowIndex].Cells[RowIndex.Index].Value.ToString();

                    // 選択行をカレント指定
                    using (MapWorksForm frm = new MapWorksForm(CreateMapPoint(), iraiRowIndex, true))
                    {
                        try
                        {
                            frm.ShowDialog();
                        }
                        catch
                        {
                            // 多重起動になった際のDisposeで失敗することがあるが・・・
                        }

                        // 再検索
                        DoSearch();
                    }
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Files")
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
        /// 2014/10/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                // 描画を停止
                kensaListDataGridView.SuspendLayout();

                kensaDataSet.KensaYoteiList.Clear();

                IGetKensaYoteiListALInput alInput = new GetKensaYoteiListALInput();

                IGetKensaYoteiListALOutput alOutput = new GetKensaYoteiListApplicationLogic().Execute(alInput);

                if (alOutput.KensaYoteiList.Count == 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Info, "表示データがありません。");
                    return;
                }

                kensaDataSet.KensaYoteiList.Merge(alOutput.KensaYoteiList);

                // 非バインディング列の編集
                int rowIndex = 1;

                foreach (DataGridViewRow row in kensaListDataGridView.Rows)
                {
                    // No.
                    row.Cells[RowIndex.Index].Value = rowIndex++;

                    // 種別
                    if (row.Cells[kensaIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString() != "3")
                    {
                        // 11条水質検査以外
                        row.Cells[Shubetsu.Index].Value = row.Cells[hoteiKbnNmDataGridViewTextBoxColumn.Index].Value.ToString();
                    }
                    else
                    {
                        // 11条水質検査（スクリーニング）
                        row.Cells[Shubetsu.Index].Value = row.Cells[screeningKbnNmDataGridViewTextBoxColumn.Index].Value.ToString();
                    }

                    // 浄化槽管理者名／設置場所
                    row.Cells[JokasoName.Index].Value = string.Format("{0}\r\n{1}",
                                                            row.Cells[jokasoSetchishaNmDataGridViewTextBoxColumn.Index].Value.ToString(),
                                                            row.Cells[jokasoSetchiBashoAdrDataGridViewTextBoxColumn.Index].Value.ToString());

                    // 請求方法
                    row.Cells[Seikyu.Index].Value = string.Format("{0}.{1}",
                                                            row.Cells[nyuukinHouhouKbnValueDataGridViewTextBoxColumn.Index].Value.ToString(),
                                                            row.Cells[nyuukinHouhouKbnNmDataGridViewTextBoxColumn.Index].Value.ToString());

                    // 2015.01.08 toyoda Add Start
                    // 請求方法が「3：請求」「4：指定請求書」の場合は赤字にする
                    if (row.Cells[nyuukinHouhouKbnValueDataGridViewTextBoxColumn.Index].Value.ToString() == "3"
                        || row.Cells[nyuukinHouhouKbnValueDataGridViewTextBoxColumn.Index].Value.ToString() == "4")
                    {
                        // 請求方法
                        row.Cells[Seikyu.Index].Style.ForeColor = Color.Red;
                        row.Cells[Seikyu.Index].Style.SelectionForeColor = Color.Red;
                    }
                    // 2015.01.08 toyoda Add End

                    // 検査時間
                    //if (row.Cells[kensaKekkaKensaTimesDataGridViewTextBoxColumn.Index].Value != DBNull.Value
                    //    && (int)row.Cells[kensaKekkaKensaTimesDataGridViewTextBoxColumn.Index].Value != 0)
                    if (row.Cells[kensaKekkaKensaTimesDataGridViewTextBoxColumn.Index].Value != DBNull.Value)
                    {
                        row.Cells[Times.Index].Value = string.Format("{0}分",
                                                            row.Cells[kensaKekkaKensaTimesDataGridViewTextBoxColumn.Index].Value.ToString());
                    }

                    // 状況
                    if (row.Cells[KensaKekkaKensaJoukyouKbn.Index].Value.ToString() == Constants.KensaJoukyouKbn.INITIAL)
                    {
                        // 未検査
                        ((DataGridViewImageCell)row.Cells[Status.Index]).Value = Resources.list_pin_initial;
                    }
                    else if (row.Cells[KensaKekkaKensaJoukyouKbn.Index].Value.ToString() == Constants.KensaJoukyouKbn.IN_WORK)
                    {
                        // 検査中
                        ((DataGridViewImageCell)row.Cells[Status.Index]).Value = Resources.list_pin_work;
                    }
                    else if (row.Cells[KensaKekkaKensaJoukyouKbn.Index].Value.ToString() == Constants.KensaJoukyouKbn.STOPPED)
                    {
                        // 中断中
                        ((DataGridViewImageCell)row.Cells[Status.Index]).Value = Resources.list_pin_stopped;
                    }
                    else if (row.Cells[KensaKekkaKensaJoukyouKbn.Index].Value.ToString() == Constants.KensaJoukyouKbn.COMPLETE)
                    {
                        // 検査完了
                        ((DataGridViewImageCell)row.Cells[Status.Index]).Value = Resources.list_pin_complete;
                    }
                    else
                    {
                        // デフォルトは未検査
                        ((DataGridViewImageCell)row.Cells[Status.Index]).Value = Resources.list_pin_initial;
                    }
                }
            }
            finally
            {
                // 描画再開
                kensaListDataGridView.ResumeLayout();
            }
        }
        #endregion

        #region CreateMapPoint()
        /// <summary>
        /// マップポイント情報の作成
        /// </summary>
        /// <returns></returns>
        private MapPointDataSet.JokasoMapPointDataTable CreateMapPoint()
        {
            MapPointDataSet.JokasoMapPointDataTable datatable = new MapPointDataSet.JokasoMapPointDataTable();

            foreach (DataGridViewRow row in kensaListDataGridView.Rows)
            {
                MapPointDataSet.JokasoMapPointRow newRow = datatable.NewJokasoMapPointRow();

                // 検査依頼のキー
                newRow.KensaIraiHoteiKbn = row.Cells[kensaIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString();
                newRow.KensaIraiHokenjoCd = row.Cells[kensaIraiHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                newRow.KensaIraiNendo = row.Cells[kensaIraiNendoDataGridViewTextBoxColumn.Index].Value.ToString();
                newRow.KensaIraiRenban = row.Cells[kensaIraiRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

                newRow.KensaIraiRowIndex = row.Cells[RowIndex.Index].Value.ToString();
                newRow.JokasoSetchishaNm = row.Cells[jokasoSetchishaNmDataGridViewTextBoxColumn.Index].Value.ToString();
                newRow.JokasoSetchiBashoAdr = row.Cells[jokasoSetchiBashoAdrDataGridViewTextBoxColumn.Index].Value.ToString();
                newRow.KensaKekkaKensaJoukyouKbn = row.Cells[KensaKekkaKensaJoukyouKbn.Index].Value.ToString();
                newRow.JokasoZenrinKeidoCd = row.Cells[jokasoZenrinKeidoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                newRow.JokasoZenrinIdoCd = row.Cells[jokasoZenrinIdoCdDataGridViewTextBoxColumn.Index].Value.ToString();

                datatable.AddJokasoMapPointRow(newRow);
            }

            return datatable;
        }
        #endregion

        #region gpsButton_Click(object sender, EventArgs e)
        /// <summary>
        /// GPSボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gpsButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // 緯度
                double latitude = 0;
                // 経度
                double longitude = 0;

                // 位置情報を取得
                // 2015.01.30 toyoda Mod Start GPS情報取得方法の変更
                //bool ret = GPSInfo.GetLocation(ref latitude, ref longitude, Settings.Default.GpsTimeout);
                bool ret = LocationGpsInfo.ReadOnce(Settings.Default.GpsTimeout);
                if (ret)
                {
                    latitude = LocationGpsInfo.LatitudeOnce;
                    longitude = LocationGpsInfo.LongitudeOnce;
                }
                // 2015.01.30 toyoda Mod End

                // 2015.1.20 toyoda Modify Start マイナス座標はエラーとして扱う
                //if (ret)
                if (ret && latitude >= 0 && longitude >= 0)
                // 2015.1.20 toyoda Modify End
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, string.Format("現在位置情報\r\n緯度 [{0}]\r\n経度 [{1}]", latitude, longitude));
                }
                else
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "現在位置情報の取得に失敗しました。\r\nしばらくして再度実行してください。");
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

        #region titleLabel_DoubleClick(object sender, KeyEventArgs e)
        /// <summary>
        /// 隠しコマンド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleLabel_DoubleClick(object sender, EventArgs e)
        {
            gpsButton.Visible = !gpsButton.Visible;
        }
        #endregion


        #endregion
    }
    #endregion
}
