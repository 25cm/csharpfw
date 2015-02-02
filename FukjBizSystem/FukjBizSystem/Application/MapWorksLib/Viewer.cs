using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.IO;

using MapWorks50;

namespace MapWorksViewer.MapWorks
{
    public class Viewer
    {
        //******************************************************************************
        //                           Viewer
        //******************************************************************************

        //******************************************************************************
        //                           MWView定数
        //******************************************************************************
        //UseableMap 地図種別(名称)
        public const string M_TOWN = "Ｚmａｐ－ＴＯＷＮⅡ（住宅地図）";
        public const string M_AREA = "Ｚmａｐ－ＡＲＥＡ２５（道路地図）";
        public const string M_KUWARI = "区割り図（住宅地図）";
        public const string M_KEN = "県単位図（道路地図）";
        public const string M_R25K = "数値地図２５０００（地図画像）";
        public const string M_RTOWN = "ラスター地図（住宅地図）";
        public const string M_R200K = "数値地図２０００００（地図画像）";
        public const string M_RKUBUN = "ラスター地図（区分図）";
        public const string M_AREA200 = "Ｚｍａｐ－ＡＲＥＡ２００（地勢図）";
        public const string M_ZENKOKU = "全国図";
        public const string M_SINGLE = "単独図";
        public const string M_MP2500 = "ＭＡＰＰＬＥ２５００";
        public const string M_MP10K = "ＭＡＰＰＬＥ１００００";
        public const string M_MP25K = "ＭＡＰＰＬＥ２５０００";
        public const string M_MP50K = "ＭＡＰＰＬＥ５００００";
        public const string M_MP200K = "ＭＡＰＰＬＥ２０００００";
        public const string M_ME = "ＭＥ　ＭＡＰ";
        public const string M_AREA2 = "Ｚｍａｐ－ＡＲＥＡⅡ";
        public const string M_DM2500 = "数値地図２５００（空間データ基盤）";
        public const string M_DM25K = "数値地図２５０００（空間データ基盤）";
        public const string M_DM25K_ADM = "数値地図２５０００（行政界・海岸線）";
        public const string M_R50K = "数値地図５００００（地図画像）";
        public const string M_BUHIN = "地図別記（住宅地図）";
        public const string M_DRM = "デジタル道路地図（住友電工製）";

        // CreatePolyline 折れ線ｽﾀｲﾙ
        //矢印なし
        public const int PL_NOTARROW = 0;
        //矢印ﾀｲﾌﾟⅠ(終点矢印)
        public const int PL_SHARP = 1;
        //矢印ﾀｲﾌﾟⅠ(終点矢印)
        public const int PL_SHARPMINI = 2;
        //矢印ﾀｲﾌﾟⅠ(終点矢印)
        public const int PL_SHARPMEDIUMS = 3;
        //矢印ﾀｲﾌﾟⅠ(終点矢印)
        public const int PL_SHARPMEDIUML = 4;
        //矢印ﾀｲﾌﾟⅠ(終点矢印)
        public const int PL_SHARPLARGE = 5;
        //矢印ﾀｲﾌﾟⅡ(終点矢印)
        public const int PL_ROUND = 6;
        //矢印ﾀｲﾌﾟⅡ(終点矢印)
        public const int PL_ROUNDMINI = 7;
        //矢印ﾀｲﾌﾟⅡ(終点矢印)
        public const int PL_ROUNDMEDIUMS = 8;
        //矢印ﾀｲﾌﾟⅡ(終点矢印)
        public const int PL_ROUNDMEDIUML = 9;
        //矢印ﾀｲﾌﾟⅡ(終点矢印)
        public const int PL_ROUNDLARGE = 10;
        //11～1５：矢印ﾀｲﾌﾟⅠ(両端矢印)
        //1６～2０：矢印ﾀｲﾌﾟⅡ(両端矢印)

        //******************************************************************************
        //                           変数
        //******************************************************************************

        //ｵｰﾊﾞﾚｲ管理構造体
        [Serializable()]
        public class Overlay
        {
            //ｵｰﾊﾞﾚｲ名称
            public string Name;
            //ｵｰﾊﾞﾚｲmdbﾌｧｲﾙのﾌﾙﾊﾟｽ
            public string Path;
        }

