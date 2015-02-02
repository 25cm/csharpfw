using System.Drawing;

namespace FukjBizSystem.Application.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Constants
    /// <summary>
    /// 定数の定義を行うクラスです。
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2013/11/14　吉浦　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class Constants
    {
        #region 項目タイトル、項目の背景色
        /// <summary>
        /// 必須入力用タイトル背景色
        /// </summary>
        public static Color RequiredTitleBackColor = Color.FromArgb(148, 203, 16);

        /// <summary>
        /// 必須入力用コントロール背景色
        /// </summary>
        public static Color RequiredControlBackColor = Color.PeachPuff;

        /// <summary>
        /// 入力用タイトル背景色
        /// </summary>
        public static Color InputTitleBackColor = Color.OliveDrab;

        /// <summary>
        /// 入力用コントロール背景色
        /// </summary>
        public static Color InputControlBackColor = SystemColors.Window;

        /// <summary>
        /// 読込専用タイトル背景色
        /// </summary>
        public static Color ReadOnlyTitleBackColor = Color.FromArgb(148, 203, 16);

        /// <summary>
        /// 読取専用コントロール背景色
        /// </summary>
        public static Color ReadOnlyContolBackColor = Color.LemonChiffon;

        /// <summary>
        /// 偶数行の背景色
        /// </summary>
        public static Color AlternatingRowsBackColor = Color.Beige;
        #endregion
        
        #region 名称マスタ
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： NameKbnConstant
        /// <summary>
        /// 名称識別区分
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static class NameKbnConstant
        {
            /// <summary>
            /// 000
            /// </summary>
            public static readonly string NAME_KBN_000 = "000";

            /// <summary>
            /// 001
            /// </summary>
            public static readonly string NAME_KBN_001 = "001";

            /// <summary>
            /// 002:旧建築用途
            /// </summary>
            public static readonly string NAME_KBN_OLD_KENCHIKU_YOTO_MST = "002";

            /// <summary>
            /// 003
            /// </summary>
            public static readonly string NAME_KBN_003 = "003";

            /// <summary>
            /// 004
            /// </summary>
            public static readonly string NAME_KBN_004 = "004";

            /// <summary>
            /// 005
            /// </summary>
            public static readonly string NAME_KBN_005 = "005";

            /// <summary>
            /// 006
            /// </summary>
            public static readonly string NAME_KBN_006 = "006";

            /// <summary>
            /// 007
            /// </summary>
            public static readonly string NAME_KBN_007 = "007";

            /// <summary>
            /// 008
            /// </summary>
            public static readonly string NAME_KBN_008 = "008";

            /// <summary>
            /// 009
            /// </summary>
            public static readonly string NAME_KBN_009 = "009";

            /// <summary>
            /// 010
            /// </summary>
            public static readonly string NAME_KBN_010 = "010";

            /// <summary>
            /// 011
            /// </summary>
            public static readonly string NAME_KBN_011 = "011";

            /// <summary>
            /// 012
            /// </summary>
            public static readonly string NAME_KBN_012 = "012";

            /// <summary>
            /// 013
            /// </summary>
            public static readonly string NAME_KBN_013 = "013";

            /// <summary>
            /// 014
            /// </summary>
            public static readonly string NAME_KBN_014 = "014";

            /// <summary>
            /// 015
            /// </summary>
            public static readonly string NAME_KBN_015 = "015";
        }
        #endregion

        #region 採番区分
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SaibanKbnConstant
        /// <summary>
        /// 名称識別区分
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static class SaibanKbnConstant
        {
            /// <summary>
            /// 00
            /// </summary>
            public static readonly string SAIBAN_KBN_00 = "00";

            /// <summary>
            /// 01
            /// </summary>
            public static readonly string SAIBAN_KBN_01 = "01";

            /// <summary>
            /// 02
            /// </summary>
            public static readonly string SAIBAN_KBN_02 = "02";

            /// <summary>
            /// 03
            /// </summary>
            public static readonly string SAIBAN_KBN_03 = "03";

            /// <summary>
            /// 04
            /// </summary>
            public static readonly string SAIBAN_KBN_04 = "04";

            /// <summary>
            /// 05
            /// </summary>
            public static readonly string SAIBAN_KBN_05 = "05";

            /// <summary>
            /// 06
            /// </summary>
            public static readonly string SAIBAN_KBN_06 = "06";

            /// <summary>
            /// 07
            /// </summary>
            public static readonly string SAIBAN_KBN_07 = "07";

            /// <summary>
            /// 08
            /// </summary>
            public static readonly string SAIBAN_KBN_08 = "08";

            /// <summary>
            /// 09
            /// </summary>
            public static readonly string SAIBAN_KBN_09 = "09";

            /// <summary>
            /// 10:
            /// </summary>
            public static readonly string SAIBAN_KBN_10 = "10";

            /// <summary>
            /// 11:年会費番号
            /// </summary>
            public static readonly string SAIBAN_KBN_11 = "11";

            /// <summary>
            /// 12:親請求番号(Root(Parent,Origin)SeikyuNo)
            /// </summary>
            public static readonly string SAIBAN_KBN_ROOT_SEIKYU_NO = "12";

            /// <summary>
            /// 13:浄化槽台帳連番(JokasoRenban)
            /// </summary>
            public static readonly string SAIBAN_KBN_JOKASO_DAICHO = "13";

            /// <summary>
            /// 14:保健所受理連番(HokejoJyuriRenban)
            /// </summary>
            public static readonly string SAIBAN_KBN_HOKENJO_JURI_NO = "14";

            /// <summary>
            /// 70:外観検査連番
            /// </summary>
            public static readonly string SAIBAN_KBN_GAIKAN_KENSA = "70";

            /// <summary>
            /// 80:水質検査連番
            /// </summary>
            public static readonly string SAIBAN_KBN_SUISHITSU_KENSA = "80";

            ///// <summary>
            ///// 7X:外観検査連番
            ///// </summary>
            //public static readonly string SAIBAN_KBN_GAIKAN_KENSA_PREFIX = "7";

            ///// <summary>
            ///// 8X:水質検査連番
            ///// </summary>
            //public static readonly string SAIBAN_KBN_SUISHITSU_KENSA_PREFIX = "8";

            /// <summary>
            /// 9X:計量証明連番
            /// </summary>
            public static readonly string SAIBAN_KBN_KEIRYO_SHOUMEI_PREFIX = "9";
        }
        #endregion

        #region フラグ(Flg)

        /// <summary>
        /// 1:TRUE,ON
        /// </summary>
        public static readonly string FLG_ON = "1";

        /// <summary>
        /// 0:FALSE,OFF
        /// </summary>
        public static readonly string FLG_OFF = "0";

        #endregion

        #region 検査依頼ステータス

        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　habu　　    新規作成
        /// 2014/12/21　habu　　    定数名に論理名を設定
        /// </history>
        public class KensaIraiStatusConstant
        {
            /// <summary>
            /// 00:検査依頼登録(新規登録時)
            /// </summary>
            public static readonly string STATUS_IRAI_TOROKU = "00";
            /// <summary>
            /// 10:要員登録済(担当検査員割当済)
            /// </summary>
            public static readonly string STATUS_TANTOU_WARIATE_ZUMI = "10";
            /// <summary>
            /// 20:検査計画済(検査計画処理後)
            /// </summary>
            public static readonly string STATUS_YOTEI_KEIKAKU_ZUMI = "20";
            /// <summary>
            /// 30:外観検査実施中(タブレット持出時)
            /// </summary>
            public static readonly string STATUS_KENSA_MOCHIDASHI = "30";
            /// <summary>
            /// 40:外観検査実施済(タブレット取込時)
            /// </summary>
            public static readonly string STATUS_KENSA_JISSHI_ZUMI = "40";
            /// <summary>
            /// 50:水質検査受付済(水質検査受付登録後)
            /// </summary>
            public static readonly string STATUS_KENSA_SUISHITSU_KEKKA_UKETUKE_ZUMI = "50";
            /// <summary>
            /// 60:水質検印済(水質検査台帳検印後)
            /// </summary>
            public static readonly string STATUS_SUISHITSU_KENIN_ZUMI = "60";
            /// <summary>
            /// 65:検査結果入力済(外観検査結果入力済)
            /// </summary>
            public static readonly string STATUS_GAIKAN_KEKKA_ZUMI = "65";
            /// <summary>
            /// 70:検印済(外観検査検印処理後)
            /// </summary>
            public static readonly string STATUS_GAIKAN_KENIN_ZUMI = "70";
            /// <summary>
            /// 80:検査結果書発行(結果書専用紙印刷後)
            /// </summary>
            public static readonly string STATUS_KEKKASHO_ZUMI = "80";
            /// <summary>
            /// 90:保留(検査保留時)
            /// </summary>
            public static readonly string STATUS_HORYU = "90";
            /// <summary>
            /// 99:取下げ(検査取下げ時)
            /// </summary>
            public static readonly string STATUS_TORISAGE = "99";
        }

        #endregion

        #region 定数マスタ

        #region 定数区分
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： ConstKbnConstanst
        /// <summary>
        /// 定数区分
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　DatNT　　    新規作成
        /// 2014/11/29　小松        追加（042:HHTデータファイル保存先）
        ///                         追加（043:HHTデータファイル名）
        ///                         追加（072:HHTデータファイルダウンロード先）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static class ConstKbnConstanst
        {
            /// <summary>
            /// 001
            /// </summary>
            public static readonly string CONST_KBN_001 = "001";

            /// <summary>
            /// 002
            /// </summary>
            public static readonly string CONST_KBN_002 = "002";

            /// <summary>
            /// 004
            /// </summary>
            public static readonly string CONST_KBN_004 = "004";

            /// <summary>
            /// 004
            /// </summary>
            public static readonly string CONST_KBN_005 = "005";

            /// <summary>
            /// 006
            /// </summary>
            public static readonly string CONST_KBN_006 = "006";

            /// <summary>
            /// 008
            /// </summary>
            public static readonly string CONST_KBN_008 = "008";

            /// <summary>
            /// 009
            /// </summary>
            public static readonly string CONST_KBN_009 = "009";

            /// <summary>
            /// 010:検査保留帳票保存先（サーバー）
            /// Renban
            /// 001:状況把握票
            /// 002:現況報告書
            /// </summary>
            public static readonly string CONST_KBN_010 = "010";

            /// <summary>
            /// 011
            /// </summary>
            public static readonly string CONST_KBN_011 = "011";

            /// <summary>
            /// 012
            /// </summary>
            public static readonly string CONST_KBN_012 = "012";

            /// <summary>
            /// 013
            /// </summary>
            public static readonly string CONST_KBN_013 = "013";

            /// <summary>
            /// 014
            /// </summary>
            public static readonly string CONST_KBN_014 = "014";

            /// <summary>
            /// 015
            /// </summary>
            public static readonly string CONST_KBN_015 = "015";

            /// <summary>
            /// 016
            /// </summary>
            public static readonly string CONST_KBN_016 = "016";

            /// <summary>
            /// 017
            /// </summary>
            public static readonly string CONST_KBN_017 = "017";

            /// <summary>
            /// 018
            /// </summary>
            public static readonly string CONST_KBN_018 = "018";

            /// <summary>
            /// 019
            /// </summary>
            public static readonly string CONST_KBN_019 = "019";

            /// <summary>
            /// 020
            /// </summary>
            public static readonly string CONST_KBN_020 = "020";

            /// <summary>
            /// 021
            /// </summary>
            public static readonly string CONST_KBN_021 = "021";

            /// <summary>
            /// 022
            /// </summary>
            public static readonly string CONST_KBN_022 = "022";

            /// <summary>
            /// 023
            /// </summary>
            public static readonly string CONST_KBN_023 = "023";

            /// <summary>
            /// 024
            /// </summary>
            public static readonly string CONST_KBN_024 = "024";

            /// <summary>
            /// 025
            /// </summary>
            public static readonly string CONST_KBN_025 = "025";

            /// <summary>
            /// 026
            /// </summary>
            public static readonly string CONST_KBN_026 = "026";

            /// <summary>
            /// 027
            /// </summary>
            public static readonly string CONST_KBN_027 = "027";

            /// <summary>
            /// 028
            /// </summary>
            public static readonly string CONST_KBN_028 = "028";

            /// <summary>
            /// 029
            /// </summary>
            public static readonly string CONST_KBN_029 = "029";

            /// <summary>
            /// 030
            /// </summary>
            public static readonly string CONST_KBN_030 = "030";

            /// <summary>
            /// 031
            /// </summary>
            public static readonly string CONST_KBN_031 = "031";

            /// <summary>
            /// 033
            /// </summary>
            public static readonly string CONST_KBN_033 = "033";

            /// <summary>
            /// 036
            /// </summary>
            public static readonly string CONST_KBN_036 = "036";

            /// <summary>
            /// 037
            /// </summary>
            public static readonly string CONST_KBN_037 = "037";

            /// <summary>
            /// 040
            /// </summary>
            public static readonly string CONST_KBN_040 = "040";

            // MOD START 20141129 区分追加 komatsu
            /// <summary>
            /// 042:HHTデータファイル保存先
            /// </summary>
            public static readonly string CONST_KBN_HHT_SV_DIR = "042";

            /// <summary>
            /// 043:HHTデータファイル名
            /// </summary>
            public static readonly string CONST_KBN_HHT_FNAME = "043";
            // MOD  END  20141129 区分追加 komatsu

            /// <summary>
            /// 045
            /// </summary>
            public static readonly string CONST_KBN_045 = "045";

            /// <summary>
            /// 046
            /// </summary>
            public static readonly string CONST_KBN_046 = "046";

            /// <summary>
            /// 047
            /// </summary>
            public static readonly string CONST_KBN_047 = "047";

            /// <summary>
            /// 048
            /// </summary>
            public static readonly string CONST_KBN_048 = "048";

            /// <summary>
            /// 049
            /// </summary>
            public static readonly string CONST_KBN_049 = "049";

            /// <summary>
            /// 050
            /// </summary>
            public static readonly string CONST_KBN_050 = "050";

            /// <summary>
            /// 051
            /// </summary>
            public static readonly string CONST_KBN_051 = "051";

            /// <summary>
            /// 052
            /// </summary>
            public static readonly string CONST_KBN_052 = "052";

            /// <summary>
            /// 053
            /// </summary>
            public static readonly string CONST_KBN_053 = "053";

            /// <summary>
            /// 054
            /// </summary>
            public static readonly string CONST_KBN_054 = "054";

            // MOD START 20141201 ThanhVX
            /// <summary>
            /// 055
            /// </summary>
            public static readonly string CONST_KBN_055 = "055";
            // MOD  END  20141201 ThanhVX

            /// <summary>
            /// 061
            /// </summary>
            public static readonly string CONST_KBN_061 = "061";

            /// <summary>
            /// 064
            /// </summary>
            public static readonly string CONST_KBN_064 = "064";

            /// <summary>
            /// 065
            /// </summary>
            public static readonly string CONST_KBN_065 = "065";

            /// <summary>
            /// 067
            /// </summary>
            public static readonly string CONST_KBN_067 = "067";

            /// <summary>
            /// 068
            /// </summary>
            public static readonly string CONST_KBN_068 = "068";

            /// <summary>
            /// 069:告示区分
            /// </summary>
            public static readonly string CONST_KBN_KOKUJIKBN = "069";

            // MOD START 20141129 区分追加 komatsu
            /// <summary>
            /// 072:HHTデータファイルダウンロード先
            /// </summary>
            public static readonly string CONST_KBN_HHT_CL_DIR = "072";
            // MOD  END  20141129 区分追加 komatsu

            /// <summary>
            /// 070
            /// </summary>
            public static readonly string CONST_KBN_070 = "070";

            /// <summary>
            /// 073
            /// </summary>
            public static readonly string CONST_KBN_073 = "073";

            /// <summary>
            /// 074:検査依頼書保存フォルダ
            /// </summary>
            public static readonly string CONST_KBN_074 = "074";

            /// <summary>
            /// 075
            /// </summary>
            public static readonly string CONST_KBN_075 = "075";

            /// <summary>
            /// 076
            /// </summary>
            public static readonly string CONST_KBN_076 = "076";

            /// <summary>
            /// 077:所見結果置換対象文字列
            /// </summary>
            public static readonly string CONST_KBN_077 = "077";

            /// <summary>
            /// 078
            /// </summary>
            public static readonly string CONST_KBN_078 = "078";
        }
        #endregion

        #region 定数連番
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： ConstRenbanConstanst
        /// <summary>
        /// 定数連番
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　DatNT　　    新規作成
        /// 2014/12/19　宗  　　    コード追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static class ConstRenbanConstanst
        {
            /// <summary>
            /// 001
            /// </summary>
            public static readonly string CONST_RENBAN_001 = "001";

            /// <summary>
            /// 002
            /// </summary>
            public static readonly string CONST_RENBAN_002 = "002";

            /// <summary>
            /// 003
            /// </summary>
            public static readonly string CONST_RENBAN_003 = "003";

            /// <summary>
            /// 004
            /// </summary>
            public static readonly string CONST_RENBAN_004 = "004";

            /// <summary>
            /// 005
            /// </summary>
            public static readonly string CONST_RENBAN_005 = "005";

            /// <summary>
            /// 006
            /// </summary>
            public static readonly string CONST_RENBAN_006 = "006";

            /// <summary>
            /// 007
            /// </summary>
            public static readonly string CONST_RENBAN_007 = "007";

            /// <summary>
            /// 008
            /// </summary>
            public static readonly string CONST_RENBAN_008 = "008";

            /// <summary>
            /// 009
            /// </summary>
            public static readonly string CONST_RENBAN_009 = "009";

            /// <summary>
            /// 016
            /// </summary>
            public static readonly string CONST_RENBAN_016 = "016";

            /// <summary>
            /// 019
            /// </summary>
            public static readonly string CONST_RENBAN_019 = "019";

            /// <summary>
            /// 027
            /// </summary>
            public static readonly string CONST_RENBAN_027 = "027";

            /// <summary>
            /// 029
            /// </summary>
            public static readonly string CONST_RENBAN_029 = "029";

            /// <summary>
            /// 028
            /// </summary>
            public static readonly string CONST_RENBAN_028 = "028";

            /// <summary>
            /// 030
            /// </summary>
            public static readonly string CONST_RENBAN_030 = "030";

            /// <summary>
            /// 031
            /// </summary>
            public static readonly string CONST_RENBAN_031 = "031";

            /// <summary>
            /// 101
            /// </summary>
            public static readonly string CONST_RENBAN_101 = "101";

            /// <summary>
            /// 102
            /// </summary>
            public static readonly string CONST_RENBAN_102 = "102";

            /// <summary>
            /// 201
            /// </summary>
            public static readonly string CONST_RENBAN_201 = "201";

            /// <summary>
            /// 202
            /// </summary>
            public static readonly string CONST_RENBAN_202 = "202";

            /// <summary>
            /// 301
            /// </summary>
            public static readonly string CONST_RENBAN_301 = "301";

            /// <summary>
            /// 401
            /// </summary>
            public static readonly string CONST_RENBAN_401 = "401";

            /// <summary>
            /// 402
            /// </summary>
            public static readonly string CONST_RENBAN_402 = "402";

            /// <summary>
            /// 403
            /// </summary>
            public static readonly string CONST_RENBAN_403 = "403";

            /// <summary>
            /// 404
            /// </summary>
            public static readonly string CONST_RENBAN_404 = "404";

            /// <summary>
            /// 501
            /// </summary>
            public static readonly string CONST_RENBAN_501 = "501";

            /// <summary>
            /// 601
            /// </summary>
            public static readonly string CONST_RENBAN_601 = "601";

            /// <summary>
            /// 602
            /// </summary>
            public static readonly string CONST_RENBAN_602 = "602";

            /// <summary>
            /// 603
            /// </summary>
            public static readonly string CONST_RENBAN_603 = "603";

            /// <summary>
            /// 604
            /// </summary>
            public static readonly string CONST_RENBAN_604 = "604";


        }
        #endregion

        #endregion

        #region 法定区分
        /// <summary>
        /// 法定区分
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　habu　　    新規作成
        /// </history>
        public static class HoteiKbnConstant
        {
            /// <summary>
            /// 1:7条検査
            /// </summary>
            public static readonly string HOTEI_KBN_7JO_GAIKAN = "1";

            /// <summary>
            /// 2:11条外観検査
            /// </summary>
            public static readonly string HOTEI_KBN_11JO_GAIKAN = "2";

            /// <summary>
            /// 3:11条水質検査
            /// </summary>
            public static readonly string HOTEI_KBN_11JO_SUISHITSU = "3";
        }
        #endregion

        #region 処理方式区分
        /// <summary>
        /// 処理方式区分
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　habu　　    新規作成
        /// </history>
        public static class ShoriHoshikiKbnConstant
        {
            /// <summary>
            /// 1:単独
            /// </summary>
            public static readonly string SHORI_HOSHIKI_KBN_TANDOKU = "1";

            /// <summary>
            /// 2:合併
            /// </summary>
            public static readonly string SHORI_HOSHIKI_KBN_GAPPEI = "2";

            /// <summary>
            /// 3:小合(小型合併)
            /// </summary>
            public static readonly string SHORI_HOSHIKI_KBN_SHOUGOU = "3";

            /// <summary>
            /// 4:その他
            /// </summary>
            public static readonly string SHORI_HOSHIKI_KBN_OTHER = "4";
        }
        #endregion

        #region 処理方式種別
        /// <summary>
        /// 処理方式種別
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　habu　　    新規作成
        /// </history>
        public static class ShoriHoshikiShubetsuConstant
        {
            /// <summary>
            /// 1:合併
            /// </summary>
            public static readonly string SHORI_HOSHIKI_SHUBETSU_GAPPEI = "1";

            /// <summary>
            /// 2:ばっ気型
            /// </summary>
            public static readonly string SHORI_HOSHIKI_SHUBETSU_BAKKI = "2";

            /// <summary>
            /// 3:腐敗型
            /// </summary>
            public static readonly string SHORI_HOSHIKI_SHUBETSU_FUHAI = "3";

            /// <summary>
            /// 4:変則合併
            /// </summary>
            public static readonly string SHORI_HOSHIKI_SHUBETSU_HENSOKU = "4";

            /// <summary>
            /// 5:小型合併
            /// </summary>
            public static readonly string SHORI_HOSHIKI_SHUBETSU_KOGATA = "5";

            /// <summary>
            /// 6:その他
            /// </summary>
            public static readonly string SHORI_HOSHIKI_SHUBETSU_OTHER = "6";
        }
        #endregion

        #region 検査種別
        /// <summary>
        /// 検査種別
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　habu　　    新規作成
        /// </history>
        public static class KensaShubetsuConstant
        {
            /// <summary>
            /// 1:
            /// </summary>
            public static readonly string KENSA_SHUBETSU_1 = "1";

            /// <summary>
            /// 2:
            /// </summary>
            public static readonly string KENSA_SHUBETSU_2 = "2";
        }
        #endregion

        #region 水質コード
        /// <summary>
        /// 水質コード
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　habu　　    新規作成
        /// </history>
        public static class SuishitsuCdConstant
        {
            /// <summary>
            /// 001:浄化槽放流水
            /// </summary>
            public static readonly string SUISHITSU_CD_JOKASO_HORYUSUI = "001";
        }
        #endregion

        #region スクリーニング区分
        /// <summary>
        /// スクリーニング区分
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　habu　　    新規作成
        /// </history>
        public static class ScreeningKbnConstant
        {
            /// <summary>
            /// 0:対象外
            /// </summary>
            public static readonly string SCREENING_KBN_NONE = "0";

            /// <summary>
            /// 1:スクリーニング(Screening)
            /// </summary>
            public static readonly string SCREENING_KBN_SCREENING = "1";

            /// <summary>
            /// 2:フォロー(Follow)
            /// </summary>
            public static readonly string SCREENING_KBN_FOLLOW = "2";

            /// <summary>
            /// 3:スクリーニング+フォロー(Screening and Follow)
            /// </summary>
            public static readonly string SCREENING_KBN_SCREENING_FOLLOW = "3";
        }
        #endregion

        #region 試験項目
        /// <summary>
        /// 試験項目
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/29　habu　　    新規作成
        /// </history>
        public static class ShikenKomokuConstant
        {
            /// <summary>
            /// 000:温度
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_ONDO = "000";

            /// <summary>
            /// 001:pH(水素イオン濃度)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_PH = "001";

            /// <summary>
            /// 082:透視度
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_TR = "082";

            /// <summary>
            /// 003:BOD
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_BOD = "003";

            /// <summary>
            /// 033:BOD
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_BOD_2 = "033";

            /// <summary>
            /// 070:残留塩素濃度
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_ZANEN = "070";

            /// <summary>
            /// 005:Cl(塩化物イオン)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_CL = "005";

            /// <summary>
            /// 031:色度
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_COLOR = "031";

            /// <summary>
            /// 087:色度
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_COLOR_2 = "087";

            /// <summary>
            /// 002:SS(懸濁物質)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_SS = "002";

            /// <summary>
            /// 008:MLSS(活性汚泥浮遊物質)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_MLSS = "008";

            /// <summary>
            /// 006:COD(化学的酵素要求量)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_COD = "006";

            /// <summary>
            /// 007:ヘキサン抽出物
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_N_HEXAN = "007";

            /// <summary>
            /// 010:ABS(陰イオン界面活性剤)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_ABS = "010";

            /// <summary>
            /// 004:アンモニア性窒素
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_NH4 = "004";

            /// <summary>
            /// 013:亜硝酸窒素(定量)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_NO2_N_TEIRYOU = "013";

            /// <summary>
            /// 014:硝酸窒素(定量)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_NO3_N_TEIRYOU = "014";

            /// <summary>
            /// 009:全窒素
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_T_N = "009";

            /// <summary>
            /// 023:全窒素
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_T_N_2 = "023";

            /// <summary>
            /// 011:全りん
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_T_P = "011";

            /// <summary>
            /// 024:全りん
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_T_P_2 = "024";

            /// <summary>
            /// 012:りん酸イオン
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_P_ION = "012";

            /// <summary>
            /// 085:大腸菌群数
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_COLON_BACT = "085";

            /// <summary>
            /// 083:亜硝酸窒素(定性)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_NO2_N_TEISEI = "083";

            /// <summary>
            /// 084:硝酸窒素(定性)
            /// </summary>
            public static readonly string SHIKEN_KOMOKU_NO3_N_TEISEI = "084";
        }
        #endregion

        #region JokasoJotaiKbnConstant
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　habu　　    新規作成
        /// </history>
        public static class JokasoJotaiKbnConstant
        {
            /// <summary>
            /// 1:現在
            /// </summary>
            public static readonly string GENZAI = "1";

            /// <summary>
            /// 2:廃止
            /// </summary>
            public static readonly string HAISHI = "2";
        }
        #endregion

        #region 前受金照合番号1
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/19　habu　　    新規作成
        /// </history>
        public static class MaeukekinSyogoNo1Constant
        {
            /// <summary>
            /// 0:手入力、用紙記載有
            /// </summary>
            public static readonly string MANUAL = "0";

            /// <summary>
            /// 1:自動採番、用紙記載無
            /// </summary>
            public static readonly string AUTO = "1";
        }
        #endregion

        #region 得意先の最大終了日

        /// <summary>
        /// 得意先の最大終了日
        /// </summary>
        public static decimal TokuisakiMaxShuryoDate = 99999999;

        #endregion

        #region 保証番号年度変換定数

        /// <summary>
        /// 西暦<->平成変換オフセット
        /// </summary>
        public static int HOSHOU_NENDO_OFFSET = 1988;

        #endregion

        #region プリンタ設定
        
        #region 印刷用紙区分
        /// <summary>
        /// 印刷用紙区分
        /// </summary>
        public static class PrintKbn
        {
            /// <summary>
            /// 請求書専用紙
            /// </summary>
            public static readonly string PRINT_KBN_SEIKYUSHO = "1";

            /// <summary>
            /// はがき／ＤＭ用
            /// </summary>
            public static readonly string PRINT_KBN_HAGAKI = "2";

            /// <summary>
            /// 送付状専用
            /// </summary>
            public static readonly string PRINT_KBN_SOFUJO = "3";

            /// <summary>
            /// 機能保証
            /// </summary>
            public static readonly string PRINT_KBN_KINOHOSHO = "4";
        }
        #endregion

        #endregion

        #region 外観検査地区
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GaikanChikuConstant
        /// <summary>
        /// 外観検査地区
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static class GaikanChikuConstant
        {
            /// <summary>
            /// 外観検査地区/A
            /// </summary>
            public static readonly string GAIKAN_CHIKU_A = "A";

            /// <summary>
            /// 外観検査地区/B
            /// </summary>
            public static readonly string GAIKAN_CHIKU_B = "B";

            /// <summary>
            /// 外観検査地区/C
            /// </summary>
            public static readonly string GAIKAN_CHIKU_C = "C";

            /// <summary>
            /// 外観検査地区/D
            /// </summary>
            public static readonly string GAIKAN_CHIKU_D = "D";

            /// <summary>
            /// 外観検査地区/E
            /// </summary>
            public static readonly string GAIKAN_CHIKU_E = "E";
        }
        #endregion

        #region マスタテーブル名
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public static class MstTblConstanst
        {
            /// <summary>
            /// 
            /// </summary>
            public static readonly string BUSHO_MST = "BushoMst";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string CHIKU_MST = "ChikuMst";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string CONST_MST = "ConstMst";

            /// <summary>
            /// GyoshaMst:業者マスタ
            /// </summary>
            public static readonly string GYOSHA_MST = "GyoshaMst";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string HOKENJO_MST = "HokenjoMst";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string KATASHIKI_MST = "KatashikiMst";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string SHISHO_MST = "ShishoMst";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string SHOKUIN_MST = "ShokuinMst";
        }
        #endregion

        #region 野帳
        /// <summary>
        /// 野帳一覧
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06　DatNT　　 新規作成
        /// </history>
        public static class YachoConstant
        {
            /// <summary>
            /// 残留塩素濃度
            /// </summary>
            public static readonly string YACHO_001 = "残留塩素濃度";

            /// <summary>
            /// NO2-N（亜硝酸性窒素）（定性）
            /// </summary>
            public static readonly string YACHO_002 = "NO2-N（亜硝酸性窒素）（定性）";

            /// <summary>
            /// NO3-N（硝酸性窒素）（定性）
            /// </summary>
            public static readonly string YACHO_003 = "NO3-N（硝酸性窒素）（定性）";

            /// <summary>
            /// NO2-N（亜硝酸性窒素）（定量）
            /// </summary>
            public static readonly string YACHO_004 = "NO2-N（亜硝酸性窒素）（定量）";

            /// <summary>
            /// NO3-N（硝酸性窒素）（定量）
            /// </summary>
            public static readonly string YACHO_005 = "NO3-N（硝酸性窒素）（定量）";

            /// <summary>
            /// COD（化学的酸素要求量）
            /// </summary>
            public static readonly string YACHO_006 = "COD（化学的酸素要求量）";

            /// <summary>
            /// 大腸菌群数
            /// </summary>
            public static readonly string YACHO_007 = "大腸菌群数";

            /// <summary>
            /// T-N（全窒素）
            /// </summary>
            public static readonly string YACHO_008 = "T-N（全窒素）";

            /// <summary>
            /// T-P（全りん）
            /// </summary>
            public static readonly string YACHO_009 = "T-P（全りん）";

            /// <summary>
            /// ヘキサン抽出物質
            /// </summary>
            public static readonly string YACHO_010 = "ヘキサン抽出物質";

            /// <summary>
            /// ABS（陰イオン界面活性剤）
            /// </summary>
            public static readonly string YACHO_011 = "ABS（陰イオン界面活性剤）";

            /// <summary>
            /// 外観
            /// </summary>
            public static readonly string YACHO_012 = "外観";

            /// <summary>
            /// 臭気
            /// </summary>
            public static readonly string YACHO_013 = "臭気";

            /// <summary>
            /// りん酸イオン
            /// </summary>
            public static readonly string YACHO_014 = "りん酸イオン";

            /// <summary>
            /// 色度
            /// </summary>
            public static readonly string YACHO_015 = "色度";
        }
        #endregion

        #region YachoCsvConstant
                /// <summary>
        /// CSVファイル取込
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        public static class YachoCsvConstant
        {
            /// <summary>
            /// GAIKAN.CSV
            /// </summary>
            public static readonly string YACHO_CSV_GAIKAN = "GAIKAN.CSV";

            /// <summary>
            /// GAIKAN.CSV
            /// </summary>
            public static readonly string YACHO_CSV_11JYO = "11JYO.CSV";

            /// <summary>
            /// GAIKAN.CSV
            /// </summary>
            public static readonly string YACHO_CSV_SAISOKU = "SAISOKU.CSV";

            /// <summary>
            /// GAIKAN.CSV
            /// </summary>
            public static readonly string YACHO_CSV_SS_DATA = "SS_DATA.CSV";
        }
        #endregion

        #region KensaIraiNyukinHohoConstant
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　habu　　    新規作成
        /// </history>
        public static class KensaIraiNyukinHohoConstant
        {
            /// <summary>
            /// 001:領収済
            /// </summary>
            public static readonly string NYUKIN_RYOSHU_ZUMI = "001";

            /// <summary>
            /// 002:
            /// </summary>
            public static readonly string NYUKIN_HOHO_2 = "002";

            /// <summary>
            /// 003:請求
            /// </summary>
            public static readonly string NYUKIN_SEIKYU = "003";

            /// <summary>
            /// 004:
            /// </summary>
            public static readonly string NYUKIN_HOHO_4 = "004";

            /// <summary>
            /// 005:一括請求
            /// </summary>
            public static readonly string NYUKIN_SEIKYU_ITKATSU = "005";
        }
        #endregion

        #region KensaIraiNyukinKanryoConstant
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　habu　　    新規作成
        /// </history>
        public static class KensaIraiNyukinKanryoConstant
        {
            /// <summary>
            /// 0:入金未完了
            /// </summary>
            public static readonly string NYUKIN_NONE = "0";

            /// <summary>
            /// 1:入金完了
            /// </summary>
            public static readonly string NYUKIN_DONE = "1";
        }
        #endregion

        #region 入金種別
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： NyukinSyubetsuConstant
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static class NyukinSyubetsuConstant
        {
            /// <summary>
            /// 1:入金種別/請求
            /// </summary>
            public static readonly string NYUKIN_SYUBETSU_1 = "1";

            /// <summary>
            /// 2:入金種別/前受金
            /// </summary>
            public static readonly string NYUKIN_SYUBETSU_2 = "2";

            /// <summary>
            /// 3:入金種別/用紙販売(請求外) 
            /// </summary>
            public static readonly string NYUKIN_SYUBETSU_3 = "3";

            /// <summary>
            /// 4:入金種別/年会費(請求外)
            /// </summary>
            public static readonly string NYUKIN_SYUBETSU_4 = "4";

            /// <summary>
            /// 5:入金種別/計量証明(請求外) 
            /// </summary>
            public static readonly string NYUKIN_SYUBETSU_5 = "5";

            /// <summary>
            /// 6:入金種別/検査手数料(請求外)
            /// </summary>
            public static readonly string NYUKIN_SYUBETSU_6 = "6";

            /// <summary>
            /// 7:入金種別/機能保証(請求外)
            /// </summary>
            public static readonly string NYUKIN_SYUBETSU_7 = "7";
        }
        #endregion

        #region TaniSochiGroupCdConstant
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/08　habu　　    新規作成
        /// </history>
        public static class TaniSochiGroupCdConstant
        {
            /// <summary>
            /// 00:タイトル、体裁
            /// </summary>
            public static readonly string JOKASO_DEFAULT_CD_TITLE = "00";

            /// <summary>
            /// 80:処理水の様子(浄化槽デフォルト)
            /// </summary>
            public static readonly string JOKASO_DEFAULT_CD_SHORISUI = "80";

            /// <summary>
            /// 81:書類(浄化槽デフォルト)
            /// </summary>
            public static readonly string JOKASO_DEFAULT_CD_SHORUI = "81";

            /// <summary>
            /// 90:外観補足
            /// </summary>
            public static readonly string JOKASO_DEFAULT_CD_GAIKAN_HOSOKU = "90";

            /// <summary>
            /// 91:水質補足
            /// </summary>
            public static readonly string JOKASO_DEFAULT_CD_SHUISHITSU_HOSOKU = "91";

            /// <summary>
            /// 92:書類補足
            /// </summary>
            public static readonly string JOKASO_DEFAULT_CD_SHORUI_HOSOKU = "92";
        }
        #endregion

        #region KakuninKensaShubetsuBunrui
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/09　habu　　    新規作成
        /// </history>
        public static class KakuninKensaShubetsuBunrui
        {
            /// <summary>
            /// 1:BOD/透視度
            /// </summary>
            public static readonly string BOD_TOSHIDO = "1";

            /// <summary>
            /// 2:SS/透視度
            /// </summary>
            public static readonly string SS_TOSHIDO = "2";
        }
        #endregion
    }
    #endregion
}
