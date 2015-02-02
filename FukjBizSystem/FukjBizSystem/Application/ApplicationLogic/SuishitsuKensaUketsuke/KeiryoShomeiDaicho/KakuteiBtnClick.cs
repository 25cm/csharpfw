using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho
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
    /// 2014/12/08  宗    　    新規作成
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
    /// 2014/12/08  宗    　    新規作成
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
    /// 2014/12/08  宗    　    新規作成
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
    /// 2014/12/08  宗    　    新規作成
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
    /// 2014/12/08  宗    　    新規作成
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
        private const string FunctionName = "KeiryoShomeiDaicho：KakuteiBtnClick";

        // 計量証明の試験項目コード
        private string kmkKbn = "049";

        /// <summary>
        /// チェック状態確認用
        /// </summary>
        private const string CheckOn = "True";
        private const string CheckOff = "False";

        #region 更新日
        /// <summary>
        /// 更新日
        /// </summary>
        enum UpdateDt
        {
            hdrUpdateDtCol,
            iraiUpdateDtCol,
            phKekkaUpdateDtCol,
            ssKekkaUpdateDtCol,
            bodAKekkaUpdateDtCol,
            nh4nKekkaUpdateDtCol,
            clKekkaUpdateDtCol,
            codKekkaUpdateDtCol,
            hekisanAKekkaUpdateDtCol,
            mlssKekkaUpdateDtCol,
            tnAKekkaUpdateDtCol,
            absAKekkaUpdateDtCol,
            tpAKekkaUpdateDtCol,
            rinsanKekkaUpdateDtCol,
            no2nTeiryoKekkaUpdateDtCol,
            no3nTeiryoKekkaUpdateDtCol,
            absBKekkaUpdateDtCol,
            tnBKekkaUpdateDtCol,
            tpBKekkaUpdateDtCol,
            shikidoKekkaUpdateDtCol,
            bodBKekkaUpdateDtCol,
            hekisanKoyuKekkaUpdateDtCol,
            hekisanDoshokuKekkaUpdateDtCol,
            hekisanBKekkaUpdateDtCol,
            namariKekkaUpdateDtCol,
            aenKekkaUpdateDtCol,
            housoKekkaUpdateDtCol,
            zanenKekkaUpdateDtCol,
            gaikanKekkaUpdateDtCol,
            shukiKekkaUpdateDtCol,
            trKekkaUpdateDtCol,
            no2nTeiseiKekkaUpdateDtCol,
            no3nTeiseiKekkaUpdateDtCol,
            daichokinKekkaUpdateDtCol,
            ph1UpdateDtCol,
            ph2UpdateDtCol,
            ss1UpdateDtCol,
            ss2UpdateDtCol,
            bodA1UpdateDtCol,
            bodA2UpdateDtCol,
            nh4n1UpdateDtCol,
            nh4n2UpdateDtCol,
            cl1UpdateDtCol,
            cl2UpdateDtCol,
            cod1UpdateDtCol,
            cod2UpdateDtCol,
            hekisanA1UpdateDtCol,
            hekisanA2UpdateDtCol,
            mlss1UpdateDtCol,
            mlss2UpdateDtCol,
            tnA1UpdateDtCol,
            tnA2UpdateDtCol,
            absA1UpdateDtCol,
            absA2UpdateDtCol,
            tpA1UpdateDtCol,
            tpA2UpdateDtCol,
            rinsan1UpdateDtCol,
            rinsan2UpdateDtCol,
            no2nTeiryo1UpdateDtCol,
            no2nTeiryo2UpdateDtCol,
            no3nTeiryo1UpdateDtCol,
            no3nTeiryo2UpdateDtCol,
            absB1UpdateDtCol,
            absB2UpdateDtCol,
            tnB1UpdateDtCol,
            tnB2UpdateDtCol,
            tpB1UpdateDtCol,
            tpB2UpdateDtCol,
            shikido1UpdateDtCol,
            shikido2UpdateDtCol,
            bodB1UpdateDtCol,
            bodB2UpdateDtCol,
            hekisanKoyu1UpdateDtCol,
            hekisanKoyu2UpdateDtCol,
            hekisanDoshoku1UpdateDtCol,
            hekisanDoshoku2UpdateDtCol,
            hekisanB1UpdateDtCol,
            hekisanB2UpdateDtCol,
            namari1UpdateDtCol,
            namari2UpdateDtCol,
            aen1UpdateDtCol,
            aen2UpdateDtCol,
            houso1UpdateDtCol,
            houso2UpdateDtCol,
            zanen1UpdateDtCol,
            zanen2UpdateDtCol,
            gaikan1UpdateDtCol,
            gaikan2UpdateDtCol,
            shuki1UpdateDtCol,
            shuki2UpdateDtCol,
            tr1UpdateDtCol,
            tr2UpdateDtCol,
            no2nTeisei1UpdateDtCol,
            no2nTeisei2UpdateDtCol,
            no3nTeisei1UpdateDtCol,
            no3nTeisei2UpdateDtCol,
            daichokin1UpdateDtCol,
            daichokin2UpdateDtCol,
            Count
        }
        #endregion

        #region DataGridViewの各Index
        // 計量証明検査依頼年度
        private const int keiryoShomeiIraiNendoColIndex = 0;
        // 計量証明支所コード
        private const int keiryoShomeiIraiSishoCdColIndex = 1;
        // 計量証明依頼連番
        private const int keiryoShomeiIraiRenbanColIndex = 2;
        // 浄化槽保健所コード
        private const int jokasoHokenjoCdColIndex = 3;
        // 浄化槽台帳登録年度
        private const int jokasoTorokuNendoColIndex = 4;
        // 浄化槽台帳連番
        private const int jokasoRenbanColIndex = 5;
        // 依頼年度
        private const int iraiNendoColIndex = 6;
        // 支所コード
        private const int shishoCdIndex = 7;
        // 検体番号
        private const int iraiNoColIndex = 8;
        // 水質コード
        private const int suishitsuCdColIndex = 9;
        // 水質の種類
        private const int suishitsuShuruiColIndex = 10;
        // 処理方式区分
        private const int shoriHoshikiKbnColIndex = 11;
        // 処理方式コード
        private const int shoriHoshikiCdColIndex = 12;
        // 処理方式区分名
        private const int shoriHoshikiKbnNmColIndex = 13;
        // 処理方式名
        private const int shoriHoshikiNmColIndex = 14;
        // 過去情報ボタン
        private const int kakoJohoColIndex = 15;
        // 課長検印
        private const int kachoKeninColIndex = 16;
        // 副課長検印
        private const int hukukachoKeninColIndex = 17;
        // 計量管理者検印
        private const int kanrishaKeninColIndex = 18;
        // pH1
        private const int ph1ColIndex = 19;
        // 温度1
        private const int ondo1ColIndex = 20;
        // 結果コード（pH1）
        private const int ph1KekkaCdColIndex = 21;
        // 確認検査種別（pH1）
        private const int kakuninKensaPh1ColIndex = 22;
        // 採用値（pH1）
        private const int saiyotiPh1ColIndex = 23;
        // pH1確認検査種別（過去との比較）
        private const int ph1KensaShubetsuKakoIndex = 24;
        // 結果入力区分（pH1）
        private const int kekkaNyuryokuPh1ColIndex = 25;
        // pH2
        private const int ph2ColIndex = 26;
        // 温度2
        private const int ondo2ColIndex = 27;
        // 結果コード（pH2）
        private const int ph2KekkaCdColIndex = 28;
        // 確認検査種別（pH2）
        private const int kakuninKensaPh2ColIndex = 29;
        // 採用値（pH2）
        private const int saiyotiPh2ColIndex = 30;
        // pH2確認検査種別（過去との比較）
        private const int ph2KensaShubetsuKakoIndex = 31;
        // 結果入力区分（pH2）
        private const int kekkaNyuryokuPh2ColIndex = 32;
        // 更新区分（過去との比較）pH
        private const int koshinKbnKakoPhIndex = 33;
        // SS1
        private const int ss1ColIndex = 34;
        // 結果コード（SS1）
        private const int ss1KekkaCdColIndex = 35;
        // 確認検査種別（SS1）
        private const int kakuninKensaSs1ColIndex = 36;
        // 採用値（SS1）
        private const int saiyotiSs1ColIndex = 37;
        // SS1確認検査種別（過去との比較）
        private const int ss1KensaShubetsuKakoIndex = 38;
        // 結果入力区分（SS1）
        private const int kekkaNyuryokuSs1ColIndex = 39;
        // SS2
        private const int ss2ColIndex = 40;
        // 結果コード（SS2）
        private const int ss2KekkaCdColIndex = 41;
        // 確認検査種別（SS2）
        private const int kakuninKensaSs2ColIndex = 42;
        // 採用値（SS2）
        private const int saiyotiSs2ColIndex = 43;
        // SS2確認検査種別（過去との比較）
        private const int ss2KensaShubetsuKakoIndex = 44;
        // 結果入力区分（SS2）
        private const int kekkaNyuryokuSs2ColIndex = 45;
        // 更新区分（過去との比較）SS
        private const int koshinKbnKakoSsIndex = 46;
        // BOD（A）1
        private const int bodA1ColIndex = 47;
        // 結果コード（BOD（A）1）
        private const int bodA1KekkaCdColIndex = 48;
        // 確認検査種別（BOD（A）1）
        private const int kakuninKensaBodA1ColIndex = 49;
        // 採用値（BOD（A）1）
        private const int saiyotiBodA1ColIndex = 50;
        // BOD（A）1確認検査種別（過去との比較）
        private const int bodA1KensaShubetsuKakoIndex = 51;
        // 結果入力区分（BOD（A）1）
        private const int kekkaNyuryokuBodA1ColIndex = 52;
        // BOD（A）2
        private const int bodA2ColIndex = 53;
        // 結果コード（BOD（A）2）
        private const int bodA2KekkaCdColIndex = 54;
        // 確認検査種別（BOD（A）2）
        private const int kakuninKensaBodA2ColIndex = 55;
        // 採用値（BOD（A）2）
        private const int saiyotiBodA2ColIndex = 56;
        // BOD（A）2確認検査種別（過去との比較）
        private const int bodA2KensaShubetsuKakoIndex = 57;
        // 結果入力区分（BOD（A）2）
        private const int kekkaNyuryokuBodA2ColIndex = 58;
        // 更新区分（過去との比較）BOD（A）
        private const int koshinKbnKakoBodAIndex = 59;
        // アンモニア性窒素1
        private const int nh4n1ColIndex = 60;
        // 結果コード（アンモニア性窒素1）
        private const int nh4n1KekkaCdColIndex = 61;
        // 確認検査種別（アンモニア性窒素1）
        private const int kakuninKensaNh4n1ColIndex = 62;
        // 採用値（アンモニア性窒素1）
        private const int saiyotiNh4n1ColIndex = 63;
        // アンモニア性窒素1確認検査種別（過去との比較）
        private const int nh4n1KensaShubetsuKakoIndex = 64;
        // 結果入力区分（アンモニア性窒素1）
        private const int kekkaNyuryokuNh4n1ColIndex = 65;
        // アンモニア性窒素2
        private const int nh4n2ColIndex = 66;
        // 結果コード（アンモニア性窒素2）
        private const int nh4n2KekkaCdColIndex = 67;
        // 確認検査種別（アンモニア性窒素2）
        private const int kakuninKensaNh4n2ColIndex = 68;
        // 採用値（アンモニア性窒素2）
        private const int saiyotiNh4n2ColIndex = 69;
        // アンモニア性窒素2確認検査種別（過去との比較）
        private const int nh4n2KensaShubetsuKakoIndex = 70;
        // 結果入力区分（アンモニア性窒素2）
        private const int kekkaNyuryokuNh4n2ColIndex = 71;
        // 更新区分（過去との比較）アンモニア性窒素
        private const int koshinKbnKakoNh4nIndex = 72;
        // 塩化物イオン1
        private const int cl1ColIndex = 73;
        // 結果コード（塩化物イオン1）
        private const int cl1KekkaCdColIndex = 74;
        // 確認検査種別（塩化物イオン1）
        private const int kakuninKensaCl1ColIndex = 75;
        // 採用値（塩化物イオン1）
        private const int saiyotiCl1ColIndex = 76;
        // 塩化物イオン1確認検査種別（過去との比較）
        private const int cl1KensaShubetsuKakoIndex = 77;
        // 結果入力区分（塩化物イオン1）
        private const int kekkaNyuryokuCl1ColIndex = 78;
        // 塩化物イオン2
        private const int cl2ColIndex = 79;
        // 結果コード（塩化物イオン2）
        private const int cl2KekkaCdColIndex = 80;
        // 確認検査種別（塩化物イオン2）
        private const int kakuninKensaCl2ColIndex = 81;
        // 採用値（塩化物イオン2）
        private const int saiyotiCl2ColIndex = 82;
        // 塩化物イオン2確認検査種別（過去との比較）
        private const int cl2KensaShubetsuKakoIndex = 83;
        // 結果入力区分（塩化物イオン2）
        private const int kekkaNyuryokuCl2ColIndex = 84;
        // 更新区分（過去との比較）塩化物イオン
        private const int koshinKbnKakoClIndex = 85;
        // COD1
        private const int cod1ColIndex = 86;
        // 結果コード（COD1）
        private const int cod1KekkaCdColIndex = 87;
        // 確認検査種別（COD1）
        private const int kakuninKensaCod1ColIndex = 88;
        // 採用値（COD1）
        private const int saiyotiCod1ColIndex = 89;
        // COD1確認検査種別（過去との比較）
        private const int cod1KensaShubetsuKakoIndex = 90;
        // 結果入力区分（COD1）
        private const int kekkaNyuryokuCod1ColIndex = 91;
        // COD2
        private const int cod2ColIndex = 92;
        // 結果コード（COD2）
        private const int cod2KekkaCdColIndex = 93;
        // 確認検査種別（COD2）
        private const int kakuninKensaCod2ColIndex = 94;
        // 採用値（COD2）
        private const int saiyotiCod2ColIndex = 95;
        // COD2確認検査種別（過去との比較）
        private const int cod2KensaShubetsuKakoIndex = 96;
        // 結果入力区分（COD2）
        private const int kekkaNyuryokuCod2ColIndex = 97;
        // 更新区分（過去との比較）COD
        private const int koshinKbnKakoCodIndex = 98;
        // ヘキサン抽出物質（A）1
        private const int hekisanA1ColIndex = 99;
        // 結果コード（ヘキサン抽出物質（A）1）
        private const int hekisanA1KekkaCdColIndex = 100;
        // 確認検査種別（ヘキサン抽出物質（A）1）
        private const int kakuninKensaHekisanA1ColIndex = 101;
        // 採用値（ヘキサン抽出物質（A）1）
        private const int saiyotiHekisanA1ColIndex = 102;
        // ヘキサン抽出物質（A）1確認検査種別（過去との比較）
        private const int hekisanA1KensaShubetsuKakoIndex = 103;
        // 結果入力区分（ヘキサン抽出物質（A）1）
        private const int kekkaNyuryokuHekisanA1ColIndex = 104;
        // ヘキサン抽出物質（A）2
        private const int hekisanA2ColIndex = 105;
        // 結果コード（ヘキサン抽出物質（A）2）
        private const int hekisanA2KekkaCdColIndex = 106;
        // 確認検査種別（ヘキサン抽出物質（A）2）
        private const int kakuninKensaHekisanA2ColIndex = 107;
        // 採用値（ヘキサン抽出物質（A）2）
        private const int saiyotiHekisanA2ColIndex = 108;
        // ヘキサン抽出物質（A）2確認検査種別（過去との比較）
        private const int hekisanA2KensaShubetsuKakoIndex = 109;
        // 結果入力区分（ヘキサン抽出物質（A）2）
        private const int kekkaNyuryokuHekisanA2ColIndex = 110;
        // 更新区分（過去との比較）ヘキサン抽出物質（A）
        private const int koshinKbnKakoHekisanAIndex = 111;
        // MLSS1
        private const int mlss1ColIndex = 112;
        // 結果コード（MLSS1）
        private const int mlss1KekkaCdColIndex = 113;
        // 確認検査種別（MLSS1）
        private const int kakuninKensaMlss1ColIndex = 114;
        // 採用値（MLSS1）
        private const int saiyotiMlss1ColIndex = 115;
        // MLSS1確認検査種別（過去との比較）
        private const int mlss1KensaShubetsuKakoIndex = 116;
        // 結果入力区分（MLSS1）
        private const int kekkaNyuryokuMlss1ColIndex = 117;
        // MLSS2
        private const int mlss2ColIndex = 118;
        // 結果コード（MLSS2）
        private const int mlss2KekkaCdColIndex = 119;
        // 確認検査種別（MLSS2）
        private const int kakuninKensaMlss2ColIndex = 120;
        // 採用値（MLSS2）
        private const int saiyotiMlss2ColIndex = 121;
        // MLSS2確認検査種別（過去との比較）
        private const int mlss2KensaShubetsuKakoIndex = 122;
        // 結果入力区分（MLSS2）
        private const int kekkaNyuryokuMlss2ColIndex = 123;
        // 更新区分（過去との比較）MLSS
        private const int koshinKbnKakoMlssIndex = 124;
        // 全窒素（A)1
        private const int tnA1ColIndex = 125;
        // 結果コード（全窒素（A)1）
        private const int tnA1KekkaCdColIndex = 126;
        // 確認検査種別（全窒素（A)1）
        private const int kakuninKensaTnA1ColIndex = 127;
        // 採用値（全窒素（A)1）
        private const int saiyotiTnA1ColIndex = 128;
        // 全窒素（A)1確認検査種別（過去との比較）
        private const int tnA1KensaShubetsuKakoIndex = 129;
        // 結果入力区分（全窒素（A)1）
        private const int kekkaNyuryokuTnA1ColIndex = 130;
        // 全窒素（A)2
        private const int tnA2ColIndex = 131;
        // 結果コード（全窒素（A)2）
        private const int tnA2KekkaCdColIndex = 132;
        // 確認検査種別（全窒素（A)2）
        private const int kakuninKensaTnA2ColIndex = 133;
        // 採用値（全窒素（A)2）
        private const int saiyotiTnA2ColIndex = 134;
        // 全窒素（A)2確認検査種別（過去との比較）
        private const int tnA2KensaShubetsuKakoIndex = 135;
        // 結果入力区分（全窒素（A)2）
        private const int kekkaNyuryokuTnA2ColIndex = 136;
        // 更新区分（過去との比較）全窒素（A)
        private const int koshinKbnKakoTnAIndex = 137;
        // 陰イオン界面活性剤（A）1
        private const int absA1ColIndex = 138;
        // 結果コード（陰イオン界面活性剤（A）1）
        private const int absA1KekkaCdColIndex = 139;
        // 確認検査種別（陰イオン界面活性剤（A）1）
        private const int kakuninKensaAbsA1ColIndex = 140;
        // 採用値（陰イオン界面活性剤（A）1）
        private const int saiyotiAbsA1ColIndex = 141;
        // 陰イオン界面活性剤（A）1確認検査種別（過去との比較）
        private const int absA1KensaShubetsuKakoIndex = 142;
        // 結果入力区分（陰イオン界面活性剤（A）1）
        private const int kekkaNyuryokuAbsA1ColIndex = 143;
        // 陰イオン界面活性剤（A）2
        private const int absA2ColIndex = 144;
        // 結果コード（陰イオン界面活性剤（A）2）
        private const int absA2KekkaCdColIndex = 145;
        // 確認検査種別（陰イオン界面活性剤（A）2）
        private const int kakuninKensaAbsA2ColIndex = 146;
        // 採用値（陰イオン界面活性剤（A）2）
        private const int saiyotiAbsA2ColIndex = 147;
        // 陰イオン界面活性剤（A）2確認検査種別（過去との比較）
        private const int absA2KensaShubetsuKakoIndex = 148;
        // 結果入力区分（陰イオン界面活性剤（A）2）
        private const int kekkaNyuryokuAbsA2ColIndex = 149;
        // 更新区分（過去との比較）陰イオン界面活性剤（A）
        private const int koshinKbnKakoAbsAIndex = 150;
        // 全りん（A)1
        private const int tpA1ColIndex = 151;
        // 結果コード（全りん（A)1）
        private const int tpA1KekkaCdColIndex = 152;
        // 確認検査種別（全りん（A)1）
        private const int kakuninKensaTpA1ColIndex = 153;
        // 採用値（全りん（A)1）
        private const int saiyotiTpA1ColIndex = 154;
        // 全りん（A)1確認検査種別（過去との比較）
        private const int tpA1KensaShubetsuKakoIndex = 155;
        // 結果入力区分（全りん（A)1）
        private const int kekkaNyuryokuTpA1ColIndex = 156;
        // 全りん（A)2
        private const int tpA2ColIndex = 157;
        // 結果コード（全りん（A)2）
        private const int tpA2KekkaCdColIndex = 158;
        // 確認検査種別（全りん（A)2）
        private const int kakuninKensaTpA2ColIndex = 159;
        // 採用値（全りん（A)2）
        private const int saiyotiTpA2ColIndex = 160;
        // 全りん（A)2確認検査種別（過去との比較）
        private const int tpA2KensaShubetsuKakoIndex = 161;
        // 結果入力区分（全りん（A)2）
        private const int kekkaNyuryokuTpA2ColIndex = 162;
        // 更新区分（過去との比較）全りん（A)
        private const int koshinKbnKakoTpAIndex = 163;
        // りん酸イオン1
        private const int rinsan1ColIndex = 164;
        // 結果コード（りん酸イオン1）
        private const int rinsan1KekkaCdColIndex = 165;
        // 確認検査種別（りん酸イオン1）
        private const int kakuninKensaRinsan1ColIndex = 166;
        // 採用値（りん酸イオン1）
        private const int saiyotiRinsan1ColIndex = 167;
        // りん酸イオン1確認検査種別（過去との比較）
        private const int rinsan1KensaShubetsuKakoIndex = 168;
        // 結果入力区分（りん酸イオン1）
        private const int kekkaNyuryokuRinsan1ColIndex = 169;
        // りん酸イオン2
        private const int rinsan2ColIndex = 170;
        // 結果コード（りん酸イオン2）
        private const int rinsan2KekkaCdColIndex = 171;
        // 確認検査種別（りん酸イオン2）
        private const int kakuninKensaRinsan2ColIndex = 172;
        // 採用値（りん酸イオン2）
        private const int saiyotiRinsan2ColIndex = 173;
        // りん酸イオン2確認検査種別（過去との比較）
        private const int rinsan2KensaShubetsuKakoIndex = 174;
        // 結果入力区分（りん酸イオン2）
        private const int kekkaNyuryokuRinsan2ColIndex = 175;
        // 更新区分（過去との比較）りん酸イオン
        private const int koshinKbnKakoRinsanIndex = 176;
        // 亜硝酸性窒素（定量）1
        private const int no2nTeiryo1ColIndex = 177;
        // 結果コード（亜硝酸性窒素（定量）1）
        private const int no2nTeiryo1KekkaCdColIndex = 178;
        // 確認検査種別（亜硝酸性窒素（定量）1）
        private const int kakuninKensaNo2nTeiryo1ColIndex = 179;
        // 採用値（亜硝酸性窒素（定量）1）
        private const int saiyotiNo2nTeiryo1ColIndex = 180;
        // 亜硝酸性窒素（定量）1確認検査種別（過去との比較）
        private const int no2nTeiryo1KensaShubetsuKakoIndex = 181;
        // 結果入力区分（亜硝酸性窒素（定量）1）
        private const int kekkaNyuryokuNo2nTeiryo1ColIndex = 182;
        // 亜硝酸性窒素（定量）2
        private const int no2nTeiryo2ColIndex = 183;
        // 結果コード（亜硝酸性窒素（定量）2）
        private const int no2nTeiryo2KekkaCdColIndex = 184;
        // 確認検査種別（亜硝酸性窒素（定量）2）
        private const int kakuninKensaNo2nTeiryo2ColIndex = 185;
        // 採用値（亜硝酸性窒素（定量）2）
        private const int saiyotiNo2nTeiryo2ColIndex = 186;
        // 亜硝酸性窒素（定量）2確認検査種別（過去との比較）
        private const int no2nTeiryo2KensaShubetsuKakoIndex = 187;
        // 結果入力区分（亜硝酸性窒素（定量）2）
        private const int kekkaNyuryokuNo2nTeiryo2ColIndex = 188;
        // 更新区分（過去との比較）亜硝酸性窒素（定量）
        private const int koshinKbnKakoNo2nTeiryoIndex = 189;
        // 硝酸性窒素（定量）1
        private const int no3nTeiryo1ColIndex = 190;
        // 結果コード（硝酸性窒素（定量）1）
        private const int no3nTeiryo1KekkaCdColIndex = 191;
        // 確認検査種別（硝酸性窒素（定量）1）
        private const int kakuninKensaNo3nTeiryo1ColIndex = 192;
        // 採用値（硝酸性窒素（定量）1）
        private const int saiyotiNo3nTeiryo1ColIndex = 193;
        // 硝酸性窒素（定量）1確認検査種別（過去との比較）
        private const int no3nTeiryo1KensaShubetsuKakoIndex = 194;
        // 結果入力区分（硝酸性窒素（定量）1）
        private const int kekkaNyuryokuNo3nTeiryo1ColIndex = 195;
        // 硝酸性窒素（定量）2
        private const int no3nTeiryo2ColIndex = 196;
        // 結果コード（硝酸性窒素（定量）2）
        private const int no3nTeiryo2KekkaCdColIndex = 197;
        // 確認検査種別（硝酸性窒素（定量）2）
        private const int kakuninKensaNo3nTeiryo2ColIndex = 198;
        // 採用値（硝酸性窒素（定量）2）
        private const int saiyotiNo3nTeiryo2ColIndex = 199;
        // 硝酸性窒素（定量）2確認検査種別（過去との比較）
        private const int no3nTeiryo2KensaShubetsuKakoIndex = 200;
        // 結果入力区分（硝酸性窒素（定量）2）
        private const int kekkaNyuryokuNo3nTeiryo2ColIndex = 201;
        // 更新区分（過去との比較）硝酸性窒素（定量）
        private const int koshinKbnKakoNo3nTeiryoIndex = 202;
        // 陰イオン界面活性剤（B)1
        private const int absB1ColIndex = 203;
        // 結果コード（陰イオン界面活性剤（B)1）
        private const int absB1KekkaCdColIndex = 204;
        // 確認検査種別（陰イオン界面活性剤（B)1）
        private const int kakuninKensaAbsB1ColIndex = 205;
        // 採用値（陰イオン界面活性剤（B)1）
        private const int saiyotiAbsB1ColIndex = 206;
        // 陰イオン界面活性剤（B)1確認検査種別（過去との比較）
        private const int absB1KensaShubetsuKakoIndex = 207;
        // 結果入力区分（陰イオン界面活性剤（B)1）
        private const int kekkaNyuryokuAbsB1ColIndex = 208;
        // 陰イオン界面活性剤（B)2
        private const int absB2ColIndex = 209;
        // 結果コード（陰イオン界面活性剤（B)2）
        private const int absB2KekkaCdColIndex = 210;
        // 確認検査種別（陰イオン界面活性剤（B)2）
        private const int kakuninKensaAbsB2ColIndex = 211;
        // 採用値（陰イオン界面活性剤（B)2）
        private const int saiyotiAbsB2ColIndex = 212;
        // 陰イオン界面活性剤（B)2確認検査種別（過去との比較）
        private const int absB2KensaShubetsuKakoIndex = 213;
        // 結果入力区分（陰イオン界面活性剤（B)2）
        private const int kekkaNyuryokuAbsB2ColIndex = 214;
        // 更新区分（過去との比較）陰イオン界面活性剤（B)
        private const int koshinKbnKakoAbsBIndex = 215;
        // 全窒素（B)1
        private const int tnB1ColIndex = 216;
        // 結果コード（全窒素（B)1）
        private const int tnB1KekkaCdColIndex = 217;
        // 確認検査種別（全窒素（B)1）
        private const int kakuninKensaTnB1ColIndex = 218;
        // 採用値（全窒素（B)1）
        private const int saiyotiTnB1ColIndex = 219;
        // 全窒素（B)1確認検査種別（過去との比較）
        private const int tnB1KensaShubetsuKakoIndex = 220;
        // 結果入力区分（全窒素（B)1）
        private const int kekkaNyuryokuTnB1ColIndex = 221;
        // 全窒素（B)2
        private const int tnB2ColIndex = 222;
        // 結果コード（全窒素（B)2）
        private const int tnB2KekkaCdColIndex = 223;
        // 確認検査種別（全窒素（B)2）
        private const int kakuninKensaTnB2ColIndex = 224;
        // 採用値（全窒素（B)2）
        private const int saiyotiTnB2ColIndex = 225;
        // 全窒素（B)2確認検査種別（過去との比較）
        private const int tnB2KensaShubetsuKakoIndex = 226;
        // 結果入力区分（全窒素（B)2）
        private const int kekkaNyuryokuTnB2ColIndex = 227;
        // 更新区分（過去との比較）全窒素（B)
        private const int koshinKbnKakoTnBIndex = 228;
        // 全りん（B)1
        private const int tpB1ColIndex = 229;
        // 結果コード（全りん（B)1）
        private const int tpB1KekkaCdColIndex = 230;
        // 確認検査種別（全りん（B)1）
        private const int kakuninKensaTpB1ColIndex = 231;
        // 採用値（全りん（B)1）
        private const int saiyotiTpB1ColIndex = 232;
        // 全りん（B)1確認検査種別（過去との比較）
        private const int tpB1KensaShubetsuKakoIndex = 233;
        // 結果入力区分（全りん（B)1）
        private const int kekkaNyuryokuTpB1ColIndex = 234;
        // 全りん（B)2
        private const int tpB2ColIndex = 235;
        // 結果コード（全りん（B)2）
        private const int tpB2KekkaCdColIndex = 236;
        // 確認検査種別（全りん（B)2）
        private const int kakuninKensaTpB2ColIndex = 237;
        // 採用値（全りん（B)2）
        private const int saiyotiTpB2ColIndex = 238;
        // 全りん（B)2確認検査種別（過去との比較）
        private const int tpB2KensaShubetsuKakoIndex = 239;
        // 結果入力区分（全りん（B)2）
        private const int kekkaNyuryokuTpB2ColIndex = 240;
        // 更新区分（過去との比較）全りん（B)
        private const int koshinKbnKakoTpBIndex = 241;
        // 色度1
        private const int shikido1ColIndex = 242;
        // 結果コード（色度1）
        private const int shikido1KekkaCdColIndex = 243;
        // 確認検査種別（色度1）
        private const int kakuninKensaShikido1ColIndex = 244;
        // 採用値（色度1）
        private const int saiyotiShikido1ColIndex = 245;
        // 色度1確認検査種別（過去との比較）
        private const int shikido1KensaShubetsuKakoIndex = 246;
        // 結果入力区分（色度1）
        private const int kekkaNyuryokuShikido1ColIndex = 247;
        // 色度2
        private const int shikido2ColIndex = 248;
        // 結果コード（色度2）
        private const int shikido2KekkaCdColIndex = 249;
        // 確認検査種別（色度2）
        private const int kakuninKensaShikido2ColIndex = 250;
        // 採用値（色度2）
        private const int saiyotiShikido2ColIndex = 251;
        // 色度2確認検査種別（過去との比較）
        private const int shikido2KensaShubetsuKakoIndex = 252;
        // 結果入力区分（色度2）
        private const int kekkaNyuryokuShikido2ColIndex = 253;
        // 更新区分（過去との比較）色度
        private const int koshinKbnKakoShikidoIndex = 254;
        // BOD（B）1
        private const int bodB1ColIndex = 255;
        // 結果コード（BOD（B）1）
        private const int bodB1KekkaCdColIndex = 256;
        // 確認検査種別（BOD（B）1）
        private const int kakuninKensaBodB1ColIndex = 257;
        // 採用値（BOD（B）1）
        private const int saiyotiBodB1ColIndex = 258;
        // BOD（B）1確認検査種別（過去との比較）
        private const int bodB1KensaShubetsuKakoIndex = 259;
        // 結果入力区分（BOD（B）1）
        private const int kekkaNyuryokuBodB1ColIndex = 260;
        // BOD（B）2
        private const int bodB2ColIndex = 261;
        // 結果コード（BOD（B）2）
        private const int bodB2KekkaCdColIndex = 262;
        // 確認検査種別（BOD（B）2）
        private const int kakuninKensaBodB2ColIndex = 263;
        // 採用値（BOD（B）2）
        private const int saiyotiBodB2ColIndex = 264;
        // BOD（B）2確認検査種別（過去との比較）
        private const int bodB2KensaShubetsuKakoIndex = 265;
        // 結果入力区分（BOD（B）2）
        private const int kekkaNyuryokuBodB2ColIndex = 266;
        // 更新区分（過去との比較）BOD（B）
        private const int koshinKbnKakoBodBIndex = 267;
        // ヘキサン抽出物質（鉱油類）1
        private const int hekisanKoyu1ColIndex = 268;
        // 結果コード（ヘキサン抽出物質（鉱油類）1）
        private const int hekisanKoyu1KekkaCdColIndex = 269;
        // 確認検査種別（ヘキサン抽出物質（鉱油類）1）
        private const int kakuninKensaHekisanKoyu1ColIndex = 270;
        // 採用値（ヘキサン抽出物質（鉱油類）1）
        private const int saiyotiHekisanKoyu1ColIndex = 271;
        // ヘキサン抽出物質（鉱油類）1確認検査種別（過去との比較）
        private const int hekisanKoyu1KensaShubetsuKakoIndex = 272;
        // 結果入力区分（ヘキサン抽出物質（鉱油類）1）
        private const int kekkaNyuryokuHekisanKoyu1ColIndex = 273;
        // ヘキサン抽出物質（鉱油類）2
        private const int hekisanKoyu2ColIndex = 274;
        // 結果コード（ヘキサン抽出物質（鉱油類）2）
        private const int hekisanKoyu2KekkaCdColIndex = 275;
        // 確認検査種別（ヘキサン抽出物質（鉱油類）2）
        private const int kakuninKensaHekisanKoyu2ColIndex = 276;
        // 採用値（ヘキサン抽出物質（鉱油類）2）
        private const int saiyotiHekisanKoyu2ColIndex = 277;
        // ヘキサン抽出物質（鉱油類）2確認検査種別（過去との比較）
        private const int hekisanKoyu2KensaShubetsuKakoIndex = 278;
        // 結果入力区分（ヘキサン抽出物質（鉱油類）2）
        private const int kekkaNyuryokuHekisanKoyu2ColIndex = 279;
        // 更新区分（過去との比較）ヘキサン抽出物質（鉱油類）
        private const int koshinKbnKakoHekisanKoyuIndex = 280;
        // ヘキサン抽出物質（動植物油類）1
        private const int hekisanDoshoku1ColIndex = 281;
        // 結果コード（ヘキサン抽出物質（動植物油類）1）
        private const int hekisanDoshoku1KekkaCdColIndex = 282;
        // 確認検査種別（ヘキサン抽出物質（動植物油類）1）
        private const int kakuninKensaHekisanDoshoku1ColIndex = 283;
        // 採用値（ヘキサン抽出物質（動植物油類）1）
        private const int saiyotiHekisanDoshoku1ColIndex = 284;
        // ヘキサン抽出物質（動植物油類）1確認検査種別（過去との比較）
        private const int hekisanDoshoku1KensaShubetsuKakoIndex = 285;
        // 結果入力区分（ヘキサン抽出物質（動植物油類）1）
        private const int kekkaNyuryokuHekisanDoshoku1ColIndex = 286;
        // ヘキサン抽出物質（動植物油類）2
        private const int hekisanDoshoku2ColIndex = 287;
        // 結果コード（ヘキサン抽出物質（動植物油類）2）
        private const int hekisanDoshoku2KekkaCdColIndex = 288;
        // 確認検査種別（ヘキサン抽出物質（動植物油類）2）
        private const int kakuninKensaHekisanDoshoku2ColIndex = 289;
        // 採用値（ヘキサン抽出物質（動植物油類）2）
        private const int saiyotiHekisanDoshoku2ColIndex = 290;
        // ヘキサン抽出物質（動植物油類）2確認検査種別（過去との比較）
        private const int hekisanDoshoku2KensaShubetsuKakoIndex = 291;
        // 結果入力区分（ヘキサン抽出物質（動植物油類）2）
        private const int kekkaNyuryokuHekisanDoshoku2ColIndex = 292;
        // 更新区分（過去との比較）ヘキサン抽出物質（動植物油類）
        private const int koshinKbnKakoHekisanDoshokuIndex = 293;
        // ヘキサン抽出物質（B）1
        private const int hekisanB1ColIndex = 294;
        // 結果コード（ヘキサン抽出物質（B）1）
        private const int hekisanB1KekkaCdColIndex = 295;
        // 確認検査種別（ヘキサン抽出物質（B）1）
        private const int kakuninKensaHekisanB1ColIndex = 296;
        // 採用値（ヘキサン抽出物質（B）1）
        private const int saiyotiHekisanB1ColIndex = 297;
        // ヘキサン抽出物質（B）1確認検査種別（過去との比較）
        private const int hekisanB1KensaShubetsuKakoIndex = 298;
        // 結果入力区分（ヘキサン抽出物質（B）1）
        private const int kekkaNyuryokuHekisanB1ColIndex = 299;
        // ヘキサン抽出物質（B）2
        private const int hekisanB2ColIndex = 300;
        // 結果コード（ヘキサン抽出物質（B）2）
        private const int hekisanB2KekkaCdColIndex = 301;
        // 確認検査種別（ヘキサン抽出物質（B）2）
        private const int kakuninKensaHekisanB2ColIndex = 302;
        // 採用値（ヘキサン抽出物質（B）2）
        private const int saiyotiHekisanB2ColIndex = 303;
        // ヘキサン抽出物質（B）2確認検査種別（過去との比較）
        private const int hekisanB2KensaShubetsuKakoIndex = 304;
        // 結果入力区分（ヘキサン抽出物質（B）2）
        private const int kekkaNyuryokuHekisanB2ColIndex = 305;
        // 更新区分（過去との比較）ヘキサン抽出物質（B）
        private const int koshinKbnKakoHekisanBIndex = 306;
        // 鉛1
        private const int namari1ColIndex = 307;
        // 結果コード（鉛1）
        private const int namari1KekkaCdColIndex = 308;
        // 確認検査種別（鉛1）
        private const int kakuninKensaNamari1ColIndex = 309;
        // 採用値（鉛1）
        private const int saiyotiNamari1ColIndex = 310;
        // 鉛1確認検査種別（過去との比較）
        private const int namari1KensaShubetsuKakoIndex = 311;
        // 結果入力区分（鉛1）
        private const int kekkaNyuryokuNamari1ColIndex = 312;
        // 鉛2
        private const int namari2ColIndex = 313;
        // 結果コード（鉛2）
        private const int namari2KekkaCdColIndex = 314;
        // 確認検査種別（鉛2）
        private const int kakuninKensaNamari2ColIndex = 315;
        // 採用値（鉛2）
        private const int saiyotiNamari2ColIndex = 316;
        // 鉛2確認検査種別（過去との比較）
        private const int namari2KensaShubetsuKakoIndex = 317;
        // 結果入力区分（鉛2）
        private const int kekkaNyuryokuNamari2ColIndex = 318;
        // 更新区分（過去との比較）鉛
        private const int koshinKbnKakoNamariIndex = 319;
        // 亜鉛1
        private const int aen1ColIndex = 320;
        // 結果コード（亜鉛1）
        private const int aen1KekkaCdColIndex = 321;
        // 確認検査種別（亜鉛1）
        private const int kakuninKensaAen1ColIndex = 322;
        // 採用値（亜鉛1）
        private const int saiyotiAen1ColIndex = 323;
        // 亜鉛1確認検査種別（過去との比較）
        private const int aen1KensaShubetsuKakoIndex = 324;
        // 結果入力区分（亜鉛1）
        private const int kekkaNyuryokuAen1ColIndex = 325;
        // 亜鉛2
        private const int aen2ColIndex = 326;
        // 結果コード（亜鉛2）
        private const int aen2KekkaCdColIndex = 327;
        // 確認検査種別（亜鉛2）
        private const int kakuninKensaAen2ColIndex = 328;
        // 採用値（亜鉛2）
        private const int saiyotiAen2ColIndex = 329;
        // 亜鉛2確認検査種別（過去との比較）
        private const int aen2KensaShubetsuKakoIndex = 330;
        // 結果入力区分（亜鉛2）
        private const int kekkaNyuryokuAen2ColIndex = 331;
        // 更新区分（過去との比較）亜鉛
        private const int koshinKbnKakoAenIndex = 332;
        // ほう素1
        private const int houso1ColIndex = 333;
        // 結果コード（ほう素1）
        private const int houso1KekkaCdColIndex = 334;
        // 確認検査種別（ほう素1）
        private const int kakuninKensaHouso1ColIndex = 335;
        // 採用値（ほう素1）
        private const int saiyotiHouso1ColIndex = 336;
        // ほう素1確認検査種別（過去との比較）
        private const int houso1KensaShubetsuKakoIndex = 337;
        // 結果入力区分（ほう素1）
        private const int kekkaNyuryokuHouso1ColIndex = 338;
        // ほう素2
        private const int houso2ColIndex = 339;
        // 結果コード（ほう素2）
        private const int houso2KekkaCdColIndex = 340;
        // 確認検査種別（ほう素2）
        private const int kakuninKensaHouso2ColIndex = 341;
        // 採用値（ほう素2）
        private const int saiyotiHouso2ColIndex = 342;
        // ほう素2確認検査種別（過去との比較）
        private const int houso2KensaShubetsuKakoIndex = 343;
        // 結果入力区分（ほう素2）
        private const int kekkaNyuryokuHouso2ColIndex = 344;
        // 更新区分（過去との比較）ほう素
        private const int koshinKbnKakoHousoIndex = 345;
        // 残塩1
        private const int zanen1ColIndex = 346;
        // 結果コード（残塩1）
        private const int zanen1KekkaCdColIndex = 347;
        // 確認検査種別（残塩1）
        private const int kakuninKensaZanen1ColIndex = 348;
        // 採用値（残塩1）
        private const int saiyotiZanen1ColIndex = 349;
        // 残塩1確認検査種別（過去との比較）
        private const int zanen1KensaShubetsuKakoIndex = 350;
        // 結果入力区分（残塩1）
        private const int kekkaNyuryokuZanen1ColIndex = 351;
        // 残塩2
        private const int zanen2ColIndex = 352;
        // 結果コード（残塩2）
        private const int zanen2KekkaCdColIndex = 353;
        // 確認検査種別（残塩2）
        private const int kakuninKensaZanen2ColIndex = 354;
        // 採用値（残塩2）
        private const int saiyotiZanen2ColIndex = 355;
        // 残塩2確認検査種別（過去との比較）
        private const int zanen2KensaShubetsuKakoIndex = 356;
        // 結果入力区分（残塩2）
        private const int kekkaNyuryokuZanen2ColIndex = 357;
        // 更新区分（過去との比較）残塩
        private const int koshinKbnKakoZanenIndex = 358;
        // 外観1
        private const int gaikan1ColIndex = 359;
        // 結果コード（外観1）
        private const int gaikan1KekkaCdColIndex = 360;
        // 確認検査種別（外観1）
        private const int kakuninKensaGaikan1ColIndex = 361;
        // 採用値（外観1）
        private const int saiyotiGaikan1ColIndex = 362;
        // 外観1確認検査種別（過去との比較）
        private const int gaikan1KensaShubetsuKakoIndex = 363;
        // 結果入力区分（外観1）
        private const int kekkaNyuryokuGaikan1ColIndex = 364;
        // 外観2
        private const int gaikan2ColIndex = 365;
        // 結果コード（外観2）
        private const int gaikan2KekkaCdColIndex = 366;
        // 確認検査種別（外観2）
        private const int kakuninKensaGaikan2ColIndex = 367;
        // 採用値（外観2）
        private const int saiyotiGaikan2ColIndex = 368;
        // 外観2確認検査種別（過去との比較）
        private const int gaikan2KensaShubetsuKakoIndex = 369;
        // 結果入力区分（外観2）
        private const int kekkaNyuryokuGaikan2ColIndex = 370;
        // 更新区分（過去との比較）外観
        private const int koshinKbnKakoGaikanIndex = 371;
        // 臭気1
        private const int shuki1ColIndex = 372;
        // 結果コード（臭気1）
        private const int shuki1KekkaCdColIndex = 373;
        // 確認検査種別（臭気1）
        private const int kakuninKensaShuki1ColIndex = 374;
        // 採用値（臭気1）
        private const int saiyotiShuki1ColIndex = 375;
        // 臭気1確認検査種別（過去との比較）
        private const int shuki1KensaShubetsuKakoIndex = 376;
        // 結果入力区分（臭気1）
        private const int kekkaNyuryokuShuki1ColIndex = 377;
        // 臭気2
        private const int shuki2ColIndex = 378;
        // 結果コード（臭気2）
        private const int shuki2KekkaCdColIndex = 379;
        // 確認検査種別（臭気2）
        private const int kakuninKensaShuki2ColIndex = 380;
        // 採用値（臭気2）
        private const int saiyotiShuki2ColIndex = 381;
        // 臭気2確認検査種別（過去との比較）
        private const int shuki2KensaShubetsuKakoIndex = 382;
        // 結果入力区分（臭気2）
        private const int kekkaNyuryokuShuki2ColIndex = 383;
        // 更新区分（過去との比較）臭気
        private const int koshinKbnKakoShukiIndex = 384;
        // 透視度1
        private const int tr1ColIndex = 385;
        // 結果コード（透視度1）
        private const int tr1KekkaCdColIndex = 386;
        // 確認検査種別（透視度1）
        private const int kakuninKensaTr1ColIndex = 387;
        // 採用値（透視度1）
        private const int saiyotiTr1ColIndex = 388;
        // 透視度1確認検査種別（過去との比較）
        private const int tr1KensaShubetsuKakoIndex = 389;
        // 結果入力区分（透視度1）
        private const int kekkaNyuryokuTr1ColIndex = 390;
        // 透視度2
        private const int tr2ColIndex = 391;
        // 結果コード（透視度2）
        private const int tr2KekkaCdColIndex = 392;
        // 確認検査種別（透視度2）
        private const int kakuninKensaTr2ColIndex = 393;
        // 採用値（透視度2）
        private const int saiyotiTr2ColIndex = 394;
        // 透視度2確認検査種別（過去との比較）
        private const int tr2KensaShubetsuKakoIndex = 395;
        // 結果入力区分（透視度2）
        private const int kekkaNyuryokuTr2ColIndex = 396;
        // 更新区分（過去との比較）透視度
        private const int koshinKbnKakoTrIndex = 397;
        // 亜硝酸性窒素（定性）1
        private const int no2nTeisei1ColIndex = 398;
        // 結果コード（亜硝酸性窒素（定性）1）
        private const int no2nTeisei1KekkaCdColIndex = 399;
        // 確認検査種別（亜硝酸性窒素（定性）1）
        private const int kakuninKensaNo2nTeisei1ColIndex = 400;
        // 採用値（亜硝酸性窒素（定性）1）
        private const int saiyotiNo2nTeisei1ColIndex = 401;
        // 亜硝酸性窒素（定性）1確認検査種別（過去との比較）
        private const int no2nTeisei1KensaShubetsuKakoIndex = 402;
        // 結果入力区分（亜硝酸性窒素（定性）1）
        private const int kekkaNyuryokuNo2nTeisei1ColIndex = 403;
        // 亜硝酸性窒素（定性）2
        private const int no2nTeisei2ColIndex = 404;
        // 結果コード（亜硝酸性窒素（定性）2）
        private const int no2nTeisei2KekkaCdColIndex = 405;
        // 確認検査種別（亜硝酸性窒素（定性）2）
        private const int kakuninKensaNo2nTeisei2ColIndex = 406;
        // 採用値（亜硝酸性窒素（定性）2）
        private const int saiyotiNo2nTeisei2ColIndex = 407;
        // 亜硝酸性窒素（定性）2確認検査種別（過去との比較）
        private const int no2nTeisei2KensaShubetsuKakoIndex = 408;
        // 結果入力区分（亜硝酸性窒素（定性）2）
        private const int kekkaNyuryokuNo2nTeisei2ColIndex = 409;
        // 更新区分（過去との比較）亜硝酸性窒素（定性）
        private const int koshinKbnKakoNo2nTeiseiIndex = 410;
        // 硝酸性窒素（定性）1
        private const int no3nTeisei1ColIndex = 411;
        // 結果コード（硝酸性窒素（定性）1）
        private const int no3nTeisei1KekkaCdColIndex = 412;
        // 確認検査種別（硝酸性窒素（定性）1）
        private const int kakuninKensaNo3nTeisei1ColIndex = 413;
        // 採用値（硝酸性窒素（定性）1）
        private const int saiyotiNo3nTeisei1ColIndex = 414;
        // 硝酸性窒素（定性）1確認検査種別（過去との比較）
        private const int no3nTeisei1KensaShubetsuKakoIndex = 415;
        // 結果入力区分（硝酸性窒素（定性）1）
        private const int kekkaNyuryokuNo3nTeisei1ColIndex = 416;
        // 硝酸性窒素（定性）2
        private const int no3nTeisei2ColIndex = 417;
        // 結果コード（硝酸性窒素（定性）2）
        private const int no3nTeisei2KekkaCdColIndex = 418;
        // 確認検査種別（硝酸性窒素（定性）2）
        private const int kakuninKensaNo3nTeisei2ColIndex = 419;
        // 採用値（硝酸性窒素（定性）2）
        private const int saiyotiNo3nTeisei2ColIndex = 420;
        // 硝酸性窒素（定性）2確認検査種別（過去との比較）
        private const int no3nTeisei2KensaShubetsuKakoIndex = 421;
        // 結果入力区分（硝酸性窒素（定性）2）
        private const int kekkaNyuryokuNo3nTeisei2ColIndex = 422;
        // 更新区分（過去との比較）硝酸性窒素（定性）
        private const int koshinKbnKakoNo3nTeiseiIndex = 423;
        // 大腸菌群数1
        private const int daichokin1ColIndex = 424;
        // 結果コード（大腸菌群数1）
        private const int daichokin1KekkaCdColIndex = 425;
        // 確認検査種別（大腸菌群数1）
        private const int kakuninKensaDaichokin1ColIndex = 426;
        // 採用値（大腸菌群数1）
        private const int saiyotiDaichokin1ColIndex = 427;
        // 大腸菌群数1確認検査種別（過去との比較）
        private const int daichokin1KensaShubetsuKakoIndex = 428;
        // 結果入力区分（大腸菌群数1）
        private const int kekkaNyuryokuDaichokin1ColIndex = 429;
        // 大腸菌群数2
        private const int daichokin2ColIndex = 430;
        // 結果コード（大腸菌群数2）
        private const int daichokin2KekkaCdColIndex = 431;
        // 確認検査種別（大腸菌群数2）
        private const int kakuninKensaDaichokin2ColIndex = 432;
        // 採用値（大腸菌群数2）
        private const int saiyotiDaichokin2ColIndex = 433;
        // 大腸菌群数2確認検査種別（過去との比較）
        private const int daichokin2KensaShubetsuKakoIndex = 434;
        // 結果入力区分（大腸菌群数2）
        private const int kekkaNyuryokuDaichokin2ColIndex = 435;
        // 更新区分（過去との比較）大腸菌群数
        private const int koshinKbnKakoDaichokinIndex = 436;
        // 結果確定日
        private const int kekkaKakuteiDtColIndex = 437;
        // 更新区分(検印)
        private const int koshinKbnKeninIndex = 438;
        // 更新区分（pH）
        private const int koshinKbnPhIndex = 439;
        // 更新区分（SS）
        private const int koshinKbnSsIndex = 440;
        // 更新区分（BOD（A））
        private const int koshinKbnBodAIndex = 441;
        // 更新区分（アンモニア性窒素）
        private const int koshinKbnNh4nIndex = 442;
        // 更新区分（塩化物イオン）
        private const int koshinKbnClIndex = 443;
        // 更新区分（COD）
        private const int koshinKbnCodIndex = 444;
        // 更新区分（ヘキサン抽出物質（A））
        private const int koshinKbnHekisanAIndex = 445;
        // 更新区分（MLSS）
        private const int koshinKbnMlssIndex = 446;
        // 更新区分（全窒素（A)）
        private const int koshinKbnTnAIndex = 447;
        // 更新区分（陰イオン界面活性剤（A））
        private const int koshinKbnAbsAIndex = 448;
        // 更新区分（全りん（A)）
        private const int koshinKbnTpAIndex = 449;
        // 更新区分（りん酸イオン）
        private const int koshinKbnRinsanIndex = 450;
        // 更新区分（亜硝酸性窒素（定量））
        private const int koshinKbnNo2nTeiryoIndex = 451;
        // 更新区分（硝酸性窒素（定量））
        private const int koshinKbnNo3nTeiryoIndex = 452;
        // 更新区分（陰イオン界面活性剤（B)）
        private const int koshinKbnAbsBIndex = 453;
        // 更新区分（全窒素（B)）
        private const int koshinKbnTnBIndex = 454;
        // 更新区分（全りん（B)）
        private const int koshinKbnTpBIndex = 455;
        // 更新区分（色度）
        private const int koshinKbnShikidoIndex = 456;
        // 更新区分（BOD（B））
        private const int koshinKbnBodBIndex = 457;
        // 更新区分（ヘキサン抽出物質（鉱油類））
        private const int koshinKbnHekisanKoyuIndex = 458;
        // 更新区分（ヘキサン抽出物質（動植物油類））
        private const int koshinKbnHekisanDoshokuIndex = 459;
        // 更新区分（ヘキサン抽出物質（B））
        private const int koshinKbnHekisanBIndex = 460;
        // 更新区分（鉛）
        private const int koshinKbnNamariIndex = 461;
        // 更新区分（亜鉛）
        private const int koshinKbnAenIndex = 462;
        // 更新区分（ほう素）
        private const int koshinKbnHousoIndex = 463;
        // 更新区分（残塩）
        private const int koshinKbnZanenIndex = 464;
        // 更新区分（外観）
        private const int koshinKbnGaikanIndex = 465;
        // 更新区分（臭気）
        private const int koshinKbnShukiIndex = 466;
        // 更新区分（透視度）
        private const int koshinKbnTrIndex = 467;
        // 更新区分（亜硝酸性窒素（定性））
        private const int koshinKbnNo2nTeiseiIndex = 468;
        // 更新区分（硝酸性窒素（定性））
        private const int koshinKbnNo3nTeiseiIndex = 469;
        // 更新区分（大腸菌群数）
        private const int koshinKbnDaichokinIndex = 470;
        // 更新区分（SS/透視度）
        private const int koshinKbnSsTrIndex = 471;
        // 更新区分（BOD/透視度）
        private const int koshinKbnBodTrIndex = 472;
        // 更新区分（塩化物イオン確認検査）
        private const int koshinKbnEnkaIonIndex = 473;
        // 更新区分（アンモニア確認検査）
        private const int koshinKbnAnmoniaIndex = 474;
        // 更新区分（アンモニアと全窒素比較）
        private const int koshinKbnAnmoniaTnIndex = 475;
        // 更新区分（COD基準値オーバー）
        private const int koshinKbnCodOverIndex = 476;
        // SS1確認検査種別（SS/透視度）
        private const int ss1KensaShubetsuSsTrIndex = 477;
        // SS2確認検査種別（SS/透視度）
        private const int ss2KensaShubetsuSsTrIndex = 478;
        // 透視度1確認検査種別（SS/透視度）
        private const int tr1KensaShubetsuSsTrIndex = 479;
        // 透視度2確認検査種別（SS/透視度）
        private const int tr2KensaShubetsuSsTrIndex = 480;
        // BOD（A）1確認検査種別（BOD/透視度）
        private const int bodA1KensaShubetsuBodTrIndex = 481;
        // BOD（A）2確認検査種別（BOD/透視度）
        private const int bodA2KensaShubetsuBodTrIndex = 482;
        // BOD（B）1確認検査種別（BOD/透視度）
        private const int bodB1KensaShubetsuBodTrIndex = 483;
        // BOD（B）2確認検査種別（BOD/透視度）
        private const int bodB2KensaShubetsuBodTrIndex = 484;
        // 透視度1確認検査種別（BOD/透視度）
        private const int tr1KensaShubetsuBodTrIndex = 485;
        // 透視度2確認検査種別（BOD/透視度）
        private const int tr2KensaShubetsuBodTrIndex = 486;
        // 塩化物イオン1確認検査種別（塩化物イオン確認検査）
        private const int cl1KensaShubetsuEnkaIonIndex = 487;
        // 塩化物イオン2確認検査種別（塩化物イオン確認検査）
        private const int cl2KensaShubetsuEnkaIonIndex = 488;
        // アンモニア性窒素1確認検査種別（アンモニア確認検査）
        private const int nh4n1KensaShubetsuAnmoniaIndex = 489;
        // アンモニア性窒素2確認検査種別（アンモニア確認検査）
        private const int nh4n2KensaShubetsuAnmoniaIndex = 490;
        // アンモニア性窒素1確認検査種別（アンモニアと全窒素比較）
        private const int nh4n1KensaShubetsuAnmoniaTnIndex = 491;
        // アンモニア性窒素2確認検査種別（アンモニアと全窒素比較）
        private const int nh4n2KensaShubetsuAnmoniaTnIndex = 492;
        // 全窒素（A）1確認検査種別（アンモニアと全窒素比較）
        private const int tnA1KensaShubetsuAnmoniaTnIndex = 493;
        // 全窒素（A）2確認検査種別（アンモニアと全窒素比較）
        private const int tnA2KensaShubetsuAnmoniaTnIndex = 494;
        // 全窒素（B）1確認検査種別（アンモニアと全窒素比較）
        private const int tnB1KensaShubetsuAnmoniaTnIndex = 495;
        // 全窒素（B）2確認検査種別（アンモニアと全窒素比較）
        private const int tnB2KensaShubetsuAnmoniaTnIndex = 496;
        // COD1確認検査種別（COD基準値オーバー）
        private const int cod1KensaShubetsuCodOverIndex = 497;
        // COD2確認検査種別（COD基準値オーバー）
        private const int cod2KensaShubetsuCodOverIndex = 498;
        // 更新日(検査台帳ヘッダ)
        private const int hdrUpdateDtColIndex = 499;
        // 更新日(計量証明依頼テーブル)
        private const int iraiUpdateDtColIndex = 500;
        // 更新日(計量証明結果テーブル(pH))
        private const int phKekkaUpdateDtColIndex = 501;
        // 更新日(計量証明結果テーブル(SS))
        private const int ssKekkaUpdateDtColIndex = 502;
        // 更新日(計量証明結果テーブル(BOD（A）))
        private const int bodAKekkaUpdateDtColIndex = 503;
        // 更新日(計量証明結果テーブル(アンモニア性窒素))
        private const int nh4nKekkaUpdateDtColIndex = 504;
        // 更新日(計量証明結果テーブル(塩化物イオン))
        private const int clKekkaUpdateDtColIndex = 505;
        // 更新日(計量証明結果テーブル(COD))
        private const int codKekkaUpdateDtColIndex = 506;
        // 更新日(計量証明結果テーブル(ヘキサン抽出物質（A）))
        private const int hekisanAKekkaUpdateDtColIndex = 507;
        // 更新日(計量証明結果テーブル(MLSS))
        private const int mlssKekkaUpdateDtColIndex = 508;
        // 更新日(計量証明結果テーブル(全窒素（A)))
        private const int tnAKekkaUpdateDtColIndex = 509;
        // 更新日(計量証明結果テーブル(陰イオン界面活性剤（A）))
        private const int absAKekkaUpdateDtColIndex = 510;
        // 更新日(計量証明結果テーブル(全りん（A)))
        private const int tpAKekkaUpdateDtColIndex = 511;
        // 更新日(計量証明結果テーブル(りん酸イオン))
        private const int rinsanKekkaUpdateDtColIndex = 512;
        // 更新日(計量証明結果テーブル(亜硝酸性窒素（定量）))
        private const int no2nTeiryoKekkaUpdateDtColIndex = 513;
        // 更新日(計量証明結果テーブル(硝酸性窒素（定量）))
        private const int no3nTeiryoKekkaUpdateDtColIndex = 514;
        // 更新日(計量証明結果テーブル(陰イオン界面活性剤（B)))
        private const int absBKekkaUpdateDtColIndex = 515;
        // 更新日(計量証明結果テーブル(全窒素（B)))
        private const int tnBKekkaUpdateDtColIndex = 516;
        // 更新日(計量証明結果テーブル(全りん（B)))
        private const int tpBKekkaUpdateDtColIndex = 517;
        // 更新日(計量証明結果テーブル(色度))
        private const int shikidoKekkaUpdateDtColIndex = 518;
        // 更新日(計量証明結果テーブル(BOD（B）))
        private const int bodBKekkaUpdateDtColIndex = 519;
        // 更新日(計量証明結果テーブル(ヘキサン抽出物質（鉱油類）))
        private const int hekisanKoyuKekkaUpdateDtColIndex = 520;
        // 更新日(計量証明結果テーブル(ヘキサン抽出物質（動植物油類）))
        private const int hekisanDoshokuKekkaUpdateDtColIndex = 521;
        // 更新日(計量証明結果テーブル(ヘキサン抽出物質（B）))
        private const int hekisanBKekkaUpdateDtColIndex = 522;
        // 更新日(計量証明結果テーブル(鉛))
        private const int namariKekkaUpdateDtColIndex = 523;
        // 更新日(計量証明結果テーブル(亜鉛))
        private const int aenKekkaUpdateDtColIndex = 524;
        // 更新日(計量証明結果テーブル(ほう素))
        private const int housoKekkaUpdateDtColIndex = 525;
        // 更新日(計量証明結果テーブル(残塩))
        private const int zanenKekkaUpdateDtColIndex = 526;
        // 更新日(計量証明結果テーブル(外観))
        private const int gaikanKekkaUpdateDtColIndex = 527;
        // 更新日(計量証明結果テーブル(臭気))
        private const int shukiKekkaUpdateDtColIndex = 528;
        // 更新日(計量証明結果テーブル(透視度))
        private const int trKekkaUpdateDtColIndex = 529;
        // 更新日(計量証明結果テーブル(亜硝酸性窒素（定性）))
        private const int no2nTeiseiKekkaUpdateDtColIndex = 530;
        // 更新日(計量証明結果テーブル(硝酸性窒素（定性）))
        private const int no3nTeiseiKekkaUpdateDtColIndex = 531;
        // 更新日(計量証明結果テーブル(大腸菌群数))
        private const int daichokinKekkaUpdateDtColIndex = 532;
        // 更新日(検査台帳明細(pH1))
        private const int ph1UpdateDtColIndex = 533;
        // 更新日(検査台帳明細(pH2))
        private const int ph2UpdateDtColIndex = 534;
        // 更新日(検査台帳明細(SS1))
        private const int ss1UpdateDtColIndex = 535;
        // 更新日(検査台帳明細(SS2))
        private const int ss2UpdateDtColIndex = 536;
        // 更新日(検査台帳明細(BOD（A）1))
        private const int bodA1UpdateDtColIndex = 537;
        // 更新日(検査台帳明細(BOD（A）2))
        private const int bodA2UpdateDtColIndex = 538;
        // 更新日(検査台帳明細(アンモニア性窒素1))
        private const int nh4n1UpdateDtColIndex = 539;
        // 更新日(検査台帳明細(アンモニア性窒素2))
        private const int nh4n2UpdateDtColIndex = 540;
        // 更新日(検査台帳明細(塩化物イオン1))
        private const int cl1UpdateDtColIndex = 541;
        // 更新日(検査台帳明細(塩化物イオン2))
        private const int cl2UpdateDtColIndex = 542;
        // 更新日(検査台帳明細(COD1))
        private const int cod1UpdateDtColIndex = 543;
        // 更新日(検査台帳明細(COD2))
        private const int cod2UpdateDtColIndex = 544;
        // 更新日(検査台帳明細(ヘキサン抽出物質（A）1))
        private const int hekisanA1UpdateDtColIndex = 545;
        // 更新日(検査台帳明細(ヘキサン抽出物質（A）2))
        private const int hekisanA2UpdateDtColIndex = 546;
        // 更新日(検査台帳明細(MLSS1))
        private const int mlss1UpdateDtColIndex = 547;
        // 更新日(検査台帳明細(MLSS2))
        private const int mlss2UpdateDtColIndex = 548;
        // 更新日(検査台帳明細(全窒素（A)1))
        private const int tnA1UpdateDtColIndex = 549;
        // 更新日(検査台帳明細(全窒素（A)2))
        private const int tnA2UpdateDtColIndex = 550;
        // 更新日(検査台帳明細(陰イオン界面活性剤（A）1))
        private const int absA1UpdateDtColIndex = 551;
        // 更新日(検査台帳明細(陰イオン界面活性剤（A）2))
        private const int absA2UpdateDtColIndex = 552;
        // 更新日(検査台帳明細(全りん（A)1))
        private const int tpA1UpdateDtColIndex = 553;
        // 更新日(検査台帳明細(全りん（A)2))
        private const int tpA2UpdateDtColIndex = 554;
        // 更新日(検査台帳明細(りん酸イオン1))
        private const int rinsan1UpdateDtColIndex = 555;
        // 更新日(検査台帳明細(りん酸イオン2))
        private const int rinsan2UpdateDtColIndex = 556;
        // 更新日(検査台帳明細(亜硝酸性窒素（定量）1))
        private const int no2nTeiryo1UpdateDtColIndex = 557;
        // 更新日(検査台帳明細(亜硝酸性窒素（定量）2))
        private const int no2nTeiryo2UpdateDtColIndex = 558;
        // 更新日(検査台帳明細(硝酸性窒素（定量）1))
        private const int no3nTeiryo1UpdateDtColIndex = 559;
        // 更新日(検査台帳明細(硝酸性窒素（定量）2))
        private const int no3nTeiryo2UpdateDtColIndex = 560;
        // 更新日(検査台帳明細(陰イオン界面活性剤（B)1))
        private const int absB1UpdateDtColIndex = 561;
        // 更新日(検査台帳明細(陰イオン界面活性剤（B)2))
        private const int absB2UpdateDtColIndex = 562;
        // 更新日(検査台帳明細(全窒素（B)1))
        private const int tnB1UpdateDtColIndex = 563;
        // 更新日(検査台帳明細(全窒素（B)2))
        private const int tnB2UpdateDtColIndex = 564;
        // 更新日(検査台帳明細(全りん（B)1))
        private const int tpB1UpdateDtColIndex = 565;
        // 更新日(検査台帳明細(全りん（B)2))
        private const int tpB2UpdateDtColIndex = 566;
        // 更新日(検査台帳明細(色度1))
        private const int shikido1UpdateDtColIndex = 567;
        // 更新日(検査台帳明細(色度2))
        private const int shikido2UpdateDtColIndex = 568;
        // 更新日(検査台帳明細(BOD（B）1))
        private const int bodB1UpdateDtColIndex = 569;
        // 更新日(検査台帳明細(BOD（B）2))
        private const int bodB2UpdateDtColIndex = 570;
        // 更新日(検査台帳明細(ヘキサン抽出物質（鉱油類）1))
        private const int hekisanKoyu1UpdateDtColIndex = 571;
        // 更新日(検査台帳明細(ヘキサン抽出物質（鉱油類）2))
        private const int hekisanKoyu2UpdateDtColIndex = 572;
        // 更新日(検査台帳明細(ヘキサン抽出物質（動植物油類）1))
        private const int hekisanDoshoku1UpdateDtColIndex = 573;
        // 更新日(検査台帳明細(ヘキサン抽出物質（動植物油類）2))
        private const int hekisanDoshoku2UpdateDtColIndex = 574;
        // 更新日(検査台帳明細(ヘキサン抽出物質（B）1))
        private const int hekisanB1UpdateDtColIndex = 575;
        // 更新日(検査台帳明細(ヘキサン抽出物質（B）2))
        private const int hekisanB2UpdateDtColIndex = 576;
        // 更新日(検査台帳明細(鉛1))
        private const int namari1UpdateDtColIndex = 577;
        // 更新日(検査台帳明細(鉛2))
        private const int namari2UpdateDtColIndex = 578;
        // 更新日(検査台帳明細(亜鉛1))
        private const int aen1UpdateDtColIndex = 579;
        // 更新日(検査台帳明細(亜鉛2))
        private const int aen2UpdateDtColIndex = 580;
        // 更新日(検査台帳明細(ほう素1))
        private const int houso1UpdateDtColIndex = 581;
        // 更新日(検査台帳明細(ほう素2))
        private const int houso2UpdateDtColIndex = 582;
        // 更新日(検査台帳明細(残塩1))
        private const int zanen1UpdateDtColIndex = 583;
        // 更新日(検査台帳明細(残塩2))
        private const int zanen2UpdateDtColIndex = 584;
        // 更新日(検査台帳明細(外観1))
        private const int gaikan1UpdateDtColIndex = 585;
        // 更新日(検査台帳明細(外観2))
        private const int gaikan2UpdateDtColIndex = 586;
        // 更新日(検査台帳明細(臭気1))
        private const int shuki1UpdateDtColIndex = 587;
        // 更新日(検査台帳明細(臭気2))
        private const int shuki2UpdateDtColIndex = 588;
        // 更新日(検査台帳明細(透視度1))
        private const int tr1UpdateDtColIndex = 589;
        // 更新日(検査台帳明細(透視度2))
        private const int tr2UpdateDtColIndex = 590;
        // 更新日(検査台帳明細(亜硝酸性窒素（定性）1))
        private const int no2nTeisei1UpdateDtColIndex = 591;
        // 更新日(検査台帳明細(亜硝酸性窒素（定性）2))
        private const int no2nTeisei2UpdateDtColIndex = 592;
        // 更新日(検査台帳明細(硝酸性窒素（定性）1))
        private const int no3nTeisei1UpdateDtColIndex = 593;
        // 更新日(検査台帳明細(硝酸性窒素（定性）2))
        private const int no3nTeisei2UpdateDtColIndex = 594;
        // 更新日(検査台帳明細(大腸菌群数1))
        private const int daichokin1UpdateDtColIndex = 595;
        // 更新日(検査台帳明細(大腸菌群数2))
        private const int daichokin2UpdateDtColIndex = 596;
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
        /// 2014/12/08  宗    　    新規作成
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
        /// 2014/12/08  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region UpdateAllDtl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateAllDtl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateAllDtl(DataGridViewRow dgvr, int index, int updateDt1Index, int updateDt2Index, string kmkCd, IKakuteiBtnClickALInput input, bool noVal = true)
        {
            #region データ更新４の初回分
            // 結果入力済みの場合にのみ更新
            if (dgvr.Cells[index + 5].Value.ToString() == "1")
            {
                // 検索
                IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                blInput.Kbn = "1";
                blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                blInput.Sisho = dgvr.Cells[shishoCdIndex].Value.ToString();
                blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                blInput.ShikenkoumokuCd = kmkCd;
                blInput.SaikensaKbn = "0";
                IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                // 楽観チェック
                string preDateTime = dgvr.Cells[updateDt1Index].Value != null ? dgvr.Cells[updateDt1Index].Value.ToString() : string.Empty;
                if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }
                // 編集＆更新
                IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                // 確認検査種別
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[index + 2].Value.ToString();
                // 確認検査種別（過去との比較）
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[index + 4].Value.ToString();
                if (noVal)
                {
                    // 結果値
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[index].Value.ToString());
                }
                // 結果コード
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[index + 1].Value.ToString();
                // 採用区分
                //20150106
                if (dgvr.Cells[index + 3].Value.ToString() == CheckOn)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                }
                if (dgvr.Cells[index + 3].Value.ToString() == CheckOff)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                }

                // 確認検査種別（SS/透視度）
                if (index == ss1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuSsTr = dgvr.Cells[ss1KensaShubetsuSsTrIndex].Value.ToString();
                }
                if (index == tr1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuSsTr = dgvr.Cells[tr1KensaShubetsuSsTrIndex].Value.ToString();
                }

                // 確認検査種別（BOD/透視度）
                if (index == bodA1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[bodA1KensaShubetsuBodTrIndex].Value.ToString();
                }
                else if (index == bodB1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[bodB1KensaShubetsuBodTrIndex].Value.ToString();
                }
                else if (index == tr1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[tr1KensaShubetsuBodTrIndex].Value.ToString();
                }

                // 塩化物イオン確認検査
                if (index == cl1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuEnkaIon = dgvr.Cells[cl1KensaShubetsuEnkaIonIndex].Value.ToString();
                }

                // アンモニア確認検査
                if (index == nh4n1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmonia = dgvr.Cells[nh4n1KensaShubetsuAnmoniaIndex].Value.ToString();
                }

                // アンモニアと全窒素の比較
                if (index == nh4n1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = dgvr.Cells[nh4n1KensaShubetsuAnmoniaTnIndex].Value.ToString();
                }
                if (index == tnA1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = dgvr.Cells[tnA1KensaShubetsuAnmoniaTnIndex].Value.ToString();
                }
                if (index == tnB1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = dgvr.Cells[tnB1KensaShubetsuAnmoniaTnIndex].Value.ToString();
                }

                // COD基準値オーバー
                if(index == cod1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuCodOver = dgvr.Cells[cod1KensaShubetsuCodOverIndex].Value.ToString();
                }
                
                // 更新日時
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                // 更新者
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                // 更新端末
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);
            }
            #endregion

            #region データ更新４の再検査分
            // 結果入力済みの場合にのみ更新
            if (dgvr.Cells[index + 11].Value.ToString() == "1")
            {
                // 検索
                IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                blInput.Kbn = "1";
                blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                blInput.Sisho = dgvr.Cells[shishoCdIndex].Value.ToString();
                blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                blInput.ShikenkoumokuCd = kmkCd;
                blInput.SaikensaKbn = "1";
                IGetKensaDaichoDtlTblByKeyBLOutput blOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(blInput);
                // 楽観チェック
                string preDateTime = dgvr.Cells[updateDt2Index].Value != null ? dgvr.Cells[updateDt2Index].Value.ToString() : string.Empty;
                if (preDateTime != blOutput.KensaDaichoDtlTblDT[0].UpdateDt.ToString())
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }
                // 編集＆更新
                IUpdateKensaDaichoDtlTblBLInput kensaDaichoDtlTblInput = new UpdateKensaDaichoDtlTblBLInput();
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT = blOutput.KensaDaichoDtlTblDT;

                // 確認検査種別
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsu = dgvr.Cells[index + 8].Value.ToString();
                // 確認検査種別（過去との比較）
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = dgvr.Cells[index + 10].Value.ToString();
                if (noVal)
                {
                    // 結果値
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[index + 6].Value.ToString());
                }
                // 結果コード
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[index + 7].Value.ToString();
                // 採用区分
                if (dgvr.Cells[index + 9].Value.ToString() == CheckOn)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "1";
                }
                if (dgvr.Cells[index + 9 ].Value.ToString() == CheckOff)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";
                }

                // 確認検査種別（SS/透視度）
                if (index == ss1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuSsTr = dgvr.Cells[ss2KensaShubetsuSsTrIndex].Value.ToString();
                }
                if (index == tr1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuSsTr = dgvr.Cells[tr2KensaShubetsuSsTrIndex].Value.ToString();
                }

                // 確認検査種別（BOD/透視度）
                if (index == bodA1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[bodA2KensaShubetsuBodTrIndex].Value.ToString();
                }
                else if (index == bodB1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[bodB2KensaShubetsuBodTrIndex].Value.ToString();
                }
                else if (index == tr1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = dgvr.Cells[tr2KensaShubetsuBodTrIndex].Value.ToString();
                }

                // 塩化物イオン確認検査
                if (index == cl1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuEnkaIon = dgvr.Cells[cl2KensaShubetsuEnkaIonIndex].Value.ToString();
                }

                // アンモニア確認検査
                if (index == nh4n1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmonia = dgvr.Cells[nh4n2KensaShubetsuAnmoniaIndex].Value.ToString();
                }

                // アンモニアと全窒素の比較
                if (index == nh4n1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = dgvr.Cells[nh4n2KensaShubetsuAnmoniaTnIndex].Value.ToString();
                }
                if (index == tnA1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = dgvr.Cells[tnA2KensaShubetsuAnmoniaTnIndex].Value.ToString();
                }
                if (index == tnB1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = dgvr.Cells[tnB2KensaShubetsuAnmoniaTnIndex].Value.ToString();
                }

                // COD基準値オーバー
                if (index == cod1ColIndex)
                {
                    kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KensaShubetsuCodOver = dgvr.Cells[cod2KensaShubetsuCodOverIndex].Value.ToString();
                }

                // 更新日時
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateDt = input.UpdateDt;
                // 更新者
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateUser = input.UpdateUser;
                // 更新端末
                kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].UpdateTarm = input.UpdateTarm;

                new UpdateKensaDaichoDtlTblBusinessLogic().Execute(kensaDaichoDtlTblInput);
            }
            #endregion
        }
        #endregion

        #region UpdateAllKekka
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateAllKekka
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void UpdateAllKekka(DataGridViewRow dgvr, int index, int updateDtIndex, string kmkCd, IKakuteiBtnClickALInput input, bool noVal = true)
        {
            #region データ更新６

            // 検索
            IGetKeiryoShomeiKekkaTblByKeyBLInput blInput = new GetKeiryoShomeiKekkaTblByKeyBLInput();
            blInput.KeiryoShomeiKekkaIraiNendo = dgvr.Cells[keiryoShomeiIraiNendoColIndex].Value.ToString();
            blInput.KeiryoShomeiKekkaIraiShishoCd = dgvr.Cells[keiryoShomeiIraiSishoCdColIndex].Value.ToString();
            blInput.KeiryoShomeiKekkaIraiNo = dgvr.Cells[keiryoShomeiIraiRenbanColIndex].Value.ToString();
            blInput.KeiryoShomeiShikenkoumokuCd = kmkCd;
            IGetKeiryoShomeiKekkaTblByKeyBLOutput blOutput = new GetKeiryoShomeiKekkaTblByKeyBusinessLogic().Execute(blInput);
            // 楽観チェック
            string preDateTime = dgvr.Cells[updateDtIndex].Value != null ? dgvr.Cells[updateDtIndex].Value.ToString() : string.Empty;
            if (preDateTime != blOutput.KeiryoShomeiKekkaTblDT[0].UpdateDt.ToString())
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }
            // 編集＆更新
            IUpdateKeiryoShomeiKekkaTblBLInput kekkaInput = new UpdateKeiryoShomeiKekkaTblBLInput();
            kekkaInput.KeiryoShomeiKekkaTblDT = blOutput.KeiryoShomeiKekkaTblDT;

            if (dgvr.Cells[index + 3].Value.ToString() == CheckOn)
            {
                if (noVal) // 亜硝酸性窒素（定性）か硝酸性窒素（定性）の場合は除外
                {
                    kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[index].Value.ToString());
                }
                kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[index + 1].Value.ToString();
                kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValueHyojiyo
                    = KensaHanteiUtility.HyojiKetasuHosei(kmkCd, dgvr.Cells[index].Value.ToString());
            }
            else if (dgvr.Cells[index + 9].Value.ToString() == CheckOn)
            {
                if (noVal) // 亜硝酸性窒素（定性）か硝酸性窒素（定性）の場合は除外
                {
                    kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[index + 6].Value.ToString());
                }
                kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[index + 7].Value.ToString();
                kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValueHyojiyo
                    = KensaHanteiUtility.HyojiKetasuHosei(kmkCd, dgvr.Cells[index + 6].Value.ToString());
            }
            // 更新日時
            kekkaInput.KeiryoShomeiKekkaTblDT[0].UpdateDt = input.UpdateDt;
            // 更新者
            kekkaInput.KeiryoShomeiKekkaTblDT[0].UpdateUser = input.UpdateUser;
            // 更新端末
            kekkaInput.KeiryoShomeiKekkaTblDT[0].UpdateTarm = input.UpdateTarm;

            new UpdateKeiryoShomeiKekkaTblBusinessLogic().Execute(kekkaInput);

            #endregion
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
        /// 2014/12/08  宗    　    新規作成
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
                    // 検査台帳ヘッダ
                    updt[rowCnt, (int)UpdateDt.hdrUpdateDtCol] = dgvr.Cells[hdrUpdateDtColIndex].Value.ToString();
                    // 計量証明依頼テーブル
                    updt[rowCnt, (int)UpdateDt.iraiUpdateDtCol] = dgvr.Cells[iraiUpdateDtColIndex].Value.ToString();
                    // 計量証明結果テーブル
                    updt[rowCnt, (int)UpdateDt.phKekkaUpdateDtCol] = dgvr.Cells[phKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.ssKekkaUpdateDtCol] = dgvr.Cells[ssKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bodAKekkaUpdateDtCol] = dgvr.Cells[bodAKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.nh4nKekkaUpdateDtCol] = dgvr.Cells[nh4nKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.clKekkaUpdateDtCol] = dgvr.Cells[clKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.codKekkaUpdateDtCol] = dgvr.Cells[codKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanAKekkaUpdateDtCol] = dgvr.Cells[hekisanAKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.mlssKekkaUpdateDtCol] = dgvr.Cells[mlssKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tnAKekkaUpdateDtCol] = dgvr.Cells[tnAKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.absAKekkaUpdateDtCol] = dgvr.Cells[absAKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tpAKekkaUpdateDtCol] = dgvr.Cells[tpAKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.rinsanKekkaUpdateDtCol] = dgvr.Cells[rinsanKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no2nTeiryoKekkaUpdateDtCol] = dgvr.Cells[no2nTeiryoKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no3nTeiryoKekkaUpdateDtCol] = dgvr.Cells[no3nTeiryoKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.absBKekkaUpdateDtCol] = dgvr.Cells[absBKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tnBKekkaUpdateDtCol] = dgvr.Cells[tnBKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tpBKekkaUpdateDtCol] = dgvr.Cells[tpBKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.shikidoKekkaUpdateDtCol] = dgvr.Cells[shikidoKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bodBKekkaUpdateDtCol] = dgvr.Cells[bodBKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanKoyuKekkaUpdateDtCol] = dgvr.Cells[hekisanKoyuKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanDoshokuKekkaUpdateDtCol] = dgvr.Cells[hekisanDoshokuKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanBKekkaUpdateDtCol] = dgvr.Cells[hekisanBKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.namariKekkaUpdateDtCol] = dgvr.Cells[namariKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.aenKekkaUpdateDtCol] = dgvr.Cells[aenKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.housoKekkaUpdateDtCol] = dgvr.Cells[housoKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.zanenKekkaUpdateDtCol] = dgvr.Cells[zanenKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.gaikanKekkaUpdateDtCol] = dgvr.Cells[gaikanKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.shukiKekkaUpdateDtCol] = dgvr.Cells[shukiKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.trKekkaUpdateDtCol] = dgvr.Cells[trKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no2nTeiseiKekkaUpdateDtCol] = dgvr.Cells[no2nTeiseiKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no3nTeiseiKekkaUpdateDtCol] = dgvr.Cells[no3nTeiseiKekkaUpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.daichokinKekkaUpdateDtCol] = dgvr.Cells[daichokinKekkaUpdateDtColIndex].Value.ToString();
                    // 検査台帳明細
                    updt[rowCnt, (int)UpdateDt.ph1UpdateDtCol] = dgvr.Cells[ph1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.ph2UpdateDtCol] = dgvr.Cells[ph2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.ss1UpdateDtCol] = dgvr.Cells[ss1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.ss2UpdateDtCol] = dgvr.Cells[ss2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bodA1UpdateDtCol] = dgvr.Cells[bodA1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bodA2UpdateDtCol] = dgvr.Cells[bodA2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.nh4n1UpdateDtCol] = dgvr.Cells[nh4n1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.nh4n2UpdateDtCol] = dgvr.Cells[nh4n2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.cl1UpdateDtCol] = dgvr.Cells[cl1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.cl2UpdateDtCol] = dgvr.Cells[cl2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.cod1UpdateDtCol] = dgvr.Cells[cod1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.cod2UpdateDtCol] = dgvr.Cells[cod2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanA1UpdateDtCol] = dgvr.Cells[hekisanA1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanA2UpdateDtCol] = dgvr.Cells[hekisanA2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.mlss1UpdateDtCol] = dgvr.Cells[mlss1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.mlss2UpdateDtCol] = dgvr.Cells[mlss2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tnA1UpdateDtCol] = dgvr.Cells[tnA1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tnA2UpdateDtCol] = dgvr.Cells[tnA2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.absA1UpdateDtCol] = dgvr.Cells[absA1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.absA2UpdateDtCol] = dgvr.Cells[absA2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tpA1UpdateDtCol] = dgvr.Cells[tpA1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tpA2UpdateDtCol] = dgvr.Cells[tpA2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.rinsan1UpdateDtCol] = dgvr.Cells[rinsan1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.rinsan2UpdateDtCol] = dgvr.Cells[rinsan2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no2nTeiryo1UpdateDtCol] = dgvr.Cells[no2nTeiryo1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no2nTeiryo2UpdateDtCol] = dgvr.Cells[no2nTeiryo2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no3nTeiryo1UpdateDtCol] = dgvr.Cells[no3nTeiryo1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no3nTeiryo2UpdateDtCol] = dgvr.Cells[no3nTeiryo2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.absB1UpdateDtCol] = dgvr.Cells[absB1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.absB2UpdateDtCol] = dgvr.Cells[absB2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tnB1UpdateDtCol] = dgvr.Cells[tnB1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tnB2UpdateDtCol] = dgvr.Cells[tnB2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tpB1UpdateDtCol] = dgvr.Cells[tpB1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tpB2UpdateDtCol] = dgvr.Cells[tpB2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.shikido1UpdateDtCol] = dgvr.Cells[shikido1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.shikido2UpdateDtCol] = dgvr.Cells[shikido2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bodB1UpdateDtCol] = dgvr.Cells[bodB1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.bodB2UpdateDtCol] = dgvr.Cells[bodB2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanKoyu1UpdateDtCol] = dgvr.Cells[hekisanKoyu1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanKoyu2UpdateDtCol] = dgvr.Cells[hekisanKoyu2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanDoshoku1UpdateDtCol] = dgvr.Cells[hekisanDoshoku1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanDoshoku2UpdateDtCol] = dgvr.Cells[hekisanDoshoku2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanB1UpdateDtCol] = dgvr.Cells[hekisanB1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.hekisanB2UpdateDtCol] = dgvr.Cells[hekisanB2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.namari1UpdateDtCol] = dgvr.Cells[namari1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.namari2UpdateDtCol] = dgvr.Cells[namari2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.aen1UpdateDtCol] = dgvr.Cells[aen1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.aen2UpdateDtCol] = dgvr.Cells[aen2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.houso1UpdateDtCol] = dgvr.Cells[houso1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.houso2UpdateDtCol] = dgvr.Cells[houso2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.zanen1UpdateDtCol] = dgvr.Cells[zanen1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.zanen2UpdateDtCol] = dgvr.Cells[zanen2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.gaikan1UpdateDtCol] = dgvr.Cells[gaikan1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.gaikan2UpdateDtCol] = dgvr.Cells[gaikan2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.shuki1UpdateDtCol] = dgvr.Cells[shuki1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.shuki2UpdateDtCol] = dgvr.Cells[shuki2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tr1UpdateDtCol] = dgvr.Cells[tr1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.tr2UpdateDtCol] = dgvr.Cells[tr2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no2nTeisei1UpdateDtCol] = dgvr.Cells[no2nTeisei1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no2nTeisei2UpdateDtCol] = dgvr.Cells[no2nTeisei2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no3nTeisei1UpdateDtCol] = dgvr.Cells[no3nTeisei1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.no3nTeisei2UpdateDtCol] = dgvr.Cells[no3nTeisei2UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.daichokin1UpdateDtCol] = dgvr.Cells[daichokin1UpdateDtColIndex].Value.ToString();
                    updt[rowCnt, (int)UpdateDt.daichokin2UpdateDtCol] = dgvr.Cells[daichokin2UpdateDtColIndex].Value.ToString();
                    #endregion

                    #region 「計量証明依頼テーブル」の更新
                    if (dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOn
                        && dgvr.Cells[hukukachoKeninColIndex].Value.ToString() == CheckOn
                        && dgvr.Cells[kanrishaKeninColIndex].Value.ToString() == CheckOn
                        )
                    {
                        #region データ更新１

                        // 検索
                        IGetKeiryoShomeiIraiTblByKeyBLInput blInput = new GetKeiryoShomeiIraiTblByKeyBLInput();
                        blInput.KeiryoShomeiIraiNendo = dgvr.Cells[keiryoShomeiIraiNendoColIndex].Value.ToString();
                        blInput.KeiryoShomeiIraiSishoCd = dgvr.Cells[keiryoShomeiIraiSishoCdColIndex].Value.ToString();
                        blInput.KeiryoShomeiIraiRenban = dgvr.Cells[keiryoShomeiIraiRenbanColIndex].Value.ToString();
                        IGetKeiryoShomeiIraiTblByKeyBLOutput blOutput = new GetKeiryoShomeiIraiTblByKeyBusinessLogic().Execute(blInput);
                        // 楽観チェック
                        string preDateTime = dgvr.Cells[iraiUpdateDtColIndex].Value != null ? dgvr.Cells[iraiUpdateDtColIndex].Value.ToString() : string.Empty;
                        if (preDateTime != blOutput.KeiryoShomeiIraiTblDT[0].UpdateDt.ToString())
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }
                        // 編集＆更新
                        IUpdateKeiryoShomeiIraiTblBLInput iraiInput = new UpdateKeiryoShomeiIraiTblBLInput();
                        iraiInput.KeiryoShomeiIraiTblDT = blOutput.KeiryoShomeiIraiTblDT;

                        // ステータス区分
                        iraiInput.KeiryoShomeiIraiTblDT[0].KeiryoShomeiStatusKbn = "70";

                        // 更新日時
                        iraiInput.KeiryoShomeiIraiTblDT[0].UpdateDt = input.UpdateDt;
                        // 更新者
                        iraiInput.KeiryoShomeiIraiTblDT[0].UpdateUser = input.UpdateUser;
                        // 更新端末
                        iraiInput.KeiryoShomeiIraiTblDT[0].UpdateTarm = input.UpdateTarm;

                        new UpdateKeiryoShomeiIraiTblBusinessLogic().Execute(iraiInput);

                        // 更新日の更新
                        updt[rowCnt, (int)UpdateDt.iraiUpdateDtCol] = input.UpdateDt.ToString();
                        #endregion
                    }
                    #endregion

                    #region「検査台帳（9条）ヘッダテーブル」の更新
                    if(dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")
                    {
                        #region データ更新２

                        // 検索
                        IGetKensaDaicho9joHdrTblByKeyBLInput blInput = new GetKensaDaicho9joHdrTblByKeyBLInput();
                        blInput.IraiNendo = dgvr.Cells[keiryoShomeiIraiNendoColIndex].Value.ToString();
                        blInput.ShishoCd = dgvr.Cells[keiryoShomeiIraiSishoCdColIndex].Value.ToString();
                        blInput.SuishitsuKensaIraiNo = dgvr.Cells[keiryoShomeiIraiRenbanColIndex].Value.ToString();
                        IGetKensaDaicho9joHdrTblByKeyBLOutput blOutput = new GetKensaDaicho9joHdrTblByKeyBusinessLogic().Execute(blInput);
                        // 楽観チェック
                        string preDateTime = dgvr.Cells[hdrUpdateDtColIndex].Value != null ? dgvr.Cells[hdrUpdateDtColIndex].Value.ToString() : string.Empty;
                        if (preDateTime != blOutput.KensaDaicho9joHdrDT[0].UpdateDt.ToString())
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }
                        // 編集＆更新
                        IUpdateKensaDaicho9joHdrTblBLInput hdrInput = new UpdateKensaDaicho9joHdrTblBLInput();
                        hdrInput.KensaDaicho9joHdrTblDataTable = blOutput.KensaDaicho9joHdrDT;

                        // 課長検印区分
                        if(dgvr.Cells[kachoKeninColIndex].Value.ToString() == CheckOn)
                        {
                            hdrInput.KensaDaicho9joHdrTblDataTable[0].KachoKeninKbn = "1";
                        }
                        else
                        {
                            hdrInput.KensaDaicho9joHdrTblDataTable[0].KachoKeninKbn = "0";
                        }
                        // 副課長検印区分
                        if (dgvr.Cells[hukukachoKeninColIndex].Value.ToString() == CheckOn)
                        {
                            hdrInput.KensaDaicho9joHdrTblDataTable[0].HukuKachoKeninKbn = "1";
                        }
                        else
                        {
                            hdrInput.KensaDaicho9joHdrTblDataTable[0].HukuKachoKeninKbn = "0";
                        }
                        // 計量管理者検印区分
                        if (dgvr.Cells[kanrishaKeninColIndex].Value.ToString() == CheckOn)
                        {
                            hdrInput.KensaDaicho9joHdrTblDataTable[0].KeiryoKanrishaKeninKbn = "1";
                        }
                        else
                        {
                            hdrInput.KensaDaicho9joHdrTblDataTable[0].KeiryoKanrishaKeninKbn = "0";
                        }

                        // 更新日時
                        hdrInput.KensaDaicho9joHdrTblDataTable[0].UpdateDt = input.UpdateDt;
                        // 更新者
                        hdrInput.KensaDaicho9joHdrTblDataTable[0].UpdateUser = input.UpdateUser;
                        // 更新端末
                        hdrInput.KensaDaicho9joHdrTblDataTable[0].UpdateTarm = input.UpdateTarm;

                        new UpdateKensaDaicho9joHdrTblBusinessLogic().Execute(hdrInput);

                        // 更新日の更新
                        updt[rowCnt, (int)UpdateDt.hdrUpdateDtCol] = input.UpdateDt.ToString();
                        #endregion
                    }
                    #endregion

                    #region「検査台帳明細テーブル」の更新
                    if ((dgvr.Cells[koshinKbnPhIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoPhIndex].Value.ToString() == "1"))
                    {
                        // pHの変更結果を反映する
                        #region データ更新３の初回分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuPh1ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = "1";
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue(kmkKbn, "001");
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
                            // 結果コード
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[ph1KekkaCdColIndex].Value.ToString();
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
                        }
                        #endregion

                        #region データ更新３の再検査分
                        // 結果入力済みの場合にのみ更新
                        if (dgvr.Cells[kekkaNyuryokuPh2ColIndex].Value.ToString() == "1")
                        {
                            // 検索
                            IGetKensaDaichoDtlTblByKeyBLInput blInput = new GetKensaDaichoDtlTblByKeyBLInput();
                            blInput.Kbn = "1";
                            blInput.IraiNendo = dgvr.Cells[iraiNendoColIndex].Value.ToString();
                            blInput.Sisho = dgvr.Cells[shishoCdIndex].Value.ToString();
                            blInput.IraiNo = dgvr.Cells[iraiNoColIndex].Value.ToString();
                            blInput.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue(kmkKbn, "001");
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
                            // 結果コード
                            kensaDaichoDtlTblInput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[ph2KekkaCdColIndex].Value.ToString();
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
                            updt[rowCnt, (int)UpdateDt.ph2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        #endregion
                    }

                    #region データ更新４
                    // SS
                    if ((dgvr.Cells[koshinKbnSsIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnSsTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoSsIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, ss1ColIndex, ss1UpdateDtColIndex, ss2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "002"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuSs1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.ss1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuSs2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.ss2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // BOD（A）
                    if ((dgvr.Cells[koshinKbnBodAIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoBodAIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, bodA1ColIndex, bodA1UpdateDtColIndex, bodA2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "003"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuBodA1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.bodA1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuBodA2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.bodA2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // アンモニア性窒素
                    if ((dgvr.Cells[koshinKbnNh4nIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnAnmoniaIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnAnmoniaTnIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoNh4nIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, nh4n1ColIndex, nh4n1UpdateDtColIndex, nh4n2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "004"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuNh4n1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.nh4n1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuNh4n2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.nh4n2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 塩化物イオン
                    if ((dgvr.Cells[koshinKbnClIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnEnkaIonIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoClIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, cl1ColIndex, cl1UpdateDtColIndex, cl2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "005"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuCl1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.cl1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuCl2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.cl2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // COD
                    if ((dgvr.Cells[koshinKbnCodIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnCodOverIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoCodIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, cod1ColIndex, cod1UpdateDtColIndex, cod2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "006"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuCod1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.cod1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuCod2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.cod2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // ヘキサン抽出物質（A）
                    if ((dgvr.Cells[koshinKbnHekisanAIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoHekisanAIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, hekisanA1ColIndex, hekisanA1UpdateDtColIndex, hekisanA2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "007"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuHekisanA1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanA1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuHekisanA2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanA2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // MLSS
                    if ((dgvr.Cells[koshinKbnMlssIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoMlssIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, mlss1ColIndex, mlss1UpdateDtColIndex, mlss2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "008"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuMlss1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.mlss1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuMlss2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.mlss2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 全窒素（A)
                    if ((dgvr.Cells[koshinKbnTnAIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnAnmoniaTnIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoTnAIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, tnA1ColIndex, tnA1UpdateDtColIndex, tnA2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "009"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuTnA1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tnA1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuTnA2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tnA2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 陰イオン界面活性剤（A）
                    if ((dgvr.Cells[koshinKbnAbsAIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoAbsAIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, absA1ColIndex, absA1UpdateDtColIndex, absA2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "010"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuAbsA1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.absA1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuAbsA2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.absA2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 全りん（A)
                    if ((dgvr.Cells[koshinKbnTpAIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoTpAIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, tpA1ColIndex, tpA1UpdateDtColIndex, tpA2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "011"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuTpA1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tpA1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuTpA2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tpA2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // りん酸イオン
                    if ((dgvr.Cells[koshinKbnRinsanIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoRinsanIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, rinsan1ColIndex, rinsan1UpdateDtColIndex, rinsan2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "012"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuRinsan1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.rinsan1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuRinsan2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.rinsan2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 亜硝酸性窒素（定量）
                    if ((dgvr.Cells[koshinKbnNo2nTeiryoIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoNo2nTeiryoIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, no2nTeiryo1ColIndex, no2nTeiryo1UpdateDtColIndex, no2nTeiryo2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "013"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuNo2nTeiryo1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no2nTeiryo1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuNo2nTeiryo2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no2nTeiryo2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 硝酸性窒素（定量）
                    if ((dgvr.Cells[koshinKbnNo3nTeiryoIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoNo3nTeiryoIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, no3nTeiryo1ColIndex, no3nTeiryo1UpdateDtColIndex, no3nTeiryo2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "014"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuNo3nTeiryo1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no3nTeiryo1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuNo3nTeiryo2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no3nTeiryo2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 陰イオン界面活性剤（B)
                    if ((dgvr.Cells[koshinKbnAbsBIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoAbsBIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, absB1ColIndex, absB1UpdateDtColIndex, absB2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "015"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuAbsB1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.absB1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuAbsB2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.absB2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 全窒素（B)
                    if ((dgvr.Cells[koshinKbnTnBIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnAnmoniaTnIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoTnBIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, tnB1ColIndex, tnB1UpdateDtColIndex, tnB2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "016"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuTnB1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tnB1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuTnB2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tnB2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 全りん（B)
                    if ((dgvr.Cells[koshinKbnTpBIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoTpBIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, tpB1ColIndex, tpB1UpdateDtColIndex, tpB2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "017"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuTpB1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tpB1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuTpB2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tpB2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 色度
                    if ((dgvr.Cells[koshinKbnShikidoIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoShikidoIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, shikido1ColIndex, shikido1UpdateDtColIndex, shikido2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "018"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuShikido1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.shikido1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuShikido2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.shikido2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // BOD（B）
                    if ((dgvr.Cells[koshinKbnBodBIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoBodBIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, bodB1ColIndex, bodB1UpdateDtColIndex, bodB2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "019"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuBodB1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.bodB1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuBodB2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.bodB2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // ヘキサン抽出物質（鉱油類）
                    if ((dgvr.Cells[koshinKbnHekisanKoyuIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoHekisanKoyuIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, hekisanKoyu1ColIndex, hekisanKoyu1UpdateDtColIndex, hekisanKoyu2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "020"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuHekisanKoyu1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanKoyu1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuHekisanKoyu2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanKoyu2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // ヘキサン抽出物質（動植物油類）
                    if ((dgvr.Cells[koshinKbnHekisanDoshokuIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoHekisanDoshokuIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, hekisanDoshoku1ColIndex, hekisanDoshoku1UpdateDtColIndex, hekisanDoshoku2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "021"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuHekisanDoshoku1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanDoshoku1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuHekisanDoshoku2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanDoshoku2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // ヘキサン抽出物質（B）
                    if ((dgvr.Cells[koshinKbnHekisanBIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoHekisanBIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, hekisanB1ColIndex, hekisanB1UpdateDtColIndex, hekisanB2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "022"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuHekisanB1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanB1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuHekisanB2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.hekisanB2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 鉛
                    if ((dgvr.Cells[koshinKbnNamariIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoNamariIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, namari1ColIndex, namari1UpdateDtColIndex, namari2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "023"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuAen1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.aen1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuAen2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.aen2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 亜鉛
                    if ((dgvr.Cells[koshinKbnAenIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoAenIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, aen1ColIndex, aen1UpdateDtColIndex, aen2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "024"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuAen1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.aen1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuAen2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.aen2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // ほう素
                    if ((dgvr.Cells[koshinKbnHousoIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoHousoIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, houso1ColIndex, houso1UpdateDtColIndex, houso2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "025"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuHouso1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.houso1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuHouso2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.houso2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 残塩
                    if ((dgvr.Cells[koshinKbnZanenIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoZanenIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, zanen1ColIndex, zanen1UpdateDtColIndex, zanen2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "026"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuZanen1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.zanen1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuZanen2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.zanen2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 外観
                    if ((dgvr.Cells[koshinKbnGaikanIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoGaikanIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, gaikan1ColIndex, gaikan1UpdateDtColIndex, gaikan2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "027"), input, false);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuGaikan1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.gaikan1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuGaikan2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.gaikan2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 臭気
                    if ((dgvr.Cells[koshinKbnShukiIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoShukiIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, shuki1ColIndex, shuki1UpdateDtColIndex, shuki2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "028"), input, false);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuShuki1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.shuki1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuShuki2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.shuki2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 透視度
                    if ((dgvr.Cells[koshinKbnTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnBodTrIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoTrIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, tr1ColIndex, tr1UpdateDtColIndex, tr2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "029"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuTr1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tr1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuTr2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.tr2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 亜硝酸性窒素（定性）
                    if ((dgvr.Cells[koshinKbnNo2nTeiseiIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoNo2nTeiseiIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, no2nTeisei1ColIndex, no2nTeisei1UpdateDtColIndex, no2nTeisei2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "030"), input, false);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuNo2nTeisei1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no2nTeisei1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuNo2nTeisei2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no2nTeisei2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 硝酸性窒素（定性）
                    if ((dgvr.Cells[koshinKbnNo3nTeiseiIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoNo3nTeiseiIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, no3nTeisei1ColIndex, no3nTeisei1UpdateDtColIndex, no3nTeisei2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "031"), input, false);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuNo3nTeisei1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no3nTeisei1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuNo3nTeisei2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.no3nTeisei2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    // 大腸菌群数
                    if ((dgvr.Cells[koshinKbnDaichokinIndex].Value.ToString() == "1")
                        || (dgvr.Cells[koshinKbnKakoDaichokinIndex].Value.ToString() == "1"))
                    {
                        UpdateAllDtl(dgvr, daichokin1ColIndex, daichokin1UpdateDtColIndex, daichokin2UpdateDtColIndex,
                            Boundary.Common.Common.GetConstValue(kmkKbn, "032"), input);
                        // 更新日の更新
                        if (dgvr.Cells[kekkaNyuryokuDaichokin1ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.daichokin1UpdateDtCol] = input.UpdateDt.ToString();
                        }
                        if (dgvr.Cells[kekkaNyuryokuDaichokin2ColIndex].Value.ToString() == "1")
                        {
                            updt[rowCnt, (int)UpdateDt.daichokin2UpdateDtCol] = input.UpdateDt.ToString();
                        }
                    }

                    #endregion

                    #endregion

                    #region「計量証明結果テーブル」の更新

                    // pH
                    if ((dgvr.Cells[koshinKbnPhIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuPh1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        #region データ更新５

                        // 検索
                        IGetKeiryoShomeiKekkaTblByKeyBLInput blInput = new GetKeiryoShomeiKekkaTblByKeyBLInput();
                        blInput.KeiryoShomeiKekkaIraiNendo = dgvr.Cells[keiryoShomeiIraiNendoColIndex].Value.ToString();
                        blInput.KeiryoShomeiKekkaIraiShishoCd = dgvr.Cells[keiryoShomeiIraiSishoCdColIndex].Value.ToString();
                        blInput.KeiryoShomeiKekkaIraiNo = dgvr.Cells[keiryoShomeiIraiRenbanColIndex].Value.ToString();
                        blInput.KeiryoShomeiShikenkoumokuCd = Boundary.Common.Common.GetConstValue(kmkKbn, "001");
                        IGetKeiryoShomeiKekkaTblByKeyBLOutput blOutput = new GetKeiryoShomeiKekkaTblByKeyBusinessLogic().Execute(blInput);
                        // 楽観チェック
                        string preDateTime = dgvr.Cells[phKekkaUpdateDtColIndex].Value != null ? dgvr.Cells[phKekkaUpdateDtColIndex].Value.ToString() : string.Empty;
                        if (preDateTime != blOutput.KeiryoShomeiKekkaTblDT[0].UpdateDt.ToString())
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }
                        // 編集＆更新
                        IUpdateKeiryoShomeiKekkaTblBLInput kekkaInput = new UpdateKeiryoShomeiKekkaTblBLInput();
                        kekkaInput.KeiryoShomeiKekkaTblDT = blOutput.KeiryoShomeiKekkaTblDT;

                        if (dgvr.Cells[saiyotiPh1ColIndex].Value.ToString() == CheckOn)
                        {
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[ph1ColIndex].Value.ToString());
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[ph1KekkaCdColIndex].Value.ToString();
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaOndo = double.Parse(dgvr.Cells[ondo1ColIndex].Value.ToString());
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValueHyojiyo 
                                = KensaHanteiUtility.HyojiKetasuHosei(Boundary.Common.Common.GetConstValue(kmkKbn, "001"), dgvr.Cells[ph1ColIndex].Value.ToString());
                        }
                        else if (dgvr.Cells[saiyotiPh2ColIndex].Value.ToString() == CheckOn)
                        {
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValue = decimal.Parse(dgvr.Cells[ph2ColIndex].Value.ToString());
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaCd = dgvr.Cells[ph2KekkaCdColIndex].Value.ToString();
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaOndo = double.Parse(dgvr.Cells[ondo2ColIndex].Value.ToString());
                            kekkaInput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValueHyojiyo
                                = KensaHanteiUtility.HyojiKetasuHosei(Boundary.Common.Common.GetConstValue(kmkKbn, "001"), dgvr.Cells[ph2ColIndex].Value.ToString());
                        }
                        // 更新日時
                        kekkaInput.KeiryoShomeiKekkaTblDT[0].UpdateDt = input.UpdateDt;
                        // 更新者
                        kekkaInput.KeiryoShomeiKekkaTblDT[0].UpdateUser = input.UpdateUser;
                        // 更新端末
                        kekkaInput.KeiryoShomeiKekkaTblDT[0].UpdateTarm = input.UpdateTarm;

                        new UpdateKeiryoShomeiKekkaTblBusinessLogic().Execute(kekkaInput);

                        // 更新日の更新
                        updt[rowCnt, (int)UpdateDt.phKekkaUpdateDtCol] = input.UpdateDt.ToString();
                        #endregion
                    }

                    #region データ更新６
                    // SS
                    if ((dgvr.Cells[koshinKbnSsIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuSs1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, ss1ColIndex, ssKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "002"), input);
                        updt[rowCnt, (int)UpdateDt.ssKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // BOD（A）
                    if ((dgvr.Cells[koshinKbnBodAIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuBodA1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, bodA1ColIndex, bodAKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "003"), input);
                        updt[rowCnt, (int)UpdateDt.bodAKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // アンモニア性窒素
                    if ((dgvr.Cells[koshinKbnNh4nIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuNh4n1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, nh4n1ColIndex, nh4nKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "004"), input);
                        updt[rowCnt, (int)UpdateDt.nh4nKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 塩化物イオン
                    if ((dgvr.Cells[koshinKbnClIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuCl1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, cl1ColIndex, clKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "005"), input);
                        updt[rowCnt, (int)UpdateDt.clKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // COD
                    if ((dgvr.Cells[koshinKbnCodIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuCod1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, cod1ColIndex, codKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "006"), input);
                        updt[rowCnt, (int)UpdateDt.codKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // ヘキサン抽出物質（A）
                    if ((dgvr.Cells[koshinKbnHekisanAIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuHekisanA1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, hekisanA1ColIndex, hekisanAKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "007"), input);
                        updt[rowCnt, (int)UpdateDt.hekisanAKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // MLSS
                    if ((dgvr.Cells[koshinKbnMlssIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuMlss1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, mlss1ColIndex, mlssKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "008"), input);
                        updt[rowCnt, (int)UpdateDt.mlssKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 全窒素（A)
                    if ((dgvr.Cells[koshinKbnTnAIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuTnA1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, tnA1ColIndex, tnAKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "009"), input);
                        updt[rowCnt, (int)UpdateDt.tnAKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 陰イオン界面活性剤（A）
                    if ((dgvr.Cells[koshinKbnAbsAIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuAbsA1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, absA1ColIndex, absAKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "010"), input);
                        updt[rowCnt, (int)UpdateDt.absAKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 全りん（A)
                    if ((dgvr.Cells[koshinKbnTpAIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuTpA1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, tpA1ColIndex, tpAKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "011"), input);
                        updt[rowCnt, (int)UpdateDt.tpAKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // りん酸イオン
                    if ((dgvr.Cells[koshinKbnRinsanIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuRinsan1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, rinsan1ColIndex, rinsanKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "012"), input);
                        updt[rowCnt, (int)UpdateDt.rinsanKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 亜硝酸性窒素（定量）
                    if ((dgvr.Cells[koshinKbnNo2nTeiryoIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuNo2nTeiryo1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, no2nTeiryo1ColIndex, no2nTeiryoKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "013"), input);
                        updt[rowCnt, (int)UpdateDt.no2nTeiryoKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 硝酸性窒素（定量）
                    if ((dgvr.Cells[koshinKbnNo3nTeiryoIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuNo3nTeiryo1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, no3nTeiryo1ColIndex, no3nTeiryoKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "014"), input);
                        updt[rowCnt, (int)UpdateDt.no3nTeiryoKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 陰イオン界面活性剤（B)
                    if ((dgvr.Cells[koshinKbnAbsBIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuAbsB1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, absB1ColIndex, absBKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "015"), input);
                        updt[rowCnt, (int)UpdateDt.absBKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 全窒素（B)
                    if ((dgvr.Cells[koshinKbnTnBIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuTnB1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, tnB1ColIndex, tnBKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "016"), input);
                        updt[rowCnt, (int)UpdateDt.tnBKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 全りん（B)
                    if ((dgvr.Cells[koshinKbnTpBIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuTpB1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, tpB1ColIndex, tpBKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "017"), input);
                        updt[rowCnt, (int)UpdateDt.tpBKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 色度
                    if ((dgvr.Cells[koshinKbnShikidoIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuShikido1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, shikido1ColIndex, shikidoKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "018"), input);
                        updt[rowCnt, (int)UpdateDt.shikidoKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // BOD（B）
                    if ((dgvr.Cells[koshinKbnBodBIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuBodB1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, bodB1ColIndex, bodBKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "019"), input);
                        updt[rowCnt, (int)UpdateDt.bodBKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // ヘキサン抽出物質（鉱油類）
                    if ((dgvr.Cells[koshinKbnHekisanKoyuIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuHekisanKoyu1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, hekisanKoyu1ColIndex, hekisanKoyuKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "020"), input);
                        updt[rowCnt, (int)UpdateDt.hekisanKoyuKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // ヘキサン抽出物質（動植物油類）
                    if ((dgvr.Cells[koshinKbnHekisanDoshokuIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuHekisanDoshoku1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, hekisanDoshoku1ColIndex, hekisanDoshokuKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "021"), input);
                        updt[rowCnt, (int)UpdateDt.hekisanDoshokuKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // ヘキサン抽出物質（B）
                    if ((dgvr.Cells[koshinKbnHekisanBIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuHekisanB1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, hekisanB1ColIndex, hekisanBKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "022"), input);
                        updt[rowCnt, (int)UpdateDt.hekisanBKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 鉛
                    if ((dgvr.Cells[koshinKbnNamariIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuNamari1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, namari1ColIndex, namariKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "023"), input);
                        updt[rowCnt, (int)UpdateDt.namariKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 亜鉛
                    if ((dgvr.Cells[koshinKbnAenIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuAen1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, aen1ColIndex, aenKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "024"), input);
                        updt[rowCnt, (int)UpdateDt.aenKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // ほう素
                    if ((dgvr.Cells[koshinKbnHousoIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuHouso1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, houso1ColIndex, housoKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "025"), input);
                        updt[rowCnt, (int)UpdateDt.housoKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 残塩
                    if ((dgvr.Cells[koshinKbnZanenIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuZanen1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, zanen1ColIndex, zanenKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "026"), input);
                        updt[rowCnt, (int)UpdateDt.zanenKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 外観
                    if ((dgvr.Cells[koshinKbnGaikanIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuGaikan1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, gaikan1ColIndex, gaikanKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "027"), input, false);
                        updt[rowCnt, (int)UpdateDt.gaikanKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 臭気
                    if ((dgvr.Cells[koshinKbnShukiIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuShuki1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, shuki1ColIndex, shukiKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "028"), input, false);
                        updt[rowCnt, (int)UpdateDt.shukiKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 透視度
                    if ((dgvr.Cells[koshinKbnTrIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuTr1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, tr1ColIndex, trKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "029"), input);
                        updt[rowCnt, (int)UpdateDt.trKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 亜硝酸性窒素（定性）
                    if ((dgvr.Cells[koshinKbnNo2nTeiseiIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuNo2nTeisei1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, no2nTeisei1ColIndex, no2nTeiseiKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "030"), input, false);
                        updt[rowCnt, (int)UpdateDt.no2nTeiseiKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 硝酸性窒素（定性）
                    if ((dgvr.Cells[koshinKbnNo3nTeiseiIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuNo3nTeisei1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, no3nTeisei1ColIndex, no3nTeiseiKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "031"), input, false);
                        updt[rowCnt, (int)UpdateDt.no3nTeiseiKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }

                    // 大腸菌群数
                    if ((dgvr.Cells[koshinKbnDaichokinIndex].Value.ToString() == "1")
                        || ((dgvr.Cells[kekkaNyuryokuDaichokin1ColIndex].Value.ToString() == "1") && (dgvr.Cells[koshinKbnKeninIndex].Value.ToString() == "1")))
                    {
                        UpdateAllKekka(dgvr, daichokin1ColIndex, daichokinKekkaUpdateDtColIndex, Boundary.Common.Common.GetConstValue(kmkKbn, "032"), input);
                        updt[rowCnt, (int)UpdateDt.daichokinKekkaUpdateDtCol] = input.UpdateDt.ToString();
                    }
                    #endregion

                    #endregion

                }

                CompleteTransaction();

                #region 更新日の更新
                rowCnt = -1;
                foreach (DataGridViewRow dgvr in input.listDataGridView.Rows)
                {
                    rowCnt++;

                    // 検査台帳ヘッダ
                    dgvr.Cells[hdrUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hdrUpdateDtCol];
                    // 計量証明依頼テーブル
                    dgvr.Cells[iraiUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.iraiUpdateDtCol];
                    // 計量証明結果テーブル
                    dgvr.Cells[phKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.phKekkaUpdateDtCol];
                    dgvr.Cells[ssKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.ssKekkaUpdateDtCol];
                    dgvr.Cells[bodAKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bodAKekkaUpdateDtCol];
                    dgvr.Cells[nh4nKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.nh4nKekkaUpdateDtCol];
                    dgvr.Cells[clKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.clKekkaUpdateDtCol];
                    dgvr.Cells[codKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.codKekkaUpdateDtCol];
                    dgvr.Cells[hekisanAKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanAKekkaUpdateDtCol];
                    dgvr.Cells[mlssKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.mlssKekkaUpdateDtCol];
                    dgvr.Cells[tnAKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tnAKekkaUpdateDtCol];
                    dgvr.Cells[absAKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.absAKekkaUpdateDtCol];
                    dgvr.Cells[tpAKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tpAKekkaUpdateDtCol];
                    dgvr.Cells[rinsanKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.rinsanKekkaUpdateDtCol];
                    dgvr.Cells[no2nTeiryoKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no2nTeiryoKekkaUpdateDtCol];
                    dgvr.Cells[no3nTeiryoKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no3nTeiryoKekkaUpdateDtCol];
                    dgvr.Cells[absBKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.absBKekkaUpdateDtCol];
                    dgvr.Cells[tnBKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tnBKekkaUpdateDtCol];
                    dgvr.Cells[tpBKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tpBKekkaUpdateDtCol];
                    dgvr.Cells[shikidoKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.shikidoKekkaUpdateDtCol];
                    dgvr.Cells[bodBKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bodBKekkaUpdateDtCol];
                    dgvr.Cells[hekisanKoyuKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanKoyuKekkaUpdateDtCol];
                    dgvr.Cells[hekisanDoshokuKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanDoshokuKekkaUpdateDtCol];
                    dgvr.Cells[hekisanBKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanBKekkaUpdateDtCol];
                    dgvr.Cells[namariKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.namariKekkaUpdateDtCol];
                    dgvr.Cells[aenKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.aenKekkaUpdateDtCol];
                    dgvr.Cells[housoKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.housoKekkaUpdateDtCol];
                    dgvr.Cells[zanenKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.zanenKekkaUpdateDtCol];
                    dgvr.Cells[gaikanKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.gaikanKekkaUpdateDtCol];
                    dgvr.Cells[shukiKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.shukiKekkaUpdateDtCol];
                    dgvr.Cells[trKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.trKekkaUpdateDtCol];
                    dgvr.Cells[no2nTeiseiKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no2nTeiseiKekkaUpdateDtCol];
                    dgvr.Cells[no3nTeiseiKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no3nTeiseiKekkaUpdateDtCol];
                    dgvr.Cells[daichokinKekkaUpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.daichokinKekkaUpdateDtCol];
                    // 検査台帳明細
                    dgvr.Cells[ph1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.ph1UpdateDtCol];
                    dgvr.Cells[ph2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.ph2UpdateDtCol];
                    dgvr.Cells[ss1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.ss1UpdateDtCol];
                    dgvr.Cells[ss2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.ss2UpdateDtCol];
                    dgvr.Cells[bodA1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bodA1UpdateDtCol];
                    dgvr.Cells[bodA2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bodA2UpdateDtCol];
                    dgvr.Cells[nh4n1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.nh4n1UpdateDtCol];
                    dgvr.Cells[nh4n2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.nh4n2UpdateDtCol];
                    dgvr.Cells[cl1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.cl1UpdateDtCol];
                    dgvr.Cells[cl2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.cl2UpdateDtCol];
                    dgvr.Cells[cod1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.cod1UpdateDtCol];
                    dgvr.Cells[cod2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.cod2UpdateDtCol];
                    dgvr.Cells[hekisanA1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanA1UpdateDtCol];
                    dgvr.Cells[hekisanA2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanA2UpdateDtCol];
                    dgvr.Cells[mlss1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.mlss1UpdateDtCol];
                    dgvr.Cells[mlss2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.mlss2UpdateDtCol];
                    dgvr.Cells[tnA1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tnA1UpdateDtCol];
                    dgvr.Cells[tnA2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tnA2UpdateDtCol];
                    dgvr.Cells[absA1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.absA1UpdateDtCol];
                    dgvr.Cells[absA2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.absA2UpdateDtCol];
                    dgvr.Cells[tpA1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tpA1UpdateDtCol];
                    dgvr.Cells[tpA2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tpA2UpdateDtCol];
                    dgvr.Cells[rinsan1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.rinsan1UpdateDtCol];
                    dgvr.Cells[rinsan2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.rinsan2UpdateDtCol];
                    dgvr.Cells[no2nTeiryo1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no2nTeiryo1UpdateDtCol];
                    dgvr.Cells[no2nTeiryo2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no2nTeiryo2UpdateDtCol];
                    dgvr.Cells[no3nTeiryo1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no3nTeiryo1UpdateDtCol];
                    dgvr.Cells[no3nTeiryo2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no3nTeiryo2UpdateDtCol];
                    dgvr.Cells[absB1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.absB1UpdateDtCol];
                    dgvr.Cells[absB2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.absB2UpdateDtCol];
                    dgvr.Cells[tnB1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tnB1UpdateDtCol];
                    dgvr.Cells[tnB2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tnB2UpdateDtCol];
                    dgvr.Cells[tpB1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tpB1UpdateDtCol];
                    dgvr.Cells[tpB2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tpB2UpdateDtCol];
                    dgvr.Cells[shikido1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.shikido1UpdateDtCol];
                    dgvr.Cells[shikido2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.shikido2UpdateDtCol];
                    dgvr.Cells[bodB1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bodB1UpdateDtCol];
                    dgvr.Cells[bodB2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.bodB2UpdateDtCol];
                    dgvr.Cells[hekisanKoyu1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanKoyu1UpdateDtCol];
                    dgvr.Cells[hekisanKoyu2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanKoyu2UpdateDtCol];
                    dgvr.Cells[hekisanDoshoku1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanDoshoku1UpdateDtCol];
                    dgvr.Cells[hekisanDoshoku2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanDoshoku2UpdateDtCol];
                    dgvr.Cells[hekisanB1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanB1UpdateDtCol];
                    dgvr.Cells[hekisanB2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.hekisanB2UpdateDtCol];
                    dgvr.Cells[namari1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.namari1UpdateDtCol];
                    dgvr.Cells[namari2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.namari2UpdateDtCol];
                    dgvr.Cells[aen1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.aen1UpdateDtCol];
                    dgvr.Cells[aen2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.aen2UpdateDtCol];
                    dgvr.Cells[houso1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.houso1UpdateDtCol];
                    dgvr.Cells[houso2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.houso2UpdateDtCol];
                    dgvr.Cells[zanen1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.zanen1UpdateDtCol];
                    dgvr.Cells[zanen2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.zanen2UpdateDtCol];
                    dgvr.Cells[gaikan1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.gaikan1UpdateDtCol];
                    dgvr.Cells[gaikan2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.gaikan2UpdateDtCol];
                    dgvr.Cells[shuki1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.shuki1UpdateDtCol];
                    dgvr.Cells[shuki2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.shuki2UpdateDtCol];
                    dgvr.Cells[tr1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tr1UpdateDtCol];
                    dgvr.Cells[tr2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.tr2UpdateDtCol];
                    dgvr.Cells[no2nTeisei1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no2nTeisei1UpdateDtCol];
                    dgvr.Cells[no2nTeisei2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no2nTeisei2UpdateDtCol];
                    dgvr.Cells[no3nTeisei1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no3nTeisei1UpdateDtCol];
                    dgvr.Cells[no3nTeisei2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.no3nTeisei2UpdateDtCol];
                    dgvr.Cells[daichokin1UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.daichokin1UpdateDtCol];
                    dgvr.Cells[daichokin2UpdateDtColIndex].Value = updt[rowCnt, (int)UpdateDt.daichokin2UpdateDtCol];
                }
                #endregion
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());
                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
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
