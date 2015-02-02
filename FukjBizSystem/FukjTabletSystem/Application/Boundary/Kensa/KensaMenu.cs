using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.ApplicationLogic.Kensa;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.KekkashoPreviewTabPage;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.KensaMenu;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.Boundary.MapWorks;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Properties;
using Zynas.Framework.Utility;
using System.Threading;

namespace FukjTabletSystem.Application.Boundary.Kensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaMenuForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaMenuForm : FukjTabBaseForm
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

        private string iraiRowIndex;
        public string IraiRowIndex { get { return iraiRowIndex; } }

        #endregion

        /// <summary>
        /// 検査依頼情報
        /// </summary>
        public KensaDataSet.KensaYoteiListRow KensaIraiInfo { get { return kensaDataSet.KensaYoteiList.Count > 0 ? kensaDataSet.KensaYoteiList[0] : null; } }

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaMenuForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaMenuForm(string iraiHoteiKbn, string iraiHokenjoCd, string iraiNendo, string iraiRenban, string iraiRowIndex)
            : base()
        {
            InitializeComponent();

            // パラメータの保存
            this.iraiHoteiKbn = iraiHoteiKbn;
            this.iraiHokenjoCd = iraiHokenjoCd;
            this.iraiNendo = iraiNendo;
            this.iraiRenban = iraiRenban;
            this.iraiRowIndex = iraiRowIndex;

            // 一覧表示を太字にする
            kensaListDataGridView.Font = new System.Drawing.Font(kensaListDataGridView.Font.FontFamily, kensaListDataGridView.Font.Size, System.Drawing.FontStyle.Bold);
        }
        #endregion

        #region KensaMenuForm_Load(object sender, EventArgs e)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaMenuForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.Visible = false;

                //タブを左側に表示する
                tabControl.Alignment = TabAlignment.Left;
                //タブのサイズを固定する
                tabControl.SizeMode = TabSizeMode.Fixed;
                tabControl.ItemSize = new Size(64, 160);
                tabControl.Font = new System.Drawing.Font(tabControl.Font.FontFamily, 16, FontStyle.Bold);
                //TabControlをオーナードローする
                tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
                //DrawItemイベントハンドラを追加
                tabControl.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);

                myTabIndex = tabControl.SelectedIndex;
                
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

        #region KensaMenuForm_Shown(object sender, EventArgs e)
        /// <summary>
        /// 画面表示（表示のちらつき制御）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaMenuForm_Shown(object sender, EventArgs e)
        {
            this.Visible = true;

            // 検査開始
            if (!StartKensa(false))
            {
                foreach (TabPage tab in tabControl.TabPages)
                {
                    tab.Enabled = false;
                }
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

                // 検査中断
                CompleteKensa(true);

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
                    // 2015.1.20 toyoda Delete Start DBには世界測地系のまま登録
                    //double longitudeJ;
                    //double latitudeJ;

                    //// 日本測地系へ変換
                    //FukjBizSystem.Application.Utility.MapLocationUtility.WLocToJLoc(longitude, latitude, out longitudeJ, out latitudeJ);
                    // 2015.1.20 toyoda Delete End

                    // 更新用データの作成
                    JokasoDaichoMstDataSet.JokasoDaichoMstLocationDataTable datatable = new JokasoDaichoMstDataSet.JokasoDaichoMstLocationDataTable();
                    JokasoDaichoMstDataSet.JokasoDaichoMstLocationRow newRow = datatable.NewJokasoDaichoMstLocationRow();

                    // 初期表示データの取得
                    foreach (DataColumn col in datatable.Columns)
                    {
                        newRow[col.ColumnName] = kensaDataSet.JokasoDaichoMstLocation[0][col.ColumnName];
                    }

                    // 2015.1.20 toyoda Modify Start DBには世界測地系のまま登録
                    //// 緯度（日本測地系）
                    //newRow.JokasoZenrinIdoCd = latitudeJ.ToString("N7").Replace(".", string.Empty);
                    //// 経度（日本測地系）
                    //newRow.JokasoZenrinKeidoCd = longitudeJ.ToString("N7").Replace(".", string.Empty);
                    // 緯度（世界測地系）
                    newRow.JokasoZenrinIdoCd = longitude.ToString("N6");
                    // 経度（世界測地系）
                    newRow.JokasoZenrinKeidoCd = latitude.ToString("N6");
                    // 2015.1.20 toyoda Modify End

                    // 更新日時
                    newRow.JokasoLocationUpdateDt = DateTime.Now;

                    newRow.UpdateDt = DateTime.Now;
                    newRow.UpdateTarm = Dns.GetHostName();
                    newRow.UpdateUser = FukjBizSystem.Application.Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    datatable.AddJokasoDaichoMstLocationRow(newRow);
                    datatable.Rows[0].AcceptChanges();
                    datatable.Rows[0].SetModified();

                    IUpdateJokasoDaichoMstLocationALInput alInput = new UpdateJokasoDaichoMstLocationALInput();

                    alInput.JokasoDaichoMstLocation = datatable;

                    new UpdateJokasoDaichoMstLocationApplicationLogic().Execute(alInput);

                    // 表示情報を更新
                    DoSearch();
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
        
        #region cameraButton_Click
        /// <summary>
        /// カメラボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cameraButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 保存ディレクトリ
                string saveDir = Path.Combine(iraiHoteiKbn, iraiHokenjoCd, iraiNendo, iraiRenban, FukjBizSystem.SettingReader.GenbaShashinFileFolder);

                using (GetPhotoDialog frm = new GetPhotoDialog(Path.Combine(Settings.Default.FileDirectory, saveDir)))
                {
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK && frm.GetImageFileList().Count > 0)
                    {
                        List<string> fileList = new List<string>();

                        foreach(string fileName in frm.GetImageFileList())
                        {
                            // 相対パス
                            fileList.Add(Path.Combine(saveDir, fileName));
                        }

                        IUpdateGenbaShashinALInput updInput = new UpdateGenbaShashinALInput();

                        updInput.IraiHoteiKbn = iraiHoteiKbn;
                        updInput.IraiHokenjoCd = iraiHokenjoCd;
                        updInput.IraiNendo = iraiNendo;
                        updInput.IraiRenban = iraiRenban;
                        updInput.FilePathList = fileList;

                        IUpdateGenbaShashinALOutput updOutput = new UpdateGenbaShashinApplicationLogic().Execute(updInput);
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

        #region paintButton_Click
        /// <summary>
        /// 落書き（フリーメモ）ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 保存ディレクトリ
                string saveDir = Path.Combine(iraiHoteiKbn, iraiHokenjoCd, iraiNendo, iraiRenban, FukjBizSystem.SettingReader.GenbaShashinFileFolder);

                using (InkCanvasDialog frm = new InkCanvasDialog(Path.Combine(Settings.Default.FileDirectory, saveDir)))
                {
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        List<string> fileList = new List<string>();
                        
                        // 相対パス
                        fileList.Add(Path.Combine(saveDir, frm.GetSaveFileName()));

                        IUpdateGenbaShashinALInput updInput = new UpdateGenbaShashinALInput();

                        updInput.IraiHoteiKbn = iraiHoteiKbn;
                        updInput.IraiHokenjoCd = iraiHokenjoCd;
                        updInput.IraiNendo = iraiNendo;
                        updInput.IraiRenban = iraiRenban;
                        updInput.FilePathList = fileList;

                        IUpdateGenbaShashinALOutput updOutput = new UpdateGenbaShashinApplicationLogic().Execute(updInput);
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
        
        #region tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        /// <summary>
        /// TabControl1のDrawItemイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.SuspendLayout();

                //対象のTabControlを取得
                TabControl tab = (TabControl)sender;
                TabPage page = tab.TabPages[e.Index];

                //タブページのテキストを取得
                string txt = page.Text;

                //タブのテキストと背景を描画するためのブラシを決定する
                Brush foreBrush, backBrush;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    foreBrush = new SolidBrush(page.ForeColor);
                    backBrush = Brushes.Yellow;
                }
                else
                {
                    foreBrush = new SolidBrush(page.ForeColor);
                    backBrush = new SolidBrush(page.BackColor);
                }

                //StringFormatを作成
                StringFormat sf = new StringFormat();
                //水平垂直方向の中央に、行が完全に表示されるようにする
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                sf.FormatFlags |= StringFormatFlags.LineLimit;

                //背景の描画
                e.Graphics.FillRectangle(backBrush, e.Bounds);

                //Textの描画
                e.Graphics.DrawString(txt, page.Font, foreBrush, e.Bounds, sf);

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                this.ResumeLayout();

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
                    using (MapWorksForm frm = new MapWorksForm(CreateMapPoint(), iraiRowIndex, false))
                    {
                        try
                        {
                            frm.ShowDialog();
                        }
                        catch
                        {
                            // 多重起動になった際のDisposeで失敗することがあるが・・・
                        }
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

        #region タブ切り替え制御

        /// <summary>
        /// 表示中のタブインデックス
        /// </summary>
        private int myTabIndex = -1;

        /// <summary>
        /// 選択を戻すために発生させたイベント
        /// </summary>
        private bool myChangeEvent = false;

        /// <summary>
        /// タブ選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // このイベント内で発生させた選択の変更は処理しない
            if (myChangeEvent)
            {
                myChangeEvent = false;
                return;
            }

            // 2015.02.01 toyoda Add Start
            // プレビュー後に戻るタブ番号を保存
            int afterPreviewBackTabIndex = myTabIndex;
            // 2015.02.01 toyoda Add End

            // 遷移元の画面がBaseを継承している場合のみ
            if (tabControl.TabPages[myTabIndex].Controls.Count != 0
                && tabControl.TabPages[myTabIndex].Controls[0] is BaseKensaTabPage)
            {
                // 遷移の確認
                if (myTabIndex != -1 && !((BaseKensaTabPage)(tabControl.TabPages[myTabIndex].Controls[0])).MenuClosing())
                {
                    // 遷移を戻す（同イベントが発生するが、2度目の処理はスキップされる）
                    myChangeEvent = true;
                    tabControl.SelectedIndex = myTabIndex;
                }
                else
                {
                    // 遷移先のインデックスを保持
                    myTabIndex = tabControl.SelectedIndex;
                }
            }
            else
            {
                // 遷移先のインデックスを保持
                myTabIndex = tabControl.SelectedIndex;
            }

            if (tabControl.SelectedTab.Name == kensaShuuryouTabPage.Name)
            {
                CompleteKensa(false);

                // 2015.02.01 toyoda Add Start
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                this.Close();
                // 2015.02.01 toyoda Add End
            }

            // 2015.02.01 toyoda Add Start
            if (tabControl.SelectedTab.Name == kekkashoTabPage.Name)
            {
                // プレビュー画面は表示しない
                tabControl.SelectedIndex = afterPreviewBackTabIndex;

                // 遷移先のインデックスを保持
                myTabIndex = tabControl.SelectedIndex;

                Thread t = new Thread(PrintKekkashoPreview);
                t.Start();
            }
            // 2015.02.01 toyoda Add End
        }

        #endregion

        #region メソッド(public)

        #region ExecSearch()
        /// <summary>
        /// 表示内容を強制的に更新する
        /// </summary>
        public void ExecSearch()
        {
            DoSearch();
        }
        #endregion

        #region DoClose()
        /// <summary>
        /// 子画面の初期ロードエラー時は親画面ごと終了する
        /// </summary>
        public void DoClose()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Close();
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

                kensaDataSet.JokasoDaichoMstLocation.Clear();

                IGetKensaInfoALInput alInput = new GetKensaInfoALInput();

                alInput.IraiHoteiKbn = this.iraiHoteiKbn;
                alInput.IraiHokenjoCd = this.iraiHokenjoCd;
                alInput.IraiNendo = this.iraiNendo;
                alInput.IraiRenban = this.iraiRenban;

                IGetKensaInfoALOutput alOutput = new GetKensaInfoApplicationLogic().Execute(alInput);

                // 想定外・・・
                if (alOutput.KensaYoteiList.Count == 0 || alOutput.JokasoDaichoMstLocation.Count == 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Info, "表示データがありません。");
                    return;
                }

                kensaDataSet.KensaYoteiList.Merge(alOutput.KensaYoteiList);

                kensaDataSet.JokasoDaichoMstLocation.Merge(alOutput.JokasoDaichoMstLocation);

                // 位置情報
                if (!kensaDataSet.JokasoDaichoMstLocation[0].IsJokasoLocationUpdateDtNull())
                {
                    locationInfoLabel.Text = kensaDataSet.JokasoDaichoMstLocation[0].JokasoLocationUpdateDt.ToString("yyyy/MM/dd HH:mm");
                }

                // 非バインディング列の編集
                foreach (DataGridViewRow row in kensaListDataGridView.Rows)
                {
                    // No.
                    row.Cells[RowIndex.Index].Value = this.iraiRowIndex;

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

                    // 2015.01.11 toyoda Add Start
                    // 請求方法が「3：請求」「4：指定請求書」の場合は赤字にする
                    if (row.Cells[nyuukinHouhouKbnValueDataGridViewTextBoxColumn.Index].Value.ToString() == "3"
                        || row.Cells[nyuukinHouhouKbnValueDataGridViewTextBoxColumn.Index].Value.ToString() == "4")
                    {
                        // 請求方法
                        row.Cells[Seikyu.Index].Style.ForeColor = Color.Red;
                        row.Cells[Seikyu.Index].Style.SelectionForeColor = Color.Red;
                    }
                    // 2015.01.11 toyoda Add End
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

        #region StartKensa(bool manual)
        /// <summary>
        /// 検査状況更新（開始、再開）
        /// </summary>
        /// <param name="manual">手動実行</param>
        /// <returns></returns>
        private bool StartKensa(bool manual)
        {
            // 現在のステータスを取得
            IGetKensaTimesALInput alInput = new GetKensaTimesALInput();

            alInput.IraiHoteiKbn = this.iraiHoteiKbn;
            alInput.IraiHokenjoCd = this.iraiHokenjoCd;
            alInput.IraiNendo = this.iraiNendo;
            alInput.IraiRenban = this.iraiRenban;

            IGetKensaTimesALOutput alOutput = new GetKensaTimesApplicationLogic().Execute(alInput);

            // 状況区分
            string status = alOutput.KensaKekkaForTimesUpdate[0].IsKensaKekkaKensaJoukyouKbnNull() || string.IsNullOrEmpty(alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaJoukyouKbn)
                ? Constants.KensaJoukyouKbn.INITIAL : alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaJoukyouKbn;

            DateTime current = DateTime.Now;
            if (status == Constants.KensaJoukyouKbn.INITIAL || status == Constants.KensaJoukyouKbn.STOPPED)
            {
                string proc = status == Constants.KensaJoukyouKbn.INITIAL ? "開始" : "再開";

                // 初期状態であれば、開始確認のメッセージを表示する
                if (TabMessageBox.Show2(TabMessageBox.Type.YesNo, string.Format("検査{0}", proc),
                                       string.Format("{0}時刻:{1}\r\n\r\n検査時間の計測を{0}します。よろしいですか？\r\n※計測を{0}しない場合、検査結果を登録することはできません。",
                                            proc,
                                            current.ToString("HH時mm分ss秒"))) == System.Windows.Forms.DialogResult.Yes)
                {
                    // メッセージ結果が「はい」の場合ステータスを更新
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable datatable = new KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable();
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateRow newRow = datatable.NewKensaKekkaForTimesUpdateRow();

                    newRow.KensaKekkaIraiHoteiKbn = this.iraiHoteiKbn;
                    newRow.KensaKekkaIraiHokenjoCd = this.iraiHokenjoCd;
                    newRow.KensaKekkaIraiNendo = this.iraiNendo;
                    newRow.KensaKekkaIraiRenban = this.iraiRenban;

                    // 開始時間=Now
                    newRow.KensaKekkaKensaStartDt = current;
                    // 終了時間=Null
                    newRow.SetKensaKekkakensaEndDtNull();
                    // 検査時間=検査時間（更新なし）
                    newRow.KensaKekkaKensaTimes = alOutput.KensaKekkaForTimesUpdate[0].IsKensaKekkaKensaTimesNull() ? 0 : alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaTimes;
                    // ステータス="検査中"
                    newRow.KensaKekkaKensaJoukyouKbn = Constants.KensaJoukyouKbn.IN_WORK;

                    datatable.AddKensaKekkaForTimesUpdateRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetModified();

                    // 更新実行
                    IUpdateKensaTimesALInput updInput = new UpdateKensaTimesALInput();
                    updInput.KensaKekkaForTimesUpdate = datatable;
                    IUpdateKensaTimesALOutput updOutput = new UpdateKensaTimesApplicationLogic().Execute(updInput);
                }
                else
                {
                    // メッセージ結果が「はい」以外の場合、falseを返す
                    return false;
                }
            }
            else if (manual && (status == Constants.KensaJoukyouKbn.STOPPED || status == Constants.KensaJoukyouKbn.COMPLETE))
            {
                // 手動実行でかつ中断、完了であれば再開確認のメッセージを表示する
                if (TabMessageBox.Show2(TabMessageBox.Type.YesNo, "検査再開",
                                       string.Format("再開時刻:{0}\r\n\r\n検査時間の計測を再開します。よろしいですか？",
                                            current.ToString("HH時mm分ss秒"))) == System.Windows.Forms.DialogResult.Yes)
                {
                    // メッセージ結果が「はい」の場合ステータスを更新
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable datatable = new KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable();
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateRow newRow = datatable.NewKensaKekkaForTimesUpdateRow();

                    newRow.KensaKekkaIraiHoteiKbn = this.iraiHoteiKbn;
                    newRow.KensaKekkaIraiHokenjoCd = this.iraiHokenjoCd;
                    newRow.KensaKekkaIraiNendo = this.iraiNendo;
                    newRow.KensaKekkaIraiRenban = this.iraiRenban;

                    // 開始時間=Now
                    newRow.KensaKekkaKensaStartDt = current;
                    // 終了時間=Null
                    newRow.SetKensaKekkakensaEndDtNull();
                    // 検査時間=検査時間（更新なし）
                    newRow.KensaKekkaKensaTimes = alOutput.KensaKekkaForTimesUpdate[0].IsKensaKekkaKensaTimesNull() ? 0 : alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaTimes;
                    // ステータス="検査中"
                    newRow.KensaKekkaKensaJoukyouKbn = Constants.KensaJoukyouKbn.IN_WORK;

                    datatable.AddKensaKekkaForTimesUpdateRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetModified();

                    // 更新実行
                    IUpdateKensaTimesALInput updInput = new UpdateKensaTimesALInput();
                    updInput.KensaKekkaForTimesUpdate = datatable;
                    IUpdateKensaTimesALOutput updOutput = new UpdateKensaTimesApplicationLogic().Execute(updInput);
                }
            }            

            return true;
        }
        #endregion

        #region CompleteKensa(bool stop)
        /// <summary>
        /// 検査状況更新（中断、終了）
        /// </summary>
        /// <param name="stop">中断フラグ</param>
        /// <returns></returns>
        private bool CompleteKensa(bool stop)
        {
            // 現在のステータスを取得
            IGetKensaTimesALInput alInput = new GetKensaTimesALInput();

            alInput.IraiHoteiKbn = this.iraiHoteiKbn;
            alInput.IraiHokenjoCd = this.iraiHokenjoCd;
            alInput.IraiNendo = this.iraiNendo;
            alInput.IraiRenban = this.iraiRenban;

            IGetKensaTimesALOutput alOutput = new GetKensaTimesApplicationLogic().Execute(alInput);

            // 状況区分
            string status = alOutput.KensaKekkaForTimesUpdate[0].IsKensaKekkaKensaJoukyouKbnNull() ? Constants.KensaJoukyouKbn.INITIAL : alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaJoukyouKbn;

            DateTime current = DateTime.Now;
            if (stop && status == Constants.KensaJoukyouKbn.IN_WORK)
            {
                // 中断でかつ検査中状態であれば、中断確認のメッセージを表示する
                if (TabMessageBox.Show2(TabMessageBox.Type.YesNo, "検査中断",
                                       string.Format("中断時刻:{0}\r\n\r\n検査を中断します。原状回復しましたか？\r\n(操作スイッチ・マンホール・制御盤、照明、フェンス類の施錠等)", current.ToString("HH時mm分ss秒")),
                                       Color.Yellow,
                                       Color.Red) == System.Windows.Forms.DialogResult.Yes)
                {
                    // メッセージ結果が「はい」の場合ステータスを更新
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable datatable = new KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable();
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateRow newRow = datatable.NewKensaKekkaForTimesUpdateRow();

                    newRow.KensaKekkaIraiHoteiKbn = this.iraiHoteiKbn;
                    newRow.KensaKekkaIraiHokenjoCd = this.iraiHokenjoCd;
                    newRow.KensaKekkaIraiNendo = this.iraiNendo;
                    newRow.KensaKekkaIraiRenban = this.iraiRenban;

                    // 開始時間=開始時間（更新なし）
                    newRow.KensaKekkaKensaStartDt = alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaStartDt;
                    // 終了時間=Now
                    newRow.KensaKekkakensaEndDt = current;

                    TimeSpan ts = newRow.KensaKekkakensaEndDt - newRow.KensaKekkaKensaStartDt;

                    // 検査時間=検査時間＋（終了時間－開始時間）
                    newRow.KensaKekkaKensaTimes = (alOutput.KensaKekkaForTimesUpdate[0].IsKensaKekkaKensaTimesNull() ? 0 : alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaTimes) + ts.Minutes;
                    // ステータス="中断"
                    newRow.KensaKekkaKensaJoukyouKbn = Constants.KensaJoukyouKbn.STOPPED;

                    datatable.AddKensaKekkaForTimesUpdateRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetModified();

                    // 更新実行
                    IUpdateKensaTimesALInput updInput = new UpdateKensaTimesALInput();
                    updInput.KensaKekkaForTimesUpdate = datatable;
                    IUpdateKensaTimesALOutput updOutput = new UpdateKensaTimesApplicationLogic().Execute(updInput);
                }
            }
            else if (!stop && status == Constants.KensaJoukyouKbn.IN_WORK)
            {
                //　終了でかつ検査中状態であれば、終了確認のメッセージを表示する
                if (TabMessageBox.Show2(TabMessageBox.Type.YesNo, "検査終了",
                                       string.Format("終了時刻:{0}\r\n\r\n検査を終了します。原状回復しましたか？\r\n(操作スイッチ・マンホール・制御盤、照明、フェンス類の施錠等)", current.ToString("HH時mm分ss秒")),
                                       Color.Yellow,
                                       Color.Red) == System.Windows.Forms.DialogResult.Yes)
                {
                    // メッセージ結果が「はい」の場合ステータスを更新
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable datatable = new KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable();
                    KensaKekkaTblDataSet.KensaKekkaForTimesUpdateRow newRow = datatable.NewKensaKekkaForTimesUpdateRow();

                    newRow.KensaKekkaIraiHoteiKbn = this.iraiHoteiKbn;
                    newRow.KensaKekkaIraiHokenjoCd = this.iraiHokenjoCd;
                    newRow.KensaKekkaIraiNendo = this.iraiNendo;
                    newRow.KensaKekkaIraiRenban = this.iraiRenban;

                    // 開始時間=開始時間（更新なし）
                    newRow.KensaKekkaKensaStartDt = alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaStartDt;
                    // 終了時間=Now
                    newRow.KensaKekkakensaEndDt = current;

                    TimeSpan ts = newRow.KensaKekkakensaEndDt - newRow.KensaKekkaKensaStartDt;

                    // 検査時間=検査時間＋（終了時間－開始時間）
                    newRow.KensaKekkaKensaTimes = (alOutput.KensaKekkaForTimesUpdate[0].IsKensaKekkaKensaTimesNull() ? 0 : alOutput.KensaKekkaForTimesUpdate[0].KensaKekkaKensaTimes) + ts.Minutes;
                    // ステータス="終了"
                    newRow.KensaKekkaKensaJoukyouKbn = Constants.KensaJoukyouKbn.COMPLETE;

                    datatable.AddKensaKekkaForTimesUpdateRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetModified();

                    // 更新実行
                    IUpdateKensaTimesALInput updInput = new UpdateKensaTimesALInput();
                    updInput.KensaKekkaForTimesUpdate = datatable;
                    IUpdateKensaTimesALOutput updOutput = new UpdateKensaTimesApplicationLogic().Execute(updInput);
                }
            }

            // 最初のタブを選択状態とする
            tabControl.SelectedIndex = 0;

            return true;
        }
        #endregion

        #region PrintKekkashoPreview()
        /// <summary>
        /// 結果書プレビュー表示
        /// </summary>
        /// <returns></returns>
        private void PrintKekkashoPreview()
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IGetPreviewALInput alInput = new GetPreviewALInput();

                alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

                IGetPreviewALOutput alOutput = new GetPreviewApplicationLogic().Execute(alInput);

                if (string.IsNullOrEmpty(alOutput.SavePath))
                {
                    // データなしは想定外
                    throw new CustomException(0, "検査結果が取得できませんでした。");
                }

                // PDFを開く
                System.Diagnostics.Process.Start(alOutput.SavePath);

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
    #endregion
}
