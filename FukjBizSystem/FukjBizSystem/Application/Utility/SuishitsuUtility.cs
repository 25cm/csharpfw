using System;
using System.Diagnostics;
using System.Reflection;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Utility
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuUtility
    /// <summary>
    /// 水質検査関連のユーティリティクラス
    /// 　水質判定などの処理を行うメソッドを提供
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/08　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SuishitsuUtility
    {
        #region 定数定義

        #region 水質検査区分
        /// <summary>
        /// 水質検査区分
        /// </summary>
        public enum SuishitsuKensaKbn
        {
            /// <summary>
            /// pH
            /// </summary>
            PH,
            /// <summary>
            /// 溶存酸素量
            /// </summary>
            YozonSansoRyo,
            /// <summary>
            /// 透視度
            /// </summary>
            Toshido,
            /// <summary>
            /// 残留塩素
            /// </summary>
            Zanryuenso,
            /// <summary>
            /// ＢＯＤ
            /// </summary>
            BOD,
            /// <summary>
            /// 塩化物イオン
            /// </summary>
            EnkabutsuIon,
            /// <summary>
            /// 汚泥沈殿率
            /// </summary>
            OdeiChindenRitsu,
        }
        #endregion

        #endregion


        #region public メソッド

        #region SuishitsuHyokaHantei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SuishitsuHyokaHantei
        /// <summary>
        /// 水質検査の入力値評価
        /// このメソッドは福岡浄化槽様から提供された旧システムの以下のソースから移植しました
        /// 　ソース　：\旧システムソース\パソコンシステムソース\2012_検査システム改造\10.改造_SRC\16.検査結果入力\kensaasn\kensafrm10.cs
        /// 　メソッド：Chk_InputDataメソッド
        /// </summary>
        /// <param name="syoriModel">処理方式（検査依頼テーブル.処理方式区分 1:単独、2:合併 3:小規模合併）</param>
        /// <param name="bodSpec">BOD処理性能（検査依頼テーブル.BOD処理性能）</param>
        /// <param name="kensaKbn">水質チェック項目</param>
        /// <param name="value">チェック数値</param>
        /// <returns>評価（0:エラー/1:○/2:△/3:×/4:－）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/08  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static int SuishitsuHyokaHantei(string syoriModel, string bodSpec, SuishitsuKensaKbn kensaKbn, string value)
        {
            int resultHyokaIndex = 0;
            int decBod = 0;
            if (!Int32.TryParse(bodSpec, out decBod))
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。BOD処理性能:{0}", bodSpec));

#if DEBUG
                Debug.WriteLine("処理モード:" + syoriModel + " BOD性能:" + bodSpec + "検査区分:" + kensaKbn + " 検査対象値:" + value + "→BOD処理性能が数値以外で指定された場合はエラー");
#endif
                // BOD処理性能が数値以外で指定された場合はエラー
                return 0;
            }

            decimal decValue = 0;
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()) || !Decimal.TryParse(value, out decValue))
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。チェック数値"));

#if DEBUG
                Debug.WriteLine("処理モード:" + syoriModel + " BOD性能:" + bodSpec + "検査区分:" + kensaKbn + " 検査対象値:" + value + "→チェック数値が NULLor空文字か数値以外の場合はエラー");
