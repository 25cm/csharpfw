using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.HoteiKensaDaicho
{

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput
    {
        #region プロパティ

        /// <summary>
        /// 更新日
        /// </summary>
        DateTime UpdateDt { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        string UpdateUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        string UpdateTarm { get; set; }

        /// <summary>
        /// 検査台帳一覧
        /// </summary>
        DataGridView  listDataGridView { get; set; }

        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        #region プロパティ

        /// <summary>
        /// 更新日
        /// </summary>
        public DateTime UpdateDt { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        public string UpdateTarm { get; set; }

        /// <summary>
        /// 検査台帳一覧
        /// </summary>
        public DataGridView  listDataGridView { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                // ログ設定
                return string.Format("更新日時[{0}], 更新者[{1}], 更新端末[{2}]",
                                        UpdateDt, UpdateUser, UpdateTarm);
            }
        }

        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALOutput : IKakuteiBtnClickALOutput
    {
       
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickApplicationLogic : BaseApplicationLogic<IKakuteiBtnClickALInput, IKakuteiBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoteiKensaDaicho：KakuteiBtnClick";

        /// <summary>
        /// 別検体情報
        /// </summary>
        struct BetsuKentai
        {
            public int rowIndex;
            public string kachoKenin;
            public string hukukachoKenin;
        }

        /// <summary>
        /// チェック状態確認用
        /// </summary>
        private const string CheckOn = "True";
        private const string CheckOff = "False";

        /// <summary>
        /// 更新日
        /// </summary>
        enum UpdateDt
        {
            iraiUpdateDt,
            kekkaUpdateDt,
            saisaisuiUpdateDt,
            headerUpdateDt,
            ph1UpdateDt,
            ph2UpdateDt,
            tr1UpdateDt,
            tr2UpdateDt,
            bod1UpdateDt,
            bod2UpdateDt,
            zanen1UpdateDt,
            zanen2UpdateDt,
            cl1UpdateDt,
            cl2UpdateDt,
            Count
        }

        #region DataGridViewの各Index
        // 検査依頼法定区分
        private const int kensaIraiHoteiKbnColIndex = 0;
        // 検査依頼保健所コード
        private const int kensaIraiHokenjoCdColIndex = 1;
        // 検査依頼年度
        private const int kensaIraiNendoColIndex = 2;
        // 検査依頼連番
        private const int kensaIraiRenbanColIndex = 3;
        // 浄化槽保健所コード
        private const int jokasoHokenjoCdColIndex = 4;
        // 浄化槽台帳登録年度
        private const int jokasoTorokuNendoColIndex = 5;
        // 浄化槽台帳連番
        private const int jokasoRenbanColIndex = 6;
        // 採水員コード
        private const int saisuiinCdColIndex = 7;
        // 放流先コード
        private const int horyusakiCdColIndex = 8;
        // 再採水区分
        private const int saisaisuiKbnColIndex = 9;
        // 再採水
        private const int saisaisuiDispColIndex = 10;
        // 検査区分
        private const int kensaKbnColIndex = 11;
        // 区分
        private const int kensaKbnNmColIndex = 12;
        // 依頼年度
        private const int iraiNendoColIndex = 13;
        // 支所コード
        private const int shishoCdColIndex = 14;
        // 依頼No
        private const int iraiNoColIndex = 15;
        // スクリーニング候補
        private const int screeningKohoColIndex = 16;
        // フォロー候補
        private const int followKohoColIndex = 17;
        // クロスチェック異常（水質判定表）
        private const int crossCheckSuishitsuColIndex = 18;
        // クロスチェック異常（過去履歴）
        private const int crossCheckKakoColIndex = 19;
        // 異常種別
        private const int ijyoShubetsuColIndex = 20;
        // 適正判定コード
        private const int tekiseiHanteiCdColIndex = 21;
        // 適正判定
        private const int tekiseiHanteiColIndex = 22;
        // 処理方式区分
        private const int shoriHoshikiCdColIndex = 23;
        // 処理方式名
        private const int syoriHoshikiNmColIndex = 24;
        // 処理目標水質
        private const int shorimokuhyoSuishitsuColIndex = 25;
        // 過去情報ボタン
        private const int kakoJohoColIndex = 26;
        // 採水員ボタン
        private const int saisuiinColIndex = 27;
        // スクリーニング指示済フラグ
        private const int screeningFlgColIndex = 28;
        // スクリーニング指示
        private const int screeningColIndex = 29;
        // 課長検印（その他）
        private const int kachoKeninEtcColIndex = 30;
        // 副課長検印（その他）
        private const int hukukachoKeninEtcColIndex = 31;
        // 課長検印
        private const int kachoKeninColIndex = 32;
        // 副課長検印
        private const int hukukachoKeninColIndex = 33;
        // pH1
        private const int ph1ColIndex = 34;
        // 温度1
        private const int ondo1ColIndex = 35;
        // 結果コード（pH1）
        private const int ph1KekkaCdColIndex = 36;
        // 確認検査種別（pH1）
        private const int kakuninKensaPh1ColIndex = 37;
        // 採用値（pH1）
        private const int saiyotiPh1ColIndex = 38;
        // pH1確認検査種別（過去との比較）
        private const int ph1KensaShubetsuKakoIndex = 39;
        // 結果入力区分（pH1）
        private const int kekkaNyuryokuPh1ColIndex = 40;
        // pH2
        private const int ph2ColIndex = 41;
        // 温度2
        private const int ondo2ColIndex = 42;
        // 結果コード（pH2）
        private const int ph2KekkaCdColIndex = 43;
        // 確認検査種別（pH2）
        private const int kakuninKensaPh2ColIndex = 44;
        // 採用値（pH2）
        private const int saiyotiPh2ColIndex = 45;
        // pH2確認検査種別（過去との比較）
        private const int ph2KensaShubetsuKakoIndex = 46;
        // 結果入力区分（pH2）
        private const int kekkaNyuryokuPh2ColIndex = 47;
        // 更新区分（過去との比較）pH
        private const int koshinKbnKakoPhIndex = 48;
        // 透視度1
        private const int tr1ColIndex = 49;
        // 結果コード（透視度1）
        private const int tr1KekkaCdColIndex = 50;
        // 確認検査種別（透視度1）
        private const int kakuninKensaTr1ColIndex = 51;
        // 採用値（透視度1）
        private const int saiyotiTr1ColIndex = 52;
        // 透視度1確認検査種別（過去との比較）
        private const int tr1KensaShubetsuKakoIndex = 53;
        // 結果入力区分（透視度1）
        private const int kekkaNyuryokuTr1ColIndex = 54;
        // 透視度2
        private const int tr2ColIndex = 55;
        // 結果コード（透視度2）
        private const int tr2KekkaCdColIndex = 56;
        // 確認検査種別（透視度2）
        private const int kakuninKensaTr2ColIndex = 57;
        // 採用値（透視度2）
        private const int saiyotiTr2ColIndex = 58;
        // 透視度2確認検査種別（過去との比較）
        private const int tr2KensaShubetsuKakoIndex = 59;
        // 結果入力区分（透視度2）
        private const int kekkaNyuryokuTr2ColIndex = 60;
        // 更新区分（過去との比較）透視度
        private const int koshinKbnKakoTrIndex = 61;
        // BOD1
        private const int bod1ColIndex = 62;
        // 結果コード（BOD1）
        private const int bod1KekkaCdColIndex = 63;
        // 確認検査種別（BOD1）
        private const int kakuninKensaBod1ColIndex = 64;
        // 採用値（BOD1）
        private const int saiyotiBod1ColIndex = 65;
        // BOD1確認検査種別（過去との比較）
        private const int bod1KensaShubetsuKakoIndex = 66;
        // 結果入力区分（BOD1）
        private const int kekkaNyuryokuBod1ColIndex = 67;
        // BOD2
        private const int bod2ColIndex = 68;
        // 結果コード（BOD2）
        private const int bod2KekkaCdColIndex = 69;
        // 確認検査種別（BOD2）
        private const int kakuninKensaBod2ColIndex = 70;
        // 採用値（BOD2）
        private const int saiyotiBod2ColIndex = 71;
        // BOD2確認検査種別（過去との比較）
        private const int bod2KensaShubetsuKakoIndex = 72;
        // 結果入力区分（BOD2）
        private const int kekkaNyuryokuBod2ColIndex = 73;
        // 更新区分（過去との比較）BOD
        private const int koshinKbnKakoBodIndex = 74;
        // 残塩1
        private const int zanen1ColIndex = 75;
        // 結果コード（残塩1）
        private const int zanen1KekkaCdColIndex = 76;
        // 確認検査種別（残塩1）
        private const int kakuninKensaZanen1ColIndex = 77;
        // 採用値（残塩1）
        private const int saiyotiZanen1ColIndex = 78;
        // 残塩1確認検査種別（過去との比較）
        private const int zanen1KensaShubetsuKakoIndex = 79;
        // 結果入力区分（残塩1）
        private const int kekkaNyuryokuZanen1ColIndex = 80;
        // 残塩2
        private const int zanen2ColIndex = 81;
        // 結果コード（残塩2）
        private const int zanen2KekkaCdColIndex = 82;
        // 確認検査種別（残塩2）
        private const int kakuninKensaZanen2ColIndex = 83;
        // 採用値（残塩2）
        private const int saiyotiZanen2ColIndex = 84;
        // 残塩2確認検査種別（過去との比較）
        private const int zanen2KensaShubetsuKakoIndex = 85;
        // 結果入力区分（残塩2）
        private const int kekkaNyuryokuZanen2ColIndex = 86;
        // 更新区分（過去との比較）残塩
        private const int koshinKbnKakoZanenIndex = 87;
        // 塩化物イオン1
        private const int cl1ColIndex = 88;
        // 結果コード（塩化物イオン1）
        private const int cl1KekkaCdColIndex = 89;
        // 確認検査種別（塩化物イオン1）
        private const int kakuninKensaCl1ColIndex = 90;
        // 採用値（塩化物イオン1）
        private const int saiyotiCl1ColIndex = 91;
        // 塩化物イオン1確認検査種別（過去との比較）
        private const int cl1KensaShubetsuKakoIndex = 92;
        // 結果入力区分（塩化物イオン1）
        private const int kekkaNyuryokuCl1ColIndex = 93;
        // 塩化物イオン2
        private const int cl2ColIndex = 94;
        // 結果コード（塩化物イオン2）
        private const int cl2KekkaCdColIndex = 95;
        // 確認検査種別（塩化物イオン2）
        private const int kakuninKensaCl2ColIndex = 96;
        // 採用値（塩化物イオン2）
        private const int saiyotiCl2ColIndex = 97;
        // 塩化物イオン2確認検査種別（過去との比較）
        private const int cl2KensaShubetsuKakoIndex = 98;
        // 結果入力区分（塩化物イオン2）
        private const int kekkaNyuryokuCl2ColIndex = 99;
        // 更新区分（過去との比較）塩化物イオン
        private const int koshinKbnKakoClIndex = 100;

        // 20150129 sou Start
        //// 塩化物イオン過去
        //private const int clKakoColIndex = 101;
        //// 結果確定日
        //private const int kekkaKakuteiDtColIndex = 102;
        //// 更新区分(検印)
        //private const int koshinKbnKeninIndex = 103;
        //// 更新区分(スクリーニング候補)
        //private const int koshinKbnScreeningKohoIndex = 104;
        //// 更新区分(クロスチェック異常(水質判定表))
        //private const int koshinKbnCrossSuishitsuIndex = 105;
        //// 更新区分(クロスチェック異常(過去履歴))
        //private const int koshinKbnCrossKakoIndex = 106;
        //// 更新区分(pH)
        //private const int koshinKbnPhIndex = 107;
        //// 更新区分(透視度)
        //private const int koshinKbnTrIndex = 108;
        //// 更新区分(BOD)
        //private const int koshinKbnBodIndex = 109;
        //// 更新区分(残塩)
        //private const int koshinKbnZanenIndex = 110;
        //// 更新区分(塩化物イオン)
        //private const int koshinKbnClIndex = 111;
        //// 更新区分（BOD/透視度）
        //private const int koshinKbnBodTrIndex = 112;
        //// 更新区分（BOD基準値オーバー）
        //private const int koshinKbnBodOverIndex = 113;
        //// 更新区分（塩化物イオン確認検査）
        //private const int koshinKbnClKakuninIndex = 114;
        //// BOD1確認検査種別（BOD/透視度）
        //private const int bod1KensaShubetsuBodTrIndex = 115;
        //// BOD2確認検査種別（BOD/透視度）
        //private const int bod2KensaShubetsuBodTrIndex = 116;
        //// 透視度1確認検査種別（BOD/透視度）
        //private const int tr1KensaShubetsuBodTrIndex = 117;
        //// 透視度2確認検査種別（BOD/透視度）
        //private const int tr2KensaShubetsuBodTrIndex = 118;
        //// BOD1確認検査種別（BOD基準値オーバー）
        //private const int bod1KensaShubetsuBodOverIndex = 119;
        //// BOD2確認検査種別（BOD基準値オーバー）
        //private const int bod2KensaShubetsuBodOverIndex = 120;
        //// 塩化物イオン1確認検査種別（塩化物イオン確認検査）
        //private const int cl1KensaShubetsuEnkaIonIndex = 121;
        //// 塩化物イオン2確認検査種別（塩化物イオン確認検査）
        //private const int cl2KensaShubetsuEnkaIonIndex = 122;
        //// 検査状況
        //private const int kensaJyokyoColIndex = 123;
        //// 更新日(検査依頼テーブル)
        //private const int iraiUpdateDtColIndex = 124;
        //// 更新日(検査結果テーブル)
        //private const int kekkaUpdateDtColIndex = 125;
        //// 更新日(再採水テーブル)
        //private const int saisaisuiUpdateDtColIndex = 126;
        //// 更新日(検査台帳ヘッダ)
        //private const int headerUpdateDtColIndex = 127;
        //// 更新日(検査台帳明細(PH1))
        //private const int ph1UpdateDtColIndex = 128;
        //// 更新日(検査台帳明細(PH2))
        //private const int ph2UpdateDtColIndex = 129;
        //// 更新日(検査台帳明細(透視度1))
        //private const int tr1UpdateDtColIndex = 130;
        //// 更新日(検査台帳明細(透視度2))
        //private const int tr2UpdateDtColIndex = 131;
        //// 更新日(検査台帳明細(BOD1))
        //private const int bod1UpdateDtColIndex = 132;
        //// 更新日(検査台帳明細(BOD2))
        //private const int bod2UpdateDtColIndex = 133;
        //// 更新日(検査台帳明細(残塩1))
        //private const int zanen1UpdateDtColIndex = 134;
        //// 更新日(検査台帳明細(残塩2))
        //private const int zanen2UpdateDtColIndex = 135;
        //// 更新日(検査台帳明細(塩化物イオン1))
        //private const int cl1UpdateDtColIndex = 136;
        //// 更新日(検査台帳明細(塩化物イオン2))
        //private const int cl2UpdateDtColIndex = 137;

        // ATUBOD1
        private const int atubod1ColIndex = 101;
        // 結果コード（ATUBOD1）
        private const int atubod1KekkaCdColIndex = 102;
        // 確認検査種別（ATUBOD1）
        private const int kakuninKensaAtubod1ColIndex = 103;
        // 採用値（ATUBOD1）
        private const int saiyotiAtubod1ColIndex = 104;
        // ATUBOD1確認検査種別（過去との比較）
        private const int atubod1KensaShubetsuKakoIndex = 105;
        // 結果入力区分（ATUBOD1）
        private const int kekkaNyuryokuAtubod1ColIndex = 106;
        // ATUBOD2
        private const int atubod2ColIndex = 107;
        // 結果コード（ATUBOD2）
        private const int atubod2KekkaCdColIndex = 108;
        // 確認検査種別（ATUBOD2）
        private const int kakuninKensaAtubod2ColIndex = 109;
        // 採用値（ATUBOD2）
        private const int saiyotiAtubod2ColIndex = 110;
        // ATUBOD2確認検査種別（過去との比較）
        private const int atubod2KensaShubetsuKakoIndex = 111;
        // 結果入力区分（ATUBOD2）
        private const int kekkaNyuryokuAtubod2ColIndex = 112;
        // 更新区分（過去との比較）ATUBOD
        private const int koshinKbnKakoAtubodIndex = 113;

        // 塩化物イオン過去
        private const int clKakoColIndex = 114;
        // 結果確定日
        private const int kekkaKakuteiDtColIndex = 115;
        // 更新区分(検印)
        private const int koshinKbnKeninIndex = 116;
        // 更新区分(スクリーニング候補)
        private const int koshinKbnScreeningKohoIndex = 117;
        // 更新区分(クロスチェック異常(水質判定表))
        private const int koshinKbnCrossSuishitsuIndex = 118;
        // 更新区分(クロスチェック異常(過去履歴))
        private const int koshinKbnCrossKakoIndex = 119;
        // 更新区分(pH)
        private const int koshinKbnPhIndex = 120;
        // 更新区分(透視度)
        private const int koshinKbnTrIndex = 121;
        // 更新区分(BOD)
        private const int koshinKbnBodIndex = 122;
        // 更新区分(残塩)
        private const int koshinKbnZanenIndex = 123;
        // 更新区分(塩化物イオン)
        private const int koshinKbnClIndex = 124;

        // 更新区分(ATTUBOD)
        private const int koshinKbnAtubodIndex = 125;

        // 更新区分（BOD/透視度）
        private const int koshinKbnBodTrIndex = 126;
        // 更新区分（BOD基準値オーバー）
        private const int koshinKbnBodOverIndex = 127;
        // 更新区分（塩化物イオン確認検査）
        private const int koshinKbnClKakuninIndex = 128;
        // BOD1確認検査種別（BOD/透視度）
        private const int bod1KensaShubetsuBodTrIndex = 129;
        // BOD2確認検査種別（BOD/透視度）
        private const int bod2KensaShubetsuBodTrIndex = 130;
        // 透視度1確認検査種別（BOD/透視度）
        private const int tr1KensaShubetsuBodTrIndex = 131;
        // 透視度2確認検査種別（BOD/透視度）
        private const int tr2KensaShubetsuBodTrIndex = 132;

        // ATUBOD1確認検査種別（BOD/透視度）
        private const int atubod1KensaShubetsuBodTrIndex = 133;
        // ATUBOD2確認検査種別（BOD/透視度）
        private const int atubod2KensaShubetsuBodTrIndex = 134;

        // BOD1確認検査種別（BOD基準値オーバー）
        private const int bod1KensaShubetsuBodOverIndex = 135;
        // BOD2確認検査種別（BOD基準値オーバー）
        private const int bod2KensaShubetsuBodOverIndex = 136;

        // ATUBOD1確認検査種別（BOD基準値オーバー）
        private const int atubod1KensaShubetsuBodOverIndex = 137;
        // ATUBOD2確認検査種別（BOD基準値オーバー）
        private const int atubod2KensaShubetsuBodOverIndex = 138;

        // 塩化物イオン1確認検査種別（塩化物イオン確認検査）
        private const int cl1KensaShubetsuEnkaIonIndex = 139;
        // 塩化物イオン2確認検査種別（塩化物イオン確認検査）
        private const int cl2KensaShubetsuEnkaIonIndex = 140;
        // 検査状況
        private const int kensaJyokyoColIndex = 141;
        // 更新日(検査依頼テーブル)
        private const int iraiUpdateDtColIndex = 142;
        // 更新日(検査結果テーブル)
        private const int kekkaUpdateDtColIndex = 143;
        // 更新日(再採水テーブル)
        private const int saisaisuiUpdateDtColIndex = 144;
        // 更新日(検査台帳ヘッダ)
        private const int headerUpdateDtColIndex = 145;
        // 更新日(検査台帳明細(PH1))
        private const int ph1UpdateDtColIndex = 146;
        // 更新日(検査台帳明細(PH2))
        private const int ph2UpdateDtColIndex = 147;
        // 更新日(検査台帳明細(透視度1))
        private const int tr1UpdateDtColIndex = 148;
        // 更新日(検査台帳明細(透視度2))
        private const int tr2UpdateDtColIndex = 149;
        // 更新日(検査台帳明細(BOD1))
        private const int bod1UpdateDtColIndex = 150;
        // 更新日(検査台帳明細(BOD2))
        private const int bod2UpdateDtColIndex = 151;
        // 更新日(検査台帳明細(残塩1))
        private const int zanen1UpdateDtColIndex = 152;
        // 更新日(検査台帳明細(残塩2))
        private const int zanen2UpdateDtColIndex = 153;
        // 更新日(検査台帳明細(塩化物イオン1))
        private const int cl1UpdateDtColIndex = 154;
        // 更新日(検査台帳明細(塩化物イオン2))
        private const int cl2UpdateDtColIndex = 155;
        // 更新日(検査台帳明細(ATUBOD1))
        private const int atubod1UpdateDtColIndex = 156;
        // 更新日(検査台帳明細(ATUBOD2))
        private const int atubod2UpdateDtColIndex = 157;
        // 20150129 sou End

        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuteiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuteiBtnClickApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region 同一依頼の別検体データ確認
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckBetsuKentai
        /// <summary>
        /// 
        /// </summary>
        /// <output>
        /// BetsuKentai 別検体情報
        /// </output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/02　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private BetsuKentai CheckBetsuKentai(int baseRowCnt, DataGridView dgv)
        {
            string where1 = dgv[kensaIraiHoteiKbnColIndex, baseRowCnt].Value.ToString();
            string where2 = dgv[kensaIraiHokenjoCdColIndex, baseRowCnt].Value.ToString();
            string where3 = dgv[kensaIraiNendoColIndex, baseRowCnt].Value.ToString();
            string where4 = dgv[kensaIraiRenbanColIndex, baseRowCnt].Value.ToString();
            string where5 = dgv[saisaisuiKbnColIndex, baseRowCnt].Value.ToString();

            BetsuKentai bk = new BetsuKentai();
            bk.rowIndex = -1;
            bk.kachoKenin = "0";
            bk.hukukachoKenin = "0";

            int rowCnt = -1;
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                rowCnt++;

                if (rowCnt == baseRowCnt)
                {
                    continue;
                }

                if ((dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString() == where1)
                    && (dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString() == where2)
                    && (dgvr.Cells[kensaIraiNendoColIndex].Value.ToString() == where3)
                    && (dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString() == where4)
                    && (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == (where5 == "1" ? "0" : "1")))
                {
                    bk.rowIndex = rowCnt;
                    bk.kachoKenin = dgvr.Cells[kachoKeninColIndex].Value.ToString();
                    bk.hukukachoKenin = dgvr.Cells[hukukachoKeninColIndex].Value.ToString();
                    break;
                }
            }

            return bk;
        }
        #endregion

        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  宗    　    新規作成
        /// 2015/01/29  宗    　    ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                StartTransaction();

                int rowCnt = -1;
                string[,] updt = new string[input.listDataGridView.RowCount, (int)UpdateDt.Count];
                foreach (DataGridViewRow dgvr in input.listDataGridView.Rows)
                {
                    rowCnt++;

                    #region 更新日退避
                    updt[rowCnt, (int)UpdateDt.iraiUpdateDt] = dgvr.Cells[iraiUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.kekkaUpdateDt] = dgvr.Cells[kekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.saisaisuiUpdateDt] = dgvr.Cells[saisaisuiUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.headerUpdateDt] = dgvr.Cells[headerUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.ph1UpdateDt] = dgvr.Cells[ph1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.ph2UpdateDt] = dgvr.Cells[ph2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tr1UpdateDt] = dgvr.Cells[tr1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tr2UpdateDt] = dgvr.Cells[tr2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bod1UpdateDt] = dgvr.Cells[bod1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bod2UpdateDt] = dgvr.Cells[bod2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.zanen1UpdateDt] = dgvr.Cells[zanen1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.zanen2UpdateDt] = dgvr.Cells[zanen2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.cl1UpdateDt] = dgvr.Cells[cl1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.cl2UpdateDt] = dgvr.Cells[cl2UpdateDtColIndex].Value.ToString();
                    #endregion

                    // 2015.01.06 toyoda Modify Start 検査結果判定に検査依頼のBOD処理性能が必要なため、必ず取得するよう変更
                    // 検索
                    IGetKensaIraiTblByKeyBLInput getKensaIraiInput = new GetKensaIraiTblByKeyBLInput();
                    getKensaIraiInput.KensaIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                    getKensaIraiInput.KensaIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                    getKensaIraiInput.KensaIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                    getKensaIraiInput.KensaIraiRenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                    IGetKensaIraiTblByKeyBLOutput getKensaIraiOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(getKensaIraiInput);
                    // 2015.01.06 toyoda Modify End

                    #region 「検査依頼テーブル」の更新
                    // スクリーニング指示
                    if ((dgvr.Cells[screeningFlgColIndex].Value.ToString() == "0")
                        && (dgvr.Cells[screeningColIndex].Value.ToString() == CheckOn))
                    {
                        #region データ更新１

                        // 楽観チェック
                        string preDateTime = dgvr.Cells[iraiUpdateDtColIndex].Value != null ? dgvr.Cells[iraiUpdateDtColIndex].Value.ToString() : string.Empty;
                        if (preDateTime != getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateDt.ToString())
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }
                        // 編集＆更新
                        IUpdateKensaIraiTblBLInput kensaIraiInput = new UpdateKensaIraiTblBLInput();
                        kensaIraiInput.KensaIraiTblDataTable = getKensaIraiOutput.KensaIraiTblDataTable;

                        // スクリーニング区分
                        if((dgvr.Cells[screeningKohoColIndex].Value.ToString() == "1")
                            || (dgvr.Cells[screeningKohoColIndex].Value.ToString() == "2"))
                        {
                            if (dgvr.Cells[followKohoColIndex].Value.ToString() == "0")
                            {
                                kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiScreeningKbn = "1";
                            }
                            else if (dgvr.Cells[followKohoColIndex].Value.ToString() == "1")
                            {
                                kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiScreeningKbn = "3";
                            }
                        }
                        else if(dgvr.Cells[screeningKohoColIndex].Value.ToString() == "0")
                        {
                            if (dgvr.Cells[followKohoColIndex].Value.ToString() == "1")
                            {
                                kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiScreeningKbn = "2";
                            }
                        }
                        // ステータス区分
                        kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "00";

                        // 更新日時
                        kensaIraiInput.KensaIraiTblDataTable[0].UpdateDt = input.UpdateDt;
                        // 更新者
                        kensaIraiInput.KensaIraiTblDataTable[0].UpdateUser = input.UpdateUser;
                        // 更新端末
                        kensaIraiInput.KensaIraiTblDataTable[0].UpdateTarm = input.UpdateTarm;

                        new UpdateKensaIraiTblBusinessLogic().Execute(kensaIraiInput);

                        // 更新日の更新
                        updt[rowCnt, (int)UpdateDt.iraiUpdateDt] = input.UpdateDt.ToString();
                        #endregion
                    }

                    // 検印済みの場合
                    if ((dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hukukachoKeninColIndex].Value.ToString() == CheckOn)
                        && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                    {
                        // スクリーニング区分：通常
                        //if (dgvr.Cells[screeningColIndex].Value.ToString() == "0")
                        if (dgvr.Cells[screeningColIndex].Value.ToString() == CheckOff)
                        {
                            if (dgvr.Cells[kensaKbnColIndex].Value.ToString() == "2")
                            {
                                #region データ更新２－１

                                // 検索
                                IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
                                blInput.KensaIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                                blInput.KensaIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                                blInput.KensaIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                                blInput.KensaIraiRenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                                IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);
                                // 楽観チェック
                                string preDateTime = dgvr.Cells[iraiUpdateDtColIndex].Value != null ? dgvr.Cells[iraiUpdateDtColIndex].Value.ToString() : string.Empty;
                                if (preDateTime != blOutput.KensaIraiTblDataTable[0].UpdateDt.ToString())
                                {
                                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                                }
                                // 編集＆更新
                                IUpdateKensaIraiTblBLInput kensaIraiInput = new UpdateKensaIraiTblBLInput();
                                kensaIraiInput.KensaIraiTblDataTable = blOutput.KensaIraiTblDataTable;

                                // ステータス区分
                                kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "70";
                                // 水質検印区分
                                kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiSuishitsuKeninKbn = "1";

                                // 更新日時
                                kensaIraiInput.KensaIraiTblDataTable[0].UpdateDt = input.UpdateDt;
                                // 更新者
                                kensaIraiInput.KensaIraiTblDataTable[0].UpdateUser = input.UpdateUser;
                                // 更新端末
                                kensaIraiInput.KensaIraiTblDataTable[0].UpdateTarm = input.UpdateTarm;

                                new UpdateKensaIraiTblBusinessLogic().Execute(kensaIraiInput);

                                // 更新日の更新
                                updt[rowCnt, (int)UpdateDt.iraiUpdateDt] = input.UpdateDt.ToString(); ;
                                #endregion

                                // 20150124 sou Start 
                                // 所見自動挿入
                                ShokenUtility.ShokenAutoAdd(
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiHoteiKbn,
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiHokenjoCd,
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiNendo,
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiRenban
                                    );
                                // 20150124 sou End
                            }
                            else if (dgvr.Cells[kensaKbnColIndex].Value.ToString() == "3")
                            {
                                #region データ更新２－１

                                // 検索
                                IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
                                blInput.KensaIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                                blInput.KensaIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                                blInput.KensaIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                                blInput.KensaIraiRenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                                IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);
                                // 楽観チェック
                                string preDateTime = dgvr.Cells[iraiUpdateDtColIndex].Value != null ? dgvr.Cells[iraiUpdateDtColIndex].Value.ToString() : string.Empty;
                                if (preDateTime != blOutput.KensaIraiTblDataTable[0].UpdateDt.ToString())
                                {
                                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                                }
                                // 編集＆更新
                                IUpdateKensaIraiTblBLInput kensaIraiInput = new UpdateKensaIraiTblBLInput();
                                kensaIraiInput.KensaIraiTblDataTable = blOutput.KensaIraiTblDataTable;

                                // ステータス区分
                                kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "60";
                                // 水質検印区分
                                kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiSuishitsuKeninKbn = "1";

                                // 更新日時
                                kensaIraiInput.KensaIraiTblDataTable[0].UpdateDt = input.UpdateDt;
                                // 更新者
                                kensaIraiInput.KensaIraiTblDataTable[0].UpdateUser = input.UpdateUser;
                                // 更新端末
                                kensaIraiInput.KensaIraiTblDataTable[0].UpdateTarm = input.UpdateTarm;

                                new UpdateKensaIraiTblBusinessLogic().Execute(kensaIraiInput);

                                // 更新日の更新
                                updt[rowCnt, (int)UpdateDt.iraiUpdateDt] = input.UpdateDt.ToString(); ;
                                #endregion
                            }
                        }
                        // スクリーニング区分：フォロー
                        //else if (dgvr.Cells[screeningColIndex].Value.ToString() == "2")
                        else if ((dgvr.Cells[screeningColIndex].Value.ToString() == CheckOn)
                            && ((dgvr.Cells[screeningKohoColIndex].Value.ToString() == "0") || (dgvr.Cells[screeningKohoColIndex].Value.ToString() == "3"))
                            && (dgvr.Cells[followKohoColIndex].Value.ToString() == "1"))
                        {
                            #region データ更新２－２

                            // 検索
                            IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
                            blInput.KensaIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                            blInput.KensaIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                            blInput.KensaIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                            blInput.KensaIraiRenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                            IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[iraiUpdateDtColIndex].Value != null ? dgvr.Cells[iraiUpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaIraiTblDataTable[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaIraiTblBLInput kensaIraiInput = new UpdateKensaIraiTblBLInput();
                            kensaIraiInput.KensaIraiTblDataTable = blOutput.KensaIraiTblDataTable;

                            // 水質検印区分
                            kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiSuishitsuKeninKbn = "1";

                            // 更新日時
                            kensaIraiInput.KensaIraiTblDataTable[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaIraiInput.KensaIraiTblDataTable[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaIraiInput.KensaIraiTblDataTable[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaIraiTblBusinessLogic().Execute(kensaIraiInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.iraiUpdateDt] = input.UpdateDt.ToString(); ;
                            #endregion
                        }
                        // スクリーニング区分：スクリーニングorスクリーニング＋フォロー
                        //else if ((dgvr.Cells[screeningColIndex].Value.ToString() == "1")
                        //    || (dgvr.Cells[screeningColIndex].Value.ToString() == "3"))
                        else if ((dgvr.Cells[screeningColIndex].Value.ToString() == CheckOn)
                            && ((dgvr.Cells[screeningKohoColIndex].Value.ToString() == "1") || (dgvr.Cells[screeningKohoColIndex].Value.ToString() == "2")))
                        {
                            // 一覧の中に対となる初回分、又はスクリーニング分が含まれているかどうか確認する
                            BetsuKentai bk = CheckBetsuKentai(rowCnt, input.listDataGridView);

                            // 含まれている場合
                            if (bk.rowIndex > -1)
                            {
                                // 検印済み(初回分とスクリーニング分の両方が検印済み)の場合
                                if ((bk.kachoKenin == "1") || (bk.hukukachoKenin == "1"))
                                {
                                    #region データ更新２－１

                                    // 検索
                                    IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
                                    blInput.KensaIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                                    blInput.KensaIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                                    blInput.KensaIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                                    blInput.KensaIraiRenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                                    IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);
                                    // 楽観チェック
                                    string preDateTime = dgvr.Cells[iraiUpdateDtColIndex].Value != null ? dgvr.Cells[iraiUpdateDtColIndex].Value.ToString() : string.Empty;
                                    if (preDateTime != blOutput.KensaIraiTblDataTable[0].UpdateDt.ToString())
                                    {
                                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                                    }
                                    // 編集＆更新
                                    IUpdateKensaIraiTblBLInput kensaIraiInput = new UpdateKensaIraiTblBLInput();
                                    kensaIraiInput.KensaIraiTblDataTable = blOutput.KensaIraiTblDataTable;

                                    // ステータス区分
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "60";
                                    // 水質検印区分
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiSuishitsuKeninKbn = "1";

                                    // 更新日時
                                    kensaIraiInput.KensaIraiTblDataTable[0].UpdateDt = input.UpdateDt;
                                    // 更新者
                                    kensaIraiInput.KensaIraiTblDataTable[0].UpdateUser = input.UpdateUser;
                                    // 更新端末
                                    kensaIraiInput.KensaIraiTblDataTable[0].UpdateTarm = input.UpdateTarm;

                                    new UpdateKensaIraiTblBusinessLogic().Execute(kensaIraiInput);

                                    // 更新日の更新
                                    updt[rowCnt, (int)UpdateDt.iraiUpdateDt] = input.UpdateDt.ToString(); ;
                                    #endregion
                                }
                            }
                            // 含まれていない場合
                            else
                            {
                                // 検印済み(初回分とスクリーニング分の両方が検印済み)の場合
                                if ((dgvr.Cells[kachoKeninEtcColIndex].Value.ToString() == "1")
                                    || (dgvr.Cells[hukukachoKeninEtcColIndex].Value.ToString() == "1"))
                                {
                                    #region データ更新２－１

                                    // 検索
                                    IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
                                    blInput.KensaIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                                    blInput.KensaIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                                    blInput.KensaIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                                    blInput.KensaIraiRenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                                    IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);
                                    // 楽観チェック
                                    string preDateTime = dgvr.Cells[iraiUpdateDtColIndex].Value != null ? dgvr.Cells[iraiUpdateDtColIndex].Value.ToString() : string.Empty;
                                    if (preDateTime != blOutput.KensaIraiTblDataTable[0].UpdateDt.ToString())
                                    {
                                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                                    }
                                    // 編集＆更新
                                    IUpdateKensaIraiTblBLInput kensaIraiInput = new UpdateKensaIraiTblBLInput();
                                    kensaIraiInput.KensaIraiTblDataTable = blOutput.KensaIraiTblDataTable;

                                    // ステータス区分
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "60";
                                    // 水質検印区分
                                    kensaIraiInput.KensaIraiTblDataTable[0].KensaIraiSuishitsuKeninKbn = "1";

                                    // 更新日時
                                    kensaIraiInput.KensaIraiTblDataTable[0].UpdateDt = input.UpdateDt;
                                    // 更新者
                                    kensaIraiInput.KensaIraiTblDataTable[0].UpdateUser = input.UpdateUser;
                                    // 更新端末
                                    kensaIraiInput.KensaIraiTblDataTable[0].UpdateTarm = input.UpdateTarm;

                                    new UpdateKensaIraiTblBusinessLogic().Execute(kensaIraiInput);

                                    // 更新日の更新
                                    updt[rowCnt, (int)UpdateDt.iraiUpdateDt] = input.UpdateDt.ToString(); ;
                                    #endregion
                                }
                            }
                        }
                    }
                    #endregion

                    #region「検査台帳（11条）ヘッダテーブル」の更新
                    if ((dgvr.Cells[koshinKbnScreeningKohoIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnCrossSuishitsuIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnCrossKakoIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                    {
                        #region データ更新３

                        // 検索
                        IGetKensaDaicho11joHdrTblByKeyBLInput blInput = new GetKensaDaicho11joHdrTblByKeyBLInput();
                        blInput.KensaKbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                        blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                        blInput.ShishoCd = dgvr.Cells[shishoCdColIndex].Value.ToString();
                        blInput.SuishitsuKensaIraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                        IGetKensaDaicho11joHdrTblByKeyBLOutput blOutput = new GetKensaDaicho11joHdrTblByKeyBusinessLogic().Execute(blInput);
                        // 楽観チェック
                        string preDateTime = dgvr.Cells[headerUpdateDtColIndex].Value != null ? dgvr.Cells[headerUpdateDtColIndex].Value.ToString() : string.Empty;
                        if (preDateTime != blOutput.KensaDaicho11joHdrDT[0].UpdateDt.ToString())
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }
                        // 編集＆更新
                        IUpdateKensaDaicho11joHdrTblBLInput kensaDaicho11joHdrTblInput = new UpdateKensaDaicho11joHdrTblBLInput();
                        kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable = blOutput.KensaDaicho11joHdrDT;

                        // スクリーニング候補
                        if (dgvr.Cells[koshinKbnScreeningKohoIndex].Value.ToString() == "1")
                        {
                            kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].ScreeningKoho = dgvr.Cells[screeningKohoColIndex].Value.ToString();
                        }
                        // クロスチェック異常（水質判定表）
                        if (dgvr.Cells[koshinKbnCrossSuishitsuIndex].Value.ToString() == "1")
                        {
                            kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].CrossCheckSuishitsu = dgvr.Cells[crossCheckSuishitsuColIndex].Value.ToString();
                        }
                        // クロスチェック異常（過去履歴）
                        if (dgvr.Cells[koshinKbnCrossKakoIndex].Value.ToString() == "1")
                        {
                            kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].CrossCheckKako = dgvr.Cells[crossCheckKakoColIndex].Value.ToString();
                        }
                        // 検印区分
                        if (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")
                        {
                            // 課長検印区分
                            if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "0")
                            {
                                if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].KachoKeninKbn = "1";
                                }
                                else if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOff)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].KachoKeninKbn = "0";
                                }
                            }
                            else if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "1")
                            {
                                kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].KachoKeninKbn = dgvr.Cells[kachoKeninEtcColIndex].Value.ToString();
                            }
                            // 課長検印区分(再採水)
                            if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "0")
                            {
                                kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].KachoKeninKbnScreening = dgvr.Cells[kachoKeninEtcColIndex].Value.ToString();
                            }
                            else if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "1")
                            {
                                if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].KachoKeninKbnScreening = "1";
                                }
                                else if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOff)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].KachoKeninKbnScreening = "0";
                                }
                            }
                            // 副課長検印区分
                            if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "0")
                            {
                                if (dgvr.Cells[hukukachoKeninColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].HukuKachoKeninKbn = "1";
                                }
                                else if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOff)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].HukuKachoKeninKbn = "0";
                                }
                            }
                            else if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "1")
                            {
                                kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].HukuKachoKeninKbn = dgvr.Cells[hukukachoKeninEtcColIndex].Value.ToString();
                            }
                            // 副課長検印区分(再採水)
                            if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "0")
                            {
                                kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].HukuKachoKeninKbnScreening = dgvr.Cells[hukukachoKeninEtcColIndex].Value.ToString();
                            }
                            else if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "1")
                            {
                                if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].HukuKachoKeninKbnScreening = "1";
                                }
                                else if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOff)
                                {
                                    kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].HukuKachoKeninKbnScreening = "0";
                                }
                            }
                        }

                        // 更新日時
                        kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].UpdateDt = input.UpdateDt;
                        // 更新者
                        kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].UpdateUser = input.UpdateUser;
                        // 更新端末
                        kensaDaicho11joHdrTblInput.KensaDaicho11joHdrTblDataTable[0].UpdateTarm = input.UpdateTarm;

                        new UpdateKensaDaicho11joHdrTblBusinessLogic().Execute(kensaDaicho11joHdrTblInput);

                        // 更新日の更新
                        updt[rowCnt, (int)UpdateDt.headerUpdateDt] = input.UpdateDt.ToString(); ;
                        #endregion
                    }
                    #endregion

                    #region「検査台帳明細テーブル」の更新
                    if ((dgvr.Cells[koshinKbnPhIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoPhIndex].Value.ToString() == "1"))
                    {
                        // pHの変更結果を反映する
                        #region データ更新４の初回分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuPh1ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "001");
                            blInput.SaikensaKbn = "0";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[ph1UpdateDtColIndex].Value != null ? dgvr.Cells[ph1UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaPh1ColIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[ph1KensaShubetsuKakoIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[ph1ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[ph1KekkaCdColIndex].Value.ToString();
                            // 温度数
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaOndo = decimal.Parse(dgvr.Cells[ondo1ColIndex].Value.ToString());
                            // 採用区分
                            if(dgvr.Cells[saiyotiPh1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }
                            if (dgvr.Cells[saiyotiPh2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.ph1UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion

                        #region データ更新４の再検査分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuPh2ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "001");
                            blInput.SaikensaKbn = "1";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[ph2UpdateDtColIndex].Value != null ? dgvr.Cells[ph2UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaPh2ColIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[ph2KensaShubetsuKakoIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[ph2ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[ph2KekkaCdColIndex].Value.ToString();
                            // 温度数
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaOndo = decimal.Parse(dgvr.Cells[ondo2ColIndex].Value.ToString());
                            // 採用区分
                            if (dgvr.Cells[saiyotiPh1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }
                            if (dgvr.Cells[saiyotiPh2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.ph2UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion
                    }

                    if ((dgvr.Cells[koshinKbnTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodTrIndex].Value.ToString() == "1"))
                    {
                        // 透視度の変更結果を反映する
                        #region データ更新５の初回分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuTr1ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "002");
                            blInput.SaikensaKbn = "0";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[tr1UpdateDtColIndex].Value != null ? dgvr.Cells[tr1UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaTr1ColIndex].Value.ToString();
                            // 確認検査種別（BOD/透視度）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[tr1KensaShubetsuBodTrIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[tr1KensaShubetsuKakoIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[tr1ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[tr1KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiTr1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }
                            if (dgvr.Cells[saiyotiTr2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.tr1UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion

                        #region データ更新５の再検査分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuTr2ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "002");
                            blInput.SaikensaKbn = "1";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[tr2UpdateDtColIndex].Value != null ? dgvr.Cells[tr2UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaTr2ColIndex].Value.ToString();
                            // 確認検査種別（BOD/透視度）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[tr2KensaShubetsuBodTrIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[tr2KensaShubetsuKakoIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[tr2ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[tr2KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiTr1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }
                            if (dgvr.Cells[saiyotiTr2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.tr2UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion
                    }

                    if ((dgvr.Cells[koshinKbnBodIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoBodIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodOverIndex].Value.ToString() == "1"))
                    {
                        // BODの変更結果を反映する
                        #region データ更新６の初回分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuBod1ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "003");
                            blInput.SaikensaKbn = "0";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[bod1UpdateDtColIndex].Value != null ? dgvr.Cells[bod1UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaBod1ColIndex].Value.ToString();
                            // 確認検査種別（BOD/透視度）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[bod1KensaShubetsuBodTrIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[bod1KensaShubetsuKakoIndex].Value.ToString();
                            // 確認検査種別（BOD基準値オーバー）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodOver = dgvr.Cells[bod1KensaShubetsuBodOverIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[bod1ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[bod1KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiBod1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }
                            if (dgvr.Cells[saiyotiBod2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.bod1UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion

                        #region データ更新６の再検査分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuBod2ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "003");
                            blInput.SaikensaKbn = "1";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[bod2UpdateDtColIndex].Value != null ? dgvr.Cells[bod2UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaBod2ColIndex].Value.ToString();
                            // 確認検査種別（BOD/透視度）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[bod2KensaShubetsuBodTrIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[bod2KensaShubetsuKakoIndex].Value.ToString();
                            // 確認検査種別（BOD基準値オーバー）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodOver = dgvr.Cells[bod2KensaShubetsuBodOverIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[bod2ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[bod2KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiBod1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }
                            if (dgvr.Cells[saiyotiBod2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.bod2UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion
                    }

                    if ((dgvr.Cells[koshinKbnZanenIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoZanenIndex].Value.ToString() == "1"))
                    {
                        // 残塩の変更結果を反映する
                        #region データ更新７の初回分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuZanen1ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "004");
                            blInput.SaikensaKbn = "0";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[zanen1UpdateDtColIndex].Value != null ? dgvr.Cells[zanen1UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaZanen1ColIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[zanen1KensaShubetsuKakoIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[zanen1ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[zanen1KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiZanen1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }
                            if (dgvr.Cells[saiyotiZanen2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.zanen1UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion

                        #region データ更新７の再検査分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuZanen2ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "004");
                            blInput.SaikensaKbn = "1";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[zanen2UpdateDtColIndex].Value != null ? dgvr.Cells[zanen2UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaZanen2ColIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[zanen2KensaShubetsuKakoIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[zanen2ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[zanen2KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiZanen1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }
                            if (dgvr.Cells[saiyotiZanen2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.zanen2UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion
                    }

                    if ((dgvr.Cells[koshinKbnClIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoClIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnClKakuninIndex].Value.ToString() == "1"))
                    {
                        // 塩化物イオンの変更結果を反映する
                        #region データ更新８の初回分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuCl1ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "005");
                            blInput.SaikensaKbn = "0";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[cl1UpdateDtColIndex].Value != null ? dgvr.Cells[cl1UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaCl1ColIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[cl1KensaShubetsuKakoIndex].Value.ToString();
                            // 確認検査種別（塩化物イオン確認検査）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuEnkaIon = dgvr.Cells[cl1KensaShubetsuEnkaIonIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[cl1ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[cl1KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiCl1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }
                            if (dgvr.Cells[saiyotiCl2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.cl1UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion

                        #region データ更新８の再検査分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuCl2ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("048", "005");
                            blInput.SaikensaKbn = "1";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[cl2UpdateDtColIndex].Value != null ? dgvr.Cells[cl2UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaCl2ColIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[cl2KensaShubetsuKakoIndex].Value.ToString();
                            // 確認検査種別（塩化物イオン確認検査）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuEnkaIon = dgvr.Cells[cl2KensaShubetsuEnkaIonIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[cl2ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[cl2KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiCl1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }
                            if (dgvr.Cells[saiyotiCl2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.cl2UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion
                    }

                    // 20150129 sou Start
                    if ((dgvr.Cells[koshinKbnAtubodIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoAtubodIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodOverIndex].Value.ToString() == "1"))
                    {
                        // ATUBODの変更結果を反映する
                        #region データ更新６の初回分(ATUBOD)
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuAtubod1ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("078", "003");
                            blInput.SaikensaKbn = "0";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[atubod1UpdateDtColIndex].Value != null ? dgvr.Cells[atubod1UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaAtubod1ColIndex].Value.ToString();
                            // 確認検査種別（BOD/透視度）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[atubod1KensaShubetsuBodTrIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[atubod1KensaShubetsuKakoIndex].Value.ToString();
                            // 確認検査種別（BOD基準値オーバー）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodOver = dgvr.Cells[atubod1KensaShubetsuBodOverIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[atubod1ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[atubod1KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiAtubod1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }
                            if (dgvr.Cells[saiyotiAtubod2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.bod1UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion

                        #region データ更新６の再検査分(ATUBOD)
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuAtubod2ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = dgvr.Cells[kensaKbnColIndex].Value.ToString();
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdColIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue("078", "003");
                            blInput.SaikensaKbn = "1";
                            IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[atubod2UpdateDtColIndex].Value != null ? dgvr.Cells[atubod2UpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                            // 確認検査種別
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[kakuninKensaAtubod2ColIndex].Value.ToString();
                            // 確認検査種別（BOD/透視度）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[atubod2KensaShubetsuBodTrIndex].Value.ToString();
                            // 確認検査種別（過去との比較）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[atubod2KensaShubetsuKakoIndex].Value.ToString();
                            // 確認検査種別（BOD基準値オーバー）
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodOver = dgvr.Cells[atubod2KensaShubetsuBodOverIndex].Value.ToString();
                            // 結果値
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[atubod2ColIndex].Value.ToString());
                            // 結果値２
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = dgvr.Cells[atubod2KekkaCdColIndex].Value.ToString();
                            // 採用区分
                            if (dgvr.Cells[saiyotiAtubod1ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                            }
                            if (dgvr.Cells[saiyotiAtubod2ColIndex].Value.ToString() == CheckOn)
                            {
                                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                            }

                            // 更新日時
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.bod2UpdateDt] = input.UpdateDt.ToString(); ;
                        }
                        #endregion
                    }
                    // 20150129 sou End
                    #endregion

                    #region「検査結果テーブル」又は「再採水テーブル」の更新
                    if ((dgvr.Cells[koshinKbnPhIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnZanenIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnClIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnAtubodIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                    {

                        if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "0")
                        {
                            // 各項目の変更結果を反映する
                            #region データ更新９

                            // 検索
                            IGetKensaKekkaTblByKeyBLInput blInput = new GetKensaKekkaTblByKeyBLInput();
                            blInput.KensaKekkaIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                            blInput.KensaKekkaIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                            blInput.KensaKekkaIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                            blInput.KensaKekkaIraiRenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                            IGetKensaKekkaTblByKeyBLOutput blOutput = new GetKensaKekkaTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[kekkaUpdateDtColIndex].Value != null ? dgvr.Cells[kekkaUpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.KensaKekkaTblDataTable[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateKensaKekkaTblBLInput kensaKekkaInput = new UpdateKensaKekkaTblBLInput();
                            kensaKekkaInput.KensaKekkaTblDataTable = blOutput.KensaKekkaTblDataTable;

                            // ph
                            if ((dgvr.Cells[koshinKbnPhIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiPh1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodo = double.Parse(dgvr.Cells[ph1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.PH,
                                                dgvr.Cells[ph1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaOndo = decimal.Parse(dgvr.Cells[ondo1ColIndex].Value.ToString());
                                }
                                else if (dgvr.Cells[saiyotiPh2ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodo = double.Parse(dgvr.Cells[ph2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.PH,
                                                dgvr.Cells[ph2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaOndo = decimal.Parse(dgvr.Cells[ondo2ColIndex].Value.ToString());
                                }
                            }
                            // 透視度
                            if ((dgvr.Cells[koshinKbnTrIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiTr1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshido = double.Parse(dgvr.Cells[tr1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshidoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                                                dgvr.Cells[tr1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshido2 = dgvr.Cells[tr1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiTr2ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshido = double.Parse(dgvr.Cells[tr2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshidoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                                                dgvr.Cells[tr2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshido2 = dgvr.Cells[tr2KekkaCdColIndex].Value.ToString();
                                }
                            }
                            // BOD
                            if ((dgvr.Cells[koshinKbnBodIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiBod1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaBOD = double.Parse(dgvr.Cells[bod1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaBODHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.BOD,
                                                dgvr.Cells[bod1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaIraiBOD2 = dgvr.Cells[bod1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiBod2ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaBOD = double.Parse(dgvr.Cells[bod2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaBODHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.BOD,
                                                dgvr.Cells[bod2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaIraiBOD2 = dgvr.Cells[bod2KekkaCdColIndex].Value.ToString();
                                }
                            }
                            // 残塩
                            if ((dgvr.Cells[koshinKbnZanenIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiZanen1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodo = double.Parse(dgvr.Cells[zanen1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso,
                                                dgvr.Cells[zanen1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End
                                }
                                else if (dgvr.Cells[saiyotiZanen1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodo = double.Parse(dgvr.Cells[zanen2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso,
                                                dgvr.Cells[zanen2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End
                                }
                            }
                            // 塩化物イオン
                            if ((dgvr.Cells[koshinKbnClIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiCl1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodo = decimal.Parse(dgvr.Cells[cl1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon,
                                                dgvr.Cells[cl1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaIraiEnsoIonNodo2 = dgvr.Cells[cl1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiCl1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodo = decimal.Parse(dgvr.Cells[cl2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon,
                                                dgvr.Cells[cl2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaIraiEnsoIonNodo2 = dgvr.Cells[cl2KekkaCdColIndex].Value.ToString();
                                }
                            }
                            // 20150129 sou Start
                            // ATUBOD
                            if ((dgvr.Cells[koshinKbnAtubodIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiAtubod1ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaATUBOD = double.Parse(dgvr.Cells[atubod1ColIndex].Value.ToString());
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaATUBOD2 = dgvr.Cells[atubod1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiAtubod2ColIndex].Value.ToString() == CheckOn)
                                {
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaATUBOD = double.Parse(dgvr.Cells[atubod2ColIndex].Value.ToString());
                                    kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaATUBOD2 = dgvr.Cells[atubod2KekkaCdColIndex].Value.ToString();
                                }
                            }
                            // 20150129 sou End

                            // 20150124 sou Start
                            #region to be removed
                            //// 2015.01.06 toyoda Add Start
                            //int suisoIonNodoHantei = (string.IsNullOrEmpty(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodoHantei)
                            //                                        || kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodoHantei == "4")
                            //                                    ? 0
                            //                                    : int.Parse(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodoHantei);

                            //int toshidoHantei = (string.IsNullOrEmpty(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshidoHantei)
                            //                                        || kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshidoHantei == "4")
                            //                                    ? 0
                            //                                    : int.Parse(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaToshidoHantei);

                            //int bodHantei = (string.IsNullOrEmpty(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaBODHantei)
                            //                                        || kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaBODHantei == "4")
                            //                                    ? 0
                            //                                    : int.Parse(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaBODHantei);

                            //int zanryuEnsoNodoHantei = (string.IsNullOrEmpty(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodoHantei)
                            //                                        || kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodoHantei == "4")
                            //                                    ? 0
                            //                                    : int.Parse(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodoHantei);

                            //int ensoIonNodoHantei = (string.IsNullOrEmpty(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodoHantei)
                            //                                        || kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodoHantei == "4")
                            //                                    ? 0
                            //                                    : int.Parse(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodoHantei);
                            //// 検査結果判定
                            //kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaHantei = Math.Max(suisoIonNodoHantei,
                            //                                                                Math.Max(toshidoHantei,
                            //                                                                    Math.Max(bodHantei,
                            //                                                                        Math.Max(zanryuEnsoNodoHantei, ensoIonNodoHantei)))).ToString();
                            //// 2015.01.06 toyoda Add End
                            #endregion
                            // 所見結果取得
                            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaDT =
                                KensaHanteiUtility.GetShokenKekka(
                                    dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString(),
                                    dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString(),
                                    dgvr.Cells[kensaIraiNendoColIndex].Value.ToString(),
                                    dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString());
                            // 適正判定
                            string tekiseiHantei = Utility.KensaHanteiUtility.KensaTekiseiHantei(
                                getKensaIraiOutput.KensaIraiTblDataTable, blOutput.KensaKekkaTblDataTable, shokenKekkaDT);
                            // 既存の判定結果よりも大きい場合にのみ更新(3:不適正＞2:おおむね適正＞1:適正)
                            if (string.Compare(kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaHantei, tekiseiHantei) < 0)
                            {
                                kensaKekkaInput.KensaKekkaTblDataTable[0].KensaKekkaHantei = tekiseiHantei;
                            }
                            // 20150124 sou End

                            // 更新日時
                            kensaKekkaInput.KensaKekkaTblDataTable[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            kensaKekkaInput.KensaKekkaTblDataTable[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            kensaKekkaInput.KensaKekkaTblDataTable[0].UpdateTarm = input.UpdateTarm;

                            new UpdateKensaKekkaTblBusinessLogic().Execute(kensaKekkaInput);


                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.kekkaUpdateDt] = input.UpdateDt.ToString();
                            #endregion
                        }
                        else if (dgvr.Cells[saisaisuiKbnColIndex].Value.ToString() == "1")
                        {
                            // 各項目の変更結果を反映する
                            #region データ更新１０

                            // 検索
                            IGetSaiSaisuiTblByKeyBLInput blInput = new GetSaiSaisuiTblByKeyBLInput();
                            blInput.SaiSaisuiIraiHoteiKbn = dgvr.Cells[kensaIraiHoteiKbnColIndex].Value.ToString();
                            blInput.SaiSaisuiIraiHokenjoCd = dgvr.Cells[kensaIraiHokenjoCdColIndex].Value.ToString();
                            blInput.SaiSaisuiIraiNendo = dgvr.Cells[kensaIraiNendoColIndex].Value.ToString();
                            blInput.SaiSaisuiIraiRrenban = dgvr.Cells[kensaIraiRenbanColIndex].Value.ToString();
                            IGetSaiSaisuiTblByKeyBLOutput blOutput = new GetSaiSaisuiTblByKeyBusinessLogic().Execute(blInput);
                            // 楽観チェック
                            string preDateTime = dgvr.Cells[saisaisuiUpdateDtColIndex].Value != null ? dgvr.Cells[saisaisuiUpdateDtColIndex].Value.ToString() : string.Empty;
                            if (preDateTime != blOutput.SaiSaisuiTblDataTable[0].UpdateDt.ToString())
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                            // 編集＆更新
                            IUpdateSaiSaisuiTblBLInput saisaisuiInput = new UpdateSaiSaisuiTblBLInput();
                            saisaisuiInput.SaiSaisuiTblDataTable = blOutput.SaiSaisuiTblDataTable;

                            // ph
                            if ((dgvr.Cells[koshinKbnPhIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiPh1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodo = double.Parse(dgvr.Cells[ph1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.PH,
                                                dgvr.Cells[ph1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiOndo = decimal.Parse(dgvr.Cells[ondo1ColIndex].Value.ToString());
                                }
                                else if (dgvr.Cells[saiyotiPh2ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodo = double.Parse(dgvr.Cells[ph2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.PH,
                                                dgvr.Cells[ph2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiOndo = decimal.Parse(dgvr.Cells[ondo1ColIndex].Value.ToString());
                                }
                            }
                            // 透視度
                            if ((dgvr.Cells[koshinKbnTrIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiTr1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido = double.Parse(dgvr.Cells[tr1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiToshidoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                                                dgvr.Cells[tr1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido2 = dgvr.Cells[tr1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiTr2ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido = double.Parse(dgvr.Cells[tr2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiToshidoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                                                dgvr.Cells[tr2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido2 = dgvr.Cells[tr2KekkaCdColIndex].Value.ToString();
                                }
                            }
                            // BOD
                            if ((dgvr.Cells[koshinKbnBodIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiBod1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD = double.Parse(dgvr.Cells[bod1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiBODHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.BOD,
                                                dgvr.Cells[bod1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD2 = dgvr.Cells[bod1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiBod2ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD = double.Parse(dgvr.Cells[bod2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiBODHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.BOD,
                                                dgvr.Cells[bod2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD2 = dgvr.Cells[bod2KekkaCdColIndex].Value.ToString();
                                }
                            }
                            // 残塩
                            if ((dgvr.Cells[koshinKbnZanenIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiZanen1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodo = double.Parse(dgvr.Cells[zanen1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso,
                                                dgvr.Cells[zanen1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End
                                }
                                else if (dgvr.Cells[saiyotiZanen1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodo = double.Parse(dgvr.Cells[zanen2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso,
                                                dgvr.Cells[zanen2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End
                                }
                            }
                            // 塩化物イオン
                            if ((dgvr.Cells[koshinKbnClIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiCl1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo = decimal.Parse(dgvr.Cells[cl1ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon,
                                                dgvr.Cells[cl1ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo2 = dgvr.Cells[cl1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiCl1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo = decimal.Parse(dgvr.Cells[cl2ColIndex].Value.ToString());

                                    // 2015.01.06 toyoda Add Start
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodoHantei
                                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiShorihoshikiKbn,
                                                getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiBODShoriSeino,
                                                SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon,
                                                dgvr.Cells[cl2ColIndex].Value.ToString()).ToString();
                                    // 2015.01.06 toyoda Add End

                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo2 = dgvr.Cells[cl2KekkaCdColIndex].Value.ToString();
                                }
                            }

                            // 20150129 sou Start
                            // ATUBOD
                            if ((dgvr.Cells[koshinKbnAtubodIndex].Value.ToString() == "1")
                                || (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1"))
                            {
                                if (dgvr.Cells[saiyotiAtubod1ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiATUBOD = double.Parse(dgvr.Cells[atubod1ColIndex].Value.ToString());
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiATUBOD2 = dgvr.Cells[atubod1KekkaCdColIndex].Value.ToString();
                                }
                                else if (dgvr.Cells[saiyotiAtubod2ColIndex].Value.ToString() == CheckOn)
                                {
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiATUBOD = double.Parse(dgvr.Cells[atubod2ColIndex].Value.ToString());
                                    saisaisuiInput.SaiSaisuiTblDataTable[0].SaiSaisuiATUBOD2 = dgvr.Cells[atubod2KekkaCdColIndex].Value.ToString();
                                }
                            }
                            // 20150129 sou End

                            // 更新日時
                            saisaisuiInput.SaiSaisuiTblDataTable[0].UpdateDt = input.UpdateDt;
                            // 更新者
                            saisaisuiInput.SaiSaisuiTblDataTable[0].UpdateUser = input.UpdateUser;
                            // 更新端末
                            saisaisuiInput.SaiSaisuiTblDataTable[0].UpdateTarm = input.UpdateTarm;

                            new UpdateSaiSaisuiTblBusinessLogic().Execute(saisaisuiInput);

                            // 更新日の更新
                            updt[rowCnt, (int)UpdateDt.saisaisuiUpdateDt] = input.UpdateDt.ToString();
                            #endregion
                        }
                    }
                    #endregion

                }

                CompleteTransaction();

                // 更新日の更新
                rowCnt = -1;
                foreach (DataGridViewRow dgvr in input.listDataGridView.Rows)
                {
                    rowCnt++;
                    dgvr.Cells[iraiUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.iraiUpdateDt];
                    dgvr.Cells[kekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.kekkaUpdateDt];
                    dgvr.Cells[saisaisuiUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.saisaisuiUpdateDt];
                    dgvr.Cells[headerUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.headerUpdateDt];
                    dgvr.Cells[ph1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.ph1UpdateDt];
                    dgvr.Cells[ph2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.ph2UpdateDt];
                    dgvr.Cells[tr1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tr1UpdateDt];
                    dgvr.Cells[tr2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tr2UpdateDt];
                    dgvr.Cells[bod1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bod1UpdateDt];
                    dgvr.Cells[bod2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bod2UpdateDt];
                    dgvr.Cells[zanen1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.zanen1UpdateDt];
                    dgvr.Cells[zanen2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.zanen2UpdateDt];
                    dgvr.Cells[cl1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.cl1UpdateDt];
                    dgvr.Cells[cl2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.cl2UpdateDt];
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
                EndTransaction();
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
