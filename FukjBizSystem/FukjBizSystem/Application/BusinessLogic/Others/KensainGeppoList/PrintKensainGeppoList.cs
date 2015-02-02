using System.Runtime.InteropServices;
using System.Windows.Forms;
using FukjBizSystem.Application.DataSet;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensainGeppoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensainGeppoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensainGeppoListBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// KensainGeppoListDgv 
        /// </summary>
        DataGridView KensainGeppoListDgv { get; set; }

        /// <summary>
        /// TaisyoYMFrom
        /// </summary>
        string TaisyoYMFrom { get; set; }

        /// <summary>
        /// TaisyoYMTo
        /// </summary>
        string TaisyoYMTo { get; set; }

        /// <summary>
        /// PrintKensainGeppoListDataTable
        /// </summary>
        KensainGeppoTblDataSet.PrintKensainGeppoListDataTable PrintKensainGeppoListDataTable { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainGeppoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainGeppoListBLInput : BaseExcelPrintBLInputImpl, IPrintKensainGeppoListBLInput
    {
        ///// <summary>
        ///// 保存ファイルモード
        ///// </summary>
        //public int SaveFileMode { get; set; }

        ///// <summary>
        ///// ＥＸＣＥＬ書式へのパス
        ///// </summary>
        //public string FormatPath { get; set; }

        ///// <summary>
        ///// 帳票ディレクトリパス
        ///// </summary>
        //public string PrintDirectory { get; set; }

        ///// <summary>
        ///// 指定保存パス
        ///// 未指定の場合は、帳票出力ディレクトリに出力されます
        ///// </summary>
        //public string SavePath { get; set; }

        ///// <summary>
        ///// 処理後ＥＸＣＥＬ表示フラグ
        ///// </summary>
        //public bool AfterDispFlg { get; set; }

        ///// <summary>
        ///// 処理後印刷フラグ
        ///// </summary>
        //public bool AfterPrintFlg { get; set; }

        ///// <summary>
        ///// 印刷プリンタ名
        ///// </summary>
        //public string PrinterName { get; set; }

        /// <summary>
        /// KensainGeppoListDgv 
        /// </summary>
        public DataGridView KensainGeppoListDgv { get; set; }

        /// <summary>
        /// TaisyoYMFrom
        /// </summary>
        public string TaisyoYMFrom { get; set; }

        /// <summary>
        /// TaisyoYMTo
        /// </summary>
        public string TaisyoYMTo { get; set; }

        /// <summary>
        /// PrintKensainGeppoListDataTable
        /// </summary>
        public KensainGeppoTblDataSet.PrintKensainGeppoListDataTable PrintKensainGeppoListDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintKensainGeppoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintKensainGeppoListBLOutput : IBaseExcelPrintBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainGeppoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainGeppoListBLOutput : BaseExcelPrintBLOutputImpl, IPrintKensainGeppoListBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath
        //{
        //    get;
        //    set;
        //}

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintKensainGeppoListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintKensainGeppoListBusinessLogic : BaseExcelPrintBusinessLogic<IPrintKensainGeppoListBLInput, IPrintKensainGeppoListBLOutput>
    {
        #region プロパティ

        /// <summary>
        /// START_PASTE_ROW_IDX 
        /// </summary>
        private const int START_PASTE_ROW_IDX = 5;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintKensainGeppoListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintKensainGeppoListBusinessLogic()
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
        /// 2014/09/16  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintKensainGeppoListBLOutput SetBook(IPrintKensainGeppoListBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintKensainGeppoListBLOutput output = new PrintKensainGeppoListBLOutput();
            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;
                application.DisplayAlerts = false;
                outputSheet = (Worksheet) book.Sheets["Sheet1"];

                string shishoNo = string.Empty;
                int rowOutputIdx = 0;
                
                //(1)
                CellOutput(outputSheet, 2, 1, string.Format("対象期間：{0}～{1}",
                    new string[]{Utility.DateUtility.ConvertToWareki(input.TaisyoYMFrom, "gyy年MM月分", Utility.DateUtility.GengoKbn.Wareki),
                                Utility.DateUtility.ConvertToWareki(input.TaisyoYMTo, "gyy年MM月分", Utility.DateUtility.GengoKbn.Wareki)
                                }));

                #region output data

                //sort
                KensainGeppoTblDataSet.PrintKensainGeppoListRow[] printRows = (KensainGeppoTblDataSet.PrintKensainGeppoListRow[])input.PrintKensainGeppoListDataTable.Select("", "Total DESC, KadoNissu ASC");

                for (int i = 0; i < printRows.Length; i++)
                {
                    KensainGeppoTblDataSet.PrintKensainGeppoListRow printRow = printRows[i];

                    rowOutputIdx = i + START_PASTE_ROW_IDX;

                    switch (printRow.ShishoCd)
                    {
                        case "1":
                            shishoNo = "③";
                            break;
                        case "2":
                            shishoNo = "②";
                            break;
                        case "3":
                            shishoNo = "①";
                            break;
                        default:
                            // 20141223 habu 
                            shishoNo = string.Empty;
                            break;
                    }

                    //(3)
                    CellOutput(outputSheet, rowOutputIdx, 2, shishoNo + printRow.KensainNm);

                    //(4)
                    CellOutput(outputSheet, rowOutputIdx, 3, printRow.Total);

                    //(5)
                    CellOutput(outputSheet, rowOutputIdx, 4, printRow.KadoNissu);

                    //(7)
                    CellOutput(outputSheet, rowOutputIdx, 7, printRow.YakushokuFlg);
                }

                #endregion
            }
            catch
            {
                throw;
            }
            finally
            {
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
