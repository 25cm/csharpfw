using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeReport;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.HoteiKensaDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint11joKensaDaichoBLInput
    /// <summary>
    /// 法定11条水質異常一覧表出力
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/15  宗           新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrint11joKensaDaichoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// Search Condition
        /// </summary>
        HoteiKensaDaichoSearchCond SearchCond { get; set; }

        #region to be removed
        ///// <summary>
        ///// 年度
        ///// </summary>
        //string Nendo { get; set; }

        ///// <summary>
        ///// 条件追加区分
        ///// </summary>
        //string IraiDateKbn { get; set; }

        ///// <summary>
        ///// 依頼受付日（開始）
        ///// </summary>
        //string IraiDateFrom { get; set; }

        ///// <summary>
        ///// 依頼受付日（終了）
        ///// </summary>
        //string IraiDateTo { get; set; }

        ///// <summary>
        ///// 検査区分
        ///// </summary>
        //string KensaKbn { get; set; }

        ///// <summary>
        ///// 依頼番号（開始）
        ///// </summary>
        //string IraiNoFrom { get; set; }

        ///// <summary>
        ///// 依頼番号（終了）
        ///// </summary>
        //string IraiNoTo { get; set; }
        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print11joKensaDaichoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/15  宗           新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print11joKensaDaichoBLInput : BaseExcelPrintBLInputImpl, IPrint11joKensaDaichoBLInput
    {
        /// <summary>
        /// Search Condition
        /// </summary>
        public HoteiKensaDaichoSearchCond SearchCond { get; set; }

        #region to be removed
        ///// <summary>
        ///// 年度
        ///// </summary>
        //public string Nendo { get; set; }

        ///// <summary>
        ///// 条件追加区分
        ///// </summary>
        //public string IraiDateKbn { get; set; }

        ///// <summary>
        ///// 依頼受付日（開始）
        ///// </summary>
        //public string IraiDateFrom { get; set; }

        ///// <summary>
        ///// 依頼受付日（終了）
        ///// </summary>
        //public string IraiDateTo { get; set; }

        ///// <summary>
        ///// 検査区分
        ///// </summary>
        //public string KensaKbn { get; set; }

        ///// <summary>
        ///// 依頼番号（開始）
        ///// </summary>
        //public string IraiNoFrom { get; set; }

        ///// <summary>
        ///// 依頼番号（終了）
        ///// </summary>
        //public string IraiNoTo { get; set; }
        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint11joKensaDaichoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/15  宗           新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrint11joKensaDaichoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print11joKensaDaichoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/15  宗           新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print11joKensaDaichoBLOutput : IPrint11joKensaDaichoBLOutput
    {
        /// <summary>
        /// 保存パス
        /// </summary>
        public string SavePath
        {
            get;
            set;
        }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print11joKensaDaichoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/15  宗           新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print11joKensaDaichoBusinessLogic : BaseExcelPrintBusinessLogic<IPrint11joKensaDaichoBLInput, IPrint11joKensaDaichoBLOutput>
    {
        #region 定義

        public enum OperationErr
        {
            /// <summary>
            /// データなし
            /// </summary>
            NoDataFound,
        }

        /// <summary>
        /// 明細先頭行位置
        /// </summary>
        private static readonly int DETAIL_OFFSET = 11;

        /// <summary>
        /// 1ページ明細行数
        /// </summary>
        private static readonly int PAGE_ROW_CNT = 20;

        /// <summary>
        /// チェックの状態
        /// </summary>
        string CheckOn = "☑";
        string CheckOff = "☐";

        /// <summary>
        /// 背景色
        /// </summary>
        Color bcMinyuryoku = Color.Yellow;
        Color bcKakuninKensa = Color.LightBlue;

        #endregion 定義

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Print11joKensaDaichoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者       内容
        /// 2014/12/15  宗           新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Print11joKensaDaichoBusinessLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region SetBook
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： SetBook
        /// <summary>
        /// ＥＸＣＥＬのブックオブジェクトにデータを設定する
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">入力</param>
        /// <param name="book">ＥＸＣＥＬのブックオブジェクト</param>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者       内容
        /// 2014/12/12  豊田         新規作成
        /// 2015/01/22  宗           試験項目毎の桁数制限を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrint11joKensaDaichoBLOutput SetBook(IPrint11joKensaDaichoBLInput input, Workbook book)
        {
            IPrint11joKensaDaichoBLOutput output = new Print11joKensaDaichoBLOutput();

            // 試験項目リストを取得
            ConstMstDataSet.ConstMstDataTable ShikenKomokuList = Boundary.Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_048) as ConstMstDataSet.ConstMstDataTable;

            // 結果コードリストを取得
            ConstMstDataSet.ConstMstDataTable KekkaCdList = Boundary.Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_027) as ConstMstDataSet.ConstMstDataTable;

            #region 検査台帳情報の取得

            ISelectHoteiKensaDaichoSearchByCondDAInput daInput = new SelectHoteiKensaDaichoSearchByCondDAInput();
            daInput.SearchCond = input.SearchCond;
            ISelectHoteiKensaDaichoSearchByCondDAOutput daOutput = new SelectHoteiKensaDaichoSearchByCondDataAccess().Execute(daInput);

            if (daOutput.HoteiKensaDaichoDT.Count == 0)
            {
                throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
            }

            #region to be removed
            //ISelectPrint11joKensaDaichoByConditionDAInput daInput = new SelectPrint11joKensaDaichoByConditionDAInput();
            
            //daInput.ShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            //daInput.Nendo = input.Nendo;
            //daInput.IraiDateKbn = input.IraiDateKbn;
            //daInput.IraiDateFrom = input.IraiDateFrom;
            //daInput.IraiDateTo = input.IraiDateTo;
            //daInput.KensaKbn = input.KensaKbn;
            //daInput.IraiNoFrom = input.IraiNoFrom;
            //daInput.IraiNoTo = input.IraiNoTo;
            //daInput.kmkCdPh = GetConstValue(ShikenKomokuList, "001");
            //daInput.kmkCdTr = GetConstValue(ShikenKomokuList, "002");
            //daInput.kmkCdBod = GetConstValue(ShikenKomokuList, "003");
            //daInput.kmkCdZanen = GetConstValue(ShikenKomokuList, "004");
            //daInput.kmkCdCl = GetConstValue(ShikenKomokuList, "005");

            //ISelectPrint11joKensaDaichoByConditionDAOutput daOutput = new SelectPrint11joKensaDaichoByConditionDataAccess().Execute(daInput);

            //if (daOutput.Print11joKensaDaicho.Count == 0)
            //{
            //    throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
            //}
            #endregion
            #endregion

            Worksheet sheet = null;

            try
            {
                string nendo = string.Empty;
                string kekkaVal = string.Empty;
                string kekkaCd = string.Empty;

                int currentRowIndex = 0;

                // 出力日
                DateTime curretDate = Boundary.Common.Common.GetCurrentTimestamp().Date;

                // 取得件数分繰り返す
                foreach (KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchRow pdr in daOutput.HoteiKensaDaichoDT)
                //foreach (SuishitsuKensaUketsukeReportDataSet.Print11joKensaDaichoRow pdr in daOutput.Print11joKensaDaicho)
                {
                    #region 年度が変わった
                    if (pdr.IraiNendo != nendo)
                    {
                        // 年度を保持
                        nendo = pdr.IraiNendo;
                        //nendo = pdr.IraiNendo;

                        // テンプレートベースをコピー
                        CopySheet(book, 0, book.Sheets.Count);

                        // 出力するシート
                        sheet = (Worksheet)book.Sheets[book.Sheets.Count];

                        // シート名をリネーム
                        sheet.Name = string.Format("{0}年度", Boundary.Common.Common.ConvertToHoshouNendoWareki(pdr.IraiNendo));

                        // 必要ページ数の算出（1ブロック=2行）
                        int pagecount = (daOutput.HoteiKensaDaichoDT.Count - 1) / 10;
                        //int pagecount = (daOutput.Print11joKensaDaicho.Count - 1) / 10;

                        // テンプレート明細部のコピー
                        CopyTemplate(sheet, pagecount);

                        #region ヘッダの出力

                        // 支所
                        CellOutput(sheet, 1, 0, Boundary.Common.Common.GetShishoNmByShishoCd(Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd));

                        // 年度
                        CellOutput(sheet, 1, 5, string.Format("≪平成{0}年度≫", Boundary.Common.Common.ConvertToHoshouNendoWareki(nendo)));

                        // 印刷日
                        CellOutput(sheet, 3, 19, curretDate);

                        // 指定範囲(From)
                        if (!string.IsNullOrEmpty(input.SearchCond.IraiNoFrom))
                        {
                            CellOutput(sheet, 3, 9, input.SearchCond.IraiNoFrom);
                        }

                        // 指定範囲(To)
                        if (!string.IsNullOrEmpty(input.SearchCond.IraiNoTo))
                        {
                            CellOutput(sheet, 3, 13, input.SearchCond.IraiNoTo);
                        }

                        if (input.SearchCond.IraiUketsukeDtInputKbn == "1")
                        {
                            // 受付日指定範囲(From)
                            if (!string.IsNullOrEmpty(input.SearchCond.IraiUketsukeFromDt))
                            {
                                CellOutput(sheet, 4, 9, ToDate(input.SearchCond.IraiUketsukeFromDt));
                            }

                            // 受付日指定範囲(To)
                            if (!string.IsNullOrEmpty(input.SearchCond.IraiUketsukeToDt))
                            {
                                CellOutput(sheet, 4, 13, ToDate(input.SearchCond.IraiUketsukeToDt));
                            }
                        }

                        // 件数
                        CellOutput(sheet, 6, 16, daOutput.HoteiKensaDaichoDT.Count);
                        //CellOutput(sheet, 6, 16, daOutput.Print11joKensaDaicho.Count);

                        #endregion

                        // 明細出力行位置を先頭に戻す
                        currentRowIndex = 0;
                    }
                    #endregion

                    // 行番号をインクリメント
                    currentRowIndex++;

                    #region 明細の出力

                    int dtlRowIndex = DETAIL_OFFSET + ((currentRowIndex - 1) * 2);
                    int dtlColIndex = 4;

                    // 依頼No
                    CellOutput(sheet, dtlRowIndex, 0, pdr.SuishitsuKensaIraiNo);

                    // 異常
                    CellOutput(sheet, dtlRowIndex, 1, GetAbnml(
                        (pdr.IsScreeningKohoNull() ? string.Empty : pdr.ScreeningKoho),
                        (pdr.IsFollowKohoNull() ? string.Empty : pdr.FollowKoho),
                        (pdr.IsCrossCheckSuishitsuNull() ? string.Empty : pdr.CrossCheckSuishitsu),
                        (pdr.IsCrossCheckKakoNull() ? string.Empty : pdr.CrossCheckKako)));

                    // 判定
                    if (!pdr.IsConstNmNull())
                    {
                        CellOutput(sheet, dtlRowIndex, 2, pdr.ConstNm);
                    }

                    // 処理方式
                    if (!pdr.IsShoriHoshikiShubetsuNmNull())
                    {
                        CellOutput(sheet, dtlRowIndex, 3, pdr.ShoriHoshikiShubetsuNm);
                    }

                    #region pH
                    {
                        // 初回検査(pH)
                        if (!pdr.IsPH1KekkaNyuryokuNull() && (pdr.PH1KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsPH1KekkaValueNull())
                            {
                                if (!pdr.IsPH1KekkaOndoNull())
                                {
                                    //kekkaVal = string.Format("{0}({1})", pdr.PH1KekkaValue, pdr.PH1KekkaOndo);
                                    kekkaVal = string.Format("{0}({1})", 
                                        KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdPh, pdr.PH1KekkaValue.ToString()), 
                                        KensaHanteiUtility.HyojiKetasuHosei("000", pdr.PH1KekkaOndo.ToString()));
                                }
                                else
                                {
                                    //kekkaVal = string.Format("{0}", pdr.PH1KekkaValue);
                                    kekkaVal = string.Format("{0}", 
                                        KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdPh, pdr.PH1KekkaValue.ToString()));
                                }
                            }
                            if (!pdr.IsPH1KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.PH1KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsPH1KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 1, pdr.PH1KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsPH1SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 2, pdr.PH1SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }
                        }

                        // 再検査(pH)
                        if ((!pdr.IsPH2KekkaNyuryokuNull()) && (pdr.PH2KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsPH2KekkaValueNull())
                            {
                                if (!pdr.IsPH2KekkaOndoNull())
                                {
                                    //kekkaVal = string.Format("{0}({1})", pdr.PH2KekkaValue, pdr.PH2KekkaOndo);
                                    kekkaVal = string.Format("{0}({1})", 
                                        KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdPh, pdr.PH2KekkaValue.ToString()), 
                                        KensaHanteiUtility.HyojiKetasuHosei("000", pdr.PH2KekkaOndo.ToString()));
                                }
                                else
                                {
                                    //kekkaVal = string.Format("{0}", pdr.PH2KekkaValue);
                                    kekkaVal = string.Format("{0}", 
                                        KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdPh, pdr.PH2KekkaValue.ToString()));
                                }
                            }
                            if (!pdr.IsPH2KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.PH2KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex + 1, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsPH2KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 1, pdr.PH2KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsPH2SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 2, pdr.PH2SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }
                        }

                        // 背景色設定(pH)
                        if ((!pdr.IsPH1KensaShubetsuNull() && (pdr.PH1KensaShubetsu != string.Empty))
                            || (!pdr.IsPH2KensaShubetsuNull() && (pdr.PH2KensaShubetsu != string.Empty)))
                        {
                            // 確認検査
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcKakuninKensa);
                        }
                        else if ((!pdr.IsPH1KekkaNyuryokuNull() && (pdr.PH1KekkaNyuryoku == "0"))
                            || (!pdr.IsPH1KekkaNyuryokuNull() && (pdr.PH1KekkaNyuryoku == "0")))
                        {
                            // 未入力
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcMinyuryoku);
                        }
                    }
                    #endregion

                    #region 透視度
                    {
                        dtlColIndex += 3;

                        // 初回検査(透視度)
                        if (!pdr.IsTR1KekkaNyuryokuNull() && (pdr.TR1KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsTR1KekkaValueNull())
                            {
                                //kekkaVal = string.Format("{0}", pdr.TR1KekkaValue);
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdTr, pdr.TR1KekkaValue.ToString()));
                            }
                            if (!pdr.IsTR1KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.TR1KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsTR1KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 1, pdr.TR1KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsTR1SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 2, pdr.TR1SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }
                        }

                        // 再検査(透視度)
                        if ((!pdr.IsTR2KekkaNyuryokuNull()) && (pdr.TR2KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsTR2KekkaValueNull())
                            {
                                //kekkaVal = string.Format("{0}", pdr.TR2KekkaValue);
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdTr, pdr.TR2KekkaValue.ToString()));
                            }
                            if (!pdr.IsTR2KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.TR2KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex + 1, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsTR2KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 1, pdr.TR2KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsTR2SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 2, pdr.TR2SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }
                        }

                        // 背景色設定(透視度)
                        if ((!pdr.IsTR1KensaShubetsuNull() && (pdr.TR1KensaShubetsu != string.Empty))
                            || (!pdr.IsTR2KensaShubetsuNull() && (pdr.TR2KensaShubetsu != string.Empty)))
                        {
                            // 確認検査
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcKakuninKensa);
                        }
                        else if ((!pdr.IsTR1KekkaNyuryokuNull() && (pdr.TR1KekkaNyuryoku == "0"))
                            || (!pdr.IsTR1KekkaNyuryokuNull() && (pdr.TR1KekkaNyuryoku == "0")))
                        {
                            // 未入力
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcMinyuryoku);
                        }
                    }
                    #endregion

                    #region BOD
                    {
                        dtlColIndex += 3;

                        // 初回検査(BOD)
                        if (!pdr.IsBOD1KekkaNyuryokuNull() && (pdr.BOD1KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsBOD1KekkaValueNull())
                            {
                                //kekkaVal = string.Format("{0}", pdr.BOD1KekkaValue);
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdBod, pdr.BOD1KekkaValue.ToString()));
                            }
                            if (!pdr.IsBOD1KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.BOD1KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsBOD1KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 1, pdr.BOD1KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsBOD1SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 2, pdr.BOD1SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }

                        }

                        // 再検査(BOD)
                        if ((!pdr.IsBOD2KekkaNyuryokuNull()) && (pdr.BOD2KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsBOD2KekkaValueNull())
                            {
                                //kekkaVal = string.Format("{0}", pdr.BOD2KekkaValue);
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdBod, pdr.BOD2KekkaValue.ToString()));
                            }
                            if (!pdr.IsBOD2KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.BOD2KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex + 1, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsBOD2KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 1, pdr.BOD2KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsBOD2SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 2, pdr.BOD2SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }
                        }

                        // 背景色設定(BOD)
                        if ((!pdr.IsBOD1KensaShubetsuNull() && (pdr.BOD1KensaShubetsu != string.Empty))
                            || (!pdr.IsBOD2KensaShubetsuNull() && (pdr.BOD2KensaShubetsu != string.Empty)))
                        {
                            // 確認検査
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcKakuninKensa);
                        }
                        else if ((!pdr.IsBOD1KekkaNyuryokuNull() && (pdr.BOD1KekkaNyuryoku == "0"))
                            || (!pdr.IsBOD1KekkaNyuryokuNull() && (pdr.BOD1KekkaNyuryoku == "0")))
                        {
                            // 未入力
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcMinyuryoku);
                        }
                    }
                    #endregion

                    #region 残塩
                    {
                        dtlColIndex += 3;

                        // 初回検査(残塩)
                        if (!pdr.IsZANEN1KekkaNyuryokuNull() && (pdr.ZANEN1KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsZANEN1KekkaValueNull())
                            {
                                //kekkaVal = string.Format("{0}", pdr.ZANEN1KekkaValue);
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdZanen, pdr.ZANEN1KekkaValue.ToString()));
                            }
                            if (!pdr.IsZANEN1KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.ZANEN1KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsZANEN1KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 1, pdr.ZANEN1KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsZANEN1SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 2, pdr.ZANEN1SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }

                        }

                        // 再検査(残塩)
                        if ((!pdr.IsZANEN2KekkaNyuryokuNull()) && (pdr.ZANEN2KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsZANEN2KekkaValueNull())
                            {
                                //kekkaVal = string.Format("{0}", pdr.ZANEN2KekkaValue);
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdZanen, pdr.ZANEN2KekkaValue.ToString()));
                            }
                            if (!pdr.IsZANEN2KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.ZANEN2KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex + 1, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsZANEN2KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 1, pdr.ZANEN2KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsZANEN2SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 2, pdr.ZANEN2SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }
                        }

                        // 背景色設定(残塩)
                        if ((!pdr.IsZANEN1KensaShubetsuNull() && (pdr.ZANEN1KensaShubetsu != string.Empty))
                            || (!pdr.IsZANEN2KensaShubetsuNull() && (pdr.ZANEN2KensaShubetsu != string.Empty)))
                        {
                            // 確認検査
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcKakuninKensa);
                        }
                        else if ((!pdr.IsZANEN1KekkaNyuryokuNull() && (pdr.ZANEN1KekkaNyuryoku == "0"))
                            || (!pdr.IsZANEN1KekkaNyuryokuNull() && (pdr.ZANEN1KekkaNyuryoku == "0")))
                        {
                            // 未入力
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcMinyuryoku);
                        }
                    }
                    #endregion

                    #region 塩化物イオン
                    {
                        dtlColIndex += 3;

                        // 初回検査(塩化物イオン)
                        if (!pdr.IsCL1KekkaNyuryokuNull() && (pdr.CL1KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsCL1KekkaValueNull())
                            {
                                //if (!pdr.IsCL1KekkaOndoNull())
                                //{
                                //    kekkaVal = string.Format("{0}({1})", pdr.CL1KekkaValue, pdr.CL1KekkaOndo);
                                //}
                                //else
                                //{
                                //    kekkaVal = string.Format("{0}", pdr.CL1KekkaValue);
                                //}
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdCl, pdr.CL1KekkaValue.ToString()));
                            }
                            if (!pdr.IsCL1KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.CL1KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsCL1KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 1, pdr.CL1KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsCL1SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex, dtlColIndex + 2, pdr.CL1SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }

                        }

                        // 再検査(塩化物イオン)
                        if ((!pdr.IsCL2KekkaNyuryokuNull()) && (pdr.CL2KekkaNyuryoku == "1"))
                        {
                            // 検査結果値＆結果コード
                            kekkaVal = string.Empty;
                            kekkaCd = string.Empty;
                            if (!pdr.IsCL2KekkaValueNull())
                            {
                                //if (!pdr.IsCL2KekkaOndoNull())
                                //{
                                //    kekkaVal = string.Format("{0}({1})", pdr.CL2KekkaValue, pdr.CL2KekkaOndo);
                                //}
                                //else
                                //{
                                //    kekkaVal = string.Format("{0}", pdr.CL2KekkaValue);
                                //}
                                kekkaVal = string.Format("{0}", 
                                    KensaHanteiUtility.HyojiKetasuHosei(input.SearchCond.KmkCdCl, pdr.CL2KekkaValue.ToString()));
                            }
                            if (!pdr.IsCL2KekkaCdNull())
                            {
                                kekkaCd = GetConstNm(KekkaCdList, pdr.CL2KekkaCd);
                            }
                            CellOutput(sheet, dtlRowIndex + 1, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                            // 確認検査種別
                            if (!pdr.IsCL2KensaShubetsuNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 1, pdr.CL2KensaShubetsu);
                            }

                            // 採用値
                            if (!pdr.IsCL2SaiyoKbnNull())
                            {
                                CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 2, pdr.CL2SaiyoKbn == "1" ? CheckOn : CheckOff);
                            }
                        }

                        // 背景色設定(塩化物イオン)
                        if ((!pdr.IsCL1KensaShubetsuNull() && (pdr.CL1KensaShubetsu != string.Empty))
                            || (!pdr.IsCL2KensaShubetsuNull() && (pdr.CL2KensaShubetsu != string.Empty)))
                        {
                            // 確認検査
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcKakuninKensa);
                        }
                        else if ((!pdr.IsCL1KekkaNyuryokuNull() && (pdr.CL1KekkaNyuryoku == "0"))
                            || (!pdr.IsCL1KekkaNyuryokuNull() && (pdr.CL1KekkaNyuryoku == "0")))
                        {
                            // 未入力
                            SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcMinyuryoku);
                        }
                    }
                    #endregion

                    // 塩化物イオン過去
                    //20150111 sou Start
                    //CellOutput(sheet, dtlRowIndex, 19,
                    //    (pdr.IsEnkaIonKako1Null() ? string.Empty : pdr.EnkaIonKako1.ToString()) + " " +
                    //    (pdr.IsEnkaIonKako2Null() ? string.Empty : pdr.EnkaIonKako2.ToString()) + " " +
                    //    (pdr.IsEnkaIonKako3Null() ? string.Empty : pdr.EnkaIonKako3.ToString()) + " " +
                    //    (pdr.IsEnkaIonKako4Null() ? string.Empty : pdr.EnkaIonKako4.ToString()) + " " +
                    //    (pdr.IsEnkaIonKako5Null() ? string.Empty : pdr.EnkaIonKako5.ToString())
                    //    );
                    CellOutput(sheet, dtlRowIndex, 19, 
                        HoteiKensaUtility.GetEnkaIonKako(pdr.KensaIraiJokasoHokenjoCd, 
                        pdr.KensaIraiJokasoTorokuNendo, pdr.KensaIraiJokasoRenban, pdr.UketsukeDt, 5));
                    //20150111 sou End

                    // 課長（チェック）
                    CellOutput(sheet, dtlRowIndex, 20, (pdr.KachoKeninKbn == "1" ? CheckOn : CheckOff));

                    // 副課長（チェック）
                    CellOutput(sheet, dtlRowIndex, 21, (pdr.HukuKachoKeninKbn == "1" ? CheckOn : CheckOff));

                    #endregion
                }

                // テンプレートベースを削除
                ((Worksheet)book.Sheets[1]).Delete();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                }
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CopyTemplate
        /// <summary>
        /// 指定ページ数分テンプレート明細部をコピー
        /// </summary>
        /// <param name="count"></param>
        private void CopyTemplate(Worksheet sheet, int count)
        {
            int idx = DETAIL_OFFSET;

            // 指定ページ数分繰り返す
            for (int i = 1; i <= count; i++)
            {
                // 行範囲コピー
                CopyRow(sheet, DETAIL_OFFSET, PAGE_ROW_CNT, idx + PAGE_ROW_CNT);

                idx += PAGE_ROW_CNT;
            }
        }
        #endregion

        #region GetConstValue
        /// <summary>
        /// 定数値取得
        /// </summary>
        /// <param name="count"></param>
        private string GetConstValue(ConstMstDataSet.ConstMstDataTable ConstMstDt, string renban)
        {
            string res = "";
            foreach (ConstMstDataSet.ConstMstRow cmr in ConstMstDt.Rows)
            {
                if (cmr.ConstRenban == renban)
                {
                    res = cmr.ConstValue;
                    break;
                }
            }
            return res;
        }
        #endregion

        #region GetConstNm
        /// <summary>
        /// 定数名称取得
        /// </summary>
        /// <param name="count"></param>
        private string GetConstNm(ConstMstDataSet.ConstMstDataTable ConstMstDt, string constVal)
        {
            string res = "";
            foreach (ConstMstDataSet.ConstMstRow cmr in ConstMstDt.Rows)
            {
                if (cmr.ConstValue == constVal)
                {
                    res = cmr.ConstNm;
                    break;
                }
            }
            return res;
        }
        #endregion

        #region GetAbnml
        /// <summary>
        /// 異常種別判定
        /// </summary>
        /// <param name="count"></param>
        private string GetAbnml(string scr, string follow, string crossSuishitsu, string crossKako)
        {
            string res = "";

            // スクリーニング＋フォロー
            if (scr == "1")
            {
                if (follow == "1")
                {
                    res += "◎";
                }
                else
                {
                    res += "●";
                }
            }
            else
            {
                if (follow == "1")
                {
                    res += "○";
                }
            }

            // クロスチェック異常(水質判定表)
            if(crossSuishitsu == "1")
            {
                res += "★";
            }

            // クロスチェック異常(過去履歴)
            if (crossKako == "1")
            {
                res += "☆";
            }

            return res;
        }
        #endregion

        #region ToDate
        /// <summary>
        /// 日付変換(yyyyMMdd → yyyy/MM/dd)
        /// </summary>
        /// <param name="count"></param>
        private string ToDate(string ymd)
        {
            if (ymd.Length != 8) return ymd;
            return ymd.Substring(0, 4) + "/" + ymd.Substring(4, 2) + "/" + ymd.Substring(6, 2);
        }
        #endregion

        #region SetBackColor
        /// <summary>
        /// セルの背景色設定
        /// </summary>
        /// <param name="count"></param>
        private void SetBackColor(Worksheet sheet, int row, int col, Color clr)
        {
            sheet.get_Range(sheet.Cells[row, col], sheet.Cells[row + 1, col + 2]).Interior.Color = ColorTranslator.ToOle(clr);
        }
        #endregion

        #endregion
    }
    #endregion
}
