using System;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Core.Common.BusinessLogic.Print;
using Zynas.Framework.Core.Common.BusinessLogic.Print.MSExcel;

namespace FrameworkTest
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintTestBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintTestBLInput : IBaseExcelPrintBLInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintTestBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintTestBLInput : BaseExcelPrintBLInputImpl, IPrintTestBLInput
    {

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintTestBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintTestBLOutput : IBaseExcelPrintBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintTestBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintTestBLOutput : BaseExcelPrintBLOutputImpl, IPrintTestBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintTestBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintTestBusinessLogic : BaseExcelPrintBusinessLogic<IPrintTestBLInput, IPrintTestBLOutput>
    {
        #region プロパティ

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintTestBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintTestBusinessLogic()
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
        /// 2014/11/14  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IPrintTestBLOutput SetBook(IPrintTestBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IPrintTestBLOutput output = new PrintTestBLOutput();

            Worksheet outputSheet = null;

            try
            {
                #region データ定義

                System.Data.DataTable printData = new System.Data.DataTable();

                printData.Columns.Add("OutputUserNm", typeof(string));

                printData.Columns.Add("Cd", typeof(string));
                printData.Columns.Add("Nm", typeof(string));

                //printData.Columns.Add("SendToGyoshaNm", typeof(string));

                for (int i = 0; i < 120; i++)
                {
                    DataRow row = printData.NewRow();

                    row["OutputUserNm"] = "ユーザ1";

                    row["Cd"] = (i + 1).ToString("000");
                    row["Nm"] = "Item" + (i + 1);

                    printData.Rows.Add(row);
                }

                #endregion

                PrintHelper printObj = new PrintHelper();
                printObj.excel = new MSExcelBind(book);
                printObj.DuplicateHeader = false;
                printObj.templateSheetName = "Sheet1";

                #region ヘッダ部定義

                BaseSection header = new BaseSection();

                header.sectionRowOrigin = 0;
                header.sectionRowCnt = 4;

                header.SetFixData("Output User(Header Fixed)", 2, 2);

                printObj.SetHeaderSection(header);
                printObj.SetHeaderData(printData);

                #endregion

                #region 明細部定義

                BaseSection detail = new BaseSection(2);

                detail.sectionRowOrigin = 4;
                detail.sectionRowCnt = 40;

                detail.SetNoCol(1, 0, 1);

                detail.SetMapping("Cd", 4);

                detail.OutputRow += delegate(ExcelBind excel, DataRow row, int rowIdx)
                {
                    string val = "Custom Output";

                    excel.CellOutput(rowIdx, 5, val);
                    // TODO バーコード出力方法検討(バーコードコントロールの実行時コピーが必要)
                };

                printObj.SetDetailSection(detail);
                printObj.SetDetailData(printData);

                #endregion

                // 出力実行
                printObj.Output();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (outputSheet != null)
                {
                    Marshal.ReleaseComObject(outputSheet);
                }
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