        /// <summary>
        /// ｵｰﾊﾞﾚｲ管理
        /// </summary>
        public static List<Overlay> Overlays = new List<Overlay>();

        //******************************************************************************
        //                           MWView関数(ﾗｲﾌﾞﾗﾘ)
        //******************************************************************************
        /// <summary>
        /// 住居種別ｺﾝﾎﾞﾎﾞｯｸｽへｱｲﾃﾑをｾｯﾄしnKindで指定されたﾘｽﾄを選択状態にする
        /// </summary>
        /// <param name="cboKind">設定対象のｺﾝﾎﾞﾎﾞｯｸｽｺﾝﾄﾛｰﾙ</param>
        /// <param name="nKind">選択する住居種別ｺｰﾄﾞ</param>
        public static void SetKindComboBox(ref ComboBox cboKind, int nKind)
        {
            //ﾘｽﾄを追加する
            cboKind.Items.Add("名称のある建物");
            cboKind.Items.Add("個人");
            cboKind.Items.Add("事業所");
            cboKind.Items.Add("準目標物");
            cboKind.Items.Add("階");
            cboKind.Items.Add("部屋");
            cboKind.Items.Add("目標物");
            cboKind.Items.Add("その他");

            //指定された住居種別ｺｰﾄﾞに一致するﾘｽﾄを選択する
            switch (nKind)
            {
                case 1363:
                    cboKind.Text = "名称のある建物";
                    break;
                case 1364:
                    cboKind.Text = "個人";
                    break;
                case 1365:
                    cboKind.Text = "事業所";
                    break;
                case 1369:
                    cboKind.Text = "準目標物";
                    break;
                case 3118:
                    cboKind.Text = "階";
                    break;
                case 3119:
                    cboKind.Text = "部屋";
                    break;
                default:
                    cboKind.Text = (nKind >= 1200 & nKind < 1300 ? "目標物" : "その他");
                    break;
            }
        }

        /// <summary>
        /// 住居種別文字列をｺｰﾄﾞに変換する
        /// </summary>
        /// <param name="strKind">変換する文字列</param>
        /// <returns>文字列が一致すれば住居種別ｺｰﾄﾞ,一致しなければｾﾞﾛ</returns>
        public static int KindToCode(string strKind)
        {
            int functionReturnValue = 0;

            switch (strKind)
            {
                case "目標物":
                    functionReturnValue = 1200;
                    break;
                case "名称のある建物":
                    functionReturnValue = 1363;
                    break;
                case "個人":
                    functionReturnValue = 1364;
                    break;
                case "事業所":
                    functionReturnValue = 1365;
                    break;
                case "準目標物":
                    functionReturnValue = 1369;
                    break;
                case "階":
                    functionReturnValue = 3118;
                    break;
                case "部屋":
                    functionReturnValue = 3119;
                    break;
                default:
                    functionReturnValue = 0;
                    break;
            }
            return functionReturnValue;
        }

        /// <summary>
        /// ｺｰﾄﾞを住居種別文字列に変換する
        /// </summary>
        /// <param name="nKind">変換するｺｰﾄﾞ</param>
        /// <returns>ｺｰﾄﾞが一致すれば住居種別文字列,一致しなければ"その他"</returns>
        public static string CodeToKind(int nKind)
        {
            string functionReturnValue = null;

            switch (nKind)
            {
                case 1200:
                    functionReturnValue = "目標物";
                    break;
                case 1363:
                    functionReturnValue = "名称のある建物";
                    break;
                case 1364:
                    functionReturnValue = "個人";
                    break;
                case 1365:
                    functionReturnValue = "事業所";
                    break;
                case 1369:
                    functionReturnValue = "準目標物";
                    break;
                case 3118:
                    functionReturnValue = "階";
                    break;
                case 3119:
                    functionReturnValue = "部屋";
                    break;
                default:
                    functionReturnValue = "その他";
                    break;
            }
            return functionReturnValue;
        }

