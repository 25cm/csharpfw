using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.ApplicationLogic.MapWorks;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.Boundary.Kensa;
using FukjTabletSystem.Application.DataSet.ACCDB;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Controls;
using FukjTabletSystem.Properties;
using MapWorks50;
using MapWorksViewer.MapWorks;
using Microsoft.VisualBasic.PowerPacks;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.MapWorks
{
    public partial class MapWorksForm : FukjMWBaseForm
    {
        #region フィールド(private)

        /// <summary>
        /// 現在地（指定浄化槽位置）Ｘ座標
        /// </summary>
        private int currentMapPointX = 0;

        /// <summary>
        /// 現在地（指定浄化槽位置）Ｙ座標
        /// </summary>
        private int currentMapPointY = 0;

        /// <summary>
        /// アイコンクリックでの検査メニューへの繊維を許可するか
        /// </summary>
        private bool formMoveEnabled = false;

        /// <summary>
        /// マップ位置情報
        /// </summary>
        private MapPointDataSet.JokasoMapPointDataTable jokasoMapPoint = new MapPointDataSet.JokasoMapPointDataTable();

        /// <summary>
        /// 終了時の状態保存を判定
        /// </summary>
        private bool SaveConditions;

        /// <summary>
        /// 拡大ｽﾞｰﾑ率
        /// </summary>
        private int ZoomInRate = 0;

        /// <summary>
        /// 縮小ｽﾞｰﾑ率
        /// </summary>
        private int ZoomOutRate = 0;
        
        /// <summary>
        /// 範囲選択
        /// </summary>
        private bool RangeSelection = false;

        #region フリーハンド処理関連

        /// <summary>
        /// フリーハンド描画用ピクチャボックス
        /// </summary>
        private TransparentPictureBox tp = null;

        /// <summary>
        /// Graphics オブジェクト
        /// </summary>
        private Graphics grfx;

        /// <summary>
        /// 描画線
        /// </summary>
        private Pen MyPen;

        /// <summary>
        /// shapeContainer
        /// </summary>
        private ShapeContainer shapeContainer;

        /// <summary>
        /// lineShape
        /// </summary>
        private LineShape lineShape;

        /// <summary>
        /// rectangleShape
        /// </summary>
        private RectangleShape rectangleShape;
                
        #endregion

        #region マウス座標

        private int start = 0;  // 1 = 描画中
        private int startX;     // Line X 起点
        private int startY;     // Line Y 起点
        private int maxX;
        private int minX;
        private int maxY;
        private int minY;

        #endregion

        #endregion

        #region 定数(private)

        #region ラベルを描画するためのレイヤー

        /// <summary>
        /// ラベルを描画するためのレイヤー(黒)
        /// </summary>
        private const int LAYER_NO_LABEL_BLACK = 70;

        /// <summary>
        /// ラベルを描画するためのレイヤー(青)
        /// </summary>
        private const int LAYER_NO_LABEL_BLUE = 71;

        /// <summary>
        /// ラベルを描画するためのレイヤー(赤)
        /// </summary>
        private const int LAYER_NO_LABEL_RED = 72;

        /// <summary>
        /// ラベル（順番）を描画するためのレイヤー(固定)※未使用となる
        /// </summary>
        private const int LAYER_NO_LABEL_TEMP_SEQ = 101;
        
        // 2015.01.27 toyoda Add Start 順番の表示方法を変更
        /// <summary>
        /// ラベル（順番背景色）を描画するためのレイヤー(固定 文字色)※1桁用
        /// </summary>
        private const int LAYER_NO_LABEL_TEMP_SEQ_FORE1 = 103;

        /// <summary>
        /// ラベル（順番背景色）を描画するためのレイヤー(固定 文字色)※2桁用
        /// </summary>
        private const int LAYER_NO_LABEL_TEMP_SEQ_FORE2 = 104;

        /// <summary>
        /// ラベル（順番背景色）を描画するためのレイヤー(固定 背景色)
        /// </summary>
        private const int LAYER_NO_LABEL_TEMP_SEQ_BACK = 102;
        // 2015.01.27 toyoda Add End

        /// <summary>
        /// ラベルを描画するためのレイヤー(固定)
        /// </summary>
        private const int LAYER_NO_LABEL_TEMP = 100;

        #endregion

        #region イメージを描画するためのレイヤー

        /// <summary>
        /// イメージを描画するためのレイヤー(Base250)
        /// </summary>
        private const int LAYER_NO_IMAGE_250 = 80;

        /// <summary>
        /// イメージを描画するためのレイヤー(Base500)
        /// </summary>
        private const int LAYER_NO_IMAGE_500 = 81;

        /// <summary>
        /// イメージを描画するためのレイヤー(Base1000)
        /// </summary>
        private const int LAYER_NO_IMAGE_1000 = 82;

        /// <summary>
        /// イメージを描画するためのレイヤー(Base1500)
        /// </summary>
        private const int LAYER_NO_IMAGE_1500 = 83;

        /// <summary>
        /// イメージを描画するためのレイヤー(Base3000)
        /// </summary>
        private const int LAYER_NO_IMAGE_3000 = 84;

        /// <summary>
        /// イメージを描画するためのレイヤー(Base5000)
        /// </summary>
        private const int LAYER_NO_IMAGE_5000 = 85;

        /// <summary>
        /// イメージを描画するためのレイヤー(Base7500)
        /// </summary>
        private const int LAYER_NO_IMAGE_7500 = 86;

        /// <summary>
        /// イメージを描画するためのレイヤー(Base10000)
        /// </summary>
        private const int LAYER_NO_IMAGE_10000 = 87;

        /// <summary>
        /// イメージを描画するためのレイヤー(固定)
        /// </summary>
        private const int LAYER_NO_IMAGE_TEMP = 89;

        #endregion

        #region 線を描画するためのレイヤー

        /// <summary>
        /// 線を描画するためのレイヤー(黒)
        /// </summary>
        private const int LAYER_NO_LINE_BLACK = 90;

        /// <summary>
        /// 線を描画するためのレイヤー(青)
        /// </summary>
        private const int LAYER_NO_LINE_BLUE = 91;

        /// <summary>
        /// 線を描画するためのレイヤー(赤)
        /// </summary>
        private const int LAYER_NO_LINE_RED = 92;

        #endregion

        #endregion

        #region コンストラクタ

        #region MapWorksForm()
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MapWorksForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MapWorksForm()
        {
            InitializeComponent();

            // 2015.01.30 toyoda Add Start GPS情報取得方法の変更
            // GPS読み込み開始
            LocationGpsInfo.StartRead();
            // 2015.01.30 toyoda Add End

            this.formMoveEnabled = true;

            currentMapPointX = 0;
            currentMapPointY = 0;
        }
        #endregion
        
        #region MapWorksForm(MapPointDataSet.JokasoMapPointDataTable jokasoMapPoint, string currentRowIndex, bool formMoveEnabled)
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MapWorksForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="jokasoMapPoint"></param>
        /// <param name="currentRowIndex"></param>
        /// <param name="formMoveEnabled"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MapWorksForm(MapPointDataSet.JokasoMapPointDataTable jokasoMapPoint, string currentRowIndex, bool formMoveEnabled)
        {
            InitializeComponent();

            // 2015.01.30 toyoda Add Start GPS情報取得方法の変更
            // GPS読み込み開始
            LocationGpsInfo.StartRead();
            // 2015.01.30 toyoda Add End

            this.formMoveEnabled = formMoveEnabled;

            this.jokasoMapPoint.Merge(jokasoMapPoint);

            DataRow[] rows = this.jokasoMapPoint.Select(string.Format("KensaIraiRowIndex='{0}'", currentRowIndex));

            if (rows.Length > 0)
            {
                try
                {
                    // 2015.1.20 toyoda Modify Start 使用時に日本測地系に変換
                    //string keido = rows[0]["JokasoZenrinKeidoCd"].ToString().PadLeft(10, '0').Insert(3, ".");
                    //string ido = rows[0]["JokasoZenrinIdoCd"].ToString().PadLeft(10, '0').Insert(3, ".");

                    //// 指定された浄化槽位置
                    //currentMapPointX = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint((double.Parse(keido)));
                    //currentMapPointY = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint((double.Parse(ido)));

                    double longitudeJ;
                    double latitudeJ;

                    // 日本測地系へ変換
                    FukjBizSystem.Application.Utility.MapLocationUtility.WLocToJLoc(double.Parse(rows[0]["JokasoZenrinKeidoCd"].ToString()), double.Parse(rows[0]["JokasoZenrinIdoCd"].ToString()), out longitudeJ, out latitudeJ);

                    // 指定された浄化槽位置
                    currentMapPointX = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint(longitudeJ);
                    currentMapPointY = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint(latitudeJ);
                    // 2015.1.20 toyoda Modify End
                }
                catch
                {
                    currentMapPointX = 0;
                    currentMapPointY = 0;
                }

            }
        }
        #endregion

        #endregion

        #region イベントハンドラ

        #region MapWorksForm_Load(object sender, System.EventArgs e)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapWorksForm_Load(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // XML（旧INI）ﾌｧｲﾙ をｸﾞﾛｰﾊﾞﾙ変数に読み込む
                string dirPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                SettingFile.ReadXml(Path.Combine(dirPath, SettingFile.xmlFileName));

                //終了時の状態保存を判定
                SaveConditions = SettingFile.xmlPara.Save;

                //拡大ｽﾞｰﾑ率
                ZoomInRate = SettingFile.xmlPara.ZoomInRate;

                //縮小ｽﾞｰﾑ率
                ZoomOutRate = SettingFile.xmlPara.ZoomOutRate;

                // 現在地追従を初期化（停止）
                gpsTimer.Interval = Settings.Default.GpsRefleshTimer;
                gpsTimer.Stop();

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

        #region MapWorksForm_Shown(object sender, System.EventArgs e)
        /// <summary>
        /// 地図表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapWorksForm_Shown(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 運用設定名を取得
                string strEnv = SettingFile.xmlPara.Workspace;

                // MWViewｺﾝﾄﾛｰﾙの初期化
                bool bRet = mwView.Initialize(strEnv, "", "");
                if (bRet == false)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Error, "エラー", "地図の初期化に失敗しました");

                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }

                if (mwView.MOverlays.Count == 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Error, "エラー", "オーバーレイの初期化に失敗しました");

                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }

                // ｶﾚﾝﾄｵｰﾊﾞﾚｲの設定
                mwView.MOverlays.SetCurrent(0);
            
                #region レイヤーの追加

                // レイヤーの再作成を行うか
                bool remakeLayer = Settings.Default.RemakeMapLayer;

                #region レイヤー（線描画）

                // 線(黒)用
                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LINE_BLACK) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LINE_BLACK);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LINE_BLACK) == null)
                {
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LINE_BLACK;
                    layer.LayerName = "LAYER_LINE_BLACK";
                    layer.Name = "LAYER_LINE_BLACK";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.ForeColor = Color.Black;
                    layer.BackColor = Color.LightGray;
                    layer.Hatching = true;
                    layer.Transparent = true;
                    layer.LineWidth = 2;

                    mwView.MLayers.Add(layer);
                }

                // 線(青)用
                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LINE_BLUE) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LINE_BLUE);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LINE_BLUE) == null)
                {
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LINE_BLUE;
                    layer.LayerName = "LAYER_LINE_BLUE";
                    layer.Name = "LAYER_LINE_BLUE";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.ForeColor = Color.Blue;
                    layer.BackColor = Color.PaleTurquoise;
                    layer.Hatching = true;
                    layer.Transparent = true;
                    layer.LineWidth = 2;

                    mwView.MLayers.Add(layer);
                }

                // 線(赤)用
                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LINE_RED) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LINE_RED);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LINE_RED) == null)
                {
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LINE_RED;
                    layer.LayerName = "LAYER_LINE_RED";
                    layer.Name = "LAYER_LINE_RED";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.ForeColor = Color.Red;
                    layer.BackColor = Color.Pink;
                    layer.Hatching = true;
                    layer.Transparent = true;
                    layer.LineWidth = 2;

                    mwView.MLayers.Add(layer);
                }

                #endregion

                #region レイヤー（ラベル）

                // ラベル（黒）用
                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_BLACK) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_BLACK);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_BLACK) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_BLACK;
                    layer.LayerName = "LAYER_LABEL_BLACK";
                    layer.Name = "LAYER_LABEL_BLACK";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 20;
                    layer.ForeColor = Color.Black;
                    layer.FontTransparent = true;

                    mwView.MLayers.Add(layer);
                }

                // ラベル（青）用
                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_BLUE) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_BLUE);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_BLUE) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_BLUE;
                    layer.LayerName = "LAYER_LABEL_BLUE";
                    layer.Name = "LAYER_LABEL_BLUE";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 20;
                    layer.ForeColor = Color.Blue;
                    layer.FontTransparent = true;

                    mwView.MLayers.Add(layer);
                }

                // ラベル（赤）用
                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_RED) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_RED);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_RED) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_RED;
                    layer.LayerName = "LAYER_LABEL_RED";
                    layer.Name = "LAYER_LABEL_RED";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 20;
                    layer.ForeColor = Color.Red;
                    layer.FontTransparent = true;

                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_TEMP_SEQ);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_TEMP_SEQ;
                    layer.LayerName = "LAYER_LABEL_TEMP_SEQ";
                    layer.Name = "LAYER_LABEL_TEMP_SEQ";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 24;
                    layer.FontWidth = 5;
                    layer.ForeColor = Color.White;
                    layer.BackColor = Color.Black;
                    layer.FontStyle = mwcFontStyle.FS_BOLD;
                    layer.FontTransparent = false;
                    layer.ScaleMode = 0;

                    mwView.MLayers.Add(layer);
                }

                // 2015.01.27 toyoda Add Start 順番の表示方法を変更
                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ_FORE1) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_TEMP_SEQ_FORE1);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ_FORE1) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_TEMP_SEQ_FORE1;
                    layer.LayerName = "LAYER_NO_LABEL_TEMP_SEQ_FORE1";
                    layer.Name = "LAYER_NO_LABEL_TEMP_SEQ_FORE1";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 33;
                    layer.FontWidth = 6;
                    layer.ForeColor = Color.White;
                    layer.FontStyle = mwcFontStyle.FS_BOLD;
                    layer.FontTransparent = true;
                    layer.ScaleMode = 0;

                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ_FORE2) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_TEMP_SEQ_FORE2);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ_FORE2) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_TEMP_SEQ_FORE2;
                    layer.LayerName = "LAYER_NO_LABEL_TEMP_SEQ_FORE2";
                    layer.Name = "LAYER_NO_LABEL_TEMP_SEQ_FORE2";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 33;
                    layer.FontWidth = 4.5f;
                    layer.ForeColor = Color.White;
                    layer.FontStyle = mwcFontStyle.FS_BOLD;
                    layer.FontTransparent = true;
                    layer.ScaleMode = 0;

                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ_BACK) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_TEMP_SEQ_BACK);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP_SEQ_BACK) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_TEMP_SEQ_BACK;
                    layer.LayerName = "LAYER_NO_LABEL_TEMP_SEQ_BACK";
                    layer.Name = "LAYER_NO_LABEL_TEMP_SEQ_BACK";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 66;
                    layer.FontWidth = 13;
                    layer.ForeColor = Color.Black;
                    layer.FontStyle = mwcFontStyle.FS_BOLD;
                    layer.FontTransparent = true;
                    layer.ScaleMode = 0;

                    mwView.MLayers.Add(layer);
                }
                // 2015.01.27 toyoda Add End

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_LABEL_TEMP);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_LABEL_TEMP) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_LABEL_TEMP;
                    layer.LayerName = "LAYER_LABEL_TEMP";
                    layer.Name = "LAYER_LABEL_TEMP";
                    layer.Visible = true;
                    layer.Search = true;

                    layer.FontName = "メイリオ";
                    layer.FontHeight = 14;
                    layer.ForeColor = Color.Black;
                    layer.BackColor = Color.Yellow;
                    layer.FontTransparent = false;
                    layer.ScaleMode = 0;

                    mwView.MLayers.Add(layer);
                }

                #endregion
            
                #region レイヤー（イメージ）

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_250) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_250);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_250) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_250;
                    layer.LayerName = "LAYER_IMAGE_250";
                    layer.Name = "LAYER_IMAGE_250";
                    layer.BaseScale = 250;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_500) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_500);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_500) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_500;
                    layer.LayerName = "LAYER_IMAGE_500";
                    layer.Name = "LAYER_IMAGE_500";
                    layer.BaseScale = 500;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_1000) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_1000);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_1000) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_1000;
                    layer.LayerName = "LAYER_IMAGE_1000";
                    layer.Name = "LAYER_IMAGE_1000";
                    layer.BaseScale = 1000;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_1500) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_1500);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_1500) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_1500;
                    layer.LayerName = "LAYER_IMAGE_1500";
                    layer.Name = "LAYER_IMAGE_1500";
                    layer.BaseScale = 1500;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_3000) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_3000);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_3000) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_3000;
                    layer.LayerName = "LAYER_IMAGE_3000";
                    layer.Name = "LAYER_IMAGE_3000";
                    layer.BaseScale = 3000;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_5000) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_5000);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_5000) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_5000;
                    layer.LayerName = "LAYER_IMAGE_5000";
                    layer.Name = "LAYER_IMAGE_5000";
                    layer.BaseScale = 5000;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_7500) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_7500);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_7500) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_7500;
                    layer.LayerName = "LAYER_IMAGE_7500";
                    layer.Name = "LAYER_IMAGE_7500";
                    layer.BaseScale = 7500;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_10000) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_10000);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_10000) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_10000;
                    layer.LayerName = "LAYER_IMAGE_10000";
                    layer.Name = "LAYER_IMAGE_10000";
                    layer.BaseScale = 10000;
                    layer.MaxScale = layer.BaseScale * 4;
                    layer.MinScale = layer.BaseScale / 4;
                    layer.Visible = true;
                    layer.Search = true;
                    mwView.MLayers.Add(layer);
                }

                if (remakeLayer && mwView.MLayers.GetLayer(LAYER_NO_IMAGE_TEMP) != null)
                {
                    mwView.MLayers.RemoveLayer(LAYER_NO_IMAGE_TEMP);
                }
                if (mwView.MLayers.GetLayer(LAYER_NO_IMAGE_TEMP) == null)
                {
                    // 規定レイヤーの追加
                    MLayer layer = new MLayer();
                    layer.LayerNo = LAYER_NO_IMAGE_TEMP;
                    layer.LayerName = "LAYER_IMAGE_TEMP";
                    layer.Name = "LAYER_IMAGE_TEMP";
                    layer.Visible = true;
                    layer.Search = true;
                    layer.ScaleMode = 0;
                    mwView.MLayers.Add(layer);
                }

                #endregion

                #endregion
                        
                // ｶﾚﾝﾄﾚｲﾔ番号の設定
                mwView.CurLayerNo = LAYER_NO_LINE_BLACK;

                //ｽｸﾛｰﾙｲﾝﾀｰﾊﾞﾙ(ﾃﾞﾌｫﾙﾄ200)
                mwView.ScrollPeriod = (short)SettingFile.xmlPara.ScrollPeriod;

                //地図種別の設定
                mwView.MapType = (mwcMapType)SettingFile.xmlPara.MapType;

                //ﾙｰﾗｰの状態を設定する
                mwView.MRuler.Visible = SettingFile.xmlPara.Ruler;

                //地図描画ﾓｰﾄﾞを設定
                mwView.MapDrawMode = SettingFile.xmlPara.MapDrawMode;

                //ｽｸﾛｰﾙ時ｵｰﾊﾞﾚｲを表示(0:しない/1:表示)
                mwView.set_Option(2, SettingFile.xmlPara.DrawOverlayOnScroll);
            
                #region オーバレイ情報の更新
            
                // オーバレイ情報リストにセット
                Viewer.Overlays.Clear();
                if (SettingFile.xmlPara.Overlays != null)
                {
                    Viewer.Overlays.AddRange(SettingFile.xmlPara.Overlays);
                }

                // 地図に反映
                if (Viewer.Overlays.Count != 0)
                {
                    for (int i = 0; i < Viewer.Overlays.Count; i++)
                    {
                        Viewer.AddMOverlay(mwView, Viewer.Overlays[i].Name, Viewer.Overlays[i].Path);
                    }
                }

                #endregion

                //地図種別を設定
                SetMapType();

                int nMapScale = SettingFile.xmlPara.MapScale;

                if (currentMapPointX != 0 && currentMapPointY != 0)
                {
                    // 指定された浄化槽を中心に表示する
                    mwView.DrawMap(currentMapPointX, currentMapPointY, nMapScale);
                }
                else
                {
                    //前回の地図表示を復元する
                    int X = SettingFile.xmlPara.X;
                    int Y = SettingFile.xmlPara.Y;

                    if (X != 0 & Y != 0)
                    {
                        mwView.DrawMap(X, Y, nMapScale);
                    }
                }
                
                // 2015.1.20 toyoda Add Start 住所、緯度、経度の表示
                SetAddressInfo();
                // 2015.1.20 toyoda Add End

                SetMapPointInfo();

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

        #region MapWorksForm_FormClosing(object sender, FormClosingEventArgs e)
        /// <summary>
        /// フォーム終了時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapWorksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                // 2015.01.30 toyoda Add Start GPS情報取得方法の変更
                // GPS読み込み開始
                LocationGpsInfo.StopRead();
                // 2015.01.30 toyoda Add End

                // 終了時の状態保存
                if (SaveConditions == true)
                {
                    setXmlPara();
                }

                try
                {
                    // XMLファイルに出力
                    string dirPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    SettingFile.WriteXml(Path.Combine(dirPath, SettingFile.xmlFileName));

                    // MWViewｺﾝﾄﾛｰﾙの終了処理
                    mwView.Terminate();
                }
                catch (Exception ex)
                {
                    TabMessageBox.Show2(ex.Message);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());

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

        #region backButton_Click(object sender, System.EventArgs e)
        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region selectCheckBox_CheckedChanged(object sender, System.EventArgs e)
        /// <summary>
        /// 選択モード変更チェックボックス押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (selectCheckBox.Checked)
                {
                    freeInputCheckBox.Enabled = false;
                    textInputCheckBox.Enabled = false;
                    lineInputCheckBox.Enabled = false;
                    messageCheckBox.Enabled = false;
                    gpsCheckBox.Enabled = false;

                    //ｵﾌﾞｼﾞｪｸﾄ･ﾋﾟｯｸﾓｰﾄﾞの設定
                    mwView.PickMode = mwcPickMode.PKM_NORMAL;
                    //ﾏｳｽﾓｰﾄﾞの設定
                    mwView.MouseMode = mwcMouseMode.MM_SELECT_OBJECT;

                    // 範囲選択オン
                    RangeSelection = true;
                }
                else
                {
                    if (mwView.SelectedObjects.Count > 0)
                    {
                        mwView.SelectedObjects.RemoveAll();
                    }

                    freeInputCheckBox.Enabled = true;
                    textInputCheckBox.Enabled = true;
                    lineInputCheckBox.Enabled = true;
                    messageCheckBox.Enabled = true;
                    gpsCheckBox.Enabled = true;

                    //ｵﾌﾞｼﾞｪｸﾄ･ﾋﾟｯｸﾓｰﾄﾞの設定
                    mwView.PickMode = mwcPickMode.PKM_NORMAL;
                    //ﾏｳｽﾓｰﾄﾞの設定
                    mwView.MouseMode = mwcMouseMode.MM_HAND_SCROLL;
                                
                    // 範囲選択オフ
                    RangeSelection = false;

                    mwView.Redraw(1, mwView.MapScale);
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

        #region messageCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// メモ表示切替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void messageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (MapPointDataSet.JokasoMapPointRow row in jokasoMapPoint)
                {
                    // 地図にマッピングしていないマスタはスキップ
                    if (row.IsMapPointXNull() || row.IsMapPointYNull())
                    {
                        continue;
                    }

                    if (messageCheckBox.Checked)
                    {
                        if (row.IsMapPointInfoObjectIDNull())
                        {
                            MLabel label = new MLabel();

                            // レイヤ番号の指定
                            label.LayerNo = LAYER_NO_LABEL_TEMP;
                            label.Temporary = true;
                            label.LabelString = string.Format("{0}\r\n{1}", row.JokasoSetchishaNm, row.JokasoSetchiBashoAdr);
                            label.X = row.MapPointX;
                            label.Y = row.MapPointY;
                            label.Style = 2;

                            mwView.CreateLabel(label);

                            // 作成中ｵﾌﾞｼﾞｪｸﾄを登録
                            object objectID = mwView.RegisterObject(true);
                            row.MapPointInfoObjectID = (Guid)objectID;
                        }

                        if (row.IsMapPointSeqObjectIDNull())
                        {
                            MLabel label = new MLabel();

                            // 2015.01.27 toyoda Mod Start 順番の表示方法を変更
                            //// レイヤ番号の指定
                            //label.LayerNo = LAYER_NO_LABEL_TEMP_SEQ;
                            //label.Temporary = true;
                            //label.LabelString = string.Format(" {0} ", row.KensaIraiRowIndex);
                            //label.X = row.MapPointX;
                            //label.Y = row.MapPointY;
                            //label.Style = 5;

                            //mwView.CreateLabel(label);

                            //// 作成中ｵﾌﾞｼﾞｪｸﾄを登録
                            //object objectID = mwView.RegisterObject(true);
                            //row.MapPointSeqObjectID = (Guid)objectID;

                            // レイヤ番号の指定
                            label.LayerNo = LAYER_NO_LABEL_TEMP_SEQ_BACK;
                            label.Temporary = true;
                            label.LabelString = "■\r\n\r\n";
                            label.X = row.MapPointX;
                            label.Y = row.MapPointY;
                            label.Style = 0;

                            mwView.CreateLabel(label);

                            // 作成中ｵﾌﾞｼﾞｪｸﾄを登録
                            object objectIDBack = mwView.RegisterObject(true);
                            row.MapPointSeqObjectID_backcolor = (Guid)objectIDBack;

                            // レイヤ番号の指定
                            int index = int.Parse(row.KensaIraiRowIndex);
                            label.LayerNo = index < 10 ? LAYER_NO_LABEL_TEMP_SEQ_FORE1 : LAYER_NO_LABEL_TEMP_SEQ_FORE2;
                            label.Temporary = true;
                            label.LabelString = string.Format("{0}\r\n\r\n\r\n\r\n", index);
                            label.X = row.MapPointX;
                            label.Y = row.MapPointY;
                            label.Style = 0;

                            mwView.CreateLabel(label);

                            // 作成中ｵﾌﾞｼﾞｪｸﾄを登録
                            object objectIDFore = mwView.RegisterObject(true);
                            row.MapPointSeqObjectID = (Guid)objectIDFore;
                            // 2015.01.27 toyoda Mod End
                        }
                    }
                    else
                    {
                        if (!row.IsMapPointInfoObjectIDNull())
                        {
                            mwView.SelectObject(row.MapPointInfoObjectID);
                            mwView.UndoControl.Enabled = true;
                            mwView.Remove();
                            mwView.UndoControl.Enabled = false;
                            mwView.Refresh();

                            row.SetMapPointInfoObjectIDNull();
                        }

                        if (!row.IsMapPointSeqObjectIDNull())
                        {
                            mwView.SelectObject(row.MapPointSeqObjectID);
                            mwView.UndoControl.Enabled = true;
                            mwView.Remove();
                            mwView.UndoControl.Enabled = false;
                            mwView.Refresh();

                            row.SetMapPointSeqObjectIDNull();
                        }

                        // 2015.01.27 toyoda Add Start 順番の表示方法を変更
                        if (!row.IsMapPointSeqObjectID_backcolorNull())
                        {
                            mwView.SelectObject(row.MapPointSeqObjectID_backcolor);
                            mwView.UndoControl.Enabled = true;
                            mwView.Remove();
                            mwView.UndoControl.Enabled = false;
                            mwView.Refresh();

                            row.SetMapPointSeqObjectID_backcolorNull();
                        }
                        // 2015.01.27 toyoda Add Start 
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

        #region textInputCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 文字入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textInputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (freeInputCheckBox.Checked)
                {
                    if (textInputCheckBox.Checked)
                    {
                        lineInputCheckBox.Enabled = false;
                    }
                    else
                    {
                        lineInputCheckBox.Enabled = true;
                    }
                }
                else
                {
                    if (textInputCheckBox.Checked)
                    {
                        using (ColorSelectDialog dlg = new ColorSelectDialog(textInputCheckBox, ColorSelectDialog.SelectMode.ColorAndStamp))
                        {
                            dlg.ShowDialog(this);

                            if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                if (dlg.SelectedColor() == ColorSelectDialog.ColorMode.StampB
                                    || dlg.SelectedColor() == ColorSelectDialog.ColorMode.StampS)
                                {
                                    selectCheckBox.Enabled = false;
                                    messageCheckBox.Enabled = false;
                                    lineInputCheckBox.Enabled = false;
                                    freeInputCheckBox.Enabled = false;
                                    zoomInButton.Enabled = false;
                                    zoomOutButton.Enabled = false;
                                    gpsCheckBox.Enabled = false;

                                    //ﾏｳｽﾓｰﾄﾞの設定
                                    mwView.MouseMode = mwcMouseMode.MM_NORMAL;

                                    // 表示状態に応じてレイヤーを切り替える（試験的に）
                                    int myBaseLayerNo;

                                    if (mwView.MapScale < 375)
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_250;
                                    }
                                    else if (mwView.MapScale < 750)
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_500;
                                    }
                                    else if (mwView.MapScale < 1250)
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_1000;
                                    }
                                    else if (mwView.MapScale < 2250)
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_1500;
                                    }
                                    else if (mwView.MapScale < 4000)
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_3000;
                                    }
                                    else if (mwView.MapScale < 6125)
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_5000;
                                    }
                                    else if (mwView.MapScale < 8750)
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_7500;
                                    }
                                    else
                                    {
                                        myBaseLayerNo = LAYER_NO_IMAGE_10000;
                                    }

                                    // ビットマップの登録
                                    MBitmap bitmap = new MBitmap();
                                    bitmap.LayerNo = myBaseLayerNo;
                                    bitmap.Temporary = false;
                                    bitmap.SetBitmap(dlg.SelectedColor() == ColorSelectDialog.ColorMode.StampB ? Resources.map_stamp_b : Resources.map_stamp_s);
                                    bitmap.Height = Resources.map_stamp_b.Height;
                                    bitmap.Width = Resources.map_stamp_b.Width;
                                    bitmap.Style = 0;

                                    mwView.CreateBitmap(bitmap);
                                }
                                else
                                {
                                    using (TextInputDialog dlg2 = new TextInputDialog())
                                    {
                                        dlg2.ShowDialog(this);

                                        if (dlg2.DialogResult == System.Windows.Forms.DialogResult.OK)
                                        {
                                            selectCheckBox.Enabled = false;
                                            messageCheckBox.Enabled = false;
                                            lineInputCheckBox.Enabled = false;
                                            freeInputCheckBox.Enabled = false;
                                            zoomInButton.Enabled = false;
                                            zoomOutButton.Enabled = false;
                                            gpsCheckBox.Enabled = false;

                                            //ﾏｳｽﾓｰﾄﾞの設定
                                            mwView.MouseMode = mwcMouseMode.MM_NORMAL;

                                            MLabel label = new MLabel();

                                            // レイヤ番号の指定
                                            label.LayerNo = dlg.SelectedColor() == ColorSelectDialog.ColorMode.Black ? LAYER_NO_LABEL_BLACK
                                                            : dlg.SelectedColor() == ColorSelectDialog.ColorMode.Blue ? LAYER_NO_LABEL_BLUE
                                                            : LAYER_NO_LABEL_RED;
                                            label.Temporary = false;
                                            label.LabelString = dlg2.InputText();

                                            mwView.CreateLabel(label);
                                        }
                                        else
                                        {
                                            textInputCheckBox.Checked = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // 「ｵﾌﾞｼﾞｪｸﾄ作成ﾓｰﾄﾞ」の場合
                        mwView.Cancel();
                        mwView.MouseMode = mwcMouseMode.MM_HAND_SCROLL;

                        selectCheckBox.Enabled = true;
                        messageCheckBox.Enabled = true;
                        lineInputCheckBox.Enabled = true;
                        freeInputCheckBox.Enabled = true;
                        zoomInButton.Enabled = true;
                        zoomOutButton.Enabled = true;
                        gpsCheckBox.Enabled = true;
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

        #region freeInputCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 手書き入力チェック変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void freeInputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (freeInputCheckBox.Checked)
                {
                    using (ColorSelectDialog dlg = new ColorSelectDialog(freeInputCheckBox, ColorSelectDialog.SelectMode.Color))
                    {
                        dlg.ShowDialog(this);

                        if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            selectCheckBox.Enabled = false;
                            messageCheckBox.Enabled = false;
                            zoomInButton.Enabled = false;
                            zoomOutButton.Enabled = false;
                            gpsCheckBox.Enabled = false;

                            tp = new TransparentPictureBox();

                            tp.Width = mwView.Width;
                            tp.Height = mwView.Height;
                            tp.Top = 0;
                            tp.Left = 0;
                            tp.Parent = mwView;

                            tp.MouseDown += new MouseEventHandler(TransparentPictureBox_MouseDown);
                            tp.MouseMove += new MouseEventHandler(TransparentPictureBox_MouseMove);
                            tp.MouseUp += new MouseEventHandler(TransparentPictureBox_MouseUp);

                            // PictureBoxと同サイズのBitmapオブジェクトを作成
                            tp.Image = new Bitmap(tp.Width, tp.Height);

                            maxX = 0;
                            minX = 0;
                            maxY = 0;
                            minY = 0;

                            grfx = Graphics.FromImage(tp.Image);

                            tp.Show();

                            // ペンの設定
                            MyPen = new Pen(Pens.Black.Color, 3);

                            // ペン色の切り換え
                            MyPen.Color = dlg.SelectedColor() == ColorSelectDialog.ColorMode.Black ? Pens.Black.Color
                                            : dlg.SelectedColor() == ColorSelectDialog.ColorMode.Blue ? Pens.Blue.Color
                                            : Pens.Red.Color;
                        }
                    }
                }
                else
                {
                    tp.Dispose();

                    selectCheckBox.Enabled = true;
                    messageCheckBox.Enabled = true;
                    if (textInputCheckBox.Checked)
                    {
                        textInputCheckBox.Checked = false;
                    }
                    if (lineInputCheckBox.Checked)
                    {
                        lineInputCheckBox.Checked = false;
                    }
                    zoomInButton.Enabled = true;
                    zoomOutButton.Enabled = true;
                    gpsCheckBox.Enabled = true;
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
        
        #region lineInputCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 直線入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineInputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (freeInputCheckBox.Checked)
                {
                    if (lineInputCheckBox.Checked)
                    {
                        textInputCheckBox.Enabled = false;
                    }
                    else
                    {
                        textInputCheckBox.Enabled = true;
                    }
                }
                else
                {
                    if (lineInputCheckBox.Checked)
                    {
                        using (LineSelectDialog dlg = new LineSelectDialog(lineInputCheckBox))
                        {
                            dlg.ShowDialog(this);

                            if (dlg.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                using (ColorSelectDialog dlg2 = new ColorSelectDialog(lineInputCheckBox, ColorSelectDialog.SelectMode.Color))
                                {
                                    dlg2.ShowDialog(this);

                                    if (dlg2.DialogResult == System.Windows.Forms.DialogResult.OK)
                                    {
                                        selectCheckBox.Enabled = false;
                                        messageCheckBox.Enabled = false;
                                        textInputCheckBox.Enabled = false;
                                        freeInputCheckBox.Enabled = false;
                                        zoomInButton.Enabled = false;
                                        zoomOutButton.Enabled = false;
                                        gpsCheckBox.Enabled = false;

                                        //ﾏｳｽﾓｰﾄﾞの設定
                                        mwView.MouseMode = mwcMouseMode.MM_NORMAL;

                                        // レイヤ番号の切り換え
                                        mwView.CurLayerNo = dlg2.SelectedColor() == ColorSelectDialog.ColorMode.Black ? LAYER_NO_LINE_BLACK
                                                        : dlg2.SelectedColor() == ColorSelectDialog.ColorMode.Blue ? LAYER_NO_LINE_BLUE
                                                        : LAYER_NO_LINE_RED;

                                        if (dlg.SelectedLine() == LineSelectDialog.LineMode.Straight)
                                        {
                                            // ﾎﾟﾘﾗｲﾝの作成(※ﾃﾝﾎﾟﾗﾘｵﾌﾞｼﾞｪｸﾄを使用しない)
                                            mwView.CreatePolyline(Viewer.PL_NOTARROW, false);
                                        }
                                        else if (dlg.SelectedLine() == LineSelectDialog.LineMode.Arrow)
                                        {
                                            // ﾎﾟﾘﾗｲﾝの作成(※ﾃﾝﾎﾟﾗﾘｵﾌﾞｼﾞｪｸﾄを使用しない)
                                            mwView.CreatePolyline(Convert.ToInt16(3), false);
                                        }
                                        else
                                        {
                                            // ﾎﾟﾘｺﾞﾝの作成(※ﾃﾝﾎﾟﾗﾘｵﾌﾞｼﾞｪｸﾄを使用しない)
                                            mwView.CreatePolygon(false);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // 「ｵﾌﾞｼﾞｪｸﾄ作成ﾓｰﾄﾞ」の場合
                        mwView.Cancel();
                        mwView.MouseMode = mwcMouseMode.MM_HAND_SCROLL;

                        selectCheckBox.Enabled = true;
                        messageCheckBox.Enabled = true;
                        textInputCheckBox.Enabled = true;
                        freeInputCheckBox.Enabled = true;
                        zoomInButton.Enabled = true;
                        zoomOutButton.Enabled = true;
                        gpsCheckBox.Enabled = true;
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

        #region zoomInButton_Click(object sender, System.EventArgs e)
        /// <summary>
        /// 拡大ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomInButton_Click(object sender, System.EventArgs e)
        {
            // 拡大表示
            mwView.Zoom((short)ZoomInRate);
        }
        #endregion

        #region zoomOutButton_Click(object sender, System.EventArgs e)
        /// <summary>
        /// 縮小ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomOutButton_Click(object sender, System.EventArgs e)
        {
            // 縮小表示
            mwView.Zoom((short)ZoomOutRate);
        }
        #endregion

        #region gpsCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 現在地取得及び現在地追従
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gpsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gpsCheckBox.Checked)
                {
                    freeInputCheckBox.Enabled = false;
                    selectCheckBox.Enabled = false;
                    messageCheckBox.Enabled = false;
                    textInputCheckBox.Enabled = false;
                    lineInputCheckBox.Enabled = false;

                    // 2015.1.20 toyoda Add Start 現在地追従時は閉じるボタンを押させない(終了時エラー対応)
                    backButton.Enabled = false;
                    // 2015.1.20 toyoda Add End

                    setMyPos(1000);

                    // ｶｰｿﾙﾀｲﾌﾟの設定(十字ｶｰｿﾙﾀｲﾌﾟ2)
                    mwView.CursorType = mwcCursorType.CURSOR_TYPE2;
                    // Pointedｲﾍﾞﾝﾄの起動
                    mwView.GetPoint(mwcMousePointer.MP_NORMAL, "中心表示");

                    // 追従を開始
                    gpsTimer.Start();
                }
                else
                {
                    freeInputCheckBox.Enabled = true;
                    selectCheckBox.Enabled = true;
                    messageCheckBox.Enabled = true;
                    textInputCheckBox.Enabled = true;
                    lineInputCheckBox.Enabled = true;

                    // 2015.1.20 toyoda Add Start 現在地追従時は閉じるボタンを押させない(終了時エラー対応)
                    backButton.Enabled = true;
                    // 2015.1.20 toyoda Add End

                    // ｶｰｿﾙﾀｲﾌﾟの設定(十字ｶｰｿﾙﾀｲﾌﾟ2)
                    mwView.CursorType = mwcCursorType.CURSOR_NONE;
                    mwView.MouseMode = mwcMouseMode.MM_HAND_SCROLL;

                    // 追従を停止
                    gpsTimer.Stop();
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

        #region gpsTimer_Tick(object sender, EventArgs e)
        /// <summary>
        /// 現在地追従タイマ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gpsTimer_Tick(object sender, EventArgs e)
        {
            setMyPos(mwView.MapScale);
        }
        #endregion
        
        #region mwView_MouseDown(object sender, MouseEventArgs e)
        /// <summary>
        /// 右クリックコンテキストメニュー制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_MouseDown(object sender, MouseEventArgs e)
        {
            Point pos = new Point();

            // X座標
            pos.X = mwView.Left + e.X;
            // Y座標
            pos.Y = mwView.Top + e.Y;

            // 右ﾎﾞﾀﾝの場合､ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰを表示
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                switch (mwView.MouseMode)
                {
                    case mwcMouseMode.MM_SELECT_OBJECT:
                        // ｵﾌﾞｼﾞｪｸﾄ選択ﾓｰﾄﾞの場合
                        cntdelPopup.Show(this, pos);
                        break;

                    case mwcMouseMode.MM_CREATE_OBJECT:
                        // ｵﾌﾞｼﾞｪｸﾄ作成ﾓｰﾄﾞの場合
                        cntmnuPopup.Show(this, pos);
                        break;
                }
            }
            else
            {
                // 左クリック

                // 範囲選択オンの場合のみ
                if (!RangeSelection) return;

                tp = new TransparentPictureBox();

                tp.Width = mwView.Width;
                tp.Height = mwView.Height;
                tp.Top = 0;
                tp.Left = 0;
                tp.Parent = mwView;
                
                // PictureBoxと同サイズのBitmapオブジェクトを作成
                tp.Image = new Bitmap(tp.Width, tp.Height);
                
                grfx = Graphics.FromImage(tp.Image);

                tp.Show();

                startX = e.X;
                startY = e.Y;

                // 範囲選択用の矩形オブジェクトを作成
                shapeContainer = new ShapeContainer();
                rectangleShape = new RectangleShape();
                shapeContainer.Parent = tp;
                rectangleShape.Parent = shapeContainer;
                rectangleShape.BorderColor = Color.Black;
                rectangleShape.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                rectangleShape.BorderWidth = 1;
                rectangleShape.Left = e.X;
                rectangleShape.Top = e.Y;
                rectangleShape.Width = 0;
                rectangleShape.Height = 0;
            }
        }
        #endregion

        #region mwView_MouseUp(object sender, MouseEventArgs e)
        /// <summary>
        /// マウスアップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // 左クリック

                // 2015.1.20 toyoda Modify Start 住所、緯度、経度の表示
                // 範囲選択オンの場合のみ
                //if (!RangeSelection) return;
                if (RangeSelection)
                {
                    // 2015.1.20 toyoda Modify End

                    // 既に選択されたオブジェクトが有る場合
                    if (mwView.SelectedObjects.Count > 0)
                    {
                        // 選択を解除
                        mwView.SelectedObjects.RemoveAll();

                        // 選択状態表示を更新
                        mwView.Redraw(1, mwView.MapScale);
                    }

                    // 矩形の左上座標を取得
                    int X = rectangleShape.Left;
                    int Y = mwView.Height - rectangleShape.Top;

                    // 矩形の右下座標を取得
                    int Xs = rectangleShape.Left + rectangleShape.Width;
                    int Ys = mwView.Height - rectangleShape.Top - rectangleShape.Height;

                    // マップの表示範囲を取得
                    int rectMinX = 0;
                    int rectMinY = 0;
                    int rectMaxX = 0;
                    int rectMaxY = 0;

                    mwView.GetMapRect(ref rectMinX, ref rectMinY, ref rectMaxX, ref rectMaxY);

                    // 矩形の左上にあたるマップ座標を計算
                    int mapX = ((rectMaxX - rectMinX) * X / mwView.Width) + rectMinX;
                    int mapY = ((rectMaxY - rectMinY) * Y / mwView.Height) + rectMinY;

                    // 矩形の右下にあたるマップ座標を計算
                    int mapXs = ((rectMaxX - rectMinX) * Xs / mwView.Width) + rectMinX;
                    int mapYs = ((rectMaxY - rectMinY) * Ys / mwView.Height) + rectMinY;

                    // 矩形範囲内にあるオブジェクトを取得
                    IGetObjectByXYRangeALInput getInput = new GetObjectByXYRangeALInput();

                    getInput.maxX = mapXs;
                    getInput.maxY = mapY;
                    getInput.minX = mapX;
                    getInput.minY = mapYs;

                    IGetObjectByXYRangeALOutput getOutput = new GetObjectByXYRangeApplicationLogic().Execute(getInput);

                    // 取得したオブジェクトをマップの選択リストに追加
                    if (getOutput.Object.Count > 0)
                    {
                        foreach (ObjectDataSet.ObjectRow obj in getOutput.Object)
                        {
                            using (MObject o = mwView.SelectedObjects.GetObject(obj.ObjectID))
                            {
                                if (o == null)
                                {
                                    using (MObject o2 = mwView.MOverlays.GetCurrent().MObjects.GetObject(obj.ObjectID))
                                    {
                                        mwView.SelectedObjects.Add(o2);
                                    }
                                }
                            }
                        }

                        // 選択に追加されている場合のみ再描画
                        if (mwView.SelectedObjects.Count > 0)
                        {
                            mwView.Redraw(1, mwView.MapScale);
                        }
                    }

                    // 矩形オブジェクトを破棄
                    rectangleShape.Visible = false;
                    rectangleShape = null;
                    shapeContainer = null;

                    tp.Dispose();

                // 2015.1.20 toyoda Modify Start 住所、緯度、経度の表示
                }
                else if(mwView.MouseMode == mwcMouseMode.MM_HAND_SCROLL)
                {
                    SetAddressInfo();
                }
                // 2015.1.20 toyoda Modify End
            }
        }
        #endregion

        #region mwView_MouseMove(object sender, MouseEventArgs e)
        /// <summary>
        /// マウス移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_MouseMove(object sender, MouseEventArgs e)
        {
            // 範囲選択オンの場合のみ
            if (!RangeSelection) return;

            // 矩形選択中のみ
            if (rectangleShape == null) return;

            if (e.X < startX)
            {
                rectangleShape.Left = e.X;
                rectangleShape.Width = startX - e.X;
            }
            else
            {
                rectangleShape.Width = e.X - rectangleShape.Left;
            }

            if (e.Y < startY)
            {
                rectangleShape.Top = e.Y;
                rectangleShape.Height = startY - e.Y;
            }
            else
            {
                rectangleShape.Height = e.Y - rectangleShape.Top;
            }
        }
        #endregion

        #region mwView_DoubleClick(object sender, System.EventArgs e)
        /// <summary>
        /// ダブルクリックによる確定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_DoubleClick(object sender, System.EventArgs e)
        {
            object vObjectID = null;

            if ((mwView.MouseMode == mwcMouseMode.MM_CREATE_OBJECT && mwView.EditMode != mwcEditMode.EM_COPY_SECTION) ||
                mwView.EditMode == mwcEditMode.EM_EDIT_SECTION ||
                mwView.EditMode == mwcEditMode.EM_EDIT_VERTEX ||
                mwView.EditMode == mwcEditMode.EM_MOVE ||
                mwView.EditMode == mwcEditMode.EM_EXTEND_POLYLINE ||
                mwView.EditMode == mwcEditMode.EM_ADD_VERTEX ||
                mwView.EditMode == mwcEditMode.EM_DEL_VERTEX)
            {
                // ｵﾌﾞｼﾞｪｸﾄ作成中または部分編集ﾓｰﾄﾞ
                mwView.UndoControl.Enabled = true;

                // 登録
                vObjectID = mwView.RegisterObject(true);
                mwView.UndoControl.Enabled = false;
            }

            if (freeInputCheckBox.Checked)
            {
                freeInputCheckBox.Checked = false;
            }
            else if (lineInputCheckBox.Checked)
            {
                lineInputCheckBox.Checked = false;
            }
            else if (textInputCheckBox.Checked)
            {
                textInputCheckBox.Checked = false;
            }
            else if (selectCheckBox.Checked)
            {
                selectCheckBox.Checked = false;
            }
            
            mwView.MouseMode = mwcMouseMode.MM_HAND_SCROLL;
        }
        #endregion

        #region mnuPopupRegister_Click(object sender, System.EventArgs e)
        /// <summary>
        /// 登録メニュー押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPopupRegister_Click(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (freeInputCheckBox.Checked)
                {
                    // 画像の保存
                    Bitmap imageBase = (Bitmap)tp.Image;

                    // 画像を切り抜く
                    Rectangle rect = new Rectangle(minX - 3, minY - 3, maxX - minX + 6, maxY - minY + 6);
                    Bitmap image = imageBase.Clone(rect, imageBase.PixelFormat);
                
                    // イメージの中心地を計算
                    int X = (((maxX - minX) / 2) + minX);
                    int Y = imageBase.Height - (((maxY - minY) / 2) + minY);
                
                    // マップの表示範囲を取得
                    int rectMinX = 0;
                    int rectMinY = 0;
                    int rectMaxX = 0;
                    int rectMaxY = 0;
                    mwView.GetMapRect(ref rectMinX, ref rectMinY, ref rectMaxX, ref rectMaxY);

                    // イメージの中心にあたるマップ座標を計算
                    int centerX = ((rectMaxX - rectMinX) * X / imageBase.Width) + rectMinX;
                    int centerY = ((rectMaxY - rectMinY) * Y / imageBase.Height) + rectMinY;

                    // 表示状態に応じてレイヤーを切り替える（試験的に）
                    int myBaseLayerNo;

                    if (mwView.MapScale < 375)
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_250;
                    }
                    else if (mwView.MapScale < 750)
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_500;
                    }
                    else if (mwView.MapScale < 1250)
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_1000;
                    }
                    else if (mwView.MapScale < 2250)
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_1500;
                    }
                    else if (mwView.MapScale < 4000)
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_3000;
                    }
                    else if (mwView.MapScale < 6125)
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_5000;
                    }
                    else if (mwView.MapScale < 8750)
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_7500;
                    }
                    else
                    {
                        myBaseLayerNo = LAYER_NO_IMAGE_10000;
                    }
                
                    // イメージのリサイズ倍率(BaseScale換算)
                    // ※どうしてもサイズが合わないので暫定で調整(x0.742F)
                    float resize = 1.0F / mwView.MLayers.GetLayer(myBaseLayerNo).BaseScale * mwView.MapScale * 0.742F;
                
                    // 高画質リサイズ
                    int w = (int)((float)image.Width * resize);
                    int h = (int)((float)image.Height * resize);
                    Bitmap dest = new Bitmap(w, h);
                    Graphics g = Graphics.FromImage(dest);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, 0, 0, w, h);

                    //dest.Save("C:\\Users\\toyoda\\Desktop\\IMG_" + DateTime.Now.ToString("yyyyMMddyymmss") + ".png");
                
                    // ビットマップの登録
                    MBitmap bitmap = new MBitmap();
                    bitmap.LayerNo = myBaseLayerNo;
                    bitmap.Temporary = false;
                    bitmap.SetBitmap(dest);
                    bitmap.Height = dest.Height;
                    bitmap.Width = dest.Width;
                    bitmap.Style = 0;
                    bitmap.X = centerX;
                    bitmap.Y = centerY;

                    mwView.CreateBitmap(bitmap);
                }

                // 作成中ｵﾌﾞｼﾞｪｸﾄを登録
                mwView_DoubleClick(mwView, e);
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
        
        #region mnuPopupDelete_Click(object sender, System.EventArgs e)
        /// <summary>
        /// 削除メニュー押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPopupDelete_Click(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (mwView.GetSelectedObjectID(0) != null)
                {
                    mwView.UndoControl.Enabled = true;
                    mwView.Remove();
                    mwView.UndoControl.Enabled = false;
                    mwView.Refresh();
                }

                if (selectCheckBox.Checked)
                {
                    selectCheckBox.Checked = false;
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

        #region mnuPopupCancel_Click(object sender, System.EventArgs e)
        /// <summary>
        /// キャンセルメニュー押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPopupCancel_Click(object sender, System.EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (freeInputCheckBox.Checked)
                {
                    freeInputCheckBox.Checked = false;
                }
                else
                {
                    // 「ｵﾌﾞｼﾞｪｸﾄ作成ﾓｰﾄﾞ」の場合
                    mwView.Cancel();                
                    mwView.MouseMode = mwcMouseMode.MM_HAND_SCROLL;
                
                    if (lineInputCheckBox.Checked)
                    {
                        lineInputCheckBox.Checked = false;
                    }
                    else if (textInputCheckBox.Checked)
                    {
                        textInputCheckBox.Checked = false;
                    }
                    else if (selectCheckBox.Checked)
                    {
                        selectCheckBox.Checked = false;
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

        #region TransparentPictureBox_MouseDown(object sender, MouseEventArgs e)
        /// <summary>
        /// マウスダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransparentPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // 右ﾎﾞﾀﾝの場合､ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰを表示
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point pos = new Point();

                // X座標
                pos.X = mwView.Left + e.X;
                // Y座標
                pos.Y = mwView.Top + e.Y;

                // ｵﾌﾞｼﾞｪｸﾄ作成ﾓｰﾄﾞの場合
                cntmnuPopup.Show(this, pos);
            }
            else
            {
                start = 1;
                startX = e.X;
                startY = e.Y;

                if (lineInputCheckBox.Checked)
                {
                    shapeContainer = new ShapeContainer();
                    lineShape = new LineShape();
                    shapeContainer.Parent = tp;
                    lineShape.Parent = shapeContainer;
                    lineShape.BorderColor = MyPen.Color;
                    lineShape.BorderWidth = 2;
                    lineShape.StartPoint = new Point(startX, startY);
                    lineShape.EndPoint = new Point(e.X, e.Y);
                }
                else if (textInputCheckBox.Checked)
                {
                    shapeContainer = new ShapeContainer();
                    rectangleShape = new RectangleShape();
                    shapeContainer.Parent = tp;
                    rectangleShape.Parent = shapeContainer;
                    rectangleShape.BorderColor = Color.Black;
                    rectangleShape.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    rectangleShape.BorderWidth = 1;
                    rectangleShape.Left = startX;
                    rectangleShape.Top = startY;
                    rectangleShape.Width = 0;
                    rectangleShape.Height = 0;
                }

                if (maxX == 0 || maxX < startX)
                {
                    maxX = startX;
                }

                if (minX == 0 || minX > startX)
                {
                    minX = startX;
                }

                if (maxY == 0 || maxY < startY)
                {
                    maxY = startY;
                }

                if (minY == 0 || minY > startY)
                {
                    minY = startY;
                }
            }
        }
        #endregion

        #region TransparentPictureBox_MouseUp(object sender, MouseEventArgs e)
        /// <summary>
        /// マウスアップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransparentPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (lineInputCheckBox.Checked && lineShape != null)
            {
                grfx.DrawLine(MyPen, startX, startY, e.X, e.Y);

                ((TransparentPictureBox)sender).Refresh();

                lineShape = null;

                shapeContainer = null;
            }
            else if (textInputCheckBox.Checked)
            {
                using (TextInputDialog dlg2 = new TextInputDialog())
                {
                    dlg2.ShowDialog(this);
                    
                    if (dlg2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        //Fontを作成
                        Font fnt = new Font("メイリオ", rectangleShape.Height / 2 / dlg2.InputLineCount());

                        //文字列を表示する範囲を指定する
                        RectangleF rect = new RectangleF(rectangleShape.Left, rectangleShape.Top, rectangleShape.Width, rectangleShape.Height);
                        
                        //文字を書く
                        grfx.DrawString(dlg2.InputText(), fnt, Brushes.Black, rect);

                        ((TransparentPictureBox)sender).Refresh();
                    }
                }
                
                rectangleShape.Visible = false;

                rectangleShape = null;

                shapeContainer = null;

                //textInputCheckBox.Checked = false;
            }

            start = 0;
            startX = e.X;
            startY = e.Y;

            if (maxX == 0 || maxX < startX)
            {
                maxX = startX;
            }

            if (minX == 0 || minX > startX)
            {
                minX = startX;
            }

            if (maxY == 0 || maxY < startY)
            {
                maxY = startY;
            }

            if (minY == 0 || minY > startY)
            {
                minY = startY;
            }
        }
        #endregion

        #region TransparentPictureBox_MouseMove(object sender, MouseEventArgs e)
        /// <summary>
        /// マウス移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransparentPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (start == 0) return;

            if (lineInputCheckBox.Checked)
            {
                lineShape.EndPoint = new Point(e.X, e.Y);
            }
            else if (textInputCheckBox.Checked)
            {
                rectangleShape.Width = e.X - startX;
                rectangleShape.Height = e.Y - startY;
            }
            else
            {
                grfx.DrawLine(MyPen, startX, startY, e.X, e.Y);

                startX = e.X;
                startY = e.Y;

                if (maxX == 0 || maxX < startX)
                {
                    maxX = startX;
                }

                if (minX == 0 || minX > startX)
                {
                    minX = startX;
                }

                if (maxY == 0 || maxY < startY)
                {
                    maxY = startY;
                }

                if (minY == 0 || minY > startY)
                {
                    minY = startY;
                }

                ((TransparentPictureBox)sender).Refresh();
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SetMapType()
        /// <summary>
        /// 地図種別を設定
        /// </summary>
        private void SetMapType()
        {
            int nUseableMapType;
            int nCurMapType;

            //ｶﾚﾝﾄ地図種別を取得
            nCurMapType = (int)mwView.MapType;
            
            //利用可能地図種別を取得
            nUseableMapType = mwView.GetUseableMap();

            if (nUseableMapType == 0)
            {
                //利用可能地図がない
                return;
            }

            //ｶﾚﾝﾄ地図種別が設定されていない場合は使用できる地図を検索し最初に見つかった地図をｶﾚﾝﾄ地図に設定します
            if (nCurMapType == 0)
            {
                nCurMapType = (int)mwView.MMapTypes[0].MapType;
                mwView.MapType = mwView.MMapTypes[0].MapType;
            }
        }
        #endregion

        #region setXmlPara()
        /// <summary>
        /// 表示状態を保存
        /// </summary>
        private void setXmlPara()
        {
            bool bRet = false;

            #region オーバレイ情報の更新
                        
            //ｵｰﾊﾞﾚｲ名称,ｵｰﾊﾞﾚｲﾊﾟｽ
            int nCount = 0;
            if (Viewer.Overlays != null)
            {
                nCount = Viewer.Overlays.Count;
            }
            if (nCount != 0)
            {
                SettingFile.xmlPara.Overlays = Viewer.Overlays.ToArray();
            }

            #endregion

            //地図
            //地図の中心座標を取得
            short iKNo = 0;
            int X = 0, Y = 0;
            bRet = mwView.GetCenterMapPoint(ref iKNo, ref X, ref Y);
            //系番号
            SettingFile.xmlPara.KNo = iKNo;
            //緯度経度座標
            SettingFile.xmlPara.X = X;
            //緯度経度座標
            SettingFile.xmlPara.Y = Y;
            //地図表示スケール
            SettingFile.xmlPara.MapScale = mwView.MapScale;

            //ﾙｰﾗ
            SettingFile.xmlPara.Ruler = mwView.MRuler.Visible;

            //ﾊﾟﾗﾒｰﾀ
            //ｽｸﾛｰﾙｲﾝﾀｰﾊﾞﾙ
            SettingFile.xmlPara.ScrollPeriod = mwView.ScrollPeriod;
            //ｽｸﾛｰﾙ時ｵｰﾊﾞﾚｲを表示(0:しない/1:表示)
            SettingFile.xmlPara.DrawOverlayOnScroll = (bool)mwView.get_Option(2);
            //地図種別
            SettingFile.xmlPara.MapType = (int)mwView.MapType;
            //利用可能地図種別
            SettingFile.xmlPara.UseableMap = mwView.GetUseableMap();
            //地図描画ﾓｰﾄﾞ
            SettingFile.xmlPara.MapDrawMode = mwView.MapDrawMode;
            //拡大ｽﾞｰﾑ率
            SettingFile.xmlPara.ZoomInRate = ZoomInRate;
            //縮小ｽﾞｰﾑ率
            SettingFile.xmlPara.ZoomOutRate = ZoomOutRate;
        }
        #endregion

        #region setMyPos(int mapScale)
        /// <summary>
        /// マップを現在位置に移動
        /// </summary>
        /// <param name="mapScale"></param>
        private void setMyPos(int mapScale)
        {
            // 緯度
            double latitudeW = 0;
            // 経度
            double longitudeW = 0;

            // 位置情報を取得
            // 2015.01.30 toyoda Mod Start GPS情報取得方法の変更
            //bool ret = GPSInfo.GetLocation(ref latitudeW, ref longitudeW, Settings.Default.GpsTimeout);
            bool ret = LocationGpsInfo.LatestUpdateDate.HasValue;
            if (ret)
            {
                latitudeW = LocationGpsInfo.Latitude;
                longitudeW = LocationGpsInfo.Longitude;
            }
            // 2015.01.30 toyoda Mod End

            // 現在地が取得できない場合
            // 2015.1.20 toyoda Modify Start マイナス座標はエラーとして扱う
            //if (!ret)
            if (!ret || latitudeW < 0 || longitudeW < 0)
            // 2015.1.20 toyoda Modify End
            {
                return;
            }
            
            double longitudeJ;
            double latitudeJ;

            // 世界測地系→日本測地系
            FukjBizSystem.Application.Utility.MapLocationUtility.WLocToJLoc(longitudeW, latitudeW, out longitudeJ, out latitudeJ);
            
            // X座標 Y座標に変換
            int xpos = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint(longitudeJ);
            int ypos = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint(latitudeJ);
            
            // カレント移動
            mwView.DrawMap(MWLib.GetKNo(xpos, ypos), xpos, ypos, mapScale);

            // 2015.1.20 toyoda Add Start 住所、緯度、経度の表示
            SetAddressInfo();
            // 2015.1.20 toyoda Add End
        }
        #endregion
                
        #region SetMapPointInfo(MapPointDataSet.JokasoMapPointDataTable data)
        /// <summary>
        /// 浄化槽アイコンの作成
        /// </summary>
        private void SetMapPointInfo()
        {
            foreach (MapPointDataSet.JokasoMapPointRow row in jokasoMapPoint)
            {
                // ビットマップの登録
                MBitmap bitmap = new MBitmap();
                bitmap.LayerNo = LAYER_NO_IMAGE_TEMP;
                bitmap.Temporary = true;

                switch (row.KensaKekkaKensaJoukyouKbn)
                {
                    case Constants.KensaJoukyouKbn.INITIAL:

                        bitmap.SetBitmap(Resources.map_pin_initial);
                        bitmap.Height = Resources.map_pin_initial.Height;
                        bitmap.Width = Resources.map_pin_initial.Width;

                        break;

                    case Constants.KensaJoukyouKbn.IN_WORK:
                        
                        bitmap.SetBitmap(Resources.map_pin_work);
                        bitmap.Height = Resources.map_pin_work.Height;
                        bitmap.Width = Resources.map_pin_work.Width;

                        break;

                    case Constants.KensaJoukyouKbn.STOPPED:

                        bitmap.SetBitmap(Resources.map_pin_stopped);
                        bitmap.Height = Resources.map_pin_stopped.Height;
                        bitmap.Width = Resources.map_pin_stopped.Width;

                        break;

                    case Constants.KensaJoukyouKbn.COMPLETE:

                        bitmap.SetBitmap(Resources.map_pin_complete);
                        bitmap.Height = Resources.map_pin_complete.Height;
                        bitmap.Width = Resources.map_pin_complete.Width;

                        break;
                }

                bitmap.Style = 0;

                try
                {
                    // 2015.1.20 toyoda Modify Start 使用時に日本測地系に変換
                    //string keido = row.JokasoZenrinKeidoCd.PadLeft(10, '0').Insert(3, ".");
                    //string ido = row.JokasoZenrinIdoCd.PadLeft(10, '0').Insert(3, ".");

                    //row.MapPointX = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint((double.Parse(keido)));
                    //row.MapPointY = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint((double.Parse(ido)));

                    double longitudeJ;
                    double latitudeJ;

                    // 日本測地系へ変換
                    FukjBizSystem.Application.Utility.MapLocationUtility.WLocToJLoc(double.Parse(row.JokasoZenrinKeidoCd), double.Parse(row.JokasoZenrinIdoCd), out longitudeJ, out latitudeJ);

                    row.MapPointX = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint(longitudeJ);
                    row.MapPointY = FukjBizSystem.Application.Utility.MapLocationUtility.GetMapPoint(latitudeJ);
                    // 2015.1.20 toyoda Modify End
                }
                catch
                {
                    // 緯度経度のないマスタは表示しない（できない）
                    continue;
                }

                bitmap.X = row.MapPointX;
                bitmap.Y = row.MapPointY;

                mwView.CreateBitmap(bitmap);

                // 作成中ｵﾌﾞｼﾞｪｸﾄを登録
                object objectID = mwView.RegisterObject(true);
                row.MapPointStatusObjectID = (Guid)objectID;
                row.SetMapPointInfoObjectIDNull();
                row.SetMapPointSeqObjectIDNull();
            }
        }
        #endregion
        
        #region mwView_MWClick(object sender, MWClickEventArgs e)
        /// <summary>
        /// マップクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_MWClick(object sender, MWClickEventArgs e)
        {
            // 画面遷移を許可する場合のみ（検査メニューからの起動時は遷移させない）
            if (!formMoveEnabled)
            {
                return;
            }

            int rectMinX = 0;
            int rectMinY = 0;
            int rectMaxX = 0;
            int rectMaxY = 0;

            // マップの表示範囲を取得   
            mwView.GetMapRect(ref rectMinX, ref rectMinY, ref rectMaxX, ref rectMaxY);

            // １ピクセルあたりのマップサイズ
            int unitMapSizeX = (rectMaxX - rectMinX) / mwView.Width;
            int unitMapSizeY = (rectMaxY - rectMinY) / mwView.Height;

            // ピン画像のサイズをマップサイズに換算
            int pinSizeX = Resources.map_pin_default.Width * unitMapSizeX;
            int pinSizeY = Resources.map_pin_default.Height * unitMapSizeY;

            DataRow[] rows = jokasoMapPoint.Select(string.Format("{0} <= MapPointX AND MapPointX <= {1} AND {2} <= MapPointY AND MapPointY <= {3}", e.Map.X - (pinSizeX / 3), e.Map.X + (pinSizeX / 3), e.Map.Y - (pinSizeY / 2), e.Map.Y));

            if (rows.Length > 0)
            {
                // 検査依頼のキー
                string iraiRowIndex = rows[0]["KensaIraiRowIndex"].ToString();
                string iraiHoteiKbn = rows[0]["KensaIraiHoteiKbn"].ToString();
                string iraiHokenjoCd = rows[0]["KensaIraiHokenjoCd"].ToString();
                string iraiNendo = rows[0]["KensaIraiNendo"].ToString();
                string iraiRenban = rows[0]["KensaIraiRenban"].ToString();

                using (KensaMenuForm form = new KensaMenuForm(iraiHoteiKbn, iraiHokenjoCd, iraiNendo, iraiRenban, iraiRowIndex))
                {
                    this.Visible = false;

                    form.ShowDialog(this);

                    this.Visible = true;
                }
            }
        }
        #endregion

        #region SetAddressInfo()
        /// <summary>
        /// 中心位置の地名・経度・緯度の表示
        /// </summary>
        private void SetAddressInfo()
        {
            short iKNo = 0;
            int X = 0;
            int Y = 0;

            bool bRet = mwView.GetCenterMapPoint(ref iKNo, ref X, ref Y);

            if (bRet)
            {
                int sss = Y % 1000; // 秒 小数点

                int hh = Y / 3600000; // 度

                int mm = (Y / 60000) % 60; // 分

                int ss = (Y / 1000) % 60; // 秒

                idoLabel.Text = "緯度: " + hh + "° " + mm + "′ " + ss + "″ " + sss;

                sss = X % 1000; // 秒 小数点

                hh = X / 3600000; // 度

                mm = (X / 60000) % 60; // 分

                ss = (X / 1000) % 60; // 秒

                keidoLabel.Text = "経度: " + hh + "° " + mm + "′ " + ss + "″ " + sss;
                
                string address1 = string.Empty;
                string address2 = string.Empty;
                string name = string.Empty;
                short kind = 0;

                short nRet = mwView.GetAddressName(X, Y, ref address1, ref address2, ref name, ref kind);

                if (nRet > 0)
                {
                    addressLabel.Text = string.Format("{0}", address1);
                }
                else
                {
                    addressLabel.Text = "<不明な住所>";
                }
            }
            else
            {
                addressLabel.Text = "<不明な住所>";
                keidoLabel.Text = "経度: 000° 00′ 00″ 000";
                idoLabel.Text = "緯度: 00° 00′ 00″ 000";
            }

            // 表示位置の調整
            keidoLabel.Left = addressLabel.Left + addressLabel.Width + 3;
            idoLabel.Left = keidoLabel.Left + keidoLabel.Width + 3;
        }
        #endregion

        #endregion
    }
}
