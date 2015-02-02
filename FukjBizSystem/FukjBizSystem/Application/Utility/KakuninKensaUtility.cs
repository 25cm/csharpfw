using FukjBizSystem.Application.DataAccess.KensaDaichoDtlTbl;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.Utility
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninKensaUtility
    /// <summary>
    /// 水質検査の確認検査関連のユーティリティクラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/13　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KakuninKensaUtility
    {
        #region 定数定義

        #region 請求区分
        /// <summary>
        /// 請求区分
        /// </summary>
        public static class ResultCode
        {
            /// <summary>
            /// 未判定
            /// </summary>
            public static readonly string Mihantei = "0";
            /// <summary>
            /// 正常
            /// </summary>
            public static readonly string Success = "1";
            /// <summary>
            /// 以上
            /// </summary>
            public static readonly string Error = "2";
        }
        #endregion

        #endregion


        #region メソッド(public)

        #region SetKakuninKensaShubetsuForHoteiKensa
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKakuninKensaShubetsuForHoteiKensa
        /// <summary>
        /// 確認検査種別設定
        /// （法定検査用）
        /// </summary>
        /// <param name="kensaDaicho11HdrRow">検査台帳（11条）ヘッダテーブル情報</param>
        /// <param name="kensaDaichoDtlRow">検査台帳明細テーブル情報</param>
        /// <param name="kensaKekkaIraiHoteiKbn">検査依頼法定区分</param>
        /// <param name="kensaKekkaIraiHokenjoCd">検査依頼保健所コード</param>
        /// <param name="kensaKekkaIraiNendo">検査依頼年度</param>
        /// <param name="kensaKekkaIraiRenban">検査依頼連番</param>
        /// <param name="kensaKbn">検査区分(1:計量証明、2:水質検査、3:外観検査)</param>
        /// <param name="iraiNendo">依頼年度</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="suishituKensaIraiNo">水質検査依頼番号</param>
        /// <param name="shikenkoumokuCd">試験項目コード</param>
        /// <param name="kekkaValue">結果値</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/29  宗          水質検査と外観検査の項目コードを別枠で取得
        ///                         ATUBODの判定を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void SetKakuninKensaShubetsuForHoteiKensa(
            KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblRow kensaDaicho11HdrRow,
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow kensaDaichoDtlRow,
            string kensaKekkaIraiHoteiKbn,
            string kensaKekkaIraiHokenjoCd,
            string kensaKekkaIraiNendo,
            string kensaKekkaIraiRenban,
            string kensaKbn,
            string iraiNendo,
            string shishoCd,
            string suishitsuKensaIraiNo,
            string shikenkoumokuCd,
            decimal kekkaValue)
        {
            // 水質検査項目コードを取得
            // pH
            string kensaKomokuCd_pH = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_001);
            // 透視度
            string kensaKomokuCd_Tr = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
            // BOD
            string kensaKomokuCd_BOD = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_003);
            // 残留塩素
            string kensaKomokuCd_Zanen = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);
            // 塩化物イオン
            string kensaKomokuCd_Cl = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_005);

            // 外観検査項目コードを取得
            // BOD
            string kensaGaikanKomokuCd_BOD = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_078, Constants.ConstRenbanConstanst.CONST_RENBAN_001);
            // 塩化物イオン
            string kensaGaikanKomokuCd_Cl = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_078, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
            // ATUBOD
            string kensaGaikanKomokuCd_ATUBOD = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_078, Constants.ConstRenbanConstanst.CONST_RENBAN_003);

            // 対象の検査依頼取得
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDt = Boundary.Common.Common.GetKensaIraiTblByKey(
                kensaKekkaIraiHoteiKbn,
                kensaKekkaIraiHokenjoCd,
                kensaKekkaIraiNendo,
                kensaKekkaIraiRenban);
            if (kensaIraiDt.Rows.Count <= 0)
            {
                return;
            }

            // 対象の検査台帳明細取得
            ISelectKensaDaichoDtlTblByCondDAInput selDtlIn = new SelectKensaDaichoDtlTblByCondDAInput();
            selDtlIn.Kbn = kensaKbn;
            selDtlIn.IraiNendo = iraiNendo;
            selDtlIn.Sisho = shishoCd;
            selDtlIn.IraiNo = suishitsuKensaIraiNo;
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT =
                new SelectKensaDaichoDtlTblByCondDataAccess().Execute(selDtlIn).KensaDaichoDtlTblDT;

            //if (shikenkoumokuCd == kensaKomokuCd_BOD)
            if ((shikenkoumokuCd == kensaKomokuCd_BOD) || (shikenkoumokuCd == kensaGaikanKomokuCd_BOD) || (shikenkoumokuCd == kensaGaikanKomokuCd_ATUBOD))
            {
                // BOD

                // 確認検査種別（BOD/透視度）
                kensaDaichoDtlRow.KensaShubetsuBodTr = KakuninKensaUtility.CheckBODTrFromBOD(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    kensaIraiDt[0].KensaIraiJokasoHokenjoCd,
                    kensaIraiDt[0].KensaIraiJokasoTorokuNendo,
                    kensaIraiDt[0].KensaIraiJokasoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    kensaIraiDt[0].KensaIraiHoryusakiCd);

                // 確認検査種別（BOD基準値オーバー）
                kensaDaichoDtlRow.KensaShubetsuBodOver = KakuninKensaUtility.CheckBodOver(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    kensaIraiDt[0].KensaIraiJokasoHokenjoCd,
                    kensaIraiDt[0].KensaIraiJokasoTorokuNendo,
                    kensaIraiDt[0].KensaIraiJokasoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    kensaIraiDt[0].KensaIraiHoryusakiCd);

                // スクリーニング候補(BOD/残留塩素)
                kensaDaicho11HdrRow.ScreeningKoho = KakuninKensaUtility.CheckScreeningKohoFromBOD(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    kensaIraiDt[0].KensaIraiShorihoshikiCd,
                    kensaIraiDt[0].KensaIraiShorimokuhyoSuishitsu);
            }
            else if (shikenkoumokuCd == kensaKomokuCd_Tr)
            {
                // Tr:透視度

                // 確認検査種別（BOD/透視度）
                kensaDaichoDtlRow.KensaShubetsuBodTr = KakuninKensaUtility.CheckBODTrFromTr(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    kensaIraiDt[0].KensaIraiJokasoHokenjoCd,
                    kensaIraiDt[0].KensaIraiJokasoTorokuNendo,
                    kensaIraiDt[0].KensaIraiJokasoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    kensaIraiDt[0].KensaIraiHoryusakiCd);
            }
            //else if (shikenkoumokuCd == kensaKomokuCd_Cl)
            else if ((shikenkoumokuCd == kensaKomokuCd_Cl) || (shikenkoumokuCd == kensaGaikanKomokuCd_Cl))
            {
                // Cl:塩化イオン

                // 確認検査種別（塩化物イオン確認検査）
                kensaDaichoDtlRow.KensaShubetsuEnkaIon = KakuninKensaUtility.CheckEnkaIon(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    kensaIraiDt[0].KensaIraiJokasoHokenjoCd,
                    kensaIraiDt[0].KensaIraiJokasoTorokuNendo,
                    kensaIraiDt[0].KensaIraiJokasoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    kensaIraiDt[0].KensaIraiHoryusakiCd);

                // クロスチェック異常（水質判定表）
                if (kensaDaichoDtlRow.KensaShubetsuEnkaIon == KakuninKensaUtility.ResultCode.Success)
                {
                    // 0=対象外
                    kensaDaicho11HdrRow.CrossCheckSuishitsu = "0";
                }
                else
                {
                    // 1=対象
                    kensaDaicho11HdrRow.CrossCheckSuishitsu = "1";
                }
            }
            else if (shikenkoumokuCd == kensaKomokuCd_Zanen)
            {
                // 残留塩素

                // スクリーニング候補(BOD/残留塩素)
                kensaDaicho11HdrRow.ScreeningKoho = KakuninKensaUtility.CheckScreeningKohoFromZanen(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    kensaIraiDt[0].KensaIraiShorihoshikiCd,
                    kensaIraiDt[0].KensaIraiShorimokuhyoSuishitsu);
            }

            // 確認検査種別（過去との比較）
            kensaDaichoDtlRow.KensaShubetsuKako = KakuninKensaUtility.CheckKakoForHoteiKensa(
                kekkaValue,
                kensaIraiDt[0].KensaIraiJokasoHokenjoCd,
                kensaIraiDt[0].KensaIraiJokasoTorokuNendo,
                kensaIraiDt[0].KensaIraiJokasoRenban,
                kensaDaicho11HdrRow.KensaIraiUketsukeDt,
                shikenkoumokuCd);

            // クロスチェック異常（過去履歴）
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'");
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            kensaDaicho11HdrRow.CrossCheckKako = "0";
            foreach (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow in rows)
            {
                string kensaShubetsuKako = dtlRow.KensaShubetsuKako;
                if (dtlRow.ShikenkoumokuCd == shikenkoumokuCd)
                {
                    // 今回の検査対象は、今回の結果で判定
                    kensaShubetsuKako = kensaDaichoDtlRow.KensaShubetsuKako;
                }
                if (kensaShubetsuKako == KakuninKensaUtility.ResultCode.Error)
                {
                    // 以上の時は、1(対象)に設定
                    kensaDaicho11HdrRow.CrossCheckKako = "1";
                }
            }
        }
        #endregion

        #region SetKakuninKensaShubetsuForKeiryoShomei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKakuninKensaShubetsuForKeiryoShomei
        /// <summary>
        /// 確認検査種別設定
        /// （計量証明用）
        /// </summary>
        /// <param name="kensaDaicho9HdrRow">検査台帳（9条）ヘッダテーブル情報</param>
        /// <param name="kensaDaichoDtlRow">検査台帳明細テーブル情報</param>
        /// <param name="keiryoShomeiIraiNendo">計量証明検査依頼年度</param>
        /// <param name="keiryoShomeiIraiSishoCd">計量証明支所コード</param>
        /// <param name="keiryoShomeiIraiRenban">計量証明依頼連番</param>
        /// <param name="kensaKbn">検査区分(1:計量証明、2:水質検査、3:外観検査)</param>
        /// <param name="iraiNendo">依頼年度</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="suishituKensaIraiNo">水質検査依頼番号</param>
        /// <param name="shikenkoumokuCd">試験項目コード</param>
        /// <param name="kekkaValue">結果値</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void SetKakuninKensaShubetsuForKeiryoShomei(
            KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblRow kensaDaicho9HdrRow,
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow kensaDaichoDtlRow,
            string keiryoShomeiIraiNendo,
            string keiryoShomeiIraiSishoCd,
            string keiryoShomeiIraiRenban,
            string kensaKbn,
            string iraiNendo,
            string shishoCd,
            string suishitsuKensaIraiNo,
            string shikenkoumokuCd,
            decimal kekkaValue)
        {
            // 水質検査項目コードを取得
            // SS
            string kensaKomokuCd_SS = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "002");
            // 透視度
            string kensaKomokuCd_Tr = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "029");
            // BOD
            string kensaKomokuCd_BOD = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "019");
            // 塩化物イオン
            string kensaKomokuCd_Cl = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "005");
            // アンモニア
            string kensaKomokuCd_Anmonia = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "004");
            // 全窒素
            string kensaKomokuCd_Tn = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "016");
            // COD
            string kensaKomokuCd_COD = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "006");

            // 対象の計量証明依頼取得
            KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable keiryoIraiDt = Boundary.Common.Common.GetKeiryoShomeiIraiTblByKey(
                keiryoShomeiIraiNendo,
                keiryoShomeiIraiSishoCd,
                keiryoShomeiIraiRenban);
            if (keiryoIraiDt.Rows.Count <= 0)
            {
                return;
            }

            // 対象の検査台帳明細取得
            ISelectKensaDaichoDtlTblByCondDAInput selDtlIn = new SelectKensaDaichoDtlTblByCondDAInput();
            selDtlIn.Kbn = kensaKbn;
            selDtlIn.IraiNendo = iraiNendo;
            selDtlIn.Sisho = shishoCd;
            selDtlIn.IraiNo = suishitsuKensaIraiNo;
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT =
                new SelectKensaDaichoDtlTblByCondDataAccess().Execute(selDtlIn).KensaDaichoDtlTblDT;

            if (shikenkoumokuCd == kensaKomokuCd_SS)
            {
                // SS

                // 確認検査種別（SS/透視度）
                kensaDaichoDtlRow.KensaShubetsuSsTr = KakuninKensaUtility.CheckSSTrFromSS(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoHokenjoCd,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoNendo,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    keiryoIraiDt[0].KeiryoShomeiSuisitsuCd);
            }
            else if (shikenkoumokuCd == kensaKomokuCd_BOD)
            {
                // BOD

                // 確認検査種別（BOD/透視度）
                kensaDaichoDtlRow.KensaShubetsuBodTr = KakuninKensaUtility.CheckBODTrFromBOD(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoHokenjoCd,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoNendo,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    keiryoIraiDt[0].KeiryoShomeiSuisitsuCd);
            }
            else if (shikenkoumokuCd == kensaKomokuCd_Tr)
            {
                // Tr:透視度

                // 確認検査種別（SS/透視度）
                kensaDaichoDtlRow.KensaShubetsuSsTr = KakuninKensaUtility.CheckSSTrFromTr(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoHokenjoCd,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoNendo,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    keiryoIraiDt[0].KeiryoShomeiSuisitsuCd);

                // 確認検査種別（BOD/透視度）
                kensaDaichoDtlRow.KensaShubetsuBodTr = KakuninKensaUtility.CheckBODTrFromTr(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoHokenjoCd,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoNendo,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    keiryoIraiDt[0].KeiryoShomeiSuisitsuCd);
            }
            else if (shikenkoumokuCd == kensaKomokuCd_Cl)
            {
                // Cl:塩化イオン

                // 確認検査種別（塩化物イオン確認検査）
                kensaDaichoDtlRow.KensaShubetsuEnkaIon = KakuninKensaUtility.CheckEnkaIon(
                    kensaDaichoDtlDT,
                    kekkaValue,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoHokenjoCd,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoNendo,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoRenban,
                    kensaKbn,
                    iraiNendo,
                    shishoCd,
                    suishitsuKensaIraiNo,
                    keiryoIraiDt[0].KeiryoShomeiSuisitsuCd);
            }
            else if (shikenkoumokuCd == kensaKomokuCd_Anmonia)
            {
                // アンモニア

                // 確認検査種別（アンモニア確認検査）
                kensaDaichoDtlRow.KensaShubetsuAnmonia = KakuninKensaUtility.CheckAnmonia(
                    kekkaValue,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoHokenjoCd,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoNendo,
                    keiryoIraiDt[0].KeiryoShomeiJokasoDaichoRenban);

                // 確認検査種別（アンモニアと全窒素比較）
                kensaDaichoDtlRow.KensaShubetsuAnmoniaTn = KakuninKensaUtility.CheckAnmoniaTnFromAnmonia(
                    kensaDaichoDtlDT,
                    kekkaValue);
            }
            else if (shikenkoumokuCd == kensaKomokuCd_Tn)
            {
                // 全窒素

                // 確認検査種別（アンモニア確認検査）
                kensaDaichoDtlRow.KensaShubetsuAnmoniaTn = KakuninKensaUtility.CheckAnmoniaTnFromTn(
                    kensaDaichoDtlDT,
                    kekkaValue);
            }
            else if (shikenkoumokuCd == kensaKomokuCd_COD)
            {
                // COD

                // 確認検査種別（COD基準値オーバー）
                kensaDaichoDtlRow.KensaShubetsuCodOver = KakuninKensaUtility.CheckCodOver(
                    kekkaValue);
            }

            // 確認検査種別（過去との比較）
            kensaDaichoDtlRow.KensaShubetsuKako = KakuninKensaUtility.CheckKakoForKeiryoShomei(
                kekkaValue,
                keiryoIraiDt[0].KeiryoShomeiJokasoDaichoHokenjoCd,
                keiryoIraiDt[0].KeiryoShomeiJokasoDaichoNendo,
                keiryoIraiDt[0].KeiryoShomeiJokasoDaichoRenban,
                kensaDaicho9HdrRow.KensaIraiUketsukeDt,
                shikenkoumokuCd);
        }
        #endregion

        #endregion


        #region メソッド(private)

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckBODTrFromBOD
        /// <summary>
        /// 確認検査種別(BOD/透視度)の検査
        /// （BOD変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueBOD"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckBODTrFromBOD(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueBOD,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string suishitsuCd)
        {
            // 水質検査項目コードを取得
            // 透視度
            string kensaKomokuCd_Tr = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);

            // 透視度の値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_Tr);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            // intに変換（共通メソッドで、透視度は int型でパースしているため）
            string valueTr = ((int)(dtlRow.KeiryoShomeiKekkaValue)).ToString();

            // 確認検査種別(BOD/透視度)の検査
            string result = KensaHanteiUtility.KakuninKensaShubetsuBODToshido(
                suishitsuCd,
                valueBOD.ToString(),
                valueTr,
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckBODTrFromTr
        /// <summary>
        /// 確認検査種別(BOD/透視度)の検査
        /// （透視度変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueBOD"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckBODTrFromTr(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueTr,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string suishitsuCd)
        {
            // 水質検査項目コードを取得
            // BOD
            string kensaKomokuCd_BOD = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_003);

            // BODの値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_BOD);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            string valueBOD = dtlRow.KeiryoShomeiKekkaValue.ToString();

            // intに変換（共通メソッドで、透視度は int型でパースしているため）
            string valueTrStr = ((int)(valueTr)).ToString();

            // 確認検査種別(BOD/透視度)の検査
            string result = KensaHanteiUtility.KakuninKensaShubetsuBODToshido(
                suishitsuCd,
                valueBOD,
                valueTrStr,
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckBodOver
        /// <summary>
        /// 確認検査種別（BOD基準値オーバー）の検査
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueBOD"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckBodOver(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueBOD,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string suishitsuCd)
        {
            // 確認検査種別(BOD基準値オーバー)
            string result = KensaHanteiUtility.KakuninKensaShubetsuBODKijyunOver(
                suishitsuCd,
                valueBOD.ToString(),
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckEnkaIon
        /// <summary>
        /// 確認検査種別（塩化物イオン確認検査）の検査
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueBOD"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckEnkaIon(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueCl,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string suishitsuCd)
        {
            // 確認検査種別（塩化物イオン確認検査）
            string result = KensaHanteiUtility.KakuninKensaShubetsuEnkabutsuIonKensa(
                valueCl.ToString(),
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakoForHoteiKensa
        /// <summary>
        /// 確認検査種別(過去との比較)の検査
        /// （法定検査用）
        /// </summary>
        /// <param name="valueKekka"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="uketsukeDt"></param>
        /// <param name="shikenkoumokuCd"></param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckKakoForHoteiKensa(
            decimal valueKekka,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string uketsukeDt,
            string shikenkoumokuCd)
        {
            // 確認検査種別(過去との比較)
            string result = KensaHanteiUtility.KakuninKensaShubetsuKakoHikaku(
                "1",
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban,
                uketsukeDt,
                shikenkoumokuCd,
                valueKekka);

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckScreeningKohoFromBOD
        /// <summary>
        /// スクリニング候補判定
        /// （BOD変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueBOD"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckScreeningKohoFromBOD(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueBOD,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string shoriHoshikiCd,
            int shoriMokuhyoSuishitsu)
        {
            // 水質検査項目コードを取得
            // 残留塩素
            string kensaKomokuCd_Zanen = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);

            // 残留塩素の値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_Zanen);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            string valueZanen = dtlRow.KeiryoShomeiKekkaValue.ToString();

            // スクリーニング判定
            string result = KensaHanteiUtility.ScreeningHantei(
                shoriHoshikiCd,
                shoriMokuhyoSuishitsu.ToString(),
                valueBOD.ToString(),
                valueZanen);

            return result;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckScreeningKohoFromZanen
        /// <summary>
        /// スクリニング候補判定
        /// （残留塩素変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueBOD"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckScreeningKohoFromZanen(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueZanen,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string shoriHoshikiCd,
            int shoriMokuhyoSuishitsu)
        {
            // 水質検査項目コードを取得
            // BOD
            string kensaKomokuCd_BOD = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_003);

            // BODの値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_BOD);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            string valueBOD = dtlRow.KeiryoShomeiKekkaValue.ToString();

            // スクリーニング判定
            string result = KensaHanteiUtility.ScreeningHantei(
                shoriHoshikiCd,
                shoriMokuhyoSuishitsu.ToString(),
                valueBOD,
                valueZanen.ToString());

            return result;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckSSTrFromSS
        /// <summary>
        /// 確認検査種別（SS/透視度）の検査
        /// （SS変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueSS"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckSSTrFromSS(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueSS,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string suishitsuCd)
        {
            // 水質検査項目コードを取得
            // 透視度
            string kensaKomokuCd_Tr = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "029");

            // 透視度の値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_Tr);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            // intに変換（共通メソッドで、透視度は int型でパースしているため）
            string valueTr = ((int)(dtlRow.KeiryoShomeiKekkaValue)).ToString();

            // 確認検査種別（SS/透視度）の検査
            string result = KensaHanteiUtility.KakuninKensaShubetsuSSToshido(
                suishitsuCd,
                valueSS.ToString(),
                valueTr,
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckSSTrFromTr
        /// <summary>
        /// 確認検査種別（SS/透視度）の検査
        /// （透視度変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueTr"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckSSTrFromTr(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueTr,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string kensaKbn,
            string iraiNendo,
            string shisho,
            string suishituKensaIraiNo,
            string suishitsuCd)
        {
            // 水質検査項目コードを取得
            // SS
            string kensaKomokuCd_SS = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "002");

            // SSの値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_SS);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            string valueSS = dtlRow.KeiryoShomeiKekkaValue.ToString();

            // intに変換（共通メソッドで、透視度は int型でパースしているため）
            string valueTrStr = ((int)(valueTr)).ToString();

            // 確認検査種別（SS/透視度）の検査
            string result = KensaHanteiUtility.KakuninKensaShubetsuSSToshido(
                suishitsuCd,
                valueSS,
                valueTrStr,
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckAnmonia
        /// <summary>
        /// 確認検査種別（アンモニア確認検査）の検査
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueAnmonia"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckAnmonia(
            decimal valueAnmonia,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban)
        {
            // 確認検査種別（アンモニア確認検査）
            string result = KensaHanteiUtility.KakuninKensaShubetsuAnmoniaKensa(
                valueAnmonia.ToString(),
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckAnmoniaTnFromAnmonia
        /// <summary>
        /// 確認検査種別（アンモニアと全窒素比較）の検査
        /// （アンモニア変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueAnmonia"></param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckAnmoniaTnFromAnmonia(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueAnmonia)
        {
            // 水質検査項目コードを取得
            // 全窒素
            string kensaKomokuCd_Tn = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "016");

            // 全窒素の値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_Tn);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            string valueTn = dtlRow.KeiryoShomeiKekkaValue.ToString();

            // 確認検査種別（アンモニアと全窒素比較）
            string result = KensaHanteiUtility.KakuninKensaShubetsuAnmoniaTNHikaku(
                valueAnmonia.ToString(),
                valueTn
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckAnmoniaTnFromTn
        /// <summary>
        /// 確認検査種別（アンモニアと全窒素比較）の検査
        /// （全窒素変更時）
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueAnmonia"></param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckAnmoniaTnFromTn(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            decimal valueTn)
        {
            // 水質検査項目コードを取得
            // アンモニア
            string kensaKomokuCd_Anmonia = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, "004");

            // アンモニアの値を取得
            // 結果入力（1=入力済）、採用区分（1=採用）
            string selDtlStr = string.Format("ShikenkoumokuCd = '{0}' and KeiryoShomeiKekkaNyuryoku = '1' and KeiryoShomeiSaiyoKbn = '1'", kensaKomokuCd_Anmonia);
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[] rows = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow[])kensaDaichoDtlDT.Select(selDtlStr);
            if (rows.Length <= 0)
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow)rows[0];
            if (dtlRow.IsKeiryoShomeiKekkaValueNull())
            {
                // 未判定
                return ResultCode.Mihantei;
            }
            string valueAnmonia = dtlRow.KeiryoShomeiKekkaValue.ToString();

            // 確認検査種別（アンモニアと全窒素比較）
            string result = KensaHanteiUtility.KakuninKensaShubetsuAnmoniaTNHikaku(
                valueAnmonia,
                valueTn.ToString()
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckCodOver
        /// <summary>
        /// 確認検査種別（COD基準値オーバー）の検査
        /// </summary>
        /// <param name="kensaDaichoDtlDT"></param>
        /// <param name="valueAnmonia"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKbn"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="shisho"></param>
        /// <param name="suishituKensaIraiNo"></param>
        /// <param name="suishitsuCd">法定検査:放流先コード[KensaIraiHoryusakiCd]/計量証明:計量証明水質コード[KeiryoShomeiSuisitsuCd]</param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckCodOver(decimal valueCOD)
        {
            // 確認検査種別（COD基準値オーバー）
            string result = KensaHanteiUtility.KakuninKensaShubetsuCODKijyunOver(
                valueCOD.ToString()
            );

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakoForKeiryoShomei
        /// <summary>
        /// 確認検査種別(過去との比較)の検査
        /// （計量証明用）
        /// </summary>
        /// <param name="valueKekka"></param>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="uketsukeDt"></param>
        /// <param name="shikenkoumokuCd"></param>
        /// <returns>確認検査種別（0=未判定、1=正常、2=異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// 2015/01/26  宗          戻り値の判定を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static string CheckKakoForKeiryoShomei(
            decimal valueKekka,
            string jokasoHokenjoCd,
            string jokasoTorokuNendo,
            string jokasoRenban,
            string uketsukeDt,
            string shikenkoumokuCd)
        {
            // 確認検査種別(過去との比較)
            string result = KensaHanteiUtility.KakuninKensaShubetsuKakoHikaku(
                "2",
                jokasoHokenjoCd,
                jokasoTorokuNendo,
                jokasoRenban,
                uketsukeDt,
                shikenkoumokuCd,
                valueKekka);

            //if (result != KensaHanteiUtility.ERR_OK)
            if (result == KensaHanteiUtility.ERR_ERR)
            {
                return ResultCode.Error;
            }

            return ResultCode.Success;
        }

        #endregion
    }
}
