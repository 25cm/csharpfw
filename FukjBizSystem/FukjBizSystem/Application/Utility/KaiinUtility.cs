using System.Diagnostics;
using FukjBizSystem.Application.BusinessLogic.Common;

namespace FukjBizSystem.Application.Utility
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaiinUtility
    /// <summary>
    /// 会員関連のユーティリティクラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/18　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KaiinUtility
    {
        #region 定数定義


        #endregion


        #region public メソッド

        #region KaiinHantei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KaiinHantei
        /// <summary>
        /// 会員判定の結果を取得
        /// </summary>
        /// <param name="gyoshaCd">業者コード</param>
        /// <returns>判定結果（0：非会員/1：会員）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/18　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static int KaiinHantei(string gyoshaCd)
        {
            int retKbn = 0;

            // パラメータチェック
            if (!string.IsNullOrEmpty(gyoshaCd))
            {
                // 業者コードが指定されている場合

                IGetGyoshaBukaiMstKaiinHanteiBLInput input = new GetGyoshaBukaiMstKaiinHanteiBLInput();
                // 部会会員コード
                input.BukaiKaiinCd = gyoshaCd;
                // 指定された部会会員コードと一致する業者部会マスタデータを取得
                IGetGyoshaBukaiMstKaiinHanteiBLOutput output = new GetGyoshaBukaiMstKaiinHanteiBusinessLogic().Execute(input);
                if (output.GyoshaBukaiMstDT != null && output.GyoshaBukaiMstDT.Rows.Count > 0)
                {
                    // 一致するデータあり
                    retKbn = 1;
                }
            }

#if DEBUG
            Debug.WriteLine("判定結果：" + retKbn);
#endif
            return retKbn;
        }
        #endregion


        #region KaiinKakakuTekiyoHantei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KaiinKakakuTekiyoHantei
        /// <summary>
        /// 会員価格適用判定の結果を取得
        /// </summary>
        /// <param name="gyoshaCd">業者コード</param>
        /// <returns>判定結果（0：適用対象外/1：適用対象）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/18　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static int KaiinKakakuTekiyoHantei(string gyoshaCd)
        {
            int retKbn = 0;

            // パラメータチェック
            if (!string.IsNullOrEmpty(gyoshaCd))
            {
                // 業者コードが指定されている場合

                // 会員判定の結果を取得
                if (KaiinUtility.KaiinHantei(gyoshaCd) == 1)
                {
                    // 適用対象
                    retKbn = 1;
                }
                else
                {
                    IGetGyoshaMstByGyoshaCdBLInput input = new GetGyoshaMstByGyoshaCdBLInput();
                    // 業者コード
                    input.GyoshaCd = gyoshaCd;
                    // 指定された業者コードと一致する業者マスタデータを取得
                    IGetGyoshaMstByGyoshaCdBLOutput output = new GetGyoshaMstByGyoshaCdBusinessLogic().Execute(input);
                    if (output.GyoshaMstDataTable != null && output.GyoshaMstDataTable.Rows.Count > 0)
                    {
                        // 一致するデータあり
                        if (output.GyoshaMstDataTable[0].KaiinKbn == "1")
                        {
                            // 「1:適用する」の場合のみ適用対象とする
                            retKbn = 1;
                        }
                    }
                }
            }

#if DEBUG
            Debug.WriteLine("判定結果：" + retKbn);
#endif
            return retKbn;
        }
        #endregion

        #endregion
    }
}