#endif
                // チェック数値が NULLか空文字の場合はエラー
                return 0;
            }

            // pH
            if (kensaKbn == SuishitsuKensaKbn.PH)
            {
                if (value.Trim() != "")
                {
                    double chk_Val = double.Parse(value);
                    // ○
                    if ((5.8 <= chk_Val) && (chk_Val <= 8.6))
                    {
                        resultHyokaIndex = 1;
                    }
                    // △
                    if ((3 <= chk_Val) && (chk_Val < 5.8))
                    {
                        resultHyokaIndex = 2;
                    }
                    if ((8.6 < chk_Val) && (chk_Val <= 10.0))
                    {
                        resultHyokaIndex = 2;
                    }
                    // ×
                    if ((3 > chk_Val) || (chk_Val > 10.0))
                    {
                        resultHyokaIndex = 3;
                    }
                }
            }

            // 残留塩素濃度
            if (kensaKbn == SuishitsuKensaKbn.Zanryuenso)
            {
                if (value.Trim() != "")
                {
                    decimal chk_Val10 = decimal.Parse(value);
                    // ○
                    if (0 < chk_Val10)
                    {
                        resultHyokaIndex = 1;
                    }
                    // △
                    // ×
                    if (0 >= chk_Val10)
                    {
                        resultHyokaIndex = 3;
                    }
                }
            }

            if (syoriModel == "1")
            {
                // 単独

                // 汚泥沈殿率
                if (kensaKbn == SuishitsuKensaKbn.OdeiChindenRitsu)
                {
                    if (value.Trim() != "")
                    {
                        decimal chk_Val1 = decimal.Parse(value);
                        // ○
                        if ((10 <= chk_Val1) && (chk_Val1 <= 60))
                        {
                            resultHyokaIndex = 1;
                        }
                        // △
                        if ((0 < chk_Val1) && (chk_Val1 < 10))
                        {
                            resultHyokaIndex = 2;
                        }
                        // ×
                        if ((0 >= chk_Val1) || (chk_Val1 > 60))
                        {
                            resultHyokaIndex = 3;
                        }
                    }
                }
                // 溶存酸素量
                if (kensaKbn == SuishitsuKensaKbn.YozonSansoRyo)
                {
                    if (value.Trim() != "")
                    {
                        double chk_Val2 = double.Parse(value);
                        // ○
                        if (0.3 <= chk_Val2)
                        {
                            resultHyokaIndex = 1;
                        }
                        // △
                        if ((0 < chk_Val2) && (chk_Val2 < 0.3))
                        {
                            resultHyokaIndex = 2;
                        }
                        // ×
                        if (0 >= chk_Val2)
                        {
                            resultHyokaIndex = 3;
                        }
                    }
                }
                // 塩化物イオン
                if (kensaKbn == SuishitsuKensaKbn.EnkabutsuIon)
                {
                    if (value.Trim() != "")
                    {
                        decimal chk_Val4 = decimal.Parse(value);
                        // ○
                        if ((90 <= chk_Val4) && (chk_Val4 <= 140))
                        {
                            resultHyokaIndex = 1;
                        }
                        // △
                        if ((30 <= chk_Val4) && (chk_Val4 < 90))
                        {
                            resultHyokaIndex = 2;
                        }
                        if ((140 < chk_Val4) && (chk_Val4 <= 270))
                        {
                            resultHyokaIndex = 2;
                        }
                        // ×
                        if ((chk_Val4 < 30) || (270 < chk_Val4))
                        {
                            resultHyokaIndex = 3;
                        }
                    }
                }
                // 透視度
                if (kensaKbn == SuishitsuKensaKbn.Toshido)
                {
                    if (value.Trim() != "")
                    {
                        decimal chk_Val6 = decimal.Parse(value);
                        // ○
                        if (7 <= chk_Val6)
                        {
                            resultHyokaIndex = 1;
                        }
                        // △
                        if ((4 <= chk_Val6) && (chk_Val6 < 7))
                        {
                            resultHyokaIndex = 2;
                        }
                        // ×
                        if (chk_Val6 < 4)
                        {
                            resultHyokaIndex = 3;
                        }
                    }
                }
                // BOD
                if (kensaKbn == SuishitsuKensaKbn.BOD)
                {
                    if (value.Trim() != "")
                    {
                        decimal chk_Val7 = decimal.Parse(value);
                        // ○
                        if (90 >= chk_Val7)
                        {
                            resultHyokaIndex = 1;
                        }
                        // △
                        if ((90 < chk_Val7) && (chk_Val7 <= 120))
                        {
                            resultHyokaIndex = 2;
                        }
                        // ×
                        if (chk_Val7 > 120)
                        {
                            resultHyokaIndex = 3;
                        }
                    }
                }
            }
            else
            {
                // 2:合弁/3:小規模合併

                // 汚泥沈殿率
                if (kensaKbn == SuishitsuKensaKbn.OdeiChindenRitsu)
                {
                    if (value.Trim() != "")
                    {
                        decimal chk_Val1 = decimal.Parse(value);
                        // ○
                        if (10 <= chk_Val1)
                        {
                            resultHyokaIndex = 1;
                        }
                        // △
                        if ((0 < chk_Val1) && (chk_Val1 < 10))
                        {
                            resultHyokaIndex = 2;
                        }
                        // ×
                        if (0 >= chk_Val1)
                        {
                            resultHyokaIndex = 3;
                        }
                    }
                }
                // 溶存酸素量
                if (kensaKbn == SuishitsuKensaKbn.YozonSansoRyo)
                {
                    if (value.Trim() != "")
                    {
                        double chk_Val2 = double.Parse(value);
                        // ○
                        if (1.0 <= chk_Val2)
                        {
                            resultHyokaIndex = 1;
                        }
                        // △
                        if ((0 < chk_Val2) && (chk_Val2 < 1.0))
                        {
                            resultHyokaIndex = 2;
                        }
                        // ×
                        if (0 >= chk_Val2)
                        {
                            resultHyokaIndex = 3;
                        }
                    }
                }
                // 塩化物イオン
                if (kensaKbn == SuishitsuKensaKbn.EnkabutsuIon)
                {
                    if (value.Trim() != "")
                    {
                        resultHyokaIndex = 4;
                    }
                }
                // 透視度
                if (kensaKbn == SuishitsuKensaKbn.Toshido)
                {
                    if (value.Trim() != "")
                    {
                        decimal chk_Val6 = decimal.Parse(value);

                        if (decBod <= 60)
                        {
                            // ○
                            if (10 <= chk_Val6)
                            {
                                resultHyokaIndex = 1;
                            }
                            // △
                            if ((5 <= chk_Val6) && (chk_Val6 < 10))
                            {
                                resultHyokaIndex = 2;
                            }
                            // ×
                            if (chk_Val6 < 5)
                            {
                                resultHyokaIndex = 3;
                            }
                        }
                        if (decBod <= 30)
                        {
                            // ○
                            if (15 <= chk_Val6)
                            {
                                resultHyokaIndex = 1;
                            }
                            // △
                            if ((12 <= chk_Val6) && (chk_Val6 < 15))
                            {
                                resultHyokaIndex = 2;
                            }
                            // ×
                            if (chk_Val6 < 12)
                            {
                                resultHyokaIndex = 3;
                            }
                        }
                        if (decBod <= 20)
                        {
                            // ○
                            if (20 <= chk_Val6)
                            {
                                resultHyokaIndex = 1;
                            }
                            // △
                            if ((15 <= chk_Val6) && (chk_Val6 < 20))
                            {
                                resultHyokaIndex = 2;
                            }
                            // ×
                            if (chk_Val6 < 15)
                            {
                                resultHyokaIndex = 3;
                            }
                        }
                    }
                }
                // BOD
                if (kensaKbn == SuishitsuKensaKbn.BOD)
                {
                    if (value.Trim() != "")
                    {
                        decimal chk_Val7 = decimal.Parse(value);

                        if (decBod <= 60)
                        {
                            // ○
                            if (60 >= chk_Val7)
                            {
                                resultHyokaIndex = 1;
                            }
                            // △
                            if ((60 < chk_Val7) && (chk_Val7 <= 80))
                            {
                                resultHyokaIndex = 2;
                            }
                            // ×
                            if (chk_Val7 > 80)
                            {
                                resultHyokaIndex = 3;
                            }
                        }
                        if (decBod <= 30)
                        {
                            // ○
                            if (30 >= chk_Val7)
                            {
                                resultHyokaIndex = 1;
                            }
                            // △
                            if ((30 < chk_Val7) && (chk_Val7 <= 40))
                            {
                                resultHyokaIndex = 2;
                            }
                            // ×
                            if (chk_Val7 > 40)
                            {
                                resultHyokaIndex = 3;
                            }
                        }
                        if (decBod <= 20)
                        {
                            // ○
                            if (20 >= chk_Val7)
                            {
                                resultHyokaIndex = 1;
                            }
                            // △
                            if ((20 < chk_Val7) && (chk_Val7 <= 30))
                            {
                                resultHyokaIndex = 2;
                            }
                            // ×
                            if (chk_Val7 > 30)
                            {
                                resultHyokaIndex = 3;
                            }
                        }
                    }
                }
            }
#if DEBUG
            Debug.WriteLine("処理モード:" + syoriModel + " BOD性能:" + bodSpec + "検査区分:" + kensaKbn + " 検査対象値:" + value + "→検査結果:[" + resultHyokaIndex + "]");
#endif
            return resultHyokaIndex;
        }
        #endregion

        #endregion
    }
}
