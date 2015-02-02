using System;
using System.IO;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuShikenKoumokuMstShosai;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoOutput;
using FukjBizSystem.Application.DataAccess.SuishitsuShikenKoumokuMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.YachoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// The path selected by the user.
        /// </summary>
        string SelectedPath { get; set; }

        /// <summary>
        /// 水質検査依頼番号の最小値-水質検査依頼番号の最大値
        /// </summary>
        string IraiNoFolder { get; set; }

        /// <summary>
        /// 外観/水質/計量証明
        /// </summary>
        TypeSearch TypeSearch { get; set; }

        /// <summary>
        /// 当日
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// YachoOutputKensaListDataTable
        /// </summary>
        KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALInput : IOutputBtnClickALInput
    {
        /// <summary>
        /// The path selected by the user.
        /// </summary>
        public string SelectedPath { get; set; }

        /// <summary>
        /// 水質検査依頼番号の最小値-水質検査依頼番号の最大値
        /// </summary>
        public string IraiNoFolder { get; set; }

        /// <summary>
        /// 外観/水質/計量証明
        /// </summary>
        public TypeSearch TypeSearch { get; set; }

        /// <summary>
        /// 当日
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// YachoOutputKensaListDataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable PrintTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("当日[{0}]", SystemDt);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALOutput
    {
        /// <summary>
        /// File does not exist
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALOutput : IOutputBtnClickALOutput
    {
        /// <summary>
        /// File does not exist
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　AnhNV　　    新規作成
    /// 2014/12/19　小松　　    再作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickApplicationLogic : BaseApplicationLogic<IOutputBtnClickALInput, IOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "YachoOutput：OutputBtnClick";

        /// <summary>
        /// File extension
        /// </summary>
        private const string FILE_EXT = ".xlsx";

        /// <summary>
        /// Print file names
        /// </summary>
        private const string FILE_001 = "残留塩素濃度";
        private const string FILE_002 = "NO2-N（亜硝酸性窒素）（定性）";
        private const string FILE_003 = "NO3-N（硝酸性窒素）（定性）";
        private const string FILE_004 = "NO2-N（亜硝酸性窒素）（定量）";
        private const string FILE_005 = "NO3-N（硝酸性窒素）（定量）";
        private const string FILE_006 = "COD（化学的酸素要求量）";
        private const string FILE_007 = "大腸菌群数";
        private const string FILE_008 = "T-N（全窒素）";
        private const string FILE_009 = "T-P（全りん）";
        private const string FILE_010 = "ヘキサン抽出物質";
        private const string FILE_011 = "ABS（陰イオン界面活性剤）";
        private const string FILE_012 = "外観";
        private const string FILE_013 = "臭気";
        private const string FILE_014 = "りん酸イオン";
        private const string FILE_015 = "色度";

        /// <summary>
        /// Limit number of row for each files
        /// </summary>
        //private const int MAX_ROW_FILE_001 = 1;
        //private const int MAX_ROW_FILE_002 = 1;
        //private const int MAX_ROW_FILE_003 = 1;
        //private const int MAX_ROW_FILE_004 = 1;
        //private const int MAX_ROW_FILE_005 = 1;
        //private const int MAX_ROW_FILE_006 = 1;
        //private const int MAX_ROW_FILE_007 = 1;
        //private const int MAX_ROW_FILE_008 = 1;
        //private const int MAX_ROW_FILE_009 = 1;
        //private const int MAX_ROW_FILE_010 = 1;
        //private const int MAX_ROW_FILE_011 = 1;
        //private const int MAX_ROW_FILE_012 = 1;
        //private const int MAX_ROW_FILE_013 = 1;
        //private const int MAX_ROW_FILE_014 = 1;
        //private const int MAX_ROW_FILE_015 = 1;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： OutputBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public OutputBtnClickApplicationLogic()
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
        /// 2014/12/05　AnhNV　　    新規作成
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
        /// 2014/12/05　AnhNV　　    新規作成
        /// 2014/12/19　小松　　    再作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IOutputBtnClickALOutput Execute(IOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IOutputBtnClickALOutput output = new OutputBtnClickALOutput();

            try
            {
                // Full path
                string localFilePath = Path.Combine(input.SelectedPath, "野帳出力");
                if (input.TypeSearch == TypeSearch.GaikanKensa)
                {
                    localFilePath = Path.Combine(localFilePath, "外観検査");
                }
                else if (input.TypeSearch == TypeSearch.SuishitsuKensa)
                {
                    localFilePath = Path.Combine(localFilePath, "水質検査");
                }
                else
                {
                    localFilePath = Path.Combine(localFilePath, "計量証明");
                }
                localFilePath = Path.Combine(localFilePath, input.SystemDt.ToString("yyyyMMdd"));

                // Server folder
                string serverFolder = Utility.SharedFolderUtility.GetConstServerFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_051,
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                // 外観/水質 is checked
                if (input.TypeSearch == TypeSearch.GaikanKensa || input.TypeSearch == TypeSearch.SuishitsuKensa)
                {
                    // Get 正式名称
                    IGetSuishitsuShikenKoumokuMstByKeyBLInput blInput = new GetSuishitsuShikenKoumokuMstByKeyBLInput();
                    // 残留塩素の試験項目コード("070")
                    blInput.SuishitsuShikenKoumokuCd = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);
                    IGetSuishitsuShikenKoumokuMstByKeyBLOutput blOutput = new GetSuishitsuShikenKoumokuMstByKeyBusinessLogic().Execute(blInput);
                    if (blOutput.SuishitsuShikenKoumokuMstDataTable.Count == 0)
                    {
                        // エラー
                        output.ErrMsg = string.Format("対象の野帳ファイルが存在しません。\r\n試験項目コード：[{0}]", blInput.SuishitsuShikenKoumokuCd);
                        return output;
                    }

                    string seishikiNm = blOutput.SuishitsuShikenKoumokuMstDataTable[0].SeishikiNm;
                    string yachoFileNm = blOutput.SuishitsuShikenKoumokuMstDataTable[0].YachoFileNm;

                    // 野帳出力

                    // 出力先フォルダ作成
                    string tempLocalOutputPath = Path.Combine(localFilePath, seishikiNm);
                    //tempLocalOutputPath = Path.Combine(tempLocalOutputPath, input.IraiNoFolder);

                    // 出力先存在チェック
                    if (!Directory.Exists(tempLocalOutputPath))
                    {
                        // 存在しない場合、フォルダ作成
                        Directory.CreateDirectory(tempLocalOutputPath);
                    }

                    // 共有サーバから野帳ファイルをダウンロード
                    DoDownload(tempLocalOutputPath, serverFolder, yachoFileNm);

                    // 登録対象の DataTableを作成
                    KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                    {
                        KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] targetRows =
                            (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])input.PrintTable.Select(string.Empty, "SuishitsuKensaIraiNoCol");
                        foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow targetRow in targetRows)
                        {
                            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] checkRow =
                                (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])targetDT.Select(string.Format("SuishitsuKensaIraiNoCol='{0}'", targetRow.SuishitsuKensaIraiNoCol));
                            if (checkRow.Length > 0)
                            {
                                // 既に登録されている場合は、次の行へ
                                continue;
                            }
                            targetDT.ImportRow(targetRow);
                        }
                    }

                    // ダウンロードした野帳ファイルに情報をセット
                    DoPrint(input, tempLocalOutputPath, yachoFileNm + FILE_EXT, targetDT);

                    // DEL START 20141219 作り直しのためコメントアウト komatsu
                    //// SeishikiNm folder
                    //localFilePath = Path.Combine(localFilePath, seishikiNm);
                    //// IraiNo folder
                    //localFilePath = Path.Combine(localFilePath, input.IraiNoFolder);

                    //if (!Directory.Exists(localFilePath))
                    //{
                    //    // Create the directory to save file
                    //    Directory.CreateDirectory(localFilePath);
                    //}

                    //// 野帳ファイル名
                    //string yachoFileName = blOutput.SuishitsuShikenKoumokuMstDataTable.Count > 0 ?
                    //    blOutput.SuishitsuShikenKoumokuMstDataTable[0].YachoFileNm + FILE_EXT : string.Empty;

                    //try
                    //{
                    //    // Connect to server
                    //    Utility.SharedFolderUtility.Connect();

                    //    string sharedFile = Path.Combine(serverFolder, yachoFileName);

                    //    // File exists on server?
                    //    if (File.Exists(sharedFile))
                    //    {
                    //        // Download to local
                    //        Utility.SharedFolderUtility.DownloadFile(Path.Combine(localFilePath, yachoFileName), sharedFile);

                    //        // Print file
                    //        DoPrint(input, localFilePath, yachoFileName);
                    //    }
                    //    else
                    //    {
                    //        output.ErrMsg = string.Format("共有フォルダに野帳ファイルが存在しません。\r\n{0}", sharedFile);
                    //    }
                    //}
                    //catch
                    //{
                    //    throw;
                    //}
                    //finally
                    //{
                    //    // Disconnect from server
                    //    Utility.SharedFolderUtility.Disconnect();
                    //}
                    // DEL  END  20141219 作り直しのためコメントアウト komatsu
                }
                else // 計量証明 is checked
                {
                    // 野帳一覧取得
                    ISelectYachoFileNmListInfoDAOutput selOut = new SelectYachoFileNmListInfoDAOutput();
                    selOut.YachoListInfoDT = new SelectYachoFileNmListInfoDataAccess().Execute(new SelectYachoFileNmListInfoDAInput()).YachoListInfoDT;

                    // 野帳出力ループ処理開始
                    foreach (SuishitsuShikenKoumokuMstDataSet.YachoFileNmListInfoRow yachoRow in selOut.YachoListInfoDT)
                    {
                        // 出力対象一覧の水質試験項目コードが水質試験項目コードと一致するレコードの一覧を取得
                        KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] outputRows
                            = (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])input.PrintTable.Select(string.Format("SuishitsuShikenKoumokuCd = '{0}'", yachoRow.SuishitsuShikenKoumokuCd), "SuishitsuKensaIraiNoCol");

                        if (outputRows.Length == 0)
                        {
                            // 対象無
                            continue;
                        }

                        // 野帳出力

                        // 出力先フォルダ作成
                        string tempLocalOutputPath = Path.Combine(localFilePath, yachoRow.SeishikiNm);
                        //tempLocalOutputPath = Path.Combine(tempLocalOutputPath, input.IraiNoFolder);

                        // 出力先存在チェック
                        if (!Directory.Exists(tempLocalOutputPath))
                        {
                            // 存在しない場合、フォルダ作成
                            Directory.CreateDirectory(tempLocalOutputPath);
                        }

                        // 共有サーバから野帳ファイルをダウンロード
                        if (!DoDownload(tempLocalOutputPath, serverFolder, yachoRow.YachoFileNm))
                        {
                            // エラーの場合は次の野帳
                            output.ErrMsg = string.Format("共有フォルダに野帳ファイルが存在しません。\r\n{0}", yachoRow.YachoFileNm);
                            continue;
                        }

                        // 登録対象の DataTableを作成
                        KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                        {
                            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] targetRows =
                                (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])input.PrintTable.Select(string.Format("YachoFileNm='{0}'", yachoRow.YachoFileNm), "SuishitsuKensaIraiNoCol");
                            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow targetRow in targetRows)
                            {
                                KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[] checkRow =
                                    (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])targetDT.Select(string.Format("SuishitsuKensaIraiNoCol='{0}'", targetRow.SuishitsuKensaIraiNoCol));
                                if (checkRow.Length > 0)
                                {
                                    // 既に登録されている場合は、次の行へ
                                    continue;
                                }
                                targetDT.ImportRow(targetRow);
                            }
                        }

                        // ダウンロードした野帳ファイルに情報をセット
                        DoPrint(input, tempLocalOutputPath, yachoRow.YachoFileNm + FILE_EXT, targetDT);
                    }

                    // DEL START 20141219 作り直しのためコメントアウト komatsu
                    //foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in input.PrintTable)
                    //{
                    //    // Skip row contains empty yacho file name
                    //    if (string.IsNullOrEmpty(row.YachoFileNm.Trim()))
                    //    {
                    //        continue;
                    //    }

                    //    yachoFileName = row.YachoFileNm + FILE_EXT;

                    //    // Get 正式名称
                    //    IGetSuishitsuShikenKoumokuMstByKeyBLInput blInput = new GetSuishitsuShikenKoumokuMstByKeyBLInput();
                    //    blInput.SuishitsuShikenKoumokuCd = row.SuishitsuShikenKoumokuCd;
                    //    IGetSuishitsuShikenKoumokuMstByKeyBLOutput blOutput = new GetSuishitsuShikenKoumokuMstByKeyBusinessLogic().Execute(blInput);
                    //    string seishikiNm = blOutput.SuishitsuShikenKoumokuMstDataTable.Count > 0 ? blOutput.SuishitsuShikenKoumokuMstDataTable[0].SeishikiNm : string.Empty;

                    //    // Create seishikiNm folder
                    //    tempLocalFilePath = Path.Combine(tempLocalFilePath, seishikiNm);

                    //    if (!Directory.Exists(tempLocalFilePath))
                    //    {
                    //        // Create the directory to save file
                    //        Directory.CreateDirectory(tempLocalFilePath);
                    //    }

                    //    try
                    //    {
                    //        // Connect to server
                    //        Utility.SharedFolderUtility.Connect();

                    //        string sharedFile = Path.Combine(serverFolder, yachoFileName);

                    //        // File exists on server?
                    //        if (File.Exists(sharedFile))
                    //        {
                    //            // Download to local
                    //            Utility.SharedFolderUtility.DownloadFile(Path.Combine(tempLocalFilePath, yachoFileName), sharedFile);

                    //            // Print file
                    //            DoPrint(input, tempLocalFilePath, yachoFileName);
                    //        }
                    //        else
                    //        {
                    //            output.ErrMsg = string.Format("共有フォルダに野帳ファイルが存在しません。\r\n{0}", sharedFile);
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        throw;
                    //    }
                    //    finally
                    //    {
                    //        // Disconnect from server
                    //        Utility.SharedFolderUtility.Disconnect();
                    //    }

                    //    tempLocalFilePath = localFilePath;
                    //}
                    // DEL  END  20141219 作り直しのためコメントアウト komatsu
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

        #region DoDownload
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoDownload
        /// <summary>
        /// サーバの野帳ファイルをローカルフォルダにダウンロード
        /// </summary>
        /// <return>
        /// 
        /// </return>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/19  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoDownload(string tempLocalFolder, string serverFolder, string yachoFileName)
        {
            // 保存フォルダ

            // 出力先存在チェック
            if (!Directory.Exists(tempLocalFolder))
            {
                // 存在しない場合、フォルダ作成
                Directory.CreateDirectory(tempLocalFolder);

            }
            try
            {
                // 共有フォルダに接続
                if (!SharedFolderUtility.Connect())
                {
                    // サーバに接続できません
                    // 「サーバに接続できません。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバに接続できません。{0}", serverFolder));
                    return false;
                }

                // サーバファイル名
                string serverYachoFileNm = Path.Combine(serverFolder, yachoFileName + FILE_EXT);
                // ローカルファイル名
                string localYachoFileNm = Path.Combine(tempLocalFolder, yachoFileName + FILE_EXT);

                // サーバファイル名の存在確認
                if (!File.Exists(serverYachoFileNm))
                {
                    // サーバに 野帳ファイルが存在しない
                    // 「指定された{0}は存在しません。」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("指定された野帳ファイルが存在しません。{0}", serverYachoFileNm));
                    // エラー
                    return false;
                }

                // 共有フォルダからダウンロード
                if (!SharedFolderUtility.DownloadFile(localYachoFileNm, serverYachoFileNm))
                {
                    // サーバから 野帳ファイルのダウンロードに失敗しました。
                    // 「サーバから 野帳ファイルのダウンロードに失敗しました。{0}」
                    MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("サーバから野帳ファイルのダウンロードに失敗しました。{0} {1}", serverYachoFileNm, localYachoFileNm));
                    return false;
                }
            }
            catch (Exception ex)
            {
                // エラー処理
                // 共有フォルダへのアクセスに失敗しました。
                MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("共有フォルダへのアクセスに失敗しました。{0}", Path.GetDirectoryName(serverFolder)));
                throw ex;
            }
            finally
            {
                // 共有フォルダから切断
                SharedFolderUtility.Disconnect();
            }
            return true;
        }
        #endregion

        #region DoPrint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoPrint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="localFile"></param>
        /// <param name="yachoFileName"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoPrint(IOutputBtnClickALInput input, string localFile, string yachoFileName, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            string outputFileName = string.Concat(Path.GetFileNameWithoutExtension(yachoFileName), "_"/*, input.IraiNoFolder, Path.GetExtension(yachoFileName)*/);
            string formatPath = Path.Combine(localFile, yachoFileName);
            string baseSavePath = Path.Combine(localFile, outputFileName);

            switch (Path.GetFileNameWithoutExtension(yachoFileName))
            {
                case FILE_001:
                    PrintFile001(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_002:
                    PrintFile002(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_003:
                    PrintFile003(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_004:
                    PrintFile004(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_005:
                    PrintFile005(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_006:
                    PrintFile006(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_007:
                    PrintFile007(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_008:
                    PrintFile008(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_009:
                    PrintFile009(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_010:
                    PrintFile010(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_011:
                    PrintFile011(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_012:
                    PrintFile012(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_013:
                    PrintFile013(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_014:
                    PrintFile014(input, formatPath, baseSavePath, targetDT);
                    break;
                case FILE_015:
                    PrintFile015(input, formatPath, baseSavePath, targetDT);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region PrintFile001
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile001
        /// <summary>
        /// 001_残留塩素濃度_野帳設計書_export_vn_V1.02
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile001(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 19 == 0    // Maximum of 19 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint001ZanryuEnsoNodoBLInput blInput = new Print001ZanryuEnsoNodoBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    //blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print001ZanryuEnsoNodoBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile002
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile002
        /// <summary>
        /// 002_NO2-N（亜硝酸性窒素）（定性）_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile002(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 36 == 0 // Maximum of 36 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint002NO2TeiseiBLInput blInput = new Print002NO2TeiseiBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print002NO2TeiseiBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile003
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile003
        /// <summary>
        /// 003_NO3-N（硝酸性窒素）（定性）_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile003(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 36 == 0 // Maximum of 36 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint003NO3TeiseiBLInput blInput = new Print003NO3TeiseiBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print003NO3TeiseiBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile004
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile004
        /// <summary>
        /// 004_NO2-N（亜硝酸性窒素）（定量）_野帳設計書_exxport_vn_1.02
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile004(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            int bookCnt = 0;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 6 == 0 // Maximum of 6 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint004NO2TeiryoBLInput blInput = new Print004NO2TeiryoBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.RowIdx = rowIdx;
                    blInput.BookCnt = bookCnt;
                    blInput.PrintTable = targetDT;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print004NO2TeiryoBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                    // A book was printed!
                    bookCnt++;
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile005
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile005
        /// <summary>
        /// 005_NO3-N（硝酸性窒素）（定量）_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile005(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 005 NO3-N（硝酸性窒素）（定量）.xlsx
            {
                KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

                int rowIdx = 1;
                foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
                {
                    partTable.ImportRow(row);

                    // Print new workbook
                    if (rowIdx % 7 == 0 // Maximum of 7 rows
                        || rowIdx == targetDT.Rows.Count)
                    {
                        // Get save path by SuishitsuKensaIraiNo
                        string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                        string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                        string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                        IPrint005NO3TeiryoBLInput blInput = new Print005NO3TeiryoBLInput();
                        //blInput.AfterDispFlg = true;
                        blInput.FormatPath = formatPath;
                        blInput.PrintTable = partTable;
                        blInput.SystemDt = input.SystemDt;
                        // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                        blInput.SavePath = savePath;
                        new Print005NO3TeiryoBusinessLogic().Execute(blInput);

                        // Reset the print table
                        partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                    }

                    rowIdx++;
                }
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile006
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile006
        /// <summary>
        /// 006_COD（化学的酸素要求量）_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile006(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 006 COD（化学的酸素要求量）.xlsx
            {
                KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

                int rowIdx = 1;
                foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
                {
                    partTable.ImportRow(row);

                    // Print new workbook
                    if (rowIdx % 23 == 0 // Maximum of 23 rows
                        || rowIdx == targetDT.Rows.Count)
                    {
                        // Get save path by SuishitsuKensaIraiNo
                        string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                        string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                        string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                        IPrint006CODKagakutekisansoyokyuryoBLInput blInput = new Print006CODKagakutekisansoyokyuryoBLInput();
                        //blInput.AfterDispFlg = true;
                        blInput.FormatPath = formatPath;
                        blInput.PrintTable = partTable;
                        blInput.SystemDt = input.SystemDt;
                        // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                        blInput.SavePath = savePath;
                        new Print006CODKagakutekisansoyokyuryoBusinessLogic().Execute(blInput);

                        // Reset the print table
                        partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                    }

                    rowIdx++;
                }
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile007
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile007
        /// <summary>
        /// 007_大腸菌群数_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile007(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 007
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 15 == 0 // Maximum of 15 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint007DaichoKingunsuBLInput blInput = new Print007DaichoKingunsuBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print007DaichoKingunsuBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile008
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile008
        /// <summary>
        /// 008_T-N（全窒素）_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile008(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 008 - T-N（全窒素）.xlsx
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 10 == 0 // Maximum of 10 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint008TNZenchitsusoBLInput blInput = new Print008TNZenchitsusoBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print008TNZenchitsusoBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile009
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile009
        /// <summary>
        /// 009_T-P（全りん）_野帳設計書_export_vn_V1.02
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile009(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 009 T-P（全りん）.xlsx
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 10 == 0 // Maximum of 10 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint009TPZenzinBLInput blInput = new Print009TPZenzinBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print009TPZenzinBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile010
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile010
        /// <summary>
        /// 010_ヘキサン抽出物質_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile010(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 010 ヘキサン抽出物質.xlsx
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 7 == 0 // Maximum of 7 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint010HekisanChushutsuBusshitsuBLInput blInput = new Print010HekisanChushutsuBusshitsuBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print010HekisanChushutsuBusshitsuBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile011
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile011
        /// <summary>
        /// 011_ABS（陰イオン界面活性剤）_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile011(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 011 ABS（陰イオン界面活性剤）.xlsx
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 7 == 0 // Maximum of 7 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint011ABSIonkaimenkasseizaiBLInput blInput = new Print011ABSIonkaimenkasseizaiBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print011ABSIonkaimenkasseizaiBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile012
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile012
        /// <summary>
        /// 012_外観_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile012(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 012 外観.xlsx
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 36 == 0 // Maximum of 36 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint012GaikanBLInput blInput = new Print012GaikanBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print012GaikanBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile013
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile013
        /// <summary>
        /// 013_臭気_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile013(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 013 臭気.xlsx
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 36 == 0 // Maximum of 36 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint013ShukiBLInput blInput = new Print013ShukiBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print013ShukiBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile014
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile014
        /// <summary>
        /// 014_りん酸イオン_野帳設計書_export_vn_1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile014(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            // 014 りん酸イオン.xlsx
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 10 == 0 // Maximum of 10 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint014RinsanIonBLInput blInput = new Print014RinsanIonBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print014RinsanIonBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region PrintFile015
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrintFile015
        /// <summary>
        /// 015_色度_野帳設計書_export_vn_V1.01
        /// </summary>
        /// <param name="input"></param>
        /// <param name="formatPath"></param>
        /// <param name="baseSavePath"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrintFile015(IOutputBtnClickALInput input, string formatPath, string baseSavePath, KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable targetDT)
        {
            KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();

            int rowIdx = 1;
            foreach (KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow row in targetDT)
            {
                partTable.ImportRow(row);

                // Print new workbook
                if (rowIdx % 3 == 0 // Maximum of 3 rows
                    || rowIdx == targetDT.Rows.Count)
                {
                    // Get save path by SuishitsuKensaIraiNo
                    string minIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol asc"))[0].SuishitsuKensaIraiNoCol;
                    string maxIraiNo = ((KensaDaicho11joHdrTblDataSet.YachoOutputKensaListRow[])partTable.Select(string.Empty, "SuishitsuKensaIraiNoCol desc"))[0].SuishitsuKensaIraiNoCol;
                    string savePath = string.Concat(baseSavePath, minIraiNo, "-", maxIraiNo, Path.GetExtension(formatPath));

                    IPrint015IrodoBLInput blInput = new Print015IrodoBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = formatPath;
                    blInput.PrintTable = partTable;
                    blInput.SystemDt = input.SystemDt;
                    // blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SavePath = savePath;
                    new Print015IrodoBusinessLogic().Execute(blInput);

                    // Reset the print table
                    partTable = new KensaDaicho11joHdrTblDataSet.YachoOutputKensaListDataTable();
                }

                rowIdx++;
            }

            try
            {
                // Delete template when print completed
                if (File.Exists(formatPath))
                {
                    File.Delete(formatPath);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
