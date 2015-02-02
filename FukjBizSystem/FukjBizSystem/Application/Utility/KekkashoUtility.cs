using System.IO;
using FukjBizSystem.Application.BusinessLogic.KensaKekka.KensaKekkaList;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Generic.BusinessLogic;

namespace FukjBizSystem.Application.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class KekkashoUtility
    {
        public enum KekkashoOutputRetCode
        {
            /// <summary>
            /// 0:正常
            /// </summary>
            Success = 0,
            /// <summary>
            /// 1:パラメータ不足
            /// </summary>
            ParameterInvalid = 1,
            /// <summary>
            /// 2:対象データなし
            /// </summary>
            NoData = 2,
            /// <summary>
            /// 3:保存先設定なし
            /// </summary>
            NoSaveTargetConfig = 3,
            /// <summary>
            /// 4:サーバーフォルダなし
            /// </summary>
            NoServerSaveTargetPath = 4,
            /// <summary>
            /// 9:ファイル作成失敗
            /// </summary>
            FileCreateFailure = 9,
        }

        private const int PRINT_KBN_PREVIEW = 0;
        private const int PRINT_KBN_OUTPUT_BEGIN = 1;

        private const int FORMAT_KEKKASHO = 0;
        private const int FORMAT_SUISHITSU_KEKKASHO = 1;

        #region KekkashoOutput
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaKbnStr">KensaIraiTbl Key(HoteiKbn)</param>
        /// <param name="hokenjoCdStr">KensaIraiTbl Key</param>
        /// <param name="nendoStr">KensaIraiTbl Key</param>
        /// <param name="renbanStr">KensaIraiTbl Key</param>
        /// <param name="printKbn">0:preview only, > 1:print n copies</param>
        /// <param name="svLcKbn">1:local,0:server</param>
        /// <param name="fdMkekbn">0:do upload output to server1:don't upload</param>
        /// <param name="edabanKbn">> 1:backup previous server output to server backup directory</param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  habu        新規作成
        /// 2014/11/11  habu        Added edabanKbn(interface only)
        /// 2014/11/28  habu        Added edabanKbn(implements)
        /// 2014/11/28  habu        Added KensaKekkaSho(not Suishitsu)
        /// 2014/12/09  habu        Fixed whole over
        /// </history>
        public static int KekkashoOutput(string kensaKbnStr, string hokenjoCdStr, string nendoStr, string renbanStr, int printKbn, int svLcKbn, int fdMkekbn, int edabanKbn)
        {
            const int FD_MK_TEMPORARY = 0;
            const int FD_MK_UPLOAD = 1;

            const string EXT_PDF = ".pdf";

            // 引数が不足の場合は終了
            if (string.IsNullOrEmpty(kensaKbnStr) || string.IsNullOrEmpty(hokenjoCdStr) || string.IsNullOrEmpty(nendoStr) || string.IsNullOrEmpty(renbanStr))
            {
                return (int)KekkashoOutputRetCode.ParameterInvalid;
            }

            // 引数が不正の場合は終了
            if (fdMkekbn != FD_MK_TEMPORARY && fdMkekbn != FD_MK_UPLOAD)
            {
                return (int)KekkashoOutputRetCode.ParameterInvalid;
            }

            // 引数が不正の場合は終了
            if (printKbn < PRINT_KBN_PREVIEW)
            {
                return (int)KekkashoOutputRetCode.ParameterInvalid;
            }

            #region 検査依頼テーブル取得
            KensaIraiTblDataSet.KensaIraiTblDataTable iraiTbl = new KensaIraiTblDataSet.KensaIraiTblDataTable();
            IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
            input.DataTableType = typeof(KensaIraiTblDataSet.KensaIraiTblDataTable);
            input.TableAdapterType = typeof(KensaIraiTblTableAdapter);
            input.Query.AddEqualCond(iraiTbl.KensaIraiHoteiKbnColumn.ColumnName, kensaKbnStr);
            input.Query.AddEqualCond(iraiTbl.KensaIraiHokenjoCdColumn.ColumnName, hokenjoCdStr);
            input.Query.AddEqualCond(iraiTbl.KensaIraiNendoColumn.ColumnName, nendoStr);
            input.Query.AddEqualCond(iraiTbl.KensaIraiRenbanColumn.ColumnName, renbanStr);

            IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);
            #endregion

            iraiTbl = (KensaIraiTblDataSet.KensaIraiTblDataTable)output.GetDataTable;

            // データがない場合は処理終了
            if (iraiTbl.Count == 0)
            {
                return (int)KekkashoOutputRetCode.NoData;
            }

            // 保存先フォルダ取得
            // ローカル保存フォルダ取得
            string localDestDir = SharedFolderUtility.GetKensaIraiKeyFolder(
                    Constants.ConstKbnConstanst.CONST_KBN_045
                    , Constants.ConstRenbanConstanst.CONST_RENBAN_001
                    , kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, 1, fdMkekbn);

            // サーバー保存フォルダ取得
            string serverDestDir = SharedFolderUtility.GetKensaIraiKeyFolder(
                    Constants.ConstKbnConstanst.CONST_KBN_045
                    , Constants.ConstRenbanConstanst.CONST_RENBAN_001
                    , kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, 0, fdMkekbn);

            // 保存先が取得できない場合は終了
            if (string.IsNullOrEmpty(localDestDir))
            {
                return (int)KekkashoOutputRetCode.NoSaveTargetConfig;
            }
            if (string.IsNullOrEmpty(serverDestDir))
            {
                return (int)KekkashoOutputRetCode.NoSaveTargetConfig;
            }

            // 保存ファイル名生成
            string kensaFileName =
                string.Join("_"
                , new string[] { kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr })
                + EXT_PDF;

            // 保存先ファイルパス生成
            string localKensaFilePath = Path.Combine(localDestDir, kensaFileName);
            string serverKensaFilePath = Path.Combine(serverDestDir, kensaFileName);

            SharedFolderUtility.Connect();

            bool serverFileExists = File.Exists(serverKensaFilePath);

            SharedFolderUtility.Disconnect();

            // 帳票種別判定
            int formatType = 0;
            if (iraiTbl[0].KensaIraiHoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU
                        && iraiTbl[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_NONE)
            {
                formatType = FORMAT_SUISHITSU_KEKKASHO;
            }
            else
            {
                formatType = FORMAT_KEKKASHO;
            }

            // プレビュー指定の場合
            if (printKbn == PRINT_KBN_PREVIEW)
            {
                // サーバーファイルが存在する場合、ローカルにコピー・表示
                if (serverFileExists)
                {
                    SharedFolderUtility.Connect();

                    // サーバーの出力ファイルをダウンロード
                    SharedFolderUtility.DownloadFile(localKensaFilePath, serverKensaFilePath);

                    // サーバー共有フォルダ切断
                    SharedFolderUtility.Disconnect();

                    // PDFを表示する
                    PDFUtility.DisplayPDF(localKensaFilePath);

                    return (int)KekkashoOutputRetCode.Success;
                }
                // サーバーファイルが存在しない場合は、ローカルに出力・表示
                else
                {
                    // PDFファイル出力
                    int outputResult
                        = OutputKekkashoFile(
                        kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr
                        , formatType
                        , printKbn
                        , localKensaFilePath);

                    if (outputResult != (int)KekkashoOutputRetCode.FileCreateFailure)
                    {
                        // PDFを表示する
                        PDFUtility.DisplayPDF(localKensaFilePath);
                    }

                    return outputResult;
                }
            }
            else
            {
                // PDFファイル出力
                int outputResult
                    = OutputKekkashoFile(
                    kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr
                    , formatType
                    , printKbn
                    , localKensaFilePath);

                // 出力処理呼び出し時に、印刷も実行される

                // ファイル出力に失敗した場合は処理中断(バックアップは行わない)
                if (outputResult == (int)KekkashoOutputRetCode.FileCreateFailure)
                {
                    return outputResult;
                }

                if (fdMkekbn == FD_MK_TEMPORARY)
                {
                    // 一時ファイル指定(サーバーアップロード無し)の場合は、出力ファイルを印刷し、そのまま終了する

                    return outputResult;
                }
                else
                {
                    // サーバー共有フォルダ接続
                    SharedFolderUtility.Connect();

                    // 枝番指定の場合は、サーバーファイルをバックアップする
                    if (edabanKbn > 0 && serverFileExists)
                    {
                        // サーバー保存フォルダ取得
                        string serverBackDir = SharedFolderUtility.GetKensaIraiKeyFolder(
                             Constants.ConstKbnConstanst.CONST_KBN_045
                             , Constants.ConstRenbanConstanst.CONST_RENBAN_002
                             , kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, 0, fdMkekbn);

                        if (string.IsNullOrEmpty(serverBackDir))
                        {
                            return (int)KekkashoOutputRetCode.NoSaveTargetConfig;
                        }

                        string backFileName = string.Join("_"
                        , new string[] { kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, (edabanKbn - 1).ToString() })
                        + EXT_PDF;

                        string backDestPath = Path.Combine(serverBackDir, backFileName);

                        // サーバーに出力ファイルをバックアップ
                        SharedFolderUtility.UploadFile(serverKensaFilePath, backDestPath);
                    }
                    
                    // サーバーに出力ファイルをアップロード
                    SharedFolderUtility.UploadFile(localKensaFilePath, serverKensaFilePath);

                    // サーバー共有フォルダ切断
                    SharedFolderUtility.Disconnect();

                    return outputResult;
                }
            }

            #region to be removed
            //// プレビュー指定かつ出力済みの場合はファイルを表示して処理終了(正常終了)
            //if (printKbn == PRINT_KBN_PREVIEW && serverFileExists)
            //{
            //    // PDFを表示する
            //    PDFUtility.DisplayPDF(serverKensaFilePath);

            //    return (int)KekkashoOutputRetCode.Success;
            //}
            //else
            //{
            //    // 枝番 > 0 かつファイルが存在した場合
            //    if (edabanKbn > 0 && serverFileExists)
            //    {
            //        // バックアップフォルダ取得
            //        string backPath;

            //        if (svLcKbn != 1)
            //        {
            //            // ローカル保存フォルダ取得
            //            backPath = SharedFolderUtility.GetKensaIraiKeyFolder(
            //                 Constants.ConstKbnConstanst.CONST_KBN_045
            //                 , Constants.ConstRenbanConstanst.CONST_RENBAN_002
            //                 , kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, 1, fdMkekbn);
            //        }
            //        else
            //        {
            //            // サーバー保存フォルダ取得
            //            backPath = SharedFolderUtility.GetKensaIraiKeyFolder(
            //                 Constants.ConstKbnConstanst.CONST_KBN_045
            //                 , Constants.ConstRenbanConstanst.CONST_RENBAN_002
            //                 , kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, 0, fdMkekbn);
            //        }

            //        if (string.IsNullOrEmpty(backPath))
            //        {
            //            return (int)KekkashoOutputRetCode.NoSaveTargetConfig;
            //        }

            //        string backFileName = string.Join("_"
            //        , new string[] { kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, (edabanKbn - 1).ToString() })
            //        + EXT_PDF;

            //        string backDestPath = Path.Combine(backPath, backFileName);

            //        // ファイルバックアップ(移動)
            //        File.Move(serverKensaFilePath, backDestPath);

            //        // 移動したので、存在しないものとして扱う(再度出力する)
            //        serverFileExists = false;
            //    }

            //    // 印刷指定時、又はプレビュー指定かつ未出力の場合出力処理実行
            //    if (printKbn >= PRINT_KBN_OUTPUT_BEGIN || (printKbn == PRINT_KBN_PREVIEW && !serverFileExists))
            //    {
            //        // 帳票出力種別判定
            //        if (iraiTbl[0].KensaIraiHoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU
            //            && iraiTbl[0].KensaIraiScreeningKbn == Constants.ScreeningKbnConstant.SCREENING_KBN_NONE)
            //        {
            //            #region 水質検査結果書出力
            //            try
            //            {
            //                // 水質検査結果書出力
            //                IPrintSuishitsuKensaKekkaShoBLOutput printOutput;
            //                PrintSuishitsuKensaKekkaShoBusinessLogic printBl = new PrintSuishitsuKensaKekkaShoBusinessLogic();
            //                IPrintSuishitsuKensaKekkaShoBLInput printInput = new PrintSuishitsuKensaKekkaShoBLInput();
            //                printInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
            //                printInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.SuishitsuKensaKekkaShoFormatFile);
            //                // 1:普通紙,2:専用紙
            //                printInput.InsatsuKbn = "1";

            //                // Get print data
            //                KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable template = new KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable();
            //                IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
            //                getInput.DataTableType = typeof(KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable);
            //                getInput.TableAdapterType = typeof(SuishitsuKensaKekkaInfoTableAdapter);
            //                getInput.Query.AddEqualCond(template.KensaIraiHoteiKbnColumn.ColumnName, kensaKbnStr);
            //                getInput.Query.AddEqualCond(template.KensaIraiHokenjoCdColumn.ColumnName, hokenjoCdStr);
            //                getInput.Query.AddEqualCond(template.KensaIraiNendoColumn.ColumnName, nendoStr);
            //                getInput.Query.AddEqualCond(template.KensaIraiRenbanColumn.ColumnName, renbanStr);

            //                IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);

            //                printInput.SuishitsuKensaKekkaInfoDataTable = (KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable)getOutput.GetDataTable;

            //                // 20141128 habu not to use GetAll
            //                //ADD_20141111_HuyTX Start
            //                //create DataTable for print template 042_水質検査結果書.xlsx
            //                // printInput.SuishitsuKensaKekkaInfoDataTable = CreateSuishitsuKensaKekka(kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr);
            //                //ADD_20141111_HuyTX End

            //                if (printKbn == PRINT_KBN_PREVIEW)
            //                {
            //                    printInput.AfterDispFlg = false;
            //                    printInput.AfterPrintFlg = false;
            //                    printInput.SavePath = serverKensaFilePath;
            //                    printInput.SaveFileMode = Zynas.Framework.Utility.SaveFileMode.Pdf;

            //                    printOutput = printBl.Execute(printInput);

            //                    // PDFを表示する
            //                    PDFUtility.DisplayPDF(printOutput.SavePath);
            //                }
            //                else
            //                {
            //                    printInput.AfterDispFlg = false;
            //                    printInput.AfterPrintFlg = true;
            //                    printInput.SaveFileMode = Zynas.Framework.Utility.SaveFileMode.Pdf;
            //                    // サーバー保存時は出力先を指定せず、作業用ディレクトリに一旦出力する

            //                    printInput.CopyCount = printKbn;
            //                    printInput.Collate = true;

            //                    printOutput = printBl.Execute(printInput);

            //                    // サーバー共有フォルダ接続
            //                    SharedFolderUtility.Connect();

            //                    // サーバーに出力ファイルをアップロード
            //                    SharedFolderUtility.UploadFile(printOutput.SavePath, serverKensaFilePath);

            //                    // サーバー共有フォルダ切断
            //                    SharedFolderUtility.Disconnect();
            //                }

            //                return (int)KekkashoOutputRetCode.Success;
            //            }
            //            catch
            //            {
            //                return (int)KekkashoOutputRetCode.FileCreateFailure;
            //            }
            //            #endregion
            //        }
            //        else
            //        {
            //            #region 検査結果書出力
            //            try
            //            {
            //                // 検査結果書出力
            //                IPrintKensaKekkaShoBLOutput printOutput;
            //                PrintKensaKekkaShoBusinessLogic printBl = new PrintKensaKekkaShoBusinessLogic();
            //                IPrintKensaKekkaShoBLInput printInput = new PrintKensaKekkaShoBLInput();
            //                printInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
            //                //20141201_HuyTX FormatPath incorrect
            //                //printInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.SuishitsuKensaKekkaShoFormatFile);
            //                printInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.KensaKekkashoFormatFile);
            //                //20141201_HuyTX_End

            //                // Get print data
            //                //KensaKekkaTblDataSet.KensaKekkaShoInfoDataTable template = new KensaKekkaTblDataSet.KensaKekkaShoInfoDataTable();
            //                //IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
            //                //getInput.DataTableType = typeof(KensaKekkaTblDataSet.KensaKekkaShoInfoDataTable);
            //                //getInput.TableAdapterType = typeof(KensaKekkaShoInfoTableAdapter);
            //                //getInput.Query.AddEqualCond(template.KensaIraiHoteiKbnColumn.ColumnName, kensaKbnStr);
            //                //getInput.Query.AddEqualCond(template.KensaIraiHokenjoCdColumn.ColumnName, hokenjoCdStr);
            //                //getInput.Query.AddEqualCond(template.KensaIraiNendoColumn.ColumnName, nendoStr);
            //                //getInput.Query.AddEqualCond(template.KensaIraiRenbanColumn.ColumnName, renbanStr);

            //                //IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);

            //                //printInput.KensaKekkaShoInfoDataTable = (KensaKekkaTblDataSet.KensaKekkaShoInfoDataTable)getOutput.GetDataTable;
            //                printInput.KensaIraiHoteiKbn = kensaKbnStr;
            //                printInput.KensaIraiHokenjoCd = hokenjoCdStr;
            //                printInput.KensaIraiNendo = nendoStr;
            //                printInput.KensaIraiRenban = renbanStr;

            //                if (printKbn == PRINT_KBN_PREVIEW)
            //                {
            //                    printInput.AfterDispFlg = false;
            //                    printInput.AfterPrintFlg = false;
            //                    printInput.SavePath = serverKensaFilePath;
            //                    printInput.SaveFileMode = Zynas.Framework.Utility.SaveFileMode.Pdf;

            //                    printOutput = printBl.Execute(printInput);

            //                    // 20141204 habu Add Fixed first preview mode doesn't be preview
            //                    // PDFを表示する
            //                    PDFUtility.DisplayPDF(printOutput.SavePath);
            //                }
            //                else
            //                {
            //                    printInput.AfterDispFlg = false;
            //                    printInput.AfterPrintFlg = true;
            //                    printInput.SaveFileMode = Zynas.Framework.Utility.SaveFileMode.Pdf;
            //                    // サーバー保存時は出力先を指定せず、作業用ディレクトリに一旦出力する

            //                    printInput.CopyCount = printKbn;
            //                    printInput.Collate = true;

            //                    printOutput = printBl.Execute(printInput);

            //                    // サーバー共有フォルダ接続
            //                    SharedFolderUtility.Connect();

            //                    // サーバーに出力ファイルをアップロード
            //                    SharedFolderUtility.UploadFile(printOutput.SavePath, serverKensaFilePath);

            //                    // サーバー共有フォルダ切断
            //                    SharedFolderUtility.Disconnect();
            //                }

            //                return (int)KekkashoOutputRetCode.Success;
            //            }
            //            catch
            //            {
            //                return (int)KekkashoOutputRetCode.FileCreateFailure;
            //            }
            //            #endregion
            //        }
            //    }
            //    else { return (int)KekkashoOutputRetCode.FileCreateFailure; }
            //}
            #endregion
        }
        #endregion

        #region KekkashoOutput
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaKbnStr"></param>
        /// <param name="hokenjoCdStr"></param>
        /// <param name="nendoStr"></param>
        /// <param name="renbanStr"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  habu        新規作成
        /// 2014/12/02  habu        added fdMkKbn
        /// </history>
        public static int KekkashoOutput(string kensaKbnStr, string hokenjoCdStr, string nendoStr, string renbanStr)
        {
            return KekkashoOutput(kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, 0, 0, 1, 0);
        }
        #endregion

        #region OutputKekkashoFile
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaKbnStr"></param>
        /// <param name="hokenjoCdStr"></param>
        /// <param name="nendoStr"></param>
        /// <param name="renbanStr"></param>
        /// <param name="formatType"></param>
        /// <param name="printKbn"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09  habu        新規作成
        /// </history>
        private static int OutputKekkashoFile(string kensaKbnStr, string hokenjoCdStr, string nendoStr, string renbanStr, int formatType, int printKbn, string outputPath)
        {
            if (formatType == FORMAT_SUISHITSU_KEKKASHO)
            {
                #region 水質検査結果書出力
                try
                {
                    // 水質検査結果書出力
                    IPrintSuishitsuKensaKekkaShoBLOutput printOutput;
                    PrintSuishitsuKensaKekkaShoBusinessLogic printBl = new PrintSuishitsuKensaKekkaShoBusinessLogic();
                    IPrintSuishitsuKensaKekkaShoBLInput printInput = new PrintSuishitsuKensaKekkaShoBLInput();
                    printInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    printInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.SuishitsuKensaKekkaShoFormatFile);
                    // 1:普通紙,2:専用紙
                    printInput.InsatsuKbn = "1";

                    // Get print data
                    KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable template = new KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable();
                    IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
                    getInput.DataTableType = typeof(KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable);
                    getInput.TableAdapterType = typeof(SuishitsuKensaKekkaInfoTableAdapter);
                    getInput.Query.AddEqualCond(template.KensaIraiHoteiKbnColumn.ColumnName, kensaKbnStr);
                    getInput.Query.AddEqualCond(template.KensaIraiHokenjoCdColumn.ColumnName, hokenjoCdStr);
                    getInput.Query.AddEqualCond(template.KensaIraiNendoColumn.ColumnName, nendoStr);
                    getInput.Query.AddEqualCond(template.KensaIraiRenbanColumn.ColumnName, renbanStr);

                    IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);

                    printInput.SuishitsuKensaKekkaInfoDataTable = (KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable)getOutput.GetDataTable;

                    printInput.AfterDispFlg = false;
                    printInput.SavePath = outputPath;
                    printInput.SaveFileMode = Zynas.Framework.Utility.SaveFileMode.Pdf;

                    if (printKbn == PRINT_KBN_PREVIEW)
                    {
                        printInput.AfterPrintFlg = false;

                        printOutput = printBl.Execute(printInput);
                    }
                    else
                    {
                        printInput.AfterPrintFlg = true;

                        printInput.CopyCount = printKbn;
                        printInput.Collate = true;

                        printOutput = printBl.Execute(printInput);
                    }

                    return (int)KekkashoOutputRetCode.Success;
                }
                catch
                {
                    return (int)KekkashoOutputRetCode.FileCreateFailure;
                }
                #endregion
            }
            else
            {
                #region 検査結果書出力
                try
                {
                    // 検査結果書出力
                    IPrintKensaKekkaShoBLOutput printOutput;
                    PrintKensaKekkaShoBusinessLogic printBl = new PrintKensaKekkaShoBusinessLogic();
                    IPrintKensaKekkaShoBLInput printInput = new PrintKensaKekkaShoBLInput();
                    printInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    printInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.KensaKekkashoFormatFile);

                    printInput.KensaIraiHoteiKbn = kensaKbnStr;
                    printInput.KensaIraiHokenjoCd = hokenjoCdStr;
                    printInput.KensaIraiNendo = nendoStr;
                    printInput.KensaIraiRenban = renbanStr;

                    printInput.AfterDispFlg = false;
                    printInput.SavePath = outputPath;
                    printInput.SaveFileMode = Zynas.Framework.Utility.SaveFileMode.Pdf;

                    if (printKbn == PRINT_KBN_PREVIEW)
                    {
                        printInput.AfterPrintFlg = false;

                        printOutput = printBl.Execute(printInput);

                    }
                    else
                    {
                        printInput.AfterPrintFlg = true;

                        printInput.CopyCount = printKbn;
                        printInput.Collate = true;

                        printOutput = printBl.Execute(printInput);
                    }

                    return (int)KekkashoOutputRetCode.Success;
                }
                catch
                {
                    return (int)KekkashoOutputRetCode.FileCreateFailure;
                }
                #endregion
            }
        }
        #endregion

    }
}
