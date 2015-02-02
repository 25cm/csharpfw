using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaKomokuMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaTanKomokuMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KakuninKensaShubetsuHanteiMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KeiryoShomeiKekkaTblDataSetTableAdapters;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.ShokenKekkaTbl;
using FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.SuishitsuKensaSetMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.SuishitsuShikenKoumokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Utility
{
    /// <summary>
    /// 検査結果判定関連
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　habu　　    新規作成
    /// 2015/01/23  宗          検査適正判定[KensaTekiseiHantei]を追加
    /// </history>
    public class KensaHanteiUtility
    {
        #region Constants

        /// <summary>
        /// 0:正常
        /// </summary>
        public const string ERR_OK = "0";
        /// <summary>
        /// 1:エラー
        /// </summary>
        public const string ERR_ERR = "1";
        /// <summary>
        /// 2:検査対象外
        /// </summary>
        public const string ERR_TAISHOUGAI = "2";
        /// <summary>
        /// 3:引数が揃っていない
        /// </summary>
        public const string ERR_PARAM_INVALID = "3";

        /// <summary>
        /// 0:未判定
        /// </summary>
        public const string HANTEI_MIHANTEI = "0";
        /// <summary>
        /// 1:適正
        /// </summary>
        public const string HANTEI_TEKISEI = "1";
        /// <summary>
        /// 2:おおむね適正
        /// </summary>
        public const string HANTEI_OOMUNE_TEKISEI = "2";
        /// <summary>
        /// 3:不適正
        /// </summary>
        public const string HANTEI_FUTEKISEI = "3";

        /// <summary>
        /// 0:スクリーニング対象外
        /// </summary>
        public const string SCR_TAISHOUGAI = "0";
        /// <summary>
        /// 1:スクリーニング対象(BOD)
        /// </summary>
        public const string SCR_BOD = "1";
        /// <summary>
        /// 2:スクリーニング対象(残塩)
        /// </summary>
        public const string SCR_ZANEN = "2";
        /// <summary>
        /// 3:未定
        /// </summary>
        public const string SCR_MITEI = "3";

        /// <summary>
        /// 0:正常
        /// </summary>
        public const string KAKO_OK = "0";
        /// <summary>
        /// 1:エラー
        /// </summary>
        public const string KAKO_NG = "1";
        /// <summary>
        /// 2:検査対象外
        /// </summary>
        public const string KAKO_TAISHOUGAI = "2";
        /// <summary>
        /// 3:引数が不足
        /// </summary>
        public const string KAKO_PARAM_INVALID = "3";

        /// <summary>
        /// 基準偏差値
        /// </summary>
        public static readonly decimal[] KIJYUN_HENSA = new decimal[]{
                                                  0m,0m,0m,1.46m,1.67m,
                                                  1.83m,1.93m,2.03m,2.11m,2.17m,
                                                  2.24m,2.28m,2.32m,2.37m,2.41m,
                                                  2.44m,2.48m,2.50m,2.53m,2.55m,
                                                  2.57m,2.58m,2.59m,2.60m,2.61m,
                                              };

        #region to be removed
        //#region BOD上限・下限
        //public static readonly decimal[] BOD_LOWER_GAPPEI = new decimal[]{
        //                                        15m,9m,7m,7m,5m,
        //                                        4m,4m,3m,3m,3m,
        //                                        3m,2m,2m,2m,2m,
        //                                        2m,2m,2m,1m,1m,
        //                                        1m,1m,1m,1m,1m,
        //                                        1m,1m,1m,1m,1m,
        //                                        1m,1m,1m,1m,1m,
        //                                        1m,1m,1m,1m,1m,
        //                                        1m,1m,1m,1m,1m,
        //                                        1m,1m,1m,1m,1m,
        //                                    };

        //public static readonly decimal[] BOD_UPPER_GAPPEI = new decimal[]{
        //                                        529m,272m,185m,185m,142m,
        //                                        115m,98m,85m,75m,68m,
        //                                        62m,57m,53m,49m,46m,
        //                                        43m,39m,37m,35m,34m,
        //                                        32m,31m,30m,29m,28m,
        //                                        27m,26m,25m,24m,24m,
        //                                        23m,23m,22m,21m,21m,
        //                                        20m,20m,20m,19m,19m,
        //                                        18m,18m,18m,17m,17m,
        //                                        17m,16m,16m,16m,16m,
        //                                    };

        //public static readonly decimal[] BOD_LOWER_BAKKI = new decimal[]{
        //                                        35m,21m,15m,12m,10m,
        //                                        9m,8m,7m,7m,6m,
        //                                        6m,5m,5m,5m,4m,
        //                                        4m,4m,4m,4m,4m,
        //                                        3m,3m,3m,3m,3m,
        //                                        3m,3m,3m,3m,3m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,1m,
        //                                    };

        //public static readonly decimal[] BOD_UPPER_BAKKI = new decimal[]{
        //                                        469m,256m,180m,141m,117m,
        //                                        100m,88m,79m,72m,65m,
        //                                        61m,56m,53m,50m,47m,
        //                                        45m,43m,41m,39m,37m,
        //                                        36m,35m,33m,32m,31m,
        //                                        30m,29m,29m,28m,27m,
        //                                        26m,26m,25m,25m,24m,
        //                                        23m,23m,22m,22m,22m,
        //                                        21m,21m,20m,20m,20m,
        //                                        19m,19m,19m,18m,18m,
        //                                    };

        //public static readonly decimal[] BOD_LOWER_ROT = new decimal[]{
        //                                        334m,143m,87m,61m,46m,
        //                                        37m,30m,26m,22m,19m,
        //                                        17m,15m,14m,13m,12m,
        //                                        11m,10m,9m,9m,8m,
        //                                        8m,7m,7m,6m,6m,
        //                                        6m,5m,5m,5m,5m,
        //                                        5m,4m,4m,4m,4m,
        //                                        4m,4m,4m,3m,3m,
        //                                        3m,3m,3m,3m,3m,
        //                                        3m,3m,3m,3m,1m,
        //                                    };

        //public static readonly decimal[] BOD_UPPER_ROT = new decimal[]{
        //                                        2572m,1023m,598m,409m,305m,
        //                                        241m,197m,166m,143m,124m,
        //                                        110m,98m,89m,81m,74m,
        //                                        68m,63m,58m,54m,51m,
        //                                        48m,45m,43m,40m,38m,
        //                                        36m,35m,33m,32m,30m,
        //                                        29m,28m,27m,26m,25m,
        //                                        24m,23m,23m,22m,21m,
        //                                        21m,20m,19m,19m,18m,
        //                                        18m,17m,17m,16m,16m,
        //                                    };
        //#endregion

        //#region SS上限・下限

        //public static readonly decimal[] SS_LOWER_GAPPEI = new decimal[]{
        //                                        275m,106m,61m,41m,30m,
        //                                        24m,19m,16m,14m,12m,
        //                                        10m,9m,8m,7m,7m,
        //                                        6m,6m,5m,5m,5m,
        //                                        4m,4m,4m,4m,3m,
        //                                        3m,3m,3m,3m,3m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,1m,
        //                                        1m,1m,1m,1m,1m,
        //                                    };

        //public static readonly decimal[] SS_UPPER_GAPPEI = new decimal[]{
        //                                        2528m,978m,561m,379m,279m,
        //                                        217m,176m,147m,125m,108m,
        //                                        95m,84m,75m,68m,62m,
        //                                        57m,52m,48m,45m,42m,
        //                                        39m,37m,34m,33m,31m,
        //                                        // TODO おそらく、資料の上限値の値が間違い -> 要QA
        //                                        2528m,978m,561m,379m,279m,
        //                                        217m,176m,147m,125m,108m,
        //                                        95m,84m,75m,68m,62m,
        //                                        57m,52m,48m,45m,42m,
        //                                        39m,37m,34m,33m,31m,
        //                                    };

        //public static readonly decimal[] SS_LOWER_BAKKI = new decimal[]{
        //                                        164m,71m,44m,31m,24m,
        //                                        19m,16m,13m,12m,10m,
        //                                        9m,8m,8m,7m,6m,
        //                                        6m,5m,5m,5m,4m,
        //                                        4m,4m,4m,4m,3m,
        //                                        3m,3m,3m,3m,3m,
        //                                        3m,3m,2m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,1m,
        //                                    };

        //public static readonly decimal[] SS_UPPER_BAKKI = new decimal[]{
        //                                        1342m,584m,359m,254m,194m,
        //                                        156m,130m,111m,96m,85m,
        //                                        75m,68m,62m,57m,52m,
        //                                        48m,45m,42m,39m,37m,
        //                                        35m,33m,31m,30m,28m,
        //                                        27m,26m,25m,24m,23m,
        //                                        22m,21m,20m,19m,19m,
        //                                        18m,18m,17m,17m,16m,
        //                                        16m,15m,15m,14m,14m,
        //                                        14m,13m,13m,13m,12m,
        //                                    };

        //public static readonly decimal[] SS_LOWER_ROT = new decimal[]{
        //                                        57,37m,25m,19m,16m,
        //                                        13m,11m,10m,9m,8m,
        //                                        7m,7m,6m,6m,5m,
        //                                        5m,5m,5m,4m,4m,
        //                                        4m,4m,4m,3m,3m,
        //                                        3m,3m,3m,3m,3m,
        //                                        3m,3m,3m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                        2m,2m,2m,2m,2m,
        //                                    };

        //public static readonly decimal[] SS_UPPER_ROT = new decimal[]{
        //                                        472m,311m,211m,160m,129m,
        //                                        109m,94m,83m,74m,67m,
        //                                        61m,56m,52m,48m,45m,
        //                                        43m,40m,38m,36m,34m,
        //                                        33m,31m,30m,29m,28m,
        //                                        27m,26m,25m,24m,23m,
        //                                        23m,22m,21m,21m,20m,
        //                                        20m,19m,19m,18m,18m,
        //                                        17m,17m,17m,16m,16m,
        //                                        15m,15m,15m,15m,14m,
        //                                    };

        //#endregion
        #endregion

        #endregion

        #region public methods

        #region TekiyoHantei
        /// <summary>
        /// 029 適正判定
        /// </summary>
        /// <param name="shoriHoshiki"></param>
        /// <param name="shoriMokuhyo"></param>
        /// <param name="ph"></param>
        /// <param name="tr"></param>
        /// <param name="bod"></param>
        /// <param name="zanen"></param>
        /// <param name="cl"></param>
        /// <param name="iraiHoteiKbn"></param>
        /// <param name="iraiHokenjoCd"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiRenban"></param>
        /// <returns></returns>
        public static string TekiyoHantei(string shoriHoshiki, string shoriMokuhyo, string ph, string tr, string bod, string zanen, string cl, string iraiHoteiKbn, string iraiHokenjoCd, string iraiNendo, string iraiRenban)
        {
            string hanteiValue = HANTEI_MIHANTEI;

            if (string.IsNullOrEmpty(shoriHoshiki) 
                || string.IsNullOrEmpty(shoriMokuhyo) 
                || string.IsNullOrEmpty(ph) 
                || string.IsNullOrEmpty(tr) 
                || string.IsNullOrEmpty(bod) 
                || string.IsNullOrEmpty(zanen) 
                || string.IsNullOrEmpty(cl))
            {
                hanteiValue = HANTEI_MIHANTEI;

                return hanteiValue;
            }

            int phHantei = SuishitsuUtility.SuishitsuHyokaHantei(shoriHoshiki, shoriMokuhyo, SuishitsuUtility.SuishitsuKensaKbn.PH, ph);

            int trHantei = SuishitsuUtility.SuishitsuHyokaHantei(shoriHoshiki, shoriMokuhyo, SuishitsuUtility.SuishitsuKensaKbn.Toshido, tr);

            int bodHantei = SuishitsuUtility.SuishitsuHyokaHantei(shoriHoshiki, shoriMokuhyo, SuishitsuUtility.SuishitsuKensaKbn.BOD, bod);

            int zanenHantei = SuishitsuUtility.SuishitsuHyokaHantei(shoriHoshiki, shoriMokuhyo, SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso, zanen);

            int clHantei = SuishitsuUtility.SuishitsuHyokaHantei(shoriHoshiki, shoriMokuhyo, SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon, cl);

            if (phHantei == 1 && trHantei == 1 && bodHantei == 1 && zanenHantei == 1 && clHantei == 1)
            {
                hanteiValue = HANTEI_TEKISEI;

                return hanteiValue;
            }
            else if ((zanenHantei == 1 && bodHantei == 1)
                || ((zanenHantei == 1 && bodHantei == 2) && (phHantei == 2 || phHantei == 3 || trHantei == 2 || trHantei == 3 || clHantei == 2 || clHantei == 3)))
            {
                hanteiValue = HANTEI_OOMUNE_TEKISEI;

                return hanteiValue;
            }
            else if (zanenHantei == 3 || bodHantei == 3)
            {
                // 所見結果を取得する
                ShokenKekkaTblDataSet.ShokenKekkaTblDataTable shokenKekkaTbl 
                    = Common.GetShokenKekkaTblByIraiKeyCheckHantei(
                    iraiHoteiKbn
                    , iraiHokenjoCd
                    , iraiNendo
                    , iraiRenban
                    , "3");

                // チェック項目判定:3の所見結果が存在すれば、不適正
                //if (shokenKekkaTbl.Count >= 0)
                if(shokenKekkaTbl != null)
                {
                    hanteiValue = HANTEI_FUTEKISEI;
                }
                // 存在しない場合、おおむね適正
                else
                {
                    hanteiValue = HANTEI_OOMUNE_TEKISEI;
                }

                return hanteiValue;
            }

            hanteiValue = HANTEI_MIHANTEI;

            return hanteiValue;
        }
        #endregion

        #region KensaTekiseiHantei1
        /// <summary>
        /// 029 検査適正判定(1)
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="iraiHokenjoCd"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiRenban"></param>
        /// <returns></returns>
        public static string KensaTekiseiHantei(
            string kensaIraiHoteiKbn, 
            string iraiHokenjoCd, 
            string iraiNendo, 
            string iraiRenban)
        {
            string hanteiValue = HANTEI_MIHANTEI;

            // パラメータチェック
            if (string.IsNullOrEmpty(kensaIraiHoteiKbn) || string.IsNullOrEmpty(iraiHokenjoCd) 
                || string.IsNullOrEmpty(iraiNendo) || string.IsNullOrEmpty(iraiRenban))
            {
                return hanteiValue;
            }

            #region 各データ検索

            // 検査依頼取得
            ISelectKensaIraiTblByKeyDAInput kiInput = new SelectKensaIraiTblByKeyDAInput();
            kiInput.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            kiInput.KensaIraiHokenjoCd = iraiHokenjoCd;
            kiInput.KensaIraiNendo = iraiNendo;
            kiInput.KensaIraiRenban = iraiRenban;
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT = new SelectKensaIraiTblByKeyDataAccess().Execute(kiInput).KensaIraiTblDataTable;
            if (kensaIraiDT.Rows.Count == 0)
            {
                return hanteiValue;
            }

            // 検査結果取得
            ISelectKensaKekkaTblByKeyDAInput kkInput = new SelectKensaKekkaTblByKeyDAInput();
            kkInput.KensaKekkaIraiHoteiKbn = kensaIraiHoteiKbn;
            kkInput.KensaKekkaIraiHokenjoCd = iraiHokenjoCd;
            kkInput.KensaKekkaIraiNendo = iraiNendo;
            kkInput.KensaKekkaIraiRenban = iraiRenban;
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT = new SelectKensaKekkaTblByKeyDataAccess().Execute(kkInput).KensaKekkaTblDataTable;

            // 所見結果取得
            ISelectShokenKekkaListWithBitmaskDAInput selIn = new SelectShokenKekkaListWithBitmaskDAInput();
            selIn.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            selIn.KensaIraiHokenjoCd = iraiHokenjoCd;
            selIn.KensaIraiNendo = iraiNendo;
            selIn.KensaIraiRenban = iraiRenban;
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaDT = new SelectShokenKekkaListWithBitmaskDataAccess().Execute(selIn).ShokenKekkaListDT;

            #endregion

            #region 検査適正判定
            hanteiValue = KensaTekiseiHantei(kensaIraiDT, kensaKekkaDT, shokenKekkaDT);
            #endregion

            return hanteiValue;
        }
        #endregion

        #region KensaTekiseiHantei2
        /// <summary>
        /// 029 検査適正判定(2)
        /// </summary>
        /// <param name="kensaIraiTblDt"></param>
        /// <param name="kensaKekkaTblDt"></param>
        /// <param name="shokenKekkaTbkDt"></param>
        /// <returns></returns>
        public static string KensaTekiseiHantei(
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblDt,
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaTblDt,
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaTblDt)
        {
            // 検査パターン
            // １ 7条検査                     ： 検査依頼法定区分 = 1
            // ２ 11条外観検査                ： 検査依頼法定区分 = 2
            // ３ 11条水質検査                ： 検査依頼法定区分 = 3 かつ スクリーニング区分 = 0 (空白)
            // ４ 11条スクリーニング          ： 検査依頼法定区分 = 3 かつ スクリーニング区分 = 1
            // ５ 11条フォロー                ： 検査依頼法定区分 = 3 かつ スクリーニング区分 = 2
            // ６ 11条スクリーニング＋フォロー： 検査依頼法定区分 = 3 かつ スクリーニング区分 = 3

            string hanteiValue = "0";
            string hanteiMax = string.Empty;

            // 検査依頼、又は検査結果のDataTableがnullの場合は処理を抜ける
            if ((kensaIraiTblDt == null) || (kensaKekkaTblDt == null)) return hanteiValue;

            // 検査パターン４(11条スクリーニング)以外、かつ検査パターン６(11条スクリーニング＋フォロー)以外の場合
            if (!((kensaIraiTblDt[0].KensaIraiHoteiKbn == "3") && (kensaIraiTblDt[0].KensaIraiScreeningKbn == "1"))
                && !((kensaIraiTblDt[0].KensaIraiHoteiKbn == "3") && (kensaIraiTblDt[0].KensaIraiScreeningKbn == "3")))
            {
                // 検査パターン３(11条水質検査)以外の場合
                if (!((kensaIraiTblDt[0].KensaIraiHoteiKbn == "3") && (kensaIraiTblDt[0].KensaIraiScreeningKbn == "0")))
                {
                    // 所得結果テーブル.チェック判定項目のMaxを取得(対象検査ビットマスク=2 or 32(水質)以外)
                    hanteiMax = GetHanteiMax(shokenKekkaTblDt, false);

                    // 所見結果テーブル.チェック項目判定 >= 2
                    if (string.Compare(hanteiMax, "2") >= 0)
                    {
                        // 取得した判定項目を返却
                        hanteiValue =  hanteiMax;
                    }
                }
                else
                {
                    // 水質検査結果判定再取得
                    ReGetSuishitsuKensaHantei(kensaIraiTblDt, ref kensaKekkaTblDt);

                    // 水質検査結果による判定
                    string kekkaHantei = SuishitsuKensaHantei(kensaKekkaTblDt);

                    if ((!((kensaIraiTblDt[0].KensaIraiHoteiKbn == "3") && (kensaIraiTblDt[0].KensaIraiScreeningKbn == "0")) && (string.Compare(kekkaHantei, "1") >= 0))
                        || ((kensaIraiTblDt[0].KensaIraiHoteiKbn == "3") && (kensaIraiTblDt[0].KensaIraiScreeningKbn == "0")))
                    {
                        hanteiValue = kekkaHantei;
                    }
                    // 所見結果テーブル.チェック項目判定のMax = 1 の場合
                    else if (hanteiMax == "1")
                    {
                        hanteiValue = "1";
                    }
                    else
                    {
                        hanteiValue = "0";
                    }
                }
            }
            else
            {
                // 所見結果テーブル.チェック項目判定のMaxを取得
                hanteiMax = GetHanteiMax(shokenKekkaTblDt);

                // 所見結果テーブル.チェック項目判定 >= 2
                if(string.Compare(hanteiMax, "2") >= 0)
                {
                    // 取得した判定項目を返却
                    hanteiValue = hanteiMax;
                }
                else
                {
                    hanteiValue = "2";
                }
            }

            return hanteiValue;
        }

        #region チェック項目判定のMaxを取得
        // suishitsuFlg = true:水質含む, false:水質除外
        private static string GetHanteiMax(ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaTblDt, bool suishitsuFlg = true)
        {
            string hanteiMax = "0";

            foreach (ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskRow row in shokenKekkaTblDt.Rows)
            {
                if(!suishitsuFlg)
                {
                    // 水質を判定から除外
                    if ((row.ShokenTaishoKensaBitMask == 2 ) || (row.ShokenTaishoKensaBitMask == 32))
                    {
                        continue;
                    }
                }

                if (string.Compare(row.ShokenCheckHantei, hanteiMax) > 0)
                {
                    // 判定Max更新
                    hanteiMax = row.ShokenCheckHantei;
                }
            }

            return hanteiMax;
        }
        #endregion

        #region 水質検査再取得
        private static void ReGetSuishitsuKensaHantei(
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblDt,
            ref KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaTblDt)
        {
            // TODO 20150124 sou ※課題No241に関連
            // 各結果値に初期値で0が設定されていると、結果が未入力又は検査対象外であっても、結果値0として再判定の対象になってしまう。
            // → 初期値がnullであれば判定の対象にはならない。

            #region pH再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaSuisoIonNodoNull() &&
                (string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaSuisoIonNodoHantei) || (kensaKekkaTblDt[0].KensaKekkaSuisoIonNodoHantei == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaSuisoIonNodoHantei =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.PH,
                        kensaKekkaTblDt[0].KensaKekkaSuisoIonNodo.ToString()
                        ).ToString();
            }
            #endregion

            #region 溶存酸素量再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaYozonSansoryo1Null() &&
                (string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaYozonSansoryoHantei) || (kensaKekkaTblDt[0].KensaKekkaYozonSansoryoHantei == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaYozonSansoryoHantei =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.YozonSansoRyo,
                        kensaKekkaTblDt[0].KensaKekkaYozonSansoryo1.ToString()
                        ).ToString();
            }
            #endregion

            #region 透視度再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaToshidoNull() &&
                (string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaToshidoHantei) || (kensaKekkaTblDt[0].KensaKekkaToshidoHantei == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaToshidoHantei =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                        kensaKekkaTblDt[0].KensaKekkaToshido.ToString()
                        ).ToString();
            }
            #endregion

            #region ２次透視度再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaToshido2jiSyorisuiNull() &&
                (string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaToshidoHantei2jiSyorisui) || (kensaKekkaTblDt[0].KensaKekkaToshidoHantei2jiSyorisui == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaToshidoHantei2jiSyorisui =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                        kensaKekkaTblDt[0].KensaKekkaToshido2jiSyorisui.ToString()
                        ).ToString();
            }
            #endregion

            #region 残留塩素再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaZanryuEnsoNodoNull() &&
                ((string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaZanryuEnsoNodoHantei)) || (kensaKekkaTblDt[0].KensaKekkaZanryuEnsoNodoHantei == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaZanryuEnsoNodoHantei =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso,
                        kensaKekkaTblDt[0].KensaKekkaZanryuEnsoNodo.ToString()
                        ).ToString();
            }
            #endregion

            #region BOD再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaBODNull() &&
                ((string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaBODHantei)) || (kensaKekkaTblDt[0].KensaKekkaBODHantei == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaBODHantei =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.BOD,
                        kensaKekkaTblDt[0].KensaKekkaBOD.ToString()
                        ).ToString();
            }
            #endregion

            #region 塩化物イオン濃度再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaEnsoIonNodoNull() &&
                ((string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaEnsoIonNodoHantei)) || (kensaKekkaTblDt[0].KensaKekkaEnsoIonNodoHantei == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaEnsoIonNodoHantei =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon,
                        kensaKekkaTblDt[0].KensaKekkaEnsoIonNodo.ToString()
                        ).ToString();
            }
            #endregion

            #region 汚泥沈殿率再取得
            if (!kensaKekkaTblDt[0].IsKensaKekkaOdeiChindenritsuNull() &&
                ((string.IsNullOrEmpty(kensaKekkaTblDt[0].KensaKekkaOdeiChindenritsuHantei)) || (kensaKekkaTblDt[0].KensaKekkaOdeiChindenritsuHantei == "0")))
            {
                kensaKekkaTblDt[0].KensaKekkaOdeiChindenritsuHantei =
                    SuishitsuUtility.SuishitsuHyokaHantei(
                        kensaIraiTblDt[0].KensaIraiShorihoshikiKbn,
                        kensaIraiTblDt[0].KensaIraiBODShoriSeino,
                        SuishitsuUtility.SuishitsuKensaKbn.OdeiChindenRitsu,
                        kensaKekkaTblDt[0].KensaKekkaOdeiChindenritsu.ToString()
                        ).ToString();
            }
            #endregion
        }
        #endregion

        #region 水質検査判定
        private static string SuishitsuKensaHantei(KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaTblDt)
        {
            string hanteiKekka = "0";

            if (kensaKekkaTblDt == null) return hanteiKekka;

            string hanteiAll = GetSuishitsuHanteiMax(kensaKekkaTblDt);
            string hanteiBefore = GetSuishitsuHanteiMax(kensaKekkaTblDt, 1);
            string hanteiAfter = GetSuishitsuHanteiMax(kensaKekkaTblDt, 2);

            // 各水質の判定Max = 0
            if (hanteiAll == "0")
            {
                hanteiKekka = "0";
            }

            // 各水質の判定Max = 1
            if (hanteiAll == "1")
            {
                hanteiKekka = "1";
            }

            // 一部の水質の判定Max = 2、その他の水質の判定Max <= 1
            if (hanteiBefore == "2" && (string.Compare(hanteiAfter, "1") <= 0))
            {
                hanteiKekka = "1";
            }

            // 各水質の判定Max >= 2
            if (string.Compare(hanteiAll, "2") >= 0)
            {
                hanteiKekka = "2";
            }

            return hanteiKekka;
        }
        #endregion

        #region 水質判定のMax取得
        // type = 0:全て, 1:前半の項目, 2:後半の項目
        private static string GetSuishitsuHanteiMax(KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaTblDt, int type = 0)
        {
            string hanteiMax = "0";
            string hanteiOver = "4";

            if (kensaKekkaTblDt == null) return hanteiMax;

            if (type == 0 || type == 1)
            {
                //水素イオン濃度ー判定
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaSuisoIonNodoHantei, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaSuisoIonNodoHantei, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaSuisoIonNodoHantei;
                }

                //汚泥沈殿率ー判定
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaOdeiChindenritsuHantei, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaOdeiChindenritsuHantei, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaOdeiChindenritsuHantei;
                }

                //溶存酸素量ー判定
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaYozonSansoryoHantei, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaYozonSansoryoHantei, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaYozonSansoryoHantei;
                }

                //塩素イオン濃度ー判定
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaEnsoIonNodoHantei, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaEnsoIonNodoHantei, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaEnsoIonNodoHantei;
                }
            }

            if (type == 0 || type == 2)
            {
                //透視度ー判定
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaToshidoHantei, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaToshidoHantei, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaToshidoHantei;
                }

                //透視度ー判定２次処理水
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaToshidoHantei2jiSyorisui, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaToshidoHantei2jiSyorisui, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaToshidoHantei2jiSyorisui;
                }

                //残留塩素濃度ー判定
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaZanryuEnsoNodoHantei, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaZanryuEnsoNodoHantei, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaZanryuEnsoNodoHantei;
                }

                //生物化学酸素要求量ー判定
                if ((string.Compare(kensaKekkaTblDt[0].KensaKekkaBODHantei, hanteiMax) > 0)
                    && (string.Compare(kensaKekkaTblDt[0].KensaKekkaBODHantei, hanteiOver) < 0))
                {
                    hanteiMax = kensaKekkaTblDt[0].KensaKekkaBODHantei;
                }
            }

            return hanteiMax;
        }
        #endregion

        #endregion

        #region GetKensaIrai
        /// <summary>
        /// 検査依頼取得
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="iraiHokenjoCd"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiRenban"></param>
        /// <returns></returns>
        public static KensaIraiTblDataSet.KensaIraiTblDataTable GetKensaIrai(
            string kensaIraiHoteiKbn,
            string iraiHokenjoCd,
            string iraiNendo,
            string iraiRenban)
        {
            ISelectKensaIraiTblByKeyDAInput kiInput = new SelectKensaIraiTblByKeyDAInput();
            kiInput.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            kiInput.KensaIraiHokenjoCd = iraiHokenjoCd;
            kiInput.KensaIraiNendo = iraiNendo;
            kiInput.KensaIraiRenban = iraiRenban;
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT = new SelectKensaIraiTblByKeyDataAccess().Execute(kiInput).KensaIraiTblDataTable;

            return kensaIraiDT;
        }
        #endregion

        #region GetKensaKekka
        /// <summary>
        /// 検査結果取得
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="iraiHokenjoCd"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiRenban"></param>
        /// <returns></returns>
        public static KensaKekkaTblDataSet.KensaKekkaTblDataTable GetKensaKekka(
            string kensaIraiHoteiKbn,
            string iraiHokenjoCd,
            string iraiNendo,
            string iraiRenban)
        {
            ISelectKensaKekkaTblByKeyDAInput kkInput = new SelectKensaKekkaTblByKeyDAInput();
            kkInput.KensaKekkaIraiHoteiKbn = kensaIraiHoteiKbn;
            kkInput.KensaKekkaIraiHokenjoCd = iraiHokenjoCd;
            kkInput.KensaKekkaIraiNendo = iraiNendo;
            kkInput.KensaKekkaIraiRenban = iraiRenban;
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT = new SelectKensaKekkaTblByKeyDataAccess().Execute(kkInput).KensaKekkaTblDataTable;

            return kensaKekkaDT;
        }
        #endregion

        #region GetShokenKekka
        /// <summary>
        /// 所見結果取得
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="iraiHokenjoCd"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiRenban"></param>
        /// <returns></returns>
        public static ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable GetShokenKekka(
            string kensaIraiHoteiKbn,
            string iraiHokenjoCd,
            string iraiNendo,
            string iraiRenban)
        {
            ISelectShokenKekkaListWithBitmaskDAInput selIn = new SelectShokenKekkaListWithBitmaskDAInput();
            selIn.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            selIn.KensaIraiHokenjoCd = iraiHokenjoCd;
            selIn.KensaIraiNendo = iraiNendo;
            selIn.KensaIraiRenban = iraiRenban;
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaDT = new SelectShokenKekkaListWithBitmaskDataAccess().Execute(selIn).ShokenKekkaListDT;

            return shokenKekkaDT;
        }
        #endregion

        #region ScreeningHantei
        /// <summary>
        /// 030 スクリーニング判定
        /// </summary>
        /// <param name="shoriHoshikiKbn"></param>
        /// <param name="syoriMokuhyo"></param>
        /// <param name="bod"></param>
        /// <param name="zanen"></param>
        /// <returns></returns>
        public static string ScreeningHantei(string shoriHoshikiKbn, string syoriMokuhyo, string bod, string zanen)
        {
            string kekka = SCR_MITEI;

            const string HANTEI_MITEI = "0";
            const string HANTEI_OK = "1";
            const string HANTEI_NG = "2";

            // BOD判定
            string bodHantei = HANTEI_MITEI;

            if (!string.IsNullOrEmpty(bod))
            {
                int temp = SuishitsuUtility.SuishitsuHyokaHantei(shoriHoshikiKbn, syoriMokuhyo, SuishitsuUtility.SuishitsuKensaKbn.BOD, bod);

                if (temp == 3)
                {
                    bodHantei = HANTEI_NG;
                }
                else
                {
                    bodHantei = HANTEI_OK;
                }
            }

            // 残留塩素判定
            string zanenHantei = HANTEI_MITEI;

            if (!string.IsNullOrEmpty(zanen))
            {
                int temp = SuishitsuUtility.SuishitsuHyokaHantei(shoriHoshikiKbn, syoriMokuhyo, SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso, zanen);

                if (temp == 3)
                {
                    zanenHantei = HANTEI_NG;
                }
                else
                {
                    zanenHantei = HANTEI_OK;
                }
            }

            if (bodHantei == HANTEI_OK && zanenHantei == HANTEI_OK)
            {
                kekka = SCR_TAISHOUGAI;

                return kekka;
            }
            else if (bodHantei == HANTEI_NG)
            {
                kekka = SCR_BOD;

                return kekka;
            }
            else if (zanenHantei == HANTEI_NG)
            {
                kekka = SCR_ZANEN;

                return kekka;
            }
            else
            {
                kekka = SCR_MITEI;

                return kekka;
            }
        }
        #endregion

        #region KakuninKensaShubetsuCODKijyunOver
        /// <summary>
        /// 031 確認検査種別(COD基準値オーバー)
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuCODKijyunOver(string cod)
        {
            string errKbn = ERR_PARAM_INVALID;

            decimal val;

            // 数値に変換
            if (!decimal.TryParse(cod, out val))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            // COD値判定
            if (val < 3.3m || 39m <= val)
            {
                errKbn = ERR_ERR;

                return errKbn;
            }

            errKbn = ERR_OK;

            return errKbn;
        }
        #endregion

        #region KakuninKensaShubetsuBODToshido
        /// <summary>
        /// 032 確認検査種別(BOD/透視度)
        /// </summary>
        /// <param name="suishitsuCd"></param>
        /// <param name="bod"></param>
        /// <param name="toshido"></param>
        /// <param name="shoriHoshikiShubetsu"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuBODToshido(string suishitsuCd, string bod, string toshido, string shoriHoshikiShubetsu)
        {
            string errKbn = ERR_PARAM_INVALID;

            // TODO 水質マスタの水質コードで良いか?
            if (suishitsuCd != Constants.SuishitsuCdConstant.SUISHITSU_CD_JOKASO_HORYUSUI)
            {
                errKbn = ERR_TAISHOUGAI;

                return errKbn;
            }

            if (string.IsNullOrEmpty(bod) || string.IsNullOrEmpty(toshido))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            int toshidoVal;

            if (!int.TryParse(toshido, out toshidoVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            decimal bodVal;

            if (!decimal.TryParse(bod, out bodVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            if (toshidoVal <= 1)
            {
                toshidoVal = 1;
            }
            if (toshidoVal >= 50)
            {
                toshidoVal = 50;
            }

            decimal lowerBod = 0m;
            decimal upperBod = 0m;

            // BODの上限、下限を処理方式種別と透視度から取得する
            if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_GAPPEI
                || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_HENSOKU
                || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_BAKKI
                || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_FUHAI
                )
            {
                KakuninKensaShubetsuHanteiMstDataSet.KakuninKensaShubetsuHanteiMstDataTable template = new KakuninKensaShubetsuHanteiMstDataSet.KakuninKensaShubetsuHanteiMstDataTable();

                IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
                getInput.DataTableType = typeof(KakuninKensaShubetsuHanteiMstDataSet.KakuninKensaShubetsuHanteiMstDataTable);
                getInput.TableAdapterType = typeof(KakuninKensaShubetsuHanteiMstTableAdapter);
                getInput.Query.AddEqualCond(template.BunruiColumn.ColumnName, Constants.KakuninKensaShubetsuBunrui.BOD_TOSHIDO);
                getInput.Query.AddEqualCond(template.ShorihoshikiColumn.ColumnName, shoriHoshikiShubetsu);
                getInput.Query.AddEqualCond(template.ToshidoColumn.ColumnName, toshidoVal.ToString());
                IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);

                if (getOutput.GetDataTable.Rows.Count == 0)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }

                lowerBod = TypeUtility.GetDecimal(getOutput.GetDataTable.Rows[0][template.KagenColumn.ColumnName]);
                upperBod = TypeUtility.GetDecimal(getOutput.GetDataTable.Rows[0][template.JogenColumn.ColumnName]);
            }
            // 小型の場合は対象外とする
            else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_KOGATA)
            {
                errKbn = ERR_TAISHOUGAI;

                return errKbn;
            }
            else
            {
                errKbn = ERR_TAISHOUGAI;

                return errKbn;
            }

            #region to be removed
            //// BODの上限、下限を処理方式種別と透視度から取得する
            //if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_GAPPEI
            //    || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_HENSOKU)
            //{
            //    lowerBod = BOD_LOWER_GAPPEI[toshidoVal - 1];
            //    upperBod = BOD_UPPER_GAPPEI[toshidoVal - 1];
            //}
            //else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_BAKKI)
            //{
            //    lowerBod = BOD_LOWER_BAKKI[toshidoVal - 1];
            //    upperBod = BOD_UPPER_BAKKI[toshidoVal - 1];
            //}
            //else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_FUHAI)
            //{
            //    lowerBod = BOD_LOWER_ROT[toshidoVal - 1];
            //    upperBod = BOD_UPPER_ROT[toshidoVal - 1];
            //}
            //// 小型の場合は対象外とする
            //else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_KOGATA)
            //{
            //    errKbn = ERR_TAISHOUGAI;

            //    return errKbn;
            //}
            //else
            //{
            //    errKbn = ERR_TAISHOUGAI;

            //    return errKbn;
            //}
            #endregion

            if (bodVal > upperBod || bodVal < lowerBod)
            {
                errKbn = ERR_ERR;

                return errKbn;
            }

            errKbn = ERR_OK;

            return errKbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="suishitsuCd"></param>
        /// <param name="bod"></param>
        /// <param name="toshido"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuBODToshido(string suishitsuCd, string bod, string toshido, string jokasoHokenjoCd, string jokasoNendo, string jokasoRenban)
        {
            // TODO 呼出ごとに、毎回、浄化槽台帳を参照する様だが、問題ないか?
            // TODO -> なんとなれば、リファクタでしのぐ
            string shoriHoshikiShubetsu = string.Empty;

            IGetJokasoDaichoMstByKeyBLInput input = new GetJokasoDaichoMstByKeyBLInput();
            input.HokenjoCd = jokasoHokenjoCd;
            input.TorokuNendo = jokasoNendo;
            input.Renban = jokasoRenban;

            IGetJokasoDaichoMstByKeyBLOutput output = new GetJokasoDaichoMstByKeyBusinessLogic().Execute(input);

            if (output.JokasoDaichoMstDT.Count == 0)
            {
                return ERR_PARAM_INVALID;
            }

            shoriHoshikiShubetsu = output.JokasoDaichoMstDT[0].JokasoShoriHosikiShubetu;

            return KakuninKensaShubetsuBODToshido(suishitsuCd, bod, toshido, shoriHoshikiShubetsu);
        }
        #endregion

        // TODO -> 呼出毎に、過去の検査結果を参照するが、問題ないか? -> 参照データ渡すオーバロードを用意する

        #region KakuninKensaShubetsuKakoHikaku
        /// <summary>
        /// 033 確認検査種別(過去との比較)
        /// </summary>
        /// <param name="kensaKbn"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="uketsukeDt"></param>
        /// <param name="komokuCd"></param>
        /// <param name="kekkaValue"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuKakoHikaku(string kensaKbn, string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban, string uketsukeDt, string komokuCd, decimal kekkaValue)
        {
            string errKbn = string.Empty;

            // 試験項目ゼロ表示区分判定
            {
                // 水質試験項目マスタ取得
                SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable template = new SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable);
                input.TableAdapterType = typeof(SuishitsuShikenKoumokuMstTableAdapter);
                input.Query.AddEqualCond(template.SuishitsuShikenKoumokuCdColumn.ColumnName, komokuCd);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable shikenTbl = (SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable)output.GetDataTable;
                string zeroDispKbn = string.Empty;

                if (shikenTbl.Count > 0)
                {
                    zeroDispKbn = shikenTbl[0].ZeroHyojiKbn;
                }

                // TODO 定数を参照する
                if (zeroDispKbn != "1")
                {
                    errKbn = KAKO_TAISHOUGAI;

                    return errKbn;
                }
            }

            int kakoDataCnt = 0;

            KensaKekkaTblDataSet.KakoKensaKekkaDataTable kakoKekkaTbl = new KensaKekkaTblDataSet.KakoKensaKekkaDataTable();
            KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiDataTable kakoKeiryoShomeiTbl = new KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiDataTable();

            // 過去結果値判定
            // 11条の場合
            if (kensaKbn == "1")
            {
                // 検査結果取得
                KensaKekkaTblDataSet.KakoKensaKekkaDataTable template = new KensaKekkaTblDataSet.KakoKensaKekkaDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KensaKekkaTblDataSet.KakoKensaKekkaDataTable);
                input.TableAdapterType = typeof(KakoKensaKekkaTableAdapter);

                input.Query.AddEqualCond(template.KensaIraiJokasoHokenjoCdColumn.ColumnName, jokasoHokenjoCd);
                input.Query.AddEqualCond(template.KensaIraiJokasoTorokuNendoColumn.ColumnName, jokasoTorokuNendo);
                input.Query.AddEqualCond(template.KensaIraiJokasoRenbanColumn.ColumnName, jokasoRenban);

                input.Query.AddLesserCond(template.KensaIraiSuishitsuUketsukeDtColumn.ColumnName, uketsukeDt);

                input.Query.AddOrderCol(template.KensaIraiSuishitsuUketsukeDtColumn.ColumnName, false);
                
                // 直近25件までを対象とする
                input.RowLimit = 25;

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                kakoDataCnt = output.GetDataTable.Rows.Count;
                kakoKekkaTbl = (KensaKekkaTblDataSet.KakoKensaKekkaDataTable)output.GetDataTable;
            }
            // 9条の場合
            else if (kensaKbn == "2")
            {
                // 計量証明取得
                KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiDataTable template = new KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiDataTable);
                input.TableAdapterType = typeof(KakoKeiryoShomeiTableAdapter);

                input.Query.AddEqualCond(template.KeiryoShomeiJokasoDaichoHokenjoCdColumn.ColumnName, jokasoHokenjoCd);
                input.Query.AddEqualCond(template.KeiryoShomeiJokasoDaichoNendoColumn.ColumnName, jokasoTorokuNendo);
                input.Query.AddEqualCond(template.KeiryoShomeiJokasoDaichoRenbanColumn.ColumnName, jokasoRenban);

                input.Query.AddLesserCond(template.KeiryoShomeiIraiUketsukeDtColumn.ColumnName, uketsukeDt);

                input.Query.AddOrderCol(template.KeiryoShomeiIraiUketsukeDtColumn.ColumnName, false);
                
                // 直近25件までを対象とする
                input.RowLimit = 25;

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                kakoDataCnt = output.GetDataTable.Rows.Count;
                kakoKeiryoShomeiTbl = (KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiDataTable)output.GetDataTable;
            }
            else
            {
                errKbn = KAKO_PARAM_INVALID;

                return errKbn;
            }

            // 過去検査回数が4回未満の場合はチェック対象外
            if (kakoDataCnt < 4)
            {
                errKbn = KAKO_TAISHOUGAI;

                return errKbn;
            }

            // 基準偏差値取得
            int kijunIdx = kakoDataCnt > 25 ? 25 : kakoDataCnt;
            decimal kijunHensaValue = 0m;
            kijunHensaValue = KIJYUN_HENSA[kijunIdx - 1];

            decimal heikinValue = 0m;
            decimal bunsanValue = 0m;
            decimal stdHensaValue = 0m;
            decimal hensaValue = 0m;

            // 11条の場合
            if (kensaKbn == "1")
            {
                // 平均値算出
                {
                    decimal sum = 0m;

                    foreach (KensaKekkaTblDataSet.KakoKensaKekkaRow row in kakoKekkaTbl)
                    {
                        sum += GetKekkaValue(komokuCd, row);
                    }

                    // 20141226 今回値も含める
                    sum += kekkaValue;

                    heikinValue = sum / (kakoKekkaTbl.Count + 1);
                    //heikinValue = sum / kakoKekkaTbl.Count;
                }

                // 分散値算出
                {
                    decimal sum = 0m;

                    foreach (KensaKekkaTblDataSet.KakoKensaKekkaRow row in kakoKekkaTbl)
                    {
                        decimal unitVal = (GetKekkaValue(komokuCd, row) - heikinValue);
                        sum += unitVal * unitVal;
                    }

                    // 20141226 今回値も含める
                    {
                        decimal unitVal = (kekkaValue - heikinValue);
                        sum += unitVal * unitVal;
                    }

                    bunsanValue = sum / (kakoKekkaTbl.Count + 1 - 1);
                    //bunsanValue = sum / (kakoKekkaTbl.Count - 1);
                }

                // 標準偏差算出
                double t_stdHensaValue = Math.Sqrt((double)bunsanValue);
                if (!double.IsNaN(t_stdHensaValue))
                {
                    stdHensaValue = (decimal)t_stdHensaValue;
                }

                // 偏差値算出
                // 0除算時の返却値は計算前の値とする
                hensaValue = stdHensaValue == 0 ? stdHensaValue : (kekkaValue - heikinValue) / stdHensaValue;
            }
            else if (kensaKbn == "2")
            {
                // 平均値算出
                {
                    decimal sum = 0m;

                    foreach (KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiRow row in kakoKeiryoShomeiTbl)
                    {
                        sum += row.KeiryoShomeiKekkaValue;
                    }

                    // 20141226 今回値も含める
                    sum += kekkaValue;

                    heikinValue = sum / (kakoKeiryoShomeiTbl.Count + 1);
                    //heikinValue = sum / kakoKeiryoShomeiTbl.Count;
                }

                // 分散値算出
                {
                    decimal sum = 0m;

                    foreach (KeiryoShomeiKekkaTblDataSet.KakoKeiryoShomeiRow row in kakoKeiryoShomeiTbl)
                    {
                        decimal unitVal = (row.KeiryoShomeiKekkaValue - heikinValue);
                        sum += unitVal * unitVal;
                    }

                    // 20141226 今回値も含める
                    {
                        decimal unitVal = (kekkaValue - heikinValue);
                        sum += unitVal * unitVal;
                    }

                    bunsanValue = sum / (kakoKeiryoShomeiTbl.Count + 1 - 1);
                    //bunsanValue = sum / (kakoKeiryoShomeiTbl.Count - 1);
                }

                // 標準偏差算出
                double t_stdHensaValue = Math.Sqrt((double)bunsanValue);
                if (!double.IsNaN(t_stdHensaValue))
                {
                    stdHensaValue = (decimal)t_stdHensaValue;
                }

                // 偏差値算出
                // 0除算時の返却値は計算前の値とする
                hensaValue = stdHensaValue == 0 ? stdHensaValue : (kekkaValue - heikinValue) / stdHensaValue;
            }

            // 偏差値が基準偏差値を上回る場合はエラー
            if (hensaValue > kijunHensaValue)
            {
                errKbn = KAKO_NG;

                return errKbn;
            }
            else
            {
                errKbn = KAKO_OK;

                return errKbn;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="komokuCd"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static decimal GetKekkaValue(string komokuCd , KensaKekkaTblDataSet.KakoKensaKekkaRow row)
        {
            decimal kekkaVal = 0m;

            // pH(水素イオン濃度)
            if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_PH)
            {
                kekkaVal = (decimal)row.KensaKekkaSuisoIonNodo;
            }
            // 透視度
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_TR)
            {
                kekkaVal = (decimal)row.KensaKekkaToshido;
            }
            // BOD
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_BOD)
            {
                kekkaVal = (decimal)row.KensaKekkaBOD;
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_BOD_2)
            {
                kekkaVal = (decimal)row.KensaKekkaBOD;
            }
            // 残留塩素濃度
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_ZANEN)
            {
                kekkaVal = (decimal)row.KensaKekkaZanryuEnsoNodo;
            }
            // 塩化物イオン
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_CL)
            {
                kekkaVal = (decimal)row.KensaKekkaEnsoIonNodo;
            }

            return kekkaVal;
        }
        #endregion

        #region KakuninKensaShubetsuBODKijyunOver
        /// <summary>
        /// 034 確認検査種別(BOD基準値オーバー)
        /// </summary>
        /// <param name="suishitsuCd"></param>
        /// <param name="bod"></param>
        /// <param name="shoriHoshikiShubetsu"></param>
        /// <param name="ninsou"></param>
        /// <param name="shoriMokuhyoShuishitsu"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuBODKijyunOver(string suishitsuCd, string bod, string shoriHoshikiShubetsu, int ninsou, int shoriMokuhyoShuishitsu)
        {
            string errKbn = ERR_PARAM_INVALID;

            // TODO 水質マスタの水質コードで良いか?
            if (suishitsuCd != Constants.SuishitsuCdConstant.SUISHITSU_CD_JOKASO_HORYUSUI)
            {
                errKbn = ERR_TAISHOUGAI;

                return errKbn;
            }

            decimal bodVal;

            if (!decimal.TryParse(bod, out bodVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            decimal shoriMokuhyouVal = shoriMokuhyoShuishitsu;

            // 小型合併以外の場合、人槽により判定
            if (shoriHoshikiShubetsu != Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_KOGATA)
            {
                if (ninsou <= 50 && bodVal > 90)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }

                if (ninsou >= 51 && ninsou <= 500 && bodVal > 60)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }

                if (ninsou >= 501 && bodVal > 30)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }
            }
            // 小型合併の場合一律に判定
            else if (bodVal >= 21)
            {
                errKbn = ERR_ERR;

                return errKbn;
            }

            // 処理目標水質が設定されている( <> 0)の場合は処理目標水質との判定
            if (shoriMokuhyouVal != 0 && bodVal > shoriMokuhyouVal)
            {
                errKbn = ERR_ERR;

                return errKbn;
            }

            errKbn = ERR_OK;

            return errKbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="suishitsuCd"></param>
        /// <param name="bod"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuBODKijyunOver(string suishitsuCd, string bod, string jokasoHokenjoCd, string jokasoNendo, string jokasoRenban)
        {
            string shoriHoshikiShubetsu = string.Empty;
            int ninsou = 0;
            int shoriMokuhyoShuishitsu = 0;

            IGetJokasoDaichoMstByKeyBLInput input = new GetJokasoDaichoMstByKeyBLInput();
            input.HokenjoCd = jokasoHokenjoCd;
            input.TorokuNendo = jokasoNendo;
            input.Renban = jokasoRenban;

            IGetJokasoDaichoMstByKeyBLOutput output = new GetJokasoDaichoMstByKeyBusinessLogic().Execute(input);

            if (output.JokasoDaichoMstDT.Count == 0)
            {
                return ERR_PARAM_INVALID;
            }

            shoriHoshikiShubetsu = output.JokasoDaichoMstDT[0].JokasoShoriHosikiShubetu;
            ninsou = output.JokasoDaichoMstDT[0].JokasoShoriTaishoJinin;
            shoriMokuhyoShuishitsu = output.JokasoDaichoMstDT[0].JokasoSyoriMokuhyoBOD;

            return KakuninKensaShubetsuBODKijyunOver(suishitsuCd, bod, shoriHoshikiShubetsu, ninsou, shoriMokuhyoShuishitsu);
        }
        #endregion

        #region KakuninKensaShubetsuEnkabutsuIonKensa
        /// <summary>
        /// 035 確認検査種別(塩化物イオン確認検査)
        /// </summary>
        /// <param name="enkabutsuIon"></param>
        /// <param name="shoriHoshikiShubetsu"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuEnkabutsuIonKensa(string enkabutsuIon, string shoriHoshikiShubetsu)
        {
            string errKbn = ERR_PARAM_INVALID;

            decimal ionVal;

            if (!decimal.TryParse(enkabutsuIon, out ionVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_BAKKI || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_FUHAI)
            {
                if (ionVal > 199.6m)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }
            }
            else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_GAPPEI || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_HENSOKU || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_KOGATA)
            {
                if (ionVal > 134.8m)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }
            }
            else
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            errKbn = ERR_OK;

            return errKbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enkabutsuIon"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuEnkabutsuIonKensa(string enkabutsuIon, string jokasoHokenjoCd, string jokasoNendo, string jokasoRenban)
        {
            string shoriHoshikiShubetsu = string.Empty;

            IGetJokasoDaichoMstByKeyBLInput input = new GetJokasoDaichoMstByKeyBLInput();
            input.HokenjoCd = jokasoHokenjoCd;
            input.TorokuNendo = jokasoNendo;
            input.Renban = jokasoRenban;

            IGetJokasoDaichoMstByKeyBLOutput output = new GetJokasoDaichoMstByKeyBusinessLogic().Execute(input);

            if (output.JokasoDaichoMstDT.Count == 0)
            {
                return ERR_PARAM_INVALID;
            }

            shoriHoshikiShubetsu = output.JokasoDaichoMstDT[0].JokasoShoriHosikiShubetu;

            return KakuninKensaShubetsuEnkabutsuIonKensa(enkabutsuIon, shoriHoshikiShubetsu);
        }
        #endregion

        #region KakuninKensaShubetsuSSToshido
        /// <summary>
        /// 036 確認検査種別(SS/透視度)
        /// </summary>
        /// <param name="suishitsuCd"></param>
        /// <param name="ss"></param>
        /// <param name="toshido"></param>
        /// <param name="shoriHoshikiShubetsu"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuSSToshido(string suishitsuCd, string ss, string toshido, string shoriHoshikiShubetsu)
        {
            string errKbn = ERR_PARAM_INVALID;

            // TODO 水質マスタの水質コードで良いか?
            if (suishitsuCd != Constants.SuishitsuCdConstant.SUISHITSU_CD_JOKASO_HORYUSUI)
            {
                errKbn = ERR_TAISHOUGAI;

                return errKbn;
            }

            if (string.IsNullOrEmpty(ss) || string.IsNullOrEmpty(toshido))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            decimal ssVal;

            if (!decimal.TryParse(ss, out ssVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            int toshidoVal;

            if (!int.TryParse(toshido, out toshidoVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            if (toshidoVal <= 1)
            {
                toshidoVal = 1;
            }

            if (toshidoVal >= 50)
            {
                toshidoVal = 50;
            }

            decimal lowerSS = 0m;
            decimal upperSS = 0m;

            // SSの上限、下限を処理方式種別と透視度から取得する
            if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_GAPPEI
                || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_HENSOKU
                || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_BAKKI
                || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_FUHAI
                )
            {
                KakuninKensaShubetsuHanteiMstDataSet.KakuninKensaShubetsuHanteiMstDataTable template = new KakuninKensaShubetsuHanteiMstDataSet.KakuninKensaShubetsuHanteiMstDataTable();

                IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
                getInput.DataTableType = typeof(KakuninKensaShubetsuHanteiMstDataSet.KakuninKensaShubetsuHanteiMstDataTable);
                getInput.TableAdapterType = typeof(KakuninKensaShubetsuHanteiMstTableAdapter);
                getInput.Query.AddEqualCond(template.BunruiColumn.ColumnName, Constants.KakuninKensaShubetsuBunrui.SS_TOSHIDO);
                getInput.Query.AddEqualCond(template.ShorihoshikiColumn.ColumnName, shoriHoshikiShubetsu);
                getInput.Query.AddEqualCond(template.ToshidoColumn.ColumnName, toshidoVal.ToString());
                IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);

                if (getOutput.GetDataTable.Rows.Count == 0)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }

                lowerSS = TypeUtility.GetDecimal(getOutput.GetDataTable.Rows[0][template.KagenColumn.ColumnName]);
                upperSS = TypeUtility.GetDecimal(getOutput.GetDataTable.Rows[0][template.JogenColumn.ColumnName]);
            }
            // 小型の場合は対象外とする
            else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_KOGATA)
            {
                errKbn = ERR_TAISHOUGAI;

                return errKbn;
            }
            else
            {
                errKbn = ERR_TAISHOUGAI;

                return errKbn;
            }

            #region to be removed
            //// SSの上限、下限を処理方式種別と透視度から取得する
            //if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_GAPPEI
            //    || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_HENSOKU)
            //{
            //    lowerSS = SS_LOWER_GAPPEI[toshidoVal - 1];
            //    upperSS = SS_UPPER_GAPPEI[toshidoVal - 1];
            //}
            //else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_BAKKI)
            //{
            //    lowerSS = SS_LOWER_BAKKI[toshidoVal - 1];
            //    upperSS = SS_UPPER_BAKKI[toshidoVal - 1];
            //}
            //else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_FUHAI)
            //{
            //    lowerSS = SS_LOWER_ROT[toshidoVal - 1];
            //    upperSS = SS_UPPER_ROT[toshidoVal - 1];
            //}
            //// 小型の場合は対象外とする
            //else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_KOGATA)
            //{
            //    errKbn = ERR_TAISHOUGAI;

            //    return errKbn;
            //}
            //else
            //{
            //    errKbn = ERR_TAISHOUGAI;

            //    return errKbn;
            //}
            #endregion

            if (ssVal > upperSS || ssVal < lowerSS)
            {
                errKbn = ERR_ERR;

                return errKbn;
            }

            errKbn = ERR_OK;

            return errKbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="suishitsuCd"></param>
        /// <param name="ss"></param>
        /// <param name="toshido"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuSSToshido(string suishitsuCd, string ss, string toshido, string jokasoHokenjoCd, string jokasoNendo, string jokasoRenban)
        {
            string shoriHoshikiShubetsu = string.Empty;

            IGetJokasoDaichoMstByKeyBLInput input = new GetJokasoDaichoMstByKeyBLInput();
            input.HokenjoCd = jokasoHokenjoCd;
            input.TorokuNendo = jokasoNendo;
            input.Renban = jokasoRenban;

            IGetJokasoDaichoMstByKeyBLOutput output = new GetJokasoDaichoMstByKeyBusinessLogic().Execute(input);

            if (output.JokasoDaichoMstDT.Count == 0)
            {
                return ERR_PARAM_INVALID;
            }

            shoriHoshikiShubetsu = output.JokasoDaichoMstDT[0].JokasoShoriHosikiShubetu;

            return KakuninKensaShubetsuSSToshido(suishitsuCd, ss, toshido, shoriHoshikiShubetsu);
        }
        #endregion

        #region KakuninKensaShubetsuAnmoniaKensa
        /// <summary>
        /// 037 確認検査種別(アンモニア確認検査)
        /// </summary>
        /// <param name="anmonia"></param>
        /// <param name="shoriHoshikiShubetsu"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuAnmoniaKensa(string anmonia, string shoriHoshikiShubetsu)
        {
            string errKbn = ERR_PARAM_INVALID;

            decimal anmoniaVal;

            if (!decimal.TryParse(anmonia, out anmoniaVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_BAKKI || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_FUHAI)
            {
                if (anmoniaVal > 150.0m)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }
            }
            else if (shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_GAPPEI || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_HENSOKU || shoriHoshikiShubetsu == Constants.ShoriHoshikiShubetsuConstant.SHORI_HOSHIKI_SHUBETSU_KOGATA)
            {
                if (anmoniaVal > 53.0m)
                {
                    errKbn = ERR_ERR;

                    return errKbn;
                }
            }
            else
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            errKbn = ERR_OK;

            return errKbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anmonia"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuAnmoniaKensa(string anmonia, string jokasoHokenjoCd, string jokasoNendo, string jokasoRenban)
        {
            string shoriHoshikiShubetsu = string.Empty;

            IGetJokasoDaichoMstByKeyBLInput input = new GetJokasoDaichoMstByKeyBLInput();
            input.HokenjoCd = jokasoHokenjoCd;
            input.TorokuNendo = jokasoNendo;
            input.Renban = jokasoRenban;

            IGetJokasoDaichoMstByKeyBLOutput output = new GetJokasoDaichoMstByKeyBusinessLogic().Execute(input);

            if (output.JokasoDaichoMstDT.Count == 0)
            {
                return ERR_PARAM_INVALID;
            }

            shoriHoshikiShubetsu = output.JokasoDaichoMstDT[0].JokasoShoriHosikiShubetu;

            return KakuninKensaShubetsuAnmoniaKensa(anmonia, shoriHoshikiShubetsu);
        }
        #endregion

        #region KakuninKensaShubetsuAnmoniaTNHikaku
        /// <summary>
        /// 038 確認検査種別(アンモニアと全窒素の比較)
        /// </summary>
        /// <param name="anmonia"></param>
        /// <param name="tn"></param>
        /// <returns></returns>
        public static string KakuninKensaShubetsuAnmoniaTNHikaku(string anmonia, string tn)
        {
            string errKbn = ERR_PARAM_INVALID;

            if (string.IsNullOrEmpty(anmonia) || string.IsNullOrEmpty(tn))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            decimal anmoniaVal;

            if (!decimal.TryParse(anmonia, out anmoniaVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            decimal tnVal;

            if (!decimal.TryParse(tn, out tnVal))
            {
                errKbn = ERR_PARAM_INVALID;

                return errKbn;
            }

            if (anmoniaVal > tnVal)
            {
                errKbn = ERR_ERR;

                return errKbn;
            }

            errKbn = ERR_OK;

            return errKbn;
        }
        #endregion

        #region HyojiKetasuHosei
        /// <summary>
        /// 020 水質検査結果値の表示桁数補正
        /// </summary>
        /// <param name="komokuCd"></param>
        /// <param name="kekkaValue"></param>
        /// <returns></returns>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/22  宗        温度の桁数判定を追加
        /// </history>
        public static string HyojiKetasuHosei(string komokuCd, string kekkaValue)
        {
            string dispValue = string.Empty;

            decimal kekkaNumValue = 0m;

            if (!decimal.TryParse(kekkaValue, out kekkaNumValue))
            {
                return dispValue;
            }

            if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_TR)
            {
                // 有効桁数
                int sigDigit = kekkaNumValue < 10 ? 1 : 2;
                // 小数点以下桁数
                int scale = 0;

                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_COLOR)
            {
                int sigDigit = kekkaNumValue < 10 ? 1 : 2;
                int scale = 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_COLOR_2)
            {
                int sigDigit = kekkaNumValue < 10 ? 1 : 2;
                int scale = 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_PH)
            {
                int sigDigit = kekkaNumValue < 10 ? 2 : 3;
                int scale = 1;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if(komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_ONDO)
            {
                int sigDigit = 3;
                int scale = 1;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_SS)
            {
                int sigDigit = kekkaNumValue < 10 ? 1 : 2;
                int scale = 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_MLSS)
            {
                int sigDigit = 2;
                int scale = 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_COD)
            {
                int sigDigit = kekkaNumValue < 1 ? 1 : 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_BOD)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_BOD_2)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_N_HEXAN)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_ABS)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 1 ? 2 : kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_ZANEN)
            {
                int sigDigit = kekkaNumValue < 0.1m ? 1 : 2;
                int scale = kekkaNumValue < 0.1m ? 2 : kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_CL)
            {
                int sigDigit = kekkaNumValue < 10 ? 1 : 2;
                int scale = 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_NH4)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_NO2_N_TEIRYOU)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 1 ? 2 : kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_NO3_N_TEIRYOU)
            {
                int sigDigit = kekkaNumValue < 1 ? 1 : 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_T_N)
            {
                int sigDigit = kekkaNumValue < 1 ? 1 : 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_T_N_2)
            {
                int sigDigit = kekkaNumValue < 1 ? 1 : 2;
                int scale = kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_P_ION)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 1 ? 2 : kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_T_P)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 1 ? 2 : kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_T_P_2)
            {
                int sigDigit = 2;
                int scale = kekkaNumValue < 1 ? 2 : kekkaNumValue < 10 ? 1 : 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_COLON_BACT)
            {
                int sigDigit = kekkaNumValue < 10 ? 1 : 2;
                int scale = 0;
                dispValue = Round2(kekkaNumValue, scale, sigDigit).ToString();
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_NO2_N_TEISEI)
            {
                dispValue = string.Empty;
            }
            else if (komokuCd == Constants.ShikenKomokuConstant.SHIKEN_KOMOKU_NO3_N_TEISEI)
            {
                dispValue = string.Empty;
            }
            else
            {
                dispValue = kekkaValue;
            }

            return dispValue;
        }

        #region Round2
        /// <summary>
        /// 端数処理(小数点以下桁数、有効桁数指定)
        /// </summary>
        /// <param name="value">端数処理対象の値</param>
        /// <param name="scale">小数部桁数</param>
        /// <param name="sigDigit">有効桁数</param>
        /// <returns>端数処理後の数値の文字列表現</returns>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/26  habu      有効桁数を超える場合であっても、整数部は処理しないように変更
        /// </history>
        public static string Round2(decimal value, int scale, int sigDigit)
        {
            // 小数部が存在する場合のみ、丸めを行う
            if (scale > 0)
            {
                // 整数部桁数
                int intLength = GetIntPrecision(value);
                // 丸め時のシフト数
                int shiftLength = intLength - sigDigit;
                decimal shiftMulNum = (decimal)Math.Pow(10, shiftLength); ;

                int tDecimal = scale + shiftLength > 0 ? scale + shiftLength : 0;
                value = Math.Round(Math.Floor(value / shiftMulNum), tDecimal, MidpointRounding.AwayFromZero) * shiftMulNum;
            }

            // 小数部桁数指定の上、文字列に変換
            return value.ToString(string.Format("F{0}", scale));
        }
        #endregion

        #region GetIntPrecision
        /// <summary>
        /// 整数部桁数を取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int GetIntPrecision(decimal value)
        {
            string valueStr = value.ToString();

            // 1未満の場合、0.1 > 0, 0.01 > -1, 0.001 > -2として扱う
            if (Math.Abs(value) < 1)
            {
                int intLength = 0;
                bool afterPoint = false;
                foreach (char c in valueStr)
                {
                    if (c == '-' || c == '+') { continue; }
                    if (c == '.')
                    {
                        afterPoint = true;
                        continue;
                    }

                    if (afterPoint)
                    {
                        if (c != '0')
                        {
                            break;
                        }
                        else
                        {
                            intLength--;
                        }
                    }
                }

                return intLength;
            }
            // 1以上の場合は、小数点右側の桁数を計算する
            else
            {
                int intLength = 0;
                foreach (char c in valueStr)
                {
                    if (c == '-' || c == '+') { continue; }
                    if (c == '.') { break; }

                    intLength++;
                }

                return intLength;
            }
        }
        #endregion
        #endregion

        #region Stubs

        [Obsolete]
        public static decimal GetHoteiKensaRyokin(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban, string kensaShubetsu)
        {
            return HoteiKensaUtility.GetHoteiKensaRyokin(jokasoHokenjoCd, jokasoTorokuNendo, jokasoRenban, kensaShubetsu);
        }
        
        #endregion

        #endregion
    }
}
