using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.BusinessLogic.Print
{
    public class PrintHelper
    {
        #region public property

        /// <summary>
        /// 各ページ先頭にヘッダの実体を出力する(タイトル行を使用しない)
        /// </summary>
        public bool DuplicateHeader = false;

        /// <summary>
        /// 各ページ末尾ごとにフッタを出力する
        /// </summary>
        public bool DuplicateFooter = false;

        /// <summary>
        /// テンプレートシート名
        /// </summary>
        public string templateSheetName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExcelBind excel { get; set; }

        #endregion

        #region Events


        #endregion

        #region private propterty

        private BaseSection detailSection = null;

        private BaseSection headerSection = null;

        private BaseSection footerSection = null;

        private IEnumerable<DataRow> outputDetailRowsEnum = null;

        private IEnumerable<DataRow> outputHeaderRowsEnum = null;

        private IEnumerable<DataRow> outputFooterRowsEnum = null;

        #endregion

        /// <summary>
        /// process real output
        /// </summary>
        public void Output()
        {
            // NOTICE テンプレートシートが複数の場合を考慮する -> 今回の使用機能では不要
            // NOTICE 出力データ中のキーによる、ページ切替、シート切替を実装 -> 今回の使用機能では不要
            // NOTICE オプショナルでExcelオブジェクトを触れる方法を、なにかしら用意する -> 今回の使用機能では不要
            // NOTICE 出力先シート名を設定する（データに応じたものを使用できるようにする） -> 今回の使用機能では不要

            // 出力開始

            // 出力明細行数カウント
            int detailRowCnt = outputDetailRowsEnum != null ? outputDetailRowsEnum.Count() : 0;

            int headerRowCnt = outputHeaderRowsEnum != null ? outputHeaderRowsEnum.Count() : 0;
            int footerRowCnt = outputFooterRowsEnum != null ? outputFooterRowsEnum.Count() : 0;

            if (detailRowCnt != headerRowCnt && detailRowCnt != footerRowCnt)
            {
                OutputInnerMode();
            }
            else
            {
                OutputOuterMode();
            }

            // テンプレートシートを削除する
            excel.SheetDelete(excel.GetSheetIdx(templateSheetName));
        }

        /// <summary>
        /// 
        /// </summary>
        private void OutputOuterMode()
        {
            // 出力明細行数カウント
            int outputRowCnt = outputDetailRowsEnum != null ? outputDetailRowsEnum.Count() : 0;

            // テンプレートシートをコピー(以降はコピーしたシートを出力先とする)
            excel.SheetCopy(excel.GetSheetIdx(templateSheetName));

            // ページインデックス
            int idxPage = 0;
            int idxDataInPage = 0;
            int currentPageBase = 0;

            //
            for (int i = 0; i < outputRowCnt; i++)
            {
                //bool sheetChanged = false;

                // NOTICE シート切替を実装する(ヘッダ、フッタを処理する) -> 今回の使用機能では不要
                //// ヘッダシート切替判定(キー)
                //if (false)
                //{
                //    sheetChanged = true;
                //}
                //// フッタシート切替判定(キー)
                //else if (false)
                //{
                //    sheetChanged = true;
                //}

                //if (sheetChanged)
                //{
                //    // シート切替処理

                //    idxPage = 0;
                //}

                bool pageChanged = false;

                // 明細ページ切替判定(行数)
                if (detailSection.IsPageBreak())
                {
                    pageChanged = true;
                }

                if (pageChanged)
                {
                    // ページ切替処理

                    // ページ行数算出
                    int pageRowCnt = CalcPageRowCount();

                    // シート内1ページ目行数算出
                    int firstPageRowCnt = CalcFirstPageRowCount();

                    // シート内最終ページ行数算出
                    int lastPageRowCnt = CalcLastPageRowCount();

                    int nextPageBase = idxPage == 0 ? firstPageRowCnt : (idxPage) * pageRowCnt + firstPageRowCnt;

                    // 各セクションのPageOriginを更新する
                    if (headerSection != null) { headerSection.pageRowOrigin = nextPageBase; }
                    if (detailSection != null) { detailSection.pageRowOrigin = nextPageBase; }
                    if (footerSection != null) { footerSection.pageRowOrigin = nextPageBase; }

                    int currentPageRowCnt = idxPage == 0 ? firstPageRowCnt : pageRowCnt;

                    // 改ページ出力
                    excel.SetPageRowBreak(currentPageBase + currentPageRowCnt - 1);

                    idxPage++;
                    currentPageBase = nextPageBase;

                    // テンプレートシートから、内容をコピー
                    // ヘッダテンプレートコピー
                    if (DuplicateHeader)
                    {
                        excel.RowCopy(excel.GetSheetIdx(templateSheetName), headerSection.sectionRowOrigin, excel.GetCurrentSheetIdx(), headerSection.sectionRowOrigin + nextPageBase, headerSection.sectionRowCnt);
                    }
                    // フッタテンプレートコピー
                    if (DuplicateFooter)
                    {
                        excel.RowCopy(excel.GetSheetIdx(templateSheetName), footerSection.sectionRowOrigin, excel.GetCurrentSheetIdx(), footerSection.sectionRowOrigin + nextPageBase, footerSection.sectionRowCnt);
                    }

                    // 明細テンプレートコピー
                    excel.RowCopy(excel.GetSheetIdx(templateSheetName), detailSection.sectionRowOrigin, excel.GetCurrentSheetIdx(), currentPageBase + CalcHeaderRowCnt(idxPage), detailSection.sectionRowCnt);
                }

                if (i == 0 || pageChanged)
                {
                    // ヘッダ出力
                    if (headerSection != null && (DuplicateHeader || i == 0))
                    {
                        OutputHeaderData(i, currentPageBase);
                    }

                    // フッタ出力
                    if (footerSection != null && DuplicateFooter)
                    {
                        OutputFooterData(i, currentPageBase + CalcHeaderRowCnt(idxPage) + CalcDetailRowCnt());
                    }
                }

                // 明細出力
                OutputDetailData(i, currentPageBase + CalcHeaderRowCnt(idxPage));

                idxDataInPage++;
            }

            // 最後のフッタを出力
            // NOTICE -> 今回使用機能ではフッタがないため、不要

            // 印刷範囲設定
            {
                // 出力行数算出
                // ページ行数算出
                int pageRowCnt = CalcPageRowCount();

                // シート内1ページ目行数算出
                int firstPageRowCnt = CalcFirstPageRowCount();

                int pageCnt = outputRowCnt % (detailSection.sectionRowCnt / detailSection.unitRowCnt) == 0 ? outputRowCnt / detailSection.sectionRowCnt : (outputRowCnt / (detailSection.sectionRowCnt / detailSection.unitRowCnt)) + 1;

                int totalRowCnt = pageCnt <= 1 ? firstPageRowCnt : firstPageRowCnt + (pageCnt - 1) * pageRowCnt;

                // NOTICE フッタ有のフォーマットの場合、フッタの考慮も必要

                // NOTICE 将来的には、汎用的な指定方法にする
                excel.SetPrintArea(0, 0, totalRowCnt, detailSection.sectionColCnt- 1);
            }
        }

        private void OutputInnerMode()
        {
            // NOTICE Implements -> 今回使用機能では、該当しないため不要
        }

        public void SetDetailSection(BaseSection section)
        {
            detailSection = section;
            section.Helper = this;
        }

        public void SetHeaderSection(BaseSection section)
        {
            headerSection = section;
            section.Helper = this;
        }

        public void SetFooterSection(BaseSection section)
        {
            footerSection = section;
            section.Helper = this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// table data should be sorted to output order 
        /// </remarks>
        /// <param name="table"></param>
        public void SetDetailData(DataTable table)
        {
            outputDetailRowsEnum = table.Rows.OfType<DataRow>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// row data should be sorted to output order 
        /// </remarks>
        /// <param name="table"></param>
        public void SetDetailData(DataRow[] rows)
        {
            outputDetailRowsEnum = rows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="table"></param>
        public void SetHeaderData(DataTable table)
        {
            outputHeaderRowsEnum = table.Rows.OfType<DataRow>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="table"></param>
        public void SetHeaderData(DataRow[] rows)
        {
            outputHeaderRowsEnum = rows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="table"></param>
        public void SetFooterData(DataTable table)
        {
            outputFooterRowsEnum = table.Rows.OfType<DataRow>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="table"></param>
        public void SetFooterData(DataRow[] rows)
        {
            outputFooterRowsEnum = rows;
        }

        public BaseSection GetDetailSection()
        {
            if (detailSection == null)
            {
                SetDetailSection(new BaseSection());
            }

            return detailSection;
        }

        public BaseSection GetHeaderSection()
        {
            if (headerSection == null)
            {
                SetHeaderSection(new BaseSection());
            }

            return headerSection;
        }

        public BaseSection GetFooterSection()
        {
            if (footerSection == null)
            {
                SetFooterSection(new BaseSection());
            }

            return footerSection;
        }

        public void SetPageBreakKey(List<string> keys)
        {
            // NOTICE detailSectionに対して改ページキーを設定する
        }

        public void SetSheetBreakKey(List<string> keys)
        {
            // NOTICE detailSectionに対して改ページシートを設定する
        }

        #region private

        #region PageRowCount

        private int CalcPageRowCount()
        {
            int pageRowCnt = 0;
            if (footerSection != null && DuplicateFooter) { pageRowCnt = footerSection.sectionRowOrigin + footerSection.sectionRowCnt; }
            else if (detailSection != null)
            {
                pageRowCnt = detailSection.sectionRowOrigin + detailSection.sectionRowCnt;
                if (headerSection == null || !DuplicateHeader)
                {
                    pageRowCnt -= headerSection.sectionRowOrigin + headerSection.sectionRowCnt;
                }
            }
            else if (headerSection != null && DuplicateHeader) { pageRowCnt = headerSection.sectionRowOrigin + headerSection.sectionRowCnt; }

            return pageRowCnt;
        }

        private int CalcFirstPageRowCount()
        {
            int firstPageRowCnt = 0;
            if (footerSection != null && DuplicateFooter) { firstPageRowCnt = footerSection.sectionRowOrigin + footerSection.sectionRowCnt; }
            else if (detailSection != null) { firstPageRowCnt = detailSection.sectionRowOrigin + detailSection.sectionRowCnt; }
            else if (headerSection != null) { firstPageRowCnt = headerSection.sectionRowOrigin + headerSection.sectionRowCnt; }

            return firstPageRowCnt;
        }

        private int CalcLastPageRowCount()
        {
            int lastPageRowCnt = 0;
            if (footerSection != null) { lastPageRowCnt = footerSection.sectionRowOrigin + footerSection.sectionRowCnt; }
            else if (detailSection != null)
            {
                lastPageRowCnt = detailSection.sectionRowOrigin + detailSection.sectionRowCnt;
                if (headerSection == null || !DuplicateHeader)
                {
                    lastPageRowCnt -= headerSection.sectionRowOrigin + headerSection.sectionRowCnt;
                }
            }
            else if (headerSection != null && DuplicateHeader) { lastPageRowCnt = headerSection.sectionRowOrigin + headerSection.sectionRowCnt; }

            return lastPageRowCnt;
        }

        private int CalcHeaderRowCnt(int idxPage)
        {
            int rowCnt = 0;

            if (idxPage == 0 || DuplicateHeader)
            {
                rowCnt = headerSection.sectionRowCnt;
            }

            return rowCnt;
        }

        private int CalcFooterRowCnt(int idxPage)
        {
            int rowCnt = 0;

            if (DuplicateFooter)
            {
                rowCnt = footerSection.sectionRowCnt;
            }

            return rowCnt;
        }

        private int CalcDetailRowCnt()
        {
            return detailSection.sectionRowCnt;
        }

        #endregion

        #region OutputData

        private void OutputDetailData(int idxData, int currentSectoinBase)
        {
            if (outputDetailRowsEnum != null && outputDetailRowsEnum.Count<DataRow>() > idxData)
            {
                int idxDataInpage = idxData % (detailSection.sectionRowCnt / detailSection.unitRowCnt);

                detailSection.OutputData(outputDetailRowsEnum.ElementAt<DataRow>(idxData), idxData, currentSectoinBase, idxDataInpage);
            }
        }

        private void OutputHeaderData(int idxData, int currentSectoinBase)
        {
            if (outputHeaderRowsEnum != null && outputHeaderRowsEnum.Count<DataRow>() > idxData)
            {
                int idxDataInpage = 0;

                headerSection.OutputData(outputHeaderRowsEnum.ElementAt<DataRow>(idxData), idxData, currentSectoinBase, idxDataInpage);
            }
        }

        private void OutputFooterData(int idxData, int currentSectoinBase)
        {
            if (outputFooterRowsEnum != null && outputFooterRowsEnum.Count<DataRow>() > idxData)
            {
                int idxDataInpage = 0;

                footerSection.OutputData(outputFooterRowsEnum.ElementAt<DataRow>(idxData), idxData, currentSectoinBase, idxDataInpage);
            }
        }

        #endregion

        #endregion

    }
}
