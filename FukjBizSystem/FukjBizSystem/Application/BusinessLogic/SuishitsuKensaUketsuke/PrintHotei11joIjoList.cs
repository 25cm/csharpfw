﻿using System;
using System.Data;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeReport;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintHotei11joIjoListBLInput
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
    interface IPrintHotei11joIjoListBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// 条件追加区分
        /// </summary>
        string IraiDateKbn { get; set; }

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        string IraiDateFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        string IraiDateTo { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        string IraiNoTo { get; set; }

        /// <summary>
        /// 支所
        /// </summary>
        string ShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHotei11joIjoListBLInput
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
    class PrintHotei11joIjoListBLInput : BaseExcelPrintBLInputImpl, IPrintHotei11joIjoListBLInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 条件追加区分
        /// </summary>
        public string IraiDateKbn { get; set; }

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        public string IraiDateFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        public string IraiDateTo { get; set; }

        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        public string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        public string IraiNoTo { get; set; }

        /// <summary>
        /// 支所
        /// </summary>
        public string ShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintHotei11joIjoListBLOutput
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
    interface IPrintHotei11joIjoListBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintHotei11joIjoListBLOutput
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
    class PrintHotei11joIjoListBLOutput : IPrintHotei11joIjoListBLOutput
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
    //  クラス名 ： PrintHotei11joIjoListBusinessLogic
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
    class PrintHotei11joIjoListBusinessLogic : BaseExcelPrintBusinessLogic<IPrintHotei11joIjoListBLInput, IPrintHotei11joIjoListBLOutput>
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
        private static readonly int DETAIL_OFFSET = 3;

        /// <summary>
        /// 1ページ明細行数
        /// </summary>
        private static readonly int PAGE_ROW_CNT = 20;

        #endregion 定義

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintHotei11joIjoListBusinessLogic
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
        public PrintHotei11joIjoListBusinessLogic()
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintHotei11joIjoListBLOutput SetBook(IPrintHotei11joIjoListBLInput input, Workbook book)
        {
            IPrintHotei11joIjoListBLOutput output = new PrintHotei11joIjoListBLOutput();

            #region 試験項目コードの取得

            // 試験項目コード(pH)
            string shikenCd_ph = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

            // 試験項目コード(透視度)
            string shikenCd_toshido = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002);

            // 試験項目コード(BOD)
            string shikenCd_bod = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_003);

            // 試験項目コード(残塩)
            string shikenCd_zanen = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_004);

            #endregion

            #region  検査結果の情報を取得

            ISelectPrintHotei11joIjoListByConditionDAInput kensaInput = new SelectPrintHotei11joIjoListByConditionDAInput();
            kensaInput.ShikenKomokuCdPh = shikenCd_ph;
            kensaInput.ShikenKomokuCdToshido = shikenCd_toshido;
            kensaInput.ShikenKomokuCdZanen = shikenCd_zanen;
            kensaInput.ShikenKomokuCdBod = shikenCd_bod;
            kensaInput.Nendo = input.Nendo;
            kensaInput.IraiDateKbn = input.IraiDateKbn;
            kensaInput.IraiDateFrom = input.IraiDateFrom;
            kensaInput.IraiDateTo = input.IraiDateTo;
            kensaInput.IraiNoFrom = input.IraiNoFrom;
            kensaInput.IraiNoTo = input.IraiNoTo;
            kensaInput.ShishoCd = input.ShishoCd;

            ISelectPrintHotei11joIjoListByConditionDAOutput kensaOutput = new SelectPrintHotei11joIjoListByConditionDataAccess().Execute(kensaInput);

            if (kensaOutput.PrintHotei11joIjoList.Count == 0)
            {
                throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
            }

            #endregion
            
            Worksheet sheet = null;

            try
            {
                string gyoshaCd = string.Empty;

                int currentRowIndex = DETAIL_OFFSET;

                // 取得件数分繰り返す
                foreach (SuishitsuKensaUketsukeReportDataSet.PrintHotei11joIjoListRow row in kensaOutput.PrintHotei11joIjoList)
                {
                    // 業者が変わった
                    if (row.KensaIraiSeikyuGyoshaCd != gyoshaCd)
                    {
                        // テンプレートベースをコピー
                        CopySheet(book, 0, book.Sheets.Count);

                        // 出力するシート
                        sheet = (Worksheet)book.Sheets[book.Sheets.Count];

                        // シート名をリネーム
                        sheet.Name = string.Format("{0}({1})", (row.IsGyoshaNmNull() ? string.Empty : row.GyoshaNm), row.KensaIraiSeikyuGyoshaCd);

                        // 対象データの抽出（出力件数チェック）
                        DataRow[] kensaRows = kensaOutput.PrintHotei11joIjoList.Select(string.Format("KensaIraiSeikyuGyoshaCd='{0}'", row.KensaIraiSeikyuGyoshaCd), "KensaIraiSuishitsuUketsukeDt, KensaIraiSuishitsuIraiNo");

                        // 必要ページ数の算出
                        int pagecount = (kensaRows.Length) / PAGE_ROW_CNT;

                        // テンプレート明細部のコピー
                        CopyTemplate(sheet, pagecount);

                        #region ヘッダの出力

                        // 業者名称
                        CellOutput(sheet, 1, 0, (row.IsGyoshaNmNull() ? string.Empty : row.GyoshaNm));

                        // 御中
                        CellOutput(sheet, 1, 4, string.Format("御中　（{0}）", row.KensaIraiSeikyuGyoshaCd));

                        // 件数
                        CellOutput(sheet, 2, 14, string.Format("{0}件", kensaRows.Length));

                        #endregion

                        // 明細出力行位置を先頭に戻す
                        currentRowIndex = DETAIL_OFFSET;

                        // 業者コードを保持
                        gyoshaCd = row.KensaIraiSeikyuGyoshaCd;
                    }

                    // 行番号をインクリメント
                    currentRowIndex++;

                    #region 明細の出力

                    // 行番号
                    int num = currentRowIndex - DETAIL_OFFSET;
                    CellOutput(sheet, currentRowIndex, 0, num);

                    // 受付日
                    if (!row.IsKensaIraiSuishitsuUketsukeDtNull())
                    {
                        CellOutput(sheet, currentRowIndex, 1, DateTime.ParseExact(row.KensaIraiSuishitsuUketsukeDt, "yyyyMMdd", null).ToString("yyyy/MM/dd"));
                    }

                    // 受付番号
                    if (!row.IsKensaIraiSuishitsuIraiNoNull())
                    {
                        CellOutput(sheet, currentRowIndex, 2, row.KensaIraiSuishitsuIraiNo);
                    }

                    // 異常内容
                    if (!row.IsScreeningKohoNull() && row.ScreeningKoho == "2")
                    {
                        CellOutput(sheet, currentRowIndex, 3, "BOD異常");
                    }
                    else if (!row.IsScreeningKohoNull() && row.ScreeningKoho == "3")
                    {
                        CellOutput(sheet, currentRowIndex, 3, "残塩異常");
                    }

                    // 設置者名
                    if (!row.IsKensaIraiSetchishaNmNull())
                    {
                        CellOutput(sheet, currentRowIndex, 4, row.KensaIraiSetchishaNm);
                    }

                    // 設置場所
                    if (!row.IsKensaIraiSetchibashoAdrNull())
                    {
                        CellOutput(sheet, currentRowIndex, 5, row.KensaIraiSetchibashoAdr);
                    }

                    // 処理方式
                    if (!row.IsShoriHoshikiShubetsuNmNull())
                    {
                        CellOutput(sheet, currentRowIndex, 6, row.ShoriHoshikiShubetsuNm);
                    }

                    // 処理能力
                    if (!row.IsKensaIraiShoritaishoJininNull())
                    {
                        CellOutput(sheet, currentRowIndex, 7, string.Format("{0}人", row.KensaIraiShoritaishoJinin));
                    }

                    // Ph
                    if (!row.IsPhValueNull())
                    {
                        if (!row.IsPhKekkaNull() && row.PhKekka == "1")
                        {
                            CellOutput(sheet, currentRowIndex, 8, string.Format("{0}{1}", row.PhValue.ToString("0.0"), "以上"));
                        }
                        else if (!row.IsPhKekkaNull() && row.PhKekka == "2")
                        {
                            CellOutput(sheet, currentRowIndex, 8, string.Format("{0}{1}", row.PhValue.ToString("0.0"), "以下"));
                        }
                        else if (!row.IsPhKekkaNull() && row.PhKekka == "3")
                        {
                            CellOutput(sheet, currentRowIndex, 8, string.Format("{0}{1}", row.PhValue.ToString("0.0"), "未満"));
                        }
                        else
                        {
                            CellOutput(sheet, currentRowIndex, 8, string.Format("{0}", row.PhValue.ToString("0.0")));
                        }
                    }

                    // Tr
                    if (!row.IsTrValueNull())
                    {
                        if (!row.IsTrKekkaNull() && row.TrKekka == "1")
                        {
                            CellOutput(sheet, currentRowIndex, 9, string.Format("{0}{1}", row.TrValue.ToString("0"), "以上"));
                        }
                        else if (!row.IsTrKekkaNull() && row.TrKekka == "2")
                        {
                            CellOutput(sheet, currentRowIndex, 9, string.Format("{0}{1}", row.TrValue.ToString("0"), "以下"));
                        }
                        else if (!row.IsTrKekkaNull() && row.TrKekka == "3")
                        {
                            CellOutput(sheet, currentRowIndex, 9, string.Format("{0}{1}", row.TrValue.ToString("0"), "未満"));
                        }
                        else
                        {
                            CellOutput(sheet, currentRowIndex, 9, string.Format("{0}", row.TrValue.ToString("0")));
                        }
                    }

                    // 残塩
                    if (!row.IsZanenValueNull())
                    {
                        if (!row.IsZanenKekkaNull() && row.ZanenKekka == "1")
                        {
                            CellOutput(sheet, currentRowIndex, 10, string.Format("{0}{1}", row.ZanenValue.ToString("0.00"), "以上"));
                        }
                        else if (!row.IsZanenKekkaNull() && row.ZanenKekka == "2")
                        {
                            CellOutput(sheet, currentRowIndex, 10, string.Format("{0}{1}", row.ZanenValue.ToString("0.00"), "以下"));
                        }
                        else if (!row.IsZanenKekkaNull() && row.ZanenKekka == "3")
                        {
                            CellOutput(sheet, currentRowIndex, 10, string.Format("{0}{1}", row.ZanenValue.ToString("0.00"), "未満"));
                        }
                        else
                        {
                            CellOutput(sheet, currentRowIndex, 10, string.Format("{0}", row.ZanenValue.ToString("0.00")));
                        }
                    }

                    // BOD
                    if (!row.IsBodValueNull())
                    {
                        if (!row.IsBodKekkaNull() && row.BodKekka == "1")
                        {
                            CellOutput(sheet, currentRowIndex, 11, string.Format("{0}{1}", row.BodValue.ToString("0.0"), "以上"));
                        }
                        else if (!row.IsBodKekkaNull() && row.BodKekka == "2")
                        {
                            CellOutput(sheet, currentRowIndex, 11, string.Format("{0}{1}", row.BodValue.ToString("0.0"), "以下"));
                        }
                        else if (!row.IsBodKekkaNull() && row.BodKekka == "3")
                        {
                            CellOutput(sheet, currentRowIndex, 11, string.Format("{0}{1}", row.BodValue.ToString("0.0"), "未満"));
                        }
                        else
                        {
                            CellOutput(sheet, currentRowIndex, 11, string.Format("{0}", row.BodValue.ToString("0.0")));
                        }
                    }

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
                CopyRow(sheet, DETAIL_OFFSET + 1, PAGE_ROW_CNT, idx + PAGE_ROW_CNT + 1);

                idx += PAGE_ROW_CNT;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
