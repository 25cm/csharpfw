using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/26　habu　　    新規作成
    /// 2014/12/19　habu　　    連携対象にカレンダ画面を追加
    /// 2014/12/22　habu　　    閉じるボタンを追加
    /// </history>
    public partial class KensaYoteiMap : FukjBaseForm
    {
        #region 定義

        #region enum

        // NOTICE 順番は通常アイコン, 同点滅アイコンの順にすること
        public enum YOTEI_ICON_TYPE
        {
            /// <summary>
            /// 本日検査予定
            /// </summary>
            YOTEI_TODAY,
            /// <summary>
            /// 本日検査予定
            /// </summary>
            YOTEI_TODAY_BLINK,
        }

        public enum MAP_MODE
        {
            /// <summary>
            /// 通常
            /// </summary>
            NORMAL,
            /// <summary>
            /// 検査予定アイコン移動用
            /// </summary>
            MOVE,
        }

        #endregion

        #region 定数

        /// <summary>
        /// アイコンにフキダシ表示する際の、マウスカーソル検知範囲
        /// </summary>
        private const int MOUSE_HOVER_RANGE = 500;

        /// <summary>
        /// アイコン表示レイヤ番号
        /// </summary>
        private const int ICON_LAYER_NO = 1;

        /// <summary>
        /// アイコン表示レイヤ名(初期生成時のみ適用)
        /// </summary>
        private const string ICON_LAYER_NAME = "KensaYoteiIconLayer";

        private readonly string DEFAULT_ADDRESS = Properties.Settings.Default.DefaultMapAddress;

        #endregion

        #endregion

        #region プロパティ

        #endregion

        #region 連携対象画面

        /// <summary>
        /// 
        /// </summary>
        public KensaMemoList memoForm;
        /// <summary>
        /// 
        /// </summary>
        public KensaYoteiCalender calenderForm;
        /// <summary>
        /// 
        /// </summary>
        public KensaYoteiList yoteiForm;

        /// <summary>
        /// 検査計画画面の共通データソース
        /// </summary>
        private KensaKeikakuDataSource editDataSource;

        #endregion

        // 同じアイコンのインスタンスは共有する
        private static System.Drawing.Image imgKensaToday = global::FukjBizSystem.Properties.Resources.yoteiIcon1;
        // TODO 点滅用反転アイコンは、画像処理での生成を検討する
        private static System.Drawing.Image imgKensaTodayBlink = global::FukjBizSystem.Properties.Resources.yoteiIcon1b;

        //// 拡大ｽﾞｰﾑ率
        //private int ZoomInRate = 0;
        //// 縮小ｽﾞｰﾑ率
        //private int ZoomOutRate = 0;

        private const int DEFAULT_SCALE = 2000;

        // TODO この辺の挙動(表示切替時の縮尺関連)はもう少し検討
        /// <summary>
        /// 初期状態での縮尺
        /// </summary>
        //private int stdMapScale = 0;
        /// <summary>
        /// 予定アイコン表示位置に移動する際の縮尺
        /// </summary>
        //private int yoteiIconMapScale = 0;

        #region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public KensaYoteiMap()
        {
            InitializeComponent();

            // 地図コントロールからのコールバックメソッド(イベント)設定
            mwView.IconSelected += IconSelected;
            mwView.IconAddressMoved += IconAddressMoved;
        }

        #endregion

        #region イベント

        #region KensaYoteiMap_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaYoteiMap_Load(object sender, EventArgs e)
        {
            BoundaryUtility.StdLoadEventSequence(this,
                delegate()
                {
                    // メニューボタン無効化
                    Program.mForm.SetMenuEnabled(false);

                    // MapWorks初期化
                    bool bRet = mwView.Initialize();

                    if (bRet == false)
                    {
                        MessageBox.Show("MapWorks の初期化に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // メニューボタン有効化
                        Program.mForm.SetMenuEnabled(true);

                        return;
                    }

                    // Icon用レイヤー確保(無い場合は生成)
                    mwView.ReserveLayer(ICON_LAYER_NAME, ICON_LAYER_NO, DEFAULT_SCALE);

                    // 共有データソース初期化
                    editDataSource = new KensaKeikakuDataSource();

                    #region 表示データ設定

                    // 表示データ取得
                    KensaKeikakuDataSet.KensaKeikakuListDataTable table = editDataSource.GetKensaYoteiData();

                    KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable memoTable = editDataSource.GetKensaYoteiMemoData();

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        KensaKeikakuDataSet.KensaKeikakuListRow row = table[i];

                        // 予定日が未入力の場合もある(その場合は空で表示する)
                        string yoteiDt = GetKensaYoteiDateStr(row);

                        string tooltipStr = GetJokasoInfoStr(row);

                        // メモ情報取得
                        string memoStr = GetJokasoMemoStr(row);

                        if (!string.IsNullOrEmpty(memoStr))
                        {
                            tooltipStr = tooltipStr + "\r\n" + memoStr;
                        }

                        // キー、座標、予定日から、アイコンを生成・表示

                        string key = editDataSource.GetKensaIraiKey(row);

                        int mapX;
                        int mapY;
                        double lonW;
                        double latW;

                        // 緯度経度または住所からMapWorks座標を取得
                        if (GetMapPoint(table, row, out mapX, out mapY, out lonW, out latW))
                        {
                            // 座標が設定されていない浄化槽で、住所から緯度経度が判明した場合は設定 -> 確定時にDBに反映される
                            // 小数点を除いた文字列形式にし、更新する(小数部7桁固定)
                            row[table.JokasoZenrinIdoCdColumn] = latW.ToString("0.0000000").Replace(".", "");
                            row[table.JokasoZenrinKeidoCdColumn] = lonW.ToString("0.0000000").Replace(".", "");
                        }

                        // 検査予定アイコンを地図表示データとして追加(座標指定)
                        mwView.AddIcon(key, mapX, mapY, yoteiDt, tooltipStr, ZMapControlMW.YOTEI_ICON_TYPE.YOTEI_TODAY);

                        #region to be removed
                        //// 緯度経度が設定されている場合は、そちらを優先的に使用する
                        //string ido = TypeUtility.GetString(row[table.JokasoZenrinIdoCdColumn]);
                        //string keido = TypeUtility.GetString(row[table.JokasoZenrinKeidoCdColumn]);

                        //int idoNum = 0;
                        //int keidoNum = 0;
                        //double lonW = 0;
                        //double latW = 0;
                        //double lonJ = 0;
                        //double latJ = 0;

                        //if (int.TryParse(ido, out idoNum) && int.TryParse(keido, out keidoNum)
                        //    && double.TryParse(ido.Insert(ido.Length - 7, "."), out latW) && double.TryParse(keido.Insert(keido.Length - 7, "."), out lonW)
                        //   )
                        //{
                        //    // 日本測地系に変換
                        //    MapLocationUtility.WLocToJLoc(lonW, latW, out lonJ, out latJ);

                        //    // MapWorks座標に変換して表示
                        //    mwView.AddIcon(key, MapLocationUtility.GetMapPoint(lonJ), MapLocationUtility.GetMapPoint(latJ), yoteiDt, tooltipStr, ZMapControlMW.YOTEI_ICON_TYPE.YOTEI_TODAY);
                        //}
                        //else
                        //{
                        //    // 設置場所住所正規化
                        //    string setchiAdr = GetNormalizedAddress(
                        //        TypeUtility.GetString(row[table.TodofukenNmColumn])
                        //        , TypeUtility.GetString(row[table.JokasoSetchiBashoAdrColumn]));
                            
                        //    int mapX = 0;
                        //    int mapY = 0;
                        //    short kNo = 0;

                        //    // の場合、ロード時に座標を設定する -> 確定時にDBに反映される
                        //    if (mwView.GetAddressPos(setchiAdr, string.Empty, string.Empty, ref kNo, ref mapX, ref mapY))
                        //    {
                        //        lonJ = MapLocationUtility.GetLocationPoint(mapX);
                        //        latJ = MapLocationUtility.GetLocationPoint(mapY);

                        //        MapLocationUtility.JLocToWLoc(lonJ, latJ, out lonW, out latW);

                        //        // 小数点を除いた文字列形式にし、更新する(小数部7桁固定)
                        //        row[table.JokasoZenrinIdoCdColumn] = latW.ToString("0.0000000").Replace(".", "");
                        //        row[table.JokasoZenrinKeidoCdColumn] = lonW.ToString("0.0000000").Replace(".", "");
                        //    }

                        //    // 検査予定アイコンを地図表示データとして追加(座標指定)
                        //    mwView.AddIcon(key, mapX, mapY, yoteiDt, tooltipStr, ZMapControlMW.YOTEI_ICON_TYPE.YOTEI_TODAY);
                        //}
                        #endregion

                    }

                    // 地図表示位置移動
                    if (table.Rows.Count == 0)
                    {
                        // デフォルトの表示位置に移動(対象データが無い場合はこちらが表示される)
                        mwView.MoveTo(DEFAULT_ADDRESS, string.Empty, string.Empty);
                    }
                    else
                    {
                        KensaKeikakuDataSet.KensaKeikakuListRow row = table[0];

                        int mapX;
                        int mapY;
                        double lonW;
                        double latW;

                        // 緯度経度または住所からMapWorks座標を取得
                        GetMapPoint(table, row, out mapX, out mapY, out lonW, out latW);

                        // 緯度経度が設定されている場合は、そちらを優先的に使用する
                        string ido = TypeUtility.GetString(row[table.JokasoZenrinIdoCdColumn]);
                        string keido = TypeUtility.GetString(row[table.JokasoZenrinKeidoCdColumn]);

                        // 地図表示位置を移動(座標基準)
                        mwView.MoveTo(mapX, mapY);

                        #region to be removed
                        //int idoNum = 0;
                        //int keidoNum = 0;
                        //double lonW = 0;
                        //double latW = 0;
                        //double lonJ = 0;
                        //double latJ = 0;

                        //if (int.TryParse(ido, out idoNum) && int.TryParse(keido, out keidoNum)
                        //    && double.TryParse(ido.Insert(ido.Length - 7, "."), out latW) && double.TryParse(keido.Insert(keido.Length - 7, "."), out lonW)
                        //    )
                        //{
                        //    // 日本測地系に変換
                        //    MapLocationUtility.WLocToJLoc(lonW, latW, out lonJ, out latJ);

                        //    // 地図表示位置を移動(座標基準)
                        //    mwView.MoveTo(MapLocationUtility.GetMapPoint(lonJ), MapLocationUtility.GetMapPoint(latJ));
                        //}
                        //else
                        //{
                        //    // 設置場所住所正規化
                        //    string setchiAdr = GetNormalizedAddress(
                        //        TypeUtility.GetString(row[table.TodofukenNmColumn])
                        //        , TypeUtility.GetString(row[table.JokasoSetchiBashoAdrColumn]));

                        //    // 地図表示位置を移動(設置場所基準)
                        //    mwView.MoveTo(setchiAdr, string.Empty, string.Empty);
                        //}
                        #endregion
                    }

                    #endregion

                    // 初回は通常モードで表示
                    mwView.ToNormalMode();

                    // 地図の再描画
                    mwView.EndUpdate();
                }
                , closeBody: delegate()
                {
                    // メニューボタン有効化
                    Program.mForm.SetMenuEnabled(true);
                }
                );
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (editDataSource != null && editDataSource.IsEdited)
                    {
                        // 編集破棄確認
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容を破棄し、画面を終了します。よろしいですか？") != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    Program.mForm.MovePrev();
                });
        }

        #region KensaYoteiMap_FormClosing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaYoteiMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 子画面を閉じる
            CloseSubForms();

            // メニュー有効化
            Program.mForm.SetMenuEnabled(true);
        }
        #endregion

        #region 子画面起動ボタン

        #region memoListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memoListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (memoForm == null || memoForm.IsDisposed)
                    {
                        memoForm = new KensaMemoList(this, editDataSource);
                    }
                    memoForm.Show();
                });
        }
        #endregion

        #region calenderButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calenderButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (calenderForm == null || calenderForm.IsDisposed)
                    {
                        calenderForm = new KensaYoteiCalender(this, editDataSource);
                    }
                    calenderForm.Show();
                });
        }
        #endregion

        #region yoteiListButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yoteiListButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (yoteiForm == null || yoteiForm.IsDisposed)
                    {
                        yoteiForm = new KensaYoteiList(this, editDataSource);
                    }
                    yoteiForm.Show();
                });
        }
        #endregion

        #region heijyunkaButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heijyunkaButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    KensaYoteiHeijyunForm frm = new KensaYoteiHeijyunForm();
                    frm.Show();
                });
        }
        #endregion

        #region allButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (memoForm == null || memoForm.IsDisposed)
                    {
                        memoForm = new KensaMemoList(this, editDataSource);
                    }
                    memoForm.Show();

                    if (calenderForm == null || calenderForm.IsDisposed)
                    {
                        calenderForm = new KensaYoteiCalender(this, editDataSource);
                    }
                    calenderForm.Show();

                    if (yoteiForm == null || yoteiForm.IsDisposed)
                    {
                        yoteiForm = new KensaYoteiList(this, editDataSource);
                    }
                    yoteiForm.Show();
                });
        }
        #endregion

        #endregion

        #region 地図操作ボタン

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            // 拡大表示
            mwView.ZoomIn();
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            // 縮小表示
            mwView.ZoomOut();
        }

        private void modeNormalButton_Click(object sender, EventArgs e)
        {
            mwView.ToNormalMode();
        }

        private void modeMoveButton_Click(object sender, EventArgs e)
        {
            mwView.ToMoveMode();
        }

        #endregion

        #region 登録ボタン

        #region decisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decisionButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 確定登録確認
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査予定日、設置場所の変更を確定・登録します。よろしいですか？") != DialogResult.Yes)
                    {
                        return;
                    }

                    // メモリ上の編集データをDBに反映
                    editDataSource.WriteBackToDB();
                }
            );
        }
        #endregion

        #endregion

        #region IconSelected
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        private void IconSelected(string key)
        {
            // フキダシの表示を切替え
            mwView.SetIconSelected(key, true);

            // 検査予定一覧の表示を同期
            if (yoteiForm != null)
            {
                yoteiForm.SelectKensaYotei(key);
            }

            // メモ一覧の表示を同期
            if (memoForm != null)
            {
                memoForm.SelectKensaYotei(key);
            }
        }
        #endregion

        #region IconAddressMoved
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="address1">番地まで</param>
        /// <param name="address2">建物名</param>
        /// <param name="addressName"></param>
        /// <param name="kind"></param>
        private void IconAddressMoved(string key, string address1, string address2, string addressName, short kind, int mapX, int mapY)
        {
            // 必要であれば建物名まで設定する(旧PCシステムでは、ざっと確認した限り番地までの入力)
            string newAddress = address1;

            // メモリ上データの住所を更新
            editDataSource.SetJokasoSetchiBashoAddr(key, newAddress);

            double lonW;
            double latW;

            MapLocationUtility.JLocToWLoc(MapLocationUtility.GetLocationPoint(mapX),MapLocationUtility.GetLocationPoint(mapY), out lonW , out latW);

            // メモリ上データの緯度経度を更新
            editDataSource.SetJokasoLocation(key, lonW, latW);

            // メモラベルの表示を更新
            KensaKeikakuDataSet.KensaKeikakuListRow kensaRow = editDataSource.GetKensaIraiRow(key);

            string tooltipStr = GetJokasoInfoStr(kensaRow);

            string memoStr = GetJokasoMemoStr(kensaRow);

            if (!string.IsNullOrEmpty(memoStr))
            {
                tooltipStr = tooltipStr + "\r\n" + memoStr;
            }

            mwView.SetKensaYoteiMemo(key, tooltipStr);

            // 検査予定一覧の表示を同期
            if (yoteiForm != null)
            {
                yoteiForm.SetJokasoSetchiAddress(key, newAddress);
            }

            // メモ一覧の表示を同期
            if (memoForm != null)
            {
                memoForm.SetJokasoSetchiAddress(key, newAddress);
            }

            // カレンダは設置場所を扱わないため、同期不要
        }
        #endregion

        #region CloseSubForms
        /// <summary>
        /// 
        /// </summary>
        private void CloseSubForms()
        {
            // 子画面を閉じる
            if (memoForm != null)
            {
                memoForm.Close();
            }
            if (calenderForm != null)
            {
                calenderForm.Close();
            }
            if (yoteiForm != null)
            {
                yoteiForm.Close();
            }
        }
        #endregion

        #region GetJokasoMemoStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetJokasoMemoStr(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            // メモ情報取得
            string memoStr = string.Empty;

            memoStr = GetJokasoMemoStr(
                 TypeUtility.GetString(row[table.JokasoHokenjoCdColumn.ColumnName])
                , TypeUtility.GetString(row[table.JokasoTorokuNendoColumn.ColumnName])
                , TypeUtility.GetString(row[table.JokasoRenbanColumn.ColumnName])
                );

            return memoStr;
        }
        #endregion

        #region GetJokasoMemoStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjoCd"></param>
        /// <param name="nendo"></param>
        /// <param name="renban"></param>
        /// <returns></returns>
        private string GetJokasoMemoStr(string hokenjoCd, string nendo, string renban)
        {
            // メモ情報取得
            string memoStr = string.Empty;

            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable memoTable = new KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable();

            KensaKeikakuDataSet.KensaKeikakuMemoTblRow[] memoRows = (KensaKeikakuDataSet.KensaKeikakuMemoTblRow[])memoTable
                .Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'"
                    , memoTable.JokasoMemoJokasoHokenjoCdColumn.ColumnName
                    , hokenjoCd
                    , memoTable.JokasoMemoJokasoTorokuNendoColumn.ColumnName
                    , nendo
                    , memoTable.JokasoMemoJokasoRenbanColumn.ColumnName
                    , renban
                ));

            foreach (KensaKeikakuDataSet.KensaKeikakuMemoTblRow memoRow in memoRows)
            {
                memoStr += TypeUtility.GetString(memoRow[memoTable.MemoColumn.ColumnName]) + "\r\n";
            }

            return memoStr;
        }
        #endregion

        #region GetKensaYoteiDateStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetKensaYoteiDateStr(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            string yoteiDt = editDataSource.GetKensaYoteiDateShortStr(row);

            #region to be removed

            //KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            //string tsuki = TypeUtility.GetString(row[table.KensaIraiKensaYoteiTsukiColumn.ColumnName]);
            //string bi = TypeUtility.GetString(row[table.KensaIraiKensaYoteiBiColumn.ColumnName]);

            //string yoteiDt = string.Empty;

            //if (!string.IsNullOrEmpty(tsuki) && !string.IsNullOrEmpty(bi))
            //{
            //    yoteiDt = string.Join("/"
            //        , new string[] {
            //         tsuki
            //        , bi
            //        });
            //}

            #endregion

            return yoteiDt;
        }
        #endregion

        #region GetJokasoInfoStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetJokasoInfoStr(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            string tooltipStr =
                  "検査種別:" + TypeUtility.GetString(row[table.KensaIraiHoteiKbnNmColumn.ColumnName]) + "\r\n"
                + "設置者:" + TypeUtility.GetString(row[table.JokasoSetchishaNmColumn.ColumnName]) + "\r\n"
                + "設置場所:" + TypeUtility.GetString(row[table.JokasoSetchiBashoAdrColumn.ColumnName])
                ;

            return tooltipStr;
        }
        #endregion

        #region 

        #region GetNormalizedAddress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseAdrStr"></param>
        /// <returns></returns>
        private string GetNormalizedAddress(string todoufukenNm, string baseAdrStr)
        {
            // 浄化槽台帳マスタの設置場所住所には、都道府県の文字がある場合と、ない場合が混在しているので、ここで正規化を行う

            // 有効な郵便番号が設定されている場合は、郵便番号と結合した都道府県を使用する

            // 既に県名が含まれていない場合のみ処理する
            if (!baseAdrStr.StartsWith(todoufukenNm))
            {
                baseAdrStr = todoufukenNm + baseAdrStr;
            }

            return baseAdrStr;
        }
        #endregion

        #region GetMapPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="row"></param>
        /// <param name="mapX"></param>
        /// <param name="mapY"></param>
        /// <param name="longtitude">DB保持形式経度</param>
        /// <param name="latitude">DB保持形式緯度</param>
        /// <returns>緯度経度が新たに取得された場合true</returns>
        private bool GetMapPoint(KensaKeikakuDataSet.KensaKeikakuListDataTable table, KensaKeikakuDataSet.KensaKeikakuListRow row, out int mapX, out int mapY, out double longtitude, out double latitude)
        {
            // 緯度経度が設定されている場合は、そちらを優先的に使用する
            string ido = TypeUtility.GetString(row[table.JokasoZenrinIdoCdColumn]);
            string keido = TypeUtility.GetString(row[table.JokasoZenrinKeidoCdColumn]);

            int idoNum = 0;
            int keidoNum = 0;
            double lonW = 0;
            double latW = 0;
            double lonJ = 0;
            double latJ = 0;

            if (int.TryParse(ido, out idoNum) && int.TryParse(keido, out keidoNum)
                // TODO 座標が0の移行データが存在するため、暫定対応
                && ido.Length >= 7 && keido.Length >= 7
                && double.TryParse(ido.Insert(ido.Length - 7, "."), out latW) && double.TryParse(keido.Insert(keido.Length - 7, "."), out lonW)
               )
            {
                longtitude = lonW;
                latitude = latW;

                // 日本測地系に変換
                MapLocationUtility.WLocToJLoc(lonW, latW, out lonJ, out latJ);

                mapX = MapLocationUtility.GetMapPoint(lonJ);
                mapY = MapLocationUtility.GetMapPoint(latJ);

                return false;
            }
            else
            {
                // 設置場所住所正規化
                string setchiAdr = GetNormalizedAddress(
                    TypeUtility.GetString(row[table.TodofukenNmColumn])
                    , TypeUtility.GetString(row[table.JokasoSetchiBashoAdrColumn]));

                mapX = 0;
                mapY = 0;
                short kNo = 0;

                if (mwView.GetAddressPos(setchiAdr, string.Empty, string.Empty, ref kNo, ref mapX, ref mapY))
                {
                    lonJ = MapLocationUtility.GetLocationPoint(mapX);
                    latJ = MapLocationUtility.GetLocationPoint(mapY);

                    // 世界測地系に変換
                    MapLocationUtility.JLocToWLoc(lonJ, latJ, out lonW, out latW);

                    longtitude = lonW;
                    latitude = latW;

                    return true;
                }
                // デフォルト住所が使用された場合
                else
                {
                    longtitude = 0;
                    latitude = 0;

                    return false;
                }
            }
        }
        #endregion

        #endregion

        #endregion

        #region 表示連携用インターフェース

        #region SelectKensaYotei
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void SelectKensaYotei(string key)
        {
            // アイコン位置まで表示を移動
            mwView.MoveToIcon(key);
            
            // アイコンを選択状態にする
            mwView.SetIconSelected(key, true);
        }
        #endregion

        #region SetKensaYoteiDate
        /// <summary>
        /// 指定検査予定のアイコンの予定日の表示を更新する
        /// </summary>
        /// <param name="key"></param>
        /// <param name="yoteiDate"></param>
        public void SetKensaYoteiDate(string key, string yoteiDate)
        {
            if (!editDataSource.IsValidKensaYoteiDate(yoteiDate))
            {
                return;
            }

            string yoteiDt;
            yoteiDt = string.Join("/"
                , new string[] {
                     yoteiDate.Substring(5, 2)
                    , yoteiDate.Substring(8, 2)
                    });

            #region to be removed
            //DateTime tempDate;
            //tempDate = DateTime.ParseExact(yoteiDate, "yyyy/MM/dd", null);

            //string yoteiDt;
            //yoteiDt = string.Join("/"
            //    , new string[] {
            //         tempDate.Month.ToString("00")
            //        , tempDate.Day.ToString("00")
            //        });
            #endregion

            mwView.SetKensaYoteiDate(key, yoteiDt);
        }
        #endregion

        #region SetJokasoSetchiAddress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="address"></param>
        public void SetJokasoSetchiAddress(string key, string address)
        {
            // 地図画面側では特に何もしない
            // (設置場所変更の起点となるため、他の画面の変更を受けて表示を更新する必要はない)
        }
        #endregion

        #endregion

    }
}
