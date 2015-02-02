using System;
using System.Collections.Generic;
using System.Text;

using MapWorks50;

namespace MapWorksViewer.MapWorks
{
    [Serializable()]
    public class XmlInitial
    {
        // [PARAMS]
        /// <summary>
        /// 保存ﾌﾗｸﾞ
        /// </summary>
        public bool Save = true;
        /// <summary>
        /// 地図種別（ビット演算形式による組み合わせ）
        /// </summary>
        public int MapType = 0;
        /// <summary>
        /// ユーザマップ
        /// </summary>
        public int UseableMap = 0;
        /// <summary>
        /// 描画モード
        /// </summary>
        public mwcMapDrawMode MapDrawMode = mwcMapDrawMode.MDM_DRAW_1_PASS;
        /// <summary>
        /// 拡大倍率（%）
        /// </summary>
        public int ZoomInRate = 200;
        /// <summary>
        /// 縮小倍率（%）
        /// </summary>
        public int ZoomOutRate = 50;
        /// <summary>
        /// スクロール中にオーバレイを表示(true)/非表示(false)
        /// </summary>
        public bool DrawOverlayOnScroll = true;
        /// <summary>
        /// スクロール間隔
        /// </summary>
        public int ScrollPeriod = 50;

        // [SHOWS]
        /// <summary>
        /// ツールバー表示(true)/非表示(false)
        /// </summary>
        public bool ToolBar = true;
        /// <summary>
        /// ステータスバー表示(true)/非表示(false)
        /// </summary>
        public bool StatusBar = true;
        /// <summary>
        /// ルーラ表示(true)/非表示(false)
        /// </summary>
        public bool Ruler = true;
        /// <summary>
        /// 広域図表示(true)/非表示(false)
        /// </summary>
        public bool Area = false;

        // [OVERLAYS]
        /// <summary>
        /// オーバレイリスト
        /// </summary>
        public Viewer.Overlay[] Overlays = null;

        // [MAPS]
        /// <summary>
        /// 系
        /// </summary>
        public int KNo = 0;
        /// <summary>
        /// X座標
        /// </summary>
        public int X = 502942477;
        /// <summary>
        /// Y座標
        /// </summary>
        public int Y = 128359218;
        /// <summary>
        /// 縮尺
        /// </summary>
        public int MapScale = 2000;
        /// <summary>
        /// 運用名称
        /// </summary>
        public string Workspace = "";
    }
}