        /// <summary>
        /// ｵｰﾊﾞﾚｲ ｺﾝﾎﾞﾎﾞｯｸｽへｵｰﾊﾞﾚｲ名称を設定する
        /// </summary>
        /// <param name="cboOverlay">設定対象のｺﾝﾎﾞﾎﾞｯｸｽｺﾝﾄﾛｰﾙ</param>
        /// <param name="ctlMWView1">ｵｰﾊﾞﾚｲ情報を取得対象のMWViewｺﾝﾄﾛｰﾙ</param>
        /// <returns>設定したｵｰﾊﾞﾚｲ数</returns>
        public static int SetOverlayComboBox(ComboBox cboOverlay, MWView ctlMWView1)
        {
            MOverlay objMOverlay;
            int nIndex;

            cboOverlay.Items.Clear();
            for (nIndex = 0; nIndex <= ctlMWView1.MOverlays.Count - 1; nIndex++)
            {
                //ｵｰﾊﾞﾚｲｺﾚｸｼｮﾝよりｵｰﾊﾞﾚｲを取得
                objMOverlay = ctlMWView1.MOverlays[nIndex];
                //ｵｰﾊﾞﾚｲ名称をｺﾝﾎﾞﾎﾞｯｸｽに設定する
                cboOverlay.Items.Add(objMOverlay.Name);
            }
            //ｵｰﾊﾞﾚｲが有れば先頭のｵｰﾊﾞﾚｲを選択する
            if (nIndex > 0)
            {
                cboOverlay.SelectedIndex = 0;
            }
            return nIndex;
        }

        ///// <summary>
        ///// ｶﾚﾝﾄｵｰﾊﾞﾚｲからﾚｲﾔｺﾝﾎﾞﾎﾞｯｸｽﾍ設定する
        ///// </summary>
        ///// <param name="cboLayer">設定対象のｺﾝﾎﾞﾎﾞｯｸｽ情報クラス</param>
        ///// <param name="objMOverlay">ﾚｲﾔ情報を取得対象のMOverlayオブジェクト</param>
        ///// <returns>設定したﾚｲﾔ数</returns>
        //public static int SetLayerComboBox(comboLayer cboLayer, MOverlay objMOverlay)
        //{
        //    if (objMOverlay == null)
        //    {
        //        return -1;
        //    }

        //    cboLayer.Items.Clear();
        //    int nIndex;
        //    for (nIndex = 0; nIndex <= objMOverlay.MLayers.Count - 1; nIndex++)
        //    {
        //        //ﾚｲﾔｺﾚｸｼｮﾝよりﾚｲﾔを取得
        //        MLayer objMLayer = objMOverlay.MLayers[nIndex];

        //        LayerItem item = new LayerItem();
        //        item.name = objMLayer.LayerName;
        //        item.number = objMLayer.LayerNo;
        //        cboLayer.Items.Add(item);

        //    }
        //    //ﾚｲﾔが有れば先頭のﾚｲﾔを選択する
        //    if (nIndex > 0)
        //    {
        //        cboLayer.SelectedIndex = 0;
        //    }
        //    return nIndex;
        //}

        ///// <summary>
        ///// 地図種別をﾘｽﾄﾎﾞｯｸｽへ設定
        ///// </summary>
        ///// <param name="lstMapType">設定対象のﾘｽﾄﾎﾞｯｸｽｺﾝﾄﾛｰﾙ</param>
        ///// <param name="nMapType">地図種別</param>
        ///// <param name="MWView1"></param>
        //public static void SetMapTypeListBox(CheckedListBox lstMapType, int nMapType, MWView MWView1)
        //{
        //    int nIndex;
        //    int nCount;

        //    nCount = 0;
        //    //地図の種別ﾘｽﾄをｸﾘｱする
        //    lstMapType.Items.Clear();

        //    for (nIndex = 0; nIndex <= MWView1.MMapTypes.Count - 1; nIndex++)
        //    {
        //        //MMapTypesコレクションで地図種別数を求めている点に注意
        //        if (MWView1.MMapTypes[nIndex].MapType != mwcMapType.MT_BUHIN)
        //        {
        //            MapTypesItem item = new MapTypesItem();
        //            item.name = MWView1.MMapTypes[nIndex].Name;
        //            item.type = MWView1.MMapTypes[nIndex].MapType;
        //            lstMapType.Items.Add(item);
        //            // ビット演算で、対応している地図種別をチェック
        //            if ((nMapType　& (int)MWView1.MMapTypes[nIndex].MapType) != 0)
        //            {
        //                //使用していればﾁｪｯｸﾎﾞｯｸｽをｵﾝ
        //                lstMapType.SetItemChecked(nCount, true);
        //            }
        //            nCount = nCount + 1;
        //        }
        //    }
        //}

