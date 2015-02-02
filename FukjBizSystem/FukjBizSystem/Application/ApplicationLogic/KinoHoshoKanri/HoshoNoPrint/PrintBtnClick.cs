using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoNoPrint;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoNoPrint
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput, IGetHoshoTorokuTblByKeyBetweenBLInput
    {
        /// <summary>
        /// HoshoTorokuTblDataTable Insert
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblInsertDT { get; set; }

        /// <summary>
        /// HoshoTorokuTblDataTable Update
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblUpdateDT { get; set; }

        /// <summary>
        /// TRUE  : Update data
        /// FALSE : Get data
        /// </summary>
        bool IsUpdate { get; set; }

        /// <summary>
        /// HoshoNoPrintInfoDataTable
        /// </summary>
        HoshoTorokuTblDataSet.HoshoNoPrintInfoDataTable HoshoNoPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IPrintBtnClickALInput
    {
        /// <summary>
        /// HoshoTorokuTblDataTable Insert
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblInsertDT { get; set; }

        /// <summary>
        /// HoshoTorokuTblDataTable Update
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblUpdateDT { get; set; }

        /// <summary>
        /// 保証登録検査機関（開始）, 保証登録年度（開始）, 保証登録年度（終了）
        /// </summary>
        public string KensakikanNendoRenbanFrom { get; set; }

        /// <summary>
        /// 保証登録検査機関（終了）, 保証登録連番（終了）, 保証登録連番（終了）
        /// </summary>
        public string KensakikanNendoRenbanTo { get; set; }

        /// <summary>
        /// TRUE  : Update data
        /// FALSE : Get data
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// HoshoNoPrintInfoDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoNoPrintInfoDataTable HoshoNoPrintInfoDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("HoshoTorokuTblInsertDataTable[{0}],HoshoTorokuTblUpdateDataTable[{1}], IsNewIssues[{1}]", 
                    new string[] { 
                        HoshoTorokuTblInsertDT[0].HoshoTorokuKensakikan,
                        HoshoTorokuTblUpdateDT[0].HoshoTorokuKensakikan,
                        IsUpdate.ToString()
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALOutput : IGetHoshoTorokuTblByKeyBetweenBLOutput
    {
        /// <summary>
        /// Error Message
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALOutput : IPrintBtnClickALOutput
    {
        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// HoshoTorokuTblDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoshoNoPrint：PrintBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintBtnClickApplicationLogic()
        {
            
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  DatNT　  新規作成
        /// 2014/12/21  habu　  added printer name setting
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                if (!input.IsUpdate)
                {
                    #region 保証登録情報の登録済みチェック

                    IGetHoshoTorokuTblByKeyBetweenBLInput checkToInput = new GetHoshoTorokuTblByKeyBetweenBLInput();
                    checkToInput.KensakikanNendoRenbanFrom = input.KensakikanNendoRenbanTo;
                    checkToInput.KensakikanNendoRenbanTo = input.KensakikanNendoRenbanTo;
                    IGetHoshoTorokuTblByKeyBetweenBLOutput checkToOutput = new GetHoshoTorokuTblByKeyBetweenBusinessLogic().Execute(checkToInput);

                    if (checkToOutput.HoshoTorokuTblDT == null || checkToOutput.HoshoTorokuTblDT.Count == 0)
                    {
                        output.ErrMsg = string.Format("該当するデータは登録されていません。\r\n[保証登録番号：{0}-{1}-{2}]",
                                            new string[]{
                                                input.KensakikanNendoRenbanTo.Substring(0, 4),
                                                Utility.DateUtility.ConvertToWareki(input.KensakikanNendoRenbanTo.Substring(4, 4), "yy"),
                                                input.KensakikanNendoRenbanTo.Substring(8, 5),
                                            }
                                        );
                    }

                    IGetHoshoTorokuTblByKeyBetweenBLInput checkFromInput = new GetHoshoTorokuTblByKeyBetweenBLInput();
                    checkFromInput.KensakikanNendoRenbanFrom = input.KensakikanNendoRenbanFrom;
                    checkFromInput.KensakikanNendoRenbanTo = input.KensakikanNendoRenbanFrom;
                    IGetHoshoTorokuTblByKeyBetweenBLOutput checkFromOutput = new GetHoshoTorokuTblByKeyBetweenBusinessLogic().Execute(checkFromInput);

                    if (checkFromOutput.HoshoTorokuTblDT == null || checkFromOutput.HoshoTorokuTblDT.Count == 0)
                    {
                        output.ErrMsg = string.Format("該当するデータは登録されていません。\r\n[保証登録番号：{0}-{1}-{2}]",
                                            new string[]{
                                                input.KensakikanNendoRenbanFrom.Substring(0, 4),
                                                Utility.DateUtility.ConvertToWareki(input.KensakikanNendoRenbanFrom.Substring(4, 4), "yy"),
                                                input.KensakikanNendoRenbanFrom.Substring(8, 5),
                                            }
                                        );
                    }

                    #endregion

                    output.HoshoTorokuTblDT = new GetHoshoTorokuTblByKeyBetweenBusinessLogic().Execute(input).HoshoTorokuTblDT;
                }
                else
                {
                    // 20141221 habu Add get printer name from setting
                    string printer = Boundary.Common.Common.GetPrinterName(Utility.Constants.PrintKbn.PRINT_KBN_KINOHOSHO);

                    // Printer is not installed
                    if (!Boundary.Common.Common.PrinterExist(printer))
                    {
                        Zynas.Framework.Core.Common.Boundary.MessageForm.Show2(Zynas.Framework.Core.Common.Boundary.MessageForm.DispModeType.Error, "印刷先のプリンターが設定されていません。");
                        return output;
                    }

                    try
                    {
                        // トランザクション開始
                        StartTransaction();

                        if (input.HoshoTorokuTblUpdateDT != null && input.HoshoTorokuTblUpdateDT.Count > 0)
                        {
                            IUpdateHoshoTorokuTblBLInput blInput = new UpdateHoshoTorokuTblBLInput();
                            blInput.HoshoTorokuTblDT = CreateDataUpdate(input.HoshoTorokuTblUpdateDT);
                            IUpdateHoshoTorokuTblBLOutput blOutput = new UpdateHoshoTorokuTblBusinessLogic().Execute(blInput);
                        }

                        if (input.HoshoTorokuTblInsertDT != null && input.HoshoTorokuTblInsertDT.Count > 0)
                        {
                            IUpdateHoshoTorokuTblBLInput blInput = new UpdateHoshoTorokuTblBLInput();
                            blInput.HoshoTorokuTblDT = input.HoshoTorokuTblInsertDT;
                            IUpdateHoshoTorokuTblBLOutput blOutput = new UpdateHoshoTorokuTblBusinessLogic().Execute(blInput);
                        }

                        // コミット
                        CompleteTransaction();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        // トランザクション終了
                        EndTransaction();
                    }

                    //ADD HuyTX START
                    IPrintHoshoNoInfoBLInput printBLInput = new PrintHoshoNoInfoBLInput();
                    // 20141221 Add habu added printer name
                    printBLInput.PrinterName = printer;
                    // 20141221 End
                    printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    printBLInput.AfterPrintFlg = true;
                    printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.HoshoNoFormatFile;
                    printBLInput.HoshoNoPrintInfoDataTable = input.HoshoNoPrintInfoDataTable;

                    new PrintHoshoNoInfoBusinessLogic().Execute(printBLInput);

                    //ADD HuyTX END
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable CreateDataUpdate(HoshoTorokuTblDataSet.HoshoTorokuTblDataTable dataTable)
        {
            DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string pcUpdate = Dns.GetHostName();

            HoshoTorokuTblDataSet.HoshoTorokuTblDataTable updateDT = new HoshoTorokuTblDataSet.HoshoTorokuTblDataTable();

            for (int i = 0; i < dataTable.Count; i++)
            {
                IGetHoshoTorokuTblByKeyBLInput blInput = new GetHoshoTorokuTblByKeyBLInput();
                blInput.HoshoTorokuKensakikan = dataTable[i].HoshoTorokuKensakikan;
                blInput.HoshoTorokuNendo = dataTable[i].HoshoTorokuNendo;
                blInput.HoshoTorokuRenban = dataTable[i].HoshoTorokuRenban;
                IGetHoshoTorokuTblByKeyBLOutput blOutput = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(blInput);

                HoshoTorokuTblDataSet.HoshoTorokuTblRow row = blOutput.HoshoTorokuTblDataTable[0];

                // 更新日が違うか？
                if (row.UpdateDt != dataTable[i].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 更新日
                blOutput.HoshoTorokuTblDataTable[0].UpdateDt = now;

                // 更新者
                blOutput.HoshoTorokuTblDataTable[0].UpdateUser = loginUser;

                // 更新端末
                blOutput.HoshoTorokuTblDataTable[0].UpdateTarm = pcUpdate;

                // 設置場所
                blOutput.HoshoTorokuTblDataTable[0].HoshoTorokuSetchibashoAdr = dataTable[i].HoshoTorokuSetchibashoAdr;

                // 補助市町村
                blOutput.HoshoTorokuTblDataTable[0].HoshoTorokuHojoShichosonCd = dataTable[i].HoshoTorokuHojoShichosonCd;

                // 浄化槽検査機関
                blOutput.HoshoTorokuTblDataTable[0].HoshoTorokuJokasoKensakikan = dataTable[i].HoshoTorokuJokasoKensakikan;

                updateDT.ImportRow(blOutput.HoshoTorokuTblDataTable[0]);

            }

            return updateDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
