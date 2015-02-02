using System.Diagnostics;
using FukjBizSystem.Application.BusinessLogic.Common;

namespace FukjBizSystem.Application.Utility
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiriUtility
    /// <summary>
    /// 経理関連のユーティリティクラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KeiriUtility
    {
        #region 定数定義

        #region 請求区分
        /// <summary>
        /// 請求区分
        /// </summary>
        public static class SeikyuKbnConstant
        {
            /// <summary>
            /// 検査手数料
            /// </summary>
            public static readonly string KensaTesuryo = "1";
            /// <summary>
            /// 計量証明
            /// </summary>
            public static readonly string KeiryoShomei = "2";
            /// <summary>
            /// 用紙販売
            /// </summary>
            public static readonly string YoshiHanbai = "3";
        }
        #endregion

        #region 入金区分
        /// <summary>
        /// 入金区分
        /// </summary>
        public static class NyukinKbnConstant
        {
            /// <summary>
            /// 前受金
            /// </summary>
            public static readonly string Makeukekin = "2";
            /// <summary>
            /// 用紙販売
            /// </summary>
            public static readonly string YoshiHanbai = "3";
            /// <summary>
            /// 計量証明
            /// </summary>
            public static readonly string KeiryoShomei = "5";
            /// <summary>
            /// 検査手数料
            /// </summary>
            public static readonly string KensaTesuryo = "6";
        }
        #endregion

        #endregion


        #region public メソッド

        #region ChkSeikyuSumi
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChkSeikyuSumi
        /// <summary>
        /// 請求明細データの有無を取得
        /// （引数で指定された区分、キー値と一致するデータの有無を取得）
        /// </summary>
        /// <param name="seikyuKbn">請求区分（1:検査手数料/2:計量証明/3:用紙販売）</param>
        /// <param name="key1">検索キー1（請求区分=1の場合：検査依頼法定区分、2の場合：計量証明検査依頼年度、3の場合：用紙販売注文No）</param>
        /// <param name="key2">検索キー2（請求区分=1の場合：検査依頼保健所コード、2の場合：計量証明支所コード）</param>
        /// <param name="key3">検索キー3（請求区分=1の場合：検査依頼年度、2の場合：計量証明依頼連番）</param>
        /// <param name="key4">検索キー4（請求区分=1の場合：検査依頼連番）</param>
        /// <returns>返却区分（-1：区分対象外/0：請求データなし/1：請求データあり）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static int ChkSeikyuSumi(string seikyuKbn, string key1, string key2 = "", string key3 = "", string key4 = "")
        {
            int retKbn = 0;

            // パラメータチェック
            if (!(!string.IsNullOrEmpty(seikyuKbn)
                && (seikyuKbn == SeikyuKbnConstant.KensaTesuryo || seikyuKbn == SeikyuKbnConstant.KeiryoShomei || seikyuKbn == SeikyuKbnConstant.YoshiHanbai)))
            {
                // パラメータ.請求区分が1,2,3以外だった場合
                // 返却区分対象外
                retKbn = -1;
            }

            // 請求データの有無をチェック
            if (seikyuKbn == SeikyuKbnConstant.KensaTesuryo)
            {
                // 検査手数料
                // パラメータ．請求区分=1  ⇒ 請求項目区分[SeikyuKomokuKbn]=1
                IGetSeikyuDtlTblByKensaIraiNoBLInput input = new GetSeikyuDtlTblByKensaIraiNoBLInput();
                // 検査依頼法定区分
                input.KensaIraiHoteiKbn = key1;
                // 検査依頼保健所コード
                input.KensaIraiHokenjoCd = key2;
                // 検査依頼年度
                input.KensaIraiNendo = key3;
                // 検査依頼連番
                input.KensaIraiRenban = key4;
                // 指定された検査依頼番号と一致する請求明細データを取得
                IGetSeikyuDtlTblByKensaIraiNoBLOutput output = new GetSeikyuDtlTblByKensaIraiNoBusinessLogic().Execute(input);
                if (output.SeikyuDtlTblDT != null && output.SeikyuDtlTblDT.Rows.Count > 0)
                {
                    // 一致する請求データあり
                    retKbn = 1;
                }
            }
            else if (seikyuKbn == SeikyuKbnConstant.KeiryoShomei)
            {
                // 計量証明
                // パラメータ．請求区分=2  ⇒ 請求項目区分[SeikyuKomokuKbn]=2
                IGetSeikyuDtlTblByKeiryoShomeiNoBLInput input = new GetSeikyuDtlTblByKeiryoShomeiNoBLInput();
                // 計量証明検査依頼年度
                input.KeiryoShomeiIraiNendo = key1;
                // 計量証明支所コード
                input.KeiryoShomeiIraiSishoCd = key2;
                // 計量証明依頼連番
                input.KeiryoShomeiIraiRenban = key3;
                // 指定された計量証明番号と一致する請求明細データを取得
                IGetSeikyuDtlTblByKeiryoShomeiNoBLOutput output = new GetSeikyuDtlTblByKeiryoShomeiNoBusinessLogic().Execute(input);
                if (output.SeikyuDtlTblDT != null && output.SeikyuDtlTblDT.Rows.Count > 0)
                {
                    // 一致する請求データあり
                    retKbn = 1;
                }
            }
            else if (seikyuKbn == SeikyuKbnConstant.YoshiHanbai)
            {
                // 用紙販売
                // パラメータ．請求区分=3  ⇒ 請求項目区分[SeikyuKomokuKbn]=3 or 4
                IGetSeikyuDtlTblByYoshiHanbaiNoBLInput input = new GetSeikyuDtlTblByYoshiHanbaiNoBLInput();
                // 用紙販売注文No
                input.YoshiHanbaiNo = key1;
                // 指定された用紙販売注文番号と一致する請求明細データを取得
                IGetSeikyuDtlTblByYoshiHanbaiNoBLOutput output = new GetSeikyuDtlTblByYoshiHanbaiNoBusinessLogic().Execute(input);
                if (output.SeikyuDtlTblDT != null && output.SeikyuDtlTblDT.Rows.Count > 0)
                {
                    // 一致する請求データあり
                    retKbn = 1;
                }
            }
            else
            {
                // パラメータ.請求区分が1,2,3以外だった場合
                // 返却区分対象外
                retKbn = -1;
            }

#if DEBUG
            Debug.WriteLine("返却区分：" + retKbn);
#endif
            return retKbn;
        }
        #endregion

        #region ChkNyukinSumi
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChkNyukinSumi
        /// <summary>
        /// 入金データの有無を取得
        /// （引数で指定された区分、キー値と一致するデータの有無を取得）
        /// </summary>
        /// <param name="nyukinKbn">入金区分（2:前受金/3:用紙販売/5:計量証明/6:検査手数料）</param>
        /// <param name="key1">検索キー1（入金区分=2の場合：前受照合番号１、3の場合：用紙販売注文No、5の場合：計量証明検査依頼年度、6の場合：検査依頼法定区分）</param>
        /// <param name="key2">検索キー2（入金区分=2の場合：前受照合番号２、5の場合：計量証明支所コード、6の場合：検査依頼保健所コード）</param>
        /// <param name="key3">検索キー3（入金区分=5の場合：計量証明依頼連番、6の場合：検査依頼年度）</param>
        /// <param name="key4">検索キー4（入金区分=6の場合：検査依頼連番）</param>
        /// <returns>返却区分（-1：区分対象外/0：入金データなし/1：入金データあり）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static int ChkNyukinSumi(string nyukinKbn, string key1, string key2 = "", string key3 = "", string key4 = "")
        {
            int retKbn = 0;

            // パラメータチェック
            if (!(!string.IsNullOrEmpty(nyukinKbn)
                && (nyukinKbn == NyukinKbnConstant.Makeukekin || nyukinKbn == NyukinKbnConstant.YoshiHanbai || nyukinKbn == NyukinKbnConstant.KeiryoShomei || nyukinKbn == NyukinKbnConstant.KensaTesuryo)))
            {
                // パラメータ.入金区分2,3,5,6以外だった場合
                // 返却区分対象外
                retKbn = -1;
            }

            // 入金データの有無をチェック
            if (nyukinKbn == NyukinKbnConstant.Makeukekin)
            {
                // 前受金
                IGetNyukinTblByMaeukekinShogoNoBLInput input = new GetNyukinTblByMaeukekinShogoNoBLInput();
                // 前受照合番号
                input.MaeukekinShogoNo = key1 + key2;
                // 指定された前受照合番号と一致する入金データを取得
                IGetNyukinTblByMaeukekinShogoNoBLOutput output = new GetNyukinTblByMaeukekinShogoNoBusinessLogic().Execute(input);
                if (output.NyukinTblDT != null && output.NyukinTblDT.Rows.Count > 0)
                {
                    // 一致する入金データあり
                    retKbn = 1;
                }
            }
            else if (nyukinKbn == NyukinKbnConstant.YoshiHanbai)
            {
                // 用紙販売
                IGetNyukinTblByYoshiHanbaiNoBLInput input = new GetNyukinTblByYoshiHanbaiNoBLInput();
                // 用紙販売注文No
                input.YoshiHanbaiNo = key1;
                // 指定された用紙販売注文番号と一致する入金データを取得
                IGetNyukinTblByYoshiHanbaiNoBLOutput output = new GetNyukinTblByYoshiHanbaiNoBusinessLogic().Execute(input);
                if (output.NyukinTblDT != null && output.NyukinTblDT.Rows.Count > 0)
                {
                    // 一致する入金データあり
                    retKbn = 1;
                }
            }
            else if (nyukinKbn == NyukinKbnConstant.KeiryoShomei)
            {
                // 計量証明
                IGetNyukinTblByKeiryoShomeiNoBLInput input = new GetNyukinTblByKeiryoShomeiNoBLInput();
                // 計量証明検査依頼年度
                input.KeiryoShomeiIraiNendo = key1;
                // 計量証明支所コード
                input.KeiryoShomeiIraiSishoCd = key2;
                // 計量証明依頼連番
                input.KeiryoShomeiIraiRenban = key3;
                // 指定された計量証明番号と一致する入金データを取得
                IGetNyukinTblByKeiryoShomeiNoBLOutput output = new GetNyukinTblByKeiryoShomeiNoBusinessLogic().Execute(input);
                if (output.NyukinTblDT != null && output.NyukinTblDT.Rows.Count > 0)
                {
                    // 一致する入金データあり
                    retKbn = 1;
                }
            }
            else if (nyukinKbn == NyukinKbnConstant.KensaTesuryo)
            {
                // 検査手数料
                IGetNyukinTblByKensaIraiNoBLInput input = new GetNyukinTblByKensaIraiNoBLInput();
                // 検査依頼法定区分
                input.KensaIraiHoteiKbn = key1;
                // 検査依頼保健所コード
                input.KensaIraiHokenjoCd = key2;
                // 検査依頼年度
                input.KensaIraiNendo = key3;
                // 検査依頼連番
                input.KensaIraiRenban = key4;
                // 指定された検査依頼番号と一致する入金データを取得
                IGetNyukinTblByKensaIraiNoBLOutput output = new GetNyukinTblByKensaIraiNoBusinessLogic().Execute(input);
                if (output.NyukinTblDT != null && output.NyukinTblDT.Rows.Count > 0)
                {
                    // 一致する入金データあり
                    retKbn = 1;
                }
            }
            else
            {
                // パラメータ.入金区分が2,3,5,6以外だった場合
                // 返却区分対象外
                retKbn = -1;
            }

#if DEBUG
            Debug.WriteLine("返却区分：" + retKbn);
#endif
            return retKbn;
        }
        #endregion

        #endregion
    }
}