        /// <summary>
        /// ｵｰﾊﾞﾚｲ情報をﾘｽﾄﾎﾞｯｸｽへ設定
        /// </summary>
        /// <param name="lstOverlay">設定対象のﾘｽﾄﾎﾞｯｸｽｺﾝﾄﾛｰﾙ</param>
        /// <param name="ctlMWview">ｵｰﾊﾞﾚｲ情報を取得対象のMWViewｺﾝﾄﾛｰﾙ</param>
        public static void SetOverlayListBox(ListBox lstOverlay, MWView ctlMWview)
        {
            int nCount;
            int nIndex;

            nCount = ctlMWview.MOverlays.Count;
            //ﾘｽﾄﾎﾞｯｸｽをｸﾘｱする
            lstOverlay.Items.Clear();
            for (nIndex = 0; nIndex <= nCount - 1; nIndex++)
            {
                //ｵｰﾊﾞﾚ名称をﾘｽﾄﾎﾞｯｸｽに設定
                lstOverlay.Items.Add(ctlMWview.MOverlays[nIndex].Name);
            }
        }

        ///// <summary>
        ///// 利用可能地図種別をｺﾝﾎﾞﾎﾞｯｸｽへ設定
        ///// </summary>
        ///// <param name="cboMapType">設定対象のｺﾝﾎﾞﾎﾞｯｸｽｺﾝﾄﾛｰﾙ</param>
        ///// <param name="MWView1"></param>
        //public static void SetMapTypeComboBox(ComboBox cboMapType, MWView MWView1)
        //{
        //    int nIndex;

        //    cboMapType.Items.Clear();
        //    for (nIndex = 0; nIndex <= MWView1.MMapTypes.Count - 1; nIndex++)
        //    {
        //        //MMapTypesコレクションで地図種別数を求めている点に注意
        //        if (MWView1.MMapTypes[nIndex].MapType != mwcMapType.MT_BUHIN)
        //        {
        //            MapTypesItem item = new MapTypesItem();
        //            item.name = MWView1.MMapTypes[nIndex].Name;
        //            item.type = MWView1.MMapTypes[nIndex].MapType;

        //            cboMapType.Items.Add(item);
        //        }
        //    }
        //}

        /// <summary>
        /// ｵｰﾊﾞﾚｲを名前を付けて追加する
        /// </summary>
        /// <param name="ctlMWview">ｵｰﾊﾞﾚｲ追加対象のMWViewｺﾝﾄﾛｰﾙ(※ｱｸﾃｨﾌﾞﾚﾎﾟｰﾄでｴﾗｰとなるためｵﾌﾞｼﾞｪｸﾄとしている)</param>
        /// <param name="Name">ｵｰﾊﾞﾚｲ名称</param>
        /// <param name="strPath">ﾌﾙﾊﾟｽのｵｰﾊﾞﾚｲ</param>
        /// <returns>追加したｵｰﾊﾞﾚｲのｲﾝﾃﾞｯｸｽ / -1:失敗</returns>
        public static int AddMOverlay(MWView ctlMWview, string Name, string strPath)
        {
            MOverlay objMOverlay1 = new MOverlay();
            bool bRet;
            int nIndex;

            //ｵｰﾊﾞﾚｲﾌｧｲﾙが存在するのか
            if (File.Exists(strPath) == false)
            {
                MessageBox.Show("オーバレイファイル(" + strPath + ")が存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }

            //ｵｰﾊﾞﾚｲﾌｧｲﾙに名前を付けてｵｰﾊﾞﾚｲｺﾚｸｼｮﾝに追加
            objMOverlay1.Name = Name;
            //ｵｰﾊﾞﾚｲ名称
            nIndex = ctlMWview.MOverlays.Add(objMOverlay1);
            if (nIndex < 0)
            {
                MessageBox.Show("ctlMWView.MOverlays.Addに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }

            //ｵｰﾊﾞﾚｲﾌｧｲﾙをｵｰﾌﾟﾝし使用可能にする
            bRet = objMOverlay1.Open(strPath);
            if (bRet == false)
            {
                MessageBox.Show("objMOverlay.Openに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
            return nIndex;
        }
    }
}
