using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapWorks50;
using MapWorksViewer.MapWorks;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/26　habu　　    新規作成
    /// </history>
    public class ZMapControlMW : System.Windows.Forms.Control
    {
        #region 定義

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

        /// <summary>
        /// 地図コントロール上の座標のデフォルト(該当しない住所の場合に表示)
        /// </summary>
        private readonly string DEFAULT_ADDRESS_1 = Properties.Settings.Default.DefaultMapAddress;

        public delegate void IconSelectedHandler(string key);
        public event IconSelectedHandler IconSelected;

        /// <summary>
        /// デバッグ等の用途で、Viewerで生成されたアイコンオブジェクトなどを確認したい場合はfalseに設定する
        /// </summary>
        private readonly bool CREATE_ICON_AS_TEMPORARY = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">アイコンキー(検査番号,浄化槽番号など)</param>
        /// <param name="address1">住所(番地まで)</param>
        /// <param name="address2">住所(建物名)</param>
        /// <param name="addressName"></param>
        /// <param name="kind"></param>
        public delegate void IconAddressMovedHandler(string key, string address1, string address2, string addressName, short kind, int mapX, int mapY);
        public event IconAddressMovedHandler IconAddressMoved;

        #region 内部クラス

        /// <summary>
        /// 検査予定アイコンデータ一式
        /// </summary>
        private class KensaYoteiIcon
        {
            /// <summary>
            /// 検査予定データキー
            /// </summary>
            public string key;

            /// <summary>
            /// 検査予定アイコン
            /// </summary>
            public MBitmap kensaYoteiIconBitMap;
            /// <summary>
            /// 検査予定アイコン(点滅用)
            /// </summary>
            public MBitmap kensaYoteiIconBitMapBlink;
            /// <summary>
            /// 検査予定日ラベル
            /// </summary>
            public MLabel kensaYoteiDateLabel;
            /// <summary>
            /// 検査予定内容フキダシ
            /// </summary>
            public MLabel kensaYoteiMemoLabel;
            //public MRect kensaYoteiSelectRect;

            public void GetIconPos(out int x, out int y)
            {
                x = kensaYoteiIconBitMap.X;
                y = kensaYoteiIconBitMap.Y;
            }

            public string GetKensaYoteiDate()
            {
                return kensaYoteiDateLabel.LabelString;
            }

            public MLabel SetKensaYoteiDate(string date)
            {
                kensaYoteiDateLabel.LabelString = date;
                kensaYoteiDateLabel.Update();

                return kensaYoteiDateLabel;
            }

            public MLabel SetKensaYoteiMemo(string memo)
            {
                kensaYoteiMemoLabel.LabelString = memo;
                kensaYoteiMemoLabel.Update();

                return kensaYoteiMemoLabel;
            }

            public MBitmap SetKensaYoteiBlink(bool blink)
            {
                // SetBitmapでの差し替えが機能しないため、点滅用画像の差し替えで対応する
                if (blink)
                {
                    //kensaYoteiIconBitMap.SetBitmap(imgKensaTodayBlink);
                    kensaYoteiIconBitMap.Visible = false;
                    kensaYoteiIconBitMapBlink.Visible = true;
                    kensaYoteiIconBitMap.FileName = "blink";
                }
                else
                {
                    //kensaYoteiIconBitMap.SetBitmap(imgKensaToday);
                    kensaYoteiIconBitMap.Visible = true;
                    kensaYoteiIconBitMapBlink.Visible = false;
                    kensaYoteiIconBitMap.FileName = "normal";
                }

                return kensaYoteiIconBitMap;
            }

            /// <summary>
            /// フキダシ表示状態取得
            /// </summary>
            /// <returns></returns>
            public bool GetKensaYoteiMemoVisible()
            {
                return kensaYoteiMemoLabel.Visible;
            }

            /// <summary>
            /// フキダシ表示状態設定
            /// </summary>
            /// <remarks>
            /// 設定後呼出側で、オーバーレイの再描画を行う必要がある
            /// </remarks>
            /// <param name="isVisible"></param>
            /// <returns></returns>
            public MLabel SetKensaYoteiMemoVisible(bool isVisible)
            {
                if (isVisible)
                {
                    kensaYoteiMemoLabel.Visible = true;
                }
                else
                {
                    kensaYoteiMemoLabel.Visible = false;
                }

                return kensaYoteiMemoLabel;
            }

            //public MRect SetKensaYoteiSelected(bool isSelected)
            //{
            //    if (isSelected)
            //    {
            //        //kensaYoteiSelectRect.LineWidth = 3;
            //        kensaYoteiSelectRect.Visible = true;
            //    }
            //    else
            //    {
            //        //kensaYoteiSelectRect.LineWidth = 0;
            //        kensaYoteiSelectRect.Visible = false;
            //    }

            //    return kensaYoteiSelectRect;
            //}
        }

        #endregion

        #region Fields

        private MWView _mwView;

        #endregion

        #region Property

        /// <summary>
        /// 地図コントロールの実体を取得
        /// </summary>
        public MWView MapControl { get { return _mwView; } }

        #region 動作パラメータプロパティ

        // TODO Scale等を呼出元から指定できるように、Setterを定義

        // 拡大ｽﾞｰﾑ率
        private int ZoomInRate = 0;
        // 縮小ｽﾞｰﾑ率
        private int ZoomOutRate = 0;

        /// <summary>
        /// 初期表示縮尺
        /// </summary>
        private const int DEFAULT_SCALE = 2000;

        /// <summary>
        /// アイコンにフキダシ表示する際の、マウスカーソル検知範囲
        /// </summary>
        private const int MOUSE_HOVER_RANGE = 500;

        /// <summary>
        /// アイコン表示レイヤ番号
        /// </summary>
        private const int ICON_LAYER_NO = 1;

        /// <summary>
        /// 画面モード
        /// </summary>
        private MAP_MODE mode = MAP_MODE.NORMAL;

        // オブジェクトを後で操作・削除する場合は、ObjectID(or ラッパーオブジェクト)を保持しておく必要がある
        // MObject系のクラスを保持するか、ObjectIDそのものを保持するかは検討
        // データキー指定参照用
        private Dictionary<string, KensaYoteiIcon> yoteiIconDataKeyMap = new Dictionary<string, KensaYoteiIcon>();
        // オブジェクトID指定参照用
        private Dictionary<object, KensaYoteiIcon> yoteiIconObjectIDMap = new Dictionary<object, KensaYoteiIcon>();

        // 同じアイコンのインスタンスは共有する
        private static System.Drawing.Image imgKensaToday = global::FukjBizSystem.Properties.Resources.yoteiIcon1;
        private static System.Drawing.Image imgKensaTodayBlink = global::FukjBizSystem.Properties.Resources.yoteiIcon1b;

        #region アイコン移動用

        /// <summary>
        /// 選択された、移動対象の検査予定アイコン
        /// </summary>
        private Guid currentMoveTraget;

        #endregion

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public ZMapControlMW()
        {
            _mwView = new MWView();
            _mwView.Dock = DockStyle.Fill;

            this.Controls.Add(_mwView);

            // イベントメソッドを設定
            _mwView.Click += mwView_Click;
            _mwView.MouseMove += mwView_MouseMove;
            _mwView.ObjectSelected += mwView_ObjectSelected;
            _mwView.ObjectUnselected += mwView_ObjectUnselected;
        }
        #endregion

        #region Initialize
        /// <summary>
        /// 
        /// </summary>
        public bool Initialize()
        {
            InitDesignProp(_mwView);

            // XML（旧INI）ﾌｧｲﾙ をｸﾞﾛｰﾊﾞﾙ変数に読み込む
            string dirPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            SettingFile.ReadXml(Path.Combine(dirPath, SettingFile.xmlFileName));

            //拡大ｽﾞｰﾑ率
            ZoomInRate = SettingFile.xmlPara.ZoomInRate;
            //縮小ｽﾞｰﾑ率
            ZoomOutRate = SettingFile.xmlPara.ZoomOutRate;

            // 運用設定名を取得(設定値が空の場合は既定の運用設定を使用する)
            string strEnv = SettingFile.xmlPara.Workspace;

            // MWViewｺﾝﾄﾛｰﾙの初期化
            bool bRet = _mwView.Initialize(strEnv, "", "");

            if (bRet == false)
            {
                // MessageBox.Show("MWView の初期化に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return bRet;
            }
            
            //ｽｸﾛｰﾙｶｰｿﾙを有効に設定
            _mwView.ScrollCursor = true;
            //ｶｰｿﾙ表示
            //mwView1.CursorType = 1;
            //ﾃﾝｷｰによるｽｸﾛｰﾙ､縮尺ｺﾝﾄﾛｰﾙを使用
            _mwView.TenKeyControl = true;
            //ｽｸﾛｰﾙの単位を指定(ｺﾝﾄﾛｰﾙの縦を100とした割合)
            _mwView.ScrollRange = 10;
            //ｽｸﾛｰﾙｲﾝﾀｰﾊﾞﾙ(ﾃﾞﾌｫﾙﾄ200)
            _mwView.ScrollPeriod = 200;
            //ｷｬｯｼｭｻｲｽﾞ(ﾃﾞﾌｫﾙﾄ32)
            _mwView.MapCache = 32;
            //地図種別の設定
            _mwView.MapType = (mwcMapType)SettingFile.xmlPara.MapType;
            //ﾙｰﾗｰの状態を設定する
            //mwView1.MRuler.Visible = SettingFile.xmlPara.Ruler;
            //mwcMapType sMapType = new mwcMapType();

            //コンパス表示設定
            _mwView.MCompass.Visible = true;
            _mwView.MCompass.Position = 3;

            // TODO 仮で選択モードにする
            _mwView.MouseMode = mwcMouseMode.MM_HAND_SCROLL_AND_SELECT;

            //地図描画ﾓｰﾄﾞを設定
            _mwView.MapDrawMode = SettingFile.xmlPara.MapDrawMode;

            //ｽｸﾛｰﾙ時ｵｰﾊﾞﾚｲを表示(0:しない/1:表示)
            _mwView.set_Option(2, SettingFile.xmlPara.DrawOverlayOnScroll);

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
                    Viewer.AddMOverlay(_mwView, Viewer.Overlays[i].Name, Viewer.Overlays[i].Path);
                }
            }

            ////' ｵｰﾊﾞﾚｲ ｺﾝﾎﾞﾎﾞｯｸｽの設定(ｵｰﾊﾞﾚｲ ｺﾝﾎﾞﾎﾞｯｸｽﾁｪﾝｼﾞｲﾍﾞﾝﾄが発生しﾚｲﾔ ｺﾝﾎﾞﾎﾞｯｸにもｾｯﾄされる)
            //ComboBox cboOverlayCombo = cboOverlay.ComboBox;
            //Viewer.SetOverlayComboBox(cboOverlayCombo, mwView1);

            ////地図倍率の設定
            //CurMapScale = 0;

            ////地図種別を設定
            //SetMapType();
            ////ﾒｲﾝ画面のｷｬﾌﾟｼｮﾝにｶﾚﾝﾄの地図種別とｽｹｰﾙを表示する
            //ShowCaption();

            ////MWView1をﾘｻｲｽﾞ
            //ResizeMWView1();

            //前回の地図表示を復元する
            int X = SettingFile.xmlPara.X;
            int Y = SettingFile.xmlPara.Y;

            // 初期表示位置設定
            if (X != 0 & Y != 0)
            {
                int nMapScale = GetInitMapScale();
                _mwView.DrawMap(X, Y, nMapScale);
            }

            return true;
        }
        #endregion

        #region InitDesignProp
        /// <summary>
        /// VisualStudioデザイナで自動設定される項目を転記
        /// </summary>
        /// <param name="mwView1"></param>
        public void InitDesignProp(MWView mwView1)
        {
            this._mwView.BorderStyle = ((short)(0));
            this._mwView.ControlID = 1;
            this._mwView.CurLayerNo = 0;
            this._mwView.CursorType = MapWorks50.mwcCursorType.CURSOR_NONE;
            this._mwView.EditMode = MapWorks50.mwcEditMode.EM_NONE;

            this._mwView.MapCache = 32;
            this._mwView.MapDrawMode = MapWorks50.mwcMapDrawMode.MDM_DRAW_1_PASS;
            this._mwView.MapScale = 0;
            this._mwView.MapScaleMode = MapWorks50.mwcMapScaleMode.MSM_ZMD;
            this._mwView.MapSelColor = System.Drawing.Color.Red;
            this._mwView.MapType = MapWorks50.mwcMapType.MT_NONE;
            this._mwView.MapTypeEx = ((ulong)(0ul));
            this._mwView.MouseMode = MapWorks50.mwcMouseMode.MM_NORMAL;
            this._mwView.MWEnvPath = null;

            this._mwView.PickDistance = 5;
            this._mwView.PickMode = MapWorks50.mwcPickMode.PKM_NORMAL;
            this._mwView.Rotation = 0F;
            this._mwView.ScaleMode = MapWorks50.mwcScaleMode.SM_BL;
            this._mwView.ScreenRegion = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._mwView.ScrollCursor = false;
            this._mwView.ScrollPeriod = ((short)(10));
            this._mwView.ScrollRange = ((short)(50));

            this._mwView.TenKeyControl = false;

            this._mwView.UseGaijiFont = true;
            this._mwView.ZoomMode = MapWorks50.mwcZoomMode.ZM_NONE;
        }
        #endregion

        #region オーバーレイ・レイヤー管理

        #region ReserveLayer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="layerNo"></param>
        /// <param name="baseScale"></param>
        public void ReserveLayer(string name, int layerNo, int baseScale)
        {
            // １番目のオーバーレイを取得
            MOverlay objMOverlay = _mwView.MOverlays[0];

            // 既存レイヤーを一旦削除する(基準縮尺などを更新する場合があるため)
            if (objMOverlay.MLayers.GetLayer(ICON_LAYER_NO) != null)
            {
                objMOverlay.MLayers.RemoveLayer(ICON_LAYER_NO);
            }

            // アイコン用レイヤーが存在しない場合は生成
            if (objMOverlay.MLayers.GetLayer(ICON_LAYER_NO) == null)
            {
                objMOverlay.MLayers.Add(CreateNewLayer(name, layerNo, baseScale));
            }

            // MapWorksオブジェクトコレクションを取得
            MObjects objects = objMOverlay.MObjects;

            //if (!CREATE_ICON_AS_TEMPORARY)
            {
                //オブジェクトを一旦全て削除
                objects.RemoveOnLayer(ICON_LAYER_NO);
            }
        }
        #endregion

        #region CreateNewLayer
        /// <summary>
        /// アイコン表示用レイヤーを生成する
        /// </summary>
        /// <returns></returns>
        private MLayer CreateNewLayer(string name, int layerNo, int baseScale)
        {
            MLayer newLayer = new MLayer();
            newLayer.LayerName = name;
            newLayer.Name = name;
            newLayer.LayerNo = ICON_LAYER_NO;

            newLayer.BaseScale = baseScale;
            // 拡大縮小(縮尺)に関わらず、常に表示する
            newLayer.MaxScale = 4000000;
            newLayer.MinScale = 0;

            newLayer.Visible = true;
            newLayer.Search = true;

            return newLayer;
        }
        #endregion

        #endregion

        #region 表示座標制御

        #region ZoomIn
        /// <summary>
        /// 
        /// </summary>
        public void ZoomIn()
        {
            // 拡大表示
            _mwView.Zoom((short)ZoomInRate);
        }
        #endregion

        #region ZoomOut
        /// <summary>
        /// 
        /// </summary>
        public void ZoomOut()
        {
            // 縮小表示
            _mwView.Zoom((short)ZoomOutRate);
        }
        #endregion

        #endregion

        #region MObject(MBitmap, MLabel)生成用

        #region AddIcon
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="name"></param>
        /// <param name="yoteiDate"></param>
        /// <param name="yoteiMemo"></param>
        /// <param name="type"></param>
        public void AddIcon(string key, string address1, string address2, string name, string yoteiDate, string yoteiMemo, YOTEI_ICON_TYPE type)
        {
            int addrX = 0;
            int addrY = 0;
            short kno = 0;

            // 住所文字列から、地図座標を取得
            GetAddressPos(address1, address2, name, ref kno, ref addrX, ref addrY);

            AddIcon(key, addrX, addrY, yoteiDate, yoteiMemo, type);
        }
        #endregion

        #region AddIcon
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="x">地図コントロール内部X座標</param>
        /// <param name="y">地図コントロール内部Y座標</param>
        /// <param name="yoteiDate"></param>
        /// <param name="yoteiMemo"></param>
        /// <param name="type"></param>
        public void AddIcon(string key, int x, int y, string yoteiDate, string yoteiMemo, YOTEI_ICON_TYPE type)
        {
            // １番目のオーバーレイを指定
            MOverlay objMOverlay = _mwView.MOverlays[0];

            // MapWorksオブジェクトコレクションを取得
            MObjects objects = objMOverlay.MObjects;

            CreateKensaYoteiIcon(objects, key, x, y, yoteiDate, yoteiMemo, type);
        }
        #endregion

        #region CreateKensaYoteiIcon
        /// <summary>
        /// 指定検査予定のアイコンを生成する
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="yoteiDate"></param>
        /// <param name="yoteiMemo"></param>
        /// <param name="type"></param>
        public void CreateKensaYoteiIcon(MObjects objects, string key, int x, int y, string yoteiDate, string yoteiMemo, YOTEI_ICON_TYPE type)
        {
            KensaYoteiIcon icon = new KensaYoteiIcon();

            icon.key = key;

            // TODO 表示スケールに応じてサイズを調整する場合は、ここで細工をする(+,KenyaYotei内部クラスに、スケール更新用メソッドを設ける)
            icon.kensaYoteiIconBitMap = CreateYoteiIconBitmap(x, y, 40, 40, type);
            icon.kensaYoteiIconBitMapBlink = CreateYoteiIconBitmap(x, y, 40, 40, type + 1);
            icon.kensaYoteiDateLabel = CreateYoteiDateLabel(yoteiDate, x, y + 500);
            icon.kensaYoteiMemoLabel = CreateToolTipLabel(yoteiMemo, x, y + 750);
            //icon.kensaYoteiSelectRect = CreateSelectRect(x, y);

            // アイコンのビットマップオブジェクトをマップに設定
            object id = objects.Add(icon.kensaYoteiIconBitMap);
            objects.Add(icon.kensaYoteiIconBitMapBlink);
            // 予定日ラベルのオブジェクトをマップに設定
            objects.Add(icon.kensaYoteiDateLabel);
            // メモラベルのオブジェクトをマップに設定
            objects.Add(icon.kensaYoteiMemoLabel);
            // 選択矩形を設定
            //objects.Add(icon.kensaYoteiSelectRect);

            yoteiIconDataKeyMap.Add(key, icon);
            yoteiIconObjectIDMap.Add(id, icon);
        }
        #endregion

        #region Iconの各パーツ生成用

        #region CreateYoteiIconBitmap
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private MBitmap CreateYoteiIconBitmap(int x, int y, int width, int height, YOTEI_ICON_TYPE type)
        {
            //ビットマップを宣言
            MBitmap m_bitmap = new MBitmap();

            if (type == YOTEI_ICON_TYPE.YOTEI_TODAY)
            {
                //イメージをセット
                m_bitmap.SetBitmap(imgKensaToday);
            }
            else if (type == YOTEI_ICON_TYPE.YOTEI_TODAY_BLINK)
            {
                //イメージをセット
                m_bitmap.SetBitmap(imgKensaTodayBlink);
                m_bitmap.Visible = false;
            }
            // TODO その他のアイコンも用意・表示する

            m_bitmap.LayerNo = ICON_LAYER_NO;
            //m_bitmap.Style = 2;  //白抜き部分をBackColor,黒色部分をForeColorで表示する
            m_bitmap.Style = 0;  //0だと色変わらない(Bitmapをそのまま表示)
            if (type == YOTEI_ICON_TYPE.YOTEI_TODAY)
            {
                m_bitmap.ForeColor = Color.Red;
                m_bitmap.BackColor = Color.Aqua;
            }

            m_bitmap.Temporary = CREATE_ICON_AS_TEMPORARY;

            m_bitmap.X = x;
            m_bitmap.Y = y;
            m_bitmap.Height = height;
            m_bitmap.Width = width;

            m_bitmap.MinX = m_bitmap.X - 1000;
            m_bitmap.MaxX = m_bitmap.X + 1000;
            m_bitmap.MinY = m_bitmap.Y - 1000;
            m_bitmap.MaxY = m_bitmap.Y + 1000;

            return m_bitmap;
        }
        #endregion

        #region CreateYoteiDateLabel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private MLabel CreateYoteiDateLabel(string labelText, int x, int y)
        {
            MLabel ml = new MLabel();

            // TODO 日付表示向けに、スタイルを調整する
            // TODO 曜日を指定する必要がある(曜日によって、ラベルの色が変わる)

            ml.LayerNo = ICON_LAYER_NO;
            ml.BackColor = Color.Yellow;
            ml.ForeColor = Color.Black;
            ml.FontHeight = 11;
            // TODO 開発版では10だと正常に表示されない（原因は後日調査）
            ml.FontWidth = 1;
            //ml.FontWidth = 11;
            ml.LabelString = labelText;
            ml.X = x;
            ml.Y = y;
            ml.FontStyle = mwcFontStyle.FS_BOLD;
            ml.Style = 0;
            ml.UseLayerAttrib = false;//レイヤ設定使うか

            ml.Temporary = CREATE_ICON_AS_TEMPORARY;

            return ml;
        }
        #endregion

        #region CreateToolTipLabel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private MLabel CreateToolTipLabel(string labelText, int x, int y)
        {
            MLabel ml = new MLabel();

            ml.LayerNo = ICON_LAYER_NO;
            ml.BackColor = Color.YellowGreen;
            ml.ForeColor = Color.Black;
            ml.FontHeight = 10;
            // TODO 開発版では10だと正常に表示されない（原因は後日調査）
            ml.FontWidth = 1;
            //ml.FontWidth = 10;
            ml.LabelString = labelText;
            ml.X = x;
            ml.Y = y;
            ml.FontStyle = mwcFontStyle.FS_BOLD;
            ml.Style = 1001;  //吹き出し風
            //ml.Style = 4;  //吹き出し風
            ml.UseLayerAttrib = false;//レイヤ設定使うか
            // 初期表示では表示しない
            ml.Visible = false;

            ml.Temporary = CREATE_ICON_AS_TEMPORARY;

            return ml;
        }
        #endregion

        #region CreateToolTipLabel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="parentBitMap"></param>
        /// <returns></returns>
        private MLabel CreateToolTipLabel(string labelText, MBitmap parentBitMap)
        {
            return CreateToolTipLabel(labelText, parentBitMap.X, parentBitMap.Y + 250);
        }
        #endregion

        #region CreateSelectRect
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private MRect CreateSelectRect(int x, int y)
        {
            MRect mr = new MRect();

            mr.LayerNo = ICON_LAYER_NO;
            mr.BackColor = Color.Blue;
            mr.LineWidth = 3;
            mr.X = x;
            mr.Y = y;
            mr.MinX = x - 500;
            mr.MaxX = x + 500;
            mr.MinY = y - 500;
            mr.MaxY = y + 500;
            mr.Visible = false;

            mr.Temporary = CREATE_ICON_AS_TEMPORARY;

            return mr;
        }
        #endregion

        #endregion

        #region Icon状態変更

        #region SetMemoLabelVisible
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isSelected"></param>
        private void SetMemoLabelVisible(string key, bool isSelected)
        {
            if (!yoteiIconDataKeyMap.ContainsKey(key))
            {
                return;
            }

            foreach (string mapKey in yoteiIconDataKeyMap.Keys)
            {
                MLabel ml = null;

                if (mapKey == key)
                {
                    if (yoteiIconDataKeyMap[mapKey].GetKensaYoteiMemoVisible() != isSelected)
                    {
                        ml = yoteiIconDataKeyMap[mapKey].SetKensaYoteiMemoVisible(isSelected);
                    }
                }

                // 実際に表示状態が変更されたオブジェクトをのみ、表示更新する
                if (ml != null)
                {
                    ml.Update();
                    _mwView.MOverlays[0].MObjects.Update(ml);

                    break;
                }
            }

            // オーバーレイ表示を更新（地図表示は不要なら更新しない）
            _mwView.Redraw(0);
        }
        #endregion

        #endregion

        #endregion

        #region 移動・座標関連

        #region MoveTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="name"></param>
        /// <param name="scale"></param>
        public void MoveTo(string address1, string address2, string name, int scale)
        {
            int addrX = 0;
            int addrY = 0;
            short kno = 0;

            // 住所文字列から、地図座標を取得
            GetAddressPos(address1, address2, name, ref kno, ref addrX, ref addrY);

            _mwView.DrawMap(addrX, addrY, scale);
        }
        #endregion

        #region MoveTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="scale"></param>
        public void MoveTo(int x, int y, int scale)
        {
            _mwView.DrawMap(x, y, scale);
        }
        #endregion

        #region MoveTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="name"></param>
        public void MoveTo(string address1, string address2, string name)
        {
            MoveTo(address1, address2, name, 4000);
        }
        #endregion

        #region MoveTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveTo(int x, int y)
        {
            MoveTo(x, y, 4000);
        }
        #endregion

        #region FindIconByBitmapObjectID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        private KensaYoteiIcon FindIconByBitmapObjectID(object objectID)
        {
            foreach (KensaYoteiIcon icon in yoteiIconDataKeyMap.Values)
            {
                if (icon.kensaYoteiIconBitMap.ObjectID == currentMoveTraget)
                {
                    return icon;
                }
            }

            return null;
        }
        #endregion

        #region IconHitTest
        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="mapPt"></param>
        /// <returns></returns>
        private bool IconHitTest(KensaYoteiIcon icon, Point mapPt)
        {
            // マウスカーソル範囲内の検査予定アイコンなら、フキダシを表示
            if (mapPt.X >= icon.kensaYoteiIconBitMap.X - MOUSE_HOVER_RANGE
             && mapPt.X <= icon.kensaYoteiIconBitMap.X + MOUSE_HOVER_RANGE
             && mapPt.Y >= icon.kensaYoteiIconBitMap.Y - MOUSE_HOVER_RANGE
             && mapPt.Y <= icon.kensaYoteiIconBitMap.Y + MOUSE_HOVER_RANGE
               )
            // IsInnerPointだと範囲内と判定されない？(ひとまず、座標毎に個別に判定)
            //if (icon.kensaYoteiIconBitMap.IsInnerPoint(mapPt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region MoveIconToMapPt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="mapInnerPt"></param>
        private void MoveIconToMapPt(KensaYoteiIcon icon, Point mapInnerPt)
        {
            // アイコンを移動
            icon.kensaYoteiIconBitMap.X = mapInnerPt.X;
            icon.kensaYoteiIconBitMap.Y = mapInnerPt.Y;

            // 予定日を移動
            icon.kensaYoteiDateLabel.X = mapInnerPt.X;
            icon.kensaYoteiDateLabel.Y = mapInnerPt.Y + 500;

            // フキダシを移動
            icon.kensaYoteiMemoLabel.X = mapInnerPt.X;
            icon.kensaYoteiMemoLabel.Y = mapInnerPt.Y + 750;

            icon.kensaYoteiIconBitMap.Update();
            icon.kensaYoteiDateLabel.Update();
            icon.kensaYoteiMemoLabel.Update();

            _mwView.MOverlays[0].MObjects.Update(icon.kensaYoteiIconBitMap);
            _mwView.MOverlays[0].MObjects.Update(icon.kensaYoteiDateLabel);
            _mwView.MOverlays[0].MObjects.Update(icon.kensaYoteiMemoLabel);
        }
        #endregion

        #region GetMapPointFromScreenPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenPt"></param>
        /// <returns></returns>
        private Point GetMapPointFromScreenPoint(Point screenPt)
        {
            // OSスクリーン座標をMapWorksコントロール内のクライアント座標に変換
            Point clientPt = _mwView.PointToClient(screenPt);

            // MapWorksクライアント座標をMapWorks地図座標に変換
            Point mapPt = _mwView.ScreenToMap(clientPt);

            return mapPt;
        }
        #endregion

        #region GetMapPointFromClientPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientPt"></param>
        /// <returns></returns>
        private Point GetMapPointFromClientPoint(Point clientPt)
        {
            // MapWorksクライアント座標をMapWorks地図座標に変換
            Point mapPt = _mwView.ScreenToMap(clientPt);

            return mapPt;
        }
        #endregion

        #endregion

        #region 操作モード切替

        /// <summary>
        /// 
        /// </summary>
        public void EndUpdate()
        {
            // 表示オブジェクト更新を行い、再描画する
            _mwView.Refresh();
        }

        public void ToNormalMode()
        {
            // 通常モードに遷移
            mode = MAP_MODE.NORMAL;
        }

        public void ToMoveMode()
        {
            // 移動モードに遷移
            mode = MAP_MODE.MOVE;
        }

        #endregion

        #region 動作パラメータ取得

        private int GetInitMapScale()
        {
            int nMapScale = SettingFile.xmlPara.MapScale;

            if (nMapScale == 0)
            {
                nMapScale = DEFAULT_SCALE;
            }

            return nMapScale;
        }

        #endregion

        #region Events

        #region mwView_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_Click(object sender, EventArgs e)
        {
            // 選択されたｵﾌﾞｼﾞｪｸﾄ
            object vObjectID = _mwView.GetSelectedObjectID(0);

            #region アイコン選択処理
            if (vObjectID != null)
            {
                foreach (string key in yoteiIconDataKeyMap.Keys)
                {
                    // TODO この比較方法でよいか？(ネットワーク版とスタンドアローン版で、IDの型の実体が異なるので動作確認が必要)
                    // TODO スタンドアローン版では確認済み
                    if (yoteiIconDataKeyMap[key].kensaYoteiIconBitMap.ObjectID.Equals(vObjectID))
                    {
                        // アイコン選択時イベント(メソッド)を起動
                        if (IconSelected != null)
                        {
                            IconSelected(key);
                        }
                    }
                }
            }
            else
            {
                // 選択解除
                //foreach (string key in yoteiIconMap.Keys)
                //{
                //  SetKensaYoteiSelected(key, false);
                //}
            }
            #endregion

            #region アイコン移動処理(移動モードのみ)
            if (mode == MAP_MODE.MOVE && currentMoveTraget != null)
            {
                KensaYoteiIcon icon = FindIconByBitmapObjectID(currentMoveTraget);

                if (icon != null)
                {
                    // OSスクリーン座標からMapWorks地図座標を取得
                    Point mapPt = GetMapPointFromScreenPoint(Cursor.Position);

                    // アイコンを指定地図座標に移動
                    MoveIconToMapPt(icon, mapPt);

                    // 移動後に再描画を行う
                    _mwView.Redraw(0);

                    string addr1 = string.Empty;
                    string addr2 = string.Empty;
                    string addrName = string.Empty;
                    short kind = 0;

                    // 地図座標 -> 住所文字列
                    _mwView.GetAddressName(mapPt.X, mapPt.Y, ref addr1, ref addr2, ref addrName, ref kind);

                    // 親画面にアイコンの移動を通知(アイコンの移動をデータメモリ上データに反映)
                    this.IconAddressMoved(icon.key, addr1, addr2, addrName, kind, mapPt.X, mapPt.Y);
                }
            }
            #endregion
        }
        #endregion

        #region mwView_ObjectSelected
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_ObjectSelected(object sender, ObjectSelectedEventArgs e)
        {
            // TODO Clickイベントとの使い分けは検討
            // アイコン移動操作用に選択オブジェクトを保持
            currentMoveTraget = (Guid)e.ObjectID;

            // TODO 再度実装する
            // 選択アイコン点滅タイマーを起動
            // iconBlinkTimer.Enabled = true;
        }
        #endregion

        #region mwView_ObjectUnselected
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_ObjectUnselected(object sender, ObjectUnselectedEventArgs e)
        {
            // TODO アイコン以外が選択されている場合を考慮する
            // 1つも選択されていなければ、選択アイコン点滅タイマーを無効化
            if (_mwView.SelectedObjects == null || _mwView.SelectedObjects.Count == 0)
            {
                // TODO 再度実装する
                //iconBlinkTimer.Enabled = false;
            }
        }
        #endregion

        #region mwView_MouseMove
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mwView_MouseMove(object sender, MouseEventArgs e)
        {
            // MouseHoverイベントは、該当ウィンドウにMouseEnterした初回しか発生しないため、
            // 同じMapWorkウィンドウ内で複数回作動しない（ので、MouseMoveイベントを使用）

            // 地図コントロールクライアント座標からMapWorks地図座標を取得
            Point mapPt = GetMapPointFromClientPoint(e.Location);

            // アイコンが無ければ何もしない
            foreach (KensaYoteiIcon icon in yoteiIconDataKeyMap.Values)
            {
                if (IconHitTest(icon, mapPt))
                {
                    SetMemoLabelVisible(icon.key, true);
                }
                else
                {
                    // 選択中で無いこと
                    if (_mwView.SelectedObjects == null
                        || _mwView.SelectedObjects.Count == 0
                        || _mwView.SelectedObjects[0].ObjectID != icon.kensaYoteiIconBitMap.ObjectID)
                    {
                        // 選択中でない検査予定のフキダシを非表示にする
                        SetMemoLabelVisible(icon.key, false);
                    }
                }
            }
        }
        #endregion

        #region iconBlinkTimer_Tick

        // TODO 点滅用の変数は整理する
        private bool blinkFlg = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconBlinkTimer_Tick(object sender, EventArgs e)
        {
            // TODO ビットマップオブジェクトの画像を切り替えても、表示に反映されない(反映されることもある)＞切替方法を見直す
            //return;

            if (_mwView.SelectedObjects != null && _mwView.SelectedObjects.Count > 0)
            {
                foreach (KensaYoteiIcon icon in yoteiIconDataKeyMap.Values)
                {
                    if (_mwView.SelectedObjects == null || _mwView.SelectedObjects.Count == 0)
                    {
                        break;
                    }

                    if (_mwView.SelectedObjects[0].ObjectID == icon.kensaYoteiIconBitMap.ObjectID)
                    {
                        MBitmap mb = icon.SetKensaYoteiBlink(blinkFlg);

                        icon.kensaYoteiIconBitMap.Update();
                        _mwView.MOverlays[0].MObjects.Update(icon.kensaYoteiIconBitMap);
                        icon.kensaYoteiIconBitMapBlink.Update();
                        _mwView.MOverlays[0].MObjects.Update(icon.kensaYoteiIconBitMapBlink);

                        _mwView.MOverlays.Update(_mwView.MOverlays[0]);

                        // 選択が解除されるので、再選択する
                        if (blinkFlg)
                        {
                            _mwView.SelectObject(icon.kensaYoteiIconBitMap.ObjectID);
                        }
                        else
                        {
                            _mwView.SelectObject(icon.kensaYoteiIconBitMapBlink.ObjectID);
                        }

                        _mwView.Redraw(0);
                    }
                }

                blinkFlg = !blinkFlg;
            }
        }
        #endregion

        #endregion

        // 検査予定アイコンまで、地図の表示を移動する
        #region MoveToIcon
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void MoveToIcon(string key)
        {
            if (yoteiIconDataKeyMap.ContainsKey(key))
            {
                int x = 0;
                int y = 0;
                yoteiIconDataKeyMap[key].GetIconPos(out x, out y);

                int nMapScale = GetInitMapScale();

                // TODO 縮尺の自動変更は、要検討
                // TODO 縮尺に応じて、アイコンサイズを変えるか？（全アイコンについて）
                _mwView.DrawMap(x, y, (int)(nMapScale * 1.5));

                // 表示位置移動の場合、表示更新は不要
            }
        }
        #endregion

        // 指定検査予定のアイコンの表示を変える（選択時強調表示）
        #region SetIconSelected
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isSelected"></param>
        public void SetIconSelected(string key, bool isSelected)
        {
            if (yoteiIconDataKeyMap.ContainsKey(key))
            {
                foreach (string mapKey in yoteiIconDataKeyMap.Keys)
                {
                    //MRect mr;
                    MLabel ml = null;
                    if (mapKey == key)
                    {
                        _mwView.SelectObject(yoteiIconDataKeyMap[mapKey].kensaYoteiIconBitMap.ObjectID);
                        //mr = yoteiIconMap[mapKey].SetKensaYoteiSelected(isSelected);
                        if (yoteiIconDataKeyMap[mapKey].GetKensaYoteiMemoVisible() != isSelected)
                        {
                            ml = yoteiIconDataKeyMap[mapKey].SetKensaYoteiMemoVisible(isSelected);
                        }
                    }
                    else
                    {
                        _mwView.UnselectObject(yoteiIconDataKeyMap[mapKey].kensaYoteiIconBitMap.ObjectID);

                        //mr = yoteiIconMap[mapKey].SetKensaYoteiSelected(!isSelected);
                        if (yoteiIconDataKeyMap[mapKey].GetKensaYoteiMemoVisible() != !isSelected)
                        {
                            ml = yoteiIconDataKeyMap[mapKey].SetKensaYoteiMemoVisible(!isSelected);
                        }
                    }

                    //mr.Update();
                    //mwView1.MOverlays[0].MObjects.Update(mr);

                    // 実際に表示状態が変更されたオブジェクトをのみ、表示更新する
                    if (ml != null)
                    {
                        ml.Update();
                        _mwView.MOverlays[0].MObjects.Update(ml);
                    }
                }

                // オーバーレイ表示を更新（地図表示は不要なら更新しない）
                _mwView.Redraw(0);

            }
        }
        #endregion

        // 指定検査予定のアイコンの予定日の表示を更新する
        #region SetKensaYoteiDate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="yoteiDate"></param>
        public void SetKensaYoteiDate(string key, string yoteiDate)
        {
            if (yoteiIconDataKeyMap.ContainsKey(key))
            {
                MLabel ml = yoteiIconDataKeyMap[key].SetKensaYoteiDate(yoteiDate);
                ml.Update();
                _mwView.MOverlays[0].MObjects.Update(ml);

                // オーバーレイを更新（地図は不要なら更新しない）
                _mwView.Redraw(0);
            }
        }
        #endregion

        #region SetKensaYoteiMemo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="memoLabel"></param>
        public void SetKensaYoteiMemo(string key, string memoLabel)
        {
            if (yoteiIconDataKeyMap.ContainsKey(key))
            {
                MLabel ml = yoteiIconDataKeyMap[key].SetKensaYoteiMemo(memoLabel);
                ml.Update();
                _mwView.MOverlays[0].MObjects.Update(ml);

                // オーバーレイを更新（地図は不要なら更新しない）
                _mwView.Redraw(0);
            }
        }
        #endregion

        #region GetAddressPos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="name"></param>
        /// <param name="kbnNo"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public bool GetAddressPos(string address1, string address2, string name, ref short kbnNo, ref int X, ref int Y)
        {
            int addrX = 0;
            int addrY = 0;
            short kno = 0;

            // 住所文字列から、地図座標を取得
            short gt = _mwView.GetAddressCoord(0, address1, address2, name, ref kno, ref addrX, ref addrY);

            if (gt > 0)
            {
                X = addrX;
                Y = addrY;
                kbnNo = kno;

                // 住所取得成功
                return true;
            }
            else
            {
                // 存在しない住所の場合は、デフォルトの座標を表示
                gt = _mwView.GetAddressCoord(0, DEFAULT_ADDRESS_1, string.Empty, string.Empty, ref kno, ref addrX, ref addrY);

                X = addrX;
                Y = addrY;
                kbnNo = kno;

                return false;
            }
        }
        #endregion
    }
}
