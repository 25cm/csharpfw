using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeReport;
using FukjBizSystem.Application.DataAccess.SuishitsuShikenKoumokuMst;
using FukjBizSystem.Application.DataAccess.SuishitsuKekkaNmMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrint9joKensaDaichoBLInput
    /// <summary>
    /// 法定11条水質異常一覧表出力
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/11  豊田         新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrint9joKensaDaichoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        KeiryoShomeiDaichoSearchCond SearchCond { get; set; }

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
    //  クラス名 ： Print9joKensaDaichoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/11  豊田         新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print9joKensaDaichoBLInput : BaseExcelPrintBLInputImpl, IPrint9joKensaDaichoBLInput
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }

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
    //  インターフェイス名 ： IPrint9joKensaDaichoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/11  豊田         新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrint9joKensaDaichoBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Print9joKensaDaichoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/11  豊田         新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print9joKensaDaichoBLOutput : IPrint9joKensaDaichoBLOutput
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
    //  クラス名 ： Print9joKensaDaichoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者       内容
    /// 2014/12/11  豊田         新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Print9joKensaDaichoBusinessLogic : BaseExcelPrintBusinessLogic<IPrint9joKensaDaichoBLInput, IPrint9joKensaDaichoBLOutput>
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
        private static readonly int DETAIL_OFFSET = 7;

        /// <summary>
        /// 1ページ明細行数
        /// </summary>
        private static readonly int PAGE_ROW_CNT = 30;

        /// <summary>
        /// チェックの状態
        /// </summary>
        string CheckOn =  "☑";
        string CheckOff = "☐";

        /// <summary>
        /// 背景色
        /// </summary>
        Color bcMinyuryoku = Color.Yellow;
        Color bcKakuninKensa = Color.LightBlue;

        #endregion 定義

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Print9joKensaDaichoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者       内容
        /// 2014/12/11  豊田         新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Print9joKensaDaichoBusinessLogic()
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
        /// 2014/12/15  宗           修正
        /// 2015/01/19  habu         修正
        /// 2015/01/22  宗           試験項目毎の桁数制限を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrint9joKensaDaichoBLOutput SetBook(IPrint9joKensaDaichoBLInput input, Workbook book)
        {
            IPrint9joKensaDaichoBLOutput output = new Print9joKensaDaichoBLOutput();

            #region  検査台帳情報の取得

            #region ヘッダ情報を取得
            ISelectPrint9joKensaDaichoHdrByConditionDAInput hdrInput = new SelectPrint9joKensaDaichoHdrByConditionDAInput();

            hdrInput.ShishoCd = input.SearchCond.ShishoCd;
            hdrInput.Nendo = input.SearchCond.Nendo;
            hdrInput.IraiDateKbn = input.SearchCond.IraiUketsukeDtInputKbn;
            hdrInput.IraiDateFrom = input.SearchCond.IraiUketsukeFromDt;
            hdrInput.IraiDateTo = input.SearchCond.IraiUketsukeToDt;
            hdrInput.IraiNoFrom = input.SearchCond.IraiNoFrom;
            hdrInput.IraiNoTo = input.SearchCond.IraiNoTo;

            #region to be removed
            //hdrInput.ShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            //hdrInput.Nendo = input.Nendo;
            //hdrInput.IraiDateKbn = input.IraiDateKbn;
            //hdrInput.IraiDateFrom = input.IraiDateFrom;
            //hdrInput.IraiDateTo = input.IraiDateTo;
            //hdrInput.IraiNoFrom = input.IraiNoFrom;
            //hdrInput.IraiNoTo = input.IraiNoTo;
            #endregion

            ISelectPrint9joKensaDaichoHdrByConditionDAOutput hdrOutput = new SelectPrint9joKensaDaichoHdrByConditionDataAccess().Execute(hdrInput);

            if (hdrOutput.Print9joKensaDaichoHdr.Count == 0)
            {
                throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
            }
            #endregion

            #region 明細情報を取得
            ISelectPrint9joKensaDaichoDtlByConditionDAInput dtlInput = new SelectPrint9joKensaDaichoDtlByConditionDAInput();

            dtlInput.ShishoCd = input.SearchCond.ShishoCd;
            dtlInput.Nendo = input.SearchCond.Nendo;
            dtlInput.IraiDateKbn = input.SearchCond.IraiUketsukeDtInputKbn;
            dtlInput.IraiDateFrom = input.SearchCond.IraiUketsukeFromDt;
            dtlInput.IraiDateTo = input.SearchCond.IraiUketsukeToDt;
            dtlInput.IraiNoFrom = input.SearchCond.IraiNoFrom;
            dtlInput.IraiNoTo = input.SearchCond.IraiNoTo;

            #region to be removed
            //dtlInput.ShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            //dtlInput.Nendo = input.Nendo;
            //dtlInput.IraiDateKbn = input.IraiDateKbn;
            //dtlInput.IraiDateFrom = input.IraiDateFrom;
            //dtlInput.IraiDateTo = input.IraiDateTo;
            //dtlInput.IraiNoFrom = input.IraiNoFrom;
            //dtlInput.IraiNoTo = input.IraiNoTo;
            #endregion

            ISelectPrint9joKensaDaichoDtlByConditionDAOutput dtlOutput = new SelectPrint9joKensaDaichoDtlByConditionDataAccess().Execute(dtlInput);
            #endregion

            #region 水質試験項目マスタ取得
            ISelectSuishitsuShikenKoumokuMstInfoDAInput kmkMstInput = new SelectSuishitsuShikenKoumokuMstInfoDAInput();
            ISelectSuishitsuShikenKoumokuMstInfoDAOutput kmkMstOutput = new SelectSuishitsuShikenKoumokuMstInfoDataAccess().Execute(kmkMstInput);
            #endregion

            // 20150120 sou Start
            #region 水質結果名称マスタ取得
            // 水質結果名称マスタ
            ISelectSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdDAInput daInput = new SelectSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdDAInput();
            daInput.SuishitsuKekkaShishoCd = input.SearchCond.ShishoCd == "0" ? "3" : input.SearchCond.ShishoCd;
            ISelectSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdDAOutput daOutput = new SelectSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdDataAccess().Execute(daInput);
            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmMstList = daOutput.SuishitsuKekkaNmMstDataTable;
            #endregion
            // 20150120 sou End

            #endregion

            Worksheet sheet = null;

            try
            {
                string nendo = string.Empty;

                int currentRowIndex = DETAIL_OFFSET;

                // 出力日
                DateTime curretDate = Boundary.Common.Common.GetCurrentTimestamp().Date;

                // 試験項目リストを取得
                ConstMstDataSet.ConstMstDataTable ShikenKomokuList = Boundary.Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_049) as ConstMstDataSet.ConstMstDataTable;

                // 結果コードリストを取得
                ConstMstDataSet.ConstMstDataTable KekkaCdList = Boundary.Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_052) as ConstMstDataSet.ConstMstDataTable;

                // 結果コード(記号)リストを取得
                ConstMstDataSet.ConstMstDataTable KekkaCdKigoList = Boundary.Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_053) as ConstMstDataSet.ConstMstDataTable;

                // 試験項目コード(pH)
                string kmkCdPh = GetConstValue(ShikenKomokuList, "001");
                // 20150120 sou Start
                //// 試験項目コード(亜硝酸性窒素(定性))
                //string kmkCdNo2nTeisei = GetConstValue(ShikenKomokuList, "083");
                //// 試験項目コード(硝酸性窒素(定性))
                //string kmkCdNo3nTeisei = GetConstValue(ShikenKomokuList, "084");
                // 試験項目コード(外観)
                string kmkCdGaikan = GetConstValue(ShikenKomokuList, "027");
                // 試験項目コード(臭気)
                string kmkCdShuki = GetConstValue(ShikenKomokuList, "028");
                // 試験項目コード(亜硝酸性窒素(定性))
                string kmkCdNo2nTeisei = GetConstValue(ShikenKomokuList, "030");
                // 試験項目コード(硝酸性窒素(定性))
                string kmkCdNo3nTeisei = GetConstValue(ShikenKomokuList, "031");
                // 20150120 sou End

                // ヘッダ取得件数分繰り返す
                foreach (SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoHdrRow hdrRow in hdrOutput.Print9joKensaDaichoHdr)
                {
                    #region 年度が変わった
                    if (hdrRow.IraiNendo != nendo)
                    {
                        // 年度を保持
                        nendo = hdrRow.IraiNendo;

                        // テンプレートベースをコピー
                        CopySheet(book, 0, book.Sheets.Count);

                        // 出力するシート
                        sheet = (Worksheet)book.Sheets[book.Sheets.Count];

                        // シート名をリネーム
                        sheet.Name = string.Format("{0}年度", Boundary.Common.Common.ConvertToHoshouNendoWareki(hdrRow.IraiNendo));

                        // 出力枠（1ブロック=6行）
                        int blockCount = 0;

                        #region 出力件数の算出

                        // 対象年度データの抽出（出力件数チェック）
                        DataRow[] kensaRows = hdrOutput.Print9joKensaDaichoHdr.Select(string.Format("IraiNendo='{0}'", hdrRow.IraiNendo), "ShishoCd, SuishitsuKensaIraiNo");

                        foreach (SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoHdrRow innerRow in kensaRows)
                        {
                            // 依頼ごとに出力対象の試験項目がいくつあるか
                            int shikenCount = 0;
                            foreach (ConstMstDataSet.ConstMstRow shikenKomoku in ShikenKomokuList)
                            {
                                // 試験項目ごとに初回検査、再検査どちらかの明細があれば1件とカウントする
                                if (dtlOutput.Print9joKensaDaichoDtl.FindByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkoumokuCdSaikensaKbn(
                                                        "1", innerRow.IraiNendo, innerRow.ShishoCd, innerRow.SuishitsuKensaIraiNo, shikenKomoku.ConstValue, "0") != null)
                                {
                                    shikenCount++;
                                }
                                else if (dtlOutput.Print9joKensaDaichoDtl.FindByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkoumokuCdSaikensaKbn(
                                                        "1", innerRow.IraiNendo, innerRow.ShishoCd, innerRow.SuishitsuKensaIraiNo, shikenKomoku.ConstValue, "1") != null)
                                {
                                    shikenCount++;
                                }
                            }

                            blockCount += shikenCount == 0 ? 1 : ((shikenCount - 1) / 16) + 1;
                        }

                        #endregion

                        // 必要ページ数の算出
                        int pagecount = (blockCount - 1) / 5;

                        // テンプレート明細部のコピー
                        CopyTemplate(sheet, pagecount);

                        #region ヘッダの出力

                        // 支所
                        CellOutput(sheet, 1, 0, Boundary.Common.Common.GetShishoNmByShishoCd(Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd));

                        // 年度
                        CellOutput(sheet, 1, 8, string.Format("≪平成{0}年度≫", Boundary.Common.Common.ConvertToHoshouNendoWareki(nendo)));

                        // 印刷日
                        CellOutput(sheet, 2, 20, curretDate);

                        // 指定範囲(From)
                        if (!string.IsNullOrEmpty(input.SearchCond.IraiNoFrom))
                        {
                            CellOutput(sheet, 3, 11, input.SearchCond.IraiNoFrom);
                        }

                        // 指定範囲(To)
                        if (!string.IsNullOrEmpty(input.SearchCond.IraiNoTo))
                        {
                            CellOutput(sheet, 3, 15, input.SearchCond.IraiNoTo);
                        }

                        if (input.SearchCond.IraiUketsukeDtInputKbn == "1")
                        {
                            // 受付日指定範囲(From)
                            if (!string.IsNullOrEmpty(input.SearchCond.IraiUketsukeFromDt))
                            {
                                CellOutput(sheet, 4, 11, ToDate(input.SearchCond.IraiUketsukeFromDt));
                            }

                            // 受付日指定範囲(To)
                            if (!string.IsNullOrEmpty(input.SearchCond.IraiUketsukeToDt))
                            {
                                CellOutput(sheet, 4, 15, ToDate(input.SearchCond.IraiUketsukeToDt));
                            }
                        }

                        // 件数
                        CellOutput(sheet, 4, 21, kensaRows.Length);
                        
                        #endregion

                        // 明細出力行位置を先頭に戻す
                        currentRowIndex = DETAIL_OFFSET;
                    }
                    #endregion

                    // 行番号をインクリメント
                    currentRowIndex++;

                    #region 明細の出力

                    // 依頼No
                    CellOutput(sheet, currentRowIndex, 0, hdrRow.SuishitsuKensaIraiNo);

                    // 水質の種類
                    if (!hdrRow.IsSuishitsuNmNull())
                    {
                        CellOutput(sheet, currentRowIndex, 1, hdrRow.SuishitsuNm);
                    }

                    // 処理方式（上段）
                    if (!hdrRow.IsShoriHoshikiShubetsuNmNull())
                    {
                        CellOutput(sheet, currentRowIndex, 2, hdrRow.ShoriHoshikiShubetsuNm);
                    }

                    // 処理方式（下段）
                    if (!hdrRow.IsShoriHoshikiNmNull())
                    {
                        CellOutput(sheet, currentRowIndex + 3, 2, hdrRow.ShoriHoshikiNm);
                    }

                    // 課長（チェック）
                    CellOutput(sheet, currentRowIndex, 27, (hdrRow.KachoKeninKbn == "1" ? CheckOn : CheckOff));

                    // 副課長（チェック）
                    CellOutput(sheet, currentRowIndex, 28, (hdrRow.HukuKachoKeninKbn == "1" ? CheckOn : CheckOff));

                    // 計量管理者（チェック）
                    CellOutput(sheet, currentRowIndex, 29, (hdrRow.KeiryoKanrishaKeninKbn == "1" ? CheckOn : CheckOff));

                    // 測定結果
                    int outputShikenCount = 0;
                    foreach (ConstMstDataSet.ConstMstRow shikenKomoku in ShikenKomokuList)
                    {
                        // 初回検査
                        SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoDtlRow kensaDtl = dtlOutput.Print9joKensaDaichoDtl.FindByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkoumokuCdSaikensaKbn(
                                                "1", hdrRow.IraiNendo, hdrRow.ShishoCd, hdrRow.SuishitsuKensaIraiNo, shikenKomoku.ConstValue, "0");
                        // 再検査
                        SuishitsuKensaUketsukeReportDataSet.Print9joKensaDaichoDtlRow saiKensaDtl = dtlOutput.Print9joKensaDaichoDtl.FindByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkoumokuCdSaikensaKbn(
                                                "1", hdrRow.IraiNendo, hdrRow.ShishoCd, hdrRow.SuishitsuKensaIraiNo, shikenKomoku.ConstValue, "1");

                        if (kensaDtl != null || saiKensaDtl != null)
                        {
                            outputShikenCount++;

                            //int dtlRowIndex = currentRowIndex + (3 * (int)((outputShikenCount - 1) / 8));
                            //int dtlColIndex = ((int)((outputShikenCount - 1) / 8) + 1) * 3;
                            int dtlRowIndex = currentRowIndex + ((outputShikenCount / 8) * 3) - ((outputShikenCount % 8) == 0 ? 3 : 0);
                            int dtlColIndex = 3 + (((outputShikenCount - 1) % 8) * 3);

                            // 背景色判定
                            bool minyuryokuFlg = false;
                            bool kakuninKensaFlg = false;

                            // 試験項目名
                            CellOutput(sheet, dtlRowIndex, dtlColIndex, GetKoumokuNm(kmkMstOutput, shikenKomoku.ConstValue));

                            // 初回検査
                            if (kensaDtl != null)
                            {
                                // 結果入力済み
                                if ((!kensaDtl.IsKeiryoShomeiKekkaNyuryokuNull()) 
                                    && (kensaDtl.KeiryoShomeiKekkaNyuryoku == "1"))
                                {
                                    string kekkaVal = string.Empty;
                                    string kekkaCd = string.Empty;

                                    // 検査結果値
                                    if (!kensaDtl.IsKeiryoShomeiKekkaValueNull())
                                    {
                                        // pH
                                        if ((kensaDtl.ShikenkoumokuCd == kmkCdPh)
                                            && (!kensaDtl.IsKeiryoShomeiKekkaOndoNull()))
                                        {
                                            //kekkaVal = string.Format("{0}({1})", kensaDtl.KeiryoShomeiKekkaValue, kensaDtl.KeiryoShomeiKekkaOndo);
                                            kekkaVal = string.Format("{0}({1})",
                                                KensaHanteiUtility.HyojiKetasuHosei(kensaDtl.ShikenkoumokuCd, kensaDtl.KeiryoShomeiKekkaValue.ToString()), 
                                                KensaHanteiUtility.HyojiKetasuHosei("000", kensaDtl.KeiryoShomeiKekkaOndo.ToString()));
                                        }
                                        //20150120 sou Start
                                        else if ((kensaDtl.ShikenkoumokuCd == kmkCdGaikan)
                                            || (kensaDtl.ShikenkoumokuCd == kmkCdShuki)
                                            || (kensaDtl.ShikenkoumokuCd == kmkCdNo2nTeisei)
                                            || (kensaDtl.ShikenkoumokuCd == kmkCdNo3nTeisei)
                                            )
                                        {
                                            kekkaVal = string.Empty;
                                        }
                                        //20150120 sou End
                                        else
                                        {
                                            //kekkaVal = string.Format("{0}", kensaDtl.KeiryoShomeiKekkaValue);
                                            kekkaVal = string.Format("{0}", 
                                                KensaHanteiUtility.HyojiKetasuHosei(kensaDtl.ShikenkoumokuCd, kensaDtl.KeiryoShomeiKekkaValue.ToString()));
                                        }
                                    }
                                    // 結果コード
                                    if (!kensaDtl.IsKeiryoShomeiKekkaCdNull())
                                    {
                                        //20150120 sou Start
                                        // 亜硝酸性窒素(定性) 又は 硝酸性窒素(定性)
                                        //if ((kensaDtl.ShikenkoumokuCd == kmkCdNo2nTeisei)
                                        //    || (kensaDtl.ShikenkoumokuCd == kmkCdNo3nTeisei))
                                        //{
                                        //    kekkaCd = GetConstNm(KekkaCdKigoList, kensaDtl.KeiryoShomeiKekkaCd);
                                        //}
                                        if ((kensaDtl.ShikenkoumokuCd == kmkCdGaikan)
                                            || (kensaDtl.ShikenkoumokuCd == kmkCdShuki)
                                            || (kensaDtl.ShikenkoumokuCd == kmkCdNo2nTeisei)
                                            || (kensaDtl.ShikenkoumokuCd == kmkCdNo3nTeisei)
                                            )
                                        {
                                            kekkaCd = GetSuishitsuKekkaNm(SuishitsuKekkaNmMstList, kensaDtl.KeiryoShomeiKekkaCd);
                                        }
                                        //20150120 sou End
                                        else
                                        {
                                            kekkaCd = GetConstNm(KekkaCdList, kensaDtl.KeiryoShomeiKekkaCd);
                                        }
                                    }
                                    // 検査結果値＆結果コード
                                    CellOutput(sheet, dtlRowIndex + 1, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                                    // 確認検査種別
                                    if (!kensaDtl.IsKensaShubetsuNull())
                                    {
                                        CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 1, kensaDtl.KensaShubetsu);
                                    }

                                    // 採用値
                                    if (!kensaDtl.IsKeiryoShomeiSaiyoKbnNull())
                                    {
                                        CellOutput(sheet, dtlRowIndex + 1, dtlColIndex + 2, kensaDtl.KeiryoShomeiSaiyoKbn == "1" ? CheckOn : CheckOff);
                                    }
                                }

                                // 背景色設定
                                if (!kensaDtl.IsKensaShubetsuNull() && (kensaDtl.KensaShubetsu != string.Empty))
                                {
                                    // 確認検査
                                    kakuninKensaFlg = true;
                                }
                                else if (!kensaDtl.IsKeiryoShomeiKekkaNyuryokuNull() && (kensaDtl.KeiryoShomeiKekkaNyuryoku == "0"))
                                {
                                    if (!kakuninKensaFlg)
                                    {
                                        // 未入力
                                        minyuryokuFlg = true;
                                    }
                                }
                            }

                            // 再検査
                            if (saiKensaDtl != null)
                            {
                                // 結果入力済み
                                if ((!saiKensaDtl.IsKeiryoShomeiKekkaNyuryokuNull())
                                    && (saiKensaDtl.KeiryoShomeiKekkaNyuryoku == "1"))
                                {
                                    string kekkaVal = string.Empty;
                                    string kekkaCd = string.Empty;

                                    // 検査結果値
                                    if (!saiKensaDtl.IsKeiryoShomeiKekkaValueNull())
                                    {
                                        // pH
                                        if ((saiKensaDtl.ShikenkoumokuCd == kmkCdPh)
                                            && (!saiKensaDtl.IsKeiryoShomeiKekkaOndoNull()))
                                        {
                                            //kekkaVal = string.Format("{0}({1})", saiKensaDtl.KeiryoShomeiKekkaValue, saiKensaDtl.KeiryoShomeiKekkaOndo);
                                            kekkaVal = string.Format("{0}({1})", 
                                                KensaHanteiUtility.HyojiKetasuHosei(kensaDtl.ShikenkoumokuCd, saiKensaDtl.KeiryoShomeiKekkaValue.ToString()), 
                                                KensaHanteiUtility.HyojiKetasuHosei("000", saiKensaDtl.KeiryoShomeiKekkaOndo.ToString()));
                                        }
                                        //20150120 sou Start
                                        else if ((saiKensaDtl.ShikenkoumokuCd == kmkCdGaikan)
                                            || (saiKensaDtl.ShikenkoumokuCd == kmkCdShuki)
                                            || (saiKensaDtl.ShikenkoumokuCd == kmkCdNo2nTeisei)
                                            || (saiKensaDtl.ShikenkoumokuCd == kmkCdNo3nTeisei)
                                            )
                                        {
                                            kekkaVal = string.Empty;
                                        }
                                        //20150120 sou End
                                        else
                                        {
                                            //kekkaVal = string.Format("{0}", saiKensaDtl.KeiryoShomeiKekkaValue);
                                            kekkaVal = string.Format("{0}", 
                                                KensaHanteiUtility.HyojiKetasuHosei(kensaDtl.ShikenkoumokuCd, saiKensaDtl.KeiryoShomeiKekkaValue.ToString()));
                                        }
                                    }
                                    // 結果コード
                                    if (!saiKensaDtl.IsKeiryoShomeiKekkaCdNull())
                                    {
                                        //20150120 sou Start
                                        // 亜硝酸性窒素(定性) 又は 硝酸性窒素(定性)
                                        //if ((saiKensaDtl.ShikenkoumokuCd == kmkCdNo2nTeisei)
                                        //    || (saiKensaDtl.ShikenkoumokuCd == kmkCdNo3nTeisei))
                                        //{
                                        //    kekkaCd = GetConstNm(KekkaCdKigoList, saiKensaDtl.KeiryoShomeiKekkaCd);
                                        //}
                                        if ((saiKensaDtl.ShikenkoumokuCd == kmkCdGaikan)
                                            || (saiKensaDtl.ShikenkoumokuCd == kmkCdShuki)
                                            || (saiKensaDtl.ShikenkoumokuCd == kmkCdNo2nTeisei)
                                            || (saiKensaDtl.ShikenkoumokuCd == kmkCdNo3nTeisei))
                                        {
                                            kekkaCd = GetSuishitsuKekkaNm(SuishitsuKekkaNmMstList, saiKensaDtl.KeiryoShomeiKekkaCd);
                                        }
                                        //20150120 sou End
                                        else
                                        {
                                            kekkaCd = GetConstNm(KekkaCdList, saiKensaDtl.KeiryoShomeiKekkaCd);
                                        }
                                    }
                                    // 検査結果値＆結果コード
                                    CellOutput(sheet, dtlRowIndex + 2, dtlColIndex, string.Format("{0}{1}", kekkaVal, kekkaCd));

                                    // 確認検査種別
                                    if (!saiKensaDtl.IsKensaShubetsuNull())
                                    {
                                        CellOutput(sheet, dtlRowIndex + 2, dtlColIndex + 1, saiKensaDtl.KensaShubetsu);
                                    }

                                    // 採用値
                                    if (!saiKensaDtl.IsKeiryoShomeiSaiyoKbnNull())
                                    {
                                        CellOutput(sheet, dtlRowIndex + 2, dtlColIndex + 2, saiKensaDtl.KeiryoShomeiSaiyoKbn == "1" ? CheckOn : CheckOff);
                                    }
                                }

                                // 背景色設定
                                if (!saiKensaDtl.IsKensaShubetsuNull() && (saiKensaDtl.KensaShubetsu != string.Empty))
                                {
                                    // 確認検査
                                    kakuninKensaFlg = true;
                                }
                                else if (!saiKensaDtl.IsKeiryoShomeiKekkaNyuryokuNull() && (saiKensaDtl.KeiryoShomeiKekkaNyuryoku == "0"))
                                {
                                    if (!kakuninKensaFlg)
                                    {
                                        // 未入力
                                        minyuryokuFlg = true;
                                    }
                                }
                            }

                            // 背景色設定
                            if (kakuninKensaFlg)
                            {
                                // 確認検査
                                SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcKakuninKensa);
                            }
                            else if (minyuryokuFlg)
                            {
                                // 未入力
                                SetBackColor(sheet, dtlRowIndex + 1, dtlColIndex + 1, bcMinyuryoku);
                            }
                        }
                    }

                    #endregion

                    // 使用したブロックの最終行番号までインクリメント
                    currentRowIndex += (6 * ((int)((outputShikenCount - 1) / 16) + 1)) - 1;
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
                CopyRow(sheet, DETAIL_OFFSET + 1, PAGE_ROW_CNT, idx + PAGE_ROW_CNT + 1);

                idx += PAGE_ROW_CNT;
            }
        }
        #endregion

        #region GetKoumokuNm
        /// <summary>
        /// 試験項目名取得
        /// </summary>
        /// <param name="count"></param>
        private string GetKoumokuNm(ISelectSuishitsuShikenKoumokuMstInfoDAOutput kmkMstOutput, string kmkCd)
        {
            string res = "";

            foreach (DataRow dr in kmkMstOutput.SuishitsuShikenKoumokuMstDataTable.Rows)
            {
                if (dr[0].ToString() == kmkCd)
                {
                    // 略称名称
                    res = dr[2].ToString();
                    break;
                }
            }

            return res;
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

        // 20150120 sou Start
        #region GetSuishitsuKekkaNm
        /// <summary>
        /// 水質結果名称取得
        /// </summary>
        /// <param name="count"></param>
        private string GetSuishitsuKekkaNm(SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaMstDt, string KekkaCd)
        {
            string res = "";
            foreach (SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstRow skmr in SuishitsuKekkaMstDt.Rows)
            {
                if (skmr.SuishitsuKekkaNmCd == KekkaCd)
                {
                    res = skmr.SuishitsuKekkaNm;
                    break;
                }
            }
            return res;
        }
        #endregion
        // 20150120 sou End

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
            sheet.get_Range(sheet.Cells[row, col], sheet.Cells[row + 2, col + 2]).Interior.Color = ColorTranslator.ToOle(clr);
        }
        #endregion

        #endregion
    }
    #endregion
}
