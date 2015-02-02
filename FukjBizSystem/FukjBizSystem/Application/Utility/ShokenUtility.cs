using System;
using System.Diagnostics;
using System.Net;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.SaiSaisuiTbl;
using FukjBizSystem.Application.DataAccess.ShokenKekkaHosokuTbl;
using FukjBizSystem.Application.DataAccess.ShokenKekkaTbl;
using FukjBizSystem.Application.DataAccess.ShokenMst;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.Utility
{
    public class ShokenUtility
    {
        /// <summary>
        /// 選択モード
        /// </summary>
        public enum SelectMode
        {
            /// <summary>
            /// 所見
            /// </summary>
            Shoken,

            /// <summary>
            /// 補足文
            /// </summary>
            Hosokubun,
        }

        /// <summary>
        /// 所見タイプ
        /// </summary>
        public enum SelectType
        {
            /// <summary>
            /// 書類検査
            /// </summary>
            ShoruiKensa,

            /// <summary>
            /// 水質検査
            /// </summary>
            SuishitsuKensa,

            /// <summary>
            /// 外観検査
            /// </summary>
            GaikanKensa,
        }

        #region public メソッド

        #region GetBitMask(SelectMode mode, SelectType type)
        /// <summary>
        /// 対象検査のビットマスクを取得する
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetBitMask(SelectMode mode, SelectType type)
        {
            int bitmask = 0;

            switch (mode)
            {
                // 所見
                case SelectMode.Shoken:

                    switch (type)
                    {
                        case SelectType.ShoruiKensa:

                            bitmask = Convert.ToInt32("00000001", 2);
                            break;

                        case SelectType.SuishitsuKensa:

                            bitmask = Convert.ToInt32("00000010", 2);
                            break;

                        case SelectType.GaikanKensa:

                            bitmask = Convert.ToInt32("00000100", 2);
                            break;
                    }

                    break;

                // 補足文
                case SelectMode.Hosokubun:

                    switch (type)
                    {
                        case SelectType.ShoruiKensa:

                            bitmask = Convert.ToInt32("00010000", 2);
                            break;

                        case SelectType.SuishitsuKensa:

                            bitmask = Convert.ToInt32("00100000", 2);
                            break;

                        case SelectType.GaikanKensa:

                            bitmask = Convert.ToInt32("01000000", 2);
                            break;
                    }

                    break;
            }

            return bitmask;
        }
        #endregion


        #region ShokenAutoAdd メソッド①
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShokenAutoAdd
        /// <summary>
        /// 【メソッド①】
        /// 所見自動挿入(パラメータ：検査番号)
        /// ※検査番号を元にデータを取得して、メソッド②へ渡す
        /// ※仕様は、「基本設計書_000_042_関数_所見自動挿入」を参照のこと
        /// </summary>
        /// <param name="kensaIraiHoteiKbn">検査依頼法定区分</param>
        /// <param name="kensaIraiHokenjoCd">検査依頼保健所CD</param>
        /// <param name="kensaIraiNendo">検査依頼年度</param>
        /// <param name="kensaIraiRenban">検査依頼連番</param>
        /// <returns>エラーフラグ（0:正常/以外:異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string ShokenAutoAdd(
            string kensaIraiHoteiKbn,
            string kensaIraiHokenjoCd,
            string kensaIraiNendo,
            string kensaIraiRenban
            )
        {
            #region １．パラメータチェック
            if (string.IsNullOrEmpty(kensaIraiHoteiKbn) || string.IsNullOrEmpty(kensaIraiHoteiKbn.Trim()) ||
                string.IsNullOrEmpty(kensaIraiHokenjoCd) || string.IsNullOrEmpty(kensaIraiHokenjoCd.Trim()) ||
                string.IsNullOrEmpty(kensaIraiNendo) || string.IsNullOrEmpty(kensaIraiNendo.Trim()) ||
                string.IsNullOrEmpty(kensaIraiRenban) || string.IsNullOrEmpty(kensaIraiRenban.Trim()))
            {
                // １）パラメータのいずれかが空白だった場合
                // 判定結果=0を返却し、終了
                return "0";
            }
            #endregion

            #region ２．各データ検索
            // １） 検査依頼取得	
            // パラメータを検索キー条件として、検査依頼テーブルを取得 → 検査依頼データセット
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT = null;
            {
                ISelectKensaIraiTblByKeyDAInput selIn = new SelectKensaIraiTblByKeyDAInput();
                selIn.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
                selIn.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
                selIn.KensaIraiNendo = kensaIraiNendo;
                selIn.KensaIraiRenban = kensaIraiRenban;
                kensaIraiDT = new SelectKensaIraiTblByKeyDataAccess().Execute(selIn).KensaIraiTblDataTable;
                if (kensaIraiDT.Rows.Count <= 0)
                {
                    // 検査依頼データセットの取得件数=0だった場合
                    // 判定結果=0を返却し、終了
                    return "0";
                }
            }

            // ２）検査結果取得	
            // パラメータを検索キー条件として、検査結果テーブルを取得 → 検査結果データセット
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT = null;
            {
                ISelectKensaKekkaTblByKeyDAInput selIn = new SelectKensaKekkaTblByKeyDAInput();
                selIn.KensaKekkaIraiHoteiKbn = kensaIraiHoteiKbn;
                selIn.KensaKekkaIraiHokenjoCd = kensaIraiHokenjoCd;
                selIn.KensaKekkaIraiNendo = kensaIraiNendo;
                selIn.KensaKekkaIraiRenban = kensaIraiRenban;
                kensaKekkaDT = new SelectKensaKekkaTblByKeyDataAccess().Execute(selIn).KensaKekkaTblDataTable;
            }

            // ３）所見結果取得	
            // パラメータを検索キー条件として、検査結果テーブルを取得 → 所見結果データセット
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaDT = null;
            {
                ISelectShokenKekkaListWithBitmaskDAInput selIn = new SelectShokenKekkaListWithBitmaskDAInput();
                selIn.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
                selIn.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
                selIn.KensaIraiNendo = kensaIraiNendo;
                selIn.KensaIraiRenban = kensaIraiRenban;
                shokenKekkaDT = new SelectShokenKekkaListWithBitmaskDataAccess().Execute(selIn).ShokenKekkaListDT;
            }

            // ４）再採水取得	
            // パラメータを検索キー条件として、再採水テーブルを取得 → 再採水データセット
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisaisuiDT = null;
            {
                ISelectSaiSaisuiTblByKeyDAInput selIn = new SelectSaiSaisuiTblByKeyDAInput();
                selIn.SaiSaisuiIraiHoteiKbn = kensaIraiHoteiKbn;
                selIn.SaiSaisuiIraiHokenjoCd = kensaIraiHokenjoCd;
                selIn.SaiSaisuiIraiNendo = kensaIraiNendo;
                selIn.SaiSaisuiIraiRrenban = kensaIraiRenban;
                saisaisuiDT = new SelectSaiSaisuiTblByKeyDataAccess().Execute(selIn).SaiSaisuiTblDataTable;
            }
            #endregion

            #region ３．所見自動挿入
            // 所見自動挿入（【メソッド②】を実行）
            return ShokenAutoAdd(kensaIraiDT, kensaKekkaDT, shokenKekkaDT, saisaisuiDT);
            #endregion
        }
        #endregion

        #region ShokenAutoAdd メソッド②
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShokenAutoAdd
        /// <summary>
        /// 【メソッド②】
        /// 所見自動挿入(パラメータ：データセット)
        /// ※仕様は、「基本設計書_000_042_関数_所見自動挿入」を参照のこと
        /// </summary>
        /// <param name="kensaIraiDT">検査依頼データセット</param>
        /// <param name="kensaKekkaDT">検査結果データセット</param>
        /// <param name="shokenKekkaDT">所見結果データセット</param>
        /// <param name="saisaisuiDT">再採水データセット</param>
        /// <returns>エラーフラグ（0:正常/以外:異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23  小松        新規作成
        /// 2015/01/26　小松　　　　単位装置選択処理追加
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string ShokenAutoAdd(
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT,
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT,
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaDT,
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisaisuiDT
            )
        {
            // システム日付
            DateTime nowDt = Boundary.Common.Common.GetCurrentTimestamp();
            // ログインユーザー名
            string userNm = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // クライアント端末名
            string hostNm = Dns.GetHostName();

            #region １．パラメータチェック
            // １）パラメータ必須チェック
            if (kensaIraiDT == null || kensaKekkaDT == null || shokenKekkaDT == null || saisaisuiDT == null)
            {
                return "1";
            }
            // ２）検査依頼存在チェック
            if (kensaIraiDT.Rows.Count <= 0 || kensaKekkaDT.Rows.Count <= 0)
            {
                return "2";
            }
            // ３）ステータスチェック
            if (!checkKensaIraiStatus(kensaIraiDT))
            {
                // 【E：ステータスチェック】を呼び出し、エラーだった場合は、エラーを返却して終了
                return "3";
            }
            #endregion

            #region ３．所見件数取得
            // 【B：所見結果件数取得】を呼び出す
            int shokenKekkaCount = 0;
            int shokenRenbanMax = 0;
            getShokenKekkaInfo(shokenKekkaDT, out shokenKekkaCount, out shokenRenbanMax);
            #endregion

            #region ４．検査適正判定取得
            // 共通関数の【Ａ：検査適正判定】を呼び出す
            string kensaHantei = KensaHanteiUtility.KensaTekiseiHantei(kensaIraiDT, kensaKekkaDT, shokenKekkaDT);
            if (kensaHantei == "0")
            {
                // ・戻り値 = 0の場合エラーを返却して、終了	
                // エラーフラグ＝４
                return "4";
            }
            #endregion

            #region ５．パターン判定
            // 【X：パターン判定処理】 を呼び出し、処理パターンを取得 → 変数．処理パターン
            int patternHantei = getPatternHantei(kensaIraiDT, kensaKekkaDT, shokenKekkaDT, saisaisuiDT, kensaHantei, shokenKekkaCount);
            #endregion

            #region ６．所見追加処理
            // １） 初期処理	
            // 追加行数
            int addRowCount = 0;
            // 行カウント = 1
            int shokenHyojiichi = 1;
	        // 所見連番 = 変数．所見連番MAX
            int shokenRenban = shokenRenbanMax;
	        // データセット．所見結果(更新) を初期化
            ShokenKekkaTblDataSet.ShokenKekkaTblDataTable updShokenKekkaDT = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();
            // データセット．所見結果補足(更新) を初期化
            ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable updShokenKekkaHosokuDT = new ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable();

            // ２）パターン別に所見の先頭を追加
            if (patternHantei == 1)
            {
                //・パターン①
                // 所見区分：000、所見コード：037、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "037", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：000、所見コード：010、 所見連番：所見連番++(0埋め)、表示位置：2
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "010", 2, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：094、所見コード：034、 所見連番：所見連番++(0埋め)、表示位置：3
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "094", "034", 3, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 2)
            {
                // ・パターン②
                // 所見区分：000、所見コード：037、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "037", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 3)
            {
                // ・パターン③
                // 所見区分：000、所見コード：038、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "038", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：000、所見コード：010、 所見連番：所見連番++(0埋め)、表示位置：2
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "010", 2, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：000、所見コード：009、 所見連番：所見連番++(0埋め)、表示位置：3
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "009", 3, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：096、所見コード：091、 所見連番：所見連番++(0埋め)、表示位置：4
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "096", "091", 4, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 4 || patternHantei == 5)
            {
                // ・パターン④、パターン⑤
                // 所見区分：000、所見コード：038、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "038", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：096、所見コード：093、 所見連番：所見連番++(0埋め)、表示位置：2
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "096", "093", 2, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 6 || patternHantei == 7)
            {
                // ・パターン⑥、パターン⑦
                // 所見区分：000、所見コード：038、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "038", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 8)
            {
                // ・パターン⑧
                // 所見区分：000、所見コード：039、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "039", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：000、所見コード：010、 所見連番：所見連番++(0埋め)、表示位置：2
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "010", 2, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：000、所見コード：095、 所見連番：所見連番++(0埋め)、表示位置：3
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "095", 3, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 9)
            {
                // ・パターン⑨
                // 所見区分：000、所見コード：039、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "039", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：096、所見コード：093、 所見連番：所見連番++(0埋め)、表示位置：2
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "096", "093", 2, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 10)
            {
                // ・パターン⑩
                // 所見区分：000、所見コード：039、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "039", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 11)
            {
                // ・パターン⑪
                // 所見区分：096、所見コード：094、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "096", "094", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            else if (patternHantei == 12)
            {
                // ・パターン⑫
                // 所見区分：000、所見コード：090、 所見連番：所見連番++(0埋め)、表示位置：1
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "090", 1, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                // 所見区分：000、所見コード：091、 所見連番：所見連番++(0埋め)、表示位置：2
                addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "091", 2, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }

            // ３） 行カウントに２）で追加した行数を加算
            // addShokenKekkaRowで加算済
            shokenHyojiichi = shokenHyojiichi + addRowCount;

            // 外観タイトル挿入フラグ
            bool gaikanInitFlag = false;
            // 書類タイトル挿入フラグ
            bool shoruiInitFlag = false;
            // 水質タイトル挿入フラグ
            bool suishitsuInitFlag = false;
            // ４）データセット．所見結果をループしながら、データセット．所見結果(更新)に詰め直す。
            // ※所見結果、所見結果補足は、表示位置の昇順で取得していること
            foreach (ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskRow shokenKekkaRow in shokenKekkaDT.Select(string.Empty, "ShokenHyojiichi asc"))
            {
                if (shokenKekkaRow.ShokenHosokuKbn == "0")
                {
                    // 所見結果レコードの場合（ShokenHosokuKbn = 0）

                    // a) データセット．所見結果．対象検査ビットマスク = 4 or 64 (外観検査)だった場合(初回の1回のみ)
                    if (!gaikanInitFlag && (shokenKekkaRow.ShokenTaishoKensaBitMask == 4 || shokenKekkaRow.ShokenTaishoKensaBitMask == 64))
                    {
                        // 所見区分：000、所見コード：005、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                        shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "005", shokenKekkaRow.ShokenHyojiichi + addRowCount, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                        // 初回の１回のみ
                        gaikanInitFlag = true;
                    }

                    // b) データセット．所見結果．対象検査ビットマスク = 1 or 16 (書類検査)だった場合(初回の1回のみ)
                    if (!shoruiInitFlag && (shokenKekkaRow.ShokenTaishoKensaBitMask == 1 || shokenKekkaRow.ShokenTaishoKensaBitMask == 16))
                    {
                        // 所見区分：000、所見コード：007、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                        shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "007", shokenKekkaRow.ShokenHyojiichi + addRowCount, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                        // 初回の１回のみ
                        shoruiInitFlag = true;
                    }

                    // c) データセット．所見結果．対象検査ビットマスク = 2 or 32 (水質検査)だった場合(初回の1回のみ)
                    if (!suishitsuInitFlag && (shokenKekkaRow.ShokenTaishoKensaBitMask == 2 || shokenKekkaRow.ShokenTaishoKensaBitMask == 32))
                    {
                        // 所見区分：000、所見コード：006、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                        shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "006", shokenKekkaRow.ShokenHyojiichi + addRowCount, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                        // 初回の１回のみ
                        suishitsuInitFlag = true;
                    }

                    // d) データセット．所見結果 → データセット所見結果(更新)に追加する		
                    //  ・表示位置を現在の行カウントを加算しながら置き換える。	
                    //  ・表示位置以外の情報は、元のデータを追加(更新情報は書き換える)	
                    shokenHyojiichi = copyShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, shokenKekkaRow, ref shokenRenban, nowDt, userNm, hostNm, addRowCount);
                }
                else
                {
                    // 所見結果補足レコードの場合（ShokenHosokuKbn = 1）

                    // a) データセット．所見結果 → データセット所見結果補足(更新)に追加する
                    //  ・表示位置を現在の行カウントを加算しながら置き換える。
                    //  ・表示位置以外の情報は、元のデータを追加(更新情報は書き換える)
                    shokenHyojiichi = copyShokenKekkaHosokuRow(updShokenKekkaHosokuDT, kensaIraiDT, shokenKekkaRow, ref shokenRenban, nowDt, userNm, hostNm, addRowCount);
                }
            }

            // ５）水質所見を追加（パターン⑤、⑦、⑫の場合のみ）
            if (patternHantei == 5 || patternHantei == 7 || patternHantei == 12)
            {
                // a）  ４）－ｃ）で水質タイトルを挿入していない場合
                if (!suishitsuInitFlag)
                {
                    // 所見区分：000、所見コード：006、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                    shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "000", "006", shokenHyojiichi, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
                }
                // b) 【D：水質所見挿入】を呼び出す
                insertSuishitsuShokenKekka(updShokenKekkaDT, kensaIraiDT, kensaKekkaDT, ref shokenHyojiichi, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }

            // ６）作成したデータセット．所見結果(更新)を元に
            // 所見結果テーブル(DELETE/INSERT)
            {
                // 一旦削除
                IDeleteShokenKekkaTblByKensaIraiNoDAInput delIn = new DeleteShokenKekkaTblByKensaIraiNoDAInput();
                delIn.KensaIraiHoteiKbn = kensaIraiDT[0].KensaIraiHoteiKbn;
                delIn.KensaIraiHokenjoCd = kensaIraiDT[0].KensaIraiHokenjoCd;
                delIn.KensaIraiNendo = kensaIraiDT[0].KensaIraiNendo;
                delIn.KensaIraiRenban = kensaIraiDT[0].KensaIraiRenban;
                (new DeleteShokenKekkaTblByKensaIraiNoDataAccess()).Execute(delIn);

                if (updShokenKekkaDT.Rows.Count > 0)
                {
                    // 登録
                    IUpdateShokenKekkaTblDAInput updIn = new UpdateShokenKekkaTblDAInput();
                    updIn.ShokenKekkaDT = updShokenKekkaDT;
                    (new UpdateShokenKekkaTblDataAccess()).Execute(updIn);
                }
            }

            // 所見結果補足テーブル(DELETE/INSERT)
            {
                // 一旦削除
                IDeleteShokenKekkaHosokuTblByKensaIraiNoDAInput delIn = new DeleteShokenKekkaHosokuTblByKensaIraiNoDAInput();
                delIn.KensaIraiHoteiKbn = kensaIraiDT[0].KensaIraiHoteiKbn;
                delIn.KensaIraiHokenjoCd = kensaIraiDT[0].KensaIraiHokenjoCd;
                delIn.KensaIraiNendo = kensaIraiDT[0].KensaIraiNendo;
                delIn.KensaIraiRenban = kensaIraiDT[0].KensaIraiRenban;
                (new DeleteShokenKekkaHosokuTblByKensaIraiNoDataAccess()).Execute(delIn);

                if (updShokenKekkaHosokuDT.Rows.Count > 0)
                {
                    // 登録
                    IUpdateShokenKekkaHosokuTblDAInput updIn = new UpdateShokenKekkaHosokuTblDAInput();
                    updIn.ShokenKekkaHosokuDT = updShokenKekkaHosokuDT;
                    (new UpdateShokenKekkaHosokuTblDataAccess()).Execute(updIn);
                }
            }
            #endregion

            #region ７．エラーフラグ＝０：正常終了を返す
            return "0";
            #endregion
        }
        #endregion

        #endregion


        #region private メソッド

        #region 【X：パターン判定処理】
        /// <param name="kensaIraiDT">検査依頼データセット</param>
        /// <param name="kensaKekkaDT">検査結果データセット</param>
        /// <param name="shokenKekkaDT">所見結果データセット</param>
        /// <param name="saisaisuiDT">再採水データセット</param>
        /// <param name="kensaHantei">検査判定（1:適正/2:おおむね適正/3:不適正）</param>
        /// <param name="shokenKekkaCount">所見結果件数</param>
        /// <returns>パターン結果</returns>
        private static int getPatternHantei(
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT,
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT,
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaDT,
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisaisuiDT,
            string kensaHantei,
            int shokenKekkaCount
            )
        {
            // １．検査依頼法定区分判定
            // データセット．検査依頼．検査依頼法定区分 <= 2 の場合（7条検査、11条外観検査）
            if (kensaIraiDT[0].KensaIraiHoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN ||
                kensaIraiDT[0].KensaIraiHoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN)
            {
                // 「⑬：外観検査」を返却
                return 13;
            }

            // ２．スクリーニング区分＝0：なしの場合
            if (string.IsNullOrEmpty(kensaIraiDT[0].KensaIraiScreeningKbn) ||
                kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_NONE)
            {
                // １） 変数．検査判定 ＝ １：適正の場合
                if (kensaHantei == "1")
                {
                    // 「⑪：水質検査適正」を返却
                    return 11;
                }
                // ２） 変数．検査判定 ＝ ２：おおむね適正の場合
                else if (kensaHantei == "2")
                {
                    // 「⑫：水質検査おおむね適正」を返却
                    return 12;
                }
            }

            // ３．スクリーニング区分＝１：スクリーニングの場合
            if (kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING)
            {
                // １）【C：水質結果判定】＜２：再採水＞を呼び出す
                int suishitsuHantei = checkSuishitsuKekkaHantei(kensaKekkaDT, saisaisuiDT, 2);

                // ２）変数．所見結果件数=0、かつ、１）の結果=0
                if (shokenKekkaCount == 0 && suishitsuHantei == 0)
                {
                    // 「①：スクリーニング外観検査問題無」を返却
                    return 1;
                }
                // ３）上記以外の場合											
                else
                {
                    // 「②：スクリーニング外観検査問題有」を返却
                    return 2;
                }
            }

            // ４．スクリーニング区分＝２：フォローの場合
            if (kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_FOLLOW)
            {
                // １）【C：水質結果判定】＜１：検査結果＞を呼び出す
                int suishitsuHantei = checkSuishitsuKekkaHantei(kensaKekkaDT, saisaisuiDT, 1);

                // ２）変数．検査判定＝１：適正
                if (kensaHantei == "1")
                {
                    // 「③：フォロー適正」を返却
                    return 3;
                }
                // ３）変数．検査判定＝２：おおむね適正、かつ、１）の結果＝0
                if (kensaHantei == "2" && suishitsuHantei == 0)
                {
                    // 「④：フォローおおむね適正水質OK」を返却
                    return 4;
                }
                // ４）変数．検査判定＝２：おおむね適正、かつ、１）の結果＝1
                if (kensaHantei == "2" && suishitsuHantei == 1)
                {
                    // 「⑤：フォローおおむね適正水質NG」を返却
                    return 5;
                }
                // ５）変数．検査判定＝３：不適正、かつ、１）の結果＝0
                if (kensaHantei == "3" && suishitsuHantei == 0)
                {
                    // 「⑥：フォロー不適正水質OK」を返却
                    return 6;
                }
                // ６）変数．検査判定＝３：不適正、かつ、１）の結果＝1
                if (kensaHantei == "3" && suishitsuHantei == 1)
                {
                    // 「⑦：フォロー不適正水質NG」を返却
                    return 7;
                }
            }

            // ５．スクリーニング区分＝３：スクリーニング＋フォローの場合
            if (kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING_FOLLOW)
            {
                // １）【C：水質結果判定】＜２：再採水＞を呼び出す
                int suishitsuHantei = checkSuishitsuKekkaHantei(kensaKekkaDT, saisaisuiDT, 2);

                // ２）変数．検査判定＝２：おおむね適正、かつ、変数．所見件数=0、かつ、１）の結果＝0
                if (kensaHantei == "2" && shokenKekkaCount == 0 && suishitsuHantei == 0)
                {
                    // 「⑧：フ＋スおおむね適正外観検査問題無」を返却
                    return 8;
                }
                // ３）変数．検査判定＝２：おおむね適正、かつ、（変数．所見件数 > 0、又は、１）の結果＝1）
                if (kensaHantei == "2" && (shokenKekkaCount > 0 || suishitsuHantei == 1))
                {
                    // 「⑨：フ＋スおおむね適正外観検査問題有」を返却
                    return 9;
                }
                // ４）変数．検査判定＝３：不適正
                if (kensaHantei == "3")
                {
                    // 「⑩：フ＋ス不適正」を返却
                    return 10;
                }
            }

            return 0;
        }
        #endregion

        #region 【B：所見結果件数取得】
        /// <param name="shokenKekkaDT">所見結果データセット</param>
        /// <param name="shokenKekkaCount">（出力）所見結果件数</param>
        /// <param name="shokenRenbanMax">（出力）所見連番MAX</param>
        private static void getShokenKekkaInfo(
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaDT,
            out int shokenKekkaCount,
            out int shokenRenbanMax
            )
        {
            // １．データセット．所見結果のレコード件数 → 変数．所見結果件数
            shokenKekkaCount = 0;
            if (shokenKekkaDT.Rows.Count > 0)
            {
                shokenKekkaCount = shokenKekkaDT.Rows.Count;
            }
            // ２．データセット．所見結果．所見連番のMAXの値 → 変数．所見連番MAX
            // Nullなら0をセット
            shokenRenbanMax = 0;
            object maxKensaIraiShokenRenbanValue = shokenKekkaDT.Compute("MAX(KensaIraiShokenRenban)", null);
            if (maxKensaIraiShokenRenbanValue != System.DBNull.Value && maxKensaIraiShokenRenbanValue != null)
            {
                int.TryParse((string)maxKensaIraiShokenRenbanValue, out shokenRenbanMax);
            }
        }
        #endregion

        #region 【C：水質結果判定】
        /// <param name="kensaKekkaDT">検査結果データセット</param>
        /// <param name="saisaisuiDT">再採水データセット</param>
        /// <param name="kekkaKbn">検査結果区分（1:検査結果、2:再採水）</param>
        /// <returns>判定結果（0:OK/1:NG）</returns>
        private static int checkSuishitsuKekkaHantei(
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT,
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisaisuiDT,
            int kekkaKbn
            )
        {
            //１．パラメータ＝１：検査結果の場合
            if (kekkaKbn == 1)
            {
                // １） データセット．検査結果の以下の項目をチェック
                //        水素イオン濃度ー判定      AND
                //        生物化学酸素要求量ー判定  AND
                //        透視度ー判定
                //        ・上記全てが1だった場合、0を返して終了
                if (kensaKekkaDT[0].KensaKekkaSuisoIonNodoHantei == "1" &&
                    kensaKekkaDT[0].KensaKekkaBODHantei == "1" &&
                    kensaKekkaDT[0].KensaKekkaToshidoHantei == "1")
                {
                    // OK
                    return 0;
                }

                //        水素イオン濃度ー判定      = 2  OR 水素イオン濃度ー判定      = 3  OR
                //        透視度ー判定              = 2  OR 透視度ー判定              = 3  OR 
                //        生物化学酸素要求量ー判定  = 2
                //        ・上記の1件でも該当した場合、1を返して終了
                if (kensaKekkaDT[0].KensaKekkaSuisoIonNodoHantei == "2" || kensaKekkaDT[0].KensaKekkaSuisoIonNodoHantei == "3" || 
                    kensaKekkaDT[0].KensaKekkaToshidoHantei == "2" || kensaKekkaDT[0].KensaKekkaToshidoHantei == "3" || 
                    kensaKekkaDT[0].KensaKekkaBODHantei == "2")
                {
                    // NG
                    return 1;
                }
            }
            // ２．パラメータ＝２：再採水の場合
            else if (kekkaKbn == 2)
            {
                // １） データセット．検査結果の以下の項目をチェック
                //        生物化学酸素要求量ー判定 AND
                //        透視度ー判定
                //        ・上記全てが1だった場合、0を返して終了
                //        ・上記以外なら、1を返して終了
                if (saisaisuiDT[0].SaiSaisuiBODHantei == "1" &&
                    saisaisuiDT[0].SaiSaisuiToshidoHantei == "1")
                {
                    // OK
                    return 0;
                }
                else
                {
                    // NG
                    return 1;
                }
            }
            // NG
            return 1;
        }
        #endregion

        #region 【D：水質所見挿入】
        /// ※水質の場合のみ呼び出される（パターン⑤、⑦、⑫の場合のみ）
        /// <param name="updShokenKekkaDT">所見結果（更新）データセット</param>
        /// <param name="kensaIraiDT">検査依頼データセット</param>
        /// <param name="kensaKekkaDT">検査結果データセット</param>
        /// <param name="shokenHyojiichi">表示位置</param>
        /// <param name="kensaIraiShokenRenban">所見連番</param>
        /// <param name="nowDt"></param>
        /// <param name="userNm"></param>
        /// <param name="hostNm"></param>
        /// <param name="addRowCount">追加行数</param>
        /// <returns>行数</returns>
        private static int insertSuishitsuShokenKekka(
            ShokenKekkaTblDataSet.ShokenKekkaTblDataTable updShokenKekkaDT,
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT,
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT,
            ref int shokenHyojiichi,
            ref int shokenRenban,
            DateTime nowDt,
            string userNm,
            string hostNm,
            ref int addRowCount
            )
        {
            // 追加行数
            int rowCount = 0;

            // １．データセット．所見結果(更新) に以下で当てはまるデータを全て追加
            // １） データセット．検査結果．水素イオン濃度 > 8.6 だった場合
            if (!kensaKekkaDT[0].IsKensaKekkaSuisoIonNodoNull() && kensaKekkaDT[0].KensaKekkaSuisoIonNodo > 8.6)
            {
                // 行追加
                rowCount++;
                // 所見区分：091、所見コード：005、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "091", "005", shokenHyojiichi, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            // ２） データセット．検査結果．水素イオン濃度 < 5.8 だった場合
            if (!kensaKekkaDT[0].IsKensaKekkaSuisoIonNodoNull() && kensaKekkaDT[0].KensaKekkaSuisoIonNodo < 5.8)
            {
                // 行追加
                rowCount++;
                // 所見区分：091、所見コード：006、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "091", "006", shokenHyojiichi, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            // ３） データセット．検査結果．透視度－判定 = 2 OR 3だった場合 ※
            if (kensaKekkaDT[0].KensaKekkaToshidoHantei == "2" || kensaKekkaDT[0].KensaKekkaToshidoHantei == "3")
            {
                // 行追加
                rowCount++;
                // 所見区分：091、所見コード：065、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "091", "065", shokenHyojiichi, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }
            // ４） データセット．検査結果．生物化学酸素要求量ー判定 = 2 OR 3だった場合　※
            if (kensaKekkaDT[0].KensaKekkaBODHantei == "2" || kensaKekkaDT[0].KensaKekkaBODHantei == "3")
            {
                // 行追加
                rowCount++;
                // 所見区分：091、所見コード：073、 所見連番：所見連番++(0埋め)、表示位置：表示位置++
                shokenHyojiichi = addShokenKekkaRow(updShokenKekkaDT, kensaIraiDT, "091", "073", shokenHyojiichi, ref shokenRenban, nowDt, userNm, hostNm, ref addRowCount);
            }

            //２．行カウントに追加した行数を加算して返却する。
            return rowCount;
        }
        #endregion

        #region 【E：ステータスチェック】
        /// <param name="kensaIraiDT">検査依頼データセット</param>
        /// <returns>チェック結果（true:処理対象/false:対象外）</returns>
        private static bool checkKensaIraiStatus(KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT)
        {
            if (kensaIraiDT[0].KensaIraiHoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN ||
                    kensaIraiDT[0].KensaIraiHoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN)
            {
                // １．データセット．検査依頼．検査依頼法定区分 <=2(7条検査、11条外観検査)、

                //    かつ、(データセット．検査依頼．ステータス区分 >= 65 又は データセット．検査依頼．ステータス区分 < 40)だった場合
                if (kensaIraiDT[0].KensaIraiStatusKbn.CompareTo(Constants.KensaIraiStatusConstant.STATUS_GAIKAN_KEKKA_ZUMI) >= 0 ||
                    kensaIraiDT[0].KensaIraiStatusKbn.CompareTo(Constants.KensaIraiStatusConstant.STATUS_KENSA_JISSHI_ZUMI) < 0)
                {
                    // ・エラーを返して終了
                    return false;
                }
            }
            else if (kensaIraiDT[0].KensaIraiHoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU)
            {
                // ２．データセット．検査依頼．検査依頼法定区分 =3 (11条水質検査)の場合

                //    １） データセット．検査依頼．スクリーニング区分 IN (１：スクリーニング、３：スクリーニング＋フォロー)の場合
                if (kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING ||
                    kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_SCREENING_FOLLOW)
                {
                    //  a） データセット．検査依頼．ステータス区分 <> 60 だった場合
                    if (kensaIraiDT[0].KensaIraiStatusKbn != Constants.KensaIraiStatusConstant.STATUS_SUISHITSU_KENIN_ZUMI)
                    {
                        // ・エラーを返して終了
                        return false;
                    }
                }

                //    ２） データセット．検査依頼．スクリーニング区分 = ２：フォローの場合
                if (kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_FOLLOW)
                {
                    //  a） データセット．検査依頼．ステータス区分 < 40 又は データセット．検査依頼．ステータス区分 >= 65
                    //      又は データセット．検査依頼．水質検印区分 <> 1 だった場合
                    if (kensaIraiDT[0].KensaIraiStatusKbn.CompareTo(Constants.KensaIraiStatusConstant.STATUS_KENSA_JISSHI_ZUMI) < 0 ||
                        kensaIraiDT[0].KensaIraiStatusKbn.CompareTo(Constants.KensaIraiStatusConstant.STATUS_GAIKAN_KEKKA_ZUMI) >= 0 ||
                        kensaIraiDT[0].KensaIraiSuishitsuKeninKbn != "1")
                    {
                        // ・エラーを返して終了
                        return false;
                    }
                }

                //    ３） データセット．検査依頼．スクリーニング区分 = ０：なしの場合
                if (string.IsNullOrEmpty(kensaIraiDT[0].KensaIraiScreeningKbn) ||
                    kensaIraiDT[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_NONE)
                {
                    //  a） データセット．検査依頼．ステータス区分 <> 50 だった場合
                    if (kensaIraiDT[0].KensaIraiStatusKbn != Constants.KensaIraiStatusConstant.STATUS_KENSA_SUISHITSU_KEKKA_UKETUKE_ZUMI)
                    {
                        // ・エラーを返して終了
                        return false;
                    }
                }
            }
            // ３．正常を返す
            return true;
        }
        #endregion

        #region addShokenKekkaRow
        /// <summary>
        /// 所見結果テーブルにレコード追加
        /// </summary>
        /// <param name="updShokenKekkaDT">所見結果（更新）データセット</param>
        /// <param name="kensaIraiDT">検査依頼データセット</param>
        /// <param name="shokenHyojiichi">表示位置</param>
        /// <param name="kensaIraiShokenRenban">所見連番</param>
        /// <param name="shokenKbn">所見区分</param>
        /// <param name="shokenCd">所見コード</param>
        /// <param name="nowDt"></param>
        /// <param name="userNm"></param>
        /// <param name="hostNm"></param>
        /// <param name="addRowCount">追加行数</param>
        /// <returns>次の表示位置</returns>
        private static int addShokenKekkaRow(
            ShokenKekkaTblDataSet.ShokenKekkaTblDataTable updShokenKekkaDT,
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT,
            string shokenKbn,
            string shokenCd,
            int shokenHyojiichi,
            ref int kensaIraiShokenRenban,
            DateTime nowDt,
            string userNm,
            string hostNm, 
            ref int addRowCount
            )
        {
            string shokenCheckHantei = string.Empty;
            string shokenShitekiKashoNo = string.Empty;
            {
                ISelectShokenMstByKeyDAInput selIn = new SelectShokenMstByKeyDAInput();
                selIn.ShokenKbn = shokenKbn;
                selIn.ShokenCd = shokenCd;
                ShokenMstDataSet.ShokenMstDataTable shokenMstDT = new SelectShokenMstByKeyDataAccess().Execute(selIn).ShokenMstDataTable;
                if (shokenMstDT.Rows.Count > 0)
                {
                    // 判断
                    shokenCheckHantei = shokenMstDT[0].ShokenHandan;
                    // 指摘箇所No
                    shokenShitekiKashoNo = shokenMstDT[0].ShokenShitekiNo;
                }
            }

            // 所見結果
            ShokenKekkaTblDataSet.ShokenKekkaTblRow newRow = updShokenKekkaDT.NewShokenKekkaTblRow();

            // 検査依頼法定区分
            newRow.KensaIraiShokanIraiHoteiKbn = kensaIraiDT[0].KensaIraiHoteiKbn;
            // 検査依頼保健所コード
            newRow.KensaIraiShokenIraiHokenjoCd = kensaIraiDT[0].KensaIraiHokenjoCd;
            // 検査依頼年度
            newRow.KensaIraiShokenIraiNendo = kensaIraiDT[0].KensaIraiNendo;
            // 検査依頼連番
            newRow.KensaIraiShokenIraiRenban = kensaIraiDT[0].KensaIraiRenban;
            // 所見連番
            kensaIraiShokenRenban++;
            newRow.KensaIraiShokenRenban = kensaIraiShokenRenban.ToString().PadLeft(2, '0');
            // 所見区分
            newRow.ShokenKbn = shokenKbn;
            // 所見コード
            newRow.ShokenCd = shokenCd;
            // 表示位置(1オリジン)
            newRow.ShokenHyojiichi = shokenHyojiichi;
            // 所見手書き
            newRow.ShokenTegaki = string.Empty;
            // チェック項目
            newRow.ShokenCheckKomoku = string.Empty;
            // チェック項目判定
            newRow.ShokenCheckHantei = shokenCheckHantei;
            // 指摘箇所No
            newRow.ShokenShitekiKashoNo = shokenShitekiKashoNo;
            // 設置者連絡有無
            newRow.ShokenSetchishaRenrakuFlg = "0";
            // 保守点検業者連絡有無
            newRow.ShokenHoshuGyoshaRenrakuFlg = "0";
            // 清掃業者連絡有無
            newRow.ShokenSeisoGyoshaRenrakuFlg = "0";
            // 工事業者連絡有無
            newRow.ShokenKojiGyoshaRenrakuFlg = "0";
            // メーカー連絡有無
            newRow.ShokenMakerRenrakuFlg = "0";
            // 保健所連絡有無
            newRow.ShokenHokenjoRenrakuFlg = "0";
            // 保守契約確認有無
            newRow.ShokenHoshuKeiyakuKakuninFlg = "0";
            // 点検回数確認有無
            newRow.ShokenTenkenKaisuuKakuninFlg = "0";
            // 清掃回数確認有無
            newRow.ShokenSeisouKaisuuKakuninFlg = "0";
            // 単位装置名
            newRow.TaniSochiNm = string.Empty;

            // 追加・更新情報
            newRow.InsertDt = nowDt;
            newRow.InsertUser = userNm;
            newRow.InsertTarm = hostNm;
            newRow.UpdateDt = nowDt;
            newRow.UpdateUser = userNm;
            newRow.UpdateTarm = hostNm;

            // 行を挿入
            updShokenKekkaDT.AddShokenKekkaTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();

            // 追加行数をカウントアップ
            addRowCount++;

            Debug.WriteLine(string.Format("表示位置：[{0}]  所見区分：[{1}]　所見CD：[{2}]  所見　追加", newRow.ShokenHyojiichi, newRow.ShokenKbn, newRow.ShokenCd));

            // 次の表示位置を返却
            return newRow.ShokenHyojiichi + 1;
        }
        #endregion

        #region copyShokenKekkaRow
        /// <summary>
        /// 所見結果テーブルにレコード追加
        /// </summary>
        /// <param name="updShokenKekkaDT">所見結果（更新）データセット</param>
        /// <param name="kensaIraiDT">検査依頼データセット</param>
        /// <param name="kensaIraiShokenRenban">所見連番</param>
        /// <param name="shokenKbn">所見区分</param>
        /// <param name="shokenCd">所見コード</param>
        /// <param name="nowDt"></param>
        /// <param name="userNm"></param>
        /// <param name="hostNm"></param>
        /// <param name="addRowCount">追加行数</param>
        /// <returns>次の表示位置</returns>
        private static int copyShokenKekkaRow(
            ShokenKekkaTblDataSet.ShokenKekkaTblDataTable updShokenKekkaDT,
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT,
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskRow srcShokenRow,
            ref int kensaIraiShokenRenban,
            DateTime nowDt,
            string userNm,
            string hostNm,
            int addRowCount
            )
        {
            // 所見結果
            ShokenKekkaTblDataSet.ShokenKekkaTblRow newRow = updShokenKekkaDT.NewShokenKekkaTblRow();

            // 検査依頼法定区分
            newRow.KensaIraiShokanIraiHoteiKbn = srcShokenRow.KensaIraiShokanIraiHoteiKbn;
            // 検査依頼保健所コード
            newRow.KensaIraiShokenIraiHokenjoCd = srcShokenRow.KensaIraiShokenIraiHokenjoCd;
            // 検査依頼年度
            newRow.KensaIraiShokenIraiNendo = srcShokenRow.KensaIraiShokenIraiNendo;
            // 検査依頼連番
            newRow.KensaIraiShokenIraiRenban = srcShokenRow.KensaIraiShokenIraiRenban;
            // 所見連番
            newRow.KensaIraiShokenRenban = srcShokenRow.KensaIraiShokenRenban;
            // 所見区分
            newRow.ShokenKbn = srcShokenRow.ShokenKbn;
            // 所見コード
            newRow.ShokenCd = srcShokenRow.ShokenCd;
            // 表示位置(1オリジン)
            // 追加した行数分ずらす
            newRow.ShokenHyojiichi = srcShokenRow.ShokenHyojiichi + addRowCount;
            // 所見手書き
            newRow.ShokenTegaki = srcShokenRow.ShokenTegaki;
            // チェック項目
            newRow.ShokenCheckKomoku = srcShokenRow.ShokenCheckKomoku;
            // チェック項目判定
            newRow.ShokenCheckHantei = srcShokenRow.ShokenCheckHantei;
            // 指摘箇所No
            newRow.ShokenShitekiKashoNo = srcShokenRow.ShokenShitekiKashoNo;
            // 設置者連絡有無
            newRow.ShokenSetchishaRenrakuFlg = srcShokenRow.ShokenSetchishaRenrakuFlg;
            // 保守点検業者連絡有無
            newRow.ShokenHoshuGyoshaRenrakuFlg = srcShokenRow.ShokenHoshuGyoshaRenrakuFlg;
            // 清掃業者連絡有無
            newRow.ShokenSeisoGyoshaRenrakuFlg = srcShokenRow.ShokenSeisoGyoshaRenrakuFlg;
            // 工事業者連絡有無
            newRow.ShokenKojiGyoshaRenrakuFlg = srcShokenRow.ShokenKojiGyoshaRenrakuFlg;
            // メーカー連絡有無
            newRow.ShokenMakerRenrakuFlg = srcShokenRow.ShokenMakerRenrakuFlg;
            // 保健所連絡有無
            newRow.ShokenHokenjoRenrakuFlg = srcShokenRow.ShokenHokenjoRenrakuFlg;
            // 保守契約確認有無
            newRow.ShokenHoshuKeiyakuKakuninFlg = srcShokenRow.ShokenHoshuKeiyakuKakuninFlg;
            // 点検回数確認有無
            newRow.ShokenTenkenKaisuuKakuninFlg = srcShokenRow.ShokenTenkenKaisuuKakuninFlg;
            // 清掃回数確認有無
            newRow.ShokenSeisouKaisuuKakuninFlg = srcShokenRow.ShokenSeisouKaisuuKakuninFlg;
            // 単位装置名
            newRow.TaniSochiNm = srcShokenRow.TaniSochiNm;

            // 追加・更新情報
            newRow.InsertDt = srcShokenRow.InsertDt;
            newRow.InsertUser = srcShokenRow.InsertUser;
            newRow.InsertTarm = srcShokenRow.InsertTarm;
            newRow.UpdateDt = nowDt;
            newRow.UpdateUser = userNm;
            newRow.UpdateTarm = hostNm;

            // 行を挿入
            updShokenKekkaDT.AddShokenKekkaTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();

            Debug.WriteLine(string.Format("表示位置：[{0}]  所見区分：[{1}]　所見CD：[{2}]  所見　コピー", newRow.ShokenHyojiichi, newRow.ShokenKbn, newRow.ShokenCd));

            // 次の表示位置を返却
            return newRow.ShokenHyojiichi + 1;
        }
        #endregion

        #region copyShokenKekkaHosokuRow
        /// <summary>
        /// 所見結果補足テーブルにレコード追加
        /// </summary>
        /// <param name="updShokenKekkaDT">所見結果（更新）データセット</param>
        /// <param name="kensaIraiDT">検査依頼データセット</param>
        /// <param name="kensaIraiShokenRenban">所見連番</param>
        /// <param name="shokenKbn">所見区分</param>
        /// <param name="shokenCd">所見コード</param>
        /// <param name="nowDt"></param>
        /// <param name="userNm"></param>
        /// <param name="hostNm"></param>
        /// <param name="addRowCount">追加行数</param>
        /// <returns>次の表示位置</returns>
        private static int copyShokenKekkaHosokuRow(
            ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable updShokenKekkaHosokuDT,
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT,
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskRow srcShokenRow,
            ref int kensaIraiShokenRenban,
            DateTime nowDt,
            string userNm,
            string hostNm,
            int addRowCount
            )
        {
            // 所見結果補足
            ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow newRow = updShokenKekkaHosokuDT.NewShokenKekkaHosokuTblRow();

            // 検査依頼法定区分
            newRow.KensaIraiShokanIraiHoteiKbn = srcShokenRow.KensaIraiShokanIraiHoteiKbn;
            // 検査依頼保健所コード
            newRow.KensaIraiShokenIraiHokenjoCd = srcShokenRow.KensaIraiShokenIraiHokenjoCd;
            // 検査依頼年度
            newRow.KensaIraiShokenIraiNendo = srcShokenRow.KensaIraiShokenIraiNendo;
            // 検査依頼連番
            newRow.KensaIraiShokenIraiRenban = srcShokenRow.KensaIraiShokenIraiRenban;
            // 所見連番
            newRow.KensaIraiShokenRenban = srcShokenRow.KensaIraiShokenRenban;
            // 所見補足文連番
            newRow.KensaIraiShokenHosokuRenban = srcShokenRow.KensaIraiShokenHosokuRenban;
            // 所見区分
            newRow.ShokenKbn = srcShokenRow.ShokenKbn;
            // 所見コード
            newRow.ShokenCd = srcShokenRow.ShokenCd;
            // 表示位置(1オリジン)
            // 追加した行数分ずらす
            newRow.ShokenHyojiichi = srcShokenRow.ShokenHyojiichi + addRowCount;
            // 所見手書き
            newRow.ShokenTegaki = srcShokenRow.ShokenTegaki;
            // チェック項目
            newRow.ShokenCheckKomoku = srcShokenRow.ShokenCheckKomoku;
            // チェック項目判定
            newRow.ShokenCheckHantei = srcShokenRow.ShokenCheckHantei;
            // 指摘箇所No
            newRow.ShokenShitekiKashoNo = srcShokenRow.ShokenShitekiKashoNo;
            // 設置者連絡有無
            newRow.ShokenSetchishaRenrakuFlg = srcShokenRow.ShokenSetchishaRenrakuFlg;
            // 保守点検業者連絡有無
            newRow.ShokenHoshuGyoshaRenrakuFlg = srcShokenRow.ShokenHoshuGyoshaRenrakuFlg;
            // 清掃業者連絡有無
            newRow.ShokenSeisoGyoshaRenrakuFlg = srcShokenRow.ShokenSeisoGyoshaRenrakuFlg;
            // 工事業者連絡有無
            newRow.ShokenKojiGyoshaRenrakuFlg = srcShokenRow.ShokenKojiGyoshaRenrakuFlg;
            // メーカー連絡有無
            newRow.ShokenMakerRenrakuFlg = srcShokenRow.ShokenMakerRenrakuFlg;
            // 保健所連絡有無
            newRow.ShokenHokenjoRenrakuFlg = srcShokenRow.ShokenHokenjoRenrakuFlg;
            // 保守契約確認有無
            newRow.ShokenHoshuKeiyakuKakuninFlg = srcShokenRow.ShokenHoshuKeiyakuKakuninFlg;
            // 点検回数確認有無
            newRow.ShokenTenkenKaisuuKakuninFlg = srcShokenRow.ShokenTenkenKaisuuKakuninFlg;
            // 清掃回数確認有無
            newRow.ShokenSeisouKaisuuKakuninFlg = srcShokenRow.ShokenSeisouKaisuuKakuninFlg;

            // 追加・更新情報
            newRow.InsertDt = srcShokenRow.InsertDt;
            newRow.InsertUser = srcShokenRow.InsertUser;
            newRow.InsertTarm = srcShokenRow.InsertTarm;
            newRow.UpdateDt = nowDt;
            newRow.UpdateUser = userNm;
            newRow.UpdateTarm = hostNm;

            // 行を挿入
            updShokenKekkaHosokuDT.AddShokenKekkaHosokuTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();

            Debug.WriteLine(string.Format("表示位置：[{0}]  所見区分：[{1}]　所見CD：[{2}]  補足　コピー", newRow.ShokenHyojiichi, newRow.ShokenKbn, newRow.ShokenCd));
            // 次の表示位置を返却
            return newRow.ShokenHyojiichi + 1;
        }
        #endregion

        #endregion
    }
}
