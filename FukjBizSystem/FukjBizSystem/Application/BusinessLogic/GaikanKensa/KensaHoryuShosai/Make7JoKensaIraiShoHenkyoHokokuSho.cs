using System.Runtime.InteropServices;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.BusinessLogic;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IMake7JoKensaIraiShoHenkyoHokokuShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IMake7JoKensaIraiShoHenkyoHokokuShoBLInput : IBaseExcelPrintBLInput
    {
        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }

        /// <summary>
        /// 担当検査員(7)
        /// </summary>
        string TantoKensain { get; set; }

        /// <summary>
        /// 起票者/所属支所(14)
        /// </summary>
        string ShozokuShisyo { get; set; }

        /// <summary>
        /// 起票者/所属部署(15)
        /// </summary>
        string ShozokuBusho { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Make7JoKensaIraiShoHenkyoHokokuShoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Make7JoKensaIraiShoHenkyoHokokuShoBLInput : BaseExcelPrintBLInputImpl, IMake7JoKensaIraiShoHenkyoHokokuShoBLInput
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

        ///// <summary>
        ///// 協会No
        ///// </summary>
        //public string KyokaiNo { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }

        /// <summary>
        /// 担当検査員(7)
        /// </summary>
        public string TantoKensain { get; set; }

        /// <summary>
        /// 起票者/所属支所(14)
        /// </summary>
        public string ShozokuShisyo { get; set; }

        /// <summary>
        /// 起票者/所属部署(15)
        /// </summary>
        public string ShozokuBusho { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IMake7JoKensaIraiShoHenkyoHokokuShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IMake7JoKensaIraiShoHenkyoHokokuShoBLOutput : IBaseExcelPrintBLOutput
    {
        /// <summary>
        /// FALSE: File created successfully, otherwise failed!
        /// </summary>
        bool FileCrash { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Make7JoKensaIraiShoHenkyoHokokuShoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// 2014/10/27　habu　　    Added PrintExcelBLI/O Default Implement
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Make7JoKensaIraiShoHenkyoHokokuShoBLOutput : BaseExcelPrintBLOutputImpl, IMake7JoKensaIraiShoHenkyoHokokuShoBLOutput
    {
        ///// <summary>
        ///// 保存パス
        ///// </summary>
        //public string SavePath { get; set; }

        /// <summary>
        /// FALSE: File created successfully, otherwise failed!
        /// </summary>
        public bool FileCrash { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Make7JoKensaIraiShoHenkyoHokokuShoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Make7JoKensaIraiShoHenkyoHokokuShoBusinessLogic : BaseExcelPrintBusinessLogic<IMake7JoKensaIraiShoHenkyoHokokuShoBLInput, IMake7JoKensaIraiShoHenkyoHokokuShoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Make7JoKensaIraiShoHenkyoHokokuShoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Make7JoKensaIraiShoHenkyoHokokuShoBusinessLogic()
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
        /// 2014/09/09　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override IMake7JoKensaIraiShoHenkyoHokokuShoBLOutput SetBook(IMake7JoKensaIraiShoHenkyoHokokuShoBLInput input, Microsoft.Office.Interop.Excel.Workbook book)
        {
            IMake7JoKensaIraiShoHenkyoHokokuShoBLOutput output = new Make7JoKensaIraiShoHenkyoHokokuShoBLOutput();

            Microsoft.Office.Interop.Excel.Application application = null;
            Worksheet outputSheet = null;

            try
            {
                application = book.Application;

                // Prevents from display messages of Excel
                application.DisplayAlerts = false;

                // Set output sheet to current active sheet
                outputSheet = (Worksheet)book.Sheets["Sheet1"];
                outputSheet.Name = "7条検査依頼書現況報告書";

                // Prepare the print data
                ISelectKensaIraiShoHenkyoHokokuShoByKyokaiNoDAInput daInput = new SelectKensaIraiShoHenkyoHokokuShoByKyokaiNoDAInput();
                daInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                daInput.KensaIraiNendo = input.KensaIraiNendo;
                daInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectKensaIraiShoHenkyoHokokuShoByKyokaiNoDAOutput daOutput = new SelectKensaIraiShoHenkyoHokokuShoByKyokaiNoDataAccess().Execute(daInput);
                KensaHoryuDataSet.KensaIraiShoHenkyoHokokuShoRow row = daOutput.KensaIraiShoHenkyoHokokuShoDataTable[0];

                // 支所名 + 部署名(1)
                // 20141209 Added space
                CellOutput(outputSheet, 6, 7, input.ShozokuShisyo + " " + input.ShozokuBusho);
                //CellOutput(outputSheet, 6, 7, string.Concat(input.ShozokuShisyo, input.ShozokuBusho));

                // 担当検査員(2)
                CellOutput(outputSheet, 7, 7, input.TantoKensain);

                // 設置者名（漢字）(3)
                CellOutput(outputSheet, 8, 7, row.KensaIraiSetchishaNm);

                // 20141209 〒、BKでなく、郵便、銀行を表示する様に変更
                // 定数名称(入金先) (4)
                CellOutput(outputSheet, 9, 7, row.ConstValue);
                //CellOutput(outputSheet, 9, 7, row.ConstNm);

                // 入金日付(5)
                CellOutput(outputSheet, 10, 7, row.MaeukekinNyukinDt);

                // System date(6)
                CellOutput(outputSheet, 6, 23, row.SystemDate);

                // 依頼年/依頼月/依頼日(7)
                CellOutput(outputSheet, 7, 23, row.KensaIraiNenTsukiBi == "年月日" ? "年    月   日" : row.KensaIraiNenTsukiBi);

                // 設置者（電話番号）(8)
                CellOutput(outputSheet, 8, 23, row.KensaIraiSetchishaTelNo);

                // 前受照合番号１+ 前受照合番号２(9)
                CellOutput(outputSheet, 9, 22, row.MaeukekinSyogoNo);

                // 20141209 habu Mod 検査依頼番号に変更
                // 検査依頼保健所コード/検査依頼年度/検査依頼連番(10)
                CellOutput(outputSheet, 10, 22, row.KensaIraiKyokai);
                // 浄化槽保健所コード/浄化槽台帳登録年度/浄化槽台帳連番(10)
                //CellOutput(outputSheet, 10, 22, row.JokasoKyokai);
            }
            catch
            {
                // Create file failed!
                output.FileCrash = true;
            }
            finally
            {
                #region オブジェクトを解放
                if (application != null) { Marshal.ReleaseComObject(application); }
                if (outputSheet != null) { Marshal.ReleaseComObject(outputSheet); }
                #endregion
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
