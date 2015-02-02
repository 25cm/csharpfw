using System;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.JinendoGaikanYoteiOutputTbl;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJinendoGaikanKensaYoteiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJinendoGaikanKensaYoteiBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 検査予定年
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJinendoGaikanKensaYoteiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanKensaYoteiBLInput : BaseExcelPrintBLInputImpl, IPrintJinendoGaikanKensaYoteiBLInput
    {
        /// <summary>
        /// 検査予定年
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintJinendoGaikanKensaYoteiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintJinendoGaikanKensaYoteiBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintJinendoGaikanKensaYoteiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanKensaYoteiBLOutput : IPrintJinendoGaikanKensaYoteiBLOutput
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
    //  クラス名 ： PrintJinendoGaikanKensaYoteiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintJinendoGaikanKensaYoteiBusinessLogic : BaseExcelPrintBusinessLogic<IPrintJinendoGaikanKensaYoteiBLInput, IPrintJinendoGaikanKensaYoteiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintJinendoGaikanKensaYoteiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintJinendoGaikanKensaYoteiBusinessLogic()
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
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HieuNH　　　新規作成
        /// 2014/12/18  kiyokuni    duplicatedが別シート対応できていないので廃止
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintJinendoGaikanKensaYoteiBLOutput SetBook(IPrintJinendoGaikanKensaYoteiBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintJinendoGaikanKensaYoteiBLOutput output = new PrintJinendoGaikanKensaYoteiBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;
            Worksheet tempSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Paginator
                string tempjHoteiSishoCd = string.Empty;
                string tempjGenChikuCd = string.Empty;

                string tempGyoshaNm1 = string.Empty;
                string tempGyoshaNm2 = string.Empty;
                bool duplicated1 = false;
                bool duplicated2 = false;

                // Current detail row in page
                int curRow = 4;

                // Preparing data for print
                ISelectJinendoGaikanYoteiPrintByNendoDAInput daInput = new SelectJinendoGaikanYoteiPrintByNendoDAInput();
                daInput.Nendo = input.Nendo;
                ISelectJinendoGaikanYoteiPrintByNendoDAOutput daOutput = new SelectJinendoGaikanYoteiPrintByNendoDataAccess().Execute(daInput);
                JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiPrintDataTable printTable = daOutput.JinendoGaikanYoteiPrintDataTable;

                foreach (JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiPrintRow row in
                    printTable.Select(string.Empty, "JokasoHoteiSishoCd, JokasoGenChikuCd, YoteiNengetsu, SeikyuGyoshaCd, KensaIraiHokenjoCd1, KensaIraiRenban1"))
                {
                    //if (!tempGyoshaNm1.Equals(row.IsGyoshaNm1Null() ? string.Empty : row.GyoshaNm1))
                    //{
                        tempGyoshaNm1 = row.IsGyoshaNm1Null() ? string.Empty : row.GyoshaNm1;
                    //    duplicated1 = false;
                    //}
                    //else
                        duplicated1 = true;

                    //if (!tempGyoshaNm2.Equals(row.IsGyoshaNm2Null() ? string.Empty : row.GyoshaNm2))
                    //{
                        tempGyoshaNm2 = row.IsGyoshaNm2Null() ? string.Empty : row.GyoshaNm2;
                    //    duplicated2 = false;
                    //}
                    //else
                        duplicated2 = true;


                    // New sheet?
                    if (!tempjHoteiSishoCd.Equals(row.JokasoHoteiSishoCd) || !tempjGenChikuCd.Equals(row.JokasoGenChikuCd))
                    {
                        // Reset row index for new sheet
                        curRow = 4;

                        // Copy a new sheet
                        tempSheet = (Worksheet)book.Sheets["Sheet1"];
                        tempSheet.Copy(tempSheet, Type.Missing);

                        // Set output sheet to current active sheet
                        outputSheet = (Worksheet)book.ActiveSheet;
                        outputSheet.Name = string.Concat("次年度外観依頼印刷チェックリスト_", row.JokasoHoteiSishoCd, "_", row.JokasoGenChikuCd);

                        // Number of detail rows on each sheet
                        int rowCnt = printTable.Select(string.Format("JokasoGenChikuCd = '{0}' AND JokasoHoteiSishoCd = '{1}' ", row.JokasoGenChikuCd, row.JokasoHoteiSishoCd)).Length;

                        // Header
                        SetHeader(outputSheet, row, input.SystemDt, rowCnt);
                    }

                    // Detail page
                    SetDetail(outputSheet, row, curRow, duplicated1, duplicated2);

                    // Reset paginator
                    tempjHoteiSishoCd = row.JokasoHoteiSishoCd;
                    tempjGenChikuCd = row.JokasoGenChikuCd;

                    // Next detail row
                    curRow++;
                }
                // 2シート以上あるか？
                if (book.Sheets.Count > 1)
                {
                    // テンプレートシートを削除
                    tempSheet.Delete();
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                #region オブジェクトを解放
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (tempSheet != null) { Marshal.ReleaseComObject(tempSheet); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region SetHeader
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <param name="now"></param>
        /// <param name="rowCnt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/25　HieuNH　　　新規作成
        /// 2014/12/08　HieuNH　　　Check null value
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeader(Worksheet outputSheet, JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiPrintRow row, DateTime now, int rowCnt)
        {
            // 検索結果の検査予定年
            CellOutput(outputSheet, 0, 0, string.Concat(row.KensaIraiNendo1, "/01/01"));

            // 支所名称 
            //// MODIFY HieuNH 2014/12/08 BEGIN
            //CellOutput(outputSheet, 2, 7, row.ShishoNm);
            CellOutput(outputSheet, 2, 7, row.IsShishoNmNull()? string.Empty : row.ShishoNm);
            //// MODIFY HieuNH 2014/12/08 END

            // 地区名称 
            //// MODIFY HieuNH 2014/12/08 BEGIN
            //CellOutput(outputSheet, 2, 21, row.ChikuNm);
            CellOutput(outputSheet, 2, 21, row.IsChikuNmNull() ? string.Empty : row.ChikuNm);
            //// MODIFY HieuNH 2014/12/08 END

            // 現地区コード 
            //// MODIFY HieuNH 2014/12/08 BEGIN
            //CellOutput(outputSheet, 2, 35, string.Concat("'", row.ChikuCd));
            CellOutput(outputSheet, 2, 35, string.Concat("'", row.IsChikuCdNull()? string.Empty : row.ChikuCd));
            //// MODIFY HieuNH 2014/12/08 END

            // シート単位の件数
            CellOutput(outputSheet, 2, 50, rowCnt.ToString());

            // システム日付
            CellOutput(outputSheet, 2, 87, now);
        }
        #endregion

        #region SetDetail
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputSheet"></param>
        /// <param name="row"></param>
        /// <param name="curRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/25　HieuNH　　　新規作成
        /// 2014/12/09　HieuNH　　　Set border for new row, check null
        /// 2014/12/18  kiyokuni    (15)がNullになる場合の対処が抜けていたのを修正、duplicatedが別シート対応できていないので廃止
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDetail(Worksheet outputSheet, JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiPrintRow row, int curRow, bool duplicated1, bool duplicated2)
        {
            //// ADD HieuNH 2014/12/09 BEGIN
            if(curRow > 5)
                CopyRow(outputSheet, 5, 1, curRow);
            //// ADD HieuNH 2014/12/09 END

            // 予定年月 (7)
            CellOutput(outputSheet, curRow, 0, string.Concat(row.YoteiNengetsu.Substring(4,2), "月"));

            //if(!duplicated1)
            //{
                // 業者名称 (8)
                CellOutput(outputSheet, curRow, 4, row.IsGyoshaNm1Null()?string.Empty:row.GyoshaNm1);
            //}
            //if(!duplicated2)
            //{
                // 業者名称 (9)
                CellOutput(outputSheet, curRow, 13, row.IsGyoshaNm2Null() ? string.Empty:row.GyoshaNm2);
            //}

            // 検査依頼保健所コード /年度/連番(10)
            CellOutput(outputSheet, curRow, 22, string.Concat(row.KensaIraiHokenjoCd1, "-",
                Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo1, "yy"), "-", row.KensaIraiRenban1));

            // 設置者名（漢字）(11)
            CellOutput(outputSheet, curRow, 33, row.KensaIraiSetchishaNm);

            // 検査依頼設置場所（住所） (12)
            CellOutput(outputSheet, curRow, 43, row.KensaIraiSetchibashoAdr);

            // 処理方式区分名(13)
            CellOutput(outputSheet, curRow, 58, row.IsConstNmNull()?string.Empty:row.ConstNm);

            // 処理対象人員 (14)
            //// MODIFY HieuNH 2014/12/09 BEGIN
            //CellOutput(outputSheet, curRow, 62, row.KensaIraiShoritaishoJinin);
            //CellOutput(outputSheet, curRow, 62, row.IsKensaIraiShoritaishoJininNull() ? string.Empty : row.KensaIraiShoritaishoJinin);
            //// MODIFY HieuNH 2014/12/09 END
            // 20141217 habu Mod string -> int
            CellOutput(outputSheet, curRow, 62, row.IsKensaIraiShoritaishoJininNull() ? string.Empty : row.KensaIraiShoritaishoJinin.ToString());
            // 20141217 End

            // 検査依頼保健所コード/年度/連番(15) 
            CellOutput(outputSheet, curRow, 66, row.IsKensaIraiHokenjoCd2Null() ? string.Empty : string.Concat(row.KensaIraiHokenjoCd2, "-",
                Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo2,"yy") , "-", row.KensaIraiRenban2));

            // 検査年/月/日(16)
            CellOutput(outputSheet, curRow, 78, string.Concat(row.IsKensaIraiKensaNenNull()?string.Empty:Utility.DateUtility.ConvertToWareki(row.KensaIraiKensaNen, "yy"), "/", row.IsKensaIraiKensaTsukiNull()?string.Empty:row.KensaIraiKensaTsuki, "/", row.IsKensaIraiKensaBiNull()?string.Empty:row.KensaIraiKensaBi));

            // 検索結果の前回依頼保健所コード/年度/連番(17)
            CellOutput(outputSheet, curRow, 86, row.IsKensaIraiZenkaiHokenjoCdNull()?"":string.Concat(row.KensaIraiZenkaiHokenjoCd, "-",
                Utility.DateUtility.ConvertToWareki(row.KensaIraiZenkaiNendo, "yy"), "-", row.KensaIraiZenkaiRenban));

            // 前回検査日 (18)
            CellOutput(outputSheet, curRow, 93, Utility.DateUtility.ConvertToWareki(row.KensaIraiZenkaiKensaDt,"yy/MM/dd"));
        }
        #endregion

        #endregion
    }
    #endregion
}
